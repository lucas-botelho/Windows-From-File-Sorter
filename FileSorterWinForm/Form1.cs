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
using FileSorterWinForm.Models.Files.Bases;
using FileSorterWinForm.Patterns.Factory.Interfaces;

namespace FileSorterWinForm
{
    public partial class Form1 : Form
    {
        private IFileRepository fileRepository { get; set; }
        private IFormRepository formRepository { get; set; }
        private ICustomFileFactory customFileFactory { get; set; }

        public Form1()
        {
            InitializeComponent();
            fileRepository = (IFileRepository)Program.ServiceProvider.GetService(typeof(IFileRepository));
            formRepository = (IFormRepository)Program.ServiceProvider.GetService(typeof(IFormRepository));
            customFileFactory = (ICustomFileFactory)Program.ServiceProvider.GetService(typeof(ICustomFileFactory));
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

                formRepository.WriteFileNameAndExtensionOnRichTextBox(result_richTextBox, allFiles.ToList());
                formRepository.WriteComboBoxWithFileExtensions(fileType_comboBox, fileRepository.GetFilesExtensionsTypes(allFiles.ToList()));
            }
        }

        private void destionationPath_button_Click(object sender, EventArgs e)
        {
            if (destinationPath_dialog.ShowDialog() == DialogResult.OK)
                destinationPath_textBox.Text = Path.GetFullPath(destinationPath_dialog.SelectedPath);
        }

        private void runApp_button_Click(object sender, EventArgs e)
        {
            if (sortingAction_comboBox.Items[sortingAction_comboBox.SelectedIndex].Equals("Move"))
            {
                DialogResult messageBox = MessageBox.Show("Moving your files can be risky, are you sure you want to proceed?",
                                                    "Warning",
                                                    MessageBoxButtons.YesNo,
                                                    MessageBoxIcon.Warning);
                if (messageBox == DialogResult.No)
                    return;
            }

            int filesMovedCount, filesNotMovedCount;
            filesMovedCount = filesNotMovedCount = 0;
            progressBar1.Visible = true;

            var filesPathsToBeMoved = Directory.GetFiles(sourcePath_textBox.Text,
                                           $"*.{fileType_comboBox.Items[fileType_comboBox.SelectedIndex].ToString().Trim('.')}",
                                           SearchOption.AllDirectories);            

            foreach (var filePath in filesPathsToBeMoved)
            {                
                IFile file = customFileFactory.CreateCustomFile(filePath);

                if (!Directory.Exists(file.DirectoryDestinationPath))
                    Directory.CreateDirectory(file.DirectoryDestinationPath);

                if (File.Exists(file.FileDestinationPath))
                    fileRepository.HandleDuplicatedFileName(file);

                try
                {
                    switch (sortingAction_comboBox.Items[sortingAction_comboBox.SelectedIndex])
                    {
                        case "Move":
                            File.Move(file.FileFullPath, file.FileDestinationPath);
                            break;
                        case "Copy":
                        default:
                            File.Copy(file.FileFullPath, file.FileDestinationPath, false);
                            break;
                    }

                    filesMovedCount++;

                    formRepository.IncrementProgressBar(progressBar1, filesPathsToBeMoved.Count());
                    formRepository.IncrementProgressBarLabel(progressBar_label, filesPathsToBeMoved.Count());
                    formRepository.WriteFileSuccessStatusOnRichTextBox(result_richTextBox, file);
                }
                catch (Exception ex)
                {
                    filesNotMovedCount++;
                    formRepository.IncrementProgressBar(progressBar1, filesPathsToBeMoved.Count());
                    formRepository.IncrementProgressBarLabel(progressBar_label, filesPathsToBeMoved.Count());
                    formRepository.WriteFileFailStatusOnRichTextBox(result_richTextBox, file, ex.Message);
                }
            }

            result_richTextBox.AppendText($"Total files moved: {filesMovedCount}");
            result_richTextBox.AppendText($"Total files not moved: {filesNotMovedCount}");

            MessageBox.Show("Job done!",
                            "YEAHH!!!",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
        }

    }
}
