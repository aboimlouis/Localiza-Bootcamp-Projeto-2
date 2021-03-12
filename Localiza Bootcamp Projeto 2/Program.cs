using System;
using System.Collections.Generic;
using System.Text;
using Localiza_Bootcamp_Projeto_2.Entities;
using Localiza_Bootcamp_Projeto_2.Enums;

namespace Localiza_Bootcamp_Projeto_2
{
    class Program
    {
        static ShowRepository repository = new ShowRepository();
        static void Main(string[] args)
        {
            string userChoice = GetUserChoice();

            while (userChoice != "X")
            {
                if (userChoice == "1") 
                {
                    ListShows();
                }
                else if (userChoice == "2")
                {
                    InsertNewShow();
                }
                else if (userChoice == "3")
                {
                    UpdateShow();
                }
                else if (userChoice == "4")
                {
                    DeleteShow();
                }
                else if (userChoice == "5")
                {
                    ShowInfo();
                }
                else if (userChoice == "C")
                {
                    Console.Clear();
                }
                else if (userChoice == "X")
                {
                    return;
                }
                else
                {
                    //Console.WriteLine("Please select a valid option.");
                    throw new ArgumentOutOfRangeException();
                }
                userChoice = GetUserChoice();
            }
        }

        public static void ListShows()
        {
            Console.WriteLine("1 - List shows");

            var shows = repository.List(); //Deveria manter como var? Ou usar List<Show>?
            if (shows.Count != 0)
            {
                foreach (Show show in shows)
                {
                    if (!show.IsDeleted())
                        Console.WriteLine("#ID {0}: {1}", show.ReturnId(), show.ReturnTitle());
                    else
                        Console.WriteLine("#ID {0}: DELETED", show.ReturnId());
                }
            }
            else
            {
                Console.WriteLine("No shows recorded in the system.");
            }
        }

        public static void InsertNewShow()
        {
            Console.WriteLine("2 - Insert new show");

            repository.Insert(ShowInput(repository.NextId()));
        }

        public static void UpdateShow()
        {
            Console.WriteLine("3 - Update show");

            Console.Write("Type show ID: ");
            int id = int.Parse(Console.ReadLine());
            if (!repository.ReturnById(id).IsDeleted())
                repository.Update(id, ShowInput(id));
            else
                Console.WriteLine("This show has been deleted.");
        }
        public static void DeleteShow()
        {
            Console.WriteLine("4 - Delete show");

            Console.Write("Type the show ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            if (!repository.ReturnById(id).IsDeleted())
                repository.Delete(id);
            else
                Console.WriteLine("Show has been deleted already.");
        }
        public static void ShowInfo()
        {
            Console.WriteLine("5 - Show info");

            Console.Write("Type the show ID: ");

            int id = int.Parse(Console.ReadLine());
            if (!repository.ReturnById(id).IsDeleted())
                Console.WriteLine(repository.ReturnById(id).ToString());
            else
                Console.WriteLine("This show has been deleted.");
        }
        private static Show ShowInput(int id)
        {
            StringBuilder showGenre = new StringBuilder();
            foreach (int i in Enum.GetValues(typeof(Genre)))
            {
                showGenre.AppendLine(Enum.GetName(typeof(Genre), i));
            }
            showGenre.Append("Please, select the show genre: ");

            Console.Write(showGenre.ToString());
            Genre inputGenre = Enum.Parse<Genre>(Console.ReadLine());
            Console.Write("Type the show title: ");
            string inputTitle = Console.ReadLine();
            Console.Write("Type the show year of release: ");
            int inputYear = int.Parse(Console.ReadLine());
            Console.Write("Type the show description: ");
            string inputDescription = Console.ReadLine();

            return new Show(id, inputGenre, inputTitle, inputDescription, inputYear);
        }
        private static string GetUserChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Select an option: ");
            Console.WriteLine("1 - List shows");
            Console.WriteLine("2 - Insert new show");
            Console.WriteLine("3 - Update show");
            Console.WriteLine("4 - Delete show");
            Console.WriteLine("5 - Show info");
            Console.WriteLine("C - Clean Screen");
            Console.WriteLine("X - Exit");

            string userChoice = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return userChoice;
        }
    }
}
