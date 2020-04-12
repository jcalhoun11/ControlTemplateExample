using SwitchingViewsWithDataTemplates.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SwitchingViewsWithDataTemplates.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewOneViewModel _ViewOneViewModel;
        private ViewTwoViewModel _ViewTwoViewModel;

        private object _ControlContext;

        public object ControlContext
        {
            get { return _ControlContext; }
            set { _ControlContext = value; OnChanged(); }
        }


        private ICommand _SwitchToViewOneCommand;
        public ICommand SwitchToViewOneCommand
        {
            get
            {
                if (_SwitchToViewOneCommand == null)
                    _SwitchToViewOneCommand = new ExecutePath(param => SwitchToViewOne(param));

                return _SwitchToViewOneCommand;
            }
        }

        private ICommand _SwitchToViewTwoCommand;
        public ICommand SwitchToViewTwoCommand
        {
            get
            {
                if (_SwitchToViewTwoCommand == null)
                    _SwitchToViewTwoCommand = new ExecutePath(param => SwitchToViewTwo(param));

                return _SwitchToViewTwoCommand;
            }
        }

        public MainViewModel()
        {
            _ViewOneViewModel = new ViewOneViewModel();
            _ViewTwoViewModel = new ViewTwoViewModel();
        }

        private void SwitchToViewTwo(object param)
        {
            ControlContext = _ViewTwoViewModel;
        }

        private void SwitchToViewOne(object param)
        {
            ControlContext = _ViewOneViewModel;
        }


    }
}
