using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMPW_411_3P_EX.Models;

namespace TDMPW_411_3P_EX.ViewModel
{
    public class EditClassPageViewModel
    {
        public ICommand backClicked { get; set; }
        public ICommand addGradingItemClicked { get; set; }
        public string name { get; set; }
        public double grade { get; set; }
        public EditClassPageViewModel(Class classToShow)
        {
            name = classToShow.name;
            grade = 0;

            backClicked = new Command(() =>
            {
                App.Current.MainPage.Navigation.PopModalAsync(false);
            });

            foreach(GradingItem gradingItem in classToShow.gradingItems)
            {
                grade += gradingItem.valueOverOne * gradingItem.gradeOverOne * 10;
            }
            grade = Math.Round(grade,2);

            addGradingItemClicked = new Command(async() =>
            {
                try
                {
                    string gradingItemName = await App.Current.MainPage.DisplayPromptAsync("Agregar rubro", "Nombre del rubro");

                    string gradingItemValueOverOneHundredString = await App.Current.MainPage.DisplayPromptAsync(gradingItemName, "Porcentaje de valor del rubro");
                    double gradingItemValueOverOne = Double.Parse(gradingItemValueOverOneHundredString) / 100;

                    string gradingItemGradeOverBaseString = await App.Current.MainPage.DisplayPromptAsync(gradingItemName, "Calificación");
                    double gradingItemGradeOverBase = Double.Parse(gradingItemGradeOverBaseString);

                    string gradingItemBaseOfGradeString = await App.Current.MainPage.DisplayPromptAsync(gradingItemName, "Calificación máxima");
                    double gradingItemBaseOfGrade = Double.Parse(gradingItemBaseOfGradeString);


                    GradingItem gradingItemToAdd = new GradingItem(gradingItemName,gradingItemGradeOverBase,gradingItemBaseOfGrade,gradingItemValueOverOne);

                    classToShow.gradingItems.Add(gradingItemToAdd);
                    Classes.classesInstance.editClassByNameOfClass(classToShow);
                }
                catch (Exception ex)
                {
                    await App.Current.MainPage.DisplayAlert("Error", "hubo un error", "OK");
                }
            });
        }
    }
}
