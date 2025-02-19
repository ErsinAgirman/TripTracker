﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.Models;

namespace TripTrackerRepository.Configurations
{
    internal class AdminConfiguration : IEntityTypeConfiguration<Staff>
	{
		public void Configure(EntityTypeBuilder<Staff> builder)
		{
			//builder.HasKey(x => x.Id);
			//builder.Property(x => x.Id).UseIdentityColumn();
			builder.Property(x => x.Name).IsRequired().HasMaxLength(50);

			//Digerleri de bu sekilde yapılabilir..
		}
	}
}
