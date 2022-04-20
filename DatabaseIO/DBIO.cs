using DatabaseProvider;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseIO
{
    public class DBIO
    {
        // Object kết nối tới DB SERVER
        MyDB mydb = new MyDB();

        // <summary>
        // Thêm 1 object (1 row của table) vào DB
        // </summary>
        public void AddObject<T>(T obj)
        {
            mydb.Set(obj.GetType()).Add(obj);
        }

        // <summary>
        // Lưu mọi thay đổi đang có vào DB SERVER
        // </summary>
        public void Save()
        {
            mydb.SaveChanges();
        }

        // <summary>
        // Đọc toàn bộ DL của TABLE account
        // </summary> 
        public List<account> GetList_Account()
        {
            return mydb.accounts.ToList();
        }

        //// lấy thông tin account thông qua username và password // truy vấn trả về 1 object
        //public account GetObject_Account(string username, string pwd)
        //{
        //    // no parameter
        //    //string sqlCommand = "SELECT * FROM account where acc_username = '" + username + "' AND acc_password = '" + pwd + "'";
        //    //mydb.Database.SqlQuery<account>(sqlCommand).FirstOrDefault();

        //    // with parameter
        //    //return mydb.Database.SqlQuery<account>(
        //    //    "SELECT * FROM account WHERE acc_username=@username AND acc_password=@pwd",
        //    //    new SqlParameter("@username", username),
        //    //    new SqlParameter("@pwd", pwd)
        //    //    ).FirstOrDefault();

        //    // iQuery
        //    return mydb.accounts.Where(a => a.acc_username == username && a.acc_password == pwd).FirstOrDefault();
        //}
        //// thêm account mới bằng procudure // truy vấn có điều kiện, tham số
        //public void AddObject_Account(int id, int role_id, string position, string name, DateTime dob, string contact, string username, string pwd)
        //{
        //    mydb.Database.ExecuteSqlCommand(
        //        "EXEC [dbo].[new_account_insert] @id,@role_id,@position,@name,@dob,@contact,@username,@pwd",
        //        new SqlParameter("id", id),
        //        new SqlParameter("role_id", role_id),
        //        new SqlParameter("position", position),
        //        new SqlParameter("name", name),
        //        new SqlParameter("dob", dob),
        //        new SqlParameter("role_id", contact),
        //        new SqlParameter("username", username),
        //        new SqlParameter("pwd", pwd)
        //        );
        //}
        //// lấy danh sách account // truy vấn trả về 1 danh sách
        //public List<account> getListAccounts()
        //{
        //    return mydb.accounts.OrderBy(a => a.acc_username).ToList();
        //}
    }
}
