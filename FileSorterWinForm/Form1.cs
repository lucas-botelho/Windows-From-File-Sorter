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

namespace FileSorterWinForm
{
    public partial class Form1 : Form
    {
        private IFileDateRepository fileDateRepository { get; set; }
        private ISortActionFactory sortActionFactory { get; set; }

        public Form1()
        {
            InitializeComponent();
            fileDateRepository = (IFileDateRepository)Program.ServiceProvider.GetService(typeof(IFileDateRepository));
            sortActionFactory = (ISortActionFactory)Program.ServiceProvider.GetService(typeof(ISortActionFactory));
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

                WriteFileNameAndExtensionOnTextBox(allFiles.ToList());
                FillComboBoxWithFileExtensions(GetFilesExtensionsTypes(allFiles.ToList()));
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
            try
            {
                var sortAction = sortActionFactory.Create(sortingAction_comboBox.Items[sortingAction_comboBox.SelectedIndex].ToString());
            }
            catch (SortActionBackDownException)
            {
                return;
            }

            var filesToBeMoved = Directory.GetFiles(sourcePath_textBox.Text,
                                           $"*.{fileType_comboBox.Items[fileType_comboBox.SelectedIndex].ToString().Trim('.')}",
                                           SearchOption.AllDirectories);

            var fileSettings = new CustomFileSettings();
            progressBar1.Visible = true;
            var progress = 0;

            foreach (var file in filesToBeMoved)
            {
                fileSettings.SourcePath = Path.GetFullPath(file);

                fileSettings.PictureDate = fileDateRepository.GetDateTakenFromImage(fileSettings.SourcePath);
                if (fileSettings.PictureDate == DateTime.MinValue)
                    fileDateRepository.GetFileDateFromFileInfo(fileSettings);

                //Create target directory path with [target directory + year + month]
                fileSettings.DestinationFolderPath = Path.Combine(destinationPath_textBox.Text, fileSettings.PictureDate.Year.ToString(), fileSettings.PictureDate.ToString("MM"));

                if (!Directory.Exists(fileSettings.DestinationFolderPath))
                    Directory.CreateDirectory(fileSettings.DestinationFolderPath);

                fileSettings.FileName = Path.GetFileNameWithoutExtension(file);
                fileSettings.FileExtension = Path.GetExtension(file);
                fileSettings.FullDestinationPath = Path.Combine(fileSettings.DestinationFolderPath, fileSettings.FileName + fileSettings.FileExtension);

                if (File.Exists(fileSettings.FullDestinationPath))
                {
                    ChangeDuplicatedFileName(fileSettings);
                    fileSettings.FullDestinationPath = fileSettings.FullDestinationPath.Replace(Path.GetFileNameWithoutExtension(fileSettings.FullDestinationPath), fileSettings.FileName );
                }

                try
                {
                    switch (sortingAction_comboBox.Items[sortingAction_comboBox.SelectedIndex])
                    {
                        case "Move":
                            File.Move(fileSettings.SourcePath, fileSettings.FullDestinationPath);
                            break;
                        case "Copy":
                        default:
                            File.Copy(fileSettings.SourcePath, fileSettings.FullDestinationPath, false);
                            break;
                    }

                    fileSettings.MovedFiles++;

                    progress++;
                    ManageProgressBar(progress, filesToBeMoved);

                    result_richTextBox.AppendText($"Moved file:", Color.Green);
                    result_richTextBox.AppendText($"{Path.GetFileName(file)}", Color.Blue);
                    result_richTextBox.AppendText($" from: ", Color.Green);
                    result_richTextBox.AppendText($"{fileSettings.SourcePath}", Color.Blue);
                    result_richTextBox.AppendText($" to: ", Color.Green);
                    result_richTextBox.AppendText($"{fileSettings.FullDestinationPath}", Color.Blue, true);
                }
                catch (Exception ex)
                {
                    progress++;
                    ManageProgressBar(progress, filesToBeMoved);

                    result_richTextBox.AppendText($"Could not copy file --> {Path.GetFullPath(file)}", Color.Red, true);
                    result_richTextBox.AppendText($"Message: {ex.Message}", Color.DarkGoldenrod, true);
                }
            }

            result_richTextBox.AppendText($"Total files moves: {fileSettings.MovedFiles}");
            MessageBox.Show("Job done!",
                            "YEAHH!!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

        private void FillComboBoxWithFileExtensions(List<string> fileExtensions)
        {
            fileType_comboBox.Items.Clear();

            //Fill comboBox values
            foreach (var extension in fileExtensions)
                fileType_comboBox.Items.Add(extension);

            fileType_comboBox.Items.Add("*");
            fileType_comboBox.SelectedIndex = 0;
            fileType_comboBox.Enabled = true;
        }

        private void WriteFileNameAndExtensionOnTextBox(List<string> allFiles)
        {
            foreach (var file in allFiles)
            {
                result_richTextBox.AppendText($"{Path.GetFileNameWithoutExtension(file)}", Color.DarkGoldenrod);
                result_richTextBox.AppendText($"{Path.GetExtension(file)}", Color.HotPink, true);
            }

            result_richTextBox.AppendText($"Total files: {allFiles.Count()}", Color.Black, true);         
        }
 

        /// <summary>
        /// Return a list of file extensions existing in a list of files
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        private static List<string> GetFilesExtensionsTypes(List<string> files)
        { 
            var fileExtensions = new List<string>();

            files.ForEach(x =>
            {
                if (!fileExtensions.Contains(Path.GetExtension(x)))
                    fileExtensions.Add(Path.GetExtension(x));
            });

            return fileExtensions;

        }

        private void ManageProgressBar(int progress, string[] filesToBeMoved)
        {
            progressBar1.Value = progress * 100 / filesToBeMoved.Count();
            progressBar_label.Text = progressBar1.Value.ToString() + "%";
        }

        private void ChangeDuplicatedFileName(CustomFileSettings fileSettings)
        {
            var repeatedFileCount = 0;
            var filePath = fileSettings.FullDestinationPath;

            while (File.Exists(filePath))
            {
                if (repeatedFileCount == 0)
                    fileSettings.FileName += $"({++repeatedFileCount})";
                else
                    fileSettings.FileName = fileSettings.FileName.Replace($"({repeatedFileCount})", $"({++repeatedFileCount})");

                filePath = filePath.Replace(Path.GetFileNameWithoutExtension(filePath), fileSettings.FileName);
            }

        }
    }
}
