<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="MakaleIcerik.aspx.cs" Inherits="Ukiyo.MakaleIcerik" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/masterstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="Makale">
        <div class="kapak">
            <asp:Image ID="img_resim" runat="server" />
        </div>
        <div class="baslik">
            <a>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal>
            </a>
        </div>
        <div class="detay">
            <label>Kategori:</label>
            <asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            | 
 
            <label>Yazar:</label>
            <asp:Literal ID="ltrl_Yazar" runat="server"></asp:Literal>
            |
 
            <label>Tarih:</label>
            <asp:Literal ID="ltrl_Tarih" runat="server"></asp:Literal>
        </div>
        <div class="ozet">
            <asp:Literal ID="ltrl_Icerik" runat="server"></asp:Literal>
        </div>
    </div>
    <div class="yorumPanel">

        <div class="baslik">
            <h2>Yorum Paneli</h2>
        </div>
        <div class="ayrac1">
        </div>
            <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false" Style="width: 99%;margin-left:0;margin-bottom:10px;">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false" Style="width: 99%;margin-left:0;margin-bottom:10px;">
    <asp:Label ID="lbl_mesaj2" runat="server"></asp:Label>
</asp:Panel>
        <asp:Panel ID="pnl_girisvar" runat="server">
            <div class="satir">
                <asp:TextBox ID="tb_yorum" runat="server" TextMode="MultiLine" CssClass="YorumKutu" placeholder="Lüfen yorumunuzu giriniz."></asp:TextBox>
            </div>
            <div class="satir" style="margin-top: 20px;">
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="YorumButon" OnClick="lbtn_ekle_Click">Yorum Gönder</asp:LinkButton>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnl_girisYok" runat="server" CssClass="yorumYok">
            <div style="margin-top: 15px;">
                Yorum yapabilmek için lütfen <a href="Giris.aspx" style="color: #0026ff">Giriş </a>
                yapınız.
            </div>
        </asp:Panel>

        <asp:Repeater ID="rp_yorumlar" runat="server">
            <ItemTemplate>
                <div class="yorumPanelKutu">
                    <div class="yorumDetay">
                        Uye : <%#Eval("UyeIsim") %> | Yorum Tarihi : <%#Eval("TarihStr") %>
                    </div>
                    <div>
                        <div class="yorumIcerik">
                            <%#Eval("Icerik") %>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
