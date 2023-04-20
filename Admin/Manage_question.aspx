<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Manage_question.aspx.cs" Inherits="Exam.GUI.Edit_question" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-6">
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
            <div class="panel panel-primary">
                <div class="panel-heading">Edit Question</div>
                <div class="panel-body">
                    <asp:Label ID="Label3" runat="server" Text=""></asp:Label>

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labelqid" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Question ID</span>
                                 <asp:TextBox runat="server" id="qid" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="input-group">
                                <asp:Button ID="Button1" runat="server" Text="Search" Class="btn btn-info" OnClick="Button1_Click1" />
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
                                <asp:TextBox runat="server" class="form-control" TextMode="multiline" Columns="50" Rows="5" id="que"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labelsid" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Subject ID</span>
                                <asp:TextBox runat="server" id="sub" type="text" class="form-control"  placeholder="ex: DAD"></asp:TextBox>
                            </div>
                        </div>
                       
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labela1" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Answer 1</span>
                                <asp:TextBox runat="server" id="a1" type="text" class="form-control"  placeholder=""></asp:TextBox>
                            </div>
                        </div>
                       
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labela2" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Answer 2</span>
                              <asp:TextBox runat="server" id="a2" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                       
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labela3" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Answer 3</span>
                                <asp:TextBox runat="server" id="a3" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                       
                    </div>
                    <br />

                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labela4" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Answer 4</span>
                                <asp:TextBox runat="server" id="a4" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                       
                    </div>
                    <br />
                    
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-8">
                            <asp:Label ID="Labelca" runat="server" Text=""></asp:Label>
                            <div class="input-group">
                                <span class="input-group-addon">Correct answer No</span>
                                <asp:TextBox runat="server" id="ca" type="text" class="form-control" placeholder=""></asp:TextBox>
                            </div>
                        </div>
                       
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-3">
                            <asp:Button ID="Button3" runat="server" Text="Clear" Class="btn btn-warning" OnClick="Button3_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="Button2" runat="server" Text="Remove" Class="btn btn-danger" OnClick="Button2_Click" />
                        </div>
                        <div class="col-md-3">
                            <asp:Button ID="Button4" runat="server" Text="Save" Class="btn btn-success" OnClick="Button4_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-md-6">
            <div class="panel panel-success">
                <div class="panel-heading">Search Questions According To Subject</div>
               <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                   <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
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
    </div>
    </div>
</asp:Content>