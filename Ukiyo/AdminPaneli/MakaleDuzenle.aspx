<%@ Page Title="" Language="C#" MasterPageFile="~/AdminPaneli/Admin.Master" AutoEventWireup="true" CodeBehind="MakaleDuzenle.aspx.cs" Inherits="Ukiyo.AdminPaneli.MakaleDuzenle" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/FormStyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

           <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisizpanel" Visible="false">
    <asp:Label ID="lbl_hatamesaj" runat="server"></asp:Label>
</asp:Panel>
<asp:Panel ID="pnl_basarili" runat="server" CssClass="basarilipanel" Visible="false">
<label>Makale başarıyla düzenlendi.</label>
</asp:Panel>
    <div class="altPanelMakale">
        <div class="formBaslik">Makale Düzenle</div>
        <div class="ayrac"></div>


        <div class="satir">
            <label class="formetiket">Makale Başlığı</label>
        </div>
        <div class="satir">
            <asp:TextBox ID="tb_makBaslik" runat="server" placeholder="Makale Başlığını Giriniz" CssClass="FormTextBox" />
        </div>
        <div class="satir">
    <label class="formetiket">Makale Kategorisi</label>
            <asp:DropDownList  style="height:40px;" ID="ddl_kategoriler" runat="server" CssClass="FormTextBox" DataTextField="Isim" DataValueField="ID">
   
</asp:DropDownList>
</div>
       
        <div class="satir">
            <label class="formetiket">Makale Özeti</label>
        </div>
        <div class="satir">
            <asp:TextBox ID="tb_makOzet" runat="server" placeholder="Kategori Açıklaması Giriniz" CssClass="FormTextBox" Style="height: 200px; max-height: 200px; max-width: 1100px;" TextMode="MultiLine" />
        </div>
        <div class="satir">
            <label class="formetiket">Makale İçeriği</label>
        </div>
        <div class="satir">
            <asp:TextBox runat="server" ID="tb_Icerik" CssClass="FormTextBox" TextMode="MultiLine" />
        </div>
                <div class="satir">
    <asp:Image ID="img_resim" runat="server" Width="200" style="margin-left:20px;" />
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
        <asp:Button ID="lbtn_makDuzenle" Text="Makaleyi Düzenle" CssClass="formButon" runat="server" OnClick="lbtn_makDuzenle_Click"/>
        <asp:Button style="background-color:darkred;" ID="lbtn_makSil" Text="Makaleyi Sil" CssClass="formButon" runat="server" OnClick="lbtn_makSil_Click"/>
        <asp:Button Style="background-color: darkblue;" ID="lbtn_geri" Text="Geri" CssClass="formButon" runat="server" OnClick="lbtn_geri_Click" />
    </div>

</asp:Content>
