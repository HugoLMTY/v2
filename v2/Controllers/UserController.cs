using System;
using System.Collections.Generic;
using System.Dynamic;
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
            using (DB_YnovEntities db = new DB_YnovEntities())
            {

                dynamic profilInfos = new ExpandoObject();


                

                profilInfos.basket = db.T_Basket.Where(x => x.id_user == T_User.activeUser).ToList();
                profilInfos.selling = db.T_Product.Where(y => y.id_user == T_User.activeUser).ToList();

                

                return View(profilInfos);
            }
        }

        public static string getSellingStatus(int id)
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                //T_Basket status = db.T_Basket.SqlQuery(
                //    "select status_basket from T_Basket where id_user = 9").FirstOrDefault();
                return "Pending";
            }
        }

        #region Conn user

        public ActionResult Autherize(T_User model)
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                var userInfos = db.T_User.Where(x => x.mail_user == model.mail_user && x.pword_user == model.pword_user).FirstOrDefault();
                if (userInfos == null)
                {
                    //Pas connecté
                    model.loginErrorMessage = "Mail ou mot de passe incorrect.";
                    return View("Connexion");
                }
                else
                {
                    //Connecté
                    Session["CurrentUser"] = userInfos.id_user;
                    Session["CurrentNameUser"] = userInfos.firstname_user + " " + userInfos.name_user;


                    HttpCookie userId = new HttpCookie("KeepUser");
                    userId.Value = userInfos.id_user.ToString();
                    Response.Cookies.Add(userId);

                    T_User.activeUser = userInfos.id_user;
                    T_User.typeUser = userInfos.type_user;

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

        #endregion


        public ActionResult BasketDetails(int obj)
        {
            using (DB_YnovEntities db = new DB_YnovEntities())
            {
                ViewBag.ActiveBasket = obj;
                IEnumerable<T_Product> query = db.T_Product.SqlQuery(
                    "select * from T_Product pro where pro.id_product in (select id_product from T_Basketitem where id_basket = ( select id_basket from T_User where id_user = " + T_User.activeUser + " ))"
                    ).ToList();

                return View("BasketDetails", query);
            }
        }

        public PartialViewResult SellingList()
        {
            return PartialView();
        }

    }





}