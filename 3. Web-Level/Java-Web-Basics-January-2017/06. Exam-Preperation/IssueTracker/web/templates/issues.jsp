<%--suppress ALL --%>
<%@ taglib prefix="c" uri="http://java.sun.com/jsp/jstl/core" %>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Issues</title>

    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.1.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/js/bootstrap.min.js"></script>
    <link rel="stylesheet" href="${pageContext.request.contextPath}/static/css/issues.css"/>
<body>
    <jsp:include page="menu.jsp"></jsp:include>
    <br/>
    <div class="container">
        <form method="get">
            <div class="row">
                <div class="col-sm-2">
                    <div class="form-group">
                        <select name="status" class="form-control" required>
                            <optgroup label="Status">
                                <option value="" disabled hidden selected>Status</option>
                                <option>All</option>
                                <option>New</option>
                                <option>Solved</option>
                            </optgroup>
                        </select>
                    </div>
                </div>
                <div class="col-sm-8">
                    <div class="form-group">
                        <input name="name" type="text" class="form-control" placeholder="Search">
                    </div>
                </div>
                <div class="col-sm-2">
                    <button type="submit" class="btn btn-default">Search</button>
                </div>
            </div>
            <div class="row">
                <a class="btn btn-success" href="${pageContext.request.contextPath}/issues/add">Add Issue</a>
            </div>
        </form>
        <div class="row">
            <table class="table table-hover">
                <thead>
                <tr>
                    <th>Id</th>
                    <th>Name</th>
                    <th>Status</th>
                    <th>Priority</th>
                    <th>Creation Date</th>
                    <th>Author</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                    <c:forEach items="${issues}" var="issue">
                        <tr>
                            <td>${issue.getId()}</td>
                            <td>${issue.getName()}</td>
                            <td>${issue.getStatus()}</td>
                            <td>${issue.getPriority()}</td>
                            <td>${issue.getCreatedOn()}</td>
                            <td>${issue.getAuthorUsername()}</td>
                            <c:choose>
                                <c:when test="${sessionScope.currentUser.getRole() == \"ADMIN\" || sessionScope.currentUser.getUsername() == issue.getAuthorUsername()}">
                                    <td>
                                        <a href="/issues/edit/${issue.getId()}" class="btn btn-primary">Edit</a>
                                    </td>
                                    <td>
                                        <a href="/issues/delete/${issue.getId()}" class="confirm-delete btn btn-danger">Delete</a>
                                    </td>
                                </c:when>
                                <c:otherwise>
                                    <td></td>
                                    <td></td>
                                </c:otherwise>
                            </c:choose>
                        </tr>
                    </c:forEach>
                </tbody>
            </table>
        </div>
    </div>

    <script>
        $("#issues").addClass("active");
    </script>
</body>
</html>