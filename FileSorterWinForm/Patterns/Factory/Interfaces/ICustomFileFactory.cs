using FileSorterWinForm.Models.Files.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Patterns.Factory.Interfaces
{
    public interface ICustomFileFactory
    {
        IFile CreateCustomFile(string fileName);
    }
}
