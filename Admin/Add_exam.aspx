<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_exam.aspx.cs" Inherits="Exam.Admin.add_exam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-5">
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <div class="panel panel-primary">
                <div class="panel-heading">Add New Exam</div>
                <div class="panel-body">
                     <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                              <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-credit-card"></i></span>
                                <asp:TextBox runat="server" ID="cid" type="text" class="form-control" placeholder="Course ID"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-credit-card"></i></span>
                                <asp:TextBox runat="server" ID="sid" type="text" class="form-control" placeholder="Subject ID"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                              <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-book"></i></span>
                                <asp:TextBox runat="server" ID="name" type="text" class="form-control" placeholder="Exam Name"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                   

                  

                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-7">
                            <asp:Button ID="Button3" runat="server" Text="Clear" Class="btn btn-warning" OnClick="Button3_Click" />
                        </div>

                        <div class="col-md-4">
                            <asp:Button ID="Button4" runat="server" Text="Save" Class="btn btn-success" OnClick="Button4_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-5">
        <div class="panel panel-success">
            <div class="panel-heading">Course Details - Alphabetical Order</div>
            <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                <div class="row">
                <div class="col-md-2">

                    <asp:Button ID="Button2" CssClass="btn btn-warning" runat="server" Text="View data" OnClick="Button8_Click" />
                </div>
             <div class="col-md-4"></div>
                <div class="col-md-2">
                    <asp:Button ID="Button5" runat="server" CssClass="btn btn-default" Text="Hide table" OnClick="Button5_Click" />
                </div>
                    </div>
                 <br />
                <div class="table-reponsive">
                    <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
    <div class="col-md-5">
        <div class="panel panel-success">
            <div class="panel-heading">Search Subjects According To Course</div>
            <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-8">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <div class="input-group">
                            <span class="input-group-addon">Course ID</span>
                            <asp:TextBox ID="subid" type="text" class="form-control" name="msg" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="input-group">
                            <asp:Button ID="Button1" runat="server" Text="Search" Class="btn btn-info" OnClick="Button1_Click" />
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
    </div>
</asp:Content>