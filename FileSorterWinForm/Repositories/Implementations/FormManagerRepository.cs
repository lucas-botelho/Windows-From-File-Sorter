using FileSorterWinForm.Extensions;
using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSorterWinForm.Repositories.Implementations
{
    internal class FormManagerRepository : IFormManagerRepository
    {
        private int FilesProcessed { get; set; }

        public FormManagerRepository()
        {
            this.FilesProcessed = 0;
        }

        public void UpdateProgressBar(ProgressBar progressBar, Label progressBarLabel, int totalFilesToBeMoved)
        {
            FilesProcessed++;
            progressBar.Value = FilesProcessed * 100 / totalFilesToBeMoved;
            progressBarLabel.Text = progressBar.Value.ToString() + " %";
        }


        public void FillComboBoxWithFileExtensions(ComboBox comboBox, List<string> fileExtensions)
        {
            comboBox.Items.Clear();

            //Fill comboBox values
            foreach (var extension in fileExtensions)
                comboBox.Items.Add(extension);

            comboBox.Items.Add("*");
            comboBox.SelectedIndex = 0;
            comboBox.Enabled = true;
        }

        public void WriteFileNameAndExtensionOnTextBox(RichTextBox rtb, IEnumerable<string> allFiles)
        {
            foreach (var file in allFiles)
            {
                rtb.AppendText($"{Path.GetFileNameWithoutExtension(file)}", Color.DarkGoldenrod);
                rtb.AppendText($"{Path.GetExtension(file)}", Color.HotPink, true);
            }

            rtb.AppendText($"Total files: {allFiles.Count()}", Color.Black, true);
        }

        public string ReadSourceDirectory(TextBox textBox)
        {
            string sourceDirectory;

            try
            {
                sourceDirectory = Path.GetFullPath(textBox.Text);
            }
            catch (Exception ex)
            {
                throw new Exception();
            }

            if (!Directory.Exists(sourceDirectory))
            {
                MessageBox.Show("The directory you're trying to sort from does not exist.", "Error");
                throw new DirectoryNotFoundException();
            }

            return sourceDirectory;
        }

        public bool IsFormReadyForSubmission(ComboBox sortingActionComboBox, ComboBox fileTypeComboBox, TextBox sourcePathTextBox)
        {
            if (fileTypeComboBox != null && fileTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Select a file type to sort.", "Warning");
                return false;
            }

            if (sourcePathTextBox != null && string.IsNullOrEmpty(sourcePathTextBox.Text))
            {
                MessageBox.Show("Select the source directory.", "Warning");
                return false;
            }

            return true;
        }

        public void ResetProgressBar(ProgressBar progressBar, Label progressBarLabel)
        {
            progressBar.Value = 0;
            progressBarLabel.Visible = false;
            progressBarLabel.Text = string.Empty;
            progressBarLabel.Visible = false;
        }
    }
}
