using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Models.Files.Interfaces
{
    public interface IFileSettings
    {
        string FileDestinationPath { get; set; }
        string DirectoryDestinationPath { get; set; }
    }
}
