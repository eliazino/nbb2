using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace provisioner.codelibrary.database {
    class dataTable {
        public string adminUname { get; set; }
        public string adminKey { get; set; }
        public string adminFullname { get; set; }
        public string[] cardSerial { get; set; }
        public string[] date { get; set; }
        public string[] staff { get; set; }
        public string[] issuer { get; set; }
        public string[] synced { get; set; }
        public string[] userTypeString { get; set; }
        public string[] userTypeID { get; set; }
        public string[] designation { get; set; }
        public string[] department { get; set; }
        public string[] location { get; set; }
        public string[] stafftype { get; set; }
        public string[] fullname { get; set; }
        public string[] staffID { get; set; }
        public dataTable getAdminProfile(string uname, string key, string fullname) {
            adminUname = uname;
            adminKey = key;
            adminFullname = fullname;
            return new dataTable();
        }
        public dataTable getCards(string[] cardserial, string[] dateTime, string[] staffID, string[] issuerID, string[] sync) {
            cardSerial = cardserial;
            date = dateTime;
            staff = staffID;
            issuer = issuerID;
            synced = sync;
            return new dataTable();
        }
        public dataTable getUsertype(string[] name, string[] id) {
            userTypeString = name;
            userTypeID = id;
            return new dataTable();
        }
        public dataTable getStaffs(string[] cardSeria, string[] designatio, string[] departmen, string[] locatio, string[] stafftyp, string[] fullnam, string[] staffI, string[] synce) {
            cardSerial = cardSeria;
            designation = designatio;
            department = departmen;
            location = locatio;
            stafftype = stafftyp;
            fullname = fullnam;
            staffID = staffI;
            synced = synce;
            return new dataTable();
        }
    }
}
