<%--suppress ALL --%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <title>Cart</title>
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
                <a class="navbar-brand" href="#">SoftUni Store</a>

                <div class="collapse navbar-collapse" id="navbarSupportedContent">
                    <ul class="navbar-nav mr-auto">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Cart</a>
                        </li>
                    </ul>
                    <ul class="navbar-nav">
                        <li class="nav-item">
                            <a class="nav-link" href="#">Login</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="#">Register</a>
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
                    <div class="text-center"><h1 class="display-3">Your Cart</h1></div>
                    <br>
                    <br>

                    <c:choose>
                        <c:when test="${sessionScope.currentUser != null}>">
                            <c:forEach items="${orders}" var="order">
                                <div class="list-group">
                                    <div class="list-group-item">
                                        <a class="btn btn-outline-danger btn-lg" href="#">X</a>
                                        <div class="media col-3">
                                            <figure class="pull-left">
                                                <a href="#">
                                                    <img
                                                            class="card-image-top img-fluid img-thumbnail"
                                                            onerror="this.src='https://i.ytimg.com/vi/BqJyluskTfM/maxresdefault.jpg';"
                                                            src="https://i.ytimg.com/vi/BqJyluskTfM/maxresdefault.jpg"></a>
                                            </figure>
                                        </div>
                                        <div class="col-md-6">
                                            <a href="#"><h4 class="list-group-item-heading"> Mass Effect Andromeda </h4></a>
                                            <p class="list-group-item-text"> Mass Effect: Andromeda is an action role-playing game in which the player takes control of either Scott or Sara Ryder from a third-person perspective.
                                            </p>
                                        </div>
                                        <div class="col-md-2 text-center mr-auto">
                                            <h2> ${order.getPrice()}&euro; </h2>
                                        </div>
                                    </div>

                                    <div class="list-group-item">
                                        <a class="btn btn-outline-danger btn-lg" href="#">X</a>
                                        <div class="media col-3">
                                            <figure class="pull-left">
                                                <a href="#">
                                                    <img
                                                            class="card-image-top img-fluid img-thumbnail"
                                                            onerror="this.src='https://i.ytimg.com/vi/BqJyluskTfM/maxresdefault.jpg';"
                                                            src="https://i.ytimg.com/vi/BqJyluskTfM/maxresdefault.jpg"></a>
                                            </figure>
                                        </div>
                                        <div class="col-md-6">
                                            <a href="#"><h4 class="list-group-item-heading"> Mass Effect Andromeda </h4></a>
                                            <p class="list-group-item-text"> Mass Effect: Andromeda is an action role-playing game in which the player takes control of either Scott or Sara Ryder from a third-person perspective.
                                            </p>
                                        </div>
                                        <div class="col-md-2 text-center mr-auto">
                                            <h2> 60&euro; </h2>
                                        </div>
                                    </div>
                                </div>
                            </c:forEach>
                        </c:when>
                        <c:otherwise>
                            <div class="container">
                                <div class="alert alert-warning alert-dismissable">
                                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                                    Your chart is empty.
                                </div>
                            </div>
                        </c:otherwise>
                    </c:choose>

                    <div class="col-8 offset-2 my-3 text-center">
                        <h1><strong>Total Price - </strong> 120 &euro;</h1>
                    </div>
                    <div class="col-8 offset-2 my-3">
                        <form method="post">
                            <input type="submit" class="btn btn-success btn-lg btn-block" value="Order"/>
                        </form>
                    </div>
                    <br>
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