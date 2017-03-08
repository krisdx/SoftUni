<%--suppress CheckTagEmptyBody --%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Home</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/static/css/home.css">
</head>
<body>
    <jsp:include page="menu.jsp"></jsp:include>
    <div class="container">
        <h1 id="welcome" class="h1">Welcome to Issue Tracker</h1>
    </div>
    <script src="${pageContext.request.contextPath}\static\jquery\jquery.min.js"></script>
    <script src="${pageContext.request.contextPath}\static\bootstrap\js\bootstrap.min.js"></script>
    <script>
        $("#home").addClass("active");
    </script>
</body>
</html>