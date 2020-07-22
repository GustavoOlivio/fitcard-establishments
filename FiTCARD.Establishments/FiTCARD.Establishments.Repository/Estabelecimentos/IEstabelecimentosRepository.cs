using FiTCARD.Establishments.Model.Estabelecimentos;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Repository.Estabelecimentos
{
    public interface IEstabelecimentosRepository
    {
        EstabelecimentosModel Get(int id);
        IEnumerable<EstabelecimentosModel> GetList();
        int Insert(EstabelecimentosModel obj);
        void Update(EstabelecimentosModel obj);
        void Delete(int id);
    }
}