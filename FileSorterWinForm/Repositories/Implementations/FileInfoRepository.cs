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
    class FileInfoRepository : IFileRepository
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

        public void ChangeDuplicatedFileName(IFile file)
        {
            var repeatedFileCount = 0;
            var filePath = file.FileDestinationPath;

            while (File.Exists(filePath))
            {
                if (repeatedFileCount == 0)
                    file.FileNameWithoutExtension += $"({++repeatedFileCount})";
                else
                    file.FileNameWithoutExtension = file.FileNameWithoutExtension.Replace($"({repeatedFileCount})", $"({++repeatedFileCount})");

                filePath = filePath.Replace(Path.GetFileNameWithoutExtension(filePath), file.FileNameWithoutExtension);
            }
        }

        public IFile HandleDuplicatedFileName(IFile file)
        {
            //move to abstract class and make them private
            ChangeDuplicatedFileName(file);
            ChangeDuplicatedFilePath(file);
            
            return file;
        }

        public void ChangeDuplicatedFilePath(IFile file)
        {
            file.FileDestinationPath = file.FileDestinationPath.Replace(Path.GetFileNameWithoutExtension(file.FileDestinationPath), file.FileNameWithoutExtension);
        }

        public List<string> GetFilesExtensionsTypes(List<string> files)
        {
            var fileExtensions = new List<string>();

            files.ForEach(file =>
            {
                if (!fileExtensions.Contains(Path.GetExtension(file)))
                    fileExtensions.Add(Path.GetExtension(file));
            });

            return fileExtensions;

        }
    }
}
