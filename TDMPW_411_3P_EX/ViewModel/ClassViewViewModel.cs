using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMPW_411_3P_EX.Models;
using TDMPW_411_3P_EX.Views;

namespace TDMPW_411_3P_EX.ViewModel
{
    public class ClassViewViewModel
    {
        public Class classToDisplay;
        public string name { get; set; }
        public double totalGrade { get; set; }
        public ICommand editClassClicked { get; set; }
        public ICommand deleteClassClicked { get; set; }
        public ClassViewViewModel(Class _classToDisplay)
        {
            classToDisplay = _classToDisplay;
            name = classToDisplay.name;
            totalGrade = 0;
            classToDisplay.gradingItems.ForEach((gradingItem) =>
            {
                totalGrade += (gradingItem.gradeOverOne * gradingItem.valueOverOne * 10);
            });

            editClassClicked = new Command(() =>
            {
                App.Current.MainPage.Navigation.PushModalAsync(new EditClassPage(classToDisplay), false);
            });

            deleteClassClicked = new Command(() =>
            {
                Classes.classesInstance.removeClass(classToDisplay);
            });
        }
    }
}
