using MyTrips.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyTrips.Models.ViewModels
{
    public class DetailsTripVM
    {
        public DetailsTripVM() { }
        public DetailsTripVM(Trip dto)
        {
            this.Id = dto.Id;
            this.StartDate = dto.StartDate.ToShortDateString();
            this.EndDate = dto.EndDate.ToShortDateString();
            this.Days = dto.Days;
            this.Kilometers = dto.Kilometers;
            this.LaunchSite = dto.LaunchSite;
            this.Destination = dto.Destination;
            this.Description = dto.Description;
            this.Photos = dto.Photos;
            this.Videos = dto.Videos;
        }

        public int Id { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Days { get; set; }
        public uint Kilometers { get; set; }
        public string LaunchSite { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Video> Videos { get; set; }
    }
}