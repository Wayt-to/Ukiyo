<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="Ukiyo.AdminPaneli.KategoriDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
    <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
</asp:Panel>
<asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
<label>Kategori başarıyla Düzenlenmiştir</label>
</asp:Panel>

    <div class="altPanel">

        <div class="formBaslik">Kategori Ekle</div>
        <div class="ayrac"></div>
        
        <div class="satir">
            <label class="formetiket">Kategori Adı</label>
        </div>
        <div class="satir">
             <asp:TextBox ID="tb_katAdi" runat="server" placeholder="Kategori Adını Giriniz" CssClass="FormTextBox" />
        </div>
        <div class="satir">
    <label class="formetiket">Kategori Açıklaması</label>
</div>
        <div class="satir">
     <asp:TextBox ID="tb_katAciklama" runat="server" placeholder="Kategori Açıklaması Giriniz" CssClass="FormTextBox" style="height:315px;max-height:315px;max-width:1100px;" TextMode="MultiLine"/>
</div>
        <div class="satir">
            <label class="formetiket">Yayın Durumu</label>

        </div>
        <div class="satir">
            <asp:CheckBox ID="cb_yayin" CssClass="checkBox" Text="(İşaretli ise yayında demektir.)" runat="server" />
        </div>
        <div style="clear:both"></div>
        <asp:Button ID="lbtn_katDuzenle" Text="Kategori Duzenle" CssClass="formButon" runat="server" OnClick="lbtn_katDuzenle_Click" />
        <asp:Button style="background-color:darkred;" ID="lbtn_katSil" Text="Kategoriyi Sil" CssClass="formButon" runat="server" OnClick="lbtn_katSil_Click"/>
        <asp:Button style="background-color:darkblue;" ID="lbtn_geri" Text="Geri" CssClass="formButon" runat="server" OnClick="lbtn_geri_Click" />

      </div>
        

</asp:Content>
