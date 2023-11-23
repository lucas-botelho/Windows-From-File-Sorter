using FileSorterWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Services.Interfaces
{
    public interface ISorterTask
    {
        void Execute(CustomFileSettings customFileSettings);
    }
}
