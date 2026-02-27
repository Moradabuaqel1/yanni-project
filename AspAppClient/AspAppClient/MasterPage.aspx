<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="MasterPage.aspx.cs" Inherits="AspAppClient.MasterPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Welcome to Mini Shop</h2>
    <p>This is the main page.</p>

    <ul>
        <li>Signup / Login</li>
        <li>Edit profile / Change password</li>
        <li>Logout</li>
    </ul>

    <p>
        If you are not logged in:
        <a href="WebFormSignIn.aspx">Login</a> |
        <a href="WebFormSignUp.aspx">Signup</a>
    </p>
</asp:Content>
