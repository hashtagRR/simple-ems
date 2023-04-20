<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="View_grades.aspx.cs" Inherits="Exam.GUI.View_grades" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Search Grades According To Subject</div>
                <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-6">
                            <div class="input-group">
                                <span class="input-group-addon">Subject ID</span>
                                <asp:TextBox ID="subid" type="text" class="form-control" name="msg" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:Button ID="Button8" runat="server" Text="Search" Class="btn btn-info" OnClick="Button8_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                       <asp:Label ID="cls_avg" runat="server" Text="" Font-Bold="True" ></asp:Label>
                    <br />
                    <br />
                    <div class="table-reponsive">
                        <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Search Grades According To Student</div>
                <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-6">
                            <div class="input-group">
                                <span class="input-group-addon">NIC No</span>
                                <asp:TextBox ID="stuid" type="text" class="form-control" name="msg" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:Button ID="Button1" runat="server" Text="Search" Class="btn btn-info" OnClick="Button1_Click" />
                            </div>
                        </div>
                    </div>
                    <br />

                    <asp:Label ID="avg" runat="server" Text="" Font-Bold="True" ></asp:Label>
                    <br />
                    <br />
                    <div class="table-reponsive">
                        <asp:GridView ID="dgv2" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>