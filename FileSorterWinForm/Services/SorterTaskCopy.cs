using FileSorterWinForm.Models;
using FileSorterWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Services
{
    public class SorterTaskCopy : SorterTask, ISorterTask
    {
        public void Execute(CustomFileSettings customFileSettings)
        {
            base.SetupExecutionRequirements(customFileSettings);
            File.Copy(customFileSettings.SourcePath, customFileSettings.FullDestinationPath);
        }
    }
}
