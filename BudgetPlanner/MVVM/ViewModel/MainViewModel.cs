using BudgetPlanner.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.MVVM.ViewModel
{
    class MainViewModel :ObservableObject
    {
        public RelayCommand HomeViewCommand { get; set; }
        public RelayCommand HomeLoanViewCommand { get; set; }
        public RelayCommand RentViewCommand { get; set; }
        public RelayCommand VehicleViewCommand { get; set; }
        public RelayCommand SavingsViewCommand { get; set; }


        public HomeViewModel HomeVM { get; set; }
        public HomeLoanViewModel HomeLoanVM { get; set; }
        public RentViewModel RentVM { get; set; }
        public VehicleViewModel VehiclenVM { get; set; }
        public SavingsViewModel SavingsVM { get; set; }

        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set 
            { 
                _currentView = value; 
                OnPropertyChanged();
            }
        }


        public MainViewModel()
        {    
            HomeVM = new HomeViewModel();
            HomeLoanVM = new HomeLoanViewModel();
            RentVM = new RentViewModel();
            VehiclenVM = new VehicleViewModel();
            SavingsVM = new SavingsViewModel();

            CurrentView = HomeVM;

            HomeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });

            HomeLoanViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeLoanVM;
            });

            RentViewCommand = new RelayCommand(o =>
            {
                CurrentView = RentVM;
            });

            VehicleViewCommand = new RelayCommand(o =>
            {
                CurrentView = VehiclenVM;
            });

            SavingsViewCommand = new RelayCommand(o =>
            {
                CurrentView = SavingsVM;
            });
        }
    }
}
