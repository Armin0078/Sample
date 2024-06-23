using Sample.MVVM.ViewModels;

namespace Sample.MVVM.Views;

public partial class AddCardPage : ContentPage
{
	public AddCardPage()
	{
		InitializeComponent();
		BindingContext = new AddCardPageViewModel();
	}

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopModalAsync();
	}
}