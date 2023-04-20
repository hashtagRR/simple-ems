<%@ Page Language="C#" MasterPageFile="Login_master.master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Exam.Admin.Login" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-md-2"></div>
            <div class="col-md-4">
                <div class="row">
                    <div class="col-md-2"></div>

                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="col-md-1"></div>
                            <h3 align="center">EMS - Admin Login</h3>
                            <br />
                            <div class="form-horizontal">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                                <div class="form-group">
                                    <div class="col-md-1"></div>
                                    <div class="col-sm-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>

                                            <asp:TextBox runat="server" ID="un" type="text" class="form-control" placeholder="Username"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <div class="col-md-1"></div>
                                    <div class="col-sm-9">
                                        <div class="input-group">
                                            <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                            <asp:TextBox runat="server" ID="pw" type="password" class="form-control" placeholder="Password"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="form-group">
                                </div>
                                <div class="form-group">
                                    <div class="col-md-1"></div>
                                    <div class="col-md-2">
                                        <asp:Button ID="Button1" class="btn btn-warning" runat="server" Text="Clear" OnClick="Button1_Click" />
                                    </div>
                                    <div class="col-md-4"></div>
                                    <div class="col-md-2">
                                        <asp:Button ID="Button2" class="btn btn-success" runat="server" Text="Submit" OnClick="Button2_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-md-6"></div>
        </div>
    </div>
</asp:Content>