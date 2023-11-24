using FileSorterWinForm.Repositories.Implementations;
using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Models
{
    public class CustomFileSettings
    {
        private IFileDateRepository fileDateRepository { get; set; }


        public CustomFileSettings(string filePath, string destinationDirectory)
        {
            fileDateRepository = (IFileDateRepository)Program.ServiceProvider.GetService(typeof(IFileDateRepository));

            SourcePath = Path.GetFullPath(filePath);
            FileExtension = Path.GetExtension(filePath);
            FileName = Path.GetFileNameWithoutExtension(filePath);

            PictureDate = fileDateRepository.GetDateTakenFromImage(this.SourcePath);
            fileDateRepository.GetFileDateFromFileInfo(this);

            CalculateDestionationSortedFolder(destinationDirectory);
            CalculateFullDestionationPathWithDuplicates();

        }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime PictureDate { get; set; }

        public string SourcePath { get; set; }

        public string DestinationFolderPath { get; set; }

        public string FullDestinationPath { get; set; }

        public string FileName { get; set; }

        public string FileExtension { get; set; }

        public void CalculateDestionationSortedFolder(string destinionationDirectory)
        {
            this.DestinationFolderPath = Path.Combine(destinionationDirectory, this.PictureDate.Year.ToString(), this.PictureDate.ToString("MM"));
        }


        private void CalculateFullDestionationPathWithDuplicates()
        {
            var repeatedFileCount = 0;

            FullDestinationPath = Path.Combine(this.DestinationFolderPath, this.FileName + this.FileExtension);

            while (File.Exists(this.FullDestinationPath))
            {
                if (repeatedFileCount == 0)
                    this.FileName += $"({++repeatedFileCount})";
                else
                    this.FileName = this.FileName.Replace($"({repeatedFileCount})", $"({++repeatedFileCount})");

                FullDestinationPath = Path.Combine(this.DestinationFolderPath, this.FileName + this.FileExtension);
            }
        }
    }
}
