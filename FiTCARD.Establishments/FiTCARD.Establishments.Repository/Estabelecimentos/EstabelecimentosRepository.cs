using FiTCARD.Establishments.Model.Estabelecimentos;
using FiTCARD.Establishments.Repository.Master;
using System.Collections.Generic;

namespace FiTCARD.Establishments.Repository.Estabelecimentos
{
    public class EstabelecimentosRepository : IEstabelecimentosRepository
    {
        private readonly IMasterRepository masterRepository;
        public EstabelecimentosRepository(IMasterRepository masterRepository)
        {
            this.masterRepository = masterRepository;
        }

        public IEnumerable<EstabelecimentosModel> GetList()
        {
            var query = "SELECT * FROM [dbo].[Estabelecimentos] (NOLOCK) WHERE [Ativo] = 1";

            var _estabelecimentos = masterRepository.QueryList<EstabelecimentosModel>(query);

            return _estabelecimentos;
        }

        public EstabelecimentosModel Get(int id)
        {
            var query = "SELECT * FROM [dbo].[Estabelecimentos] (NOLOCK) WHERE [Id] = @id";

            var categoria = masterRepository.QueryGetById<EstabelecimentosModel>(query, id);

            return categoria;
        }

        public int Insert(EstabelecimentosModel obj)
        {
            var query = @"
                INSERT INTO [dbo].[Estabelecimentos]
                  ([RazaoSocial],
                  [NomeFantasia],
                  [CNPJ],
                  [Email],
                  [Endereco],
                  [Cidade],
                  [Estado],
                  [Telefone],
                  [DataCadastro],
                  [CategoriaId],
                  [Ativo],
                  [BancoAgencia],
                  [BancoConta])
                VALUES
                  (@RazaoSocial,
                  @NomeFantasia,
                  @CNPJ,
                  @Email,
                  @Endereco,
		          @Cidade,
                  @Estado,
                  @Telefone,
                  GETDATE(),
                  @CategoriaId,
                  @Ativo,
                  @BancoAgencia,
                  @BancoConta);
                SELECT [Id] FROM [dbo].[Estabelecimentos] (NOLOCK) WHERE [Id] = @@IDENTITY";

            var estabelecimentoId = masterRepository.QueryInsert<int>(query, obj);

            return estabelecimentoId;
        }

        public void Update(EstabelecimentosModel obj)
        {
            var query = @"
                UPDATE [dbo].[Estabelecimentos]
                SET [RazaoSocial] = @RazaoSocial,
                    [NomeFantasia] = @NomeFantasia,
                    [CNPJ] = @CNPJ,
                    [Email] = @Email,
                    [Endereco] = @Endereco,
                    [Cidade] = @Cidade,
                    [Estado] = @Estado,
                    [Telefone] = @Telefone,
                    [CategoriaId] = @CategoriaId,
                    [Ativo] = @Ativo,
                    [BancoAgencia] = @BancoAgencia,
                    [BancoConta] = @BancoConta
              WHERE [Id] = @Id";

            masterRepository.QueryUpdate(query, obj);
        }

        public void Delete(int id)
        {
            var query = "DELETE [dbo].[Estabelecimentos] WHERE [Id] = @id";

            masterRepository.QueryDelete(query, id);
        }
    }
}