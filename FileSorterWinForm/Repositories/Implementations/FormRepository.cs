using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSorterWinForm.Extensions;
using System.IO;

namespace FileSorterWinForm.Repositories.Implementations
{
    public class FormRepository : IFormRepository
    {
        private const int UNDRED_PERCENT = 100;
        public int IncrementProgressBar(ProgressBar progressBar, int totalFilesToBeMoved)
        {
            var progress = progressBar.Value * totalFilesToBeMoved / UNDRED_PERCENT;

            progress++;
            
            progressBar.Value = progress * UNDRED_PERCENT / totalFilesToBeMoved;

            return progressBar.Value;
        }
        public void IncrementProgressBarLabel(Label progressBarLabel, int amount)
        {
            progressBarLabel.Text = amount.ToString() + "%";
        }
        public void WriteComboBoxWithFileExtensions(ComboBox comboBox, List<string> fileExtensions)
        {
            //Fill comboBox values
            foreach (var extension in fileExtensions)
                comboBox.Items.Add(extension);

            comboBox.Items.Add("*");
            comboBox.SelectedIndex = 0;
            comboBox.Enabled = true;
        }
        public void WriteFileNameAndExtensionOnRichTextBox(RichTextBox textbox, List<string> allFiles)
        {
            foreach (var file in allFiles)
            {
                textbox.AppendText($"{Path.GetFileNameWithoutExtension(file)}", Color.DarkGoldenrod);
                textbox.AppendText($"{Path.GetExtension(file)}", Color.HotPink, true);
            }

            textbox.AppendText($"Total files: {allFiles.Count()}", Color.Black, true);
        }
        public void WriteFileSuccessStatusOnRichTextBox(RichTextBox textbox, IFile file)
        {
            textbox.AppendText($"Moved file:", Color.Green);
            textbox.AppendText($"{file.FileName}", Color.Blue);
            textbox.AppendText($" from: ", Color.Green);
            textbox.AppendText($"{file.FileFullPath}", Color.Blue);
            textbox.AppendText($" to: ", Color.Green);
            textbox.AppendText($"{file.FileDestinationPath}", Color.Blue, true);
        }
        public void WriteFileFailStatusOnRichTextBox(RichTextBox textbox, IFile file, string errorMessage)
        {
            textbox.AppendText($"Could not copy file --> {file.FileFullPath}", Color.Red, true);
            textbox.AppendText($"Message: {errorMessage}", Color.DarkGoldenrod, true);
        }

    }
}
