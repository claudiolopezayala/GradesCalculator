using TDMPW_411_3P_EX.Models;
using TDMPW_411_3P_EX.ViewModel;

namespace TDMPW_411_3P_EX.Views;

public partial class EditClassPage : ContentPage
{
	public Class classToEdit;
	public List<GradingItem> gradingItemsToShow;
	public EditClassPage(Class _classToEdit)
	{
		Classes.classesInstance.classesUpdated += classUpdated;
		InitializeComponent();
		this.classToEdit = _classToEdit;
		gradingItemsToShow = classToEdit.gradingItems;
		loadGradingItemsToStackLayout();
		BindingContext = new EditClassPageViewModel(classToEdit);
	}

	private void classUpdated(object sender, EventArgs e)
	{
		Navigation.PopModalAsync(false);

    }

	private void loadGradingItemsToStackLayout ()
	{
		gradingItemsStackLayout.Clear();
		foreach (GradingItem gradingItem in gradingItemsToShow)
		{
			gradingItemsStackLayout.Add(new GradingItemView(gradingItem, classToEdit));
		}
	}
}