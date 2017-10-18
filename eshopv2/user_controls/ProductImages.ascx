﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProductImages.ascx.cs" Inherits="eshopv2.user_controls.ProductImages" %>

<%--<asp:ScriptManager runat="server"></asp:ScriptManager>--%>
<%--<asp:UpdatePanel runat="server">
    <ContentTemplate>--%>
        <div class="row">
            <div class="col-lg-12">
                <div id="thumbnails">
                    <asp:HyperLink ID="lnkImage" runat="server" CssClass="mainImage" data-lightbox="mainImage">
                        <asp:Image ID="imgMain" runat="server" CssClass="img-responsive mainImage" />
                    </asp:HyperLink>
                </div>
            </div>
        </div><!--row-->
        <asp:Repeater ID="rptImages" runat="server" OnItemDataBound="rptImages_ItemDataBound">
            <ItemTemplate>
                <asp:HyperLink ID="lnkImage" runat="server" NavigateUrl='<%#Eval("imageUrl") %>'></asp:HyperLink>
            </ItemTemplate>
        </asp:Repeater>

        <%--<div class="row">--%>
            <asp:Panel ID="pnlThumbs" runat="server" CssClass="thumbs row"></asp:Panel>
        <%--</div><!--row-->--%>
    <%--</ContentTemplate>
</asp:UpdatePanel>--%>

<script type="text/javascript">
    function changeImg(imageUrl)
    {
        var image = document.getElementById("ctl00_ContentPlaceHolder1_priProductImages_imgMain");
        var extension = imageUrl.substring(imageUrl.lastIndexOf('.'));
        image.src = imageUrl.toString().substring(0, imageUrl.toString().indexOf("-thumb")) + "-main" + extension;
        var link = document.getElementById("ctl00_ContentPlaceHolder1_priProductImages_lnkImage");
        link.href = imageUrl.toString().substring(0, imageUrl.toString().indexOf("-thumb"))+extension;
    }
    
</script>