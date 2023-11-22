using FileSorterWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorterWinForm.Services
{
    public class SortActionMove : ISortAction
    {
        public void Execute(string source, string target)
        {
            File.Move(source, target);
        }
    }
}
