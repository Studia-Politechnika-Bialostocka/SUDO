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
        public int Rating {get;set;}
        public string Comment {get;set;}
    }
}