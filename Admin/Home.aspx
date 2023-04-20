<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Exam.Admin.Home" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h3></h3>
    <div class="form-horizontal">
        <div class="col-md-3">
            <div class="panel panel-primary">
                <div class="panel-heading">Question Count</div>
                 <div class="panel-body" style="max-height: 600px; overflow-y: scroll">
                    <div class="table-reponsive">
                        <asp:GridView ID="dgv1" runat="server" CssClass="table"></asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="panel panel-primary">
                <div class="panel-heading">Student Count</div>
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