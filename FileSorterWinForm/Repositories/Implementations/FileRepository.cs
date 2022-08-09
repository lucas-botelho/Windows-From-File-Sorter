using FileSorterWinForm.Models;
using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FileSorterWinForm.Repositories.Implementations
{
    class FileRepository : IFileRepository
    {
        public DateTime GetFileDateFromImageProperties(string path)
        {
            Regex regx = new Regex(":");
            string dateTaken = string.Empty;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (Image myImage = Image.FromStream(fs, false, false))
                {

                    PropertyItem propItem = myImage.GetPropertyItem(36867);
                    dateTaken = regx.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);

                }
            }
            catch (Exception)
            {
                return new DateTime();
            }

            return DateTime.Parse(dateTaken);

        }

        public void FillFileDatesFromFileInfo(IFile file)
        {
            var fileInfo = new FileInfo(file.FileFullPath);
            file.ModifiedDate = fileInfo.LastWriteTimeUtc;
            file.CreationDate = fileInfo.CreationTime;
        }

        public void FillImageObjectFileDates(IFile file)
        {
            file.CreationDate = GetFileDateFromImageProperties(file.FileFullPath);
            if (file.CreationDate == DateTime.MinValue)
                FillFileDatesFromFileInfo(file);
        }


        public void ChangeDuplicatedFileName(IFile file)
        {
            var repeatedFileCount = 0;
            var filePath = file.FileDestinationPath;

            while (File.Exists(filePath))
            {
                if (repeatedFileCount == 0)
                    file.FileName += $"({++repeatedFileCount})";
                else
                    file.FileName = file.FileName.Replace($"({repeatedFileCount})", $"({++repeatedFileCount})");

                filePath = filePath.Replace(Path.GetFileNameWithoutExtension(filePath), file.FileName);
            }
        }

        public IFile HandleDuplicatedFileName(IFile file)
        {
            ChangeDuplicatedFileName(file);
            ChangeDuplicatedFilePath(file);

            return file;
        }

        public void ChangeDuplicatedFilePath(IFile file)
        {
            file.FileDestinationPath = file.FileDestinationPath.Replace(Path.GetFileNameWithoutExtension(file.FileDestinationPath), file.FileName);
        }

        public List<string> GetFilesExtensionsTypes(List<string> files)
        {
            var fileExtensions = new List<string>();

            files.ForEach(x =>
            {
                if (!fileExtensions.Contains(Path.GetExtension(x)))
                    fileExtensions.Add(Path.GetExtension(x));
            });

            return fileExtensions;

        }
    }
}
