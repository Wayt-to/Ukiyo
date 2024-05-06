<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="UyeleriListele.aspx.cs" Inherits="Ukiyo.AdminPaneli.UyeleriListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="altPanel">

    <div class="formBaslik">Üyeleri Listele             <asp:Button ID="SearchButton" runat="server" Text="Ara" style="padding:8px;float:right;border-radius:20px;font-weight:600;" OnClick="SearchButton_Click" /><asp:TextBox ID="SearchBox" runat="server" placeholder="Kullanıcı Adı Giriniz" BorderStyle="Dashed" style="padding:8px;float:right;"></asp:TextBox></div>
            

    <div class="ayrac"></div>

    <div class="tabloDıs">
        <asp:ListView ID="lv_Uyeler" runat="server" OnItemCommand="lv_Uyeler_ItemCommand">
            <LayoutTemplate>
                <table cellpadding="0" cellspacing="0" class="tablo">
                    <tr>
                        <th style="text-align: center">ID</th>
                        <th style="text-align: center">Kullanıcı Adı</th>
                        <th style="text-align: center">E-mail</th>
                        <th style="text-align: center">Kayıt Tarihi</th>
                        <th style="text-align: center">Durum</th>
                        <th style="text-align: center">Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><%# Eval("ID") %></td>
                    <td align="center"><%# Eval("KullaniciAdi") %></td>
                    <td align="center"><%# Eval("Email") %></td>
                    <td align="center"><%# Eval("UyelikTarihi") %></td>
                    <td align="center"><%# Eval("Durum") %></td>
                    <td align="center">
                        <asp:LinkButton ID="lbtn_durum" runat="server" CssClass="formDurum" CommandArgument='<%#Eval("ID") %>' CommandName="durum">Durum Değiştir</asp:LinkButton> 
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <asp:Button Style="background-color: darkblue;" ID="lbtn_geri" Text="Geri" CssClass="formButon" runat="server" OnClick="lbtn_geri_Click" />
</div>
</asp:Content>
