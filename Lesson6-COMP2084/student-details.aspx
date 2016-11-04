<%@ Page Title="Student Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="student-details.aspx.cs" Inherits="Lesson6_COMP2084.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Student Details</h1>

    <div class="form-group">
        <label for="txtLastName" class="col-sm-3 control-label">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" required />
    </div>
    <div class="form-group">
        <label for="txtFirstMidName" class="col-sm-3 control-label">First/Middle Name:</label>
        <asp:TextBox ID="txtFirstMidName" runat="server" required />
    </div>
    <div class="form-group">
        <label for="txtEnrollmentDate" class="col-sm-3 control-label">Enrollment Date:</label>
        <asp:TextBox ID="txtEnrollmentDate" runat="server" required type="date"/>
    </div>
    <asp:Button class="btn btn-success col-sm-offset-3" id="btnSaveStudent" runat="server" text="Save"  OnClick="btnSaveStudent_Click"/>
</asp:Content>
