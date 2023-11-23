namespace FileSorterWinForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourcePath_dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.sourcePath_button = new System.Windows.Forms.Button();
            this.sourcePath_textBox = new System.Windows.Forms.TextBox();
            this.sourcePath_label = new System.Windows.Forms.Label();
            this.destionationPath_label = new System.Windows.Forms.Label();
            this.destinationPath_textBox = new System.Windows.Forms.TextBox();
            this.destionationPath_button = new System.Windows.Forms.Button();
            this.fileType_comboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.destinationPath_dialog = new System.Windows.Forms.FolderBrowserDialog();
            this.result_richTextBox = new System.Windows.Forms.RichTextBox();
            this.runApp_button = new System.Windows.Forms.Button();
            this.sortingAction_comboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sourcePath_button
            // 
            this.sourcePath_button.Location = new System.Drawing.Point(951, 14);
            this.sourcePath_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sourcePath_button.Name = "sourcePath_button";
            this.sourcePath_button.Size = new System.Drawing.Size(100, 28);
            this.sourcePath_button.TabIndex = 0;
            this.sourcePath_button.Text = "...";
            this.sourcePath_button.UseVisualStyleBackColor = true;
            this.sourcePath_button.Click += new System.EventHandler(this.sourcePath_button_Click);
            // 
            // sourcePath_textBox
            // 
            this.sourcePath_textBox.Location = new System.Drawing.Point(192, 16);
            this.sourcePath_textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sourcePath_textBox.Name = "sourcePath_textBox";
            this.sourcePath_textBox.Size = new System.Drawing.Size(737, 22);
            this.sourcePath_textBox.TabIndex = 1;
            this.sourcePath_textBox.Leave += new System.EventHandler(this.sourcePath_textBox_Leave);
            // 
            // sourcePath_label
            // 
            this.sourcePath_label.AutoSize = true;
            this.sourcePath_label.Location = new System.Drawing.Point(16, 20);
            this.sourcePath_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.sourcePath_label.Name = "sourcePath_label";
            this.sourcePath_label.Size = new System.Drawing.Size(130, 16);
            this.sourcePath_label.TabIndex = 2;
            this.sourcePath_label.Text = "Indicate source path:";
            // 
            // destionationPath_label
            // 
            this.destionationPath_label.AutoSize = true;
            this.destionationPath_label.Location = new System.Drawing.Point(16, 70);
            this.destionationPath_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.destionationPath_label.Name = "destionationPath_label";
            this.destionationPath_label.Size = new System.Drawing.Size(154, 16);
            this.destionationPath_label.TabIndex = 5;
            this.destionationPath_label.Text = "Indicate destination path:";
            // 
            // destinationPath_textBox
            // 
            this.destinationPath_textBox.Location = new System.Drawing.Point(192, 66);
            this.destinationPath_textBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.destinationPath_textBox.Name = "destinationPath_textBox";
            this.destinationPath_textBox.Size = new System.Drawing.Size(737, 22);
            this.destinationPath_textBox.TabIndex = 4;
            // 
            // destionationPath_button
            // 
            this.destionationPath_button.Location = new System.Drawing.Point(951, 64);
            this.destionationPath_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.destionationPath_button.Name = "destionationPath_button";
            this.destionationPath_button.Size = new System.Drawing.Size(100, 28);
            this.destionationPath_button.TabIndex = 3;
            this.destionationPath_button.Text = "...";
            this.destionationPath_button.UseVisualStyleBackColor = true;
            this.destionationPath_button.Click += new System.EventHandler(this.destionationPath_button_Click);
            // 
            // fileType_comboBox
            // 
            this.fileType_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.fileType_comboBox.Enabled = false;
            this.fileType_comboBox.FormattingEnabled = true;
            this.fileType_comboBox.Location = new System.Drawing.Point(192, 117);
            this.fileType_comboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.fileType_comboBox.Name = "fileType_comboBox";
            this.fileType_comboBox.Size = new System.Drawing.Size(89, 24);
            this.fileType_comboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 121);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Indicate file type:";
            // 
            // result_richTextBox
            // 
            this.result_richTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.result_richTextBox.Location = new System.Drawing.Point(20, 156);
            this.result_richTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.result_richTextBox.Name = "result_richTextBox";
            this.result_richTextBox.ReadOnly = true;
            this.result_richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.result_richTextBox.Size = new System.Drawing.Size(1029, 382);
            this.result_richTextBox.TabIndex = 8;
            this.result_richTextBox.Text = "";
            // 
            // runApp_button
            // 
            this.runApp_button.Location = new System.Drawing.Point(951, 114);
            this.runApp_button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.runApp_button.Name = "runApp_button";
            this.runApp_button.Size = new System.Drawing.Size(100, 34);
            this.runApp_button.TabIndex = 9;
            this.runApp_button.Text = "Run";
            this.runApp_button.UseVisualStyleBackColor = true;
            this.runApp_button.Click += new System.EventHandler(this.runApp_button_Click);
            // 
            // sortingAction_comboBox
            // 
            this.sortingAction_comboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sortingAction_comboBox.FormattingEnabled = true;
            this.sortingAction_comboBox.Items.AddRange(new object[] {
            "Move",
            "Copy"});
            this.sortingAction_comboBox.Location = new System.Drawing.Point(421, 117);
            this.sortingAction_comboBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.sortingAction_comboBox.Name = "sortingAction_comboBox";
            this.sortingAction_comboBox.Size = new System.Drawing.Size(160, 24);
            this.sortingAction_comboBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(312, 121);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 16);
            this.label2.TabIndex = 11;
            this.label2.Text = "Sorting Action:";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(603, 114);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(328, 28);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Visible = false;
            // 
            // progressBar_label
            // 
            this.progressBar_label.AutoSize = true;
            this.progressBar_label.BackColor = System.Drawing.Color.Transparent;
            this.progressBar_label.Location = new System.Drawing.Point(759, 121);
            this.progressBar_label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.progressBar_label.Name = "progressBar_label";
            this.progressBar_label.Size = new System.Drawing.Size(0, 16);
            this.progressBar_label.TabIndex = 13;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 90);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 14;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.progressBar_label);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sortingAction_comboBox);
            this.Controls.Add(this.runApp_button);
            this.Controls.Add(this.result_richTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.fileType_comboBox);
            this.Controls.Add(this.destionationPath_label);
            this.Controls.Add(this.destinationPath_textBox);
            this.Controls.Add(this.destionationPath_button);
            this.Controls.Add(this.sourcePath_label);
            this.Controls.Add(this.sourcePath_textBox);
            this.Controls.Add(this.sourcePath_button);
            this.Controls.Add(this.progressBar1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "File Sorter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog sourcePath_dialog;
        private System.Windows.Forms.Button sourcePath_button;
        private System.Windows.Forms.TextBox sourcePath_textBox;
        private System.Windows.Forms.Label sourcePath_label;
        private System.Windows.Forms.Label destionationPath_label;
        private System.Windows.Forms.TextBox destinationPath_textBox;
        private System.Windows.Forms.Button destionationPath_button;
        private System.Windows.Forms.ComboBox fileType_comboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog destinationPath_dialog;
        private System.Windows.Forms.RichTextBox result_richTextBox;
        private System.Windows.Forms.Button runApp_button;
        private System.Windows.Forms.ComboBox sortingAction_comboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label progressBar_label;
        private System.Windows.Forms.Button button1;
    }
}

