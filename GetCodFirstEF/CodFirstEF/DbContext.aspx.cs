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
    public partial class DbContext : System.Web.UI.Page
    {
        public List<TableDef> Tabs;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<String> Objetos = (List<String>)Session["Objetos"];
            String ConnStr = (String)Session["ConnString"];

            SqlConnection DBConn = new SqlConnection(ConnStr);
            DBConn.Open();

            var Tabs = new TableDefs(DBConn, Objetos);

            var m_SB = new StringBuilder();
            foreach (var Tab in Tabs)
            {
                if (Tab.Type == "U")
                {
                    // public DbSet<tb_ModelosFormulario> tb_ModelosFormulario { get; set; }
                    m_SB.Append("        ");

                    // EF não suporta views !
                    // Views herdados de tabela são um truque.....
                    if (Tab.Type == "V" && Tab.TabHerd == null)
                        m_SB.Append("// ");

                    m_SB.Append("public DbSet&lt;r")
                        .Append(Tab.Name)
                        .Append("&gt; ")
                        .Append(Tab.Name)
                        .ApLine(" { get; set; } ");
                }
            }
            litSP.Text = m_SB.ToString();
        }
    }
}
