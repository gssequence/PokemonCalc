using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using Livet;
using Livet.Commands;
using Livet.Messaging;
using Livet.Messaging.IO;
using Livet.EventListeners;
using Livet.Messaging.Windows;

using PokemonCalc.Models;

namespace PokemonCalc.ViewModels
{
    public class PokemonDataViewModel : ViewModel
    {
        private PokemonData model;

        public string Number { get { return model.Number; } }
        public string Name { get { return model.Name; } }
        public int H { get { return model.H; } }
        public int A { get { return model.A; } }
        public int B { get { return model.B; } }
        public int C { get { return model.C; } }
        public int D { get { return model.D; } }
        public int S { get { return model.S; } }
        public int Total { get { return model.H + model.A + model.B + model.C + model.D + model.S; } }

        public PokemonDataViewModel(PokemonData model)
        {
            this.model = model;
        }
    }
}
