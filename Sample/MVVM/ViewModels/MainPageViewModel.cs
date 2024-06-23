using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using PropertyChanged;
using Sample.Data;
using Sample.MVVM.Views;

namespace Sample.MVVM.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public partial class MainPageViewModel : CardInfo
	{
		public MainPageViewModel()
		{
			UpdateCards();

			foreach (var cardItem in Cards)
			{
				Id = cardItem.Id;
				Text = cardItem.Text;
			}
			MessagingCenter.Subscribe<AddCardPageViewModel>(this, "CardAdded", (send) =>
			{
				UpdateCards();
			});

			MessagingCenter.Subscribe<DetailPageViewModel>(this, "CardUpdated", (send) =>
			{
				UpdateCards();
			});
		}

		[RelayCommand]
		private async Task Tap(int CardId)
		{
			await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Id={CardId}");
		}

		[RelayCommand]
		private void DeleteTask(int cardId)
		{
			try
			{
				App.CardRepo.DeleteCard(cardId);
				UpdateCards();
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
