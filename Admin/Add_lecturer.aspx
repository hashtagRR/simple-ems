<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Add_lecturer.aspx.cs" Inherits="Exam.Admin.Manage_lecturer" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-5">
             <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <div class="panel panel-primary">
                <div class="panel-heading">Register New Lecturer</div>
                <div class="panel-body">


                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>
                                <asp:TextBox runat="server" id="fn" type="text" class="form-control"  placeholder="Full name"></asp:TextBox>
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
                                <asp:TextBox runat="server" id="nic" maxlength="10" type="text" class="form-control" placeholder="NIC No"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-book"></i></span>
                               <asp:TextBox runat="server" id="subject" type="text" class="form-control" placeholder="Subject ID"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-earphone"></i></span>
                                <asp:TextBox runat="server" id="tp" type="text" maxlength="10" class="form-control" placeholder="Contact No"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                               <asp:TextBox runat="server" id="pw1" type="password" class="form-control" placeholder="Password"></asp:TextBox>
                            </div>

                        </div>
                    </div>
                    <br />


                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                              <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                 <asp:TextBox runat="server" id="pw2" type="password" class="form-control"  placeholder="Retype Password"></asp:TextBox>
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


        <div class="col-md-5">
            <div class="panel panel-success">
                <div class="panel-heading">Subject  Details - Alphhabetical Order</div>
                <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
 <div>

        <asp:Button ID="Button1" CssClass="btn btn-warning" runat="server" Text="Populate Grid" OnClick="Button1_Click" />
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
