<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ServiceDesk.Views.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../Assets/Lib/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class="row mt-5 mb-5"></div>
    <asp:Panel ID="Panel1" runat="server" BorderWidth="10px" BorderColor="Teal" >
        <div class="container-fluid" >
            <div class="row mt-5 mb-5"></div>
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4">
                    <form id="form1" runat="server">
                        <div>
                            <div class="row">
                                <div class="col-md-4"></div>
                                <div class="col-md-8">
                                    <img src="../Assets/Images/Login.png"/>
                                </div>
                            </div>
                        </div>
                        <div class="mt-3">
                            <h2 style="text-align:center">Авторизация</h2>
                        </div>
                        <div class="mt-3">
                            <label for="Login" class="form-label">Логин</label>
                            <input class="form-control" id="Login" runat="server" required="required" placeholder="Логин"/>
                        </div>
                        <div class="mt-3">
                            <label for="Password" class="form-label">Пароль</label>
                            <input type="password" class="form-control" id="Password" runat="server" required="required" placeholder="Пароль"/>
                        </div>
                        <asp:Label ID="Label1" runat="server" Text="" ForeColor="DarkRed"></asp:Label>
                        <div class="mt-3 d-grid">
                            <asp:Button ID="loginBtn" runat="server" style="text-align:center" Text="Приступить к работе" CssClass="btn-group" OnClick="loginBtn_Click" ></asp:Button>  
                        </div>
                    </form>
                </div>
                <div class="col-md-4"></div>
            </div>
        </div> 
        <div class="row mt-5 mb-5"></div>
    </asp:Panel>
</body>
</html>
