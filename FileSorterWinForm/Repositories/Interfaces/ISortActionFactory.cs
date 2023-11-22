using FileSorterWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Repositories.Interfaces
{
    public interface ISortActionFactory
    {
        ISortAction Create(string sortActionName);
    }
}
