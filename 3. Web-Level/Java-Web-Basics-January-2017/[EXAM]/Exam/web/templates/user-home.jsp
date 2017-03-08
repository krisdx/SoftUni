<%--suppress ALL --%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <title>Game Store</title>
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
                        <a class="nav-link" href="/cart">Cart</a>
                    </li>
                </ul>
                <ul class="navbar-nav">
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
    <main>
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="text-center"><h1 class="display-3">SoftUni Store</h1></div>

                    <form class="form-inline" method="get">
                        Filter:
                        <input type="submit" name="filter" class="btn btn-link" value="All"/>
                        <input type="submit" name="filter" class="btn btn-link" value="Owned"/>
                    </form>

                    <c:forEach items="${games}" var="game">
                        <div class="card-group">
                            <div class="card col-4 thumbnail">
                                <img class="card-image-top img-fluid img-thumbnail" onerror="${game.getImageThumbnail()}"
                                     src="${game.getImageThumbnail()}">
                                <div class="card-block">
                                    <h4 class="card-title">${game.getTitle()}</h4>
                                    <p class="card-text"><strong>Price</strong> - ${game.getPrice()} &euro;</p>
                                    <p class="card-text"><strong>Size</strong> - ${game.getSize()} GB</p>
                                    <p class="card-text">${game.getDescription()}</p>
                                </div>
                                <div class="card-footer">
                                    <a class="card-button btn btn-outline-primary" name="info" href="/games/info/${game.getId()}">Info</a>
                                    <a class="card-button btn btn-primary" name="buy" href="#">Buy</a>
                                </div>
                            </div>
                        </div>
                    </c:forEach>
                </div>
            </div>
        </div>
    </main>
    <br/>

    <!--Footer-->
    <footer>
        <div class="container modal-footer">
            <p>&copy; 2017 - Software University Foundation</p>
        </div>
    </footer>
</body>
</html>