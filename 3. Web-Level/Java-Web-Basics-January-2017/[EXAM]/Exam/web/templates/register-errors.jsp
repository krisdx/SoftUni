<%--suppress CheckTagEmptyBody --%>
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

    <main class="col-4 offset-4 text-center">
        <div class="container">
            <div class="row">
                <div class="col-12">
                    <div class="text-center"><h1 class="display-3">Register</h1></div>
                    <br/>
                    <div class="alert alert-danger" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Oh snap!</strong> Invalid Password. It should be at least 6 symbols long, containing 1 uppercase letter, 1 lowercase letter and 1 digit.
                    </div>
                    <div class="alert alert-danger" role="alert">
                        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                        <strong>Oh snap!</strong> Invalid Password. It should be at least 6 symbols long, containing 1 uppercase letter, 1 lowercase letter and 1 digit.
                    </div>
                    <form>

                        <div class="form-group row">
                            <label class="sr-only">Email</label>
                            <input class="form-control" placeholder="somebody@example.com"/>
                        </div>

                        <div class="form-group row">
                            <label class="sr-only">Full Name</label>
                            <input pattern="^[a-zA-Z -.]+$" class="form-control" placeholder="Full Name"/>
                        </div>

                        <div class="form-group row">
                            <label class="sr-only">Password</label>
                            <input pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" class="form-control" placeholder="Password"/>
                        </div>

                        <div class="form-group row">
                            <label class="sr-only">Confirm Password</label>
                            <input pattern="(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}" class="form-control" placeholder="Confirm Password"/>
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