using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMPW_411_3P_EX.Models;

namespace TDMPW_411_3P_EX.ViewModel
{
    public class SemesterPageViewModel
    {
        public ICommand addClassClicked { get; set; }
        public SemesterPageViewModel()
        {
            addClassClicked = new Command(async () =>
            {
                try
                {
                    string name = await App.Current.MainPage.DisplayPromptAsync("Agregar calculo", "Nombre del calculo");

                    string firstParcialGradeOverTenString = await App.Current.MainPage.DisplayPromptAsync(name, "Calificación del primer parcial");
                    double firstParcialGradeOverOne = Double.Parse(firstParcialGradeOverTenString) / 10;

                    string secondParcialGradeOverTenString = await App.Current.MainPage.DisplayPromptAsync(name, "Calificación del segundo parcial");
                    double secondParcialGradeOverOne = Double.Parse(secondParcialGradeOverTenString) / 10;

                    string firstParcialValueOverTenString = await App.Current.MainPage.DisplayPromptAsync(name, "Porcentaje del primer parcial");
                    double firstParcialValueOverOne = Double.Parse(firstParcialValueOverTenString) / 100;

                    string secondParcialValueOverTenString = await App.Current.MainPage.DisplayPromptAsync(name, "Porcentaje del segundo parcial");
                    double secondParcialValueOverOne = Double.Parse(secondParcialValueOverTenString) / 100;

                    string thirdParcialValueOverTenString = await App.Current.MainPage.DisplayPromptAsync(name, "Porcentaje del tercer parcial");
                    double thirdParcialValueOverOne = Double.Parse(thirdParcialValueOverTenString) / 100;

                    SemesterCalculation calculationToAdd = new SemesterCalculation(name,firstParcialGradeOverOne,secondParcialGradeOverOne,firstParcialValueOverOne,secondParcialValueOverOne,thirdParcialValueOverOne);
                    SemesterCalculations.semesterClalculationsInstance.addSemesterCalculation(calculationToAdd);
                }
                catch(Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "hubo un error", "OK");
                }
            });
        }
    }
}
