using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using provisioner.codelibrary.utils;

namespace provisioner.codelibrary.database {
    class DbEntity {
        public void createDatabaseFile() {
            try {
                if (!Directory.Exists("c:\\TouchNPay")) {
                    DirectoryInfo dir = Directory.CreateDirectory("c:\\TouchNPay");
                    //Directory.CreateDirectory dir = new Directory();
                }
                string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) + "c:\\TouchNPay", provisioner.Properties.Resources.DBName);
                if (!File.Exists(path)) {
                    SQLiteConnection.CreateFile(path);
                }
                FileInfo f = new FileInfo(path);
                string fullname = f.FullName;
            } catch (Exception e) {
                //YuCk Yea!! Error there.
                //MessageBox.Show(e.ToString(), "Thats an Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private SQLiteConnection _generateCon() {
            string path = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) + "c:\\TouchNPay", provisioner.Properties.Resources.DBName);
            SQLiteConnection con = new SQLiteConnection("data source=" + path);
            return con;
        }
        private SQLiteCommand _generateCom(SQLiteConnection con) {
            return new SQLiteCommand(con);
        }
        public void createTables() {
            string staffs = @"CREATE TABLE IF NOT EXISTS `staffs` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `staffID` TEXT UNIQUE, `fullname` TEXT, `cardSerial` TEXT, `status` INTEGER DEFAULT 1, `staffType` TEXT, `location` TEXT, `department` TEXT, `designation` TEXT, `synced` INTEGER Default 0)";
            string cards = @"CREATE TABLE IF NOT EXISTS `cards` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `cardSerial` TEXT UNIQUE, `assigned` INTEGER DEFAULT 0, `valid` INTEGER DEFAULT 1, `issuerID` INTEGER, `dateCreated` TEXT, `dateSynced` TEXT, `staffI` TEXT UNIQUE, `synced` INTEGER Default 0)";
            string admin = @"CREATE TABLE IF NOT EXISTS `admin` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `fullname` TEXT, `email` TEXT, `phone` TEXT, `username` TEXT, `password` TEXT, `publicKey` TEXT, `lastseen` TEXT, `gender` TEXT, `address` TEXT)";
           string duplicateCards = @" CREATE TABLE IF NOT EXISTS `duplicateCards`( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `cardSerial` TEXT UNIQUE, `assigned` INTEGER DEFAULT 0, `valid` INTEGER DEFAULT 1, `issuerID` INTEGER, `dateCreated` TEXT, `dateSynced` TEXT, `staffI` TEXT UNIQUE, `synced` INTEGER DEFAULT 0)";
            string duplicateStaff = @"CREATE TABLE IF NOT EXISTS `duplicateStaffs` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `staffID` TEXT UNIQUE, `fullname` TEXT, `cardSerial` TEXT, `status` INTEGER DEFAULT 1, `staffType` TEXT, `location` TEXT, `department` TEXT, `designation` TEXT, `synced` INTEGER Default 0)";
            string usertype = @"CREATE TABLE IF NOT EXISTS `usertypes` ( `id` INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, `name` TEXT, `userTypeID` TEXT UNIQUE )";
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = staffs;
                command.ExecuteNonQuery();
                command.CommandText = cards;
                command.ExecuteNonQuery();
                command.CommandText = admin;
                command.ExecuteNonQuery();
                command.CommandText = duplicateCards;
                command.ExecuteNonQuery();
                command.CommandText = usertype;
                command.ExecuteNonQuery();
                command.CommandText = duplicateStaff;
                command.ExecuteNonQuery();
                con.Close();
            } catch (Exception e) {
                //YuCk Yea!! Another Error there. muuuuuuuu!!!!!!!!!
                //File.Delete(@"Revive.sqlite");
                // MessageBox.Show(e.ToString(), "Thats an Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public bool execQuery(String statement) {
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = statement;
                command.ExecuteNonQuery();
                //con.Close();
                return true;
            } catch (Exception) {
                //Console.Write(rt.ToString());
                //MessageBox.Show(rt.ToString(), "Thats an Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public int colExists(string statement) {
            int t = 0;
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = statement;
                command.ExecuteNonQuery();
                SQLiteDataReader fetch = command.ExecuteReader();
                while (fetch.Read()) {
                    t++;
                }
                con.Close();
                return t;
            } catch (Exception Exc) {
                MessageBox.Show(Exc.ToString(), "Thats an Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return 0;
            }
        }
        public strFormater writeCards(string statement) {
            var data = new strFormater();
            var cardSerial = new List<string>();
            var dateCreated = new List<string>();
            var staffI = new List<string>();
            var issuerID = new List<string>();
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = statement;
                SQLiteDataReader fetch = command.ExecuteReader();
                while (fetch.Read()) {
                    cardSerial.Add(fetch["cardSerial"].ToString());
                    dateCreated.Add(fetch["dateCreated"].ToString());
                    staffI.Add(fetch["staffI"].ToString());
                    issuerID.Add("HonWell");
                    data.getCardsObj(cardSerial.ToArray(), dateCreated.ToArray(), staffI.ToArray(), issuerID.ToArray());
                }
                con.Close();
                return data;
            } catch (Exception Exv) {
                return data;
            }
        }
        public strFormater writeStaffs(string sql) {
            var data = new strFormater();
            var designation = new List<string>();
            var department = new List<string>();
            var location = new List<string>();
            var stafftype = new List<string>();
            var fullname = new List<string>();
            var cardSerial = new List<string>();
            var dateCreated = new List<string>();
            var staffID = new List<string>();
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = sql;
                SQLiteDataReader fetch = command.ExecuteReader();
                while (fetch.Read()) {
                    if (!string.IsNullOrEmpty(fetch["cardSerial"].ToString())) {
                        cardSerial.Add(fetch["cardSerial"].ToString());
                        designation.Add(fetch["designation"].ToString());
                        department.Add(fetch["department"].ToString());
                        location.Add(fetch["location"].ToString());
                        stafftype.Add(fetch["stafftype"].ToString());
                        fullname.Add(fetch["fullname"].ToString());
                        staffID.Add(fetch["staffID"].ToString());
                        
                    }
                }
                data.getStaffsObj(cardSerial.ToArray(), designation.ToArray(), department.ToArray(), location.ToArray(), stafftype.ToArray(), fullname.ToArray(), staffID.ToArray());
                con.Close();
                return data;
            } catch (Exception Exv) {
                return data;
            }
        }
        public dataTable getStaffs(string sql) {
            var data = new dataTable();
            var designation = new List<string>();
            var department = new List<string>();
            var location = new List<string>();
            var stafftype = new List<string>();
            var fullname = new List<string>();
            var cardSerial = new List<string>();
            var dateCreated = new List<string>();
            var staffID = new List<string>();
            var synced = new List<string>();
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = sql;
                SQLiteDataReader fetch = command.ExecuteReader();
                while (fetch.Read()) {
                    if (true) {
                        cardSerial.Add(fetch["cardSerial"].ToString());
                        designation.Add(fetch["designation"].ToString());
                        department.Add(fetch["department"].ToString());
                        location.Add(fetch["location"].ToString());
                        stafftype.Add(fetch["stafftype"].ToString());
                        fullname.Add(fetch["fullname"].ToString());
                        staffID.Add(fetch["staffID"].ToString());
                        synced.Add(fetch["synced"].ToString());
                    }
                }
                data.getStaffs(cardSerial.ToArray(), designation.ToArray(), department.ToArray(), location.ToArray(), stafftype.ToArray(), fullname.ToArray(), staffID.ToArray(), synced.ToArray());
                con.Close();
                return data;
            } catch (Exception Exv) {
                return data;
            }
        }
        public bool doMagic() {
            bool v = false;
            string sql = "select*from cards";
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = sql;
                SQLiteDataReader fetch = command.ExecuteReader();
                while (fetch.Read()) {
                    string staffI = fetch["staffI"].ToString();
                    string serial = fetch["cardSerial"].ToString();
                    staffI = staffI.Replace(" ", "");
                    string sql2 = "update cards set staffI = '"+staffI+"' where cardSerial = '"+serial+"'";
                    SQLiteCommand command2 = _generateCom(con);
                    command2.CommandText = sql2;
                    SQLiteDataReader H = command2.ExecuteReader();
                }
            } catch (Exception e) {

            }
                    return v;
        }
        public dataTable getCards(string statement) {
            var data = new dataTable();
            var cardSerial = new List<string>();
            var dateCreated = new List<string>();
            var staffI = new List<string>();
            var issuerID = new List<string>();
            var synced = new List<string>();
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = statement;
                SQLiteDataReader fetch = command.ExecuteReader();
                while (fetch.Read()) {
                    cardSerial.Add(fetch["cardSerial"].ToString());
                    dateCreated.Add(fetch["dateCreated"].ToString());
                    staffI.Add(fetch["staffI"].ToString());
                    synced.Add(fetch["synced"].ToString());
                    issuerID.Add("HonWell");
                    data.getCards(cardSerial.ToArray(), dateCreated.ToArray(), staffI.ToArray(), issuerID.ToArray(), synced.ToArray());
                }
                con.Close();
                return data;
            } catch (Exception Exv) {
                return data;
            }
        }
        public dataTable fetchAdminprofile(string sql) {
            string username = string.Empty;
            string key = string.Empty;
            string fullname = string.Empty;
            dataTable data = new dataTable();
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = sql;
                SQLiteDataReader fetch = command.ExecuteReader();
                while (fetch.Read()) {
                    username = fetch["username"].ToString();
                    key = fetch["publicKey"].ToString();
                    fullname = fetch["fullname"].ToString();
                }
                data.getAdminProfile(username, key, fullname);
                return data;
            } catch (Exception) {

            }return data;
        }
        public dataTable fetchUserTypes(string sql) {
            var data = new dataTable();
            var usertype = new List<string>();
            var usertypeID = new List<string>();
            try {
                SQLiteConnection con = _generateCon();
                SQLiteCommand command = _generateCom(con);
                con.Open();
                command.CommandText = sql;
                SQLiteDataReader fetch = command.ExecuteReader();
                while (fetch.Read()) {
                    usertype.Add(fetch["name"].ToString());
                    usertypeID.Add(fetch["userTypeID"].ToString());
                    data.getUsertype(usertype.ToArray(), usertypeID.ToArray());
                }
                con.Close();
                return data;
            } catch (Exception Exv) {
                return data;
            }
        }

    }
}
