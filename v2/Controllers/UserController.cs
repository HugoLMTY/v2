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
        { return View(); }


        public ActionResult Autherize(T_User model)
        {
            using(DB_YnovEntities db = new DB_YnovEntities())
            {
                var userInfos = db.T_User.Where(x => x.mail_user == model.mail_user && x.pword_user == model.pword_user).FirstOrDefault();
                if (userInfos == null)
                {
                    model.loginErrorMessage = "Mail ou mot de passe incorrect.";
                    return View("Connexion", model);
                }
                else
                {
                    Session["CurrentUser"] = userInfos.id_user;
                    Session["CurrentNameUser"] = userInfos.firstname_user + " " + userInfos.name_user;
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
                    Session["CreateState"] = true;
                    Session["CreateMail"] = model.mail_user;
                    Session["CreatePword"] = model.pword_user;
                    db.SaveChanges();
                    return RedirectToAction("Connexion", "User");
                }
            }
        }


        public ActionResult Disconnect()
        {
            Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}