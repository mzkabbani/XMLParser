using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Common.Classes.Monitoring {
    public static class MonitorObject {

        public static string username="";
        public static List<FormAndAccessTime> formAndAccessTime = new List<FormAndAccessTime>();
        public static DateTime loginTime = new DateTime();
        public static DateTime logoutTime = new DateTime();

        //public static MonitorObject(string user, DateTime login) {
        //    username = user;
        //    loginTime = login;
        //    formAndAccessTime = new List<FormAndAccessTime>();
        //}

    }

    public class FormAndAccessTime {
        public DateTime AccessTime;
        public string formName;

        public FormAndAccessTime(string form, DateTime time) {
            formName = form;
            AccessTime = time;
        }
    }

}
