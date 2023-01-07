using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Patterns.Factory.Implementations;
using FileSorterWinForm.Patterns.Factory.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;
using FileSorterWinForm.Services.Base;
using FileSorterWinForm.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorterWinForm.Services.Implementations
{
    public class MoveService : BaseSortingMethodService
    {
        public MoveService(IDirectoryRepository fileDirectoryRepository) : base(fileDirectoryRepository)
        {
        }

        public override bool Execute(string filePath, string destionationDirectory)
        {      
            if (ShowWarningMessage() == DialogResult.No)
                return false;
            
            IFile file = _customFileFactory.CreateCustomFile(filePath, destionationDirectory);

            _fileDirectoryRepository.BuildFileDirectory(file);

            File.Move(file.FileFullPath, file.FileDestinationPath);
        }

        private DialogResult ShowWarningMessage()
        {
            return MessageBox.Show("Moving your files can be risky, are you sure you want to proceed?",
                                                    "Warning",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
        }
    }
}
