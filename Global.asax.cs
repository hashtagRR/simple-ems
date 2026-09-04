using System;

namespace Exam
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            // No application-level startup logic is required: each portal
            // (Admin/Lecturer/Student) gates access per-page via Session
            // checks in its own Page_Load, so nothing needs to be
            // registered here (no routing, no bundles are consumed by the
            // C# code itself).
        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }
    }
}
