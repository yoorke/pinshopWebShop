<%@ Page Language="C#" MasterPageFile="~/eshop2.Master" AutoEventWireup="true" CodeBehind="customPage.aspx.cs" Inherits="eshopv2.customPage" Title="Untitled Page" %>
<%@ Register Src="user_controls/Banner.ascx" TagName="Banner" TagPrefix="banner" %>
<%@ Register Src="~/user_controls/product_fp.ascx" TagName="ProductFP" TagPrefix="ws" %>
<%@ Register Src="~/user_controls/Breadcrumbs.ascx" TagName="Breadcrumbs" TagPrefix="ws" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="<%=ResolveUrl("~/css/mainMenuVertical.css") %>" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%--<div class="col-xs-2 left-column visible-lg visible-md">
        <banner:Banner ID="banner1" runat="server" Position="FP1" />
        <banner:Banner ID="banner2" runat="server" Position="FP2" />        
    </div>--%>
    <ws:Breadcrumbs ID="breadcrumbs" runat="server" />
    <div class="col-lg-12">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="customPage">
                <h1 class="heading"><asp:Literal ID="lblHeading" runat="server"></asp:Literal></h1>
        
                <div id="divContent" runat="server"></div>
            </div>
        </div>
        <div class="row margin-top-2">
            <asp:Repeater ID="rptProducts" runat="server">
                <ItemTemplate>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 padding-left-0 padding-right-0">
                        <ws:ProductFP ID="productFP" runat="server" ProductItem='<%#Container.DataItem %>' />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="row banners">
            <div class="col-md-4 padding-left-0 padding-right-0 bannerFP fp1">
                <banner:Banner id="bannerCP1" runat="server" Position="CP1" />
            </div>
            <div class="col-md-4 bannerFP fp2">
                <banner:Banner ID="bannerCP2" runat="server" Position="CP2" />
            </div>
            <div class="col-md-4 padding-left-0 padding-right-0 bannerFP fp3">
                <banner:Banner ID="bannerCP3" runat="server" Position="CP3" />
            </div>
        </div>
    </div>
</asp:Content>
