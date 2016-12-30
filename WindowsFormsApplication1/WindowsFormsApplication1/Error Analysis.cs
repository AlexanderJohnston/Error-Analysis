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

namespace WindowsFormsApplication1
{
    public partial class ErrorAnalysis : Form
    {
        public ErrorAnalysis()
        {
            InitializeComponent();
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
            DataTable table1500Layout = ConstructTable1500();


            // Import the selected data file into our new table.
            table1500Layout = CommonEngine.CsvToDataTable(selectedFile, "ImportRecord", ',', true);

            return table1500Layout;

            // End Method.
        }

        /// <summary>
        /// Construct a new data table with the 1500 byte Engage layout.
        /// </summary>
        public static DataTable ConstructTable1500()
        {
            // Define the columns in 1500 byte layout for Engage.
            DataColumn[] newCols ={
                new DataColumn("Seq", typeof(String)),
                new DataColumn("Title", typeof(String)),
                new DataColumn("First Name", typeof(String)),
                new DataColumn("Middle Name", typeof(String)),
                new DataColumn("Last Name", typeof(String)),
                new DataColumn("Suffix", typeof(String)),
                new DataColumn("Long Name", typeof(String)),
                new DataColumn("Drop", typeof(String)),
                new DataColumn("Split", typeof(String)),
                new DataColumn("House (H)/Prospect (P)", typeof(String)),
                new DataColumn("Ref#", typeof(String)),
                new DataColumn("DPC", typeof(String)),
                new DataColumn("Dear Sal", typeof(String)),
                new DataColumn("Salutation2", typeof(String)),
                new DataColumn("Salutation3", typeof(String)),
                new DataColumn("Company", typeof(String)),
                new DataColumn("Secondary Addr", typeof(String)),
                new DataColumn("Primary Addr", typeof(String)),
                new DataColumn("City", typeof(String)),
                new DataColumn("ST", typeof(String)),
                new DataColumn("Zip", typeof(String)),
                new DataColumn(" - ", typeof(String)),
                new DataColumn("Zip4", typeof(String)),
                new DataColumn("MRG Date", typeof(String)),
                new DataColumn("MRG Amount", typeof(String)),
                new DataColumn("MRG Month", typeof(String)),
                new DataColumn("HPC Date", typeof(String)),
                new DataColumn("HPC Amount", typeof(String)),
                new DataColumn("First Date", typeof(String)),
                new DataColumn("First Year", typeof(String)),
                new DataColumn("Amt 1", typeof(String)),
                new DataColumn("Amt 2", typeof(String)),
                new DataColumn("Amt 3", typeof(String)),
                new DataColumn("Amt 4", typeof(String)),
                new DataColumn("Amt 5", typeof(String)),
                new DataColumn("Amount", typeof(String)),
                new DataColumn("OEL", typeof(String)),
                new DataColumn("Keycode", typeof(String)),
                new DataColumn("Finder No", typeof(String)),
                new DataColumn("Dist", typeof(String)),
                new DataColumn("Congressmen", typeof(String)),
                new DataColumn("Senator 1", typeof(String)),
                new DataColumn("Senator 2", typeof(String)),
                new DataColumn("County", typeof(String)),
                new DataColumn("Governor", typeof(String)),
                new DataColumn("Full State", typeof(String)),
                new DataColumn("IMB", typeof(String)),
                new DataColumn("File Type", typeof(String)),
                new DataColumn("Priority", typeof(String)),
                new DataColumn("FILENAME", typeof(String)),
                new DataColumn("Engage Use", typeof(String)),
                new DataColumn("Client1", typeof(String)),
                new DataColumn("Client2", typeof(String)),
                new DataColumn("Client3",typeof(String)),
                new DataColumn("Client4",typeof(String)),
                new DataColumn("DPV Error",typeof(String)),
                new DataColumn("NCOA Mflag",typeof(String)),
                new DataColumn("NCOA FN",typeof(String))
                };
            // Define the new data table.
            DataTable newTable1500 = new DataTable("1500 Layout Analysis");
            newTable1500.Columns.AddRange(newCols);

            return newTable1500;
            // End Method.
        }
        // End Class.
    }

    /// <summary>
    /// This class will handle all filesystem I/O functions such as load, select, streaming, writing etc...
    /// </summary>
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
}
