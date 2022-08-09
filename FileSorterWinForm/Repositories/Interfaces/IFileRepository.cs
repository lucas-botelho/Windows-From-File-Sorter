using FileSorterWinForm.Models;
using FileSorterWinForm.Models.Files.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Repositories.Interfaces
{
    public interface IFileRepository
    {
        DateTime GetFileDateFromImageProperties(string path);
        void FillFileDatesFromFileInfo(IFile fileSettings);
        void FillImageObjectFileDates(IFile file);
        void ChangeDuplicatedFileName(IFile file);
        IFile HandleDuplicatedFileName(IFile file);
        void ChangeDuplicatedFilePath(IFile file);

        /// <summary>
        /// Return a list of file extensions existing in a list of files
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        List<string> GetFilesExtensionsTypes(List<string> files);
    }
}
