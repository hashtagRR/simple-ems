<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="End_exam.aspx.cs" Inherits="Exam_student.Student.End_exam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2></h2>
    <div class="row">

        <div class="col-md-2"></div>
        <div class="col-md-6">
            <div class="panel panel-default">
                <h2 align="center" style="color:red;">Result Sheet</h2>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label2" runat="server" Text="Full Name :"></asp:Label>
                        </div>
                        <asp:Label ID="fn" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="aaa" runat="server" Text="Student ID :"></asp:Label>
                        </div>

                        <asp:Label ID="sid" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label5" runat="server" Text="Course ID"></asp:Label>
                        </div>
                        <asp:Label ID="cid" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                     <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label1" runat="server" Text="Exam name"></asp:Label>
                        </div>
                        <asp:Label ID="ena" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                     <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label4" runat="server" Text="Marks"></asp:Label>
                        </div>
                        <asp:Label ID="mk" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                     <div class="row">
                        <div class="col-md-3">
                            <asp:Label ID="Label7" runat="server" Text="Grade"></asp:Label>
                        </div>
                        <asp:Label ID="gd" runat="server" Text=""></asp:Label>
                    </div>
                    <br />
                </div>
            </div>
        </div>
    </div>


</asp:Content>