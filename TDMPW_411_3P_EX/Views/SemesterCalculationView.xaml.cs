using TDMPW_411_3P_EX.Models;
using TDMPW_411_3P_EX.ViewModel;

namespace TDMPW_411_3P_EX.Views;

public partial class SemesterCalculationView : ContentView
{
	private SemesterCalculation semesterCalculationToShow;

    public SemesterCalculationView(SemesterCalculation semesterCalculationToShow)
	{
		InitializeComponent();
		BindingContext = new SemesterCalculationViewViewModel(semesterCalculationToShow);
		this.semesterCalculationToShow = semesterCalculationToShow;
		entryTarget.Text = $"{semesterCalculationToShow.targetGradeOverOne * 10}";

    }

    private async void Entry_Completed(object sender, EventArgs e)
    {
		double target = 0.0;
		try
		{
			target = Double.Parse(entryTarget.Text) / 10;
		}catch (Exception ex)
		{
            await App.Current.MainPage.DisplayAlert("Error", "Ingresa un número valido", "OK");
			return;
        }
		semesterCalculationToShow.targetGradeOverOne=target;
		SemesterCalculations.semesterClalculationsInstance.editClassByNameOfClass(semesterCalculationToShow);
    }
}