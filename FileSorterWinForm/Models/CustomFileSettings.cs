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

            this.SourcePath = Path.GetFullPath(filePath);
            this.PictureDate = fileDateRepository.GetDateTakenFromImage(this.SourcePath);
            if (this.PictureDate == DateTime.MinValue)
                fileDateRepository.GetFileDateFromFileInfo(this);

            this.FileName = Path.GetFileNameWithoutExtension(filePath);
            this.FileExtension = Path.GetExtension(filePath);

            this.CalculateDestionationSortedFolder(destinationDirectory);
            this.FullDestinationPath = Path.Combine(this.DestinationFolderPath, this.FileName + this.FileExtension);
            HandleDuplicatedFileName();

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


        private void HandleDuplicatedFileName()
        {
            var repeatedFileCount = 1;

            while (File.Exists(this.FullDestinationPath))
            {
                if (repeatedFileCount == 1)
                    this.FileName += $"({++repeatedFileCount})";
                else
                    this.FileName = this.FileName.Replace($"({repeatedFileCount})", $"({++repeatedFileCount})");

                this.FullDestinationPath = this.FullDestinationPath.Replace(Path.GetFileNameWithoutExtension(this.FullDestinationPath), this.FileName);
            }
        }

    }
}
