<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="WebFormSignIn.aspx.cs" Inherits="AspAppClient.WebFormSignIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <asp:Panel ID="pnlLogin" runat="server">

    <!-- PUT YOUR PAGE HTML/CONTROLS HERE ONLY -->
    <h2>Login</h2>
     <table class="auto-style1">
     <tr>
         <td style="height: 22px"></td>
         <td style="height: 22px"></td>
         <td colspan="2" style="height: 22px"></td>
         <td style="height: 22px"></td>
         <td style="height: 22px"></td>
     </tr>
     <tr>
         <td class="auto-style2"></td>
         <td class="auto-style2"></td>
         <td class="auto-style5">
           <asp:Label ID="Label1" runat="server" Text="Email: "></asp:Label>
         </td>
         <td class="auto-style2">
             <asp:TextBox ID="txtboxEmail" runat="server"></asp:TextBox>
         </td>
         <td class="auto-style2"></td>
         <td class="auto-style2"></td>
     </tr>
     <tr>
         <td class="auto-style2" style="height: 26px"></td>
         <td class="auto-style2" style="height: 26px"></td>
         <td class="auto-style5" style="height: 26px">
             <asp:Label ID="Label3" runat="server" Text="Password: "></asp:Label>
            
         </td>
         <td class="auto-style2" style="height: 26px">
             <asp:TextBox ID="txtboxPass" runat="server"></asp:TextBox>
         </td>
         <td class="auto-style2" style="height: 26px"></td>
         <td class="auto-style2" style="height: 26px"></td>
     </tr>
     <tr>
         <td>&nbsp;</td>
         <td>&nbsp;</td>
         <td class="auto-style3" colspan="2">
             <asp:Button ID="btnLogin" runat="server" OnClick="Button1_Click" Text="Sign In" />
         </td>
         <td>&nbsp;</td>
         <td>&nbsp;</td>
     </tr>
     <tr>
         <td class="auto-style4"></td>
         <td class="auto-style4"></td>
         <td class="auto-style7"></td>
         <td class="auto-style4">
             <asp:Label ID="lblMsg" runat="server"></asp:Label>
         </td>
         <td class="auto-style4"></td>
         <td class="auto-style4"></td>
     </tr>
 </table>
</asp:Panel>


<asp:Panel ID="pnlAlreadyLogged" runat="server" Visible="false">
    <h2>You are already logged in ✅</h2>
    <p>
        <a href="MasterPage.aspx">Go to Home</a> |
        <a href="UserManagment.aspx">My Account</a> |
        <a href="Logout.aspx">Logout</a>
    </p>
</asp:Panel>
</asp:Content>