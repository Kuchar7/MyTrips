using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyTrips.Models.Data
{
    [Table("Videos")]
    public class Video
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string VideoPath { get; set; }
        [ForeignKey("TripId")]
        public Trip Trip { get; set; }
        public int TripId { get; set; }

    }
}