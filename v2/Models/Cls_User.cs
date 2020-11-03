using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Security.Permissions;
using System.Web;

namespace v2.Models
{
    public class Cls_User
    {
        private int _ID_User;
        public int ID_User
        { get => _ID_User; set => _ID_User = value; }


        private string _Name_User;
        public string Name_User
        { get => _Name_User; set => _Name_User = value; }


        private string _Firstname_User;
        public string Firstname_User
        { get => _Firstname_User; set => _Firstname_User = value; }


        private string _Mail_User;
        public string Mail_User
        { get => _Mail_User; set => _Mail_User = value; }


        private int _Age_User;
        public int Age_User
        { get => _Age_User; set => _Age_User = value; }


        private string _Adress_User;
        public string Adress_User
        { get => _Adress_User; set => _Adress_User = value; }


        private int _Tel_User;
        public int Tel_User
        { get => _Tel_User; set => _Tel_User = value; }

        private string _Pword_User;
        public string Pword_User
        { get => _Pword_User; set => _Pword_User = value; }
    }
}