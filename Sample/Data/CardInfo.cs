using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.MVVM.Models;

namespace Sample.Data
{
	public partial class CardInfo : ObservableObject
	{
		public ObservableCollection<CardModel>? Cards { get; set; }

		[ObservableProperty]
		public int id;

		[ObservableProperty]
		public string? text;

		public void UpdateCards()
		{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
			Cards = new ObservableCollection<CardModel>(App.CardRepo.GetAllCards());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
		}
	}
}
