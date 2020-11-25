using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using v2.Models;

namespace v2.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Index()
        { return RedirectToAction("Index","Home"); }

        public ActionResult Shop()
        { return RedirectToAction("Shop", "Home"); }

        public ActionResult Commands()
        { return RedirectToAction("Commands", "Home"); }

        public ActionResult test()
        { return RedirectToAction("test", "Home"); }


        public ActionResult Connexion()
        { return View(); }
        public ActionResult CreateAccount()
        { return View(); }
        public ActionResult Profil()
        {
            getBasketList();
            return View(); 
        }

        public ActionResult BasketDetails(int obj)
        {
            getBasketItemList(obj);
            return View();
        }


        public ActionResult Autherize(T_User model)
        {
            using(DB_YnovEntities db = new DB_YnovEntities())
            {
                var userInfos = db.T_User.Where(x => x.mail_user == model.mail_user && x.pword_user == model.pword_user).FirstOrDefault();
                if (userInfos == null)
                {
                    //Pas connecté
                    model.loginErrorMessage = "Mail ou mot de passe incorrect.";
                    return View("Connexion", model);
                }
                else
                {
                    //Connecté
                    Session["CurrentUser"] = userInfos.id_user;
                    Session["CurrentNameUser"] = userInfos.firstname_user + " " + userInfos.name_user;


                    HttpCookie userId = new HttpCookie("KeepUser");
                    userId.Value = userInfos.id_user.ToString();
                    Response.Cookies.Add(userId);

                    userInfos.id_activeUser = userInfos.id_user;

                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult AddUser(T_User model)
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                var checkUser = db.T_User.Where(x => x.mail_user == model.mail_user).FirstOrDefault();
                if (checkUser != null)
                {
                    //Compte pas créé
                    Session["mailState"] = "Mail déjà utilisé";
                    return RedirectToAction("CreateAccount", "User");
                }
                else
                {
                    //Compte créé
                    T_User userInfos = new T_User();

                    userInfos.firstname_user = model.firstname_user;
                    userInfos.name_user = model.name_user;
                    userInfos.type_user = 1;
                    userInfos.mail_user = model.mail_user;
                    if (model.age_user != null)
                        userInfos.age_user = model.age_user;
                    userInfos.tel_user = model.tel_user;
                    userInfos.adress_user = model.adress_user;
                    userInfos.pword_user = model.pword_user;

                    db.T_User.Add(userInfos);
                    db.SaveChanges();

                    Session["CreateState"] = true;
                    Session["CreateMail"] = model.mail_user;
                    Session["CreatePword"] = model.pword_user;

                    return RedirectToAction("Connexion", "User");
                }
            }
        }


        public ActionResult Disconnect()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public static void getBasketList()
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                List<T_Basket> basketList = new List<T_Basket>();

                IEnumerable<T_Basket> dbBasketlist;
                dbBasketlist = db.T_Basket.ToList();

                foreach (var item in dbBasketlist)
                {
                    T_Basket basketInfos = new T_Basket();

                    basketInfos.id_basket = item.id_basket;
                    basketInfos.date_basket = item.date_basket;
                    basketInfos.qty_basket = item.qty_basket;
                    basketInfos.price_basket = item.price_basket;
                    basketInfos.id_user = item.id_user;
                    basketInfos.status_basket = item.status_basket;

                    basketList.Add(basketInfos);
                }
                T_Basket.basketList = basketList;
            }
        }

        public void getBasketItemList(int obj)
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                List<T_Basketitem> itemList = new List<T_Basketitem>();
                List<T_Product> productList = new List<T_Product>();

                IEnumerable<T_Basketitem> dbItemList;
                IEnumerable<T_Product> dbProductList;

                dbItemList = db.T_Basketitem.Where(x => x.id_basket == obj);

                foreach (var item in dbItemList)
                {
                    T_Basketitem itemInfos = new T_Basketitem();

                    dbProductList = db.T_Product.Where(x => x.id_product == item.id_product);

                    foreach (var product in dbProductList)
                    {
                        T_Product productInfos = new T_Product();

                        productInfos.id_product = product.id_product;
                        productInfos.name_product = product.name_product;
                        productInfos.qty_product = product.qty_product;
                        productInfos.color_product = product.color_product;
                        productInfos.price_product = product.price_product;
                        productInfos.desc_product = product.desc_product;
                        productInfos.id_imgproduct = product.id_imgproduct;
                        productInfos.type_product = product.type_product;
                        productInfos.height_product = product.height_product;
                        product.lenght_product = product.height_product;
                        product.width_product = product.width_product;

                        productList.Add(productInfos);
                    }

                    itemInfos.id_basketitem = item.id_basketitem;
                    itemInfos.id_basket = item.id_basket;
                    itemInfos.id_product = item.id_product;
                    itemInfos.qty_basketitem = item.qty_basketitem;

                    itemList.Add(itemInfos);
                }
                T_Basketitem.id_activeBasket = obj;
                T_Basketitem.basketitemList = itemList;
                T_Basketitem.basketProductList = productList;
            }
        }
    }





}