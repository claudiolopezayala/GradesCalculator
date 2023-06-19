using TDMPW_411_3P_EX.Models;
using TDMPW_411_3P_EX.ViewModel;

namespace TDMPW_411_3P_EX.Views;

public partial class AllClassesPage : ContentPage
{
	public List<Class> classesToShow;

	public AllClassesPage()
	{
		Classes.classesInstance.classesUpdated += this.classUptdated;
		classesToShow = Classes.classesInstance.getClonedClasses();
        InitializeComponent();
		BindingContext = new AllClassesPageViewModel();
		loadClassesToStackLayout();
	}

	private void classUptdated (object sender, EventArgs e)
	{
		classesToShow = Classes.classesInstance.getClonedClasses();
		loadClassesToStackLayout ();
	}

	private void loadClassesToStackLayout()
	{
		ClassesStackLayout.Clear();
		foreach (Class classToShow in classesToShow)
		{
			ClassesStackLayout.Add(new ClassView(classToShow));
		}
	}
}