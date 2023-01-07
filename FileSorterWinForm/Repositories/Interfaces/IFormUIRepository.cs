using FileSorterWinForm.Models.Files.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSorterWinForm.Extensions;


namespace FileSorterWinForm.Repositories.Interfaces
{
    public interface IFormUIRepository
    {
        void WriteComboBoxWithFileExtensions(ComboBox comboBox, List<string> fileExtensions);
        void WriteFileNameAndExtensionOnRichTextBox(RichTextBox textbox, List<string> allFiles);
        int IncrementProgressBar(ProgressBar progressBar, int totalFilesToBeMoved);
        void IncrementProgressBarLabel(Label progressBarLabel, int amount);
        void WriteFileSuccessStatusOnRichTextBox(RichTextBox textbox, IFile file); 
        void WriteFileFailStatusOnRichTextBox(RichTextBox textbox, IFile file, string errorMessage); 

    }
}
