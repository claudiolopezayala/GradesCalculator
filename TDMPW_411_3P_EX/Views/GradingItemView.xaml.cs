using TDMPW_411_3P_EX.Models;
using TDMPW_411_3P_EX.ViewModel;

namespace TDMPW_411_3P_EX.Views;

public partial class GradingItemView : ContentView
{
	public GradingItemView(GradingItem gradingItemToDisplay, Class classToDisplay)
	{
		InitializeComponent();
		BindingContext = new GradingItemViewViewModel(gradingItemToDisplay, classToDisplay);
	}
}