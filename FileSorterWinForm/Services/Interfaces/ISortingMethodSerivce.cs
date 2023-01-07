using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Services.Interfaces
{
    public interface ISortingMethodSerivce
    {
        void Execute(string filePath, string destionationDirectory);
    }
}
