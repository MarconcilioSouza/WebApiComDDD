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
    public partial class IDsSistema : System.Web.UI.Page
    {
        public List<TableDef> Tabs;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            List<String> Objetos = (List<String>)Session["Objetos"];
            String ConnStr = (String)Session["ConnString"];

            SqlConnection DBConn = new SqlConnection(ConnStr);
            DBConn.Open();

            Tabs = new TableDefs(DBConn, Objetos);

            foreach (var Table in Tabs)
            {
                SqlCommand cmdIns = DBConn.CreateCommand();
                cmdIns.CommandType = CommandType.Text;
                cmdIns.CommandText =
                    "Insert into __ObjectsSistema (id, name, type ) " + Environment.NewLine +
                    " values ( @id, @name, @type) ";

                cmdIns.Parameters.Add("@id", SqlDbType.Int).Value = Table.IdObjeto;
                cmdIns.Parameters.Add("@name", SqlDbType.NVarChar).Value = Table.Name;
                cmdIns.Parameters.Add("@type", SqlDbType.NChar, 1).Value = Table.Type;
                cmdIns.ExecuteNonQuery();
            }

            litOut.Text = Tabs.Count.ToString() + " IDs marcados em __ObjectsSistema";
        }
    }
}