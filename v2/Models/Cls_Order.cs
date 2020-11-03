using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v2.Models
{
    public class Cls_Order
    {
        private int _ID_Order;
        public int ID_Order
        { get => _ID_Order; set => _ID_Order = value; }


        private string _Request_Order;
        public string Request_Order
        { get => _Request_Order; set => _Request_Order = value; }


        private string _Comment_Order;
        public string Comment_Order
        { get => _Comment_Order; set => _Comment_Order = value; }


        private string _Filepath_Order;
        public string Filepath_Order
        { get => _Filepath_Order; set => _Filepath_Order = value; }


        private string _Status_Order;
        public string Status_Order
        { get => _Status_Order; set => _Status_Order = value; }
    }
}