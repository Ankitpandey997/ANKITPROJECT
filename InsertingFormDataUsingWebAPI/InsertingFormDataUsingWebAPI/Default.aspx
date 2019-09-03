<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="InsertingFormDataUsingWebAPI.Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
<title>Insert data into database using jquery in asp.net</title>
<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.2.js"></script>
</head>
<body>
<form id="form1" runat="server">
<table>
<tr>
<td>Name:</td>
<td><input type="text" id="txtname" /></td>
</tr>
<tr>
<td>Subject:</td>
<td> <input type="text" id="txtsubject" /></td>
</tr>
<tr>
<td>Body:</td>
<td> <textarea id="txtbody"></textarea></td>
</tr>
<tr>
<td></td>
<td>
<input type="button" id="btnSubmit" value="Submit" />
</td>
</tr>
</table>
<label id="lblmsg"/><br />
<asp:GridView ID="gvDetails" runat="server">
<HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
</asp:GridView>
</form>
<script type="text/javascript">
$(function () {
$('#btnSubmit').click(function () {
var name = $('#txtname').val();
var subject = $('#txtsubject').val();
var body = $('#txtbody').val();
if (name != '' && subject != '' && body) {
$.ajax({
type: "POST",
contentType: "application/json; charset=utf-8",
url: "InsertDataintoDatabase.aspx/InsertData",
data: "{'username':'" + name + "','subj':'" + subject + "','desc':'" + body + "'}",
dataType: "json",
success: function (data) {
var obj = data.d;
if (obj == 'true') {
$('#txtname').val('');
$('#txtsubject').val('');
$('#txtbody').val('');
$('#lblmsg').html("Details Submitted Successfully");
window.location.reload();
}
},
error: function (result) {
alert("Error");
}
});
}
else {
alert('Please enter all the fields')
return false;
}
})
});
</script>
</body>
</html>