using System;
using System.Collections.Generic;

namespace inlock_games_dbFirst_Manha.Domains;

public partial class Estudio
{
    public Guid IdEstudio { get; set; } // = Guid.NewGuid();
    //Desta forma gera um novo guid quando é criado um novo objeto.

    public string Nome { get; set; } = null!;

    public virtual ICollection<Jogo> Jogos { get; set; } = new List<Jogo>();
}
