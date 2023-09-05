using System;
using System;
using System;
using System;
using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorktileTasks
{
    public static class CsvCreator
    {
        public static DataTable createDataTable()
        {
            // this method creates a data table
            DataTable myDataTable = new();

            myDataTable.Columns.Add("Name", typeof(string));
            myDataTable.Columns.Add("Date", typeof(string));
            myDataTable.Columns.Add("Description", typeof(string));
            myDataTable.Columns.Add("Duration", typeof(string));

            myDataTable.Rows.Add("任务名称", DateTime.Today.ToString("yyyy/MM/dd"), "工时描述", "8");
            //myDataTable.Rows.Add("2021-02-23", "This is a blog post", "Joe");
            //myDataTable.Rows.Add("1957-03-05", "There and back again", "Bilbo Baggins");
            //myDataTable.Rows.Add("2000-01-01", "That's no moon", "Obi-Wan Kenobi");

            return myDataTable;
        }
        public static void ToCSV(this DataTable dtDataTable, string strFilePath)
        {
            UTF8Encoding utf8 = new(true);
            StreamWriter sw = new(strFilePath, false, utf8);
            //headers    
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                sw.Write(dtDataTable.Columns[i]);
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dtDataTable.Rows)
            {
                for (int i = 0; i < dtDataTable.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string value = dr[i].ToString();
                        if (value.Contains(','))
                        {
                            value = string.Format("\"{0}\"", value);
                            sw.Write(value);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString());
                        }
                    }
                    if (i < dtDataTable.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }
    }
}
