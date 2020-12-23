using MyTrips.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTrips.Models.ViewModels
{
    public class ListTripVM
    {
        public ListTripVM()
        {

        }
        public ListTripVM(Trip dto)
        {
            this.Id = dto.Id;
            this.StartDate = dto.StartDate.ToShortDateString();
            this.LaunchSite = dto.LaunchSite;
            this.Destination = dto.Destination;
            this.Photo = dto.Photos.FirstOrDefault();

        }


        public int Id { get; set; }
        public string StartDate { get; set; }
        public string LaunchSite { get; set; }
        public string Destination { get; set; }
        public Photo Photo { get; set; }
    }
}