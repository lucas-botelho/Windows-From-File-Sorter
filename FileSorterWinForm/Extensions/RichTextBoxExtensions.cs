using System;
using System.Windows.Forms;
using System.Drawing;

namespace FileSorterWinForm.Extensions
{
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox rtb, string text, Color color, bool isNewLine = false)
        {
            rtb.SuspendLayout();
            rtb.SelectionStart = rtb.TextLength;
            rtb.SelectionLength = 0;

            rtb.SelectionColor = color;
            rtb.AppendText(isNewLine ? $"{text}{ Environment.NewLine}" : text);
            rtb.SelectionColor = rtb.ForeColor;
            rtb.ScrollToCaret();
            rtb.ResumeLayout();
        }
    }
}
