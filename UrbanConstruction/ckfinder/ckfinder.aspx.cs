using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
 

public partial class ckfinder_ckfinder : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        HttpCookie cookie = Request.Cookies["User"];
        if (cookie == null && cookie.Values["username"].Length == 0)
        {
            Response.Redirect("Administrator/Login.aspx");
        }     
    }
}
