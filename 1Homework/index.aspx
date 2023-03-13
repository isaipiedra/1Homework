<%@ Page Language="C#" MaintainScrollPositionOnPostBack="true" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_1Homework.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%-- Page Tittle --%>
    <title>Index</title>
    <%-- Style References --%>
    <link href="Bootstrap/css/background.css" rel="stylesheet" />
    <link href="Bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href='https://unpkg.com/boxicons@2.1.4/css/boxicons.min.css' rel='stylesheet' />
</head>
<body>
    <%-- Page Background --%>
    <div class='background'>
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
    <%-- Page Header --%>
    <header class='position-relative navbar navbar-dark navbar-expand-md fixed-top bg-warning bg-opacity-75 rounded-bottom'>
        <%-- Navigation bar and Icon --%>
        <section class='container-fluid'>
            <%-- Icon --%>
            <div class="container">
                <a class="navbar-brand" href="index.aspx">
                    <img src="IMGS/laugh.png" alt="" width="50" />
                </a>
            </div>
            <%-- Responsive toggler --%>
            <button class='navbar-toggler' type='button'
                data-bs-toggle='collapse' data-bs-target='#myNavbarToggler7'
                aria-controls='navbarNav' aria-expanded='false'
                aria-label='Toggle navigation'>
                <span class='navbar-toggler-icon'></span>
            </button>
            <%-- Log Out --%>
            <nav class='collapse navbar-collapse' id='myNavbarToggler7'>
                <ul class='navbar-nav mx-auto'>
                    <li class='nav-item'><a class='nav-link'
                        href='login.aspx'>Log Out</a></li>
                </ul>
            </nav>
        </section>
    </header>

    <%-- Page functions --%>
    <form id="form1" runat="server">

        <%-- Video section --%>
        <section class="position-relative container-fluid mt-3">
            <article class="w-100 bg-success bg-opacity-50 p-3 text-light rounded-3 shadow">
                <%-- Tittle of the video section --%>
                <div>
                    <h1 class="d-inline border-end border-3 pe-3 align-middle">Video</h1>
                    <h5 class="d-inline ps-2">Let's watch something, here you have a video. Also, you can upload the link of your favorite youtube video.</h5>
                    <img width="50" src="IMGS/televisor.png" class="float-start me-2"/>
                </div>
                <%-- Video player and uploader --%>
                <div class="w-100 align-content-center mt-4">
                    <%-- Video selector / uploader for the user --%>
                    <div class="mb-3">
                        <asp:TextBox ID="videoUrl" runat="server" class="form-control w-50 d-inline opacity-75" placeholder="Video url - ONLY YOUTUBE ALLOWED"></asp:TextBox>
                        <asp:Button ID="loadVideo" runat="server" Text="Load" OnClick="loadVideo_Click" class="ms-3 btn btn-info d-inline opacity-100" />
                    </div>
                    <%-- Video player with default video --%>
                    <iframe
                        name="videoTag"
                        id="videoTag"
                        runat="server"
                        width="560"
                        height="315"
                        src="https://www.youtube.com/embed/D7kz1LvX8vA"
                        frameborder="0"
                        class="rounded-3"
                        allowfullscreen></iframe>
                    </div>
            </article>
        </section>

        <%-- Videogame section --%>
        <section class="position-relative container-fluid mt-3">
            <article class="w-100 bg-info bg-opacity-50 p-3 text-light rounded-3 shadow">
                <%-- Tittle of the videogame section --%>
                <div>
                    <h1 class="d-inline border-end border-3 pe-3 align-middle">Videogame</h1>
                    <h5 class="d-inline ps-2">Let's play something, can you beat the machine?</h5>
                    <img width="50" src="IMGS/arcada.png" class="float-start me-2"/>
                </div>
            </article>
        </section>

        <%-- Drawing section --%>
        <section class="position-relative container-fluid mt-3 mb-3">
            <article class="w-100 bg-primary bg-opacity-50 p-3 text-light rounded-3 shadow">
                <%-- Tittle of the drawing section --%>
                <div>
                    <h1 class="d-inline border-end border-3 pe-3 align-middle">Drawing</h1>
                    <h5 class="d-inline ps-2">Let's draw some shapes, you can choose the shape and its color.</h5>
                    <img width="50" src="IMGS/tintero.png" class="float-start me-2" />
                </div>
                <div class="mt-3 p-1">
                    <select id="shapeSelector" runat="server" class="form-select w-25 d-inline">
                        <option selected value="0">Square</option>
                        <option value="1">Circle</option>
                        <option value="2">Diamond</option>
                        <option value="3">Heart</option>
                    </select>
                    <input style="top:7px;" id="colorPicker" runat="server" type="color" name="colors" value="Black" class="d-inline-block border-0 ms-2 form-control form-control-color position-relative"/>
                    <asp:Button ID="shapeDraw" style="top:-20px;" runat="server" Text="Draw!" OnClick="shapeDraw_Click" class="ms-2 btn btn-success d-inline opacity-100" />
                </div>
            </article>
        </section>
    </form>
</body>
<%-- Bootstrap script reference --%>
<script src="Bootstrap/js/bootstrap.js"></script>
</html>
