using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Threading;
using System.Transactions;
using System.Web;
using System.Web.Mvc;

namespace Tests.Controllers
{
    [Transaction]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            Thread td = new Thread(ShowStr);
            return View();
        }
        void ShowStr()
        {
            Console.WriteLine("notime for loser");
        }
        [AutoComplete]
        int testTransaction()
        {
            int a;
            using (TransactionScope scope = new TransactionScope())
            {
                a = 5;
            }
            SqlConnection sqlConn = new SqlConnection("connectionStr");
            SqlCommand command = sqlConn.CreateCommand();
            SqlTransaction trans = sqlConn.BeginTransaction();
            command.Transaction = trans;
            command.ExecuteNonQuery();
            trans.Commit();

            trans.Rollback();
            return a;
        }
        public void TestWebClient()
        {
            WebProxy wp = new WebProxy();
            WebClient client = new WebClient();
            //System.Web.HttpRequest request = System.Net.HttpWebRequest.Create("");
            //request.Credentials = new NetworkCredential("account", "password");
            IPAddress ip = IPAddress.Parse("192.168.200.24");
            SqlDataReader reader = new SqlDataReader();
            DataTable table = new DataTable();
            DataColumn[] cols = new DataColumn[1];
            cols[0] = table.Columns[0];
            table.PrimaryKey = cols;
        }
    }
}
