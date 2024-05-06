<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Ukiyo.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="assets/masterstyle.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_makaleler" runat="server">
        <ItemTemplate>
            <div class="Makale">
                <div class="kapak">
                    <img src="Images/MakaleResimleri/<%# Eval("KapakResim") %>" />
                </div>
                <div>
                    <div class="baslik">
                        <a href='MakaleIcerik.aspx?MakaleID=<%# Eval("ID") %>'>
                            <h2>
                                <%# Eval("Baslik") %>
                            </h2>
                        </a>
                    </div>
                    <div class="detay">
                        <label>Kategori:</label><%# Eval("Kategori") %> |
                        <label>Tarih:</label><%# Eval("TarihStr") %> | 
                    </div>
                    <div class="ozet">
                        <%# Eval("Ozet") %>
                    </div>
                    <div  class="devami"><a  href='MakaleIcerik.aspx?MakaleID=<%# Eval("ID") %>'>Devamını Oku >>></a>
</div>


                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
