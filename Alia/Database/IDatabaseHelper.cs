using System.Collections.Generic;

namespace Alia
{
	public interface IDatabaseHelper
	{
		void UpdateLockStatus (int id, bool locked = false);
		void UpdateCompletedStatus (int id, bool completed = true);
		List<TextTaskTable> GetTasks ();
	}
}