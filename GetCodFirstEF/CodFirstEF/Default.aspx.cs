using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;

namespace DBGera
{
    public partial class _Default : System.Web.UI.Page
    {
        public String GetAppSetting(String key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }
            catch
            {
                throw new Exception("Erro lendo App Setting " + key);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                return;

            txtServer.Text = GetAppSetting("DefServer");
            txtUser.Text = GetAppSetting("DefUser");
            txtDB.Text = GetAppSetting("DefDB");
            txtPWD.Text = GetAppSetting("DefPassword");
        }

        protected void butGeraCS_Click(object sender, EventArgs e)
        {
            StringBuilder ConnString = new StringBuilder("Server=");
            ConnString.Append(txtServer.Text);
            ConnString.Append(";database=");
            ConnString.Append(txtDB.Text);
            ConnString.Append(";User ID=");
            ConnString.Append(txtUser.Text);
            ConnString.Append(";Password=");
            ConnString.Append(txtPWD.Text);

            txtConnString.Text = ConnString.ToString();
        }

        protected void butConnect_Click(object sender, EventArgs e)
        {
            lstObjects.Items.Clear();

            SqlConnection DBConn = new SqlConnection(txtConnString.Text.ToString());
            DBConn.Open();

            var Sql = new StringBuilder();
            Sql.ApLine("Select o.name, o.type ");
            Sql.ApLine(" from sys.objects o ");
            Sql.ApLine(" where o.type in ('P', 'U', 'V') ");
            Sql.ApLine("   and not exists (Select * from __ObjectsSistema OS where OS.id = o.object_id)");

            var Like = txtLike.Text.Trim();
            if (!String.IsNullOrEmpty(Like))
                Sql.ApLine(" and o.name like '%" + Like + "%'");

            Sql.ApLine(" order by o.name");

            SqlCommand cmdObj = DBConn.CreateCommand();
            cmdObj.CommandText = Sql.ToString();
            SqlDataReader rdObj = cmdObj.ExecuteReader();

            try
            {
                while (rdObj.Read())
                {
                    ListItem Item = new ListItem((String)rdObj[0]);
                    Item.Selected = cbxSelect.Checked;
                    lstObjects.Items.Add(Item);
                }
            }
            finally
            {
                rdObj.Close();
            }
        }

        private void GravaSession()
        {
            List<String> Objetos = new List<String>();
            foreach (ListItem Item in lstObjects.Items)
                if (Item.Selected)
                    Objetos.Add(Item.Text);

            Session["ConnString"] = txtConnString.Text;
            Session["Objetos"] = Objetos;
            Session["SoPoco"] = false;
        }

        protected void butGerar_Click(object sender, EventArgs e)
        {
            GravaSession();

            Response.Redirect("Gera.aspx", true);
        }

        protected void butMarcarIDs_Click(object sender, EventArgs e)
        {
            GravaSession();

            Response.Redirect("IDsSistema.aspx", true);
        }

        protected void butRefresh_Click(object sender, EventArgs e)
        {
            GravaSession();

            Response.Redirect("Refresh.aspx", true);
        }
        protected void butSoPoco_Click(object sender, EventArgs e)
        {
            GravaSession();
            Session["SoPoco"] = true;

            Response.Redirect("Gera.aspx", true);
        }

        protected void butDbContext_Click(object sender, EventArgs e)
        {
            GravaSession();

            Response.Redirect("DbContext.aspx", true);
        }

        protected void butSP_Click(object sender, EventArgs e)
        {
            GravaSession();

            Response.Redirect("SP.aspx", true);
        }
    }
}