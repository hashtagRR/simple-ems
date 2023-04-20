<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Exam_student.Student.Home" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1></h1>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <div class="w3-content w3-section" style="max-width: 500px">
                    <img class="mySlides" src="img/a1.jpg" style="width: 100%">
                    <img class="mySlides" src="img/a2.jpg" style="width: 100%">
                    <img class="mySlides" src="img/a3.jpg" style="width: 100%">
                    <img class="mySlides" src="img/a4.jpg" style="width: 100%">
                    <img class="mySlides" src="img/a5.jpg" style="width: 100%">
                    <img class="mySlides" src="img/a6.jpg" style="width: 100%">
                    <img class="mySlides" src="img/a7.jpg" style="width: 100%">
                </div>
            </div>
            <div class="col-md-6">

                <div class="panel panel-primary">
                    <div class="panel-heading">Recomended Learning Partners</div>
                    <div class="panel-body">
                        <p>
                            Whether you’re five or ninety five,
                            the internet has a lot to offer.
                            Particularly when the topic is education,
                            the resources on the internet are endless.
                            Best of all, many high quality sites are completely free.
                            From history to coding, excellent free education awaits on the following web sites.
                        </p>
                        <ul class="list-group">
                            <li class="list-group-item"><a href=" https://www.coursera.org/?siteID=TnL5HPStwNw-F6VG3bK7XajypPOwTEbtZA&utm_content=10&utm_medium=partners&utm_source=linkshare&utm_campaign=TnL5HPStwNw">Coursera</a> </li>
                            <li class="list-group-item"><a href=" https://www.khanacademy.org/">Khan Academy</a></li>
                            <li class="list-group-item"><a href=" http://www.openculture.com/freeonlinecourses">Open Culture Online Courses</a></li>
                            <li class="list-group-item"><a href="https://www.udemy.com/?siteID=TnL5HPStwNw-OthuI2prurV5qRVhArGrJw&LSNPUBID=TnL5HPStwNw ">Udemy </a></li>
                            <li class="list-group-item"><a href="http://academicearth.org/ ">Academic Earth</a></li>
                            <li class="list-group-item"><a href="https://www.edx.org/?source=aw&awc=6798_1494685716_62ad72d0104a6a0045a1e4754a82e4e9&utm_source=aw&utm_medium=affiliate_partner&utm_content=text-link&utm_term=78888_Skimlinks ">edX</a></li>
                            <li class="list-group-item"><a href=" https://alison.com/">Alison</a></li>
                            <li class="list-group-item"><a href="http://www.extension.harvard.edu/open-learning-initiative ">Harvard Extension</a></li>
                            <li class="list-group-item"><a href="http://oyc.yale.edu/ ">Open Yale Courses</a></li>
                            <li class="list-group-item"><a href="https://www.class-central.com/university/berkeley ">UC Berkeley Class Central</a></li>
                        </ul>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        var myIndex = 0;
        carousel();

        function carousel() {
            var i;
            var x = document.getElementsByClassName("mySlides");
            for (i = 0; i < x.length; i++) {
                x[i].style.display = "none";
            }
            myIndex++;
            if (myIndex > x.length) { myIndex = 1 }
            x[myIndex - 1].style.display = "block";
            setTimeout(carousel, 3000); // Change image every 2 seconds
        }
    </script>
</asp:Content>