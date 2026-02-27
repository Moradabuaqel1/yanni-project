<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master"
 CodeBehind="WebFormSignUp.aspx.cs" Inherits="AspAppClient.WebFormSignUp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <table class="auto-style1">
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style2" colspan="2"><strong><span class="auto-style3">SignUp Form</span></strong></td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style4">User Name :</td>
                <td>
                    <asp:TextBox ID="TextBoxUsrName" runat="server" Width="206px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style4">Email :</td>
                <td>
                    <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" Width="206px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style4">Gender :</td>
                <td>
                    <asp:RadioButtonList ID="RadioButtonListGender" runat="server" RepeatDirection="Horizontal">
                        <asp:ListItem Selected="True">Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style4">Date of birth :</td>
                <td>
                    <asp:TextBox ID="TextBoxBirthDay" runat="server" TextMode="Date"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style4">Password :</td>
                <td>
                    <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password" Width="154px"></asp:TextBox>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style4">Confirm Password :</td>
                <td>
                    <asp:TextBox ID="TextBoxCPass" runat="server" TextMode="Password" Width="154px"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPass" ControlToValidate="TextBoxCPass" ErrorMessage="Passwords not identical"></asp:CompareValidator>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td class="auto-style4">&nbsp;</td>
                <td>
                    <asp:Button ID="ButtonSignUp" runat="server" OnClick="ButtonSignUp_Click" Text="SignUp" />
&nbsp;&nbsp;
                    <asp:Label ID="LabelMsg" runat="server"></asp:Label>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Content>