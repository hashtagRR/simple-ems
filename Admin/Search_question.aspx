<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Search_question.aspx.cs" Inherits="Exam.Admin.Search_question" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


      <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Search Questions According To Subject</div>
               <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                    <div class="row">
                            
                        <div class="col-md-1"></div>
                        <div class="col-md-6">
                       
                            <div class="input-group">
                                <span class="input-group-addon">Subject ID</span>
                                <asp:TextBox runat="server" ID="id" type="text" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="input-group">
                                <asp:Button ID="Button8" runat="server" Text="Search" Class="btn btn-info" OnClick="Button8_Click" />
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="table-reponsive">
                        <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>

         <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">View Question</div>
                <div class="panel-body">
                     <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-6">
                           
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
                    
                   

    <div class="table-reponsive">
        <asp:GridView ID="dgv2" runat="server" CssClass="table"></asp:GridView>
    </div>
                </div>
            </div>
        </div>
    </div>
    </div>



    </asp:Content>
