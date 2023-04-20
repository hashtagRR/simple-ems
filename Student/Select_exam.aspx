<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Select_exam.aspx.cs" EnableViewState="true" Inherits="Exam_student.Student.Select_exam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2></h2>
    <div class="row">

        <div class="col-md-2"></div>
        <div class="col-md-8">
            <div class="panel panel-default">
                <h2 align="center" style="color:green;">Good luck for your exam !!!</h2>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="Label2" runat="server" Text="Full Name :"></asp:Label>
                        </div>
                        <asp:Label ID="fn" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="aaa" runat="server" Text="Student ID :"></asp:Label>
                        </div>

                        <asp:Label ID="sid" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-2">
                            <asp:Label ID="Label5" runat="server" Text="Couese ID"></asp:Label>
                        </div>
                        <asp:Label ID="cid" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <asp:DropDownList ID="dl1" class="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList>

                    <asp:Button ID="Button1" runat="server" class="btn btn-primary" Text="Start Exam" OnClick="Button1_Click" />
                    <br />
                    <br />
                    <br />
                    <asp:Panel ID="Panel1" runat="server" BackImageUrl="~/Student/ExamAnswerSheet2977380Small.jpg"></asp:Panel>

                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
    </div>

    <style>
    </style>
</asp:Content>