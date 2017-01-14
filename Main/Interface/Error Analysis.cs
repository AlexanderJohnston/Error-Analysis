using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using FileHelpers;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace WindowsFormsApplication1
{

    public partial class ErrorAnalysis : Form
    {
        // This is a DataTable object to store the full file once it has been parsed. Methods will filter it on demand, not destructively.
        public static DataTable globalTable = new DataTable();

        // Entry(), Main().
        public ErrorAnalysis()
        {
            InitializeComponent();
            dataGridView1.DoubleBuffered(true);

            // Jump to buttonAnalyze_Click for the next step.

        }

        /// <summary>
        /// An entry point which accepts a file path to begin checking for common errors.
        /// </summary>
        public DataTable EntryPoint(string selectedFile)
        {
            // Build a data table to store our incoming file using the 1500 schema which is defined in the method.
            progressBarAnalyze.Value++;
            DataTable table1500Layout = ErrorChecking.ConstructTable1500(selectedFile);

            // Drop out if the table couldn't be constructed properly, due to header mis-match.
            if (table1500Layout.Rows.Count == 0) { return table1500Layout; }

            // Begin Error Analysis
            int badFinder = ErrorChecking.CheckFinder(table1500Layout);
            textFinderLength.Text = badFinder.ToString();
            progressBarAnalyze.Value++;

            int badDuplicates = ErrorChecking.CheckDuplicates(table1500Layout);
            textFinderDupe.Text = badDuplicates.ToString();
            progressBarAnalyze.Value++;

            int badKeycodeLength = ErrorChecking.CheckKeycodeLength(table1500Layout);
            textKeycodeLength.Text = badKeycodeLength.ToString();
            progressBarAnalyze.Value++;

            int badKeycodeFormat = ErrorChecking.CheckKeycodeDropSplit(table1500Layout);
            textKeycodeFormat.Text = badKeycodeFormat.ToString();
            progressBarAnalyze.Value++;

            int countDropCode = ErrorChecking.CheckDropCode(table1500Layout);
            textDropCode.Text = countDropCode.ToString();
            progressBarAnalyze.Value++;

            int countSplitCode = ErrorChecking.CheckSplitCode(table1500Layout);
            textSplitCode.Text = countSplitCode.ToString();
            progressBarAnalyze.Value++;

            bool checkSequential = ErrorChecking.CheckSequenceOrder(table1500Layout);
            textSequential.Text = checkSequential.ToString();
            progressBarAnalyze.Value++;

            // Check to see if there are blank IMBs.
            bool checkIMBNull = ErrorChecking.CheckIMBExists(table1500Layout);
            // Check to see if any IMBs exist at all in proper format.
            var existsEvenOneIMB = table1500Layout.AsEnumerable().Where(r => r.Field<string>("IMB").Length == 31);
            // Report the situation.
            if (existsEvenOneIMB.Count() > 0) { textIMBNull.Text = checkIMBNull.ToString(); }
            else { textIMBNull.Text = "All"; } 
            progressBarAnalyze.Value++;

            bool checkIMBUnique = ErrorChecking.CheckIMBUnique(table1500Layout);
            textIMBUnique.Text = checkIMBUnique.ToString();
            progressBarAnalyze.Value++;

            int checkIMBMin = ErrorChecking.CheckIMBMinLength(table1500Layout);
            textIMBMin.Text = checkIMBMin.ToString();
            progressBarAnalyze.Value++;

            int checkIMBMax = ErrorChecking.CheckIMBMaxLength(table1500Layout);
            textIMBMax.Text = checkIMBMax.ToString();
            progressBarAnalyze.Value++;

            int checkLongNameMatches = ErrorChecking.CheckLongName(table1500Layout);
            textBadLongName.Text = checkLongNameMatches.ToString();
            progressBarAnalyze.Value++;

            string checkIMBSeqStart = ErrorChecking.CheckIMBSequenceMinimum(table1500Layout);
            textIMBSequenceStart.Text = checkIMBSeqStart.ToString();
            progressBarAnalyze.Value++;

            string checkIMBSeqEnd = ErrorChecking.CheckIMBSequenceMaximum(table1500Layout);
            textIMBSequenceEnd.Text = checkIMBSeqEnd.ToString();
            progressBarAnalyze.Value++;

            bool checkIMBSequential = ErrorChecking.CheckIMBSequential(table1500Layout);
            textIMBSequential.Text = checkIMBSequential.ToString();
            progressBarAnalyze.Value++;

            int checkIMBMatches = ErrorChecking.CheckIMBMatchesData(table1500Layout);
            textIMBMatchData.Text = checkIMBMatches.ToString();
            progressBarAnalyze.Value++;

            int checkSalutationBlanks = ErrorChecking.CheckSalutations(table1500Layout);
            textSalutations.Text = checkSalutationBlanks.ToString();
            progressBarAnalyze.Value++;

            int checkFullState = ErrorChecking.CheckFullState(table1500Layout);
            textStateMatch.Text = checkFullState.ToString();
            progressBarAnalyze.Value++;

            int checkAmountsMatch = ErrorChecking.CheckAmountsNotMatch(table1500Layout);
            textAmounts.Text = checkAmountsMatch.ToString();
            progressBarAnalyze.Value++;

            int checkBlankFileType = ErrorChecking.CheckFileType(table1500Layout);
            textFileType.Text = checkBlankFileType.ToString();
            progressBarAnalyze.Value++;

            int checkBadChars = ErrorChecking.CheckBadCharacters(table1500Layout);
            textBadCharacters.Text = checkBadChars.ToString();
            progressBarAnalyze.Value++;

            // Display the table.
            return table1500Layout;

            // End Method.
        }

        /// <summary>
        /// Calls for a file selection dialog and sets the information to a textbox.
        /// </summary>
        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            // Call a new string to SelectFile's return.
            string selectedFile = FileManagement.SelectFile();

            // Set the value of a textbox to the file path.
            textFilePath.Text = selectedFile;
            // End Method.
        }

        /// <summary>
        /// Calls for a file selection dialog and sets the information to a textbox.
        /// </summary>
        private void buttonAnalyze_Click(object sender, EventArgs e)
        {
            // Begin error analysis by passing a file path as string.
            string selectedFile = textFilePath.Text.ToString();
            if (File.Exists(selectedFile) == true)
            {
                // Initialize table.
                DataTable currentDataTable = new DataTable();

                // Move on to the next major step.
                progressBarAnalyze.Maximum = 23; progressBarAnalyze.Value = 0;
                currentDataTable = EntryPoint(selectedFile);

                // Drop out if the table came back null.
                if (currentDataTable.Rows.Count == 0) { MessageBox.Show("The header on your table is not Engage 1500 Layout.", "Header Mis-match!"); return; }

                // Save our global table.
                globalTable = currentDataTable;
                progressBarAnalyze.Value++;

                //Display the table.
                dataGridView1.DataSource = currentDataTable;
                progressBarAnalyze.Value = 0;

                // Set the record number label.
                labelRecordNum.Text = "Records: " + currentDataTable.Rows.Count; 
            }
            else
            {
                MessageBox.Show("Your selected file does not exist.", "File Error");
            }



            // End Method.
        }

        /// <summary>
        /// Watches for keystrokes to use hotkeys.
        /// </summary>
        protected override bool ProcessCmdKey(ref Message message, Keys keys)
        {
            switch (keys)
            {
                case Keys.Control | Keys.S:
                    {
                        buttonSelectFile.PerformClick();
                        return true;
                    }
                case Keys.Control | Keys.A:
                    {
                        buttonAnalyze.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref message, keys);
        }

        private void ErrorAnalysis_Load(object sender, EventArgs e)
        {

        }

        private void buttonViewAll_Click(object sender, EventArgs e)
        {
            // Set the gridview back to the global table.
            dataGridView1.DataSource = globalTable;
        }
        //
        // Begin the display box on_click codes.
        //
        private void textBadLongName_Click(object sender, EventArgs e)
        {
            // Check that there are errors to be displayed before proceeding.
            if (textBadLongName.Text.ToString() != "0" && textBadLongName.Text.ToString() != null)
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Send the data table. Store index in return as a list.
                List<int> foundRecords = new List<int>();
                foundRecords = ErrorChecking.DetailsLongName(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(index))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textFinderDupe_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textFinderDupe.Text.ToString() != "0" && textFinderDupe.Text.ToString() != null)
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.
                // Send the number of duplicate IDs as integer, and the data table. Store it as a list.
                List<string> foundRecords = new List<string>();
                foundRecords = ErrorChecking.DetailsDuplicates(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(row.Field<string>("Finder_No")))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textFinderLength_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textFinderLength.Text.ToString() != "0" && textFinderLength.Text.ToString() != null)
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Send the data table. Store index in return as a list.
                List<int> foundRecords = new List<int>();
                foundRecords = ErrorChecking.DetailsIDLength(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(index))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }

        }

        private void textKeycodeFormat_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textKeycodeFormat.Text.ToString() != "0" && textKeycodeFormat.Text.ToString() != null)
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Send the data table. Store index in return as a list.
                List<int> foundRecords = new List<int>();
                foundRecords = ErrorChecking.DetailsKeycodeFormat(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(index))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textKeycodeLength_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textKeycodeLength.Text.ToString() != "0" && textKeycodeLength.Text.ToString() != null)
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Send the data table. Store index in return as a list.
                List<int> foundRecords = new List<int>();
                foundRecords = ErrorChecking.DetailsKeycodeLength(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(index))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textIMBNull_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textIMBNull.Text.ToString() != "False" && textIMBNull.Text.ToString() != null)
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Check if it's the whole file, to save time.
                var checkNullExists = globalTable.Rows.OfType<DataRow>()
                .Where(r => r.Field<string>("IMB").ToString() == "");
                // If whole file, inform user.
                if (checkNullExists.Count() == Convert.ToInt32(labelRecordNum.Text.Substring(9, labelRecordNum.Text.ToString().Length - 9)))
                {
                    MessageBox.Show("The entire file is missing barcodes. No filter has been applied.", "No Change");
                }
                else
                {
                    // Send the data table. Store index in return as a list.
                    List<int> foundRecords = new List<int>();
                    foundRecords = ErrorChecking.DetailsIMBNull(dataGridView1.DataSource as DataTable);

                    // Iterate over the data table to hide rows that do not appear in the list.
                    var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                        .Where((row, index) => foundRecords.Contains(index))
                        .CopyToDataTable();

                    // Make a new dataview based on the query. Set the datasource to the new view.
                    DataView filterView = filterQuery.AsDataView();
                    dataGridView1.DataSource = filterView;
                }
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textIMBUnique_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textIMBUnique.Text.ToString() != "False" && textIMBUnique.Text.ToString() != null)
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Send the data table. Store index in return as a list.
                List<string> foundRecords = new List<string>();
                foundRecords = ErrorChecking.DetailsIMBDuplicate(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(row.Field<string>("IMB")))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textIMBMatchData_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textIMBMatchData.Text.ToString() != "False" && textIMBMatchData.Text.ToString() != "0")
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Send the data table. Store index in return as a list.
                List<int> foundRecords = new List<int>();
                foundRecords = ErrorChecking.DetailsIMBMatching(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(index))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textAmounts_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textAmounts.Text.ToString() != "False" && textAmounts.Text.ToString() != "0")
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Send the data table. Store index in return as a list.
                List<int> foundRecords = new List<int>();
                foundRecords = ErrorChecking.DetailsAmounts(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(index))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textStateMatch_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textStateMatch.Text.ToString() != "False" && textStateMatch.Text.ToString() != "0")
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Send the data table. Store index in return as a list.
                List<int> foundRecords = new List<int>();
                foundRecords = ErrorChecking.DetailsFullState(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(index))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;
            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textBadCharacters_Click(object sender, EventArgs e)
        {
            // Check that an error was found before proceeding.
            if (textBadCharacters.Text.ToString() != "False" && textBadCharacters.Text.ToString() != "0")
            {
                // Check the data source before proceeding.
                if (dataGridView1.DataSource != globalTable) { buttonViewAll.PerformClick(); } // Load the global table.

                // Send the data table. Store index in return as a list.
                List<int> foundRecords = new List<int>();
                foundRecords = ErrorChecking.DetailsBadChars(dataGridView1.DataSource as DataTable);

                // Iterate over the data table to hide rows that do not appear in the list.
                var filterQuery = (dataGridView1.DataSource as DataTable).AsEnumerable()
                    .Where((row, index) => foundRecords.Contains(index))
                    .CopyToDataTable();

                // Make a new dataview based on the query. Set the datasource to the new view.
                DataView filterView = filterQuery.AsDataView();
                dataGridView1.DataSource = filterView;

                // Iterate over the data table to hide rows that do not appear in the list.
                DataTable filteredTable = filterView.ToTable();

                // List of bad chars.
                /*Char[] badCharList = new Char[] { ',', '\t', '\v', '\r', '\n' , '"' };

                foreach (DataColumn col in filteredTable.Columns)
                {
                    if (col.DataType == typeof(string))
                    {
                        foreach (DataRow row in filteredTable.Rows)
                        {
                            bool match = false;
                            if (row.Field<string>(col) != null) { match = row.Field<string>(col).ToString().IndexOfAny(badCharList) != -1; }
                            if (match == true)
                            {
                                filterQuery.Rows[row.]
                            }
                        }
                    }
                }*/

                // Make a new dataview based on the query. Set the datasource to the new view.
                //DataView highlightView = highlightQuery.AsDataView();
                //dataGridView1.DataSource = filterView;

            }
            else
            {
                MessageBox.Show("You must analyze the file first, and more than 0 errors must be displayed.", "Not Enough Errors!");
            }
        }

        private void textSalutations_Click(object sender, EventArgs e)
        {

        }

        // End Class.
    }


    /// <summary>
    /// This class will handle all data analysis functions.
    /// </summary>
    public class ErrorChecking
    {

        /// <summary>
        /// Construct a new data table with the 1500 byte Engage layout.
        /// </summary>
        public static DataTable ConstructTable1500(string selectedFile)
        {
            // Define a string for testing the header.
            string firstLine = null;
            // Define a temporary table for later.
            DataTable newTable1500Import = new DataTable();
            // Define the columns in 1500 byte layout for Engage.
            DataColumn[] newCols ={
                new DataColumn("Seq", typeof(int)),
                new DataColumn("Title", typeof(String)),
                new DataColumn("First_Name", typeof(String)),
                new DataColumn("Middle_Name", typeof(String)),
                new DataColumn("Last_Name", typeof(String)),
                new DataColumn("Suffix", typeof(String)),
                new DataColumn("Long_Name", typeof(String)),
                new DataColumn("Drop", typeof(String)),
                new DataColumn("Split", typeof(String)),
                new DataColumn("House_(H)/Prospect_(P)", typeof(String)),
                new DataColumn("Ref#", typeof(String)),
                new DataColumn("DPC", typeof(String)),
                new DataColumn("Dear_Sal", typeof(String)),
                new DataColumn("Salutation2", typeof(String)),
                new DataColumn("Salutation3", typeof(String)),
                new DataColumn("Company", typeof(String)),
                new DataColumn("Secondary_Addr", typeof(String)),
                new DataColumn("Primary_Addr", typeof(String)),
                new DataColumn("City", typeof(String)),
                new DataColumn("ST", typeof(String)),
                new DataColumn("Zip", typeof(String)),
                new DataColumn(" - ", typeof(String)),
                new DataColumn("Zip4", typeof(String)),
                new DataColumn("MRG_Date", typeof(String)),
                new DataColumn("MRG_Amount", typeof(String)),
                new DataColumn("MRG_Month", typeof(String)),
                new DataColumn("HPC_Date", typeof(String)),
                new DataColumn("HPC_Amount", typeof(String)),
                new DataColumn("First_Date", typeof(String)),
                new DataColumn("First_Year", typeof(String)),
                new DataColumn("Amt_1", typeof(String)),
                new DataColumn("Amt_2", typeof(String)),
                new DataColumn("Amt_3", typeof(String)),
                new DataColumn("Amt_4", typeof(String)),
                new DataColumn("Amt_5", typeof(String)),
                new DataColumn("Amount", typeof(String)),
                new DataColumn("OEL", typeof(String)),
                new DataColumn("Keycode", typeof(String)),
                new DataColumn("Finder_No", typeof(String)),
                new DataColumn("Dist", typeof(String)),
                new DataColumn("Congressmen", typeof(String)),
                new DataColumn("Senator_1", typeof(String)),
                new DataColumn("Senator_2", typeof(String)),
                new DataColumn("County", typeof(String)),
                new DataColumn("Governor", typeof(String)),
                new DataColumn("Full_State", typeof(String)),
                new DataColumn("IMB", typeof(String)),
                new DataColumn("File_Type", typeof(String)),
                new DataColumn("Priority", typeof(String)),
                new DataColumn("FILENAME", typeof(String)),
                new DataColumn("Engage_Use", typeof(String)),
                new DataColumn("Client1", typeof(String)),
                new DataColumn("Client2", typeof(String)),
                new DataColumn("Client3",typeof(String)),
                new DataColumn("Client4",typeof(String)),
                new DataColumn("DPV_Error",typeof(String)),
                new DataColumn("NCOA_Mflag",typeof(String)),
                new DataColumn("NCOA_FN",typeof(String))
                };
            // Define the new data table.
            DataTable newTable1500 = new DataTable("1500 Layout Analysis");
            newTable1500.Columns.AddRange(newCols);

            // Check that the data file is in 1500 layout.
            try
            {
                using (StreamReader reader = new StreamReader(selectedFile))
                {
                    firstLine = reader.ReadLine() ?? "";
                }

            }
            catch (Exception ex) { MessageBox.Show("File header could not be read.\r\n" + ex, "Header Error!"); }
            
            if (firstLine != @"""Seq"",""Title"",""First Name"",""Middle Name"",""Last Name"",""Suffix"",""Long Name"",""Drop"",""Split"",""House (H)/Prospect (P)"",""Ref#"",""DPC"",""Dear Sal"",""Salutation2"",""Salutation3"",""Company"",""Secondary Addr"",""Primary Addr"",""City"",""ST"",""Zip"",""Dash"",""Zip4"",""MRG Date"",""MRG Amount"",""MRG Month"",""HPC Date"",""HPC Amount"",""First Date"",""First Year"",""Amt 1"",""Amt 2"",""Amt 3"",""Amt 4"",""Amt 5"",""Amount"",""OEL"",""Keycode"",""Finder No"",""Dist"",""Congressmen"",""Senator 1"",""Senator 2"",""County"",""Governor"",""Full State"",""IMB"",""File Type"",""Priority"",""FILENAME"",""Engage Use"",""Client1"",""Client2"",""Client3"",""Client4"",""DPV Error"",""NCOA Mflag"",""NCOA FN""")
            {
                DataTable failedTable = new DataTable();
                return failedTable;
            }
            // Import the data.
            try
            {
                newTable1500Import = CommonEngine.CsvToDataTable(selectedFile, "ImportRecord", ',', true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Your file might be in use by another program.\r\n" + ex, "Read File Error!");
            }

            // Change the table's column types.

            try
            {
                foreach (DataRow row in newTable1500Import.Rows)
                {
                    newTable1500.ImportRow(row);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to populate data table correctly.\r\n" + ex, "Import Rows Error!");
            }

            return newTable1500;
            // End Method.
        }

        public static int CheckFinder(DataTable currentDataFile)
        {
            // Define a counter to hold our errors.
            int i = 0;

            // Iterate over each row, checking the length of the Finder Number (ID) column.
            foreach (DataRow row in currentDataFile.Rows)
            {
                if (row["Finder_No"].ToString().Length != 11)
                {
                    i++;
                }
            }
            return i;
            // End Method.
        }

        public static int CheckDuplicates(DataTable currentDataFile)
        {
            // Use LINQ to group the duplicates into a list.
            var duplicateIDs = currentDataFile.AsEnumerable().GroupBy(r => r[38]).Where(gr => gr.Count() > 1).ToList();
            return duplicateIDs.Count();
        }

        public static int CheckKeycodeLength(DataTable currentDataFile)
        {
            // Determine if Keycodes are all the correct length.
            var lengthKeycodes = currentDataFile.AsEnumerable()
                .Where(r => ((string)r["Keycode"]).Length != 11).ToList();

            // Return the count of keycodes with the wrong length.
            return lengthKeycodes.Count();

            // End Method.
        }

        public static int CheckKeycodeDropSplit(DataTable currentDataFile)
        {
            /* Initialize a counter to store our bad format Keycodes.
            *  Find a new variable which is a list based on
            *  a string column name "Keycode" from byte 9 to 11,
            *  when it is not equal to a string column "Drop",
            *  from byte 2 to 2, added to the string column "Split".
            */
            var countBadFormat = currentDataFile.AsEnumerable()
                .Where(r => ((string)r["Keycode"]).Length == 11)
                .Where(r => ((string)r["Keycode"]).Substring(9, 2)
                != ((string)r["Drop"]).Substring(1, 1)
                + ((string)r["Split"]).ToString()).ToList();

            return countBadFormat.Count();
            // End Method.
        }

        public static int CheckDropCode(DataTable currentDataFile)
        {
            // Check that the drop and split codes are all the same.
            var valuesDropSplit = currentDataFile.AsEnumerable()
                .Select(r => ((string)r["Drop"])).Distinct();

            return valuesDropSplit.Count();
        }

        public static int CheckSplitCode(DataTable currentDataFile)
        {
            // Check that all split codes are the same.
            var countSplitCode = currentDataFile.AsEnumerable()
                .Select(r => ((string)r["Split"])).Distinct();

            return countSplitCode.Count();
        }

        public static bool CheckSequenceOrder(DataTable currentDataFile)
        {
            // Get our data table into list format.
            var dataAsList = currentDataFile.Rows.OfType<DataRow>()
                .Select(r => r.Field<int>("Seq")).ToList<int>();
            // Make sure that our sequence numbers are in order by generating a new range based on min & count.
            bool sequentialCheck = Enumerable
                // Call the Enumerable as a range.
                .Range(
                // Define the minimum of the range to be minimum of the "Seq" field on table.
                dataAsList.Min(),
                // An iteration of count equal to the total items on the list.
                dataAsList.Count()
                       )
                // And check that this newly generated sequence matches the table.
                .SequenceEqual(dataAsList);

            return sequentialCheck;

        }

        public static int CheckSequenceMax(DataTable currentDataFile)
        {
            // Set the sequence number column to a list of integers.
            var dataAsList = currentDataFile.Rows.OfType<DataRow>()
                .Select(r => r.Field<int>("Seq")).ToList<int>();

            // Return the maximum on the list.
            return dataAsList.Max();

        }

        public static bool CheckIMBExists(DataTable currentDataFile)
        {
            // Call the data table's IMB column and look for null values using LINQ.
            var checkNullExists = currentDataFile.AsEnumerable()
                .Where(r => r.Field<string>("IMB").ToString() == " " |
                    r.Field<string>("IMB").ToString() == "");

            return checkNullExists.Count() > 0;
            ;
        }

        public static bool CheckIMBUnique(DataTable currentDataFile)
        {
            var dupeIMB = currentDataFile.AsEnumerable()
                .Where(r => r.Field<string>("IMB") != null)
                .GroupBy(r => r)
                .Any(g => g.Count() > 1);

            if (dupeIMB)
            {
                // There are duplicates.
                return true;
            }
            return false;
        }

        public static int CheckIMBMinLength(DataTable currentDataFile)
        {
            // Get the minimum length of the IMB field using LINQ.
            var lengthIMBMin = currentDataFile.Rows.OfType<DataRow>()
                // Select just the lengths of each string in this column.
                .Select(r => r.Field<string>("IMB").Length)
                // Map them to a list for Aggregate.
                .ToList()
                // Compare first two results, then compare the comparison to the next result : iterate until final answer.
                .Aggregate((pre, cur) => pre < cur ? pre : cur);

            return lengthIMBMin;
        }

        public static int CheckIMBMaxLength(DataTable currentDataFile)
        {
            // Get the maximum length of the IMB field using LINQ.
            var lengthIMBMax = currentDataFile.Rows.OfType<DataRow>()
                // Select just the lengths of each string in this column.
                .Select(r => r.Field<string>("IMB").Length)
                // Map them to a list for Aggregate.
                .ToList()
                // Compare first two results, then compare the comparison to the next result : iterate until final answer.
                .Aggregate((pre, cur) => pre > cur ? pre : cur);

            return lengthIMBMax;
        }

        public static string CheckIMBSequenceMinimum(DataTable currentDataFile)
        {
            // Initialize a string for return.
            string foundMinimum = null;

            // Make sure that there are at least a couple values to check.
            var safetyLINQ = currentDataFile.AsEnumerable()
                // Discard bad IMB numbers.
                .Where(r => r.Field<string>("IMB").Length == 31)
                .ToList();
            if (safetyLINQ.Count > 1)
            {
                var minimumSequence = currentDataFile.AsEnumerable()
                // Discard bad IMB numbers.
                .Where(r => r.Field<string>("IMB").Length == 31)
                // Get the sequence numbers as an integer, from bytes 11 to 19)
                .Select(r => Convert.ToInt32(r.Field<string>("IMB").Substring(11, 9)))
                // Map to a list for Aggregate.
                .ToList()
                // Compare the first two results, then c ompare the comparison to the next result : iterate until final answer.
                .Aggregate((pre, cur) => pre < cur ? pre : cur);

                // 0-fill the integer back into a string. 
                // Select a substring which is 9 digits long starting at the right side.
                // Adding 8 because that's the length of the 0 fill constant.
                foundMinimum = ("00000000" + minimumSequence.ToString()).Substring(minimumSequence.ToString().Length + 8 - 9, 9);

                return foundMinimum;
            }
            else
            {
                // There were no barcodes to check.
                return "Blank";
            }
        }
        
        public static string CheckIMBSequenceMaximum(DataTable currentDataFile)
        {
            // Initialize a string for return.
            string foundMaximum = null;

            // Make sure that there are at least a couple values to check.
            var safetyLINQ = currentDataFile.AsEnumerable()
                // Discard bad IMB numbers.
                .Where(r => r.Field<string>("IMB").Length == 31)
                .ToList();
            if (safetyLINQ.Count > 1)
            {
                var maximumSequence = currentDataFile.AsEnumerable()
                // Discard bad IMB numbers.
                .Where(r => r.Field<string>("IMB").Length == 31)
                // Get the sequence numbers as an integer, from bytes 11 to 19)
                .Select(r => Convert.ToInt32(r.Field<string>("IMB").Substring(11, 9)))
                // Map to a list for Aggregate.
                .ToList()
                // Compare the first two results, then c ompare the comparison to the next result : iterate until final answer.
                .Aggregate((pre, cur) => pre > cur ? pre : cur);

                // 0-fill the integer back into a string. 
                // Select a substring which is 9 digits long starting at the right side.
                // Adding 8 because that's the length of the 0 fill constant.
                foundMaximum = ("00000000" + maximumSequence.ToString()).Substring(maximumSequence.ToString().Length + 8 - 9, 9);

                return foundMaximum;
            }
            else
            {
                // There were no barcodes to check.
                return "Blank";
            }
        }

        public static bool CheckIMBSequential(DataTable currentDataFile)
        {
            // Make sure that there are at least a couple values to check.
            var safetyLINQ = currentDataFile.AsEnumerable()
                // Discard bad IMB numbers.
                .Where(r => r.Field<string>("IMB").Length == 31)
                .ToList();
            if (safetyLINQ.Count > 1)
            {
                // Get our sequence numbers into list format as integer.
                var dataAsList = currentDataFile.Rows.OfType<DataRow>()
                // Discard bad IMB numbers.
                .Where(r => r.Field<string>("IMB").Length == 31)
                .Select(r => Convert.ToInt32(r.Field<string>("IMB").Substring(11, 9)))
                .ToList<int>();
                // Make sure that our sequence numbers are in order by generating a new range based on min & count.
                bool sequentialCheck = Enumerable
                    // Call the Enumerable as a range.
                    .Range(
                    // Define the minimum of the range to be minimum of the "Seq" field on table.
                    dataAsList.Min(),
                    // An iteration of count equal to the total items on the list.
                    dataAsList.Count()
                           )
                    // And check that this newly generated sequence matches the table.
                    .SequenceEqual(dataAsList);

                return sequentialCheck;
            }
            else
            {
                // There were no barcodes.
                return false;
            }
                
        }

        public static int CheckIMBMatchesData(DataTable currentDataFile)
        {
            var countBadFormat = currentDataFile.AsEnumerable()
                // Only select valid barcodes.
               .Where(r => r.Field<string>("IMB").Length == 31)
               // Compare valid barcode to other data fields.
               .Where(r => r.Field<string>("IMB").Substring(20, 11)
               != r.Field<string>("Zip")
               + r.Field<string>("Zip4")
               + r.Field<string>("DPC").Substring(0,2)
               )
               .ToList();

            return countBadFormat.Count();
            // End Method.

        }

        public static int CheckLongName(DataTable currentDataFile)
        {
            // Initialize a counter to check if bad names exist.
            int i = 0;
            // Initialize an integer list to store row number of bad names.
            List<int> badIndex = new List<int>();

            // Iterate over the rows in the table to compare names.
            // Continue will break the loop and jump to the next row, so that we don't count a row 3 times.
            foreach (DataRow row in currentDataFile.Rows)
            {
                // Check to see if the full name contains first name. Do nothing if it does.
                if (row.Field<string>("Long_Name") != null && row.Field<string>("First_Name") != null &&
                    row.Field<string>("Long_Name").Contains(row.Field<string>("First_Name")))
                { }
                else
                { i++; continue; }

                // Check to see if the full name contains middle name. Do nothing if it does.
                if (row.Field<string>("Long_Name") != null && row.Field<string>("Middle_Name") != null &&
                    row.Field<string>("Long_Name").Contains(row.Field<string>("Middle_Name")))
                { }
                else
                { i++; continue; }

                // Check to see if the full name contains last name. Do nothing if it does.
                if (row.Field<string>("Long_Name") != null && row.Field<string>("Last_Name") != null &&
                    row.Field<string>("Long_Name").Contains(row.Field<string>("Last_Name")))
                { }
                else
                { i++; continue; }

            }

            // Return number of mismatched names.
            return i;
        }

        public static int CheckSalutations(DataTable currentDataFile)
        {
            // Parse through the data in LINQ to find blank fields in the salutations.
            var indexBadSalutations = currentDataFile.AsEnumerable()
                .Where(r => r.Field<string>("Dear_Sal").Length < 1
                | r.Field<string>("Salutation2").Length < 1
                | r.Field<string>("Salutation3").Length < 1);

            // Pass integer count back to the form.
            return indexBadSalutations.Count();
        }

        public static int CheckFullState(DataTable currentDataFile)
        {
            // Iterate over the table to determine bad states.
            var badStateCounts = currentDataFile.AsEnumerable()
                .Where(r =>
                StateSwitch.GetStateByName(r.Field<string>("Full_State").ToString()).ToString()
                != r.Field<string>("ST").ToString());

            return badStateCounts.Count();
        }

        public static int CheckAmountsNotMatch(DataTable currentDataFile)
        {
            // Just make sure the fields match each other based on AMT_1, AMT_4, against Amount.
            var checkAmounts = currentDataFile.AsEnumerable()
            // START
                .Where(r => 
                ! r.Field<string>("Amt_1").ToString()
                .Contains(
                    r.Field<string>("Amount").ToString()
                        )
                && // AND
                ! r.Field<string>("Amt_4").ToString()
                .Contains(
                    r.Field<string>("Amount").ToString()
                        )
                    );
            // STOP

            return checkAmounts.Count();
        }
        
        public static int CheckFileType(DataTable currentDataFile)
        {
            // Let's see if any of the File Type field rows have blank data.
            var checkBlankData = currentDataFile.AsEnumerable()
                .Where(r => r.Field<string>("File_Type").ToString() == "");

            return checkBlankData.Count();
        }

        public static int CheckBadCharacters(DataTable currentDataFile)
        {
            // Look for troublesome special characters among ALL fields.
            // At long last, I have figured out how to query "ANY" column.
            // This will cast the columns as DataColumn into an array.
            List<DataColumn> columns = currentDataFile.Columns.Cast<DataColumn>().ToList<DataColumn>();
            columns.RemoveRange(40, 3); // Remove senators and congressmen as they're sanitized ahead of time.
            var checkSpecialCharacters = currentDataFile.AsEnumerable()
                .Where(r => columns.Any(c => r[c].ToString().Contains(',')));

            return checkSpecialCharacters.Count();
        }

        public static List<int> DetailsLongName(DataTable currentDataFile)
        {
            // List to hold the indexes that we find.
            List<int> indexBadNames = new List<int>();

            // Return the record number of any matching the condition.
            // Select has an overload which allows a second input for the index.
            // Then simply check for where the conditions match and return the index.
            var badFirstNames = currentDataFile.AsEnumerable()
                .Select((r, i) => new { i, r })
                .Where(f =>
                    (f.r.Field<string>("Long_Name") != null &&
                    f.r.Field<string>("First_Name") != null &&
                    !f.r.Field<string>("Long_Name").Contains(f.r.Field<string>("First_Name") ) 
                    ) ||
                    (f.r.Field<string>("Long_Name") != null &&
                    f.r.Field<string>("First_Name") != null &&
                    !f.r.Field<string>("Long_Name").Contains(f.r.Field<string>("Middle_Name") )
                    ) ||
                    (f.r.Field<string>("Long_Name") != null &&
                    f.r.Field<string>("First_Name") != null &&
                    !f.r.Field<string>("Long_Name").Contains(f.r.Field<string>("Last_Name")) )
                )
                .Select(r => r.i);

            indexBadNames.AddRange(badFirstNames);

            return indexBadNames;
        }

        public static List<string> DetailsDuplicates(DataTable currentDataFile)
        {
            // List to hold the indexes that we find.
            List<string> indexDupeIDs = new List<string>();

            // Return the record number of any matching the condition.
            // Select has an overload which allows a second input for the index.
            // Then simply check for where the conditions match and return the index.
            var duplicateIDs = currentDataFile.AsEnumerable()
                .Select((r, i) => new { i, r })
                .GroupBy(f => f.r.Field<string>("Finder_No"))
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            indexDupeIDs.AddRange(duplicateIDs);
            return indexDupeIDs;
        }

        public static List<int> DetailsIDLength(DataTable currentDataFile)
        {
            // Initialize a new list to hold the indexes.
            List<int> indexBadLength = new List<int>();

            // Use LINQ to locate the fields which have short ID numbers.
            var indexesFound = currentDataFile.AsEnumerable()
                .Select((r, i) => new { i, r })
                .Where(f => f.r.Field<string>("Finder_No").Length != 11)
                .Select(r => r.i);

            indexBadLength.AddRange(indexesFound);

            return indexBadLength;
        }

        public static List<int> DetailsKeycodeFormat(DataTable currentDataFile)
        {
            // Initialize a new list to hold the indexes.
            List<int> indexBadLength = new List<int>();

            /* Initialize a var to store our bad format Keycodes.
            *  Find a new variable which is a list based on
            *  a string column name "Keycode" from byte 9 to 11,
            *  when it is not equal to a string column "Drop",
            *  from byte 2 to 2, added to the string column "Split".
            */
            var indexesFound = currentDataFile.AsEnumerable()
                .Select((r, i) => new { i, r })
                .Where(f => f.r.Field<string>("Keycode").Substring(9, 2)
                != f.r.Field<string>("Keycode").Substring(1, 1)
                + f.r.Field<string>("Keycode").ToString())
                .Select(r => r.i);

            indexBadLength.AddRange(indexesFound);

            return indexBadLength;
        }

        public static List<int> DetailsKeycodeLength(DataTable currentDataFile)
        {
            // Initialize a new list to hold the indexes.
            List<int> indexBadLength = new List<int>();

            // Use LINQ to find the Keycodes of incorrect length.
            var indexesFound = currentDataFile.AsEnumerable()
                .Select((r, i) => new { i, r })
                .Where(f => f.r.Field<string>("Keycode").Length != 11)
                .Select(r => r.i);

            indexBadLength.AddRange(indexesFound);

            return indexBadLength;
        }

        public static List<int> DetailsIMBNull(DataTable currentDataFile)
        {
            // Initialize a new list to hold the indexes.
            List<int> indexBadLength = new List<int>();

            // Use LINQ to find the null barcodes.
            var indexesFound = currentDataFile.AsEnumerable()
                .Select((r, i) => new { i, r })
                .Where(f => f.r.Field<string>("IMB").ToString() == "")
                .Select(r => r.i);

            indexBadLength.AddRange(indexesFound);

            return indexBadLength;
        }

        public static List<string> DetailsIMBDuplicate(DataTable currentDataFile)
        {
            // List to hold the indexes that we find.
            List<string> indexDupeIDs = new List<string>();

            // Return the record number of any matching the condition.
            // Select has an overload which allows a second input for the index.
            // Then simply check for where the conditions match and return the index.
            var duplicateIDs = currentDataFile.AsEnumerable()
                .Select((r, i) => new { i, r })
                .GroupBy(f => f.r.Field<string>("IMB"))
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();

            indexDupeIDs.AddRange(duplicateIDs);
            return indexDupeIDs;
        }

        public static List<int> DetailsIMBMatching(DataTable currentDataFile)
        {
            // A list of integers to hold the index of bad matches.
            List<int> indexBadIMB = new List<int>();

            // CONDITION: "IMB".Substring(20,11) should be Zip5+Zip4+DPC
            var indexesFound = currentDataFile.AsEnumerable()
                // Only select barcodes of the correct length.
                .Where( r => r.Field<string>("IMB").Length == 31)
                // Overload select to get index.
                .Select((r, i) => new { i, r })
                // Check for the baddies.
                .Where(
                f => f.r.Field<string>("IMB").Substring(20,11) 
                != (
                f.r.Field<string>("Zip")
                + f.r.Field<string>("Zip4")
                + f.r.Field<string>("DPC").Substring(0,2)
                    )
                )
                .Select(r => r.i);

            indexBadIMB.AddRange(indexesFound);

            return indexBadIMB;
        }

        public static List<int> DetailsAmounts(DataTable currentDataFile)
        {
            // List of ints for return later.
            List<int> indexBadAmounts = new List<int>();
            // Just make sure the fields match each other based on AMT_1, AMT_4, against Amount.
            var checkAmounts = currentDataFile.AsEnumerable()
            // START
                .Select((r, i) => new { i, r })
                .Where(f => !
                f.r.Field<string>("Amt_1").ToString()
                .Contains(
                    f.r.Field<string>("Amount").ToString()
                        )
                && // AND
                ! f.r.Field<string>("Amt_4").ToString()
                .Contains(
                    f.r.Field<string>("Amount").ToString()
                        )
                    )
                // Get indexes.
                .Select(r => r.i);
            // STOP

            indexBadAmounts.AddRange(checkAmounts);
            return indexBadAmounts;
        }

        public static List<int> DetailsFullState(DataTable currentDataFile)
        {
            // List of ints for return later.
            List<int> indexBadAmounts = new List<int>();
            // Just make sure the fields match each other based on AMT_1, AMT_4, against Amount.
            var checkStates = currentDataFile.AsEnumerable()
            // START
                .Select((r, i) => new { i, r })
                .Where(f =>
                StateSwitch.GetStateByName(f.r.Field<string>("Full_State").ToString()).ToString()
                != f.r.Field<string>("ST").ToString())
                // Get indexes.
                .Select(r => r.i);
            // STOP

            indexBadAmounts.AddRange(checkStates);
            return indexBadAmounts;
        }

        public static List<int> DetailsBadChars(DataTable currentDataFile)
        {
            // List of ints for return later.
            List<int> indexBadAmounts = new List<int>();
            // This will cast the columns as DataColumn into an array.
            List<DataColumn> columns = currentDataFile.Columns.Cast<DataColumn>().ToList<DataColumn>();
            columns.RemoveRange(40, 3); // Remove senators and congressmen as they are sanitized ahead of time.
            // Look for troublesome special characters among ALL fields.
            var checkSpecialCharacters = currentDataFile.AsEnumerable()
                .Select((r, i) => new { i, r })
                // using f => f.r because of the index select overload.
                .Where(f => columns.Any(c => f.r[c].ToString().Contains(','))
                | columns.Any(c => f.r[c].ToString().Contains('\t'))
                | columns.Any(c => f.r[c].ToString().Contains('\v'))
                | columns.Any(c => f.r[c].ToString().Contains('\r'))
                | columns.Any(c => f.r[c].ToString().Contains('\n'))
                | columns.Any(c => f.r[c].ToString().Contains('"')))
                .Select(r => r.i);

            // NOTE: I do not know how to perform this calcuation against a list of chars, so I wrote it out manually.

            indexBadAmounts.AddRange(checkSpecialCharacters);
            return indexBadAmounts;
        }


        // End Class.
    }

    /// <summary>
    /// This class will handle all filesystem I/O functions such as load, select, streaming, writing etc...
    /// </summary>
    /// 
    public class FileManagement
    {
        /// <summary>
        /// Opens a file selection window for the user to call their data file.
        /// </summary>
        /// <returns>A string containing full path.</returns>
        public static string SelectFile()
        {
            string selectedFile = null;

            // Call a new file selection window and check result.
            OpenFileDialog fileDialog = new OpenFileDialog();
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                selectedFile = fileDialog.FileName;
            }

            return selectedFile;
            // End Method.
        }

        // End Class.
    }

    public class StateSwitch
    {
        public static string GetState(State state)
        {
            switch (state)
            {
                case State.AL:
                    return "ALABAMA";

                case State.AK:
                    return "ALASKA";

                case State.AS:
                    return "AMERICAN SAMOA";

                case State.AZ:
                    return "ARIZONA";

                case State.AR:
                    return "ARKANSAS";

                case State.CA:
                    return "CALIFORNIA";

                case State.CO:
                    return "COLORADO";

                case State.CT:
                    return "CONNECTICUT";

                case State.DE:
                    return "DELAWARE";

                case State.DC:
                    return "DISTRICT OF COLUMBIA";

                case State.ER:
                    return "ERROR";

                case State.FM:
                    return "FEDERATED STATES OF MICRONESIA";

                case State.FL:
                    return "FLORIDA";

                case State.GA:
                    return "GEORGIA";

                case State.GU:
                    return "GUAM";

                case State.HI:
                    return "HAWAII";

                case State.ID:
                    return "IDAHO";

                case State.IL:
                    return "ILLINOIS";

                case State.IN:
                    return "INDIANA";

                case State.IA:
                    return "IOWA";

                case State.KS:
                    return "KANSAS";

                case State.KY:
                    return "KENTUCKY";

                case State.LA:
                    return "LOUISIANA";

                case State.ME:
                    return "MAINE";

                case State.MH:
                    return "MARSHALL ISLANDS";

                case State.MD:
                    return "MARYLAND";

                case State.MA:
                    return "MASSACHUSETTS";

                case State.MI:
                    return "MICHIGAN";

                case State.MN:
                    return "MINNESOTA";

                case State.MS:
                    return "MISSISSIPPI";

                case State.MO:
                    return "MISSOURI";

                case State.MT:
                    return "MONTANA";

                case State.NE:
                    return "NEBRASKA";

                case State.NV:
                    return "NEVADA";

                case State.NH:
                    return "NEW HAMPSHIRE";

                case State.NJ:
                    return "NEW JERSEY";

                case State.NM:
                    return "NEW MEXICO";

                case State.NY:
                    return "NEW YORK";

                case State.NC:
                    return "NORTH CAROLINA";

                case State.ND:
                    return "NORTH DAKOTA";

                case State.MP:
                    return "NORTHERN MARIANA ISLANDS";

                case State.OH:
                    return "OHIO";

                case State.OK:
                    return "OKLAHOMA";

                case State.OR:
                    return "OREGON";

                case State.PW:
                    return "PALAU";

                case State.PA:
                    return "PENNSYLVANIA";

                case State.PR:
                    return "PUERTO RICO";

                case State.RI:
                    return "RHODE ISLAND";

                case State.SC:
                    return "SOUTH CAROLINA";

                case State.SD:
                    return "SOUTH DAKOTA";

                case State.TN:
                    return "TENNESSEE";

                case State.TX:
                    return "TEXAS";

                case State.UT:
                    return "UTAH";

                case State.VT:
                    return "VERMONT";

                case State.VI:
                    return "VIRGIN ISLANDS";

                case State.VA:
                    return "VIRGINIA";

                case State.WA:
                    return "WASHINGTON";

                case State.WV:
                    return "WEST VIRGINIA";

                case State.WI:
                    return "WISCONSIN";

                case State.WY:
                    return "WYOMING";
            }

            throw new Exception("Not Available");
        }


        public static State GetStateByName(string name)
            {
            switch (name.ToUpper())
            {
                case "ALABAMA":
                    return State.AL;

                case "ALASKA":
                    return State.AK;

                case "AMERICAN SAMOA":
                    return State.AS;

                case "ARIZONA":
                    return State.AZ;

                case "ARKANSAS":
                    return State.AR;

                case "CALIFORNIA":
                    return State.CA;

                case "COLORADO":
                    return State.CO;

                case "CONNECTICUT":
                    return State.CT;

                case "DELAWARE":
                    return State.DE;

                case "DISTRICT OF COLUMBIA":
                    return State.DC;

                case "FEDERATED STATES OF MICRONESIA":
                    return State.FM;

                case "FLORIDA":
                    return State.FL;

                case "GEORGIA":
                    return State.GA;

                case "GUAM":
                    return State.GU;

                case "HAWAII":
                    return State.HI;

                case "IDAHO":
                    return State.ID;

                case "ILLINOIS":
                    return State.IL;

                case "INDIANA":
                    return State.IN;

                case "IOWA":
                    return State.IA;

                case "KANSAS":
                    return State.KS;

                case "KENTUCKY":
                    return State.KY;

                case "LOUISIANA":
                    return State.LA;

                case "MAINE":
                    return State.ME;

                case "MARSHALL ISLANDS":
                    return State.MH;

                case "MARYLAND":
                    return State.MD;

                case "MASSACHUSETTS":
                    return State.MA;

                case "MICHIGAN":
                    return State.MI;

                case "MINNESOTA":
                    return State.MN;

                case "MISSISSIPPI":
                    return State.MS;

                case "MISSOURI":
                    return State.MO;

                case "MONTANA":
                    return State.MT;

                case "NEBRASKA":
                    return State.NE;

                case "NEVADA":
                    return State.NV;

                case "NEW HAMPSHIRE":
                    return State.NH;

                case "NEW JERSEY":
                    return State.NJ;

                case "NEW MEXICO":
                    return State.NM;

                case "NEW YORK":
                    return State.NY;

                case "NORTH CAROLINA":
                    return State.NC;

                case "NORTH DAKOTA":
                    return State.ND;

                case "NORTHERN MARIANA ISLANDS":
                    return State.MP;

                case "OHIO":
                    return State.OH;

                case "OKLAHOMA":
                    return State.OK;

                case "OREGON":
                    return State.OR;

                case "PALAU":
                    return State.PW;

                case "PENNSYLVANIA":
                    return State.PA;

                case "PUERTO RICO":
                    return State.PR;

                case "RHODE ISLAND":
                    return State.RI;

                case "SOUTH CAROLINA":
                    return State.SC;

                case "SOUTH DAKOTA":
                    return State.SD;

                case "TENNESSEE":
                    return State.TN;

                case "TEXAS":
                    return State.TX;

                case "UTAH":
                    return State.UT;

                case "VERMONT":
                    return State.VT;

                case "VIRGIN ISLANDS":
                    return State.VI;

                case "VIRGINIA":
                    return State.VA;

                case "WASHINGTON":
                    return State.WA;

                case "WEST VIRGINIA":
                    return State.WV;

                case "WISCONSIN":
                    return State.WI;

                case "WYOMING":
                    return State.WY;

                default:
                    return State.ER;
            }

        throw new Exception("Not Available");
    }

        public enum State
        {
            AL,
            AK,
            AS,
            AZ,
            AR,
            CA,
            CO,
            CT,
            DE,
            DC,
            FM,
            FL,
            GA,
            GU,
            HI,
            ID,
            IL,
            IN,
            IA,
            KS,
            KY,
            LA,
            ME,
            MH,
            MD,
            MA,
            MI,
            MN,
            MS,
            MO,
            MT,
            NE,
            NV,
            NH,
            NJ,
            NM,
            NY,
            NC,
            ND,
            MP,
            OH,
            OK,
            OR,
            PW,
            PA,
            PR,
            RI,
            SC,
            SD,
            TN,
            TX,
            UT,
            VT,
            VI,
            VA,
            WA,
            WV,
            WI,
            WY,
            ER
        }


    }

    /// <summary>
    /// This class handles double buffering for data grid view tools. This prevents flickering.
    /// </summary>
    static class DataGridViewExtensioncs
    {
        /// <summary>
        /// This method prevents flickering on data grid view tables.
        /// </summary>
        public static void DoubleBuffered(this DataGridView dgv, bool setting)
        {
            var dgvType = dgv.GetType();
            var pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(dgv, setting, null);
        }
    }
}
