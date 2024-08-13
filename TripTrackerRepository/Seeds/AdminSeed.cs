using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TripTrackerCore.Models;

namespace TripTrackerRepository.Seeds
{
    internal class AdminSeed : IEntityTypeConfiguration<Admin>
	{
		public void Configure(EntityTypeBuilder<Admin> builder)
		{
			builder.HasData(
				new Admin { Id = 1, Name = "Melih", Surname = "Bahadir", Active = true, CreatedDate = DateTime.Now, UptatedDate = null },
				new Admin { Id = 2, Name = "Yaser", Surname = "Kalkan", Active = true, CreatedDate = DateTime.Now, UptatedDate = null },
				new Admin { Id = 3, Name = "Yilmaz", Surname = "Genc", Active = true, CreatedDate = DateTime.Now, UptatedDate = null });
		}
	}
}
