using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Ukiyo
{
    public partial class Categories : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = dm.TumAktifKategorileriGetir();
            rp_kategoriler.DataBind();
        }
    }
}