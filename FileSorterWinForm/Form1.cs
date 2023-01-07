using FileSorterWinForm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Text.RegularExpressions;
using FileSorterWinForm.Repositories.Interfaces;
using FileSorterWinForm.Models.Files;
using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Extensions;
using FileSorterWinForm.Patterns.Factory.Interfaces;

namespace FileSorterWinForm
{
    public partial class Form1 : Form
    {
        #region Private Properties
        private IFileRepository fileRepository { get; set; }
        private IFormUIRepository winFormRepository { get; set; }
        #endregion

        public Form1()
        {
            InitializeComponent();
            fileRepository = (IFileRepository)Program.ServiceProvider.GetService(typeof(IFileRepository));
            winFormRepository = (IFormUIRepository)Program.ServiceProvider.GetService(typeof(IFormUIRepository));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sourcePath_button_Click(object sender, EventArgs e)
        {
            if (sourcePath_dialog.ShowDialog() == DialogResult.OK)
            {
                var sourceDirectory = Path.GetFullPath(sourcePath_dialog.SelectedPath);

                sourcePath_textBox.Text = sourceDirectory;

                var allFiles = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);

                winFormRepository.WriteFileNameAndExtensionOnRichTextBox(result_richTextBox, allFiles.ToList());
                winFormRepository.WriteComboBoxWithFileExtensions(fileType_comboBox, fileRepository.GetFilesExtensionsTypes(allFiles.ToList()));
            }
        }

        private void destionationPath_button_Click(object sender, EventArgs e)
        {
            if (destinationPath_dialog.ShowDialog() == DialogResult.OK)
                destinationPath_textBox.Text = Path.GetFullPath(destinationPath_dialog.SelectedPath);
        }

        private void runApp_button_Click(object sender, EventArgs e)
        {
            int filesMovedCount = 0, filesNotMovedCount = 0, progressBarValue = 0 ;
            var sortingMethod = sortingAction_comboBox.Items[sortingAction_comboBox.SelectedIndex].Equals("Move");
            //factory here

            progressBar1.Visible = true;

            var filePathsToBeMoved = Directory.GetFiles(sourcePath_textBox.Text,
                                           $"*.{fileType_comboBox.Items[fileType_comboBox.SelectedIndex].ToString().Trim('.')}",
                                           SearchOption.AllDirectories);

            foreach (var filePath in filePathsToBeMoved)
            {                
                //IFile file = customFileFactory.CreateCustomFile(filePath, destinationPath_textBox.Text);

                //can be encapsulated create file directory - start
                
                //end

                try
                {
                    switch (sortingAction_comboBox.Items[sortingAction_comboBox.SelectedIndex])
                    {
                        case Constants.SortingMethodOption.Move:
                            break;
                        case Constants.SortingMethodOption.Copy:
                        default:
                            File.Copy(file.FileFullPath, file.FileDestinationPath, false);
                            break;
                    }

                    filesMovedCount++;

                    winFormRepository.WriteFileSuccessStatusOnRichTextBox(result_richTextBox, file);
                }
                catch (Exception ex)
                {
                    filesNotMovedCount++;
                    winFormRepository.WriteFileFailStatusOnRichTextBox(result_richTextBox, file, ex.Message);
                }

                progressBarValue = winFormRepository.IncrementProgressBar(progressBar1, filePathsToBeMoved.Count());
                winFormRepository.IncrementProgressBarLabel(progressBar_label, progressBarValue);
            }

            //Can be moved to it's own function
            result_richTextBox.AppendText($"Total files moved: {filesMovedCount}", Color.Black, true);
            result_richTextBox.AppendText($"Total files not moved: {filesNotMovedCount}");

            MessageBox.Show("Job done!", "YEAHH!!!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
