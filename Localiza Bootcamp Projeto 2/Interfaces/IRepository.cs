using System;
using System.Collections.Generic;
using System.Text;

namespace Localiza_Bootcamp_Projeto_2.Interfaces
{
    public interface IRepository<T>
    {
        List<T> List();
        T ReturnById(int id);
        void Insert(T entitie);
        void Delete(int id);
        void Update(int id, T entitie);
        int NextId();
    }
}
