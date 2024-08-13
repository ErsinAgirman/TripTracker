namespace TripTrackerCore.UnitOfWorks
{
	public interface IUnitOfWork
	{
		Task CommitAsync();
		void Commit();
	}
}
