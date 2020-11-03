using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v2.Models
{
    public class Cls_Basket
    {
        private int _ID_Basket;
        public int ID_Basket
        { get => _ID_Basket; set => _ID_Basket = value; }


        private int _Qty_Basket;
        public int Qty_Basket
        { get => _Qty_Basket; set => _Qty_Basket = value; }


        private int _ID_User;
        public int ID_User
        { get => _ID_User; set => _ID_User = value; }


        private string _Status_Basket;
        public string Status_Basket
        { get => _Status_Basket; set => _Status_Basket = value; }
    }
}