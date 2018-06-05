using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Excel;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Reflection;

namespace TestAppWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DataSet ds=new DataSet();
        public static string con;

        public static string GetConnectionString(string filename)
        {
            
            var file = new FileInfo(filename);
            using (var stream = new FileStream(filename, FileMode.Open))
            {

                if (file.Extension == ".xls")
                {
                   
                    con = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + filename + ";Extended Properties='Excel 8.0;HDR=Yes'";
                    


                }
                else if (file.Extension == ".xlsx")
                {
                   
                    con = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filename + ";Extended Properties='Excel 8.0;HDR=No'";
                }
            }
                return con;
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
           
            this.sheetCombo.SelectionChanged -= new SelectionChangedEventHandler(OnMyComboboxChanged);
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            var result = dlg.ShowDialog();
            if (result == true)
            {
                textBox.Text = dlg.FileName;
            }
           
        }

        private void OnMyComboboxChanged(object sender,SelectionChangedEventArgs e)
        {
            SelectTable();
        }


        static DataTable GetSchemaTable(string con)
        {
            using (OleDbConnection connection = new
                       OleDbConnection(con))
            {
                connection.Open();
                DataTable schemaTable = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
               // DataTable schemaTable = connection.GetOleDbSchemaTable(
                 //   OleDbSchemaGuid.Tables, null);
                  //  new object[] { null, null, null, "TABLE" });
                return schemaTable;
            }
        }
        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            con = GetConnectionString(textBox.Text);
            // DataTable sheets = GetSchemaTable(con);

            List<string> table_list = new List<string>();

            //foreach(DataRow r in sheets.Rows)
            //{

            //    table_list.Add(r.Field<string>(2));
            //}
            List<SheetName> sheets = new List<SheetName>();
            sheets = GetSheetNames(con);
            foreach(SheetName item in sheets)
            {
                table_list.Add(item.sheetName.Substring(1,item.sheetName.Length-3));
            }
            sheetCombo.ItemsSource = table_list;

            if (table_list.Count >= 0)
                sheetCombo.SelectedIndex = 0;
          
        }

        private IList<string> GetTablenames(DataTableCollection tables)
        {
            var tableList = new List<string>();
            foreach (var table in tables)
            {
                tableList.Add(table.ToString());
            }

            return tableList;
        }

        private void sheetCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectTable();
        }

        private void SelectTable()
        {
            var tablename = sheetCombo.SelectedItem;
            string sheetName = sheetCombo.SelectedItem.ToString();
            string sheetNamewithoutdollar = sheetName.Substring(0, sheetName.Length - 2)+"$A:R";

            using (OleDbConnection connection = new
                       OleDbConnection(con))
            {
                connection.Open();
                string query = @"SELECT * FROM [" + tablename +  "$A:Z]";
                // ds.Clear();
                OleDbDataAdapter data = new OleDbDataAdapter(query, connection);
                DataTable dt = new DataTable();
                data.Fill(dt);

             




                dataGrid.ItemsSource = new DataView(dt);
             
            }
          

        }


        public List<SheetName> GetSheetNames(string conn)
        {
            List<SheetName> sheetNames = new List<SheetName>();
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                con.Open();
                DataTable excelSchema = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow row in excelSchema.Rows)
                {
                    if (!row["TABLE_NAME"].ToString().Contains("xlnm"))
                    {
                        sheetNames.Add(new SheetName() { sheetName = row["TABLE_NAME"].ToString(), sheetType = row["TABLE_TYPE"].ToString(), sheetCatalog = row["TABLE_CATALOG"].ToString(), sheetSchema = row["TABLE_SCHEMA"].ToString() });
                    }
                }
            }
            return sheetNames;
        }


    }

    public class SheetName
    {
        public string sheetName { get; set; }
        public string sheetType { get; set; }
        public string sheetCatalog { get; set; }
        public string sheetSchema { get; set; }
    }
}

