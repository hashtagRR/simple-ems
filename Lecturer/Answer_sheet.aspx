<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Answer_sheet.aspx.cs" Inherits="Exam_lecturer.Lecturer.Asnwer_sheet" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-5">
            <div class="panel panel-primary">
                <div class="panel-heading">View Answer Sheet</div>
                <div class="panel-body">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-7">
                            <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                 <span class="input-group-addon">Student NIC</span>
                                 <asp:TextBox runat="server" id="nic" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                            </div>
                        
                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:Button ID="Button3" runat="server" Text="Find Exams" Class="btn btn-info" OnClick="Button3_Click"  />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="col-md-1"></div>
                     <div class="col-md-5">
                    <asp:DropDownList ID="dl1" class="btn btn-default dropdown-toggle" runat="server"></asp:DropDownList>
                    </div>
                         <div class="col-md-3">
                            <div class="input-group">
                                <asp:Button ID="Button1" runat="server" Text="View Answer Sheet" Class="btn btn-info" OnClick="Button1_Click"  />
                            </div>
                        </div>
                    <br />  <br />
                   

    <div class="table-reponsive">
        <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
    </div>
                </div>
            </div>
        </div>
        <div class="col-md-7">
            <div class="panel panel-success">
                <div class="panel-heading">View Question</div>
                <div class="panel-body">
                    <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-5">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                 <span class="input-group-addon">Question ID</span>
                                 <asp:TextBox runat="server" id="qid" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                            </div>
                        
                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:Button ID="Button2" runat="server" Text="Search" Class="btn btn-info" OnClick="Button2_Click"   />
                            </div>
                        </div>
                    </div>
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