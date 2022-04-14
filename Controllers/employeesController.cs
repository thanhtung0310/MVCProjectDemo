using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseProvider;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using PagedList;

namespace MVCProjectDemo.Controllers
{
    public class employeesController : Controller
    {
        private MyDB db = new MyDB();

        public class HttpParamActionAttribute: ActionNameSelectorAttribute
        {
            public override bool IsValidName(ControllerContext controllerContext, string actionName, MethodInfo methodInfo)
            {
                if (actionName.Equals(methodInfo.Name, StringComparison.InvariantCultureIgnoreCase))
                    return true;

                var request = controllerContext.RequestContext.HttpContext.Request;
                return request[methodInfo.Name] != null;
            }
        }

        //// GET: employees
        //public ActionResult Index()
        //{
        //    return View(db.employees.ToList());
        //}

        //// GET: employees/?searchString=@
        //public ActionResult Index(string searchString)
        //{

        //    var emp = from e in db.employees // lấy toàn bộ liên kết
        //              select e;
        //              //join a in db.accounts on e.emp_id equals a.emp_id
        //              //select new { e.emp_id, e.emp_name, e.emp_dob, a.acc_username, a.acc_password, e.emp_contact_number };

        //    if (!String.IsNullOrEmpty(searchString)) // kiểm tra chuỗi tìm kiếm có rỗng/null hay không
        //    {
        //        emp = emp.Where(s => s.emp_name.Contains(searchString)); //lọc theo chuỗi tìm kiếm
        //    }

        //    return View(emp); //trả về kết quả

        //    //List<employee> listEmp = new List<employee>();
        //    //foreach (var item in emp)
        //    //{
        //    //    employee temp = new employee();
        //    //    temp.emp_id = item.emp_id;
        //    //    temp.emp_name = item.emp_name;
        //    //    temp.emp_dob = item.emp_dob;
        //    //    temp.username = item.acc_username;
        //    //    temp.pwd = item.acc_password;
        //    //    temp.emp_contact_number = item.emp_contact_number;
        //    //    listEmp.Add(temp);
        //    //}

        //    //return View(listEmp);
        //}

        //// GET: employees/?sortOrder=@
        //public ActionResult Index(string sortOrder)
        //{
        //    // 1. Thêm biến NameSortParm để biết trạng thái sắp xếp tăng, giảm ở View
        //    ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
        //    ViewBag.PosSortParm = sortOrder == "Position" ? "position_desc" : "position";

        //    // 2. Truy vấn lấy tất cả đường dẫn
        //    var emp = from e in db.employees
        //                select e;

        //    // 3. Thứ tự sắp xếp theo thuộc tính LinkName
        //    switch (sortOrder)
        //    {
        //        // 3.1 Nếu biến sortOrder sắp giảm thì sắp giảm theo LinkName
        //        case "name_desc":
        //            emp = emp.OrderByDescending(s => s.emp_name);
        //            break;

        //        // 3.2 Sắp tăng dần theo LinkDescription
        //        case "position":
        //            emp = emp.OrderBy(s => s.emp_position);
        //            break;

        //        // 3.3 Sắp giảm theo LinkDescription
        //        case "position_desc":
        //            emp = emp.OrderByDescending(s => s.emp_position);
        //            break;

        //        // 3.4 Mặc định thì sẽ sắp tăng
        //        default:
        //            emp = emp.OrderBy(s => s.emp_name);
        //            break;
        //    }

        //    // 4. Trả kết quả về Views
        //    return View(emp.ToList());
        //}

        //// GET: employees/ Dynamic Linq sort
        //public ActionResult Index(string sortProperty, string sortOrder)
        //{
        //    // tạo biến ViewBag SortOrder để giữ trạng thái tăng/giảm
        //    ViewBag.SortOrder = String.IsNullOrEmpty(sortOrder) ? "desc" : "";

        //    // lấy tất cả thuộc tính của lớp employees
        //    var properties = typeof(employee).GetProperties();
        //    string s = String.Empty;
        //    foreach (var item in properties)
        //    {
        //        // kiểm tra thuộc tính virtual
        //        var isVirtual = item.GetAccessors()[0].IsVirtual;

        //        // thuộc tính thường
        //        if (!isVirtual)
        //        {
        //            ViewBag.Headings += "<th><a href='?sortProperty=" + item.Name + "&sortOrder=" +
        //        ViewBag.SortOrder + "'>" + item.Name + "</th></a></th>";
        //        }
        //        // thuộc tính virtual
        //        else
        //            ViewBag.Headings += "<th>" + item.Name + "</a></th>";
        //    }

        //    // truy vấn lấy tất cả columns
        //    var emp = from e in db.employees
        //              select e;

        //    // thuộc tính sắp xếp mặc định là 'emp_name'
        //    if (String.IsNullOrEmpty(sortProperty)) sortProperty = "emp_id";

        //    // sắp xếp tăng/giảm bằng phương thức OrderBy
        //    if (sortOrder == "desc") emp = emp.OrderBy(sortProperty + " desc");
        //    else 
        //        emp = emp.OrderBy(sortProperty);

        //    // return view
        //    return View(emp.ToList());
        //}

        //// GET: employees/ sortOrder & searchString
        //public ActionResult Index (string sortProperty, string sortOrder, string searchString)
        //{
        //    // ViewBag.SortOrder to store sort Status
        //    if (sortOrder == "asc")
        //        ViewBag.SortOrder = "desc";
        //    if (sortOrder == "desc")
        //        ViewBag.SortOrder = "";
        //    if (sortOrder == "")
        //        ViewBag.SortOrder = "asc";

        //    // ViewBag.searchValue = searchString
        //    ViewBag.searchValue = searchString;

        //    // get all properties' heading
        //    var properties = typeof(employee).GetProperties();

        //    // list kiểu tuple<string, bool, int> với param <Name, isVirtual, Order>
        //    List<Tuple<string, bool, int>> list = new List<Tuple<string, bool, int>>();
        //    foreach (var item in properties)
        //    {
        //        int order = 999;
        //        var isVirtual = item.GetAccessors()[0].IsVirtual;

        //        if (item.Name == "emp_id")
        //            order = 1;
        //        if (item.Name == "emp_name")
        //            order = 2;
        //        if (item.Name == "emp_position")
        //            order = 3;
        //        if (item.Name == "emp_dob")
        //            order = 4;
        //        if (item.Name == "emp_contact_number")
        //            order = 5; //continue; nếu không cần hiển thị cột này

        //        Tuple<string, bool, int> t = new Tuple<string, bool, int>(item.Name, isVirtual, order);
        //        list.Add(t);
        //    }

        //    // sort
        //    list = list.OrderBy(x => x.Item3).ToList();

        //    foreach (var item in list)
        //    {
        //        // kiểm tra thuộc tính thường
        //        if (!item.Item2)
        //        {
        //            if (sortOrder == "desc" && sortProperty == item.Item1)
        //                ViewBag.Headings += "<th><a href='?sortProperty=" + item.Item1 + "&sortOrder=" +
        //                ViewBag.SortOrder + "&searchString=" + searchString + "'>" + item.Item1 + "<i class='fa fa-fw fa-sort-desc'></i></th></a></th>";
        //            else if (sortOrder == "asc" && sortProperty == item.Item1)
        //                ViewBag.Headings += "<th><a href='?sortProperty=" + item.Item1 + "&sortOrder=" +
        //                ViewBag.SortOrder + "&searchString=" + searchString + "'>" + item.Item1 + "<i class='fa fa-fw fa-sort-asc'></a></th>";
        //            else
        //                ViewBag.Headings += "<th><a href='?sortProperty=" + item.Item1 + "&sortOrder=" +
        //               ViewBag.SortOrder + "&searchString=" + searchString + "'>" + item.Item1 + "<i class='fa fa-fw fa-sort'></a></th>"; 
        //        }
        //        // thuộc tính virtual
        //        else 
        //            ViewBag.Headings += "<th>" + item.Item1 + "</th>";
        //    }

        //    // lấy danh sách properties của table
        //    var emp = from e in db.employees
        //              select e;

        //    // thuộc tính sắp xếp mặc định = emp_id
        //    if (String.IsNullOrEmpty(sortProperty)) sortProperty = "emp_id";

        //    if (sortOrder == "desc") 
        //        emp = emp.OrderBy(sortProperty + " desc");
        //    else if (sortOrder == "asc") 
        //        emp = emp.OrderBy(sortProperty);

        //    // search string
        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        emp = emp.Where(s => s.emp_name.Contains(searchString));
        //    }

        //    return View(emp.ToList());
        //}

        //[HttpGet]
        //// GET: /employees/ pagedList
        //public ActionResult Index(int ?size, int? page)
        //{
        //    List<SelectListItem> items = new List<SelectListItem>();
        //    items.Add(new SelectListItem { Text = "5", Value = "5" });
        //    items.Add(new SelectListItem { Text = "10", Value = "10" });

        //    foreach (var item in items)
        //        if (item.Value == size.ToString())
        //            item.Selected = true;

        //    ViewBag.size = items;
        //    ViewBag.currentSize = size;

        //    page = page ?? 1;

        //    var emp = (from e in db.employees
        //               select e).OrderBy(x => x.emp_id);

        //    int pageSize = (size ?? 5);
        //    int pageNumber = (page ?? 1);

        //    int checkTotal = (int)(emp.ToList().Count / pageSize) + 1;
        //    if (pageNumber > checkTotal)
        //        pageNumber = checkTotal;

        //    return View(emp.ToPagedList(pageNumber, pageSize));
        //}

        [HttpGet]
        // GET /employees/ paging && sort && searchString
        public ActionResult Index(int? size, int? page, string sortProperty, string sortOrder, string searchString)
        {
            if (sortOrder == "asc")
                ViewBag.sortOrder = "desc";
            if (sortOrder == "desc")
                ViewBag.sortOrder = "";
            if (sortOrder == "")
                ViewBag.sortOrder = "asc";

            ViewBag.searchValue = searchString;
            ViewBag.sortProperty = sortProperty;
            ViewBag.page = page;

            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "5", Value = "5" });
            items.Add(new SelectListItem { Text = "10", Value = "10" });

            foreach (var item in items)
                if (item.Value == size.ToString())
                    item.Selected = true;
            ViewBag.size = items;
            ViewBag.currentSize = size;

            var properties = typeof(employee).GetProperties();
            List<Tuple<string, bool, int>> list = new List<Tuple<string, bool, int>>();
            foreach (var item in properties)
            {
                int order = 999;
                var isVirtual = item.GetAccessors()[0].IsVirtual;

                if (item.Name == "emp_id") 
                    order = 1;
                if (item.Name == "emp_name") 
                    order = 2;
                if (item.Name == "emp_position") 
                    order = 3;
                if (item.Name == "emp_dob") 
                    order = 4;
                if (item.Name == "emp_contact_number") 
                    order = 5;
                Tuple<string, bool, int> t = new Tuple<string, bool, int>(item.Name, isVirtual, order);
                list.Add(t);
            }
            list = list.OrderBy(x => x.Item3).ToList();

            foreach (var item in list)
            {
                // kiểm tra thuộc tính thường
                if (!item.Item2)
                {
                    if (sortOrder == "desc" && sortProperty == item.Item1)
                        ViewBag.Headings += "<th><a href='?sortProperty=" + item.Item1 + "&sortOrder=" +
                        ViewBag.SortOrder + "&searchString=" + searchString + "'>" + item.Item1 + "<i class='fa fa-fw fa-sort-desc'></i></th></a></th>";
                    else if (sortOrder == "asc" && sortProperty == item.Item1)
                        ViewBag.Headings += "<th><a href='?sortProperty=" + item.Item1 + "&sortOrder=" +
                        ViewBag.SortOrder + "&searchString=" + searchString + "'>" + item.Item1 + "<i class='fa fa-fw fa-sort-asc'></a></th>";
                    else
                        ViewBag.Headings += "<th><a href='?sortProperty=" + item.Item1 + "&sortOrder=" +
                       ViewBag.SortOrder + "&searchString=" + searchString + "'>" + item.Item1 + "<i class='fa fa-fw fa-sort'></a></th>";
                }
                // thuộc tính virtual
                else
                    ViewBag.Headings += "<th>" + item.Item1 + "</th>";
            }

            var emp = from e in db.employees
                      select e;

            // thuộc tính sắp xếp mặc định = emp_id
                if (String.IsNullOrEmpty(sortProperty)) sortProperty = "emp_id";

            if (sortOrder == "desc")
                emp = emp.OrderBy(sortProperty + " desc");
            else if (sortOrder == "asc")
                emp = emp.OrderBy(sortProperty);
            else
                emp = emp.OrderBy("emp_id");

            // search string
            if (!String.IsNullOrEmpty(searchString))
            {
                emp = emp.Where(s => s.emp_name.Contains(searchString));
            }

            page = page ?? 1;

            int pageSize = (size ?? 5);
            ViewBag.pageSize = pageSize;

            int pageNumber = (page ?? 1);

            int checkTotal = (int)(emp.ToList().Count / pageSize) + 1;
            if (pageNumber > checkTotal)
                pageNumber = checkTotal;

            return View(emp.ToPagedList(pageNumber, pageSize));
        }


        [HttpPost, HttpParamAction]
        public ActionResult Reset()
        {
            ViewBag.searchValue = "";
            Index(null, null, "", "", "");
            return View();
        }

        // GET: employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,emp_name,emp_position,emp_dob,emp_contact_number")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_name,emp_position,emp_dob,emp_contact_number")] employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // GET: employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            employee employee = db.employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employee employee = db.employees.Find(id);
            db.employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
