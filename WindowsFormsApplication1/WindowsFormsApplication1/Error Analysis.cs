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

namespace WindowsFormsApplication1
{

    public partial class ErrorAnalysis : Form
    {
        public static DataTable globalTable = new DataTable();

        public ErrorAnalysis()
        {
            InitializeComponent();
            dataGridView1.DoubleBuffered(true);
        }

        /// <summary>
        /// An entry point which accepts a file path to begin checking for common errors.
        /// </summary>
        public DataTable EntryPoint(string selectedFile)
        {
            // Build a data table to store our incoming file using the 1500 schema which is defined in the method.
            DataTable table1500Layout = ErrorChecking.ConstructTable1500(selectedFile);

            // Drop out if the table couldn't be constructed properly, due to header mis-match.
            if (table1500Layout.Rows.Count == 0) { return table1500Layout; }

            // Begin Error Analysis
            int badFinder = ErrorChecking.CheckFinder(table1500Layout);
            textFinderLength.Text = badFinder.ToString();
            int badDuplicates = ErrorChecking.CheckDuplicates(table1500Layout);
            textFinderDupe.Text = badDuplicates.ToString();
            int badKeycodeLength = ErrorChecking.CheckKeycodeLength(table1500Layout);
            textKeycodeLength.Text = badKeycodeLength.ToString();
            int badKeycodeFormat = ErrorChecking.CheckKeycodeDropSplit(table1500Layout);
            textKeycodeFormat.Text = badKeycodeFormat.ToString();
            int countDropCode = ErrorChecking.CheckDropCode(table1500Layout);
            textDropCode.Text = countDropCode.ToString();
            int countSplitCode = ErrorChecking.CheckSplitCode(table1500Layout);
            textSplitCode.Text = countSplitCode.ToString();
            bool checkSequential = ErrorChecking.CheckSequenceOrder(table1500Layout);
            textSequential.Text = checkSequential.ToString();
            bool checkIMBNull = ErrorChecking.CheckIMBExists(table1500Layout);
            textIMBNull.Text = checkIMBNull.ToString();
            bool checkIMBUnique = ErrorChecking.CheckIMBUnique(table1500Layout);
            textIMBUnique.Text = checkIMBUnique.ToString();
            int checkIMBMin = ErrorChecking.CheckIMBMinLength(table1500Layout);
            textIMBMin.Text = checkIMBMin.ToString();
            int checkIMBMax = ErrorChecking.CheckIMBMaxLength(table1500Layout);
            textIMBMax.Text = checkIMBMax.ToString();
            int checkLongNameMatches = ErrorChecking.CheckLongName(table1500Layout);
            textBadLongName.Text = checkLongNameMatches.ToString();

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
                currentDataTable = EntryPoint(selectedFile);

                // Drop out if the table came back null.
                if (currentDataTable.Rows.Count == 0) { MessageBox.Show("The header on your table is not Engage 1500 Layout.", "Header Mis-match!"); return; }

                // Save our global table.
                globalTable = currentDataTable;
                
                //Display the table.
                dataGridView1.DataSource = currentDataTable;

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
            var checkNullExists = currentDataFile.Rows.OfType<DataRow>()
                .Where(r => r.Field<string>("IMB").ToString() == "");

            return checkNullExists.Count() > 0;
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
