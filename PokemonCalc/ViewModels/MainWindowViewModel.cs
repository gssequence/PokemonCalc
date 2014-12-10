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
using System.Collections.ObjectModel;

namespace PokemonCalc.ViewModels
{
    public class MainWindowViewModel : ViewModel
    {
        private Pokemon model;
        private List<List<bool>> filter;

        #region PokemonData変更通知プロパティ
        private ReadOnlyDispatcherCollection<PokemonDataViewModel> _PokemonData;

        public ReadOnlyDispatcherCollection<PokemonDataViewModel> PokemonData
        {
            get
            { return _PokemonData; }
            set
            {
                if (_PokemonData == value)
                    return;
                _PokemonData = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Values変更通知プロパティ
        private ObservableCollection<ValueSetViewModel> _Values = new ObservableCollection<ValueSetViewModel>();

        public ObservableCollection<ValueSetViewModel> Values
        {
            get
            { return _Values; }
            set
            {
                if (_Values == value)
                    return;
                _Values = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SelectedItem変更通知プロパティ
        private PokemonDataViewModel _SelectedItem;

        public PokemonDataViewModel SelectedItem
        {
            get
            { return _SelectedItem; }
            set
            {
                if (_SelectedItem == value || value == null)
                    return;
                _SelectedItem = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region PokemonSelectWindowViewModel変更通知プロパティ
        private PokemonSelectWindowViewModel _PokemonSelectWindowViewModel;

        public PokemonSelectWindowViewModel PokemonSelectWindowViewModel
        {
            get
            { return _PokemonSelectWindowViewModel; }
            set
            {
                if (_PokemonSelectWindowViewModel == value)
                    return;
                _PokemonSelectWindowViewModel = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SelectedCharacter変更通知プロパティ
        private string _SelectedCharacter;

        public string SelectedCharacter
        {
            get
            { return _SelectedCharacter; }
            set
            {
                if (_SelectedCharacter == value)
                    return;
                _SelectedCharacter = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region SelectedPersonality変更通知プロパティ
        private string _SelectedPersonality;

        public string SelectedPersonality
        {
            get
            { return _SelectedPersonality; }
            set
            { 
                if (_SelectedPersonality == value)
                    return;
                _SelectedPersonality = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region SelectedPersonalityIndex変更通知プロパティ
        private int _SelectedPersonalityIndex = 0;

        public int SelectedPersonalityIndex
        {
            get
            { return _SelectedPersonalityIndex; }
            set
            { 
                if (_SelectedPersonalityIndex == value)
                    return;
                _SelectedPersonalityIndex = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SelectedMezapa変更通知プロパティ
        private string _SelectedMezapa;

        public string SelectedMezapa
        {
            get
            { return _SelectedMezapa; }
            set
            { 
                if (_SelectedMezapa == value)
                    return;
                _SelectedMezapa = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region SelectedMezapaIndex変更通知プロパティ
        private int _SelectedMezapaIndex = 0;

        public int SelectedMezapaIndex
        {
            get
            { return _SelectedMezapaIndex; }
            set
            { 
                if (_SelectedMezapaIndex == value)
                    return;
                _SelectedMezapaIndex = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region Level変更通知プロパティ
        private int _Level = 50;

        public int Level
        {
            get
            { return _Level; }
            set
            {
                if (_Level == value)
                    return;
                _Level = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region AH変更通知プロパティ
        private int _AH = 1;

        public int AH
        {
            get
            { return _AH; }
            set
            { 
                if (_AH == value)
                    return;
                _AH = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region DH変更通知プロパティ
        private int _DH = 0;

        public int DH
        {
            get
            { return _DH; }
            set
            { 
                if (_DH == value)
                    return;
                _DH = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region AA変更通知プロパティ
        private int _AA = 1;

        public int AA
        {
            get
            { return _AA; }
            set
            { 
                if (_AA == value)
                    return;
                _AA = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region DA変更通知プロパティ
        private int _DA = 0;

        public int DA
        {
            get
            { return _DA; }
            set
            { 
                if (_DA == value)
                    return;
                _DA = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region AB変更通知プロパティ
        private int _AB = 1;

        public int AB
        {
            get
            { return _AB; }
            set
            { 
                if (_AB == value)
                    return;
                _AB = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion
        
        #region DB変更通知プロパティ
        private int _DB = 0;

        public int DB
        {
            get
            { return _DB; }
            set
            { 
                if (_DB == value)
                    return;
                _DB = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region AC変更通知プロパティ
        private int _AC = 1;

        public int AC
        {
            get
            { return _AC; }
            set
            { 
                if (_AC == value)
                    return;
                _AC = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region DC変更通知プロパティ
        private int _DC = 0;

        public int DC
        {
            get
            { return _DC; }
            set
            { 
                if (_DC == value)
                    return;
                _DC = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region AD変更通知プロパティ
        private int _AD = 1;

        public int AD
        {
            get
            { return _AD; }
            set
            { 
                if (_AD == value)
                    return;
                _AD = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region DD変更通知プロパティ
        private int _DD = 0;

        public int DD
        {
            get
            { return _DD; }
            set
            { 
                if (_DD == value)
                    return;
                _DD = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region AS変更通知プロパティ
        private int _AS = 1;

        public int AS
        {
            get
            { return _AS; }
            set
            { 
                if (_AS == value)
                    return;
                _AS = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region DS変更通知プロパティ
        private int _DS = 0;

        public int DS
        {
            get
            { return _DS; }
            set
            { 
                if (_DS == value)
                    return;
                _DS = value;
                RaisePropertyChanged();
                calc();
            }
        }
        #endregion

        #region StringNotation変更通知プロパティ
        private string _StringNotation;

        public string StringNotation
        {
            get
            { return _StringNotation; }
            set
            { 
                if (_StringNotation == value)
                    return;
                _StringNotation = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region CopyCommand
        private ViewModelCommand _CopyCommand;

        public ViewModelCommand CopyCommand
        {
            get
            {
                if (_CopyCommand == null)
                {
                    _CopyCommand = new ViewModelCommand(Copy);
                }
                return _CopyCommand;
            }
        }

        public void Copy()
        {
            System.Windows.Clipboard.SetText(StringNotation);
        }
        #endregion

        #region TweetCommand
        private ViewModelCommand _TweetCommand;

        public ViewModelCommand TweetCommand
        {
            get
            {
                if (_TweetCommand == null)
                {
                    _TweetCommand = new ViewModelCommand(Tweet);
                }
                return _TweetCommand;
            }
        }

        public void Tweet()
        {
            System.Diagnostics.Process.Start("https://twitter.com/intent/tweet?text=" + System.Web.HttpUtility.UrlEncode(StringNotation));
        }
        #endregion

        #region ApplyFilterCommand
        private ViewModelCommand _ApplyFilterCommand;

        public ViewModelCommand ApplyFilterCommand
        {
            get
            {
                if (_ApplyFilterCommand == null)
                {
                    _ApplyFilterCommand = new ViewModelCommand(ApplyFilter);
                }
                return _ApplyFilterCommand;
            }
        }

        public void ApplyFilter()
        {
            for (int i = 0; i < 32; i++)
            {
                filter[i][0] = Values[i].IsMatchH;
                filter[i][1] = Values[i].IsMatchA;
                filter[i][2] = Values[i].IsMatchB;
                filter[i][3] = Values[i].IsMatchC;
                filter[i][4] = Values[i].IsMatchD;
                filter[i][5] = Values[i].IsMatchS;
            }
            RaisePropertyChanged("IsFiltered");
        }
        #endregion

        #region ResetFilterCommand
        private ViewModelCommand _ResetFilterCommand;

        public ViewModelCommand ResetFilterCommand
        {
            get
            {
                if (_ResetFilterCommand == null)
                {
                    _ResetFilterCommand = new ViewModelCommand(ResetFilter);
                }
                return _ResetFilterCommand;
            }
        }

        public void ResetFilter()
        {
            for (int i = 0; i < 32; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    filter[i][j] = true;
                }
            }
            RaisePropertyChanged("IsFiltered");
            calc();
        }
        #endregion
        
        #region IsFiltered変更通知プロパティ

        public bool IsFiltered
        {
            get
            {
                foreach (var item in filter)
                {
                    foreach (var element in item)
                    {
                        if (element == false) return true;
                    }
                }
                return false;
            }
        }
        #endregion

        #region MezapaViewModel変更通知プロパティ
        private MezapaViewModel _MezapaViewModel;

        public MezapaViewModel MezapaViewModel
        {
            get
            { return _MezapaViewModel; }
            set
            { 
                if (_MezapaViewModel == value)
                    return;
                _MezapaViewModel = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region ResetInputCommand
        private ViewModelCommand _ResetInputCommand;

        public ViewModelCommand ResetInputCommand
        {
            get
            {
                if (_ResetInputCommand == null)
                {
                    _ResetInputCommand = new ViewModelCommand(ResetInput);
                }
                return _ResetInputCommand;
            }
        }

        public void ResetInput()
        {
            SelectedPersonalityIndex = SelectedMezapaIndex = 0;
            AH = AA = AB = AC = AD = AS = 1;
            DH = DA = DB = DC = DD = DS = 0;
            ResetFilter();
        }
        #endregion


        public MainWindowViewModel()
        {
            MezapaViewModel = new MezapaViewModel();

            filter = new List<List<bool>>();
            for (int i = 0; i < 32; i++)
            {
                filter.Add(new List<bool> { true, true, true, true, true, true });
            }

            model = new Pokemon();
            PokemonData = ViewModelHelper.CreateReadOnlyDispatcherCollection(model.PokemonData, (d) => new PokemonDataViewModel(d), DispatcherHelper.UIDispatcher);
            PokemonSelectWindowViewModel = new PokemonSelectWindowViewModel(this);
            for (int i = 31; i >= 0; i--)
                Values.Add(new ValueSetViewModel(i, 0, 0, 0, 0, 0, 0));
            SelectedItem = PokemonData[0];
        }

        #region SetD

        public void SetLevel(string value)
        {
            Level = int.Parse(value);
        }

        public void SetDH(string value)
        {
            DH = int.Parse(value);
        }

        public void SetDA(string value)
        {
            DA = int.Parse(value);
        }

        public void SetDB(string value)
        {
            DB = int.Parse(value);
        }

        public void SetDC(string value)
        {
            DC = int.Parse(value);
        }

        public void SetDD(string value)
        {
            DD = int.Parse(value);
        }

        public void SetDS(string value)
        {
            DS = int.Parse(value);
        }

        #endregion

        private void calc()
        {
            // 能力値計算
            for (int i = 0; i < 32; i++)
            {
                int j = 31 - i;
                Values[i].H = Pokemon.CalcHAbilityValue(SelectedItem.Name, SelectedItem.H, j, DH, Level);
                Values[i].A = Pokemon.CalcABCDSAbilityValue(SelectedItem.A, j, DA, Level, ParameterType.A, SelectedCharacter);
                Values[i].B = Pokemon.CalcABCDSAbilityValue(SelectedItem.B, j, DB, Level, ParameterType.B, SelectedCharacter);
                Values[i].C = Pokemon.CalcABCDSAbilityValue(SelectedItem.C, j, DC, Level, ParameterType.C, SelectedCharacter);
                Values[i].D = Pokemon.CalcABCDSAbilityValue(SelectedItem.D, j, DD, Level, ParameterType.D, SelectedCharacter);
                Values[i].S = Pokemon.CalcABCDSAbilityValue(SelectedItem.S, j, DS, Level, ParameterType.S, SelectedCharacter);

                Values[i].IsMatchH = Values[i].H == AH;
                Values[i].IsMatchA = Values[i].A == AA;
                Values[i].IsMatchB = Values[i].B == AB;
                Values[i].IsMatchC = Values[i].C == AC;
                Values[i].IsMatchD = Values[i].D == AD;
                Values[i].IsMatchS = Values[i].S == AS;
            }

            // めざパ判断
            var mezapa = Pokemon.Mezapa(SelectedMezapa);
            for (int i = 0; i < 32; i++)
            {
                int j = 31 - i;
                if (j % 2 == 0)
                {
                    Values[i].IsMatchH = Values[i].IsMatchH && mezapa.H.HasFlag(EvenOddType.Even);
                    Values[i].IsMatchA = Values[i].IsMatchA && mezapa.A.HasFlag(EvenOddType.Even);
                    Values[i].IsMatchB = Values[i].IsMatchB && mezapa.B.HasFlag(EvenOddType.Even);
                    Values[i].IsMatchC = Values[i].IsMatchC && mezapa.C.HasFlag(EvenOddType.Even);
                    Values[i].IsMatchD = Values[i].IsMatchD && mezapa.D.HasFlag(EvenOddType.Even);
                    Values[i].IsMatchS = Values[i].IsMatchS && mezapa.S.HasFlag(EvenOddType.Even);
                }
                if (j % 2 == 1)
                {
                    Values[i].IsMatchH = Values[i].IsMatchH && mezapa.H.HasFlag(EvenOddType.Odd);
                    Values[i].IsMatchA = Values[i].IsMatchA && mezapa.A.HasFlag(EvenOddType.Odd);
                    Values[i].IsMatchB = Values[i].IsMatchB && mezapa.B.HasFlag(EvenOddType.Odd);
                    Values[i].IsMatchC = Values[i].IsMatchC && mezapa.C.HasFlag(EvenOddType.Odd);
                    Values[i].IsMatchD = Values[i].IsMatchD && mezapa.D.HasFlag(EvenOddType.Odd);
                    Values[i].IsMatchS = Values[i].IsMatchS && mezapa.S.HasFlag(EvenOddType.Odd);
                }
            }

            // 個性判断
            ParameterType highestType;
            int mod;
            Pokemon.Personality(SelectedPersonality, out highestType, out mod);
            if (highestType != ParameterType.None)
            {
                int highestIndex = 32;
                for (int i = 0; i < 32; i++)
                {
                    int j = 31 - i;
                    bool match = valueFor(highestType, Values[i].IsMatchH, Values[i].IsMatchA, Values[i].IsMatchB, Values[i].IsMatchC, Values[i].IsMatchD, Values[i].IsMatchS);
                    int value = valueFor(highestType, Values[i].H, Values[i].A, Values[i].B, Values[i].C, Values[i].D, Values[i].S);
                    if (match)
                    {
                        if (j % 5 == mod)
                        {
                            if (highestIndex == 32)
                                highestIndex = i;
                        }
                        else
                        {
                            switch (highestType)
                            {
                                case ParameterType.H:
                                    Values[i].IsMatchH = false;
                                    break;
                                case ParameterType.A:
                                    Values[i].IsMatchA = false;
                                    break;
                                case ParameterType.B:
                                    Values[i].IsMatchB = false;
                                    break;
                                case ParameterType.C:
                                    Values[i].IsMatchC = false;
                                    break;
                                case ParameterType.D:
                                    Values[i].IsMatchD = false;
                                    break;
                                case ParameterType.S:
                                    Values[i].IsMatchS = false;
                                    break;
                            }
                        }
                    }
                }
                for (int i = 0; i < highestIndex; i++)
                {
                    Values[i].IsMatchH = false;
                    Values[i].IsMatchA = false;
                    Values[i].IsMatchB = false;
                    Values[i].IsMatchC = false;
                    Values[i].IsMatchD = false;
                    Values[i].IsMatchS = false;
                }
            }

            // 絞り込み
            for (int i = 0; i < 32; i++)
            {
                Values[i].IsMatchH = Values[i].IsMatchH && filter[i][0];
                Values[i].IsMatchA = Values[i].IsMatchA && filter[i][1];
                Values[i].IsMatchB = Values[i].IsMatchB && filter[i][2];
                Values[i].IsMatchC = Values[i].IsMatchC && filter[i][3];
                Values[i].IsMatchD = Values[i].IsMatchD && filter[i][4];
                Values[i].IsMatchS = Values[i].IsMatchS && filter[i][5];
            }
            RaisePropertyChanged("IsFiltered");

            // めざパ判定
            var oeh = Values.Aggregate(EvenOddType.Undefined, (acc, succ) => acc | (succ.IsMatchH ? (succ.Num % 2 == 0 ? EvenOddType.Even : EvenOddType.Odd) : EvenOddType.Undefined));
            var oea = Values.Aggregate(EvenOddType.Undefined, (acc, succ) => acc | (succ.IsMatchA ? (succ.Num % 2 == 0 ? EvenOddType.Even : EvenOddType.Odd) : EvenOddType.Undefined));
            var oeb = Values.Aggregate(EvenOddType.Undefined, (acc, succ) => acc | (succ.IsMatchB ? (succ.Num % 2 == 0 ? EvenOddType.Even : EvenOddType.Odd) : EvenOddType.Undefined));
            var oec = Values.Aggregate(EvenOddType.Undefined, (acc, succ) => acc | (succ.IsMatchC ? (succ.Num % 2 == 0 ? EvenOddType.Even : EvenOddType.Odd) : EvenOddType.Undefined));
            var oed = Values.Aggregate(EvenOddType.Undefined, (acc, succ) => acc | (succ.IsMatchD ? (succ.Num % 2 == 0 ? EvenOddType.Even : EvenOddType.Odd) : EvenOddType.Undefined));
            var oes = Values.Aggregate(EvenOddType.Undefined, (acc, succ) => acc | (succ.IsMatchS ? (succ.Num % 2 == 0 ? EvenOddType.Even : EvenOddType.Odd) : EvenOddType.Undefined));
            MezapaViewModel.CheckTypes(oeh, oea, oeb, oec, oed, oes);

            // 文字列表記更新
            StringNotation = SelectedItem.Name + " : " + stringNotationFor((v) => v.IsMatchH)
                + "-" + stringNotationFor((v) => v.IsMatchA)
                 + "-" + stringNotationFor((v) => v.IsMatchB)
                  + "-" + stringNotationFor((v) => v.IsMatchC)
                   + "-" + stringNotationFor((v) => v.IsMatchD)
                    + "-" + stringNotationFor((v) => v.IsMatchS);
        }

        private string stringNotationFor(Func<ValueSetViewModel, bool> selector)
        {
            bool multi = false;
            List<string> ranges = new List<string>();
            IEnumerable<ValueSetViewModel> hMatches = Values.Reverse();
            while (true)
            {
                hMatches = hMatches.SkipWhile((h) => !selector(h));
                if (hMatches.Count() == 0) break;
                int s = hMatches.ElementAt(0).Num;
                int c = hMatches.TakeWhile((h) => selector(h)).Count();
                hMatches = hMatches.Skip(c);
                if (c == 1)
                    ranges.Add(s.ToString());
                else if (c > 1)
                {
                    ranges.Add(string.Format("{0}~{1}", s, s + c - 1));
                    multi = true;
                }
            }
            if (ranges.Count == 0) return "??";
            if (!multi && ranges.Count == 1) return ranges[0];
            return "[" + ranges.Aggregate((acc, succ) => acc + "|" + succ) + "]";
        }

        private T valueFor<T>(ParameterType type, T h, T a, T b, T c, T d, T s)
        {
            switch (type)
            {
                case ParameterType.H:
                    return h;
                case ParameterType.A:
                    return a;
                case ParameterType.B:
                    return b;
                case ParameterType.C:
                    return c;
                case ParameterType.D:
                    return d;
                case ParameterType.S:
                    return s;
                default:
                    return default(T);
            }
        }
    }
}
