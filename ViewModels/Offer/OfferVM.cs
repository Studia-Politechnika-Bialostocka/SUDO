using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SUDO.ViewModels.Offer
{
    public class OfferVM
    {
        public int? Id {get; set;}

        [Display(Name = "Destination")]
        [StringLength(100, ErrorMessage = "{0} length cannot be greater than {1}.")]
        [Required(ErrorMessage="This field is required.")]    
        public string Destination {get; set;}

        public string? DriverName {get; set;}

        [Display(Name = "MaxPassengeCount")]
        [Range(1899, 2022, ErrorMessage = "{0} must be between {1} and {2}.")] 
        [RegularExpression("^[0-9]+$", ErrorMessage = "{0} może zawierać jedynie liczby całkowite.")]
        [Required(ErrorMessage="This field is required.")]    
        public int MaxPassengerCount {get; set;}

        public bool NonSmoking {get; set;}

        [Required(ErrorMessage="This field is required.")]  
        public double Cost {get; set;}

        public bool? IsFull {get; set;}
    }
}