using CommunityToolkit.Mvvm.Input;
using PropertyChanged;
using Sample.Data;
using Sample.MVVM.Models;

namespace Sample.MVVM.ViewModels
{
	[QueryProperty(nameof(CardId), "Id")]
	[AddINotifyPropertyChangedInterface]
	public partial class DetailPageViewModel : CardInfo
	{
		[SuppressPropertyChangedWarnings]
		public int CardId
		{
			set
			{
				CardGetter(value);
			}
		}

		[RelayCommand]
		void CardGetter(int id)
		{
			var card = App.CardRepo.GetCard(id);
			Id = card.Id;
			Text = card.Text;
		}

		[RelayCommand]
		[Obsolete]
		void UpdateCard()
		{
			try
			{

				App.CardRepo.AddOrUpdateCard(new CardModel()
				{
					Id = Id,
					Text = Text,
				});
				MessagingCenter.Send(this, "CardUpdated");
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
