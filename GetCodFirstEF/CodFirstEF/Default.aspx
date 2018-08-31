<%@ Page Language="C#" AutoEventWireup="true" Inherits="DBGera._Default" CodeBehind="Default.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Parameters</title>
    <style type="text/css">
        .ButDiv
        {
            margin: 12px;
        }
        
        .ButDiv.Poco
        {
            background-color: red;
        }

        .ButDiv input
        {
            display: block;
            width: 120px;
            padding: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table cellpadding="3">
        <tr>
            <td>
                Server
            </td>
            <td>
                <asp:TextBox ID="txtServer" runat="server">.\SQLExpress</asp:TextBox>
            </td>
            <td>
                User
            </td>
            <td>
                <asp:TextBox ID="txtUser" runat="server">sa</asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                DB
            </td>
            <td>
                <asp:TextBox ID="txtDB" runat="server"></asp:TextBox>
            </td>
            <td>
                Pwd
            </td>
            <td>
                <asp:TextBox ID="txtPWD" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
                <asp:Button ID="butGeraCS" runat="server" Text="Gerar String" OnClick="butGeraCS_Click" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3" style="padding-top: 12px">
                <asp:TextBox ID="txtConnString" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Like
            </td>
            <td>
                <asp:TextBox ID="txtLike" runat="server"></asp:TextBox>
            </td>
            <td>
            </td>
            <td>
                <asp:CheckBox ID="cbxSelect" runat="server" Text="Selecionar Todos" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="3">
                <asp:Button ID="butConnect" runat="server" Text="Conectar & Listar" OnClick="butConnect_Click" />
            </td>
        </tr>
    </table>
    <br />
    <table>
        <tr valign="top">
            <td>
                <asp:ListBox ID="lstObjects" runat="server" Height="400px" Width="300px" SelectionMode="Multiple">
                </asp:ListBox>
            </td>
            <td>
               <%-- <div class="ButDiv">
                    <asp:Button ID="butGerar" runat="server" Text="Gerar Classes" OnClick="butGerar_Click"
                        CssClass="ButGerar" />
                </div>--%>
                <div class="ButDiv">
                    <asp:Button ID="butMarcarIDs" runat="server" Text="Marcar IDs" OnClick="butMarcarIDs_Click"
                        CssClass="ButGerar" OnClientClick="javascript: return confirm('Marcar os objetos em __ObjectsSistema ?')" />
                </div>
                <%--<div class="ButDiv">
                    <asp:Button ID="butRefresh" runat="server" Text="Refresh Views" OnClick="butRefresh_Click"
                        CssClass="ButGerar" />
                </div>--%>
                <div class="ButDiv Poco">
                    <asp:Button ID="butSoPoco" runat="server" Text="Get Code First" OnClick="butSoPoco_Click"
                        CssClass="ButGerar" />
                </div>
                <div class="ButDiv Poco">
                    <asp:Button ID="butDbContext" runat="server" Text="DbContext" OnClick="butDbContext_Click"
                        CssClass="ButGerar" />
                </div>
                <div class="ButDiv">
                    <asp:Button ID="butSP" runat="server" Text="Gerar SP" OnClick="butSP_Click" CssClass="ButGerar" />
                </div>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
