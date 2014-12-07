<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FinancingApp.WebForms._Default" %>

<%@ Register TagPrefix="Uc1" Src="~/CustomLogin.ascx" TagName="Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <div id="mygrid" runat="server">

    </div>
    <uc1:Login runat="server" id="login1"></uc1:Login>
    <h2>Customers</h2>
    ViewStateTextBox :  <asp:TextBox ID="TextBox1" runat="server" Text="My Initial Value"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <asp:GridView ID="GridView1" runat="server" EnableViewState="true">
        <%-- <Columns db="First"></Columns>--%>
    </asp:GridView>
  
    <asp:HiddenField ID="HiddenField1" runat="server" />

    <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem>1</asp:ListItem>
         <asp:ListItem>2</asp:ListItem>
         <asp:ListItem>3</asp:ListItem>
    </asp:DropDownList>
</asp:Content>
