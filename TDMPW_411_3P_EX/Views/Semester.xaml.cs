using TDMPW_411_3P_EX.Models;
using TDMPW_411_3P_EX.ViewModel;

namespace TDMPW_411_3P_EX.Views;

public partial class Semester : ContentPage
{
	public List<SemesterCalculation> calculationsToShow;
	public Semester()
	{
		SemesterCalculations.semesterClalculationsInstance.semesterCalculationsUpdated += calculationsUpdated;
        InitializeComponent();
		BindingContext = new SemesterPageViewModel();
		calculationsToShow = SemesterCalculations.semesterClalculationsInstance.getClonedSemesterCalculations();
		loadSemesterCalculationToStackLayout();
    }

	private void calculationsUpdated (object sender, EventArgs e)
	{
		calculationsToShow = SemesterCalculations.semesterClalculationsInstance.getClonedSemesterCalculations();
		loadSemesterCalculationToStackLayout ();
	}

	private void loadSemesterCalculationToStackLayout()
	{
        ClassesStackLayout.Clear();
        foreach (SemesterCalculation calculationToShow in calculationsToShow)
        {
            ClassesStackLayout.Add(new SemesterCalculationView(calculationToShow));
        }
    }


}