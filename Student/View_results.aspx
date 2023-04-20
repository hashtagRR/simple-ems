<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="View_results.aspx.cs" Inherits="Exam_student.Student.View_grades" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Previous Exam Results</div>
                <div class="panel-body">
                     <div class="table-reponsive">
        <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
    </div>

                </div>
            </div>
        </div>
       
        <div class="col-md-6">
            <div class="panel panel-primary">
                <div class="panel-heading">Your avarage at exams</div>
                <div class="panel-body">

                    <div class="col-md-2"></div>
                    <asp:Label ID="Label1" runat="server" Text="Average :" Font-Size="Larger" Font-Bold="True"></asp:Label>
                    <asp:Label ID="avg" runat="server" text-size="xtra-large" Text="" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                    <br/><br/><br/>
                    <asp:Label ID="feed" runat="server" Text="" Font-Size="Large"></asp:Label>
                </div>
            </div>
        </div>
    </div></div>
</asp:Content>