using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTrips.Models.Data
{
    [Table("Trips")]
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime StartDate{get; set;}
        public DateTime EndDate { get; set; }
        public int Days { get; set; }
        public uint Kilometers { get; set; }
        public string LaunchSite { get; set; }
        public string Destination { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Video> Videos { get; set; }




    }
}