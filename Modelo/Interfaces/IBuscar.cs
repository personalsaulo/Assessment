﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo.Interfaces
{
   public interface IBuscar
    {
        Pessoa BuscaPorNome(string nome);
    }
}
