using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCalc.Models
{
    public enum ParameterType
    {
        H, A, B, C, D, S, None
    }

    [Flags]
    public enum EvenOddType
    {
        Even = (1 << 1),
        Odd = (1 << 0),
        Both = (Even | Odd),
        Undefined = 0
    }
}
