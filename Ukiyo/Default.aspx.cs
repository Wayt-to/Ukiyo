using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo
{
    public partial class Default1 : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count == 0)
            {
                rp_makaleler.DataSource = dm.MakaleleriListele(true);
                rp_makaleler.DataBind();
            }
            else
            {
                int katID = Convert.ToInt32(Request.QueryString["Kategori_ID"]);
                rp_makaleler.DataSource = dm.MakaleleriListele(katID);
                rp_makaleler.DataBind();
            }
        }
    }
}