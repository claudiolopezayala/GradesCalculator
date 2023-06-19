using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMPW_411_3P_EX.Views;

namespace TDMPW_411_3P_EX.ViewModel
{
    [AddINotifyPropertyChangedInterface]
    public class LandingPageViewModel
    {
        public ICommand seeGradesClicked { get; set; }

        public LandingPageViewModel()
        {
            seeGradesClicked = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushModalAsync(new MainPage(), false);
            });
        }
    }
}
