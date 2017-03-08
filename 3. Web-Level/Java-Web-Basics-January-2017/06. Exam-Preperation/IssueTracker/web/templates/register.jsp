<%--suppress CheckTagEmptyBody --%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Register</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/static/css/action.css"/>
</head>
<body>
<jsp:include page="menu.jsp"></jsp:include>
    <br>
    <c:forEach items="${constraintViolations}" var="violation">
        <div class="container">
            <div class="alert alert-danger alert-dismissable">
                <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                <strong>Error!</strong><span> ${violation.getMessage()}</span>
            </div>
        </div>
    </c:forEach>
    <c:choose>
        <c:when test="${passwordMismatch != null}">
            <div class="container">
                <div class="alert alert-danger alert-dismissable">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Error!</strong><span> Passwords are not matching.</span>
                </div>
            </div>
        </c:when>
        <c:when test="${duplicateUsername != null}">
            <div class="container">
                <div class="alert alert-danger alert-dismissable">
                    <a href="#" class="close" data-dismiss="alert" aria-label="close">&times;</a>
                    <strong>Error!</strong><span> User with ${duplicateUsername} username already exists.</span>
                </div>
            </div>
        </c:when>
    </c:choose>
    <div class="container">
        <div class="row">
            <div class="jumbotron">
                <form method="post">
                    <div class="form-group">
                        <input name="username" type="text" class="form-control" placeholder="Enter username">
                    </div>
                    <div class="form-group">
                        <input name="fullName" type="text" class="form-control" placeholder="Enter full name">
                    </div>
                    <div class="form-group">
                        <input name="password" type="password" class="form-control" placeholder="Enter password">
                    </div>
                    <div class="form-group">
                        <input name="repeatPassword" type="password" class="form-control" placeholder="Repeat password">
                    </div>
                    <div class="form-group">
                        <button type="submit" class="btn btn-primary">Register</button>
                        <a href="${pageContext.request.contextPath}/" class="btn btn-primary">Cancel</a>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>