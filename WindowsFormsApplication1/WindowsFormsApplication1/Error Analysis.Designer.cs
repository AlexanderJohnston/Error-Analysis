﻿namespace WindowsFormsApplication1
{
    partial class ErrorAnalysis
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
            this.textFilePath = new System.Windows.Forms.TextBox();
            this.labelFilePath = new System.Windows.Forms.Label();
            this.buttonSelectFile = new System.Windows.Forms.Button();
            this.buttonAnalyze = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textFinderDupe = new System.Windows.Forms.TextBox();
            this.textFinderLength = new System.Windows.Forms.TextBox();
            this.textSequential = new System.Windows.Forms.TextBox();
            this.textIMBNull = new System.Windows.Forms.TextBox();
            this.labelFinderDupe = new System.Windows.Forms.Label();
            this.labelFinderLength = new System.Windows.Forms.Label();
            this.labelPanel1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.labelPanel2 = new System.Windows.Forms.Label();
            this.labelKeycodeLength = new System.Windows.Forms.Label();
            this.labelKeycodeFormat = new System.Windows.Forms.Label();
            this.textKeycodeLength = new System.Windows.Forms.TextBox();
            this.textKeycodeFormat = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelPanel3 = new System.Windows.Forms.Label();
            this.labelLongName = new System.Windows.Forms.Label();
            this.textBadLongName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDrop = new System.Windows.Forms.Label();
            this.textSplitCode = new System.Windows.Forms.TextBox();
            this.textDropCode = new System.Windows.Forms.TextBox();
            this.labelSequential = new System.Windows.Forms.Label();
            this.textIMBUnique = new System.Windows.Forms.TextBox();
            this.labelIMBNull = new System.Windows.Forms.Label();
            this.labelIMBDupe = new System.Windows.Forms.Label();
            this.labelIMBMin = new System.Windows.Forms.Label();
            this.labelIMBMax = new System.Windows.Forms.Label();
            this.textIMBMin = new System.Windows.Forms.TextBox();
            this.textIMBMax = new System.Windows.Forms.TextBox();
            this.buttonViewAll = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelPanel4 = new System.Windows.Forms.Label();
            this.labelRecordNum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // textFilePath
            // 
            this.textFilePath.Location = new System.Drawing.Point(12, 36);
            this.textFilePath.Name = "textFilePath";
            this.textFilePath.Size = new System.Drawing.Size(499, 20);
            this.textFilePath.TabIndex = 0;
            // 
            // labelFilePath
            // 
            this.labelFilePath.AutoSize = true;
            this.labelFilePath.Location = new System.Drawing.Point(12, 20);
            this.labelFilePath.Name = "labelFilePath";
            this.labelFilePath.Size = new System.Drawing.Size(49, 13);
            this.labelFilePath.TabIndex = 1;
            this.labelFilePath.Text = "Data File";
            // 
            // buttonSelectFile
            // 
            this.buttonSelectFile.Location = new System.Drawing.Point(333, 62);
            this.buttonSelectFile.Name = "buttonSelectFile";
            this.buttonSelectFile.Size = new System.Drawing.Size(86, 22);
            this.buttonSelectFile.TabIndex = 2;
            this.buttonSelectFile.Text = "Select File";
            this.buttonSelectFile.UseVisualStyleBackColor = true;
            this.buttonSelectFile.Click += new System.EventHandler(this.buttonSelectFile_Click);
            // 
            // buttonAnalyze
            // 
            this.buttonAnalyze.Location = new System.Drawing.Point(425, 62);
            this.buttonAnalyze.Name = "buttonAnalyze";
            this.buttonAnalyze.Size = new System.Drawing.Size(86, 22);
            this.buttonAnalyze.TabIndex = 3;
            this.buttonAnalyze.Text = "Analyze";
            this.buttonAnalyze.UseVisualStyleBackColor = true;
            this.buttonAnalyze.Click += new System.EventHandler(this.buttonAnalyze_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 260);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1171, 367);
            this.dataGridView1.TabIndex = 4;
            // 
            // textFinderDupe
            // 
            this.textFinderDupe.Location = new System.Drawing.Point(89, 39);
            this.textFinderDupe.Name = "textFinderDupe";
            this.textFinderDupe.Size = new System.Drawing.Size(68, 20);
            this.textFinderDupe.TabIndex = 5;
            this.textFinderDupe.Click += new System.EventHandler(this.textFinderDupe_Click);
            // 
            // textFinderLength
            // 
            this.textFinderLength.Location = new System.Drawing.Point(89, 70);
            this.textFinderLength.Name = "textFinderLength";
            this.textFinderLength.Size = new System.Drawing.Size(68, 20);
            this.textFinderLength.TabIndex = 6;
            this.textFinderLength.Click += new System.EventHandler(this.textFinderLength_Click);
            // 
            // textSequential
            // 
            this.textSequential.Location = new System.Drawing.Point(1005, 83);
            this.textSequential.Name = "textSequential";
            this.textSequential.Size = new System.Drawing.Size(68, 20);
            this.textSequential.TabIndex = 14;
            // 
            // textIMBNull
            // 
            this.textIMBNull.Location = new System.Drawing.Point(101, 38);
            this.textIMBNull.Name = "textIMBNull";
            this.textIMBNull.Size = new System.Drawing.Size(68, 20);
            this.textIMBNull.TabIndex = 15;
            this.textIMBNull.Click += new System.EventHandler(this.textIMBNull_Click);
            // 
            // labelFinderDupe
            // 
            this.labelFinderDupe.AutoSize = true;
            this.labelFinderDupe.Location = new System.Drawing.Point(26, 42);
            this.labelFinderDupe.Name = "labelFinderDupe";
            this.labelFinderDupe.Size = new System.Drawing.Size(57, 13);
            this.labelFinderDupe.TabIndex = 16;
            this.labelFinderDupe.Text = "Duplicates";
            // 
            // labelFinderLength
            // 
            this.labelFinderLength.AutoSize = true;
            this.labelFinderLength.Location = new System.Drawing.Point(8, 77);
            this.labelFinderLength.Name = "labelFinderLength";
            this.labelFinderLength.Size = new System.Drawing.Size(75, 13);
            this.labelFinderLength.TabIndex = 17;
            this.labelFinderLength.Text = "Wrong Length";
            // 
            // labelPanel1
            // 
            this.labelPanel1.AutoSize = true;
            this.labelPanel1.Location = new System.Drawing.Point(64, 4);
            this.labelPanel1.Name = "labelPanel1";
            this.labelPanel1.Size = new System.Drawing.Size(46, 13);
            this.labelPanel1.TabIndex = 18;
            this.labelPanel1.Text = "Finder #";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelPanel1);
            this.panel1.Controls.Add(this.labelFinderLength);
            this.panel1.Controls.Add(this.labelFinderDupe);
            this.panel1.Controls.Add(this.textFinderLength);
            this.panel1.Controls.Add(this.textFinderDupe);
            this.panel1.Location = new System.Drawing.Point(1, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 118);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.labelPanel2);
            this.panel2.Controls.Add(this.labelKeycodeLength);
            this.panel2.Controls.Add(this.labelKeycodeFormat);
            this.panel2.Controls.Add(this.textKeycodeLength);
            this.panel2.Controls.Add(this.textKeycodeFormat);
            this.panel2.Location = new System.Drawing.Point(189, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 118);
            this.panel2.TabIndex = 20;
            // 
            // labelPanel2
            // 
            this.labelPanel2.AutoSize = true;
            this.labelPanel2.Location = new System.Drawing.Point(58, 4);
            this.labelPanel2.Name = "labelPanel2";
            this.labelPanel2.Size = new System.Drawing.Size(49, 13);
            this.labelPanel2.TabIndex = 18;
            this.labelPanel2.Text = "Keycode";
            // 
            // labelKeycodeLength
            // 
            this.labelKeycodeLength.AutoSize = true;
            this.labelKeycodeLength.Location = new System.Drawing.Point(21, 73);
            this.labelKeycodeLength.Name = "labelKeycodeLength";
            this.labelKeycodeLength.Size = new System.Drawing.Size(75, 13);
            this.labelKeycodeLength.TabIndex = 17;
            this.labelKeycodeLength.Text = "Wrong Length";
            // 
            // labelKeycodeFormat
            // 
            this.labelKeycodeFormat.AutoSize = true;
            this.labelKeycodeFormat.Location = new System.Drawing.Point(6, 42);
            this.labelKeycodeFormat.Name = "labelKeycodeFormat";
            this.labelKeycodeFormat.Size = new System.Drawing.Size(90, 13);
            this.labelKeycodeFormat.TabIndex = 16;
            this.labelKeycodeFormat.Text = "Wrong Drop/Split";
            // 
            // textKeycodeLength
            // 
            this.textKeycodeLength.Location = new System.Drawing.Point(102, 70);
            this.textKeycodeLength.Name = "textKeycodeLength";
            this.textKeycodeLength.Size = new System.Drawing.Size(68, 20);
            this.textKeycodeLength.TabIndex = 6;
            this.textKeycodeLength.Click += new System.EventHandler(this.textKeycodeLength_Click);
            // 
            // textKeycodeFormat
            // 
            this.textKeycodeFormat.Location = new System.Drawing.Point(102, 39);
            this.textKeycodeFormat.Name = "textKeycodeFormat";
            this.textKeycodeFormat.Size = new System.Drawing.Size(68, 20);
            this.textKeycodeFormat.TabIndex = 5;
            this.textKeycodeFormat.Click += new System.EventHandler(this.textKeycodeFormat_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.labelPanel3);
            this.panel3.Controls.Add(this.textIMBNull);
            this.panel3.Controls.Add(this.labelIMBNull);
            this.panel3.Controls.Add(this.textIMBUnique);
            this.panel3.Controls.Add(this.labelIMBDupe);
            this.panel3.Location = new System.Drawing.Point(377, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(182, 118);
            this.panel3.TabIndex = 21;
            // 
            // labelPanel3
            // 
            this.labelPanel3.AutoSize = true;
            this.labelPanel3.Location = new System.Drawing.Point(67, 3);
            this.labelPanel3.Name = "labelPanel3";
            this.labelPanel3.Size = new System.Drawing.Size(47, 13);
            this.labelPanel3.TabIndex = 18;
            this.labelPanel3.Text = "Barcode";
            // 
            // labelLongName
            // 
            this.labelLongName.AutoSize = true;
            this.labelLongName.Location = new System.Drawing.Point(3, 42);
            this.labelLongName.Name = "labelLongName";
            this.labelLongName.Size = new System.Drawing.Size(67, 13);
            this.labelLongName.TabIndex = 30;
            this.labelLongName.Text = "Long Names";
            // 
            // textBadLongName
            // 
            this.textBadLongName.Location = new System.Drawing.Point(76, 39);
            this.textBadLongName.Name = "textBadLongName";
            this.textBadLongName.Size = new System.Drawing.Size(68, 20);
            this.textBadLongName.TabIndex = 31;
            this.textBadLongName.Click += new System.EventHandler(this.textBadLongName_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(927, 138);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Number Splits";
            // 
            // labelDrop
            // 
            this.labelDrop.AutoSize = true;
            this.labelDrop.Location = new System.Drawing.Point(924, 112);
            this.labelDrop.Name = "labelDrop";
            this.labelDrop.Size = new System.Drawing.Size(75, 13);
            this.labelDrop.TabIndex = 16;
            this.labelDrop.Text = "Number Drops";
            // 
            // textSplitCode
            // 
            this.textSplitCode.Location = new System.Drawing.Point(1005, 135);
            this.textSplitCode.Name = "textSplitCode";
            this.textSplitCode.Size = new System.Drawing.Size(68, 20);
            this.textSplitCode.TabIndex = 6;
            // 
            // textDropCode
            // 
            this.textDropCode.Location = new System.Drawing.Point(1005, 109);
            this.textDropCode.Name = "textDropCode";
            this.textDropCode.Size = new System.Drawing.Size(68, 20);
            this.textDropCode.TabIndex = 5;
            // 
            // labelSequential
            // 
            this.labelSequential.AutoSize = true;
            this.labelSequential.Location = new System.Drawing.Point(942, 86);
            this.labelSequential.Name = "labelSequential";
            this.labelSequential.Size = new System.Drawing.Size(57, 13);
            this.labelSequential.TabIndex = 22;
            this.labelSequential.Text = "Sequential";
            // 
            // textIMBUnique
            // 
            this.textIMBUnique.Location = new System.Drawing.Point(101, 69);
            this.textIMBUnique.Name = "textIMBUnique";
            this.textIMBUnique.Size = new System.Drawing.Size(68, 20);
            this.textIMBUnique.TabIndex = 23;
            this.textIMBUnique.Click += new System.EventHandler(this.textIMBUnique_Click);
            // 
            // labelIMBNull
            // 
            this.labelIMBNull.AutoSize = true;
            this.labelIMBNull.Location = new System.Drawing.Point(39, 41);
            this.labelIMBNull.Name = "labelIMBNull";
            this.labelIMBNull.Size = new System.Drawing.Size(56, 13);
            this.labelIMBNull.TabIndex = 24;
            this.labelIMBNull.Text = "Blank IMB";
            // 
            // labelIMBDupe
            // 
            this.labelIMBDupe.AutoSize = true;
            this.labelIMBDupe.Location = new System.Drawing.Point(21, 72);
            this.labelIMBDupe.Name = "labelIMBDupe";
            this.labelIMBDupe.Size = new System.Drawing.Size(74, 13);
            this.labelIMBDupe.TabIndex = 25;
            this.labelIMBDupe.Text = "Duplicate IMB";
            // 
            // labelIMBMin
            // 
            this.labelIMBMin.AutoSize = true;
            this.labelIMBMin.Location = new System.Drawing.Point(929, 168);
            this.labelIMBMin.Name = "labelIMBMin";
            this.labelIMBMin.Size = new System.Drawing.Size(70, 13);
            this.labelIMBMin.TabIndex = 26;
            this.labelIMBMin.Text = "Minimum IMB";
            // 
            // labelIMBMax
            // 
            this.labelIMBMax.AutoSize = true;
            this.labelIMBMax.Location = new System.Drawing.Point(926, 194);
            this.labelIMBMax.Name = "labelIMBMax";
            this.labelIMBMax.Size = new System.Drawing.Size(73, 13);
            this.labelIMBMax.TabIndex = 27;
            this.labelIMBMax.Text = "Maximum IMB";
            // 
            // textIMBMin
            // 
            this.textIMBMin.Location = new System.Drawing.Point(1005, 161);
            this.textIMBMin.Name = "textIMBMin";
            this.textIMBMin.Size = new System.Drawing.Size(68, 20);
            this.textIMBMin.TabIndex = 28;
            // 
            // textIMBMax
            // 
            this.textIMBMax.Location = new System.Drawing.Point(1005, 187);
            this.textIMBMax.Name = "textIMBMax";
            this.textIMBMax.Size = new System.Drawing.Size(68, 20);
            this.textIMBMax.TabIndex = 29;
            // 
            // buttonViewAll
            // 
            this.buttonViewAll.Location = new System.Drawing.Point(219, 62);
            this.buttonViewAll.Name = "buttonViewAll";
            this.buttonViewAll.Size = new System.Drawing.Size(108, 22);
            this.buttonViewAll.TabIndex = 33;
            this.buttonViewAll.Text = "View All Records";
            this.buttonViewAll.UseVisualStyleBackColor = true;
            this.buttonViewAll.Click += new System.EventHandler(this.buttonViewAll_Click);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelPanel4);
            this.panel4.Controls.Add(this.labelLongName);
            this.panel4.Controls.Add(this.textBadLongName);
            this.panel4.Location = new System.Drawing.Point(565, 86);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(318, 118);
            this.panel4.TabIndex = 26;
            // 
            // labelPanel4
            // 
            this.labelPanel4.AutoSize = true;
            this.labelPanel4.Location = new System.Drawing.Point(132, 4);
            this.labelPanel4.Name = "labelPanel4";
            this.labelPanel4.Size = new System.Drawing.Size(40, 13);
            this.labelPanel4.TabIndex = 18;
            this.labelPanel4.Text = "Names";
            // 
            // labelRecordNum
            // 
            this.labelRecordNum.AutoSize = true;
            this.labelRecordNum.Location = new System.Drawing.Point(15, 236);
            this.labelRecordNum.Name = "labelRecordNum";
            this.labelRecordNum.Size = new System.Drawing.Size(59, 13);
            this.labelRecordNum.TabIndex = 34;
            this.labelRecordNum.Text = "Records: 0";
            // 
            // ErrorAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 639);
            this.Controls.Add(this.labelRecordNum);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textSplitCode);
            this.Controls.Add(this.buttonViewAll);
            this.Controls.Add(this.labelDrop);
            this.Controls.Add(this.textDropCode);
            this.Controls.Add(this.textIMBMax);
            this.Controls.Add(this.textIMBMin);
            this.Controls.Add(this.labelIMBMax);
            this.Controls.Add(this.labelIMBMin);
            this.Controls.Add(this.labelSequential);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textSequential);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.buttonAnalyze);
            this.Controls.Add(this.buttonSelectFile);
            this.Controls.Add(this.labelFilePath);
            this.Controls.Add(this.textFilePath);
            this.KeyPreview = true;
            this.Name = "ErrorAnalysis";
            this.Text = "Error Analysis";
            this.Load += new System.EventHandler(this.ErrorAnalysis_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textFilePath;
        private System.Windows.Forms.Label labelFilePath;
        private System.Windows.Forms.Button buttonSelectFile;
        private System.Windows.Forms.Button buttonAnalyze;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textFinderDupe;
        private System.Windows.Forms.TextBox textFinderLength;
        private System.Windows.Forms.TextBox textSequential;
        private System.Windows.Forms.TextBox textIMBNull;
        private System.Windows.Forms.Label labelFinderDupe;
        private System.Windows.Forms.Label labelFinderLength;
        private System.Windows.Forms.Label labelPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label labelPanel2;
        private System.Windows.Forms.Label labelKeycodeLength;
        private System.Windows.Forms.Label labelKeycodeFormat;
        private System.Windows.Forms.TextBox textKeycodeLength;
        private System.Windows.Forms.TextBox textKeycodeFormat;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelPanel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelDrop;
        private System.Windows.Forms.TextBox textSplitCode;
        private System.Windows.Forms.TextBox textDropCode;
        private System.Windows.Forms.Label labelSequential;
        private System.Windows.Forms.TextBox textIMBUnique;
        private System.Windows.Forms.Label labelIMBNull;
        private System.Windows.Forms.Label labelIMBDupe;
        private System.Windows.Forms.Label labelIMBMin;
        private System.Windows.Forms.Label labelIMBMax;
        private System.Windows.Forms.TextBox textIMBMin;
        private System.Windows.Forms.TextBox textIMBMax;
        private System.Windows.Forms.Label labelLongName;
        private System.Windows.Forms.TextBox textBadLongName;
        private System.Windows.Forms.Button buttonViewAll;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label labelPanel4;
        private System.Windows.Forms.Label labelRecordNum;
    }
}

