﻿using System;
using System.Collections.Generic;

namespace inlock_games_dbFirst_Manha.Domains;

public partial class Jogo
{
    public Guid IdJogo { get; set; }

    public Guid IdEstudio { get; set; }

    public string Nome { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public DateTime DataLancamento { get; set; }

    public decimal Valor { get; set; }

    public virtual Estudio IdEstudioNavigation { get; set; } = null!;
}
