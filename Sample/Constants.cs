using SQLite;

namespace VirtualDiary
{
	public static class Constants
	{
		private const string dbFileName = "SQLite.db3";

		public const SQLiteOpenFlags flags = SQLiteOpenFlags.ReadWrite |
			SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

		public static string dbPath
		{
			get
			{
				return Path.Combine(FileSystem.AppDataDirectory, dbFileName);
			}
		}

	}
}
