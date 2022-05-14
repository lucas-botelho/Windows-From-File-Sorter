using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Models
{
    public class CustomFileSettings
    {

        public CustomFileSettings()
        {

        }

        public DateTime CreationDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public DateTime PictureDate { get; set; }

        public int MovedFiles { get; set; }

        public string SourcePath { get; set; }

        public string DestinationFolderPath { get; set; }

        public string FullDestinationPath { get; set; }
    }
}
