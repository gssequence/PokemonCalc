using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Livet;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using System.Reflection;

namespace PokemonCalc.Models
{
    public class Pokemon : NotificationObject
    {
        #region PokemonData変更通知プロパティ
        private ObservableCollection<PokemonData> _PokemonData = new ObservableCollection<PokemonData>();

        public ObservableCollection<PokemonData> PokemonData
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

        public Pokemon()
        {
            var root = XDocument.Load(Assembly.GetExecutingAssembly().GetManifestResourceStream("PokemonCalc.Resources.List.xml")).Root;
            foreach (var item in root.Elements())
            {
                PokemonData.Add(new PokemonData(
                    item.Attribute("number").Value,
                    item.Attribute("name").Value,
                    int.Parse(item.Attribute("h").Value),
                    int.Parse(item.Attribute("a").Value),
                    int.Parse(item.Attribute("b").Value),
                    int.Parse(item.Attribute("c").Value),
                    int.Parse(item.Attribute("d").Value),
                    int.Parse(item.Attribute("s").Value)
                ));
            }
        }

        public static int CalcHAbilityValue(string name, int s, int k, int d, int l)
        {
            if (name == "ヌケニン") return 1;
            return (int)((s * 2 + k + d / 4) * l / 100.0 + l + 10);
        }

        public static int CalcABCDSAbilityValue(int s, int k, int d, int l, ParameterType t, string c)
        {
            return (int)((int)((s * 2 + k + d / 4) * l / 100.0 + 5) * new CorrectionData(c).CorrectionValue(t));
        }

        public static void Personality(string s, out ParameterType type, out int mod)
        {
            switch (s)
            {
                case "たべるのがだいすき":
                    type = ParameterType.H;
                    mod = 0;
                    break;
                case "ひるねをよくする":
                    type = ParameterType.H;
                    mod = 1;
                    break;
                case "いねむりがおおい":
                    type = ParameterType.H;
                    mod = 2;
                    break;
                case "ものをよくちらかす":
                    type = ParameterType.H;
                    mod = 3;
                    break;
                case "のんびりするのがすき":
                    type = ParameterType.H;
                    mod = 4;
                    break;
                case "ちからがじまん":
                    type = ParameterType.A;
                    mod = 0;
                    break;
                case "あばれることがすき":
                    type = ParameterType.A;
                    mod = 1;
                    break;
                case "ちょっとおこりっぽい":
                    type = ParameterType.A;
                    mod = 2;
                    break;
                case "ケンカをするのがすき":
                    type = ParameterType.A;
                    mod = 3;
                    break;
                case "ちのけがおおい":
                    type = ParameterType.A;
                    mod = 4;
                    break;
                case "からだがじょうぶ":
                    type = ParameterType.B;
                    mod = 0;
                    break;
                case "うたれづよい":
                    type = ParameterType.B;
                    mod = 1;
                    break;
                case "ねばりづよい":
                    type = ParameterType.B;
                    mod = 2;
                    break;
                case "しんぼうづよい":
                    type = ParameterType.B;
                    mod = 3;
                    break;
                case "がまんづよい":
                    type = ParameterType.B;
                    mod = 4;
                    break;
                case "こうきしんがつよい":
                    type = ParameterType.C;
                    mod = 0;
                    break;
                case "イタズラがすき":
                    type = ParameterType.C;
                    mod = 1;
                    break;
                case "ぬけめがない":
                    type = ParameterType.C;
                    mod = 2;
                    break;
                case "かんがえごとがおおい":
                    type = ParameterType.C;
                    mod = 3;
                    break;
                case "とてもきちょうめん":
                    type = ParameterType.C;
                    mod = 4;
                    break;
                case "きがつよい":
                    type = ParameterType.D;
                    mod = 0;
                    break;
                case "ちょっぴりみえっぱり":
                    type = ParameterType.D;
                    mod = 1;
                    break;
                case "まけんきがつよい":
                    type = ParameterType.D;
                    mod = 2;
                    break;
                case "まけずぎらい":
                    type = ParameterType.D;
                    mod = 3;
                    break;
                case "ちょっぴりごうじょう":
                    type = ParameterType.D;
                    mod = 4;
                    break;
                case "かけっこがすき":
                    type = ParameterType.S;
                    mod = 0;
                    break;
                case "ものおとにびんかん":
                    type = ParameterType.S;
                    mod = 1;
                    break;
                case "おっちょこちょい":
                    type = ParameterType.S;
                    mod = 2;
                    break;
                case "すこしおちょうしもの":
                    type = ParameterType.S;
                    mod = 3;
                    break;
                case "にげるのがはやい":
                    type = ParameterType.S;
                    mod = 4;
                    break;
                default:
                    type = ParameterType.None;
                    mod = 0;
                    break;
            }
        }

        public static ParameterPair<EvenOddType> Mezapa(string type)
        {
            switch (type)
            {
                case "あく":
                    return new ParameterPair<EvenOddType>(EvenOddType.Odd, EvenOddType.Odd, EvenOddType.Odd, EvenOddType.Odd, EvenOddType.Odd, EvenOddType.Odd);
                case "ドラゴン":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Odd, EvenOddType.Odd, EvenOddType.Odd);
                case "こおり":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Odd, EvenOddType.Odd, EvenOddType.Both);
                case "エスパー":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Odd, EvenOddType.Odd, EvenOddType.Even);
                case "でんき":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Odd, EvenOddType.Odd, EvenOddType.Both);
                case "くさ":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Even, EvenOddType.Odd, EvenOddType.Odd);
                case "みず":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Even, EvenOddType.Odd, EvenOddType.Both);
                case "ほのお":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Even, EvenOddType.Odd, EvenOddType.Even);
                case "はがね":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Both);
                case "ゴースト":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Odd, EvenOddType.Even, EvenOddType.Odd);
                case "むし":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Odd, EvenOddType.Even, EvenOddType.Both);
                case "いわ":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Odd, EvenOddType.Even, EvenOddType.Even);
                case "じめん":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Even, EvenOddType.Both);
                case "どく":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Even, EvenOddType.Even, EvenOddType.Odd);
                case "ひこう":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Even, EvenOddType.Even, EvenOddType.Both);
                case "かくとう":
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Even, EvenOddType.Even, EvenOddType.Even);
                default:
                    return new ParameterPair<EvenOddType>(EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Both, EvenOddType.Both);
            }
        }

        private class CorrectionData
        {
            public ParameterType UpType { get; private set; }
            public ParameterType DownType { get; private set; }

            public double CorrectionValue(ParameterType type)
            {
                if (type == UpType) return 1.1;
                if (type == DownType) return 0.9;
                return 1.0;
            }

            public CorrectionData(string character)
            {
                switch (character)
                {
                    case "さみしがり":
                        UpType = ParameterType.A;
                        DownType = ParameterType.B;
                        break;
                    case "いじっぱり":
                        UpType = ParameterType.A;
                        DownType = ParameterType.C;
                        break;
                    case "やんちゃ":
                        UpType = ParameterType.A;
                        DownType = ParameterType.D;
                        break;
                    case "ゆうかん":
                        UpType = ParameterType.A;
                        DownType = ParameterType.S;
                        break;
                    case "ずぶとい":
                        UpType = ParameterType.B;
                        DownType = ParameterType.A;
                        break;
                    case "わんぱく":
                        UpType = ParameterType.B;
                        DownType = ParameterType.C;
                        break;
                    case "のうてんき":
                        UpType = ParameterType.B;
                        DownType = ParameterType.D;
                        break;
                    case "のんき":
                        UpType = ParameterType.B;
                        DownType = ParameterType.S;
                        break;
                    case "ひかえめ":
                        UpType = ParameterType.C;
                        DownType = ParameterType.A;
                        break;
                    case "おっとり":
                        UpType = ParameterType.C;
                        DownType = ParameterType.B;
                        break;
                    case "うっかりや":
                        UpType = ParameterType.C;
                        DownType = ParameterType.D;
                        break;
                    case "れいせい":
                        UpType = ParameterType.C;
                        DownType = ParameterType.S;
                        break;
                    case "おだやか":
                        UpType = ParameterType.D;
                        DownType = ParameterType.A;
                        break;
                    case "おとなしい":
                        UpType = ParameterType.D;
                        DownType = ParameterType.B;
                        break;
                    case "しんちょう":
                        UpType = ParameterType.D;
                        DownType = ParameterType.C;
                        break;
                    case "なまいき":
                        UpType = ParameterType.D;
                        DownType = ParameterType.S;
                        break;
                    case "おくびょう":
                        UpType = ParameterType.S;
                        DownType = ParameterType.A;
                        break;
                    case "せっかち":
                        UpType = ParameterType.S;
                        DownType = ParameterType.B;
                        break;
                    case "ようき":
                        UpType = ParameterType.S;
                        DownType = ParameterType.C;
                        break;
                    case "むじゃき":
                        UpType = ParameterType.S;
                        DownType = ParameterType.D;
                        break;
                    default:
                        UpType = ParameterType.None;
                        DownType = ParameterType.None;
                        break;
                }
            }
        }
    }

    public class ParameterPair<T>
    {
        public T H { get; private set; }
        public T A { get; private set; }
        public T B { get; private set; }
        public T C { get; private set; }
        public T D { get; private set; }
        public T S { get; private set; }

        public ParameterPair(T h, T a, T b, T c, T d, T s)
        {
            H = h;
            A = a;
            B = b;
            C = c;
            D = d;
            S = s;
        }

        public T GetValue(ParameterType type)
        {
            switch (type)
            {
                case ParameterType.H:
                    return H;
                case ParameterType.A:
                    return A;
                case ParameterType.B:
                    return B;
                case ParameterType.C:
                    return C;
                case ParameterType.D:
                    return D;
                case ParameterType.S:
                    return S;
                default:
                    return default(T);
            }
        }
    }
}
