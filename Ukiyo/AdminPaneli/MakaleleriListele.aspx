<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="MakaleleriListele.aspx.cs" Inherits="Ukiyo.AdminPaneli.MakaleleriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="altPanel">

        <div class="formBaslik">Makaleleri Listele <asp:Button ID="SearchButton" runat="server" Text="Ara" style="padding:8px;float:right;border-radius:20px;font-weight:600;" OnClick="SearchButton_Click" /><asp:TextBox ID="SearchBox" runat="server" placeholder="Makale Başlığı Giriniz" BorderStyle="Dashed" style="padding:8px;float:right;"></asp:TextBox></div>
        <div class="ayrac"></div>

        <div class="tabloDıs">
            <asp:ListView ID="lv_makaleler" runat="server">
                <LayoutTemplate>
                    <table cellpadding="0" cellspacing="0" class="tablo">
                        <tr>
                            <th style="text-align: center">ID</th>
                            <th style="text-align: center;">Resim</th>
                            <th style="text-align: center;">Başlık</th>
                            <th style="text-align: center;">Kategori</th>
                            <th style="text-align: center;">Yazar</th>
                            <th style="text-align: center;">Görüntüleme Sayı</th>
                            <th style="text-align: center;">Durum</th>
                            <th style="text-align: center;">Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center"><%# Eval("ID") %></td>
                        <td style="text-align: center;">
                            <img src='../Images/MakaleResimleri/<%# Eval("KapakResim") %>' height="40" /></td>
                        <td align="center"><%# Eval("Baslik") %></td>
                        <td align="center"><%# Eval("Kategori") %></td>
                        <td align="center"><%# Eval("Yukleyen") %></td>
                        <td align="center"><%# Eval("GoruntulemeSayi") %></td>
                        <td align="center"><%# Eval("Durum") %></td>
                        <td align="center">
                            <a href='MakaleDuzenle.aspx?Makale_ID=<%# Eval("ID") %>' class="tabloButonDuzenle">Düzenle</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <asp:Button Style="background-color: darkblue;" ID="lbtn_geri" Text="Geri" CssClass="formButon" runat="server" OnClick="lbtn_geri_Click" />
    </div>

</asp:Content>
