﻿<%@ Page Language="C#" MasterPageFile="~/Therapist.master" AutoEventWireup="true" CodeFile="Therapist_Welcome.aspx.cs" Inherits="Therapist_Welcome" Title="Therapist DashBoard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <script src="FusionCharts/FusionCharts.js" type="text/javascript"></script>
    <script type="text/javascript">
   function preventBack(){window.history.forward();}
    setTimeout("preventBack()", 0);
    window.onunload=function(){null};
    </script>
    <!-- BEGIN PAGE HEADER-->
    <div class="row-fluid">
        <div class="span12">
            <!-- BEGIN PAGE TITLE & BREADCRUMB-->
            <h3 class="page-title">Welcome,
                <asp:Label ID="lblUser" runat="server" />
                <asp:Button id="LinkButton2" class="btn blue" runat="server" style="text-align:left" Text="Intervention Tools" onClientClick="window.open('https://nerdnerdy.com/');"></asp:Button>
                <asp:Button id="LinkButton1" class="btn green" runat="server" style="text-align:left" Text="Buy license" onClientClick="window.open('https://nerdnerdy.com/');"></asp:Button>
            </h3>
            <ul class="breadcrumb">
                <li>
                    <i class="icon-home"></i>
                    <a href="Therapist_Welcome.aspx">Home</a>
                    <i class="icon-angle-right"></i>
                </li>
                <li><a href="Therapist_Welcome.aspx">Dashboard</a></li>
                <li class="pull-right no-text-shadow">
                    <div id="dashboard-report-range" class="dashboard-date-range tooltips no-tooltip-on-touch-device responsive" data-tablet="" data-desktop="tooltips" data-placement="top" data-original-title="Change dashboard date range">
                        <i class="icon-calendar"></i>
                        <span></span>
                        <i class="icon-angle-down"></i>
                    </div>
                </li>
            </ul>
            <!-- END PAGE TITLE & BREADCRUMB-->
        </div>
    </div>
</asp:Content>