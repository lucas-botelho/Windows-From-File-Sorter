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

        public void WriteFileNameAndExtensionOnTextBox(RichTextBox rtb, List<string> allFiles)
        {
            foreach (var file in allFiles)
            {
                rtb.AppendText($"{Path.GetFileNameWithoutExtension(file)}", Color.DarkGoldenrod);
                rtb.AppendText($"{Path.GetExtension(file)}", Color.HotPink, true);
            }

            rtb.AppendText($"Total files: {allFiles.Count()}", Color.Black, true);
        }
    }
}
