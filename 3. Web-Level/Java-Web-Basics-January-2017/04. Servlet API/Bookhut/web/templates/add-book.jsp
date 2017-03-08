<%--suppress CheckTagEmptyBody --%>
<%@ page contentType="text/html;charset=UTF-8" language="java" %>
<html>
<head>
    <title>Add Book</title>
</head>
<body>
    <jsp:include page="menu.jsp"></jsp:include>
    <form method="post">
        <label for="title">Title:</label>
        <input id="title" type="text" name="title">
        <label for="author">Author:</label>
        <input id="author" type="text" name="author">
        <label for="pages">Pages:</label>
        <input id="pages" type="text" name="pages">
        <button type="submit" name="add">Add</button>
    </form>
</body>
</html>