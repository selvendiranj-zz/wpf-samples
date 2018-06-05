using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using OfficeOpenXml;
using System.IO;
using System.Data;

namespace TestAppWpf
{
    /// <summary>
    /// Interaction logic for ExcelReadingwithEPPLUS.xaml
    /// </summary>
    public partial class ExcelReadingwithEPPLUS : Window
    {
        ExcelPackage pack;
        ExcelWorkbook wb;
        
        public ExcelReadingwithEPPLUS()
        {
            InitializeComponent();
            
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            var result = dlg.ShowDialog();
            if (result == true)
            {
                textBox.Text = dlg.FileName;
            }
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            
            if (textBox.Text != "")
            {
                FileInfo file = new FileInfo(textBox.Text);
                pack = new ExcelPackage(file);

                wb = pack.Workbook;

                List<string> sheets = pack.Workbook.Worksheets.Select(x => x.Name).ToList();

                sheetCombo.ItemsSource = sheets;



            }
        }

        private void sheetCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            dt.Columns.Clear();

            ExcelWorksheet ws;

            if (sheetCombo.SelectedItem.ToString() == "Balance Sheet Worksheet")
            {
                ws = pack.Workbook.Worksheets["Balance Sheet Worksheet"];

                var headerRows = ws.Cells["B8:B185"];//ws.Cells["A4:N4"];

                foreach(var cell in headerRows)
                {
                    var columncellvalue = cell.GetValue<string>();
                    if (columncellvalue != null)
                    { 
                   
                    dt.Columns.Add(new DataColumn(cell.ToString()+"_"+columncellvalue.ToString()));
                    }
                    else
                    {
                        dt.Columns.Add(new DataColumn(cell.ToString()+"_"));
                    }

                }

                //foreach (DataColumn c in dt.Columns)
                //{
                //    int s = c.ColumnName.IndexOf('_');
                //    if (c.ColumnName.Length > s + 1)
                //    {
                //        string columnname = c.ColumnName.Replace(c.ColumnName, c.ColumnName.Remove(0, s + 1));
                //        c.ColumnName = columnname;

                //        dt.AcceptChanges();

                //    }

                //    if (c.ColumnName.Length == s + 1)
                //    {
                //        dt.Columns.Remove(c);
                //    }
                //    c.ColumnName.Replace(c.ColumnName, c.ColumnName.Substring(s + 1, c.ColumnName.Length));
                //}

                //to iterate from E to N ,E-4,F-5,....
                //G-6
                //H-7
                //I-8
                //J-9
                //K-10
                //L-11
                //M-12
                //N-13

                for(int i = 69; i <= 78; i++)
                {
                    char index = Convert.ToChar(i);

                    var range = ws.Cells[index+"8:"+index+"185"];

                    int datatablecolumn = 0;
                    DataRow newRow = null;
                    int currcolumn = -1;
                    foreach (var item in range)
                    {
                        if(item.Address.Equals("F15"))
                        {
                            break;
                        }
                        if (currcolumn != item.Start.Column)
                        {
                            newRow = dt.NewRow();
                            dt.Rows.Add(newRow);
                            datatablecolumn = 0;
                            currcolumn = item.Start.Column;


                        }
                        if (item.Value != null)
                        {
                            newRow[datatablecolumn] = item.Value.ToString();
                        }
                        else
                        {
                            newRow[datatablecolumn] = string.Empty;
                        }

                        datatablecolumn++;

                    }
                }

                // var range = ws.Cells["A6:N185"];
                //int datatablecolumn = 0;
                //DataRow newRow = null;
                //int currrow = -1;
                //foreach(var item in range)
                //{
                //    if (currrow != item.Start.Row)
                //    {
                //        newRow = dt.NewRow();
                //        dt.Rows.Add(newRow);
                //        datatablecolumn = 0;
                //        currrow = item.Start.Row;


                //    }
                //    if(item.Value!=null)
                //    {
                //        newRow[datatablecolumn] = item.Value.ToString();
                //    }

                //    datatablecolumn++;

                //}






            }
            else
            {

            }

            dataGrid.ItemsSource = new DataView(dt);
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string s = (string)e.Column.Header;
            string changed_header;
            int index = s.IndexOf('_');

            if(s.Length>index+1)
            {
                changed_header = s.Replace(s, s.Remove(0, index + 1));
                e.Column.Header = changed_header;
              
            }
            
        }
    }
}
