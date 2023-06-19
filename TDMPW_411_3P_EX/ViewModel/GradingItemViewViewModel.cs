using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMPW_411_3P_EX.Models;

namespace TDMPW_411_3P_EX.ViewModel
{
    public class GradingItemViewViewModel
    {
        public string name { get; set; }
        public double gradeOverTen { get; set; }
        public double valueOverOneHundred { get; set; }
        public ICommand deleteClassClicked { get; set; }
        public GradingItemViewViewModel(GradingItem gradingItemToDisplay, Class classToDisplay)
        {
            name = gradingItemToDisplay.name;
            gradeOverTen = gradingItemToDisplay.gradeOverOne * 10;
            valueOverOneHundred = gradingItemToDisplay.valueOverOne * 100;
            deleteClassClicked = new Command(() =>
            {
                classToDisplay.gradingItems.Remove(gradingItemToDisplay);
                Classes.classesInstance.editClassByNameOfClass(classToDisplay);
            });
        }
    }
}
