using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Models.Files.Bases
{
    public abstract class CustomFileBase : IFile
    {
        public CustomFileBase(string filePath, string fileDestinationPath)
        {
            this.fileRepository = (IFileRepository)Program.ServiceProvider.GetService(typeof(IFileRepository));
            GetFilePropertiesValues(filePath, fileDestinationPath);
        }

        private IFileRepository fileRepository { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get;  set; }
        public string FileFullPath { get; set; }
        public string FileDirectory { get; set; }
        public string FileNameWithoutExtension { get; set; }
        public string FileExtension { get; set; }


        public string FileDestinationPath { get; set; }

        /// <summary>
        /// Create target directory path with [target directory + year + month]
        /// </summary>

        public string DirectoryDestinationPath { get; set; }

        public virtual DateTime GetFileOriginalDate()
        {
            return CreationDate;    
        }

        private void GetFilePropertiesValues(string filePath, string fileDestinationPath)
        {
            this.FileFullPath = Path.GetFullPath(filePath);
            this.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileFullPath);
            this.FileExtension = Path.GetExtension(FileFullPath);
            this.FileDirectory = FileFullPath.Replace(FileNameWithoutExtension, string.Empty);

            FillImageObjectFileDates(this);

            this.DirectoryDestinationPath = fileDestinationPath;
            this.FileDestinationPath = Path.Combine(DirectoryDestinationPath, $"{FileNameWithoutExtension}{FileExtension}");
        }

        private void FillImageObjectFileDates(IFile file)
        {
            file.CreationDate = fileRepository.GetFileDateFromImageProperties(file.FileFullPath);
            if (file.CreationDate == DateTime.MinValue)
                fileRepository.FillFileDatesFromFileInfo(file);
        }
    }
}
