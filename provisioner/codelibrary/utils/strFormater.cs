using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace provisioner.codelibrary.utils {
    class strFormater {
        public string mObj { get; set; }
        public string  cardObjs { get; set; }
        public string[] cardSerial { get; set; }
        public string[] date { get; set; }
        public string[] staff { get; set; }
        public string[] issuer { get; set; }
        public string staffsObj { get; set; }
        public string designation { get; set; }
        public string department { get; set; }
        public string location { get; set; }
        public string stafftype { get; set; }
        public string fullname { get; set; }
        public string staffID { get; set; }
        public string staffObjs { get; set; }
        public strFormater getCardsObj(string[] cardSerial, string[] date, string[] staff, string[] issuer) {
            if (cardSerial.Length > 0) {
                JObject bulkObject = new JObject();
                JArray cardsArray = new JArray();
                for (int s = 0; s < cardSerial.Length; s++) {
                    JObject transactionObject = new JObject();
                    transactionObject.Add("cardSerial", cardSerial[s]);
                    transactionObject.Add("issuerID", issuer[s]);
                    transactionObject.Add("staffID", staff[s]);
                    transactionObject.Add("dateCreated", date[s]);
                    cardsArray.Add(transactionObject);
                }
                bulkObject.Add("data", cardsArray);
                cardObjs = bulkObject.ToString();
            }
            return new strFormater();
        }
        public strFormater getStaffsObj(string[] cardSerial, string[] designation, string[] department, string[] location, string[] stafftype, string[] fullname, string[] staffID) {
            if (cardSerial.Length > 0) {
                JObject bulkObject = new JObject();
                JArray staffsArray = new JArray();
                for (int s = 0; s < cardSerial.Length; s++) {
                    JObject transactionObject = new JObject();
                    transactionObject.Add("name", fullname[s]);
                    transactionObject.Add("cardSerial", cardSerial[s]);
                    transactionObject.Add("staffID", staffID[s]);
                    transactionObject.Add("staffType", stafftype[s]);
                    transactionObject.Add("location", location[s]);
                    transactionObject.Add("designation", designation[s]);
                    transactionObject.Add("department", department[s]);
                    staffsArray.Add(transactionObject);
                }
                bulkObject.Add("data", staffsArray);
                staffObjs = bulkObject.ToString();
            }
            return new strFormater();
        }
        public strFormater setParams(string[] iamount, string[] icardCFee, string[] icBalance, string[] icDate, string[] itcode, string[] ideviceCF, string[] ityp, string[] icomp_name, string[] bill_id, string[] iserial, string[] deviceID, string[] agentID) {
            if (iamount.Length > 0) {
                JObject bulkObject = new JObject();
                JArray transactionsArray = new JArray();
                for (int s = 0; s < iamount.Length; s++) {
                    JObject transactionObject = new JObject();
                    transactionObject.Add("amount", iamount[s]);
                    transactionObject.Add("card_charge_fee", icardCFee[s]);
                    transactionObject.Add("card_balance", icBalance[s]);
                    //System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                    //dtDateTime = dtDateTime.AddSeconds(Double.Parse(icDate[s])).ToLocalTime();
                    string date = icDate[s].ToString();

                    transactionObject.Add("created_time", date);
                    transactionObject.Add("transaction_code", itcode[s]);
                    transactionObject.Add("device_charge_fee", ideviceCF[s]);
                    transactionObject.Add("type", "2");
                    JObject meta_data = new JObject();
                    meta_data.Add("bill_id", bill_id[s]);
                    meta_data.Add("user_id", agentID[s]);
                    transactionObject.Add("serial_number", iserial[s]);
                    transactionObject.Add("meta_data", meta_data);
                    transactionsArray.Add(transactionObject);
                }
                bulkObject.Add("bulk_trans", transactionsArray);
                bulkObject.Add("device_id", deviceID[0]);
                bulkObject.Add("holder_id", deviceID[0]);
                bulkObject.Add("vendor_id", agentID[0]);
                mObj = bulkObject.ToString();
            }
            return new strFormater();
        }
    }
}
