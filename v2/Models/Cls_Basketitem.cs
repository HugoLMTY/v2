using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v2.Models
{
    public class Cls_Basketitem
    {
        private int _ID_Basketitem;
        public int ID_Basketitem
        { get => _ID_Basketitem; set => _ID_Basketitem = value; }


        private int _ID_Basket;
        public int ID_Basket
        { get => _ID_Basket; set => _ID_Basket = value; }


        private int _ID_Product;
        public int ID_Product
        { get => _ID_Product; set => _ID_Product = value; }


        private int _Qty_Product;
        public int Qty_Product
        { get => _Qty_Product; set => _Qty_Product = value; }


        private int _Price_Product;
        public int Price_Product
        { get => _Price_Product; set => _Price_Product = value; }

    }
}