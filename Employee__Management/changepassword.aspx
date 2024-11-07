<%@ Page Title="" Language="C#" MasterPageFile="~/user.Master" AutoEventWireup="true" CodeBehind="changepassword.aspx.cs" Inherits="Employee__Management.changepassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <table>
        <tr>
            <td>Current Password:</td>
            <td>
                <asp:TextBox ID="txtcurrentpassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>New Password:</td>
            <td>
                <asp:TextBox ID="txtnewpassword" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Confirm Password:</td>
            <td>
                <asp:TextBox ID="txtconfirmpassword" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnlogin" runat="server" Text="Change Password" BackColor="Green" ForeColor="White" Onclick="btnlogin_Click" />
                
            </td>
        </tr>

        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblmassage" runat="server" ForeColor="Red" Font-Bold="true"></asp:Label></td>
        </tr>
    </table>
</asp:Content>
