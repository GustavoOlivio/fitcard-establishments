using FiTCARD.Establishments.Model.Categorias;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Repository.Categorias
{
    public interface ICategoriasRepository
    {
        CategoriasModel Get(int id);
        IEnumerable<CategoriasModel> GetList();
        int Insert(CategoriasModel obj);
        void Update(CategoriasModel obj);
        void Delete(int id);
    }
}