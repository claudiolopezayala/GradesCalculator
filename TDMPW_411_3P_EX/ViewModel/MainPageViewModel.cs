using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TDMPW_411_3P_EX.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class MainPageViewModel
    {
        public ICommand seeGradesClicked { get; set; }

        public MainPageViewModel() { 
        }
    }
}
