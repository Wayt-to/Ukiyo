<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Ukiyo.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/masterstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater runat="server" ID="rp_kategoriler">
        <ItemTemplate>
            <div class="KategoriKutu">
                <a href="Default.aspx?Kategori_ID=<%# Eval("ID") %>"><%# Eval("Isim") %></a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
