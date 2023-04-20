<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_question.aspx.cs" Inherits="Exam.GUI.Add_question" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-6">
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <div class="panel panel-primary">
                <div class="panel-heading">Add New Question</div>
                <div class="panel-body">

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
                            <asp:Label ID="Labelq" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Question</span>
                                <asp:TextBox runat="server" TextMode="MultiLine" class="form-control" ID="q"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labela1" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                                <asp:TextBox runat="server" ID="a1" type="text" class="form-control" placeholder="Answer 1"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labela2" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                                <asp:TextBox runat="server" ID="a2" type="text" class="form-control" placeholder="Answer 2"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labela3" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                                <asp:TextBox runat="server" ID="a3" type="text" class="form-control" placeholder="Answer 3"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labela4" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-pencil"></i></span>
                                <asp:TextBox runat="server" ID="a4" type="text" class="form-control" placeholder="Answer 4"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labelca" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-thumbs-up"></i></span>
                                <asp:TextBox runat="server" ID="cor" type="text" class="form-control" placeholder="Correct answer no."></asp:TextBox>
                            </div>
                        </div>
                    </div>
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

        <div class="col-md-6">
            <div class="panel panel-success">
                <div class="panel-heading">Subject Details - Alphabetical Order</div>
                <h4></h4>
                <div class="col-md-1"></div>
                <div>
                    <asp:Button ID="Button1" CssClass="btn btn-warning" runat="server" Text="Populate Table" OnClick="Button1_Click" />
                </div>
                <div class="panel-body" style="max-height: 600px; overflow-y: scroll">

                    <div class="table-reponsive">
                        <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>