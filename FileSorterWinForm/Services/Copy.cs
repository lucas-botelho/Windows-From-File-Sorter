using FileSorterWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Services
{
    public class SortActionCopy : ISortAction
    {
        public void Execute(string source, string target)
        {
            File.Copy(source, target);
        }
    }
}
