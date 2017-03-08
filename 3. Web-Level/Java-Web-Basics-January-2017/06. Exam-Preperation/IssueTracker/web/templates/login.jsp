<%--suppress ALL --%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Log In</title>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/static/css/action.css"/>
</head>
<body>
    <jsp:include page="menu.jsp"></jsp:include>

    <c:choose>
        <c:when test="${successfulRegistration != null}">
            <div class="container">
                <div class="alert alert-success alert-dismissable">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>${successfulRegistration}</strong>
                </div>
            </div>
        </c:when>
    </c:choose>

    <c:choose>
        <c:when test="${unexistingUser != null}">
            <div class="container">
                <div class="alert alert-danger alert-dismissable">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>${unexistingUser}</strong>
                </div>
            </div>
        </c:when>
    </c:choose>

    <c:choose>
        <c:when test="${notLoggedIn != null}">
            <div class="container">
                <div class="alert alert-danger alert-dismissable">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>${notLoggedIn}</strong>
                </div>
            </div>
        </c:when>
    </c:choose>

    <br/>
    <div class="container">
        <div class="row">
            <div class="jumbotron">
                <form method="post">
                    <div class="form-group">
                        <input name="username" type="text" class="form-control" placeholder="Enter username">
                    </div>
                    <div class="form-group">
                        <input name="password" type="password" class="form-control" placeholder="Enter password">
                    </div>
                    <div class="form-group">
                        <input class="btn btn-primary" type="submit" value="Log In">
                        <a href="${pageContext.request.contextPath}/" class="btn btn-primary">Cancel</a>
                        <a href="${pageContext.request.contextPath}/register" style="padding-left: 20px">Not Register? Click here</a>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script>
        $("#login").addClass("active");
    </script>
</body>
</html>