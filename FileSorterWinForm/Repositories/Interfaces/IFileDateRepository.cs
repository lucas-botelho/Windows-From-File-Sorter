using FileSorterWinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Repositories.Interfaces
{
    public interface IFileDateRepository
    {
        DateTime GetDateTakenFromImage(string path);

        void GetFileDateFromFileInfo(CustomFileSettings fileSettings);
    }
}
