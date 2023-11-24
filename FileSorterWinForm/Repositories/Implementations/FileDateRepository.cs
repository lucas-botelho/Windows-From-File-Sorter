using FileSorterWinForm.Models;
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
    class FileDateRepository : IFileDateRepository
    {
        public DateTime GetDateTakenFromImage(string path)
        {
            Regex r = new Regex(":");
            string dateTaken = string.Empty;
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (Image myImage = Image.FromStream(fs, false, false))
                {

                    PropertyItem propItem = myImage.GetPropertyItem(36867);
                    dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);

                }
            }
            catch (Exception)
            {
                return new DateTime();
            }

            return DateTime.Parse(dateTaken);

        }

        public void GetFileDateFromFileInfo(CustomFileSettings fileSettings)
        {
            fileSettings.ModifiedDate = new FileInfo(fileSettings.SourcePath).LastWriteTimeUtc;
            fileSettings.CreationDate = new FileInfo(fileSettings.SourcePath).CreationTime;

            //add exception handling for filename
            //make oop refactor
            //Handle gopro files -- GOPRO file set modified date as 2016
            if (fileSettings.FileName.StartsWith("GH") || fileSettings.FileName.StartsWith("GOPR") || fileSettings.FileName.StartsWith("GX"))
                fileSettings.PictureDate = fileSettings.CreationDate;
            else
                fileSettings.PictureDate = fileSettings.ModifiedDate < fileSettings.CreationDate ? fileSettings.ModifiedDate : fileSettings.CreationDate;
        }
    }
}
