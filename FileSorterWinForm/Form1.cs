using FileSorterWinForm.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using FileSorterWinForm.Extensions;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Text.RegularExpressions;
using FileSorterWinForm.Repositories.Interfaces;
using FileSorterWinForm.Services.Interfaces;
using FileSorterWinForm.Exceptions;
using FileSorterWinForm.Repositories.Implementations;
using System.Security.Cryptography.X509Certificates;

namespace FileSorterWinForm
{
    public partial class Form1 : Form
    {
        private ISortTaskFactory sortTaskFactory { get; set; }
        private IFormManagerRepository formManagerRepository { get; set; }
        private IFileSettingsRepository fileSettingsRepository { get; set; }

        public Form1()
        {
            InitializeComponent();
            sortTaskFactory = (ISortTaskFactory)Program.ServiceProvider.GetService(typeof(ISortTaskFactory));
            formManagerRepository = (IFormManagerRepository)Program.ServiceProvider.GetService(typeof(IFormManagerRepository));
            fileSettingsRepository = (IFileSettingsRepository)Program.ServiceProvider.GetService(typeof(IFileSettingsRepository));
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

                formManagerRepository.WriteFileNameAndExtensionOnTextBox(result_richTextBox, allFiles.ToList());
                formManagerRepository.FillComboBoxWithFileExtensions(fileType_comboBox, fileSettingsRepository.GetFilesExtensionsTypes(allFiles.ToList()));
            }
        }

        private void destionationPath_button_Click(object sender, EventArgs e)
        {
            if (destinationPath_dialog.ShowDialog() == DialogResult.OK)
            {
                var destinationDirectory = Path.GetFullPath(destinationPath_dialog.SelectedPath);
                destinationPath_textBox.Text = destinationDirectory;
            }
        }

        private void runApp_button_Click(object sender, EventArgs e)
        {
            if (!formManagerRepository.IsFormReadyForSubmission(sortingAction_comboBox, fileType_comboBox, sourcePath_textBox))
                return;

            ISorterTask task;
            int countMovedFiles = 0;
            try
            {
                task = sortTaskFactory.Create((string)sortingAction_comboBox.Items[sortingAction_comboBox.SelectedIndex]);
            }
            catch (SortActionBackDownException)
            {
                return;
            }

            progressBar1.Visible = true;


            var filesToBeMoved = Directory.GetFiles(sourcePath_textBox.Text,
                                           $"*.{fileType_comboBox.Items[fileType_comboBox.SelectedIndex].ToString().Trim('.')}",
                                           SearchOption.AllDirectories);

            foreach (var filePath in filesToBeMoved)
            {
                var fileSettings = new CustomFileSettings(Path.GetFullPath(filePath), destinationPath_textBox.Text);


                try
                {
                    task.Execute(fileSettings);
                    countMovedFiles++;
                    formManagerRepository.UpdateProgressBar(progressBar1, progressBar_label, filesToBeMoved.Count());

                    result_richTextBox
                        .AppendText($"Moved file:", Color.Green)
                        .AppendText($"{Path.GetFileName(filePath)}", Color.Blue)
                        .AppendText($" from: ", Color.Green)
                        .AppendText($"{fileSettings.SourcePath}", Color.Blue)
                        .AppendText($" to: ", Color.Green)
                        .AppendText($"{fileSettings.FullDestinationPath}", Color.Blue, true);
                }
                catch (Exception ex)
                {
                    formManagerRepository.UpdateProgressBar(progressBar1, progressBar_label, filesToBeMoved.Count());

                    result_richTextBox
                        .AppendText($"Could not copy file -> {Path.GetFullPath(filePath)}", Color.Red, true)
                        .AppendText($"Message: {ex.Message}", Color.DarkGoldenrod, true);
                }
            }

            result_richTextBox.AppendText($"Total files moves: {countMovedFiles}");
            MessageBox.Show("Job finished!",
                            "Success",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);


            formManagerRepository.ResetProgressBar(progressBar1, progressBar_label);
        }

        private void sourcePath_textBox_Leave(object sender, EventArgs e)
        {
            string sourceDirectory;

            try
            {
                sourceDirectory = formManagerRepository.ReadSourceDirectory(sourcePath_textBox);
            }
            catch (Exception)
            {
                return;
            }

            var allFiles = Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories);

            formManagerRepository.WriteFileNameAndExtensionOnTextBox(result_richTextBox, allFiles);
            formManagerRepository.FillComboBoxWithFileExtensions(fileType_comboBox, fileSettingsRepository.GetFilesExtensionsTypes(allFiles.ToList()));
        }
    }
}
