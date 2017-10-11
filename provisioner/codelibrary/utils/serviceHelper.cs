using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Newtonsoft.Json.Linq;
using provisioner.codelibrary.database;

namespace provisioner.codelibrary.utils {
    class serviceHelper {
        private static string data;

        public static async Task<String> PostFormUrlEncoded<TResult>(string url, IEnumerable<KeyValuePair<string, string>> postData) {
            using (var httpClient = new HttpClient()) {
                using (var content = new FormUrlEncodedContent(postData)) {
                    content.Headers.Clear();
                    content.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    try {
                        //content = WebUtility.UrlEncode(content);
                        HttpResponseMessage response = await httpClient.PostAsync(url, content);
                        return await response.Content.ReadAsStringAsync();
                    } catch(Exception e) {
                        return null;
                    }
                }
            }
        }

        public bool verifyUser() {
            string sql = "select * from admin";
            DbEntity db = new DbEntity();
            db.createDatabaseFile();
            db.createTables();
            return (db.colExists(sql)>0)? true :false;
        }
        public static void syncCard(string username, string publicKey, string cardObj) {
            try {
                cardObj = string.IsNullOrEmpty(cardObj) ? "{\"cards\":[]}" : cardObj;
                //cardObj = WebUtility.UrlEncode(cardObj);
                var URL = provisioner.Properties.Resources.apiURL.ToString() + "admin/sync/cardDetails";
                List<KeyValuePair<String, String>> values = new List<KeyValuePair<String, String>>();
                KeyValuePair<String, String> user = new KeyValuePair<string, string>("username", username);
                KeyValuePair<String, String> key = new KeyValuePair<string, string>("publicKey", publicKey);
                KeyValuePair<String, String> cards = new KeyValuePair<string, string>("cards", cardObj);
                values.Add(user);
                values.Add(key);
                values.Add(cards);
                string x = (Task.Run(async () => await PostFormUrlEncoded<string>(URL, values))).Result;
                JObject serverResponse = JObject.Parse(x);
                string error = serverResponse["error"].ToString();
                if (int.Parse(JObject.Parse(error)["status"].ToString()) == 0) {
                    try {
                        string duplicates = serverResponse["content"]["data"]["duplicate"].ToString();
                        string success = serverResponse["content"]["data"]["successful"].ToString();
                        string failed = serverResponse["content"]["data"]["failed"].ToString();
                        string card = serverResponse["content"]["cards"].ToString();
                        JArray dups = JArray.Parse(duplicates);
                        JArray succ = JArray.Parse(success);
                        JArray fail = JArray.Parse(failed);
                        JArray car = JArray.Parse(card);
                        int counter = 0;
                        string sql = "";
                        DbEntity db = new database.DbEntity();
                        for(counter = 0; counter < dups.ToArray().Length; counter++) {
                            sql = "update cards set synced = 1 where cardSerial = '" + dups[counter] + "'";
                            db.execQuery(sql);
                        }
                        for (counter = 0; counter < succ.ToArray().Length; counter++) {
                            sql = "update cards set synced = 1 where cardSerial = '" + succ[counter] + "'";
                            db.execQuery(sql);
                        }
                        for (counter = 0; counter < fail.ToArray().Length; counter++) {
                            sql = "insert into duplicateCards (cardSerial) values ('" + fail[counter] + "')";
                            db.execQuery(sql);
                        }
                        for (counter = 0; counter < car.ToArray().Length; counter++) {
                            JObject ncar = JObject.Parse(car[counter].ToString());
                            sql = @"INSERT INTO cards(cardSerial, assigned, dateCreated, staffI, synced)
                            SELECT '" + ncar["cardSerial"].ToString() + "', '"+ ncar["assigned"].ToString() + "', '"+ ncar["dateCreated"].ToString() + "', '"+ ncar["staffI"].ToString() + "', 1  WHERE NOT EXISTS(SELECT id FROM cards WHERE cardSerial = '" + ncar["cardSerial"].ToString() + "' OR staffI = '" + ncar["staffI"].ToString() + "')";
                            //sql = "insert into cards (cardSerial, assigned, dateCreated, staffI, synced) values ('" + ncar["cardSerial"].ToString() + "', '"+ ncar["assigned"].ToString() + "', '"+ ncar["dateCreated"].ToString() + "', '"+ ncar["staffI"].ToString() + "', 1)";
                            try { db.execQuery(sql); } catch (Exception) { }
                        }
                        MessageBox.Show("The Cards were succesfully synced", "Bonum Magnum!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    } catch (Exception emx) {
                        MessageBox.Show(emx.Message, "Exception!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } else {
                    MessageBox.Show(JObject.Parse(error)["message"].ToString(), "Server Response", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } catch (Exception e) {

            }
        }
        public static void syncStaffs(string username, string publicKey, string staffObj) {
            try {
                staffObj = string.IsNullOrEmpty(staffObj) ? "{\"staffs\":[]}" : staffObj;
                var URL = provisioner.Properties.Resources.apiURL.ToString() + "admin/create/staff";
                //staffObj = WebUtility.UrlEncode(staffObj);
                List<KeyValuePair<String, String>> values = new List<KeyValuePair<String, String>>();
                KeyValuePair<String, String> user = new KeyValuePair<string, string>("username", username);
                KeyValuePair<String, String> key = new KeyValuePair<string, string>("publicKey", publicKey);
                KeyValuePair<String, String> staff = new KeyValuePair<string, string>("staffs", staffObj);
                values.Add(user);
                values.Add(key);
                values.Add(staff);
                string x = (Task.Run(async () => await PostFormUrlEncoded<string>(URL, values))).Result;
                JObject serverResponse = JObject.Parse(x);
                string error = serverResponse["error"].ToString();
                if (int.Parse(JObject.Parse(error)["status"].ToString()) == 0) {
                    try {
                        string duplicates = serverResponse["content"]["data"]["duplicate"].ToString();
                        string success = serverResponse["content"]["data"]["successful"].ToString();
                        string staf = serverResponse["content"]["staffs"].ToString();
                        JArray dups = JArray.Parse(duplicates);
                        JArray succ = JArray.Parse(success);
                        JArray staffs = JArray.Parse(staf);
                        int counter = 0;
                        string sql = "";
                        DbEntity db = new database.DbEntity();
                        for (counter = 0; counter < dups.ToArray().Length; counter++) {
                            sql = "update staffs set synced = 1 where staffID = '" + dups[counter] + "'";
                            db.execQuery(sql);
                        }
                        for (counter = 0; counter < succ.ToArray().Length; counter++) {
                            sql = "update staffs set synced = 1 where staffID = '" + succ[counter] + "'";
                            db.execQuery(sql);
                        }
                        for (counter = 0; counter < staffs.ToArray().Length; counter++) {
                            JObject ncar = JObject.Parse(staffs[counter].ToString());
                            sql = @"INSERT INTO staffs(staffID, fullname, cardSerial, location, department, designation, synced)
                            SELECT '" + ncar["staffID"].ToString() + "', '" + ncar["fullname"].ToString() + "', '" + ncar["cardSerial"].ToString() + "', '" + ncar["location"].ToString() + "','" + ncar["department"].ToString() + "', '" + ncar["designation"].ToString() + "', 1  WHERE NOT EXISTS(SELECT id FROM staffs WHERE cardSerial = '" + ncar["cardSerial"].ToString() + "' OR staffID = '" + ncar["staffID"].ToString() + "')";
                            //sql = "insert into cards (cardSerial, assigned, dateCreated, staffI, synced) values ('" + ncar["cardSerial"].ToString() + "', '"+ ncar["assigned"].ToString() + "', '"+ ncar["dateCreated"].ToString() + "', '"+ ncar["staffI"].ToString() + "', 1)";
                            try { db.execQuery(sql); } catch (Exception) { }
                        }
                        MessageBox.Show("The Staffs were succesfully synced", "Bonum Magnum!", MessageBoxButton.OK, MessageBoxImage.Asterisk);
                    } catch (Exception emx) {
                        MessageBox.Show(emx.Message, "Exception!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } else {
                    MessageBox.Show(JObject.Parse(error)["message"].ToString(), "Server Response", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } catch (Exception e) {

            }
        }
        public static bool Login(string username, string password) {
            bool conf = false;
            try {
                /*string path = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) + "c:\\TouchNPay";
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                } else {
                    Directory.Delete(path);
                }*/
                var db = new DbEntity();
                db.createDatabaseFile();
                db.createTables();

            } catch (Exception ex) {
                //MessageBox.Show(ex.ToString());
            }

            try {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyComputer) + "c:\\config\\";
                if (!Directory.Exists(path)) {
                    Directory.CreateDirectory(path);
                }
                //File.Delete(path + @"config.txt");
                var URL = provisioner.Properties.Resources.apiURL.ToString() + "admin/login";
                List<KeyValuePair<String, String>> values = new List<KeyValuePair<String, String>>();
                KeyValuePair<String, String> user = new KeyValuePair<string, string>("username", username);
                KeyValuePair<String, String> pass = new KeyValuePair<string, string>("password", password);
                //KeyValuePair<String, String> device = new KeyValuePair<string, string>("device_code", IMEI);
                values.Add(user);
                values.Add(pass);
                //values.Add(device);
                string x = (Task.Run(async () => await PostFormUrlEncoded<string>(URL, values))).Result;
                JObject serverResponse = JObject.Parse(x);
                string error = serverResponse["error"].ToString();
                if (int.Parse(JObject.Parse(error)["status"].ToString()) == 0) {
                    try {
                        string success = serverResponse["success"].ToString();
                        string content = serverResponse["content"]["data"].ToString();
                        //JObject cont = JObject.Parse(content);
                        JArray objs = JArray.Parse(content);
                        string publicKey = serverResponse["content"]["publicKey"].ToString();
                        string usern = serverResponse["content"]["username"].ToString(); ;
                        string fullname = "";
                        string email = "";
                        string phone = "";
                        string lastseen = "";
                        string gender = "";
                        string address = "";
                        foreach (JObject obj in objs) {
                            fullname = obj["fullname"].ToString();
                            email = obj["email"].ToString();
                            phone = obj["phone"].ToString();
                            gender = obj["gender"].ToString();
                            address = obj["address"].ToString();
                            lastseen = obj["lastseen"].ToString();
                        }
                        string sql = "insert into admin (username, publicKey, fullname, email, phone, lastseen, gender, address) values ('"+usern+ "', '" + publicKey + "', '" + fullname + "', '" + email + "', '" + phone + "', '" + lastseen + "', '" + gender + "', '" + address + "')";
                        DbEntity db = new DbEntity();
                        db.execQuery(sql);
                        conf = true;
                    } catch (Exception emx) {
                        MessageBox.Show(emx.Message, "Exception!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                } else {
                    MessageBox.Show("Access Denied. Incorrect username or password", "Server Response", MessageBoxButton.OK, MessageBoxImage.Error);
                    conf = false;
                }
            } catch (Exception Ex) {
                MessageBox.Show(Ex.Message, "Remote Connection error", MessageBoxButton.OK, MessageBoxImage.Error);
                conf = false;
            }
            return conf;
        }
        public static bool trySyncUserTypes(string a, string b) {
            var requestUriString = provisioner.Properties.Resources.apiURL.ToString() + "admin/get/userType/-";
            if (b.Length <= 1 || a.Length <= 1)
                return false;
            try {
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(requestUriString);
                httpWebRequest.Method = "GET";
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Headers.Add("username", a);
                httpWebRequest.Headers.Add("publicKey", b);
                using (Stream responseStream = httpWebRequest.GetResponse().GetResponseStream()) {
                    using (StreamReader streamReader = new StreamReader(responseStream)) {
                        //model.model mod = new model.model();
                        //mod.execQuery("delete from company where id > 0");
                        data = streamReader.ReadToEnd().ToString();
                    }
                }
                JObject serverResponse = JObject.Parse(data);
                string error = serverResponse["error"].ToString();
                if (int.Parse(JObject.Parse(error)["status"].ToString()) == 0) {
                    string success = serverResponse["success"].ToString();
                    string content = serverResponse["content"]["data"].ToString();
                    //JObject cont = JObject.Parse(content);
                    DbEntity db = new DbEntity();
                    JArray objs = JArray.Parse(content);
                    string usertype = string.Empty;
                    string usertypeID = string.Empty;
                    foreach (JObject obj in objs) {
                        usertype = obj["userType"].ToString();
                        usertypeID = obj["id"].ToString();
                        string sql = "insert into usertypes (name, userTypeID) values ('" + usertype + "', '" + usertypeID + "')";
                        try {
                            db.execQuery(sql);
                        } catch (Exception) { }
                    }
                    
                } else {
                    MessageBox.Show(JObject.Parse(error)["message"].ToString(), "Server Response", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
    }
}
