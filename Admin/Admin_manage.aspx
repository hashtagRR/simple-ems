<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Admin_manage.aspx.cs" Inherits="Exam.GUI.Admin_manage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-5">
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
            <div class="panel panel-primary">
                <div class="panel-heading">Add New Admin</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-credit-card"></i></span>
                                <asp:TextBox runat="server" ID="nic" type="text" class="form-control" MaxLength="10" placeholder="NIC NO"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox runat="server" ID="pw1" type="password" class="form-control" placeholder="Password"></asp:TextBox>
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
                                <asp:TextBox runat="server" ID="pw2" type="password" class="form-control" name="password" placeholder="Re-Type Password"></asp:TextBox>
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
            <br />
            
             <div class="panel panel-primary">

                <div class="panel-heading">Remove Admin Account</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">

                            <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-credit-card"></i></span>
                                <asp:TextBox runat="server" ID="nicr" type="text" class="form-control" MaxLength="10" placeholder="NIC NO"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox runat="server" ID="pwr" type="password" class="form-control" placeholder="Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                   
                   
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-7">
                            <asp:Button ID="Button5" runat="server" Text="Clear" Class="btn btn-warning"  />
                        </div>

                        <div class="col-md-4">
                            <asp:Button ID="Button6" runat="server" Text="Save" Class="btn btn-success" OnClick="Button6_Click"  />
                        </div>
                    </div>
                </div>
            </div>




        </div>

        <div class="col-md-5">
            <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
            <div class="panel panel-primary">
                <div class="panel-heading">Change Pasword</div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                              <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-credit-card"></i></span>
                                <asp:TextBox runat="server" ID="nic2" type="text" class="form-control" MaxLength="10" placeholder="NIC NO"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                 <asp:TextBox runat="server" ID="opw" type="password" class="form-control" placeholder="Old Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                 <asp:TextBox runat="server" ID="npw1" type="password" class="form-control" placeholder="New Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-9">
                             <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon"><i class="glyphicon glyphicon-lock"></i></span>
                                <asp:TextBox runat="server" ID="npw2" type="password" class="form-control" placeholder="Re-type New Password"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-7">
                            <asp:Button ID="Button1" runat="server" Text="Clear" Class="btn btn-warning" OnClick="Button1_Click" />
                        </div>

                        <div class="col-md-4">
                            <asp:Button ID="Button2" runat="server" Text="Save" Class="btn btn-success" OnClick="Button2_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
</asp:Content>