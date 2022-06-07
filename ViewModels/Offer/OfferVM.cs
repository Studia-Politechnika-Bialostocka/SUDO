using System.ComponentModel.DataAnnotations;
using SUDO.Models;

namespace SUDO.ViewModels.Offer
{
    public class OfferVM
    {
        public int? Id {get; set;}

        [Display(Name = "Destination")]
        [StringLength(100, ErrorMessage = "{0} length cannot be greater than {1}.")]
        [Required(ErrorMessage="This field is required.")]    
        public string Destination {get; set;}

        public string? Stops {get; set;}

        public string? DriverId {get; set;}
        public string? DriverName {get; set;}

        [Display(Name = "MaxPassengeCount")]
        [Range(1, 8, ErrorMessage = "{0} must be between {1} and {2}.")] 
        [RegularExpression("^[0-9]+$", ErrorMessage = "{0} może zawierać jedynie liczby całkowite.")]
        [Required(ErrorMessage="This field is required.")]    
        public int MaxPassengerCount {get; set;}

        public bool NonSmoking {get; set;}

        [Required(ErrorMessage="This field is required.")]  
        public double Cost {get; set;}

        [Required(ErrorMessage="This field is required.")]
        public DateTime Departure{get; set;}

        [Required(ErrorMessage="This field is required.")]
        public DateTime Arrival{get; set;}
        public int PassengerCount {get; set;}
        public bool IsFull {get; set;}
    }
}