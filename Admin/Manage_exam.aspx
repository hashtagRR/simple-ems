<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Manage_exam.aspx.cs" Inherits="Exam.Admin.Manage_exam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-5">
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <div class="panel panel-primary">
                <div class="panel-heading">Edit / Search / Remove Exam</div>
                <div class="panel-body" style="max-height: 600px; overflow-y: scroll">

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Exam ID</span>
                                <asp:TextBox runat="server" ID="eid" type="text" class="form-control" placeholder=""></asp:TextBox>
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
                        <div class="col-md-9">
                             <asp:Label ID="Labelname" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Name</span>
                                <asp:TextBox runat="server" ID="na" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                             <asp:Label ID="Labelcid" runat="server" Text=""></asp:Label>
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
                            <asp:Label ID="Labelsid" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Subject ID</span>
                                <asp:TextBox runat="server" ID="sid" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />

                    <br />

                    <div class="row">

                        <div class="col-md-4">
                            <asp:Button ID="Button6" runat="server" Text="Clear" Class="btn btn-warning" OnClick="Button6_Click" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="Button8" runat="server" Text="Remove" Class="btn btn-danger" OnClick="Button8_Click" />
                        </div>

                        <div class="col-md-4">
                            <asp:Button ID="Button9" runat="server" Text="Update" Class="btn btn-success" OnClick="Button9_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-md-7">
        <div class="panel panel-success">
            <div class="panel-heading">Exam Details - Alphabetical Order</div>
            <div class="panel-body" style="max-height: 600px; overflow-y: scroll">

                <div>

                    <asp:Button ID="Button2" CssClass="btn btn-warning" runat="server" Text="View data" OnClick="Button2_Click" />
                </div>
                <div class="table-reponsive">
                    <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>