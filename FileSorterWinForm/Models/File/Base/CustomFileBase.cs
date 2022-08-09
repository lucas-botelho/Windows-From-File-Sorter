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
        public CustomFileBase(string filePath)
        {
            this.fileRepository = (IFileRepository)Program.ServiceProvider.GetService(typeof(IFileRepository));
            this.FileFullPath = filePath;
            fileRepository.FillImageObjectFileDates(this);
        }

        private IFileRepository fileRepository { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime ModifiedDate { get;  set; }
        public string FileFullPath { get; set; }
        public string FileName { get { return Path.GetFileNameWithoutExtension(FileFullPath); } set { FileName = value; } }
        public string FileExtension { get { return Path.GetExtension(FileFullPath); } set { FileExtension = value; } }

        public string FileDestinationPath { get { return Path.Combine(DirectoryDestinationPath, FileName + FileExtension); } set { FileDestinationPath = value; } }

        /// <summary>
        /// Create target directory path with [target directory + year + month]
        /// </summary>
        public string DirectoryDestinationPath 
        { 
            get 
            {
                var filePathWithoutName = FileDestinationPath.Replace(FileName, string.Empty);
                return Path.Combine(filePathWithoutName, CreationDate.Year.ToString(), CreationDate.ToString("MM")); 
            }
            set { DirectoryDestinationPath = value; }
        }

        public virtual DateTime GetFileOriginalDate()
        {
            return CreationDate;    
        }

    }
}
