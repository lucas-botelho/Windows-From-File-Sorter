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
using System.Xml.Linq;

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
        private void button1_Click(object sender, EventArgs e)
        {
            var filesToBeMoved = Directory.GetFiles(sourcePath_textBox.Text,
                                           $"*.{fileType_comboBox.Items[fileType_comboBox.SelectedIndex].ToString().Trim('.')}",
                                           SearchOption.AllDirectories);

            foreach (var file in filesToBeMoved)
            {

                if (Path.GetExtension(file).ToLower().Equals("png") || Path.GetExtension(file).ToLower().Equals(".png"))
                {
                    foreach (var file1 in filesToBeMoved)
                    {
                        if (Path.GetExtension(file1).ToLower().Equals("png") || Path.GetExtension(file1).ToLower().Equals(".png"))
                        {
                            string img1_ref, img2_ref;
                            var img1 = new Bitmap(file);
                            var img2 = new Bitmap(file1);
                            int count1 = 0, count2 = 0;
                            bool flag = true;

                            if (img1.Width == img2.Width && img1.Height == img2.Height)
                            {
                                for (int i = 0; i < img1.Width; i++)
                                {
                                    for (int j = 0; j < img1.Height; j++)
                                    {
                                        img1_ref = img1.GetPixel(i, j).ToString();
                                        img2_ref = img2.GetPixel(i, j).ToString();
                                        if (img1_ref != img2_ref)
                                        {
                                            count2++;
                                            flag = false;
                                            break;
                                        }
                                        count1++;
                                    }
                                }
                                if (flag == false)
                                    MessageBox.Show("Sorry, Images are not same , " + count2 + " wrong pixels found");
                                else
                                    MessageBox.Show(" Images are same , " + count1 + " same pixels found and " + count2 + " wrong pixels found");
                            }
                            else
                            {
                                MessageBox.Show("Sorry, Images are not same");
                            }

                        }
                    }

                }
            }

        }
    }
}
