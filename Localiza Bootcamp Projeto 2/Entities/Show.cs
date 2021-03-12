using System;
using System.Collections.Generic;
using System.Text;
using Localiza_Bootcamp_Projeto_2.Enums;

namespace Localiza_Bootcamp_Projeto_2.Entities
{
    class Show : BaseEntitie
    {
        private Genre Genre { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }
        private int Year { get; set; }

        private bool Deleted { get; set; }

        public Show()
        {
        }

        public Show(int id, Genre genre, string title, string description, int year)
        {
            Id = id;
            Genre = genre;
            Title = title;
            Description = description;
            Year = year;
            Deleted = false;
        }

        public string ReturnTitle()
        {
            return Title;
        }

        public int ReturnId()
        {
            return Id;
        }

        public bool IsDeleted()
        {
            return Deleted;
        }

        public void Delete()
        {
            Deleted = true;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Genre: ");
            sb.Append(Genre);
            sb.Append(Environment.NewLine);
            sb.Append("Title: ");
            sb.Append(Title);
            sb.Append(Environment.NewLine);
            sb.Append("Description: ");
            sb.Append(Description);
            sb.Append(Environment.NewLine);
            sb.Append("First Season Aired: ");
            sb.Append(Year);
            sb.Append(Environment.NewLine);
            sb.Append("Deleted: ");
            sb.Append(Deleted);
            sb.Append(Environment.NewLine);
            return sb.ToString();
        }
    }
}
