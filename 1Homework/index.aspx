﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_1Homework.index" %>

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
    <%-- Video section --%>
    <section class="position-relative container-fluid mt-3">
        <article class="w-100 bg-success bg-opacity-50 p-3 text-light rounded-3 shadow">
            <h1 class="d-inline border-end border-3 pe-3 align-middle">Video</h1>
            <h5 class="d-inline ps-2">Let's watch something, here you have a video.</h5>
        </article>
    </section>

    <%-- Videogame section --%>
    <section class="position-relative container-fluid mt-3">
        <article class="w-100 bg-info bg-opacity-50 p-3 text-light rounded-3 shadow">
            <div class="d-block">
                <h1 class="d-inline border-end border-3 pe-3 align-middle">Videogame</h1>
                <h5 class="d-inline p-2">Let's play something, can you beat the machine?</h5>
            </div>
        </article>
    </section>

    <%-- Drawing section --%>
    <section class="position-relative container-fluid mt-3">
        <article class="w-100 bg-primary bg-opacity-50 p-3 text-light rounded-3 shadow">
            <h1 class="d-inline border-end border-3 pe-3 align-middle">Drawing</h1>
            <h5 class="d-inline ps-2">Let's draw something, select a fruit to be drawn.</h5>
        </article>
    </section>
    <form id="form1" runat="server">
        <div>
        </div>
    </form>
</body>
<%-- Bootstrap script reference --%>
<script src="Bootstrap/js/bootstrap.js"></script>
</html>
