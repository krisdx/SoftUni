<%--suppress ALL --%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <title>Game Details</title>
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
    <main>
        <div class="container">
            <div class="row">
                <div class="col-12 text-center">

                    <c:set var="gameBindingModel" value="${gameBindingModel}"></c:set>
                    <h1 class="display-3">${gameBindingModel.getTitle()}</h1>
                    <br>

                    <iframe width="560" height="315" src="https://www.youtube.com/embed/${gameBindingModel.getTrailer()}" frameborder="0" allowfullscreen></iframe>
                    <br>
                    <br>
                    <p>${gameBindingModel.getDescription()}</p>

                    <p><strong>Price</strong> - ${gameBindingModel.getPrice()} &euro;</p>
                    <p><strong>Size</strong> - ${gameBindingModel.getSize()} GB</p>
                    <p><strong>Release Date</strong> - ${gameBindingModel.getReleaseDate()}</p>

                    <a class="btn btn-outline-primary" href="/">Back</a>
                    <c:choose>
                        <c:when test="${sessionScope.currentUser.getRole() == \"ADMIN\"}">
                            <a class="btn btn-warning" href="/games/edit/${gameBindingModel.getId()}">Edit</a>
                            <a class="btn btn-danger" href="/games/delete/${gameBindingModel.getId()}">Delete</a>
                        </c:when>
                    </c:choose>
                    <a class="btn btn-primary" href="#">Buy</a>
                    <br>
                    <br>
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