using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DBGera
{
    public partial class SP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<String> Objetos = (List<String>)Session["Objetos"];
            String ConnStr = (String)Session["ConnString"];

            SqlConnection DBConn = new SqlConnection(ConnStr);
            DBConn.Open();

            var Tabs = new TableDefs(DBConn, Objetos);

            var m_SB = new StringBuilder();
            if (Tabs.Count > 0)
                Tabs[0].GeraProcSql(m_SB);

            litSP.Text = m_SB.ToString();
        }
    }
}