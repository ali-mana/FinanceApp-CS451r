<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CustomLogin.ascx.cs" Inherits="FinancingApp.WebForms.CustomLogin" %>

username : <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
Password : <asp:TextBox ID="TextBox2" runat="server" TextMode="Password" ></asp:TextBox><br />
Save my session: <asp:CheckBox ID="CheckBox1" runat="server" /> <br />
<asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />