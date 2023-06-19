using TDMPW_411_3P_EX.Models;
using TDMPW_411_3P_EX.ViewModel;

namespace TDMPW_411_3P_EX.Views;

public partial class ClassView : ContentView
{
	public ClassView(Class classToDisplay)
	{
		InitializeComponent();
		BindingContext = new ClassViewViewModel(classToDisplay);
	}
}