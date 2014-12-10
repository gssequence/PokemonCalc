using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonCalc.Models
{
    public class PokemonData
    {
        public string Number { get; private set; }
        public string Name { get; private set; }
        public int H { get; private set; }
        public int A { get; private set; }
        public int B { get; private set; }
        public int C { get; private set; }
        public int D { get; private set; }
        public int S { get; private set; }

        public PokemonData(string number, string name, int h, int a, int b, int c, int d, int s)
        {
            Number = number;
            Name = name;
            H = h;
            A = a;
            B = b;
            C = c;
            D = d;
            S = s;
        }
    }
}
