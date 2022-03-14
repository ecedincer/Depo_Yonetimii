<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Depolar.aspx.cs" Inherits="Depo_Yonetimi.Depolar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
         .auto-style2 {
             height: 27px;
         }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="container">
        <div class="row my-3">
            <div class="col">
                <table class="table d-sm-table-cell d-sm-table-row table-borderless " style="padding-left: 100px;">
                    <tr>
                        <th>
                            <asp:Label Text="Depo ID : " runat="server" />
                        </th>
                        <th>
                            <asp:TextBox Enabled="false" runat="server" ID="txtdID" />
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Depo Adı : " runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" MaxLength="50" ID="txtdAd" />
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Depo Adresi : " runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" MaxLength="50" ID="txtAdres" />
                        </th>
                    </tr>
                       <tr>
                        <th>
                            <asp:Label Text="Depo Kapasitesi : " runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" MaxLength="50" ID="txtKapasite" />
                        </th>
                    </tr>
                      <tr>
                        <th>
                            <asp:Label Text="Depo Türü :" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" ID="drpDTuru" AutoPostBack="true"  OnSelectedIndexChanged="drpTuru_SelectedIndexChanged" OnDataBound="drpTuru_DataBound">                               
                            </asp:DropDownList>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Şehir :" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" ID="drpSehir" AutoPostBack="true"  OnSelectedIndexChanged="drpSehir_SelectedIndexChanged" OnDataBound="drpSehir_DataBound">                               
                            </asp:DropDownList>
                        </th>
                    </tr>
                      <tr>
                        <th>
                            <asp:Label Text="ilçe :" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" ID="drpIlce" AutoPostBack="true"  OnSelectedIndexChanged="drpIlce_SelectedIndexChanged" OnDataBound="drpIlce_DataBound">                               
                            </asp:DropDownList>
                        </th>
                    </tr>

                    <tr>
                        <th></th>
                        <th>
                            <asp:Button Text="Kaydet" runat="server" class="btn btn-outline-dark" ID="btnKaydet" Style="width: 100px;" OnClick="btnKaydet_Click" />
                        </th>

                    </tr>
                </table>
            </div>
        </div>
        <div class="row my-2">
            <div class="col">
                <table class="table table-bordered">
                    <tr>
                        <td>-Depo ID-</td>
                        <td>-Depo Adı-</td>
                        <td>-Depo Turu-</td>
                        <td>-Adres-</td>
                        <td>-Şehir-</td>
                        <td>-İlçe-</td>
                        <td>-Güncelle-</td>
                        <td>-Sil-</td>
                        
                    </tr>
                    <asp:Repeater runat="server" ID="rptDepo">
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="dID" Text='<%#Eval("DepolarID") %>' runat="server" /></td>
                                <td><asp:Label ID="dAd" Text='<%#Eval("DepoAdi") %>' runat="server" /></td>
                                <td><asp:Label ID="dTur" Text='<%#Eval("DepoTuruAdi") %>' runat="server" /></td>
                                <td><asp:Label ID="dAdres" Text='<%#Eval("Adres") %>' runat="server" /></td>
                                <td><asp:Label ID="SehirID" Text='<%#Eval("SehirAdi") %>' runat="server" /></td>
                                <td><asp:Label ID="IlceID" Text='<%#Eval("IlceAdi") %>' runat="server" /></td>
                                <td>
                                <asp:LinkButton Text="Güncelle" runat="server" ID="DepoSec" commandname="Update" CommandArgument='<%# Eval("DepolarID") %>' OnClick="DepoSec_Click" /></td>
                                <td>
                                <asp:LinkButton runat="server" ID="btnSil" Text="Sil" commandname="Delete" CommandArgument='<%# Eval("DepolarID") %>'  /></td>                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
