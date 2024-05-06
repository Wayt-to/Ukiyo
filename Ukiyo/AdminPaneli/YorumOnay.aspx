<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="YorumOnay.aspx.cs" Inherits="Ukiyo.AdminPaneli.YorumOnay" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" /><link href="Assets/css/MasterStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnl_basarisiz" CssClass="basarisizpanel" runat="server" Visible="false">
        <asp:Label ID="lbl_basarisiz" runat="server" />
    </asp:Panel>
    <asp:Panel ID="pnl_basarili" CssClass="basarilipanel" runat="server" Visible="false">
    <asp:Label ID="lbl_basarili" runat="server" />
</asp:Panel>
            <div class="altPanel">

    <div class="formBaslik">Onay Bekleyen Yorumlar</div>
    <div class="ayrac"></div>

    <div class="tabloDıs">
        <asp:ListView ID="lv_Yorumlar" runat="server" OnItemCommand="lv_Yorumlar_ItemCommand">
            <LayoutTemplate>
                <table cellpadding="0" cellspacing="0" class="tablo">
                    <tr>
                        <th style="text-align: center">ID</th>
                       <th style="text-align: center">Makale</th>
                        <th style="text-align: center">Kullanıcı Adı</th>
                        <th style="text-align: center;max-width:500px;">Yorum</th>
                        <th style="text-align: center">Yorumun Tarihi</th>
                        <th style="text-align: center">Durum</th>
                        <th style="text-align: center">Seçenekler</th>
                    </tr>
                    <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td align="center"><%# Eval("ID") %></td>
                    <td align="center"><%# Eval("MakaleBaslik") %></td>
                    <td align="center"><%# Eval("UyeIsim") %></td>
                    <td align="center" style="max-width:500px;"><%# Eval("Icerik") %></td>
                    <td align="center"><%# Eval("Tarih") %></td>
                    <td align="center"><%# Eval("Durum") %></td>
                    <td align="center">
                        <asp:LinkButton ID="lbtn_durum" runat="server" CssClass="formDurum" CommandArgument='<%#Eval("ID") %>' CommandName="durum">Onayla</asp:LinkButton> 
                        <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="formDurum" style="color:red" CommandArgument='<%#Eval("ID") %>' CommandName="sil">Sil</asp:LinkButton> 
                    </td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
    </div>
    <asp:Button Style="background-color: darkblue;" ID="lbtn_geri" Text="Geri" CssClass="formButon" runat="server" OnClick="lbtn_geri_Click" />
</div>

</asp:Content>
