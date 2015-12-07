using SQLite;

namespace Alia
{
	public interface ISQLite {
		SQLiteConnection GetConnection();
	}
}