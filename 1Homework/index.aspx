<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="_1Homework.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <%-- Page Tittle --%>
    <title>Index | Cowabunga </title>
    <%-- Style References --%>
    <link href="Bootstrap/css/background.css" rel="stylesheet" />
    <link href="Bootstrap/css/bootstrap.min.css" rel="stylesheet" />
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

    <%-- Page Header --%>
    <header class="position-relative navbar navbar-dark navbar-expand-md fixed-top bg-warning bg-opacity-75 rounded-bottom">
        <%-- Navigation bar and Icon --%>
        <section class="container-fluid">
            <%-- Icon --%>
            <div class="container">
                <a class="navbar-brand float-start" href="index.aspx">
                    <img src="IMGS/poster.png" width="50" />
                </a>
            </div>
            <%-- Log Out --%>
            <nav>
                <ul class="navbar-nav mx-auto">
                    <li class="nav-item"><a class="nav-link"
                        href="login.aspx">Log Out</a></li>
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
                <header role="button" href="#videoCollapse" data-bs-toggle="collapse" aria-controls="videoCollapse" aria-expanded="false">
                    <img width="50" src="IMGS/televisor.png" class="d-inline me-2" />
                    <h1 class="d-inline border-end border-3 pe-3 align-middle">Video</h1>
                    <h5 class="d-inline ps-2">Let's watch something, here you have a video. Also, you can upload the link of your favorite youtube video.</h5>
                </header>
                <%-- Video player and uploader --%>
                <aside runat="server" class="mt-3 collapse" id="videoCollapse">
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
                        width="460"
                        height="250"
                        src="https://www.youtube.com/embed/D7kz1LvX8vA"
                        frameborder="0"
                        class="rounded-3"
                        allowfullscreen></iframe>
                </aside>
            </article>
        </section>

        <%-- Videogame section --%>
        <section class="position-relative container-fluid mt-3">
            <article class="w-100 bg-info bg-opacity-50 p-3 text-light rounded-3 shadow">
                <%-- Tittle of the videogame section --%>
                <header role="button" href="#gameCollapse" data-bs-toggle="collapse" aria-controls="gameCollapse" aria-expanded="false">
                    <img width="50" src="IMGS/arcada.png" class="d-inline me-2" />
                    <h1 class="d-inline border-end border-3 pe-3 align-middle">Videogame</h1>
                    <h5 class="d-inline ps-2">Let's play hangman! You have 6 opportunities to guess the word. All words are related to 80's and 90's gear.</h5>
                </header>
                <%-- Hangman display --%>
                <aside runat="server" class="mt-3 collapse" id="gameCollapse">
                    <%-- Button to generate the game --%>
                    <asp:Button class="btn btn-primary my-3 d-inline" ID="generateGame" runat="server" Text="Generate Game!" OnClick="generateGame_Click" />
                    <asp:Label class="d-inline" ID="results" runat="server" Text=""></asp:Label>
                        
                    <%-- Game display hidden until the game has started --%>
                    <div runat="server" id="gameDisplay" visible="false">
                        <%-- Display the amount of opportunities the player has --%>
                        <div class="d-block my-3">
                            <h5 class="d-inline">Your opportunities: </h5>
                            <asp:Label class="d-inline ms-2 fw-bold text-decoration-underline" ID="opportunities" runat="server" Text=""></asp:Label>
                        </div>
                        <%-- Display the word to be completed by the player --%>
                        <div class="d-block my-3">
                            <h5 class="d-inline">Word: </h5>
                            <asp:Label class="d-inline text-light" ID="word" runat="server" Text=""></asp:Label>
                            <asp:Label class="d-inline text-light" ID="letterNum" runat="server" Text=""></asp:Label>
                        </div>
                        <%-- Input to guess the letters --%>
                        <div class="d-block my-3 w-50">
                            <h5 class="d-inline">Write a letter to guess: </h5>
                            <asp:TextBox class="d-inline form-control ms-2 w-25 opacity-75" ID="letterGuessed" runat="server"></asp:TextBox>
                            <asp:Button class="d-inline btn btn-primary ms-2" ID="guessLetter" runat="server" Text="Guess" OnClick="guessLetter_Click" />
                            <%-- Display a message if the letter guessed is or not part of the word --%>
                            <asp:Label class="d-inline ms-2" ID="chance" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </aside>
            </article>
        </section>

        <%-- Drawing section --%>
        <section class="position-relative container-fluid mt-3 mb-3">
            <article class="w-100 bg-primary bg-opacity-50 p-3 text-light rounded-3 shadow">
                <%-- Tittle of the drawing section --%>
                <div role="button" href="#drawingCollapse" data-bs-toggle="collapse" aria-controls="drawingCollapse" aria-expanded="false">
                    <img width="50" src="IMGS/tintero.png" class="d-inline me-2" />
                    <h1 class="d-inline border-end border-3 pe-3 align-middle">Drawing</h1>
                    <h5 class="d-inline ps-2">Let's draw some shapes, you can choose the shape and its color.</h5>
                </div>
                <%-- Drawing section with the selectors of the shape and color --%>
                <div runat="server" class="mt-3 p-1 collapse" id="drawingCollapse">
                    <select id="shapeSelector" runat="server" class="form-select w-25 d-inline">
                        <option selected="selected" value="0">Square</option>
                        <option value="1">Circle</option>
                        <option value="2">Diamond</option>
                        <option value="3">Heart</option>
                    </select>
                    <%-- Color picker for the inside of the shape --%>
                    <input style="top: 7px;" id="colorPicker" runat="server" type="color" value="#FF0000" class="d-inline-block border-0 ms-2 form-control form-control-color position-relative" />
                    <%-- Button to create the desired shape --%>
                    <asp:Button ID="shapeDraw" Style="top: -20px;" runat="server" Text="Draw!" OnClick="shapeDraw_Click" class="ms-2 btn btn-success d-inline opacity-100" />
                </div>
            </article>
        </section>
    </form>
    <%-- Bootstrap script reference --%>
    <script src="Bootstrap/js/bootstrap.bundle.min.js"></script>
</body>
</html>
