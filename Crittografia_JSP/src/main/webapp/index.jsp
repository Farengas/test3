<%@ page language="java" contentType="text/html; charset=UTF-8" %>
<!DOCTYPE html>
<html>
<head>
    <title>Criptatore di Frasi</title>
</head>
<body>
    <h1>Cripta una Frase</h1>
    <form method="post" action="cripta">
    <textarea name="frase" rows="4" cols="50" placeholder="Inserisci la frase da criptare"></textarea>
    <br>
    <input type="submit" value="Cripta">
</form>

    <%
        String risultato = (String) request.getAttribute("risultato");
        if (risultato != null && !risultato.isEmpty()) {
            out.println("<h2>Frase Criptata:</h2>");
            out.println("<p>" + risultato + "</p>");
        }
    %>
</body>
</html>
