﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripTrackerCore.DTOs;
using TripTrackerCore.Models;

namespace TripTrackerService.Mapping
{
	public class MapProfile :Profile
	{
        public MapProfile()
        {
            CreateMap<Staff, AdminDto>().ReverseMap();
            CreateMap<Staff, StaffDto>().ReverseMap();
            CreateMap<Status, StatusDto>().ReverseMap();
            CreateMap<Travel, TravelDto>().ReverseMap();

            CreateMap<AdminDto, Staff>(); //düzenleme için

            CreateMap<Travel, TravelWithStaffDto>();

            //buraya bakılacak, ekleme yapılabilir (Update,Delete vs bağlı olarak)
        }
    }
}
