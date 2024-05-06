<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="ModeratorAtama.aspx.cs" Inherits="Ukiyo.AdminPaneli.ModeratorAtama" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
    <link href="Assets/css/AdminLoginCss.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="girispanel">
            <h1 style="margin: 20px; margin-left: 130px;">Moderatör Atama Formu</h1>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
    <asp:Label ID="lbl_mesaj2" runat="server"></asp:Label>
</asp:Panel>
            <label>Kullanıcı Adı</label><br />
            <asp:TextBox ID="tb_kullaniciadi" runat="server" CssClass="textBox1" Text="vahit" /><br />
            <label>Moderatör Email'i</label><br />
            <asp:TextBox ID="tb_email" runat="server" CssClass="textBox1" Text="email@mail.com" /><br />
            <label>Şifre</label><br />
            <asp:TextBox ID="tb_sifre" runat="server" class="textBox2" Text="1234" /><br />
            <asp:Button ID="btn_kayit" Text="Giriş Yap" runat="server" CssClass="girisButon" OnClick="btn_kayit_Click" />


        </div>
    </div>
</asp:Content>
