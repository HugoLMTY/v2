using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace v2.Models
{
    public class Cls_Product
    {
        private int _ID_Product;
        public int ID_Product
        { get => _ID_Product; set => _ID_Product = value; }


        private string _Name_Product;
        public string Name_Product
        { get => _Name_Product; set => _Name_Product = value; }


        private int _Qty_Product;
        public int Qty_Product
        { get => _Qty_Product; set => _Qty_Product = value; }


        private string _Color_Product;
        public string Color_Product
        { get => _Color_Product; set => _Color_Product = value; }


        private int _Price_Product;
        public int Price_Product
        { get => _Price_Product; set => _Price_Product = value; }


        private string _Desc_Product;
        public string Desc_Product
        { get => _Desc_Product; set => _Desc_Product = value; }


        private int _ID_Imgproduct;
        public int ID_Imgroduct
        { get => _ID_Imgproduct; set => _ID_Imgproduct = value; }


        private string _Type_Product;
        public string Type_Product
        { get => _Type_Product; set => _Type_Product = value; }


        private float _Height_Product;
        public float Height_Product
        { get => _Height_Product; set => _Height_Product = value; }


        private float _Lenght_Product;
        public float Lenght_Product
        { get => _Lenght_Product; set => _Lenght_Product = value; }


        private float _Width_Product;
        public float Width_Product
        { get => _Width_Product; set => _Width_Product = value; }
    }
}