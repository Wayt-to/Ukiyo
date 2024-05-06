<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Giris.aspx.cs" Inherits="Ukiyo.Giris" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/masterstyle.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="girispanel">
            <h1 style="margin-top:30px ; margin-left:220px;padding:20px;color:azure">Üye Giriş</h1>
            <br />
            <br />
            
            
            <label>Kullanıcı Adı</label><br />
            <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="textBox1" Text="" />
            <br />
            <label>Şifre</label><br />
            <asp:TextBox ID="tb_sifre" runat="server" class="textBox2" Text="" TextMode="Password" />
            <br />
            <asp:Button ID="btn_giris" Text="Giriş Yap" runat="server" CssClass="girisButon" OnClick="btn_giris_Click" />
            <label style="margin-left: 220px; font-size: 14pt; margin-top: 20px;">Hesabın yok mu?<br />
                &nbsp<a style="color:cadetblue" href="Kayıt.aspx">Hemen kaydol!</a></label>
        </div>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
</asp:Panel>
    </div>
</asp:Content>
