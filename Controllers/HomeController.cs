using DatabaseIO;
using DatabaseProvider;
using MVCProjectDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProjectDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DBIO db = new DBIO();
            List<account> accountList = db.GetList_Account();

            return View();
        }

        /// <summary>
        /// Thêm một user mới vào DB
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AddAccount(FormCollection data)
        {
            string id = data["id"];
            string username = data["username"];
            string pwd = data["pwd"];
            JsonResult js = new JsonResult();

            if (String.IsNullOrEmpty(id) || String.IsNullOrEmpty(username) || String.IsNullOrEmpty(pwd))
            {
                js.Data = new
                {
                    status = "ER",
                    message = "Không thể bỏ trống dữ liệu!"
                };
            }
            else
            {
                DBIO db = new DBIO();

                account a = new account();
                a.acc_id = Convert.ToInt32(id);
                a.emp_id = Convert.ToInt32(id);
                a.acc_username = username;
                a.acc_password = pwd;
                a.role_id = 5;

                db.AddObject(a);
                db.Save();

                js.Data = new
                {
                    status = "OK"
                };
            }

            return Json(js, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            MyModel myModel = new MyModel();
            myModel.NAME = "MVC DEMO PROJECT";
            myModel.PHONE = "0123456789";
            ViewBag.Message = "Your application description page.";

            return View(myModel);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}