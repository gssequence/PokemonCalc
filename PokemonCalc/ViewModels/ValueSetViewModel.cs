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
    public class ValueSetViewModel : ViewModel
    {
        public int Num { get; private set; }
        public string NumStr
        {
            get
            {
                if (Num < 10) return Num.ToString();
                return Num.ToString() + " (" + toBase32() + ")";
            }
        }

        #region H変更通知プロパティ
        private int _H;

        public int H
        {
            get
            { return _H; }
            set
            { 
                if (_H == value)
                    return;
                _H = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region A変更通知プロパティ
        private int _A;

        public int A
        {
            get
            { return _A; }
            set
            { 
                if (_A == value)
                    return;
                _A = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region B変更通知プロパティ
        private int _B;

        public int B
        {
            get
            { return _B; }
            set
            { 
                if (_B == value)
                    return;
                _B = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region C変更通知プロパティ
        private int _C;

        public int C
        {
            get
            { return _C; }
            set
            { 
                if (_C == value)
                    return;
                _C = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region D変更通知プロパティ
        private int _D;

        public int D
        {
            get
            { return _D; }
            set
            { 
                if (_D == value)
                    return;
                _D = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region S変更通知プロパティ
        private int _S;

        public int S
        {
            get
            { return _S; }
            set
            { 
                if (_S == value)
                    return;
                _S = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsMatchH変更通知プロパティ
        private bool _IsMatchH;

        public bool IsMatchH
        {
            get
            { return _IsMatchH; }
            set
            { 
                if (_IsMatchH == value)
                    return;
                _IsMatchH = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsMatchA変更通知プロパティ
        private bool _IsMatchA;

        public bool IsMatchA
        {
            get
            { return _IsMatchA; }
            set
            { 
                if (_IsMatchA == value)
                    return;
                _IsMatchA = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsMatchB変更通知プロパティ
        private bool _IsMatchB;

        public bool IsMatchB
        {
            get
            { return _IsMatchB; }
            set
            { 
                if (_IsMatchB == value)
                    return;
                _IsMatchB = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsMatchC変更通知プロパティ
        private bool _IsMatchC;

        public bool IsMatchC
        {
            get
            { return _IsMatchC; }
            set
            { 
                if (_IsMatchC == value)
                    return;
                _IsMatchC = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsMatchD変更通知プロパティ
        private bool _IsMatchD;

        public bool IsMatchD
        {
            get
            { return _IsMatchD; }
            set
            { 
                if (_IsMatchD == value)
                    return;
                _IsMatchD = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region IsMatchS変更通知プロパティ
        private bool _IsMatchS;

        public bool IsMatchS
        {
            get
            { return _IsMatchS; }
            set
            { 
                if (_IsMatchS == value)
                    return;
                _IsMatchS = value;
                RaisePropertyChanged();
            }
        }
        #endregion


        public ValueSetViewModel(int num, int h, int a, int b, int c, int d, int s)
        {
            Num = num;
            H = h;
            A = a;
            B = b;
            C = c;
            D = d;
            S = s;
        }

        private char toBase32()
        {
            if (Num < 10) return Num.ToString()[0];
            return (char)('A' + Num - 10);
        }
    }
}
