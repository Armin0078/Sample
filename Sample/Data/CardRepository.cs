using SQLite;
using System.Collections.ObjectModel;
using Sample.MVVM.Models;
using Sample;

namespace VirtualDiary.Data
{
	public class CardRepository
	{
		readonly SQLiteConnection connection;

		public CardRepository()
		{
			connection = new SQLiteConnection(Constants.dbPath, Constants.flags);

			connection.CreateTable<CardModel>();


			//connection.DeleteAll<CardModel>(); // for DB testing
		}

		public List<CardModel> GetAllCards()
		{
			try
			{
				var dateCards = connection.Table<CardModel>().ToList();
				return dateCards;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				var emptyCardList = new List<CardModel>();
				return emptyCardList;
			}
		}

		public CardModel GetCard(int id)
		{
			try
			{
				return connection.Table<CardModel>().FirstOrDefault(c => c.Id == id);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
				var emptyCard = new CardModel();
				return emptyCard;
			}
		}
		public void AddOrUpdateCard(CardModel card)
		{
			if (card.Id != 0)
			{
				try
				{
					connection.Update(card);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
				}
			}
			else
			{
				try
				{
					connection.Insert(card);
				}
				catch (Exception ex)
				{
					Console.WriteLine($"Error: {ex.Message}");
				}
			}

		}
		public void DeleteCard(int id)
		{
#pragma warning disable CS8602 // Dereference of a possibly null reference.
			ObservableCollection<CardModel> cards = new(App.CardRepo.GetAllCards());
#pragma warning restore CS8602 // Dereference of a possibly null reference.
			var card = cards.FirstOrDefault(c => c.Id == id);
			try
			{
				connection.Delete(card);
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
		}
	}
}
