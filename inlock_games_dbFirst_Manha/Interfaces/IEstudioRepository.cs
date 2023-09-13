using inlock_games_dbFirst_Manha.Domains;

namespace inlock_games_dbFirst_Manha.Interfaces
{
    public interface IEstudioRepository
    {
        List<Estudio> Listar();
        Estudio BuscarPorId(Guid id);
        void Cadastrar(Estudio estudio);
        void Atualizar(Guid id, Estudio estudio);
        void Deletar(Guid id);
        List<Estudio> ListarComJogos();

    }
}
