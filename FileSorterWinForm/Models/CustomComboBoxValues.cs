using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSorterWinForm.Models
{
    class CustomComboBoxValues
    {
        public CustomComboBoxValues(string value, string text)
        {
            this.Value = value;
            this.Text = text;

        }
        public string Value { get; set; }

        public string Text { get; set; }
    }
}
