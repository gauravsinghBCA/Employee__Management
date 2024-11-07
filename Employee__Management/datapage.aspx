<%@ Page Title="" Language="C#" MasterPageFile="~/mainpage.Master" AutoEventWireup="true" CodeBehind="datapage.aspx.cs" Inherits="Employee__Management.datapage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>Employee Name:</td>
            <td>
                <asp:TextBox ID="txtname" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Employee EmailId:</td>
            <td>
                <asp:TextBox ID="txtemail" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Employee Password:</td>
            <td>
                <asp:TextBox ID="txtpassword" placeholder="password" runat="server"></asp:TextBox></td>
        </tr>


        <tr>
            <td>Employee Salary:</td>
            <td>
                <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox></td>
        </tr>

        <tr>
            <td>Employee Gender:</td>
            <td>
                <asp:RadioButtonList ID="rblgender" runat="server" RepeatColumns="3"></asp:RadioButtonList></td>
        </tr>

        <tr>
            <td>Employee Department:</td>
            <td>
                <asp:DropDownList ID="ddldepartment" runat="server"></asp:DropDownList></td>
        </tr>

        <tr>
            <td>Employee Country:</td>
            <td>
                <asp:DropDownList ID="ddlcountry" runat="server" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
        </tr>

        <tr>
            <td>Employee empstate:</td>
            <td>
                <asp:DropDownList ID="ddlempstate" runat="server"></asp:DropDownList></td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnsubmit" runat="server" BackColor="Green" ForeColor="White" Text="submit" OnClick="btnsubmit_Click" />
                <a href="LoginForm.aspx">Sign In</a>
            </td>
        </tr>


    </table>

    <asp:GridView ID="grdv" runat="server" OnRowCommand="grdv_RowCommand" AutoGenerateColumns="false" OnSelectedIndexChanged="grdv_SelectedIndexChanged">
        <Columns>

            <asp:TemplateField HeaderText="Id">
                <ItemTemplate>
                    <%#Eval("id") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Name">
                <ItemTemplate>
                    <%#Eval("name") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <%#Eval("email") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Password">
                <ItemTemplate>
                    <%#Eval("password") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Salary">
                <ItemTemplate>
                    <%#Eval("salary") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Gender">
                <ItemTemplate>
                    <%#Eval("gendername") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Department">
                <ItemTemplate>
                    <%#Eval("departmentname") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Country">
                <ItemTemplate>
                    <%#Eval("countryname") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="State">
                <ItemTemplate>
                    <%#Eval("empstatename") %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="deletebtn" runat="server" Text="delete" BackColor="Maroon" ForeColor="White" CommandName="delete_data" CommandArgument='<%#Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="editbtn" runat="server" Text="edit" BackColor="YellowGreen" ForeColor="Black" CommandName="edit_data" CommandArgument='<%#Eval("id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Content>
