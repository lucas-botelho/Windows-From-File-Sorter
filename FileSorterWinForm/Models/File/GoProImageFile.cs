using FileSorterWinForm.Models.Files.Bases;
using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Models.Files
{
    public class GoProImageFile : CustomFileBase
    {
        public GoProImageFile(string filePath, string fileDestinationPath) : base(filePath, fileDestinationPath)
        {

        }
    }
}
