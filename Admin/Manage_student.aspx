<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_student.aspx.cs" Inherits="Exam.Admin.Manage_student" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3></h3>
    <div class="form-horizontal">

        <div class="col-md-5">
            <div class="panel panel-primary">
                <div class="panel-heading">Edit / Search / Remove student</div>
                <div class="panel-body">

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Student ID</span>
                                <asp:TextBox runat="server" ID="sid" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:Button ID="Button5" runat="server" Text="Search" Class="btn btn-info" OnClick="Button5_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">NIC No</span>
                                <asp:TextBox runat="server" ID="nic" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:Button ID="Button3" runat="server" Text="Search" Class="btn btn-info" OnClick="Button3_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon">Full Name</span>
                                <asp:TextBox runat="server" ID="fn" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon">Course ID</span>
                                <asp:TextBox runat="server" ID="cid" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon">Contact No</span>
                                <asp:TextBox runat="server" ID="tp" type="text" class="form-control" name="msg" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">

                        <div class="col-md-4">
                            <asp:Button ID="Button1" runat="server" Text="Clear" Class="btn btn-warning" OnClick="Button1_Click1" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="Button6" runat="server" Text="Remove" Class="btn btn-danger" OnClick="Button6_Click" />
                        </div>

                        <div class="col-md-4">
                            <asp:Button ID="Button2" runat="server" Text="Update" Class="btn btn-success" OnClick="Button2_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-7">
            <div class="panel panel-success">
                <div class="panel-heading">Student Details - Alphabetical Order</div>
                 <div class="panel-body" style="max-height: 600px; overflow-y: scroll">

                    <div>

                        <asp:Button ID="Button4" CssClass="btn btn-warning" runat="server" Text="View Details" OnClick="Button1_Click" />
                    </div>

                    <div class="table-reponsive">
                        <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>