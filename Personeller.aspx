<%@ Page Title="" Language="C#" MasterPageFile="~/Menu.Master" AutoEventWireup="true" CodeBehind="Personeller.aspx.cs" Inherits="Depo_Yonetimi.Personeller" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="container">
        <div class="row my-3">
            <div class="col">
                <div class="row">
                    <div class="col-6">
                        <div class="form-group">
                            <asp:Label Text="Personel ID : " runat="server" />
                            <asp:TextBox Enabled="false" runat="server" ID="txtpID" />
                        </div>
                        <div class="form-group">
                            <asp:Label Text="Personel TC : " runat="server" />
                            <asp:TextBox runat="server" MaxLength="11" ID="txtpTc" />
                        </div>
                    </div>

                    <div class="col-6">
                        <div class="form-group">

                            <asp:Label Text="Doğum Günü :" runat="server" />

                            <asp:TextBox TextMode="Date" runat="server" ID="txtpDogumGunu" MaxLength="200" />

                        </div>
                    </div>
                </div>
            </div>


            <table class="table d-sm-table-cell d-sm-table-row table-borderless " style="padding-left: 100px;">
                <tr>
                    <th></th>
                    <th></th>
                </tr>
                <tr>
                    <th></th>
                </tr>
                <tr>
                    <th>
                        <asp:Label Text="Personel Adı : " runat="server" />
                    </th>
                    <th>
                        <asp:TextBox runat="server" MaxLength="50" ID="txtpAd" />
                    </th>
                </tr>
                <tr>
                    <th>
                        <asp:Label Text="Personel Soyadı : " runat="server" />
                    </th>
                    <th>
                        <asp:TextBox runat="server" MaxLength="50" ID="txtpSoyad" />
                    </th>
                </tr>
                <tr>
                    <th>
                        <asp:Label Text="Ünvan : " runat="server" />
                    </th>
                    <th>
                        <asp:TextBox runat="server" MaxLength="50" ID="txtpUnvan" />
                    </th>
                </tr>
                <tr>
                    <th>
                        <asp:Label Text="Cinsiyet :" runat="server" />
                    </th>
                    <th>
        <asp:RadioButton ID="pCErkek" runat="server" Text="Erkek" GroupName="Cinsiyet" OnCheckedChanged="pCErkek_CheckedChanged" />      
                        </th>
                    <th>
        <asp:RadioButton ID="pCKadin" runat="server" Text="Kadın" GroupName="Cinsiyet"  OnCheckedChanged="pCKadin_CheckedChanged" />    
                    </th>
                </tr>
                <tr>
                    <th>
                        <%--<asp:Label Text="Doğum Günü :" runat="server" />--%>
                    </th>
                    <th>
                        <%--<asp:TextBox TextMode="Date" runat="server" ID="txtpDogumGunu" MaxLength="200" />--%>
                    </th>
                </tr>
                <tr>
                    <th class="auto-style1">
                        <asp:Label Text="Adres :" runat="server" />
                    </th>
                    <th class="auto-style1">

                        <asp:TextBox runat="server"  MaxLength="200" ID="txtpAdres" OnTextChanged="txtpAdres_TextChanged" />
                    </th>
                    </tr>
                    <tr>
                        <th class="auto-style1">
                           <asp:Label Text="Telefon :" runat="server" />
                    </th>
                    <th class="auto-style1">

                        <asp:TextBox runat="server" MaxLength="10" ID="txtpTelefon" />
                    </th>
                </tr>
                <tr>
                    <th>
                        <asp:Label Text="Şehir :" runat="server" />
                    </th>
                    <th>
                        <asp:DropDownList runat="server" ID="drpSehir" OnSelectedIndexChanged="drpSehir_SelectedIndexChanged" OnDataBound="drpSehir_DataBound">
                        </asp:DropDownList>
                    </th>
                </tr>
                <tr>
                    <th>
                        <asp:Label Text="İşe Başlama Tarihi :" runat="server" />
                    </th>
                    <th>
                        <asp:TextBox TextMode="Date" runat="server" ID="txtBaslangic" MaxLength="200" />
                    </th>
                </tr>
                <tr>
                    <th>
                        <asp:Label Text="İşten Ayrılma Tarihi :" runat="server" />
                    </th>
                    <th>
                        <asp:TextBox TextMode="Date" runat="server" ID="txtBitis" MaxLength="200" />
                    </th>
                </tr>
                 <tr>
                    <th>
                        <asp:Label Text="Email : " runat="server" />
                    </th>
                    <th>
                        <asp:TextBox runat="server" MaxLength="50" ID="txtMail" />
                    </th>
                </tr>
                                <tr>
                    <th>
                        <asp:Label Text="Depo :" runat="server" />
                    </th>
                    <th>
                        <asp:DropDownList runat="server" ID="drpDepo" OnSelectedIndexChanged="drpDepo_SelectedIndexChanged" OnDataBound="drpDepo_DataBound">
                        </asp:DropDownList>
                    </th>
                </tr>
                <tr>
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
                        <td>-Personel Id-</td>
                    <td>-Personel TC-</td>
                    <td>-Personel Adı-</td>
                    <td>-Personel Soyadı-</td>
                    <td>-Ünvan-</td>
                    <td>-Cinsiyet-</td>
                    <td>-Doğum Günü-</td>
                    <td>-Adres-</td>
                    <td>-Telefon-</td>
                    <td>-SehirAdi-</td>
                    <td>-IseBaslamaTarihi-</td>
                    <td>-IstenAyrilmaTarihi-</td>
                    <td>-Email-</td>
                    <td>-DepoAdi-</td>
                    <td>-Güncelle-</td>
                    <td>-Sil-</td>

                </tr>
                <asp:Repeater runat="server" ID="rptPersonel" OnItemCommand="rptPersonel_ItemCommand">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:Label ID="pID" Text='<%#Eval("PersonellerID") %>' runat="server" /></td>
                          <td>
                                <asp:Label ID="pTC" Text='<%#Eval("TC") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pAd" Text='<%#Eval("Adı") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pSoyad" Text='<%#Eval("Soyadı") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pUnvan" Text='<%#Eval("Unvan") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pCinsiyet" Text='<%#Eval("Cinsiyet") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pDogumGunu" Text='<%#Eval("DogumGunu","{0:dd.MM.yyyy}") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pAdres" Text='<%#Eval("Adres") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pTelefon" Text='<%#Eval("Telefon") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pSehir" Text='<%#Eval("SehirAdi") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pBaslangic" Text='<%#Eval("IsBasıTarihi") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pBitis" Text='<%#Eval("IsSonuTarihi") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="pMail" Text='<%#Eval("Email") %>' runat="server" /></td>
                            <td>
                                <asp:Label ID="Label1" Text='<%#Eval("DepoAdi") %>' runat="server" /></td>
                            <td>
                                <asp:LinkButton Text="Güncelle" runat="server" ID="PersonelSec" commandname="Update" CommandArgument='<%# Eval("PersonellerID") %>' OnClick="PersonelSec_Click" /></td>
                            <td>
                                <asp:LinkButton runat="server" ID="btnSil" Text="Sil" commandname="Delete" CommandArgument='<%# Eval("PersonellerID") %>'  /></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>



            </table>
        </div>
    </div>


</asp:Content>

