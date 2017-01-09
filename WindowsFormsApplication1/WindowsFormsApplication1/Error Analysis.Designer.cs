namespace WindowsFormsApplication1
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
            this.textIMBMatchData = new System.Windows.Forms.TextBox();
            this.labelIMBAccurate = new System.Windows.Forms.Label();
            this.textIMBSequential = new System.Windows.Forms.TextBox();
            this.labelIMBSequential = new System.Windows.Forms.Label();
            this.textIMBSequenceEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textIMBSequenceStart = new System.Windows.Forms.TextBox();
            this.labelIMBSequenceStart = new System.Windows.Forms.Label();
            this.labelPanel3 = new System.Windows.Forms.Label();
            this.labelIMBNull = new System.Windows.Forms.Label();
            this.textIMBUnique = new System.Windows.Forms.TextBox();
            this.labelIMBDupe = new System.Windows.Forms.Label();
            this.labelIMBMax = new System.Windows.Forms.Label();
            this.labelIMBMin = new System.Windows.Forms.Label();
            this.textIMBMax = new System.Windows.Forms.TextBox();
            this.textIMBMin = new System.Windows.Forms.TextBox();
            this.labelLongName = new System.Windows.Forms.Label();
            this.textBadLongName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.labelDrop = new System.Windows.Forms.Label();
            this.textSplitCode = new System.Windows.Forms.TextBox();
            this.textDropCode = new System.Windows.Forms.TextBox();
            this.labelSequential = new System.Windows.Forms.Label();
            this.buttonViewAll = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelSpecialChars = new System.Windows.Forms.Label();
            this.textBadCharacters = new System.Windows.Forms.TextBox();
            this.labelFileType = new System.Windows.Forms.Label();
            this.textFileType = new System.Windows.Forms.TextBox();
            this.labelAmounts = new System.Windows.Forms.Label();
            this.textAmounts = new System.Windows.Forms.TextBox();
            this.labelStateMatch = new System.Windows.Forms.Label();
            this.textStateMatch = new System.Windows.Forms.TextBox();
            this.labelSalutationBlank = new System.Windows.Forms.Label();
            this.textSalutations = new System.Windows.Forms.TextBox();
            this.labelPanel4 = new System.Windows.Forms.Label();
            this.labelRecordNum = new System.Windows.Forms.Label();
            this.progressBarAnalyze = new System.Windows.Forms.ProgressBar();
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
            this.textFinderDupe.Location = new System.Drawing.Point(101, 26);
            this.textFinderDupe.Name = "textFinderDupe";
            this.textFinderDupe.Size = new System.Drawing.Size(68, 20);
            this.textFinderDupe.TabIndex = 5;
            this.textFinderDupe.Click += new System.EventHandler(this.textFinderDupe_Click);
            // 
            // textFinderLength
            // 
            this.textFinderLength.Location = new System.Drawing.Point(101, 57);
            this.textFinderLength.Name = "textFinderLength";
            this.textFinderLength.Size = new System.Drawing.Size(68, 20);
            this.textFinderLength.TabIndex = 6;
            this.textFinderLength.Click += new System.EventHandler(this.textFinderLength_Click);
            // 
            // textSequential
            // 
            this.textSequential.Location = new System.Drawing.Point(984, 6);
            this.textSequential.Name = "textSequential";
            this.textSequential.Size = new System.Drawing.Size(68, 20);
            this.textSequential.TabIndex = 14;
            // 
            // textIMBNull
            // 
            this.textIMBNull.Location = new System.Drawing.Point(84, 25);
            this.textIMBNull.Name = "textIMBNull";
            this.textIMBNull.Size = new System.Drawing.Size(68, 20);
            this.textIMBNull.TabIndex = 15;
            this.textIMBNull.Click += new System.EventHandler(this.textIMBNull_Click);
            // 
            // labelFinderDupe
            // 
            this.labelFinderDupe.AutoSize = true;
            this.labelFinderDupe.Location = new System.Drawing.Point(38, 29);
            this.labelFinderDupe.Name = "labelFinderDupe";
            this.labelFinderDupe.Size = new System.Drawing.Size(57, 13);
            this.labelFinderDupe.TabIndex = 16;
            this.labelFinderDupe.Text = "Duplicates";
            // 
            // labelFinderLength
            // 
            this.labelFinderLength.AutoSize = true;
            this.labelFinderLength.Location = new System.Drawing.Point(20, 60);
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
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelPanel1);
            this.panel1.Controls.Add(this.labelFinderLength);
            this.panel1.Controls.Add(this.labelFinderDupe);
            this.panel1.Controls.Add(this.textFinderLength);
            this.panel1.Controls.Add(this.textFinderDupe);
            this.panel1.Location = new System.Drawing.Point(1, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 153);
            this.panel1.TabIndex = 19;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.labelPanel2);
            this.panel2.Controls.Add(this.labelKeycodeLength);
            this.panel2.Controls.Add(this.labelKeycodeFormat);
            this.panel2.Controls.Add(this.textKeycodeLength);
            this.panel2.Controls.Add(this.textKeycodeFormat);
            this.panel2.Location = new System.Drawing.Point(189, 86);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(182, 153);
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
            this.labelKeycodeLength.Location = new System.Drawing.Point(21, 60);
            this.labelKeycodeLength.Name = "labelKeycodeLength";
            this.labelKeycodeLength.Size = new System.Drawing.Size(75, 13);
            this.labelKeycodeLength.TabIndex = 17;
            this.labelKeycodeLength.Text = "Wrong Length";
            // 
            // labelKeycodeFormat
            // 
            this.labelKeycodeFormat.AutoSize = true;
            this.labelKeycodeFormat.Location = new System.Drawing.Point(6, 29);
            this.labelKeycodeFormat.Name = "labelKeycodeFormat";
            this.labelKeycodeFormat.Size = new System.Drawing.Size(90, 13);
            this.labelKeycodeFormat.TabIndex = 16;
            this.labelKeycodeFormat.Text = "Wrong Drop/Split";
            // 
            // textKeycodeLength
            // 
            this.textKeycodeLength.Location = new System.Drawing.Point(102, 57);
            this.textKeycodeLength.Name = "textKeycodeLength";
            this.textKeycodeLength.Size = new System.Drawing.Size(68, 20);
            this.textKeycodeLength.TabIndex = 6;
            this.textKeycodeLength.Click += new System.EventHandler(this.textKeycodeLength_Click);
            // 
            // textKeycodeFormat
            // 
            this.textKeycodeFormat.Location = new System.Drawing.Point(102, 26);
            this.textKeycodeFormat.Name = "textKeycodeFormat";
            this.textKeycodeFormat.Size = new System.Drawing.Size(68, 20);
            this.textKeycodeFormat.TabIndex = 5;
            this.textKeycodeFormat.Click += new System.EventHandler(this.textKeycodeFormat_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textIMBMatchData);
            this.panel3.Controls.Add(this.labelIMBAccurate);
            this.panel3.Controls.Add(this.textIMBSequential);
            this.panel3.Controls.Add(this.labelIMBSequential);
            this.panel3.Controls.Add(this.textIMBSequenceEnd);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.textIMBSequenceStart);
            this.panel3.Controls.Add(this.labelIMBSequenceStart);
            this.panel3.Controls.Add(this.labelPanel3);
            this.panel3.Controls.Add(this.textIMBNull);
            this.panel3.Controls.Add(this.labelIMBNull);
            this.panel3.Controls.Add(this.textIMBUnique);
            this.panel3.Controls.Add(this.labelIMBDupe);
            this.panel3.Controls.Add(this.labelIMBMax);
            this.panel3.Controls.Add(this.labelIMBMin);
            this.panel3.Controls.Add(this.textIMBMax);
            this.panel3.Controls.Add(this.textIMBMin);
            this.panel3.Location = new System.Drawing.Point(377, 87);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(356, 152);
            this.panel3.TabIndex = 21;
            // 
            // textIMBMatchData
            // 
            this.textIMBMatchData.Location = new System.Drawing.Point(84, 120);
            this.textIMBMatchData.Name = "textIMBMatchData";
            this.textIMBMatchData.Size = new System.Drawing.Size(68, 20);
            this.textIMBMatchData.TabIndex = 36;
            this.textIMBMatchData.Click += new System.EventHandler(this.textIMBMatchData_Click);
            // 
            // labelIMBAccurate
            // 
            this.labelIMBAccurate.AutoSize = true;
            this.labelIMBAccurate.Location = new System.Drawing.Point(4, 123);
            this.labelIMBAccurate.Name = "labelIMBAccurate";
            this.labelIMBAccurate.Size = new System.Drawing.Size(76, 13);
            this.labelIMBAccurate.TabIndex = 37;
            this.labelIMBAccurate.Text = "Doesn\'t Match";
            // 
            // textIMBSequential
            // 
            this.textIMBSequential.Location = new System.Drawing.Point(84, 87);
            this.textIMBSequential.Name = "textIMBSequential";
            this.textIMBSequential.Size = new System.Drawing.Size(68, 20);
            this.textIMBSequential.TabIndex = 34;
            // 
            // labelIMBSequential
            // 
            this.labelIMBSequential.AutoSize = true;
            this.labelIMBSequential.Location = new System.Drawing.Point(21, 90);
            this.labelIMBSequential.Name = "labelIMBSequential";
            this.labelIMBSequential.Size = new System.Drawing.Size(57, 13);
            this.labelIMBSequential.TabIndex = 35;
            this.labelIMBSequential.Text = "Sequential";
            // 
            // textIMBSequenceEnd
            // 
            this.textIMBSequenceEnd.Location = new System.Drawing.Point(243, 120);
            this.textIMBSequenceEnd.Name = "textIMBSequenceEnd";
            this.textIMBSequenceEnd.Size = new System.Drawing.Size(68, 20);
            this.textIMBSequenceEnd.TabIndex = 33;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Sequence End";
            // 
            // textIMBSequenceStart
            // 
            this.textIMBSequenceStart.Location = new System.Drawing.Point(243, 87);
            this.textIMBSequenceStart.Name = "textIMBSequenceStart";
            this.textIMBSequenceStart.Size = new System.Drawing.Size(68, 20);
            this.textIMBSequenceStart.TabIndex = 31;
            // 
            // labelIMBSequenceStart
            // 
            this.labelIMBSequenceStart.AutoSize = true;
            this.labelIMBSequenceStart.Location = new System.Drawing.Point(156, 90);
            this.labelIMBSequenceStart.Name = "labelIMBSequenceStart";
            this.labelIMBSequenceStart.Size = new System.Drawing.Size(81, 13);
            this.labelIMBSequenceStart.TabIndex = 30;
            this.labelIMBSequenceStart.Text = "Sequence Start";
            // 
            // labelPanel3
            // 
            this.labelPanel3.AutoSize = true;
            this.labelPanel3.Location = new System.Drawing.Point(144, 3);
            this.labelPanel3.Name = "labelPanel3";
            this.labelPanel3.Size = new System.Drawing.Size(47, 13);
            this.labelPanel3.TabIndex = 18;
            this.labelPanel3.Text = "Barcode";
            // 
            // labelIMBNull
            // 
            this.labelIMBNull.AutoSize = true;
            this.labelIMBNull.Location = new System.Drawing.Point(22, 28);
            this.labelIMBNull.Name = "labelIMBNull";
            this.labelIMBNull.Size = new System.Drawing.Size(56, 13);
            this.labelIMBNull.TabIndex = 24;
            this.labelIMBNull.Text = "Blank IMB";
            // 
            // textIMBUnique
            // 
            this.textIMBUnique.Location = new System.Drawing.Point(84, 56);
            this.textIMBUnique.Name = "textIMBUnique";
            this.textIMBUnique.Size = new System.Drawing.Size(68, 20);
            this.textIMBUnique.TabIndex = 23;
            this.textIMBUnique.Click += new System.EventHandler(this.textIMBUnique_Click);
            // 
            // labelIMBDupe
            // 
            this.labelIMBDupe.AutoSize = true;
            this.labelIMBDupe.Location = new System.Drawing.Point(4, 59);
            this.labelIMBDupe.Name = "labelIMBDupe";
            this.labelIMBDupe.Size = new System.Drawing.Size(74, 13);
            this.labelIMBDupe.TabIndex = 25;
            this.labelIMBDupe.Text = "Duplicate IMB";
            // 
            // labelIMBMax
            // 
            this.labelIMBMax.AutoSize = true;
            this.labelIMBMax.Location = new System.Drawing.Point(164, 59);
            this.labelIMBMax.Name = "labelIMBMax";
            this.labelIMBMax.Size = new System.Drawing.Size(73, 13);
            this.labelIMBMax.TabIndex = 27;
            this.labelIMBMax.Text = "Maximum IMB";
            // 
            // labelIMBMin
            // 
            this.labelIMBMin.AutoSize = true;
            this.labelIMBMin.Location = new System.Drawing.Point(167, 28);
            this.labelIMBMin.Name = "labelIMBMin";
            this.labelIMBMin.Size = new System.Drawing.Size(70, 13);
            this.labelIMBMin.TabIndex = 26;
            this.labelIMBMin.Text = "Minimum IMB";
            // 
            // textIMBMax
            // 
            this.textIMBMax.Location = new System.Drawing.Point(243, 56);
            this.textIMBMax.Name = "textIMBMax";
            this.textIMBMax.Size = new System.Drawing.Size(68, 20);
            this.textIMBMax.TabIndex = 29;
            // 
            // textIMBMin
            // 
            this.textIMBMin.Location = new System.Drawing.Point(243, 25);
            this.textIMBMin.Name = "textIMBMin";
            this.textIMBMin.Size = new System.Drawing.Size(68, 20);
            this.textIMBMin.TabIndex = 28;
            // 
            // labelLongName
            // 
            this.labelLongName.AutoSize = true;
            this.labelLongName.Location = new System.Drawing.Point(3, 28);
            this.labelLongName.Name = "labelLongName";
            this.labelLongName.Size = new System.Drawing.Size(67, 13);
            this.labelLongName.TabIndex = 30;
            this.labelLongName.Text = "Long Names";
            // 
            // textBadLongName
            // 
            this.textBadLongName.Location = new System.Drawing.Point(76, 25);
            this.textBadLongName.Name = "textBadLongName";
            this.textBadLongName.Size = new System.Drawing.Size(68, 20);
            this.textBadLongName.TabIndex = 31;
            this.textBadLongName.Click += new System.EventHandler(this.textBadLongName_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(906, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Number Splits";
            // 
            // labelDrop
            // 
            this.labelDrop.AutoSize = true;
            this.labelDrop.Location = new System.Drawing.Point(903, 35);
            this.labelDrop.Name = "labelDrop";
            this.labelDrop.Size = new System.Drawing.Size(75, 13);
            this.labelDrop.TabIndex = 16;
            this.labelDrop.Text = "Number Drops";
            // 
            // textSplitCode
            // 
            this.textSplitCode.Location = new System.Drawing.Point(984, 58);
            this.textSplitCode.Name = "textSplitCode";
            this.textSplitCode.Size = new System.Drawing.Size(68, 20);
            this.textSplitCode.TabIndex = 6;
            // 
            // textDropCode
            // 
            this.textDropCode.Location = new System.Drawing.Point(984, 32);
            this.textDropCode.Name = "textDropCode";
            this.textDropCode.Size = new System.Drawing.Size(68, 20);
            this.textDropCode.TabIndex = 5;
            // 
            // labelSequential
            // 
            this.labelSequential.AutoSize = true;
            this.labelSequential.Location = new System.Drawing.Point(860, 9);
            this.labelSequential.Name = "labelSequential";
            this.labelSequential.Size = new System.Drawing.Size(118, 13);
            this.labelSequential.TabIndex = 22;
            this.labelSequential.Text = "Records are Sequential";
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
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.labelSpecialChars);
            this.panel4.Controls.Add(this.textBadCharacters);
            this.panel4.Controls.Add(this.labelFileType);
            this.panel4.Controls.Add(this.textFileType);
            this.panel4.Controls.Add(this.labelAmounts);
            this.panel4.Controls.Add(this.textAmounts);
            this.panel4.Controls.Add(this.labelStateMatch);
            this.panel4.Controls.Add(this.textStateMatch);
            this.panel4.Controls.Add(this.labelSalutationBlank);
            this.panel4.Controls.Add(this.textSalutations);
            this.panel4.Controls.Add(this.labelPanel4);
            this.panel4.Controls.Add(this.labelLongName);
            this.panel4.Controls.Add(this.textBadLongName);
            this.panel4.Location = new System.Drawing.Point(739, 87);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(318, 152);
            this.panel4.TabIndex = 26;
            // 
            // labelSpecialChars
            // 
            this.labelSpecialChars.AutoSize = true;
            this.labelSpecialChars.Location = new System.Drawing.Point(160, 92);
            this.labelSpecialChars.Name = "labelSpecialChars";
            this.labelSpecialChars.Size = new System.Drawing.Size(80, 13);
            this.labelSpecialChars.TabIndex = 44;
            this.labelSpecialChars.Text = "Bad Characters";
            // 
            // textBadCharacters
            // 
            this.textBadCharacters.Location = new System.Drawing.Point(245, 89);
            this.textBadCharacters.Name = "textBadCharacters";
            this.textBadCharacters.Size = new System.Drawing.Size(68, 20);
            this.textBadCharacters.TabIndex = 45;
            // 
            // labelFileType
            // 
            this.labelFileType.AutoSize = true;
            this.labelFileType.Location = new System.Drawing.Point(190, 59);
            this.labelFileType.Name = "labelFileType";
            this.labelFileType.Size = new System.Drawing.Size(50, 13);
            this.labelFileType.TabIndex = 42;
            this.labelFileType.Text = "File Type";
            // 
            // textFileType
            // 
            this.textFileType.Location = new System.Drawing.Point(245, 56);
            this.textFileType.Name = "textFileType";
            this.textFileType.Size = new System.Drawing.Size(68, 20);
            this.textFileType.TabIndex = 43;
            // 
            // labelAmounts
            // 
            this.labelAmounts.AutoSize = true;
            this.labelAmounts.Location = new System.Drawing.Point(190, 28);
            this.labelAmounts.Name = "labelAmounts";
            this.labelAmounts.Size = new System.Drawing.Size(48, 13);
            this.labelAmounts.TabIndex = 40;
            this.labelAmounts.Text = "Amounts";
            // 
            // textAmounts
            // 
            this.textAmounts.Location = new System.Drawing.Point(245, 25);
            this.textAmounts.Name = "textAmounts";
            this.textAmounts.Size = new System.Drawing.Size(68, 20);
            this.textAmounts.TabIndex = 41;
            // 
            // labelStateMatch
            // 
            this.labelStateMatch.AutoSize = true;
            this.labelStateMatch.Location = new System.Drawing.Point(3, 90);
            this.labelStateMatch.Name = "labelStateMatch";
            this.labelStateMatch.Size = new System.Drawing.Size(51, 13);
            this.labelStateMatch.TabIndex = 34;
            this.labelStateMatch.Text = "Full State";
            // 
            // textStateMatch
            // 
            this.textStateMatch.Location = new System.Drawing.Point(76, 87);
            this.textStateMatch.Name = "textStateMatch";
            this.textStateMatch.Size = new System.Drawing.Size(68, 20);
            this.textStateMatch.TabIndex = 35;
            // 
            // labelSalutationBlank
            // 
            this.labelSalutationBlank.AutoSize = true;
            this.labelSalutationBlank.Location = new System.Drawing.Point(3, 59);
            this.labelSalutationBlank.Name = "labelSalutationBlank";
            this.labelSalutationBlank.Size = new System.Drawing.Size(54, 13);
            this.labelSalutationBlank.TabIndex = 32;
            this.labelSalutationBlank.Text = "Salutation";
            // 
            // textSalutations
            // 
            this.textSalutations.Location = new System.Drawing.Point(76, 56);
            this.textSalutations.Name = "textSalutations";
            this.textSalutations.Size = new System.Drawing.Size(68, 20);
            this.textSalutations.TabIndex = 33;
            // 
            // labelPanel4
            // 
            this.labelPanel4.AutoSize = true;
            this.labelPanel4.Location = new System.Drawing.Point(130, 3);
            this.labelPanel4.Name = "labelPanel4";
            this.labelPanel4.Size = new System.Drawing.Size(56, 13);
            this.labelPanel4.TabIndex = 18;
            this.labelPanel4.Text = "Bad Fields";
            // 
            // labelRecordNum
            // 
            this.labelRecordNum.AutoSize = true;
            this.labelRecordNum.Location = new System.Drawing.Point(9, 242);
            this.labelRecordNum.Name = "labelRecordNum";
            this.labelRecordNum.Size = new System.Drawing.Size(59, 13);
            this.labelRecordNum.TabIndex = 34;
            this.labelRecordNum.Text = "Records: 0";
            // 
            // progressBarAnalyze
            // 
            this.progressBarAnalyze.Location = new System.Drawing.Point(333, 10);
            this.progressBarAnalyze.Name = "progressBarAnalyze";
            this.progressBarAnalyze.Size = new System.Drawing.Size(178, 23);
            this.progressBarAnalyze.TabIndex = 35;
            // 
            // ErrorAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1195, 639);
            this.Controls.Add(this.progressBarAnalyze);
            this.Controls.Add(this.labelRecordNum);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textSplitCode);
            this.Controls.Add(this.buttonViewAll);
            this.Controls.Add(this.labelDrop);
            this.Controls.Add(this.textDropCode);
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
        private System.Windows.Forms.TextBox textIMBMatchData;
        private System.Windows.Forms.Label labelIMBAccurate;
        private System.Windows.Forms.TextBox textIMBSequential;
        private System.Windows.Forms.Label labelIMBSequential;
        private System.Windows.Forms.TextBox textIMBSequenceEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIMBSequenceStart;
        private System.Windows.Forms.Label labelIMBSequenceStart;
        private System.Windows.Forms.ProgressBar progressBarAnalyze;
        private System.Windows.Forms.Label labelSpecialChars;
        private System.Windows.Forms.TextBox textBadCharacters;
        private System.Windows.Forms.Label labelFileType;
        private System.Windows.Forms.TextBox textFileType;
        private System.Windows.Forms.Label labelAmounts;
        private System.Windows.Forms.TextBox textAmounts;
        private System.Windows.Forms.Label labelStateMatch;
        private System.Windows.Forms.TextBox textStateMatch;
        private System.Windows.Forms.Label labelSalutationBlank;
        private System.Windows.Forms.TextBox textSalutations;
    }
}

