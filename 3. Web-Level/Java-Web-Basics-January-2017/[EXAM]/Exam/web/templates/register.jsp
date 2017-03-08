<%--suppress CheckTagEmptyBody --%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Register</title>

    <link rel="stylesheet" href="${pageContext.request.contextPath}/static/bootstrap.min.css/"/>
    <script src="${pageContext.request.contextPath}/static/jquery.min.js"></script>
    <script src="${pageContext.request.contextPath}/static/bootstrap.min.js"></script>
    <style>
        #duplicate-email {
            margin-top: 20px;
        }
    </style>
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
                        <li class="nav-item">
                            <a class="nav-link" href="/login">Login</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" href="/register">Register</a>
                        </li>
                    </ul>
                </div>

            </div>
        </nav>
    </header>

    <c:choose>
        <c:when test="${duplicateEmail != null}">
            <div class="container">
                <div id="duplicate-email" class="alert alert-danger alert-dismissable">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    User with email <strong>${duplicateEmail}</strong> already exists.
                </div>
            </div>
        </c:when>
    </c:choose>

    <main class="col-4 offset-4 text-center">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="text-center"><h1 class="display-3">Register</h1></div>
                    <br>
                    <form method="post">
                        <div class="form-group row">
                            <label class="sr-only">Email</label>
                            <input name="email" class="form-control" placeholder="somebody@example.com"/>
                        </div>

                        <div class="form-group row">
                            <label class="sr-only">Full Name</label>
                            <input type="text" name="fullName" pattern="^[a-zA-Z -.]+$" class="form-control" placeholder="Full Name"/>
                        </div>

                        <div class="form-group row">
                            <label class="sr-only">Password</label>
                            <input name="password" type="password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" class="form-control" placeholder="Password"/>
                        </div>

                        <div class="form-group row">
                            <label class="sr-only">Confirm Password</label>
                            <input name="confirmPassword" type="password" pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" class="form-control" placeholder="Confirm Password"/>
                        </div>

                        <input type="submit" class="btn btn-outline-warning btn-lg btn-block"
                               value="Register"/>
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