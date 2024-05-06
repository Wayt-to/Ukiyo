<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Kayıt.aspx.cs" Inherits="Ukiyo.Kayıt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/masterstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <div class="girispanel" style="height: 600px">
        <h1 style="margin-top:20px ; margin-left:170px;padding:20px;">Üye Kayıt Formu</h1>
        <br />
        <br />
        
        
        <label>Kullanıcı Adı</label><br />
        <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="textBox1"  />
        <label>Email</label><br />
        <asp:TextBox ID="tb_email" runat="server" CssClass="textBox1" />
        <br />
        <label>Şifre</label><br />
        <asp:TextBox ID="tb_sifre" runat="server" class="textBox2"  />
        <br />

        <asp:Button ID="btn_giris" Text="Kayıt Ol" runat="server" CssClass="girisButon" OnClick="btn_giris_Click" />
        
    </div>
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
</asp:Panel>
</div>
</asp:Content>
