using FiTCARD.Establishments.Model.Categorias;
using FiTCARD.Establishments.Repository.Master;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Repository.Categorias
{
    public class CategoriasRepository : ICategoriasRepository
    {
        private readonly IMasterRepository masterRepository;
        
        public CategoriasRepository(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public IEnumerable<CategoriasModel> GetList()
        {
            var query = "SELECT * FROM [dbo].[Categorias] (NOLOCK)";

            var _categorias = masterRepository.QueryList<CategoriasModel>(query);

            return _categorias;
        }

        public CategoriasModel Get(int id)
        {
            var query = "SELECT * FROM [dbo].[Categorias] (NOLOCK) WHERE [Id] = @id";

            var categoria = masterRepository.QueryGetById<CategoriasModel>(query, id);

            return categoria;
        }
        
        public void Update(CategoriasModel categoria)
        {
            var query = @"
                UPDATE [dbo].[Categorias]
                  SET[Nome] = @Nome,
                    [TelefoneObrigatorio] = @TelefoneObrigatorio,
                        [Ativo] = @Ativo
                WHERE[Id] = @Id";

            masterRepository.QueryUpdate(query, categoria);
        }

        public int Insert(CategoriasModel categoria)
        {
            var query = @"
                INSERT INTO [dbo].[Categorias] (
                  [Nome],
                    [TelefoneObrigatorio],
                      [DataCadastro],
                        [Ativo])
                VALUES (
                  @Nome,
                    @TelefoneObrigatorio,
                      GETDATE(),
                        @Ativo);
                SELECT [Id] FROM [dbo].[Categorias] (NOLOCK) WHERE [Id] = @@IDENTITY";

            var categoriaId = masterRepository.QueryInsert<CategoriasModel>(query, categoria);

            return categoriaId;
        }

        public void Delete(int id)
        {
            var query = "DELETE [dbo].[Categorias] WHERE [Id] = @id";

            masterRepository.QueryDelete(query, id);
        }
    }
}