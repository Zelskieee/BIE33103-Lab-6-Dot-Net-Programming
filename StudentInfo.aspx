<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/MasterPage.Master" AutoEventWireup="true" CodeBehind="StudentInfo.aspx.cs" Inherits="Lab5.MasterPages.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" type="text/css" href="../style.css/StyleStudentInfo.css" />
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Info</h1> <br /><br />
    <asp:Button ID="AddNew" Text="Add New Student" runat="server" OnClick="ButtonAddNew_Click" />&nbsp;
    <br /><br />
    <div class="tabledata">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false"
            OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
            OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" AllowPaging="true" PageSize="5" OnPageIndexChanging="GridView1_PageIndexChanging" DataKeyNames="id">
            <HeaderStyle BackColor="#bed2fa" Font-Bold="True" ForeColor="Black" />
            <Columns>
                <asp:BoundField DataField="name" HeaderText="Student Name" ItemStyle-CssClass="grid-cell" />
                <asp:BoundField DataField="id" HeaderText="Student ID" ItemStyle-CssClass="grid-cell" />
                <asp:BoundField DataField="course" HeaderText="Course" ItemStyle-CssClass="grid-cell" />
                <asp:ButtonField Text="Select" CommandName="Select" ItemStyle-Width="30" ItemStyle-CssClass="grid-cell" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="Delete" Text="Delete"
                            OnClientClick="javascript:return confirm('Are you sure to delete this record?');"
                            style="color: red; padding: 10px;" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="msg" runat="server" Text=""></asp:Label>
    </div>
    <asp:Label ID="lblStatus" runat="server" Text="" style="color: red; margin-left: -10px;"></asp:Label>
</asp:Content>
