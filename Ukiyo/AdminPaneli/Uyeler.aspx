<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="Uyeler.aspx.cs" Inherits="Ukiyo.AdminPaneli.Uyeler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <a class="kategoriBaslik" href="UyeleriListele.aspx">Üye Listesi</a>
    <a class="kategoriBaslik" href="ModeratorAtama.aspx">Moderatör Atama</a>
    <a class="kategoriBaslik" style="margin-top:170px;margin-left:330px;float:left;clear:both;" href="ModeratorListesi.aspx">Moderatör Listesi</a>

</asp:Content>
