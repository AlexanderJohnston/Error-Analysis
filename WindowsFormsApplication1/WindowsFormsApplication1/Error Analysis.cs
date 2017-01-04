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

namespace WindowsFormsApplication1
{
    public partial class ErrorAnalysis : Form
    {
        public ErrorAnalysis()
        {
            InitializeComponent();
            dataGridView1.DoubleBuffered(true);
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
                dataGridView1.DataSource = ErrorChecking.EntryPoint(selectedFile);
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
        // End Class.
    }


    /// <summary>
    /// This class will handle all data analysis functions.
    /// </summary>
    public class ErrorChecking
    {
        /// <summary>
        /// An entry point which accepts a file path to begin checking for common errors.
        /// </summary>
        public static DataTable EntryPoint(string selectedFile)
        {
            // Build a data table to store our incoming file using the 1500 schema which is defined in the method.
            DataTable table1500Layout = ConstructTable1500(selectedFile);

            // Begin Error Analysis
            int badFinder = CheckFinder(table1500Layout);
            int badDuplicates = CheckDuplicates(table1500Layout);
            int badKeycodeLength = CheckKeycodeLength(table1500Layout);
            int badKeycodeFormat = CheckKeycodeDropSplit(table1500Layout);
            int countDropCode = CheckDropCode(table1500Layout);
            int countSplitCode = CheckSplitCode(table1500Layout);
            bool checkSequential = CheckSequenceOrder(table1500Layout);
            bool checkIMBNull = CheckIMBExists(table1500Layout);
            bool checkIMBUnique = CheckIMBUnique(table1500Layout);
            int checkIMBMin = CheckIMBMinLength(table1500Layout);
            int checkIMBMax = CheckIMBMaxLength(table1500Layout);

            // Display the table.
            return table1500Layout;

            // End Method.
        }

        /// <summary>
        /// Construct a new data table with the 1500 byte Engage layout.
        /// </summary>
        public static DataTable ConstructTable1500(string selectedFile)
        {
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
            foreach(DataRow row in currentDataFile.Rows)
            {
                if ( row["Finder_No"].ToString().Length != 11)
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
                .Where(r => r.Field<string>("IMB") == null).ToList();

            return checkNullExists.Count() > 0;
        }

        public static bool CheckIMBUnique(DataTable currentDataFile)
        {
            // Call the IMB column and look for duplicated values using LINQ.
            var duplicateIMBs = currentDataFile.Rows.OfType<DataRow>()
                .GroupBy(r => r.Field<string>("IMB"))
                // Only select where a group count is greater than 1, meaning a duplicate.
                .Where(gr => gr.Count() > 1).ToList();
            return duplicateIMBs.Count()>0;
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
