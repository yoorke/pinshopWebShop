﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="eshopv2._Default" MasterPageFile="~/eshop2.Master" Title="PinShop | Vaša online prodavnica" %>
<%@ Register Src="user_controls/product_slider.ascx" TagName="ProductSlider" TagPrefix="ps" %>
<%@ Register Src="user_controls/Banner.ascx" TagName="Banner" TagPrefix="banner" %>
<%@ Register Src="user_controls/Slider.ascx" TagName="Slider" TagPrefix="slider" %>
<%@ Register Src="user_controls/MainMenuVerticalV2.ascx" TagName="mainMenuVerticalV2" TagPrefix="mainMenuVerticalV2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="Stylesheet" id="camera-css" href="<%=ResolveUrl("~/css/camera.css") %>" type="text/css" />
    <link href="<%#ResolveUrl("~/css/mainMenuVerticalV2.css") %>" rel="stylesheet" type="text/css" />
    <%--<style>
        .camera_wrap .camera_pag .camera_pag_ul li {
            display:none !important;
        }
    </style>--%>
    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!--<div class="container-fluid">-->
        <%--<div class="col-xs-2 left-column visible-lg visible-md">
            <banner:Banner ID="banner1" runat="server" Position="FP1" />
            <banner:Banner ID="banner2" runat="server" Position="FP2" />
            
            <div class="fb-page" data-href="https://www.facebook.com/pinservis?fref=ts" data-width="180" data-height="400" data-small-header="true" data-adapt-container-width="true" data-hide-cover="true" data-show-facepile="true" data-show-posts="false"><div class="fb-xfbml-parse-ignore"><blockquote cite="https://www.facebook.com/pinservis?fref=ts"><a href="https://www.facebook.com/pinservis?fref=ts">Pin Servis</a></blockquote></div></div>
            
        </div><!--col-banner-->--%>
        
        <!--MAIN CONTENT-->
        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 main-content first-page">
            
            <!--SLIDER-->
            <div class="row">
                <div class="col-md-3 padding-left-0 padding-right-0 mainMenuVertical">
                    <mainMenuVerticalV2:mainMenuVerticalV2 runat="server" ID="mainMenuVerticalV2"></mainMenuVerticalV2:mainMenuVerticalV2>
                </div>
                <div class="col-md-9">
                    <slider:Slider ID="slider1" runat="server" SliderID="12" />
                </div>
            </div>
            <!--<div class="row slider">
                <div class="col-xs-12 padding-left-0 padding-right-0">
                    <div class="camera_wrap camera_azure_skin" id="camera_wrap_1">
                        <div data-thumb="/images/slides/thumbs/bridge.jpg" data-src="/images/slides/slide1.jpg">
                            <%--<div class="camera_caption fadeFromBottom">
                                Camera is a responsive/adaptive slideshow. <em>Try to resize the browser window</em>
                            </div>--%>
                        </div>
                        <div data-thumb="/images/slides/thumbs/leaf.jpg" data-src="/images/slides/slide2.jpg">
                            <%--<div class="camera_caption fadeFromBottom">
                                It uses a light version of jQuery mobile, <em>navigate the slides by swiping with your fingers</em>
                            </div>--%>
                        </div>
                        <div data-thumb="/images/slides/thumbs/road.jpg" data-src="/images/slides/slide3.jpg">
                            <%--<div class="camera_caption fadeFromBottom">
                                <em>It's completely free</em> (even if a donation is appreciated)
                            </div>--%>
                        </div>
                        <div data-thumb="/images/slides/thumbs/sea.jpg" data-src="/images/slides/slide1.jpg">
                            <%--<div class="camera_caption fadeFromBottom">
                                Camera slideshow provides many options <em>to customize your project</em> as more as possible
                            </div>--%>
                        </div>
                        <div data-thumb="/images/slides/thumbs/shelter.jpg" data-src="/images/slides/slide2.jpg">
                            <%--<div class="camera_caption fadeFromBottom">
                                It supports captions, HTML elements and videos and <em>it's validated in HTML5</em> (<a href="http://validator.w3.org/check?uri=http%3A%2F%2Fwww.pixedelic.com%2Fplugins%2Fcamera%2F&amp;charset=%28detect+automatically%29&amp;doctype=Inline&amp;group=0&amp;user-agent=W3C_Validator%2F1.2" target="_blank">have a look</a>)
                            </div>--%>
                        </div>
                        <div data-thumb="/images/slides/thumbs/tree.jpg" data-src="/images/slides/slide3.jpg">
                            <%--<div class="camera_caption fadeFromBottom">
                                Different color skins and layouts available, <em>fullscreen ready too</em>
                            </div>--%>
                        </div>
                    </div><!-- #camera_wrap_1 
                </div><!--col
            </div><!--row-slider-->
            
            <!--PRODUCT SLIDER-->
            <div class="row banners">
                <div class="col-md-4 padding-left-0 padding-right-0 bannerFP fp1">
                    <banner:Banner ID="bannerFP1" runat="server" Position="FP1" />
                </div>
                <div class="col-md-4 bannerFP fp2">
                    <banner:Banner ID="bannerFP2" runat="server" Position="FP2" />
                </div>
                <div class="col-md-4 padding-left-0 padding-right-0 bannerFP fp3">
                    <banner:Banner ID="bannerFP3" runat="server" Position="FP3" />
                </div>
                <div class="col-md-12 padding-left-0 padding-right-0 bannerFP fp4">
                    <banner:Banner ID="bannerFP4" runat="server" Position="FP4" />
                </div>
            </div>
            <div class="row product_slider">
            <div class="col-lg-12">
            <asp:Repeater ID="rptPromotions" runat="server" OnItemDataBound="rptPromotions_ItemDataBound">
                <HeaderTemplate>
                    <!--<div class="row">
                        <div class="col-lg-12">-->
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="lblPromotionID" runat="server" Value='<%#Eval("promotionID") %>' />
                    <!--<h2><asp:Label ID="lblName" runat="server" Text='<%#Eval("name") %>'></asp:Label></h2>-->
                    <ps:ProductSlider ID="productSlider1" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                        <!--</div><!---col
                    </div>-->
                </FooterTemplate>
            </asp:Repeater>
            
            <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_ItemDataBound">
                <HeaderTemplate>
                    <!--<div class="row">
                        <div class="col-lg-12">-->
                </HeaderTemplate>
                <ItemTemplate>
                    <asp:HiddenField ID="lblCategoryID" runat="server" Value='<%#Eval("categoryID") %>' />
                    <asp:HiddenField ID="lblNumberOfProducts" runat="server" Value='<%#Eval("numberOfProducts") %>' />
                    <asp:HiddenField ID="lblFirstPageOrderBy" runat="server" Value='<%#Eval("firstPageOrderBy") %>' />
                    
                    <ps:ProductSlider ID="productSlider2" runat="server" />
                </ItemTemplate>
                <FooterTemplate>
                        <!--</div>
                    </div>-->
                </FooterTemplate>
            </asp:Repeater>
            </div><!--col-->
            </div><!--product-slider-->
                    
            <div class="row banners">
                <div class="col-md-4 padding-left-0 padding-right-0 bannerFP fp1">
                    <banner:Banner ID="bannerFP5" runat="server" Position="FP1" />
                </div>
                <div class="col-md-4 bannerFP fp2">
                    <banner:Banner ID="banenrFP6" runat="server" Position="FP2" />
                </div>
                <div class="col-md-4 padding-left-0 padding-right-0 bannerFP fp3">
                    <banner:Banner ID="bannerFP7" runat="server" Position="FP3" />
                </div>
            </div>
        </div><!--col-main-->
    <!--</div>--><!--container-->
    
    
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolderFooter" runat="server">
    
    <script src="<%=ResolveUrl("~/js/jquery.mobile.customized.min.js") %>"></script>
    <script src="<%=ResolveUrl("~/js/jquery.easing.1.3.js") %>"></script>
    <script src="<%=ResolveUrl("~/js/camera.js") %>"></script>
    
    <script>
        jquery_1_7_1(function() {

            jquery_1_7_1('#camera_wrap_1').camera({
                thumbnails: true
                //onLoaded: function() {
                    //jquery_1_7_1(".camera-pag").show();
                //}
            });
        });
	</script>
    <script>
        $(document).ready(function () {
            if ($(window).width() >= 1024) {
                $('.cd-dropdown').addClass('dropdown-is-active');
                $('.cd-dropdown-trigger').hide();
            }
            else if ($(window).width() < 1024) {
                $('.cd-dropdown-trigger').show();
            }
        })
    </script>
</asp:Content>
