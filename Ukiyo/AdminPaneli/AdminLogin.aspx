<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Ukiyo.AdminPaneli.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Ukiyo Admin Giris</title>
    <link href="Assets/css/AdminLoginCss.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="girispanel">
                <img style="padding: 30px; margin-left: 140px;" src="../Images/logokucuk.png" /><br />
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
   <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <label>Kullanıcı Adı</label><br />
                <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="textBox1" Text="" /><br />
                <label>Şifre</label><br />
                <asp:TextBox ID="tb_sifre"  runat="server" class="textBox2" Text="" TextMode="Password"/><br />
                <asp:Button ID="btn_giris" Text="Giriş Yap" runat="server" CssClass="girisButon" OnClick="btn_giris_Click"/>

                
            </div>
        </div>
    </form>
</body>
</html>
