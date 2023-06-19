using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TDMPW_411_3P_EX.Models;

namespace TDMPW_411_3P_EX.ViewModel
{
    public class AllClassesPageViewModel
    {
        public ICommand addClassClicked { get; set; }
        public AllClassesPageViewModel()
        {
            addClassClicked = new Command(async() =>
            {
                string className = await App.Current.MainPage.DisplayPromptAsync("Agregar Clase", "Nombre de la clase");
                if (className == null) return;
                Class classToAdd = new Class(className);
                try
                {
                    Classes.classesInstance.addClass(classToAdd);
                }catch (Exception ex)
                {
                    if (ex.Message == "DuplicatedClass")
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Clase ya existe", "OK");
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Error", "Ocurrió un error", "OK");
                    }
                }
            });
        }
    }
}
