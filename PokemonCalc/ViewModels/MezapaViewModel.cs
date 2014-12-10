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
    public class MezapaViewModel : ViewModel
    {
        #region Types

        #region Fire変更通知プロパティ
        private bool _Fire;

        public bool Fire
        {
            get
            { return _Fire; }
            set
            { 
                if (_Fire == value)
                    return;
                _Fire = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Water変更通知プロパティ
        private bool _Water;

        public bool Water
        {
            get
            { return _Water; }
            set
            { 
                if (_Water == value)
                    return;
                _Water = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Electric変更通知プロパティ
        private bool _Electric;

        public bool Electric
        {
            get
            { return _Electric; }
            set
            { 
                if (_Electric == value)
                    return;
                _Electric = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Grass変更通知プロパティ
        private bool _Grass;

        public bool Grass
        {
            get
            { return _Grass; }
            set
            { 
                if (_Grass == value)
                    return;
                _Grass = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Ice変更通知プロパティ
        private bool _Ice;

        public bool Ice
        {
            get
            { return _Ice; }
            set
            { 
                if (_Ice == value)
                    return;
                _Ice = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Fighting変更通知プロパティ
        private bool _Fighting;

        public bool Fighting
        {
            get
            { return _Fighting; }
            set
            { 
                if (_Fighting == value)
                    return;
                _Fighting = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Poison変更通知プロパティ
        private bool _Poison;

        public bool Poison
        {
            get
            { return _Poison; }
            set
            { 
                if (_Poison == value)
                    return;
                _Poison = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Ground変更通知プロパティ
        private bool _Ground;

        public bool Ground
        {
            get
            { return _Ground; }
            set
            { 
                if (_Ground == value)
                    return;
                _Ground = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Flying変更通知プロパティ
        private bool _Flying;

        public bool Flying
        {
            get
            { return _Flying; }
            set
            { 
                if (_Flying == value)
                    return;
                _Flying = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Psychic変更通知プロパティ
        private bool _Psychic;

        public bool Psychic
        {
            get
            { return _Psychic; }
            set
            { 
                if (_Psychic == value)
                    return;
                _Psychic = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Bug変更通知プロパティ
        private bool _Bug;

        public bool Bug
        {
            get
            { return _Bug; }
            set
            { 
                if (_Bug == value)
                    return;
                _Bug = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Rock変更通知プロパティ
        private bool _Rock;

        public bool Rock
        {
            get
            { return _Rock; }
            set
            { 
                if (_Rock == value)
                    return;
                _Rock = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Ghost変更通知プロパティ
        private bool _Ghost;

        public bool Ghost
        {
            get
            { return _Ghost; }
            set
            { 
                if (_Ghost == value)
                    return;
                _Ghost = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Dragon変更通知プロパティ
        private bool _Dragon;

        public bool Dragon
        {
            get
            { return _Dragon; }
            set
            { 
                if (_Dragon == value)
                    return;
                _Dragon = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Dark変更通知プロパティ
        private bool _Dark;

        public bool Dark
        {
            get
            { return _Dark; }
            set
            { 
                if (_Dark == value)
                    return;
                _Dark = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Steel変更通知プロパティ
        private bool _Steel;

        public bool Steel
        {
            get
            { return _Steel; }
            set
            { 
                if (_Steel == value)
                    return;
                _Steel = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Undefined変更通知プロパティ
        private bool _Undefined;

        public bool Undefined
        {
            get
            { return _Undefined; }
            set
            { 
                if (_Undefined == value)
                    return;
                _Undefined = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #endregion

        public MezapaViewModel()
        {

        }

        public void CheckTypes(EvenOddType h, EvenOddType a, EvenOddType b, EvenOddType c, EvenOddType d, EvenOddType s)
        {
            if (h == EvenOddType.Undefined || a == EvenOddType.Undefined || b == EvenOddType.Undefined || c == EvenOddType.Undefined || d == EvenOddType.Undefined || s == EvenOddType.Undefined)
            {
                Undefined = true;
                Fire = Water = Electric = Grass = Ice = Fighting = Poison = Ground = Flying = Psychic = Bug = Rock = Ghost = Dragon = Dark = Steel = false;
                return;
            }
            else
            {
                Dark = type(h, a, b, c, d, s, true, true, true, true, true, true);

                Dragon = type(h, a, b, c, d, s, false, true, true, true, true, true)
                    || type(h, a, b, c, d, s, true, false, true, true, true, true)
                    || type(h, a, b, c, d, s, false, false, true, true, true, true)
                    || type(h, a, b, c, d, s, true, true, false, true, true, true);

                Ice = type(h, a, b, c, d, s, false, true, false, true, true, true)
                    || type(h, a, b, c, d, s, true, false, false, true, true, true)
                    || type(h, a, b, c, d, s, false, false, false, true, true, true)
                    || type(h, a, b, c, d, s, true, true, true, true, true, false);

                Psychic = type(h, a, b, c, d, s, false, true, true, true, true, false)
                    || type(h, a, b, c, d, s, true, false, true, true, true, false)
                    || type(h, a, b, c, d, s, false, false, true, true, true, false)
                    || type(h, a, b, c, d, s, true, true, false, true, true, false);

                Electric = type(h, a, b, c, d, s, false, true, false, true, true, false)
                    || type(h, a, b, c, d, s, true, false, false, true, true, false)
                    || type(h, a, b, c, d, s, false, false, false, true, true, false)
                    || type(h, a, b, c, d, s, true, true, true, false, true, true);

                Grass = type(h, a, b, c, d, s, false, true, true, false, true, true)
                    || type(h, a, b, c, d, s, true, false, true, false, true, true)
                    || type(h, a, b, c, d, s, false, false, true, false, true, true)
                    || type(h, a, b, c, d, s, true, true, false, false, true, true)
                    || type(h, a, b, c, d, s, false, true, false, false, true, true);

                Water = type(h, a, b, c, d, s, true, false, false, false, true, true)
                    || type(h, a, b, c, d, s, false, false, false, false, true, true)
                    || type(h, a, b, c, d, s, true, true, true, false, true, false)
                    || type(h, a, b, c, d, s, false, true, true, false, true, false);

                Fire = type(h, a, b, c, d, s, true, false, true, false, true, false)
                    || type(h, a, b, c, d, s, false, false, true, false, true, false)
                    || type(h, a, b, c, d, s, true, true, false, false, true, false)
                    || type(h, a, b, c, d, s, false, true, false, false, true, false);

                Steel = type(h, a, b, c, d, s, true, false, false, false, true, false)
                    || type(h, a, b, c, d, s, false, false, false, false, true, false)
                    || type(h, a, b, c, d, s, true, true, true, true, false, true)
                    || type(h, a, b, c, d, s, false, true, true, true, false, true);

                Ghost = type(h, a, b, c, d, s, true, false, true, true, false, true)
                    || type(h, a, b, c, d, s, false, false, true, true, false, true)
                    || type(h, a, b, c, d, s, true, true, false, true, false, true)
                    || type(h, a, b, c, d, s, false, true, false, true, false, true);

                Bug = type(h, a, b, c, d, s, true, false, false, true, false, true)
                    || type(h, a, b, c, d, s, false, false, false, true, false, true)
                    || type(h, a, b, c, d, s, true, true, true, true, false, false)
                    || type(h, a, b, c, d, s, false, true, true, true, false, false)
                    || type(h, a, b, c, d, s, true, false, true, true, false, false);

                Rock = type(h, a, b, c, d, s, false, false, true, true, false, false)
                    || type(h, a, b, c, d, s, true, true, false, true, false, false)
                    || type(h, a, b, c, d, s, false, true, false, true, false, false)
                    || type(h, a, b, c, d, s, true, false, false, true, false, false);

                Ground = type(h, a, b, c, d, s, false, false, false, true, false, false)
                    || type(h, a, b, c, d, s, true, true, true, false, false, true)
                    || type(h, a, b, c, d, s, false, true, true, false, false, true)
                    || type(h, a, b, c, d, s, true, false, true, false, false, true);

                Poison = type(h, a, b, c, d, s, false, false, true, false, false, true)
                    || type(h, a, b, c, d, s, true, true, false, false, false, true)
                    || type(h, a, b, c, d, s, false, true, false, false, false, true)
                    || type(h, a, b, c, d, s, true, false, false, false, false, true);

                Flying = type(h, a, b, c, d, s, false, false, false, false, false, true)
                    || type(h, a, b, c, d, s, true, true, true, false, false, false)
                    || type(h, a, b, c, d, s, false, true, true, false, false, false)
                    || type(h, a, b, c, d, s, true, false, true, false, false, false);

                Fighting = type(h, a, b, c, d, s, false, false, true, false, false, false)
                    || type(h, a, b, c, d, s, true, true, false, false, false, false)
                    || type(h, a, b, c, d, s, false, true, false, false, false, false)
                    || type(h, a, b, c, d, s, true, false, false, false, false, false)
                    || type(h, a, b, c, d, s, false, false, false, false, false, false);

                Undefined = !(Fire || Water || Electric || Grass || Ice || Fighting || Poison || Ground || Flying || Psychic || Bug || Rock || Ghost || Dragon || Dark || Steel);
            }
        }

        private bool type(EvenOddType h, EvenOddType a, EvenOddType b, EvenOddType c, EvenOddType d, EvenOddType s,
            bool expH, bool expA, bool expB, bool expC, bool expD, bool expS)
        {
            return toBool(h, expH) && toBool(a, expA) && toBool(b, expB) && toBool(c, expC) && toBool(d, expD) && toBool(s, expS);
        }

        private bool toBool(EvenOddType eot, bool expected)
        {
            switch (eot)
            {
                case EvenOddType.Even:
                    return !expected;
                case EvenOddType.Odd:
                    return expected;
                default:
                    return true;
            }
        }
    }
}
