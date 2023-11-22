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
        void ResetProgressBar(ProgressBar progressBar, Label progressBarLabel);
        void FillComboBoxWithFileExtensions(ComboBox comboBox, List<string> fileExtensions);
        void WriteFileNameAndExtensionOnTextBox(RichTextBox rtb, IEnumerable<string> allFiles);
        string ReadSourceDirectory(TextBox textBox);
        bool IsFormReadyForSubmission(ComboBox sortingActionComboBox, ComboBox fileTypeComboBox, TextBox sourcePathTextBox);


    }
}
