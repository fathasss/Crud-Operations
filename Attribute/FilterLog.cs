using CrudOperatorUI.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;

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
            var controllerName = filterContext.RouteData.Values["controller"];
            var actionName = filterContext.RouteData.Values["action"];
            var actionController = controllerName + "/" + actionName;
            var date = DateTime.Now;
            var user = filterContext.HttpContext.Session["Login"];
            var IPAddress = request.ServerVariables["HTTP_X_FORWARDED_FOR"] ?? request.UserHostAddress;
            var browser = request.Browser.Browser;

            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("spUserLoggerAdd", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", user);
                cmd.Parameters.AddWithValue("@action", actionController);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@ip", IPAddress);
                cmd.Parameters.AddWithValue("@browser", browser);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}