using inlock_games_dbFirst_Manha.Contexts;
using inlock_games_dbFirst_Manha.Domains;
using inlock_games_dbFirst_Manha.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace inlock_games_dbFirst_Manha.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //Instanciamos a Context, pois ele tem acesso a todo o banco de dados
        InlockContext ctx = new InlockContext();
        public void Atualizar(Guid id, Estudio estudio)
        {
            Estudio estudioBuscado  = ctx.Estudios.Find(id)!;

            if (estudioBuscado != null)
            {
                estudioBuscado.Nome = estudio.Nome;
            }

            ctx.Estudios.Update(estudioBuscado);
            
            ctx.SaveChanges();
        }

        public Estudio BuscarPorId(Guid id)
        {
            return ctx.Estudios.FirstOrDefault(e => e.IdEstudio == id );
        }

        public void Cadastrar(Estudio estudio)
        {
            //como não temos o identity para gerar um novo ID automaticamente, inserimos o novo Guid aqui ou tambem temos a opção de deixa-lo na program, SIGA O EXEMPLO LA.
            estudio.IdEstudio = Guid.NewGuid();

            ctx.Estudios.Add(estudio);

            ctx.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            Estudio estudioBuscado = ctx.Estudios.Find(id)!;

            ctx.Estudios.Remove(estudioBuscado);

            ctx.SaveChanges();
        }

        public List<Estudio> Listar()
        {
            //Chamar o objeto ctx para listar nossa lista de Estudio, pois ele que detem o caminho para o nosso BD
            return ctx.Estudios.ToList();
        }

        public List<Estudio> ListarComJogos()
        {
            //Retorna a lsita de Estudio com todos os jogos que pertence á ela
            return ctx.Estudios.Include(e => e.Jogos).ToList();
        }
    }
}
