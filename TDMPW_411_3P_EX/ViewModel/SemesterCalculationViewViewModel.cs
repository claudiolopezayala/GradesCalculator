using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMPW_411_3P_EX.Models;

namespace TDMPW_411_3P_EX.ViewModel
{
    public class SemesterCalculationViewViewModel
    {
        public ICommand deleteClassClicked { get; set; }
        public string name { get; set; }
        public double totalGrade { get; set; }
        public double neededGrade { get; set; }
        public string message { get; set; }

        public SemesterCalculationViewViewModel(SemesterCalculation calculationToShow)
        {
            name = calculationToShow.name;
            double totalGradeOverOne = (calculationToShow.firstParcialGradeOverOne * calculationToShow.firstParcialValueOverOne) + (calculationToShow.secondParcialGradeOverOne * calculationToShow.secondParcialValueOverOne);
            totalGrade = Math.Round((totalGradeOverOne * 10), 2);
            double neededGradeOverOne = (calculationToShow.targetGradeOverOne - totalGradeOverOne) / calculationToShow.thirdParcialValueOverOne;
            neededGrade = Math.Round((neededGradeOverOne * 10), 2);
            if (neededGrade < 0) { neededGrade = 0; }
            if (neededGrade > 10)
            {
                message = "Lo siento no es posible";
            }
            else
            {
                message = "Vamos!! si se puede";
            }
            deleteClassClicked = new Command(() =>
            {
                SemesterCalculations.semesterClalculationsInstance.removeSemesterCalculation(calculationToShow);
            });
        }
    }
}
