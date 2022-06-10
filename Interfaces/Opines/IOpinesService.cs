using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SUDO.ViewModels.Opines;

namespace SUDO.Interfaces.Opines
{
    public interface IOpinesService
    {
        void AddEntry(OpineVM entry);
        OpineListVM GetAllEntries();
        OpineVM GetOpineById(int id);
    }
}