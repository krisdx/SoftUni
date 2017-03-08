<%--suppress ALL --%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <title>Delete Game</title>
    <meta charset="UTF-8">

    <link rel="stylesheet" href="${pageContext.request.contextPath}/static/bootstrap.min.css/"/>
    <script src="${pageContext.request.contextPath}/static/jquery.min.js"></script>
    <script src="${pageContext.request.contextPath}/static/bootstrap.min.js"></script>
</head>
<body>
    <header>
        <nav class="navbar navbar-toggleable-md navbar-light bg-warning">
            <div class="container">
                <button class="navbar-toggler navbar-toggler-right" type="button" data-toggle="collapse"
                        data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false"
                        aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                </button>
                <a class="navbar-brand" href="/">SoftUni Store</a>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Cart</a>
                        </li>
                    </ul>
                    <ul class="navbar-nav">
                        <li class="nav-item dropdown">
                            <a class="nav-link dropdown-toggle" href="http://example.com" id="AdminDropdownMenuLink"
                               data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                                Admin
                            </a>
                            <div class="dropdown-menu" aria-labelledby="navbarDropdownMenuLink">
                                <a class="dropdown-item" href="/games">Games</a>
                            </div>
                        </li>

                        <li class="nav-item">
                            <c:choose>
                                <c:when test="${sessionScope.currentUser != null}">
                                    <c:set var="currentUser" value="${sessionScope.currentUser}"></c:set>
                                    <a class="nav-link" href="/logout">Logout (<strong>${currentUser.getFullName()}</strong>)</a>
                                </c:when>
                                <c:otherwise>
                                    <a class="nav-link" href="/logout">Logout</a>
                                </c:otherwise>
                            </c:choose>
                        </li>
                    </ul>
                </div>

            </div>
        </nav>
    </header>

    <!--Body of the store-->
    <main class="col-4 offset-4 text-center">
        <div class="container">
            <div class="row">
                <c:set var="gameModel" value="${gameBindingModel}"></c:set>
                <div class="col-12">
                    <div class="text-center"><h1 class="display-3">Delete Game - ${gameModel.getTitle()}</h1></div>
                    <br>
                    <form method="post">
                        <div class="form-group row">
                            <label class="form-control-label">Title</label>
                            <input name="title" pattern="[A-Z].{3,100}" class="form-control"
                                   placeholder="Enter Game Title" value="${gameModel.getTitle()}" disabled/>
                        </div>

                        <div class="form-group row">
                            <label class="form-control-label">Description</label>
                            <textarea name="description" class="form-control" placeholder="Enter Game Description" minlength="20" disabled>${gameModel.getDescription()}</textarea>
                        </div>

                        <div class="form-group row">
                            <label class="form-control-label">Thumbnail</label>
                            <input name="imageThumbnail" type="url" class="form-control" placeholder="Enter URL to Image" value="${gameModel.getImageThumbnail()}" disabled/>
                        </div>

                        <div class="form-group row">
                            <label class="form-control-label">Price</label>
                            <div class="input-group">
                                <input name="price" step="0.01" min="0" class="form-control" placeholder="Enter Price" value="${gameModel.getPrice()}" disabled/>
                                <span class="input-group-addon">&euro;</span>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="form-control-label">Size</label>
                            <div class="input-group">
                                <input name="size" step="0.1" min="0" class="form-control" placeholder="Enter Size" value="${gameModel.getSize()}" disabled/>
                                <span class="input-group-addon">GB</span>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="form-control-label">YouTube Video URL</label>
                            <div class="input-group">
                                <span class="input-group-addon">https://www.youtube.com/watch?v=</span>
                                <input name="trailer" class="form-control" minlength="11" maxlength="11" value="${gameModel.getTrailer()}" disabled/>
                            </div>
                        </div>

                        <div class="form-group row">
                            <label class="form-control-label">Release Date</label>
                            <input name="releaseDate" type="date" class="form-control" placeholder="yyyy-MM-dd" value="${gameModel.getReleaseDate()}" disabled/>
                        </div>

                        <input type="submit" class="btn btn-outline-warning btn-lg btn-block"
                               value="Delete Game"/>
                    </form>
                    <br/>
                </div>
            </div>
        </div>
    </main>

    <!--Footer-->
    <footer>
        <div class="container modal-footer">
            <p>&copy; 2017 - Software University Foundation</p>
        </div>
    </footer>
</body>
</html>