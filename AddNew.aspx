<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddNew.aspx.cs" Inherits="Lab5.MasterPages.AddNew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../style.css/StyleAddNew.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<table>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">
            <h1>Add New Student</h1>
            </td>    
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">
            <H3></H3>
            </td>
            <td class="auto-style8">&nbsp;</td>
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style3"><strong>Student Name : </strong></td>
            <td>&nbsp;<asp:TextBox id="txtbox_name"  runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtbox_name" ErrorMessage="Enter Student Name" ForeColor="Red">

                </asp:RequiredFieldValidator>
                
            </td>
                                
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style3"><strong>Student ID : </strong></td>
            <td>&nbsp;<asp:TextBox ID="txtbox_ID" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="rfvID" runat="server" ControlToValidate="txtbox_ID" ErrorMessage="Enter Student ID" ForeColor="Red">
</asp:RequiredFieldValidator>


</td>
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style3"><strong>Course : </strong></td>
            <td>&nbsp;<asp:DropDownList runat="server" ID="ddl_Course">
                <asp:ListItem Text="Computer Science" Value="1"></asp:ListItem>
                <asp:ListItem Text="Electrical Engineering" Value="2"></asp:ListItem>
                <asp:ListItem Text="Mechanical Engineering" Value="3"></asp:ListItem>
                <asp:ListItem Text="Architecture" Value="4"></asp:ListItem>
                <asp:ListItem Text="Electronic Engineering" Value="5"></asp:ListItem>
                <asp:ListItem Text="Technology Management" Value="6"></asp:ListItem>
                <asp:ListItem Text="Aeronautical Engineering" Value="7"></asp:ListItem>
                <asp:ListItem Text="Civil Engineering" Value="8"></asp:ListItem>
                      </asp:DropDownList>&nbsp;
                                

</td>
        </tr>
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">
            <div class="button-container">
                <asp:Button ID="ButtonSave" Text="Save" runat="server" OnClick="ButtonSave_Click" />&nbsp;
            <asp:Button ID="ButtonCancel" Text="Cancel" runat="server" OnClick="ButtonCancel_Click" />&nbsp;
            </div>

            </td>
            <td class="auto-style8">&nbsp;<asp:Label id="lblStatus" ForeColor="Red" runat="server"></asp:Label></td>
        </tr>    
        <tr><td class="auto-style8">&nbsp;</td>
            <td class="auto-style2">
                &nbsp;</td>
            <td class="auto-style8">&nbsp;</td>
        </tr>    
    </table>
</asp:Content>

