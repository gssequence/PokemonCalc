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
    public class PokemonSelectWindowViewModel : ViewModel
    {
        #region MainWindowViewModel変更通知プロパティ
        private MainWindowViewModel _MainWindowViewModel;

        public MainWindowViewModel MainWindowViewModel
        {
            get
            { return _MainWindowViewModel; }
            set
            { 
                if (_MainWindowViewModel == value)
                    return;
                _MainWindowViewModel = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        #region SearchQuery変更通知プロパティ
        private string _SearchQuery = "";

        public string SearchQuery
        {
            get
            { return _SearchQuery; }
            set
            { 
                if (_SearchQuery == value)
                    return;
                _SearchQuery = value;
                RaisePropertyChanged();
                refreshList();
            }
        }
        #endregion

        #region PokemonFilteredList変更通知プロパティ
        private ObservableCollection<PokemonDataViewModel> _PokemonFilteredList = new ObservableCollection<PokemonDataViewModel>();

        public ObservableCollection<PokemonDataViewModel> PokemonFilteredList
        {
            get
            { return _PokemonFilteredList; }
            set
            { 
                if (_PokemonFilteredList == value)
                    return;
                _PokemonFilteredList = value;
                RaisePropertyChanged();
            }
        }
        #endregion

        public PokemonSelectWindowViewModel(MainWindowViewModel parent)
        {
            MainWindowViewModel = parent;
            refreshList();
        }

        private void refreshList()
        {
            PokemonFilteredList.Clear();
            string query = SearchQuery.Trim();
            foreach (var item in MainWindowViewModel.PokemonData)
            {
                if (string.IsNullOrEmpty(query) || item.Name.Contains(query))
                    PokemonFilteredList.Add(item);
            }
        }
    }
}
