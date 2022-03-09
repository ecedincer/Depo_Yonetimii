<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DepoYonetimi.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>..:: Giriş Yap ::..</title>
     <!-- Google Font: Source Sans Pro -->
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700&display=fallback">
    <!-- Font Awesome -->
    <link rel="stylesheet" href="Tasarım/plugins/fontawesome-free/css/all.min.css">
    <!-- icheck bootstrap -->
    <link rel="stylesheet" href="Tasarım/plugins/icheck-bootstrap/icheck-bootstrap.min.css">
    <!-- Theme style -->
    <link rel="stylesheet" href="Tasarım/dist/css/adminlte.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <center>
            <div class="login-box">
                <div class="login-logo">
                    <a href="#"><b>Depo</b>YÖNETİM</a>
                </div>
                <!-- /.login-logo -->

                <div class="card">
                    <div class="card-body login-card-body">
                        <p class="login-box-msg">Kullanmak için giriş yap !</p>


                        <div class="input-group mb-3">
                            <asp:TextBox runat="server" TextMode="Email" CssClass="form-control" placeholder="Email" ID="txtEmail"  />
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-envelope"></span>
                                </div>
                            </div>
                        </div>
                        <div class="input-group mb-3">
                            <asp:TextBox runat="server" TextMode="Password" CssClass="form-control" placeholder="Password" ID="txtPassword" />
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-lock"></span>
                                </div>
                            </div>
                        </div>

                        <div class="input-group mb-3">
                            <asp:TextBox runat="server" TextMode="Number" CssClass="form-control" placeholder="Doğrulama kodu" ID="txtdkod"  Visible="false" />
                            <div class="input-group-append">
                                <div class="input-group-text">
                                    <span class="fas fa-envelope"></span>
                                </div>
                            </div>
                        </div>

                           

                        <center>                            
                                                  
                            <!-- /.col -->                            
                                <asp:Button Text="Giriş" CssClass="btn btn-primary btn-danger" runat="server" ID="btnGiris" OnClick="btnGiris_Click" />                            
                            <!-- /.col -->                       
                            </center>


                        <center>                            
                                                  
                            <!-- /.col -->                            
                                <asp:Button Text="Giriş" CssClass="btn btn-primary btn-danger" runat="server" ID="btnGirisKod" Visible="false" OnClick="btnGirisKod_Click" />                            
                            <!-- /.col -->                       
                            </center>
                        <br />
                        <br />
                        <br />

                        
                        <!-- /.social-auth-links -->

                        <p class="mb-1">
                            <a href="#">Şifremi Unuttum</a>
                        </p>
                       
                    </div>
                    <!-- /.login-card-body -->
                </div>

            </div>
        </center>
        <script src="Tasarım/plugins/jquery/jquery.min.js"></script>
        <!-- Bootstrap 4 -->
        <script src="Tasarım/plugins/bootstrap/js/bootstrap.bundle.min.js"></script>
        <!-- AdminLTE App -->
        <script src="Tasarım/dist/js/adminlte.min.js"></script>


    </form>
</body>
</html>
