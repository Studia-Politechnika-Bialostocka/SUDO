using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SUDO.Models;

namespace SUDO.ViewModels.Opines
{
    public class OpineVM
    {
        public int? Id {get;set;}

        [Required(ErrorMessage="This field is required.")]  
        [Range(1, 10, ErrorMessage = "{0} must be between {1} and {2}.")] 
        public int DrivingRating {get;set;}
        [Required(ErrorMessage="This field is required.")]  
        [Range(1, 10, ErrorMessage = "{0} must be between {1} and {2}.")] 
        public int ProprietyRating {get;set;}
        [Required(ErrorMessage="This field is required.")]  
        [Range(1, 10, ErrorMessage = "{0} must be between {1} and {2}.")] 
        public int PunctualityRating {get;set;}

        [StringLength(200, ErrorMessage = "{0} length cannot be greater than {1}.")]
        public string? Comment {get;set;}

        public string? CurrentUserId {get;set;}
        public string? CommentedUserId{get;set;}
    }
}