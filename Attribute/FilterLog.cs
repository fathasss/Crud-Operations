using CrudOperatorUI.Utility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Sockets;
using System.Web.Mvc;

namespace CrudOperatorUI.Attribute
{
    public class FilterLog : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Log(filterContext);
        }

        private void Log(ActionExecutingContext filterContext)
        {
            string connect = ConnectionString.CName;
            var request = filterContext.HttpContext.Request;
            var actionController = String.Empty;
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var idName = filterContext.RouteData.Values["id"];

            if(idName == null)
            {
                actionController = controllerName + "/" + actionName;
            }
            else
            {
                actionController = controllerName + "/" + actionName + "/id?=" +idName;
            }
            
            var date = DateTime.Now;
            var user = filterContext.HttpContext.Session["Login"];

            if(user == null)
            {
                user = "Anonymous";
            }

            var browser = request.Browser.Browser;
            var IPAddress = String.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                     IPAddress = ip.ToString();
                }
            }
                      
            try
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    SqlCommand cmd = new SqlCommand("spUserLoggerAdd", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", user.ToString());
                    cmd.Parameters.AddWithValue("@action", actionController.ToString());
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@ip", IPAddress);
                    cmd.Parameters.AddWithValue("@browser", browser.ToString());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
            catch(Exception ex)
            {
                using (SqlConnection conn = new SqlConnection(connect))
                {
                    SqlCommand cmd = new SqlCommand("spUserLogError", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@name", user.ToString());
                    cmd.Parameters.AddWithValue("@action", actionController.ToString());
                    cmd.Parameters.AddWithValue("@date", date);
                    cmd.Parameters.AddWithValue("@ip", IPAddress);
                    cmd.Parameters.AddWithValue("@browser", browser.ToString());
                    cmd.Parameters.AddWithValue("@errorMessage", ex.Message.ToString());
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }          
        }
    }
}