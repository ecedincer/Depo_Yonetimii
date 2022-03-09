<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Musteriler.aspx.cs" Inherits="Depo_Yonetimi.Musteriler" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="row my-3">
            <div class="col">
                <table class="table d-sm-table-cell d-sm-table-row table-borderless " style="padding-left: 100px;">
                    <tr>
                        <th>
                            <asp:Label Text="Müşteri ID : " runat="server" />
                        </th>
                        <th>
                            <asp:TextBox Enabled="false" runat="server" ID="txtmID" />
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Şirket Adı : " runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" MaxLength="50" ID="txtmAd" />
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Kontak Adı : " runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" MaxLength="50" ID="txtKontak" />
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Ünvan : " runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" MaxLength="50" ID="txtUnvan" />
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Telefon :" runat="server" />
                        </th>
                        <th>
                           
                            <asp:TextBox  runat="server" TextMode="Number" MaxLength="10" ID="txtTelefon"/>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Adres :" runat="server" />
                        </th>
                        <th>
                            <asp:TextBox runat="server" ID="txtAdres" MaxLength="200" />
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
                            <asp:Label Text="İlçe :" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" ID="drpIlce" AutoPostBack="true" OnSelectedIndexChanged="drpIlce_SelectedIndexChanged" OnDataBound="drpIlce_DataBound">
                            </asp:DropDownList>
                        </th>
                    </tr>
                    <tr>
                        <th>
                            <asp:Label Text="Mah :" runat="server" />
                        </th>
                        <th>
                            <asp:DropDownList runat="server" ID="drpMah"  AutoPostBack="true" OnDataBound="drpMah_DataBound">
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
                <table class="table-bordered">
                    <tr>
                        <td>-Müşteri ID-</td>
                        <td>-Şirket Adı-</td>
                        <td>-Kontak Adı-</td>
                        <td>-Ünvan-</td>
                        <td>-Telefon-</td>
                        <td>-Adres-</td>
                        <td>-Şehir-</td>
                        <td>-İlçe-</td>
                        <td>-Mah-</td>                        
                        <td>-Güncelle-</td>
                        <td>-Sil-</td>
                        
                    </tr>
                    <asp:Repeater runat="server" ID="rptMusteri">
                        <ItemTemplate>
                            <tr>
                                <td><asp:Label ID="mID" Text='<%#Eval("MusteriID") %>' runat="server" /></td>
                                <td><asp:Label ID="mAd" Text='<%#Eval("SirketAdi") %>' runat="server" /></td>
                                <td><asp:Label ID="mKontak" Text='<%#Eval("Kontak") %>' runat="server" /></td>
                                <td><asp:Label ID="Unvan" Text='<%#Eval("Unvan") %>' runat="server" /></td>
                                <td><asp:Label ID="Tel" Text='<%#Eval("Telefon") %>' runat="server" /></td>
                                <td><asp:Label ID="mAdres" Text='<%#Eval("Adres") %>' runat="server" /></td>
                                <td><asp:Label ID="SehirID" Text='<%#Eval("SehirAdi") %>' runat="server" /></td>
                                <td><asp:Label ID="IlceID" Text='<%#Eval("IlceAdi") %>' runat="server" /></td>
                                <td><asp:Label ID="MahID" Text='<%#Eval("MahalleAdi") %>' runat="server" /></td>
                                
                                
                                <td><asp:LinkButton Text="Güncelle" runat="server" ID="MusteriSec" OnClick="MusteriSec_Click" /></td>
                                <td><asp:LinkButton runat="server" ID="btnSil" Text="Sil" OnClientClick="return confirm('Bu Kaydı Silmek İstediğinize Emin misiniz?');" OnClick="btnSil_Click" /></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </table>
            </div>
        </div>
    </div>




</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
