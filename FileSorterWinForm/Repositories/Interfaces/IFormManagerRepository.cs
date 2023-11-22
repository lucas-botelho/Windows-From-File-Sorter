using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorterWinForm.Repositories.Interfaces
{
    internal interface IFormManagerRepository
    {
        void UpdateProgressBar(ProgressBar progressBar, Label progressBarLabel, int totalFilesToBeMoved);
        void FillComboBoxWithFileExtensions(ComboBox comboBox, List<string> fileExtensions);
        void WriteFileNameAndExtensionOnTextBox(RichTextBox rtb, List<string> allFiles);

    }
}
