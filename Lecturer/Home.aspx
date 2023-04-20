<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Exam_lecturer.Lecturer.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  

     <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-5">
            <div class="panel panel-primary">
                <div class="panel-heading">Question Count</div>
                 <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                    <div class="table-reponsive">
                        <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Latest Exam Results</div>
                 <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                    <div class="table-reponsive">
                        <asp:GridView ID="dgv2" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
     </div>




</asp:Content>
