using MyTrips.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyTrips.Models.ViewModels
{
    public class AddTripVM
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Data startu wycieczki")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage ="Wymagane podanie daty początku wycieczki!")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Data końca wycieczki")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage ="Wymagene podanie daty końca wycieczki!")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Liczba kilometrów")]
        [Required(ErrorMessage = "Wymagene podanie liczby kilometrów!")]
        [Range(UInt32.MinValue, UInt32.MaxValue, ErrorMessage ="Niepoprawna wartość liczby kilometrów")]
        public uint Kilometers { get; set; }
        [Display(Name = "Miejsce startu")]
        [Required(ErrorMessage = "Wymagane podanie miejsca startu!")]
        [MaxLength(30, ErrorMessage = "Przekroczono dozwoloną długość nazwy miejsce startowego")]
        public string LaunchSite { get; set; }
        [Display(Name = "Miejsce docelowe")]
        [MaxLength(30, ErrorMessage = "Przekroczono dozwoloną długość nazwy miejsce docelowego")]
        public string Destination { get; set; }
        [Display(Name = "Opis wycieczki")]
        [MaxLength(200, ErrorMessage ="Przekroczono dozwoloną długość opisu wycieczki")]
        public string Description { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }
        public virtual ICollection<Video> Videos { get; set; }


    }
}