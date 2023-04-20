<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_subject.aspx.cs" Inherits="Exam.Admin.Search" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3></h3>
    <div class="container">
        <div class="row">
            <div class="col-md-6">

                <div class="panel panel-primary">
                    <div class="panel-heading">Search Subject</div>
                    <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                        <div class="row">

                            <div class="col-md-6">
                                <div class="input-group">
                                    <span class="input-group-addon">Subject ID</span>
                                    <asp:TextBox ID="cid" type="text" class="form-control" name="msg" runat="server"></asp:TextBox>
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

            <div class="col-md-6">
                <div class="panel panel-success">
                    <div class="panel-heading">View All Subjects - Alphebatical Order</div>
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