<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Manage_subject.aspx.cs" Inherits="Exam.Admin.Manage_subject" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


<h3></h3>
    <div class="form-horizontal">

<div class="col-md-5">
            <div class="panel panel-primary">
                <div class="panel-heading">Edit / Search / Remove Subject</div>
                <div class="panel-body">
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <div class="input-group">
                                 <span class="input-group-addon">Subject ID</span>
                                <asp:TextBox runat="server" id="sid" type="text" class="form-control" placeholder=""></asp:TextBox>
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
                            <div class="input-group">
                                 <span class="input-group-addon">Name</span>
                                <asp:TextBox runat="server" id="na" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                     
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon">Course ID</span>
                                <asp:TextBox runat="server" id="cid" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <div class="input-group">
                               <span class="input-group-addon">Description</span>
                                <asp:TextBox runat="server" id="des" class="form-control" TextMode="multiline" Columns="50" Rows="5" placeholder=""></asp:TextBox>
                            </div>
                        </div>

                    </div>
                  
                    <br />

                    <div class="row">

                        <div class="col-md-4">
                            <asp:Button ID="Button2" runat="server" Text="Clear" Class="btn btn-warning" OnClick="Button2_Click" />
                        </div>
                        <div class="col-md-4">
                            <asp:Button ID="Button6" runat="server" Text="Remove" Class="btn btn-danger" OnClick="Button6_Click" />
                        </div>

                        <div class="col-md-4">
                            <asp:Button ID="Button3" runat="server" Text="Update" Class="btn btn-success" OnClick="Button3_Click" />
                        </div>

                    </div>

                </div>
            </div>
        </div>





  
        <div class="col-md-7">
            <div class="panel panel-success">
                <div class="panel-heading">Subject Details - Alphabetical Order</div>
                <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                   
                     <div>

        <asp:Button ID="Button1" CssClass="btn btn-warning" runat="server" Text="View Details" OnClick="Button1_Click" />
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