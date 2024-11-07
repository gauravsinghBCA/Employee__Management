<%@ Page Title="" Language="C#" MasterPageFile="~/mainpage.Master" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="Employee__Management.LoginForm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>Email Id:</td>
            <td>
                <asp:TextBox ID="txtmail" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td>
                <asp:TextBox ID="txtepassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button ID="btnlogin" runat="server" Text="Login" BackColor="Green" ForeColor="White" OnClick="btnlogin_Click"/>
                <a href="datapage.aspx">Sign Up</a>
            </td>
        </tr>

        <tr>
            <td></td>
            <td><asp:Label ID="lblmassage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
    </table>

</asp:Content>
