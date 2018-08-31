using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

namespace DBGera
{
    public partial class Gera : System.Web.UI.Page
    {
        public TableDefs Tabs;
        public Boolean SoPoco = false;

        protected void Page_Load(object sender, EventArgs e)
        {
            List<String> Objetos = (List<String>)Session["Objetos"];
            String ConnStr = (String)Session["ConnString"];
            SoPoco = (Boolean)Session["SoPoco"];

            SqlConnection DBConn = new SqlConnection(ConnStr);
            DBConn.Open();

            Tabs = new TableDefs(DBConn, Objetos);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            StringBuilder Out = new StringBuilder();
            Out.Append("    // ")
                .Append(DateTime.Now.ToShortDateString())
                .Append(" ")
                .ApLine(DateTime.Now.ToLongTimeString());
            Out.ApLine("    // --------------------========== Tables ==========--------------------");
            Out.ApLine();

            foreach (TableDef Tabela in Tabs)
            {
                if (Tabela.Type == "U")
                {
                    Tabela.GravaPocoTab(Out);

                    if (!SoPoco)
                        Tabela.GravaCursor(Out);
                }
            }

            //Out.ApLine("    // --------------------========== Views ==========--------------------");
            //Out.ApLine();

            //foreach (TableDef View in Tabs)
            //{
            //    if (!SoPoco && View.Type == "V")
            //    {
            //        View.GravaPocoView(Out);

            //        View.GravaView(Out);
            //    }
            //}

            //Out.ApLine("    // --------------------========== Stored Procedures ==========--------------------");
            //Out.ApLine();

            //foreach (TableDef Proc in Tabs)
            //{
            //    if (Proc.Type == "P")
            //        Proc.GravaProc(Tabs, Out, SoPoco);
            //}

            litOut.Text = Out.ToString();
        }
    }
}
