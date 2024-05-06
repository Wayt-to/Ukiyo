<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ukiyo.AdminPaneli.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="kategoriBaslik">
        <label style="text-decoration:none;color:red;margin:15px;">!</label>
       <a runat="server" style="text-decoration:none;color:black;" href="YorumOnay.aspx"> <asp:Label id="onaysiz" runat="server"></asp:Label></a>
    </div>
    
</asp:Content>
