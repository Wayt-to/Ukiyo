<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="MakaleEkle.aspx.cs" Inherits="Ukiyo.AdminPaneli.MakaleEkle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
    <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
</asp:Panel>
<asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
<label>Makale başarıyla eklenmiştir</label>
</asp:Panel>
    <div class="altPanelMakale">
        <div class="formBaslik">Makale Ekle</div>
        <div class="ayrac"></div>


        <div class="satir">
            <label class="formetiket">Makale Başlığı</label>
        </div>
        <div class="satir">
            <asp:TextBox ID="tb_makBaslik" runat="server" placeholder="Makale Başlığını Giriniz" CssClass="FormTextBox" textmode="MultiLine"/>
        </div>
        <div class="satir">
            <label class="formetiket">Makale Kategorisi</label>
            <asp:DropDownList style="height:40px;" ID="ddl_kategoriler" runat="server" CssClass="FormTextBox" DataTextField="Isim" DataValueField="ID">
            </asp:DropDownList>
        </div>
       
        <div class="satir">
            <label class="formetiket">Makale Özeti</label>
        </div>
        <div class="satir">
            <asp:TextBox ID="tb_makOzet" runat="server" placeholder="Makale Özeti Giriniz" CssClass="FormTextBox" Style="height: 200px; max-height: 315px; max-width: 1100px;" TextMode="MultiLine" />
        </div>
        <div class="satir">
            <label class="formetiket">Makale İçeriği</label>
        </div>
        <div class="satir">
            <asp:TextBox runat="server" ID="tb_Icerik" CssClass="FormTextBox" textmode="MultiLine" />
        </div>
       
        <div class="satir">
            <label class="formetiket" >Kapak Resim</label>
            <asp:FileUpload ID="fu_resim" style="border:1px solid silver;margin-top:5px;padding-top:7px" runat="server" CssClass="FormTextBox" />
        </div>
        <div class="satir">
    <label class="formetiket">Yayın Durumu</label>
</div>
        <div class="satir">
            <asp:CheckBox ID="cb_yayin" CssClass="checkBox" Text="(İşaretli ise yayında demektir.)" runat="server" />
        </div>


        <div style="clear: both"></div>
        <asp:Button ID="lbtn_makEkle" Text="Makale Ekle" CssClass="formButon" runat="server" OnClick="lbtn_makEkle_Click" />
        <asp:Button Style="background-color: darkblue;" ID="lbtn_geri" Text="Geri" CssClass="formButon" runat="server" OnClick="lbtn_geri_Click" />
    </div>

</asp:Content>
