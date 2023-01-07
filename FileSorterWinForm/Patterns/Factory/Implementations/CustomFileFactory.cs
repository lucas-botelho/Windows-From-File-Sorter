using FileSorterWinForm.Models.Files;
using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Patterns.Factory.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;
using System.Drawing.Text;

namespace FileSorterWinForm.Patterns.Factory.Implementations
{
    public class CustomFileFactory : ICustomFileFactory
    {
        public IFile CreateCustomFile(string filePath, string fileDestinationPath)
        {

            var isGoProFile = filePath.StartsWith("GH") || filePath.StartsWith("GOPR") || filePath.StartsWith("GX");
            if (isGoProFile)
                return new GoProImageFile(filePath, fileDestinationPath);

            return new GenericImageFile(filePath, fileDestinationPath);
        }
    }
}
