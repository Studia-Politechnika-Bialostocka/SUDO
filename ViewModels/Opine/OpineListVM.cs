using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using SUDO.Models;

namespace SUDO.ViewModels.Opines
{
    public class OpineListVM
    {
        public List<OpineVM> Opines {get;set;}
        public int Count{get; set;}
    }
}