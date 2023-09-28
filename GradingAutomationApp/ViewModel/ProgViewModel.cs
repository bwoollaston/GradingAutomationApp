using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingAutomationApp.ViewModel
{
    internal class ProgViewModel :ViewModelBase
    {
        public ProgViewModel()
        {
            TabItems = new ObservableCollection<string>() { "Parse" , "Email" };
            ParseInputs = new ParseInputsViewModel();
            EmailApp = new EmailAppViewModel();
            ViewModel = ParseInputs;
        }
        void Run()
        {

        }
        private ViewModelBase _viewModel;
        public ViewModelBase ViewModel 
        { 
            get { return _viewModel; }
            set { _viewModel = value; OnPropertyChanged(); }
        }
        private ParseInputsViewModel _parseInputs;
        public ParseInputsViewModel ParseInputs
        {
            get { return _parseInputs; }
            set { _parseInputs = value; OnPropertyChanged(); }
        }
        private EmailAppViewModel _emailApp;
        public EmailAppViewModel EmailApp
        {
            get { return _emailApp; }
            set { _emailApp = value; OnPropertyChanged(); }
        }
        private string _selectedTab;
        public string SelectedTab
        {
            get { return _selectedTab; }
            set 
            {
                if (_selectedTab == value) return;
                _selectedTab = value; 
                if(_selectedTab == TabItems[0])
                {
                    ViewModel = ParseInputs;
                }
                else if(_selectedTab == TabItems[1])
                {
                    ViewModel = EmailApp;
                }

                OnPropertyChanged(); 
            }
        }
        private ObservableCollection<string> _tabItems;
        public ObservableCollection<string> TabItems
        {
            get { return _tabItems; }
            set { _tabItems = value; OnPropertyChanged(); }
        }

    }
}
