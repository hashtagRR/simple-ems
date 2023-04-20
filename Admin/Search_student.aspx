<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_student.aspx.cs" Inherits="Exam.Admin.Search_student" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3></h3>
    <div class="container">
        <div class="row">
            <div class="col-md-6">

                <div class="panel panel-primary">
                    <div class="panel-heading">Search Student</div>
                    <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <div class="row">

                            <div class="col-md-6">
                                <div class="input-group">
                                    <span class="input-group-addon">Student ID</span>
                                    <asp:TextBox ID="sid" type="text" class="form-control" name="msg" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="input-group">
                                    <asp:Button ID="Button1" runat="server" Text="Search" Class="btn btn-info" OnClick="Button1_Click" />
                                </div>
                            </div>
                        </div>
                        <br />
                        <asp:Label ID="Label2" runat="server" Text=""></asp:Label>

                        <div class="row">

                            <div class="col-md-6">
                                <div class="input-group">
                                    <span class="input-group-addon">NIC No</span>
                                    <asp:TextBox ID="nic" type="text" class="form-control" name="msg" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="col-md-3">
                                <div class="input-group">
                                    <asp:Button ID="Button2" runat="server" Text="Search" Class="btn btn-info" OnClick="Button2_Click" />
                                </div>
                            </div>
                        </div>
                        <br />

                        <div class="table-reponsive">
                            <asp:GridView ID="dgv2" runat="server" CssClass="table"></asp:GridView>
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-md-6">
                <div class="panel panel-success">
                    <div class="panel-heading">View All Courses - Alphabetical order of course</div>
                    <div class="panel-body" style="max-height: 600px; overflow-y: scroll">

                        <div class="table-reponsive">
                            <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>