<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>
<%@ Import Namespace="AlienInvasion.Server" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Space Invaders vs Continuous Testing</title>
</head>
<body>

<center>

<h1>Space Invaders vs Continuous Testing</h1>
<h2>Leader Board</h2>

<table border="1" cellpadding="5" width="600">
	<tr>
		<td>Name(s)</td>
		<td>Score</td>
		<td>Current Destruction</td>
	</tr>

	<%
	foreach (AlienInvasionUser user in (IEnumerable)Model) {
	%>
		<tr>
			<td><%=user.Name%></td>
			<td><%=user.Score%></td>
			<td><%=Math.Min(user.FailuresOnCurrentCity * 20, 100) + "%"%></td>
		</tr>
	<%
	}
	%>
</table>

</center>

</body>
</html>
