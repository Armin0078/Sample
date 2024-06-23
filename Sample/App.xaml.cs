

using VirtualDiary.Data;

namespace Sample
{
	public partial class App : Application
	{
		static public CardRepository? CardRepo { get; private set; }
		public App(CardRepository repo)
		{
			CardRepo = repo;

			InitializeComponent();

			MainPage = new AppShell();
		}
	}
}
