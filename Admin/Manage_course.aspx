<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Manage_course.aspx.cs" Inherits="Exam.Admin.Manage_course" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-5">
            <div class="panel panel-primary">
                <div class="panel-heading">Edit / Search / Remove Course</div>
                <div class="panel-body">
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <div class="input-group">
                                <span class="input-group-addon">Course ID</span>
                                 <asp:TextBox runat="server" id="cid" type="text" class="form-control" placeholder="ex: HND-COM"></asp:TextBox>
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
                               <span class="input-group-addon">Duration</span>
                               <asp:TextBox runat="server" id="dur" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon">Cost</span>
                               <asp:TextBox runat="server" id="cost" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>

                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon">No of subjects</span>
                               <asp:TextBox runat="server" id="nos" type="text" class="form-control" placeholder=""></asp:TextBox>
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
                <div class="panel-heading">All Courses- Alphabetical Order</div>
                <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                  
                     <div>

        <asp:Button ID="Button3" CssClass="btn btn-warning" runat="server" Text="View Details" OnClick="Button1_Click" />
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