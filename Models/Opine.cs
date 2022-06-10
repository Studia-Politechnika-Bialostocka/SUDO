using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SUDO.Models
{
    public class Opine
    {
        public int Id {get;set;}
        public int DrivingRating {get;set;}
        public int ProprietyRating {get;set;}
        public int PunctualityRating {get;set;}
        public string? Comment {get;set;}
        public string CurrentUserId {get;set;}
        public string CommentedUserId {get;set;}
    }
}