using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace DBGera
{
    public partial class Refresh : System.Web.UI.Page
    {
        public List<TableDef> Tabs;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<String> Objetos = (List<String>)Session["Objetos"];
            String ConnStr = (String)Session["ConnString"];

            SqlConnection DBConn = new SqlConnection(ConnStr);
            DBConn.Open();

            var m_SB = new StringBuilder();
            foreach (String Obj in Objetos)
            {
                TableDef Tab = new TableDef(DBConn, Obj);
                if (Tab.Type == "V")
                {
                    m_SB.Append("sp_refreshview ").ApLine(Tab.Name);
                    m_SB.ApLine("go");
                }
            }
            litSP.Text = m_SB.ToString();
        }
    }
}
