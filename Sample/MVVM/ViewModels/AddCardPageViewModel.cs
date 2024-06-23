using CommunityToolkit.Mvvm.Input;
using PropertyChanged;
using Sample.Data;
using Sample.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.MVVM.ViewModels
{
	[AddINotifyPropertyChangedInterface]
	public partial class AddCardPageViewModel : CardInfo
	{
		[RelayCommand]
		public void AddCard()
		{
			try
			{
				App.CardRepo.AddOrUpdateCard(new CardModel()
				{
					Text = Text
				});

				MessagingCenter.Send(this, "CardAdded");
			}
			catch (Exception)
			{
				throw;
			}
		}
	}
}
