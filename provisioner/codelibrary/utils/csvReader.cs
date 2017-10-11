using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using provisioner.codelibrary.database;
using System.Windows;

namespace provisioner.codelibrary.utils {
    class csvReader {
        private string unprocessed;
        private StreamReader sreader;
        public void getFile(string filePath, string usert) {
            if (File.Exists(filePath)){
                StreamReader sr = new StreamReader(filePath);
                unprocessed = sr.ReadLine();
                sreader = sr;
                string[] value = unprocessed.Split(',');
                DataTable dt = new DataTable();
                DataRow row;
                foreach (string dc in value) {
                    try {
                        dt.Columns.Add(new DataColumn(dc));
                    }catch(Exception e) {

                    }
                }
                DbEntity db = new DbEntity();
                int counter = 0;
                int duplicates = 0;
                while (!sreader.EndOfStream) {
                    value = sreader.ReadLine().Split(',');
                    if (true) {//value.Length == dt.Columns.Count) {
                        string fullname = value[5].ToString() + " " + value[3] + " " + value[4];
                        fullname = fullname.Replace("'", "").Replace("\"", "");
                        string staffID = value[0];
                        string location = value[1].Replace("'", "").Replace("\"", "");
                        string department = value[2].Replace("'","").Replace("\"","");
                        string desig = "N/S";
                        string sql = "insert into staffs (fullname, staffID, location, department, designation, staffType) values ('"+fullname+ "', '" + staffID + "', '" + location + "', '" + department + "', '" + desig + "', '" + usert + "')";
                        if (db.execQuery(sql)) {

                        }else {
                            duplicates++;
                            sql = "insert into duplicateStaffs (fullname, staffID, location, department, designation, staffType) values ('" + fullname + "', '" + staffID + "', '" + location + "', '" + department + "', '" + desig + "', '" + usert + "')";
                            db.execQuery(sql);
                        }
                    }
                    counter++;
                }
                MessageBox.Show(counter.ToString()+" Total,  "+duplicates.ToString()+" duplicates were ignored!", "Upload Finished", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            } else {
                MessageBox.Show("The file path is invalid / unavailable. It might have been deleted or moved.", "File Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
        public void reader() {
            string[] value = unprocessed.Split(',');
            DataTable dt = new DataTable();
            DataRow row;
            foreach (string dc in value) {
                dt.Columns.Add(new DataColumn(dc));
            }

            while (!sreader.EndOfStream) {
                value = sreader.ReadLine().Split(',');
                if (value.Length == dt.Columns.Count) {
                    row = dt.NewRow();
                    row.ItemArray = value;
                    dt.Rows.Add(row);
                }
            }
        }
    }
}
