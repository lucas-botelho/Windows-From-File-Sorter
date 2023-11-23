using FileSorterWinForm.Models;
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
    public class SorterTaskMove : SorterTask, ISorterTask
    {
        public void Execute(CustomFileSettings customFileSettings)
        {
            base.SetupExecutionRequirements(customFileSettings);
            File.Move(customFileSettings.SourcePath, customFileSettings.FullDestinationPath);
        }
    }
}
