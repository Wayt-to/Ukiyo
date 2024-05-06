<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="Ukiyo.AdminPaneli.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="altPanel">

        <div class="formBaslik">Kategori Listele <asp:Button ID="SearchButton" runat="server" Text="Ara" style="padding:8px;float:right;border-radius:20px;font-weight:600;" OnClick="SearchButton_Click" /><asp:TextBox ID="SearchBox" runat="server" placeholder="Kategori Adı Giriniz" BorderStyle="Dashed" style="padding:8px;float:right;"></asp:TextBox>
</div>
        <div class="ayrac"></div>

        <div class="tabloDıs">
            <asp:ListView runat="server" ID="lv_kategoriler">
                <LayoutTemplate>
                    <table cellpadding="0" cellspacing="0" class="tablo">
                        <tr>
                            <th style="text-align: center">ID</th>
                            <th style="text-align: center">İsim</th>
                            <th style="text-align: center">Açıklama</th>
                            <th style="text-align: center">Durum</th>
                            <th style="text-align: center">Düzenle Menüsü</th>
                        </tr>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td align="center"><%# Eval("ID") %></td>
                        <td align="center"><%# Eval("Isim") %></td>
                        <td align="center"><%# Eval("Aciklama") %></td>
                        <td align="center"><%# Eval("Durum") %></td>
                        <td align="center">
                            <a href='KategoriDuzenle.aspx?Kategori_ID=<%# Eval("ID")%>' class="tabloButonDuzenle">Düzenle</a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
        <asp:Button style="background-color:darkblue;" ID="lbtn_geri" Text="Geri" CssClass="formButon" runat="server" OnClick="lbtn_geri_Click" />
    </div>
</asp:Content>
