using Sample.MVVM.ViewModels;
using Sample.MVVM.Views;

namespace Sample
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainPageViewModel();
		}

		private async void OnAddButtonClicked(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new AddCardPage());
		}
    }

}
