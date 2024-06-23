using Sample.MVVM.ViewModels;

namespace Sample.MVVM.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage()
	{
		InitializeComponent();
		BindingContext = new DetailPageViewModel();
	}

	private async void OnButtonClicked(object sender, EventArgs e)
	{
		await Navigation.PopToRootAsync();
	}
}