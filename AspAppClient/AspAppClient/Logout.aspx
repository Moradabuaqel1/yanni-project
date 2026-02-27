<%@ Page Language="C#"  MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Logout.aspx.cs" Inherits="AspAppClient.Logout" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">  
    <style>
    .center-box {
        display: flex;
        justify-content: center;
        align-items: center;
        height: 200px;
    }

    .badge {
        background: #16a085;   
        color: white;
        padding: 10px 25px;
        border-radius: 20px;
        border: none;
        font-size: 16px;
        cursor: pointer;
    }

    .badge:hover {
        background: #138d75;
    }
</style>
<div class="center-box">
    <asp:Button ID="btnLogout"
        runat="server"
        Text="Logout"
        CssClass="badge"
        OnClick="Button1_Click" />
</div>
</asp:Content>