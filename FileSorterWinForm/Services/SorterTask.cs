using FileSorterWinForm.Models;
using FileSorterWinForm.Repositories.Implementations;
using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Services
{
    public class SorterTask
    {
        private IFileSettingsRepository fileSettingsRepository { get; set; }

        public SorterTask()
        {
            fileSettingsRepository = (IFileSettingsRepository)Program.ServiceProvider.GetService(typeof(IFileSettingsRepository));
        }
        protected void SetupExecutionRequirements(CustomFileSettings fileSettings)
        {
            fileSettingsRepository.CreateDirectoryIfMissing(fileSettings.DestinationFolderPath);
        }
    }
}
