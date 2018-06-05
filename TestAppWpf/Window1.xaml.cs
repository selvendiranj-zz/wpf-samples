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
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.SS.Util;
using NPOI.SS.Formula;
using NPOI.XSSF.Util;
using NPOI.POIFS.FileSystem;
using NPOI.POIFS.Properties;
using System.IO;
using System.Data;

namespace TestAppWpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        HSSFWorkbook hssfwb;
        HSSFSheet hssfsheet;
        HSSFRow hssfrow;
        HSSFCell hssfcell;

        IWorkbook xssfwb;
        ISheet xssfsheet;
        XSSFRow xssfrow;
        XSSFCell xssfcell;

        public Window1()
        {
            InitializeComponent();
        }

        private void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            var filetoread = new FileInfo(textBox.Text);
            int sheet_no = 0;
            List<string> sheet = new List<string>();
            if (filetoread.Extension == ".xls")
            {

                using (FileStream file = new FileStream(textBox.Text, FileMode.Open, FileAccess.Read))
                {
                    hssfwb = new HSSFWorkbook(file);
                }

                sheet_no = hssfwb.NumberOfSheets;

                for (int i = 0; i < sheet_no; i++)
                {
                    sheet.Add(hssfwb.GetSheetName(i));
                }
            }
            else if (filetoread.Extension == ".xlsx")
            {


                using (FileStream file = new FileStream(textBox.Text, FileMode.Open, FileAccess.Read))
                {
                    xssfwb = new XSSFWorkbook(file);
                }

                sheet_no = xssfwb.NumberOfSheets;

                for (int i = 0; i < sheet_no; i++)
                {
                    sheet.Add(xssfwb.GetSheetName(i));
                }
            }






            sheetCombo.ItemsSource = sheet;




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

        private void sheetCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Rows.Clear();
            dt.Columns.Clear();
            //int i = 1;
            var filetoread = new FileInfo(textBox.Text);
            if (filetoread.Extension == ".xls")
            {

                hssfsheet = (HSSFSheet)hssfwb.GetSheet(sheetCombo.SelectedItem.ToString());





                for (int i = 0; i < hssfsheet.LastRowNum; i++)
                {

                    if (hssfsheet.GetRow(i) != null)
                    {
                        DataRow dr = dt.NewRow();
                        dt.Rows.Add(dr);

                        for (int j = 0; j < hssfsheet.GetRow(i).LastCellNum; j++)
                        {
                            var cell = hssfsheet.GetRow(i).GetCell(j);

                            if (cell != null)
                            {

                                DataColumn dc = new DataColumn();
                                dt.Columns.Add(dc);
                                switch (cell.CellType)
                                {
                                    case NPOI.SS.UserModel.CellType.Numeric:
                                        dr[j] = hssfsheet.GetRow(i).GetCell(j).NumericCellValue;
                                        break;
                                    case NPOI.SS.UserModel.CellType.String:
                                        dr[j] = hssfsheet.GetRow(i).GetCell(j).StringCellValue;
                                        break;
                                    case NPOI.SS.UserModel.CellType.Formula:
                                        dr[j] = hssfsheet.GetRow(i).GetCell(j).CellFormula;
                                        break;
                                }
                            }

                        }
                    }

                }

            }
            else if (filetoread.Extension == ".xlsx")
            {

                //xssfsheet = xssfwb.GetSheet(sheetCombo.SelectedItem.ToString());

                xssfsheet = xssfwb.GetSheetAt(sheetCombo.SelectedIndex);

                if (sheetCombo.SelectedItem.ToString() == "Balance Sheet Worksheet")
                {
                    var range = "B9:B185";
                    var headerRows = CellRangeAddress.ValueOf(range);

                    int count = 0;

                    for (var j = headerRows.FirstRow; j <= headerRows.LastRow; j++)
                    {
                        var row = xssfsheet.GetRow(j);
                        for (var k = headerRows.FirstColumn; k <= headerRows.LastColumn; k++)
                        {
                            if (row.GetCell(k) != null)
                            {
                                string col_name = row.RowNum.ToString() + "_";
                                dt.Columns.Add(new DataColumn(col_name+row.GetCell(k).ToString()));
                              
                            }
                            else
                            {
                                dt.Columns.Add(row.RowNum.ToString() + "_");
                            }
                            //count++;
                        }

                    }

                    for(int i=69;i<=78;i++)
                    {
                        char index = Convert.ToChar(i);

                        range = index + "9:" + index + "185";

                        var rows = CellRangeAddress.ValueOf(range);


                        int datatablecolumn = 0;
                        DataRow newRow = null;

                        newRow = dt.NewRow();
                        dt.Rows.Add(newRow);

                        for (var j=rows.FirstRow;j<=rows.LastRow;j++)
                        {
                            var row = xssfsheet.GetRow(j);

                         
                           

                            for (var k=rows.FirstColumn;k<=rows.LastColumn;k++)
                            {
                                XSSFCell _cell = (XSSFCell)xssfsheet.GetRow(j).GetCell(k);
                                
                                ICell cell = xssfsheet.GetRow(j).GetCell(k);

                              //  IFormulaEvaluator evaluator = xssfwb.GetCreationHelper().CreateFormulaEvaluator();

                                if (cell != null)
                                {
                                    object valorCell = null;

                                    //switch(evaluator.EvaluateFormulaCell(cell))
                                    //{
                                    //    case CellType.Boolean:
                                    //        newRow[datatablecolumn] = xssfsheet.GetRow(j).GetCell(k).BooleanCellValue;
                                    //        break;
                                    //    case CellType.Numeric:
                                    //        newRow[datatablecolumn] = xssfsheet.GetRow(j).GetCell(k).NumericCellValue;
                                    //        break;
                                    //    case CellType.String:
                                    //        newRow[datatablecolumn] = xssfsheet.GetRow(j).GetCell(k).StringCellValue;
                                    //        break;
                                    //    case CellType.Blank:

                                    //        break;
                                    //    case CellType.Error:
                                    //        newRow[datatablecolumn] = xssfsheet.GetRow(j).GetCell(k).ErrorCellValue;
                                    //        break;
                                    //}

                                    switch (cell.CellType)
                                    {
                                        case CellType.Blank: valorCell = DBNull.Value; break;
                                        case CellType.Boolean: valorCell = cell.BooleanCellValue; break;
                                        case CellType.String: valorCell = cell.StringCellValue; break;
                                        case CellType.Numeric:
                                            if (HSSFDateUtil.IsCellDateFormatted(cell)) { valorCell = cell.DateCellValue; }
                                            else { valorCell = cell.NumericCellValue; }
                                            break;
                                        case CellType.Formula:
                                            switch (cell.CachedFormulaResultType)
                                            {
                                                case CellType.Blank: valorCell = DBNull.Value; break;
                                                case CellType.String: valorCell = cell.StringCellValue; break;
                                                case CellType.Boolean: valorCell = cell.BooleanCellValue; break;
                                                case CellType.Numeric:
                                                    if (HSSFDateUtil.IsCellDateFormatted(cell)) { valorCell = cell.DateCellValue; }
                                                    else { valorCell = cell.NumericCellValue; }
                                                    break;
                                            }
                                            break;
                                        default: valorCell = cell.StringCellValue; break;
                                    }

                                    newRow[datatablecolumn] = valorCell;
                                }

                                    // newRow[datatablecolumn] = xssfsheet.GetRow(j).GetCell(k).NumericCellValue;

                                    //newRow[datatablecolumn] = formaleval.Evaluate(cell).FormatAsString();

                                 
                                 else
                                {
                                    //if(row.RowNum==15)
                                    //{
                                    //    break;
                                    //}
                                    newRow[datatablecolumn] = string.Empty;
                                }

                                datatablecolumn++;
                            }
                        }

                    }


                    //    for (int i=0;i<xssfsheet.LastRowNum;i++)
                    //{
                    //    if(xssfsheet.GetRow(i)!=null)
                    //    {
                    //        DataRow dr = dt.NewRow();
                    //        dt.Rows.Add(dr);


                    //        for (int j = 0; j < xssfsheet.GetRow(i).Cells.Count; j++)
                    //        {
                    //            var cell = xssfsheet.GetRow(i).GetCell(j);

                    //            if (cell != null)
                    //            {
                    //                DataColumn dc = new DataColumn();
                    //                dt.Columns.Add(dc);

                    //                switch (cell.CellType)
                    //                {
                    //                    case NPOI.SS.UserModel.CellType.Numeric:
                    //                        dr[j] = xssfsheet.GetRow(i).GetCell(j).NumericCellValue;
                    //                        break;
                    //                    case NPOI.SS.UserModel.CellType.String:
                    //                       dr[j] = xssfsheet.GetRow(i).GetCell(j).StringCellValue;
                    //                        break;
                    //                    case NPOI.SS.UserModel.CellType.Formula:
                    //                        dr[j] = xssfsheet.GetRow(i).GetCell(j).CellFormula;
                    //                        break;
                    //                }
                    //            }

                    //        }
                    //    }
                    //}



                }

                dataGrid.ItemsSource = new DataView(dt);




            }
        }

        private void dataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            string s = (string)e.Column.Header;
            string changed_header;
            int index = s.IndexOf('_');

            if (s.Length > index + 1)
            {
                changed_header = s.Replace(s, s.Remove(0, index + 1));
                e.Column.Header = changed_header;

            }
        }
    }
}
