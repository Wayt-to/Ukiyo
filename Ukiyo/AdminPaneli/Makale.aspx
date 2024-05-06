<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="Makale.aspx.cs" Inherits="Ukiyo.AdminPaneli.Makale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <a class="kategoriBaslik" href="MakaleleriListele.aspx">Makaleleri Listele</a>
        <a class="kategoriBaslik" href="MakaleEkle.aspx">Makale Ekle</a>
    </div>
</asp:Content>
