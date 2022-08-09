using FileSorterWinForm.Models.Files;
using FileSorterWinForm.Models.Files.Interfaces;
using FileSorterWinForm.Patterns.Factory.Interfaces;
using FileSorterWinForm.Repositories.Interfaces;

namespace FileSorterWinForm.Patterns.Factory.Implementations
{
    public class CustomFileFactory : ICustomFileFactory
    {
        public IFile CreateCustomFile(string filePath)
        {
            if (filePath.StartsWith("GH") || filePath.StartsWith("GOPR") || filePath.StartsWith("GX"))
                return new GoProImageFile(filePath);

            return new GenericImageFile(filePath);
        }
    }
}
