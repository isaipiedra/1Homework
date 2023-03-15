<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="logIn.aspx.cs" Inherits="_1Homework.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%-- Page Tittle --%>
    <title>Log In</title>
    <%-- Style References --%>
    <link href="Bootstrap/css/background.css" rel="stylesheet" />
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css" rel="stylesheet" />
</head>
<body>
    <%-- Page Background --%>
    <div class="background">
        <%-- Individual circles of the backgroung animation --%>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
        <span></span>
    </div>

    <%-- Main Login --%>
    <main class="section d-flex h-100 position-absolute">
        <section class="row h-100 justify-content-center align-self-center">
            <%-- Side login --%>
            <article class="px-5 w-100 col-md-6 col-lg-5 ml-auto d-flex bg-light bg-opacity-25 align-items-center rounded-end text-light">
                <aside>
                    <%-- Icon and description --%>
                    <div class="mb-4">
                        <img class="float-start me-2" width="50" src="IMGS/poster.png" />
                        <h1 class="ps-3">Welcome!</h1>
                    </div>
                    <p class="">Write down your credentials to access our page.</p>
                    <div id="credentialAlert" runat="server" class="alert alert-danger visually-hidden" role="alert">
                        <i class='bx bx-error-alt'></i>
                        <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
                    </div>
                    <%-- Log In form --%>
                    <form id="form1" runat="server">
                        <%-- Username icon and input --%>
                        <figure class="input-group mb-3 w-100">
                            <span class="input-group-text bg-info border-0">
                                <i class="bx bxs-user text-light"></i>
                            </span>
                            <asp:TextBox ID="username" runat="server" class="form-control bg-light bg-opacity-50" placeholder="Username"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="usName" runat="server" ControlToValidate="username" ErrorMessage="Enter a username" ForeColor="Red" class="ps-2"></asp:RequiredFieldValidator>
                        </figure>
                        <%-- Password icon and input --%>
                        <figure class="input-group mb-3 w-100">
                            <span class="input-group-text bg-info border-0">
                                <i class="bx bxs-lock-alt text-light"></i>
                            </span>
                            <asp:TextBox ID="password" runat="server" class="form-control bg-light bg-opacity-50" placeholder="Password" autocomplete="off" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="pass" runat="server" ControlToValidate="password" ErrorMessage="Enter a password" ForeColor="Red" class="ps-2"></asp:RequiredFieldValidator>
                        </figure>
                        <%-- Submit button --%>
                        <span>
                            <asp:Button ID="submitLogIn" runat="server" Text="Log In" class="btn btn-success w-25" onClick="submitLogIn_Click" />
                        </span>
                    </form>
                </aside>
            </article>
        </section>
    </main>
</body>
<%-- Bootstrap script reference --%>
<script src="Bootstrap/js/bootstrap.js"></script>
</html>