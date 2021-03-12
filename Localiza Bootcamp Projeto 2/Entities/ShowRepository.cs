using System;
using System.Collections.Generic;
using System.Text;
using Localiza_Bootcamp_Projeto_2.Interfaces;

namespace Localiza_Bootcamp_Projeto_2.Entities
{
    class ShowRepository : IRepository<Show>
    {
        private List<Show> shows = new List<Show>();
        public void Delete(int id)
        {
            shows[id].Delete();
        }

        public void Insert(Show entitie)
        {
            shows.Add(entitie);
        }

        public List<Show> List()
        {
            return shows;
        }

        public int NextId()
        {
            return shows.Count;
        }

        public Show ReturnById(int id)
        {
            return shows[id];
        }

        public void Update(int id, Show entitie)
        {
            shows[id] = entitie;
        }
    }
}
