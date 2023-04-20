<%@ Page Language="C#" MasterPageFile="~/Student/Login_master.Master" AutoEventWireup="true" CodeBehind="Exam.aspx.cs" Inherits="Exam_student.Student.Exam" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id="CarIn" runat="server"></div>

    <br />
    <br />
    <asp:Timer ID="ExamClock" runat="server"></asp:Timer>
    <br />
    
    <br />
    <br />

    <asp:Label ID="Label1" runat="server" Text="" Font-Bold="True" ForeColor="Red" Font-Size="Larger"></asp:Label>
    
    <asp:GridView ID="dgv1" runat="server"></asp:GridView>






</asp:Content>