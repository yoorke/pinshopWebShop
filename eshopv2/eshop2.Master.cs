﻿using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using eshopBL;

namespace eshopv2
{
    public partial class eshop : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadFooter();
            Page.Header.DataBind();
            loadMenuPromotions();

            if (HttpContext.Current.User.Identity.IsAuthenticated)
                ((Label)loginView1.FindControl("lblUsername")).Text = Membership.GetUser().UserName;

            if (loginView1.FindControl("lnkLogin") != null)
                //((HyperLink)loginView1.FindControl("lnkLogin")).NavigateUrl = Page.ResolveUrl("~/login.aspx?returnUrl=" + Page.Request.RawUrl);
                ((HyperLink)loginView1.FindControl("lnkLogin")).NavigateUrl = Page.ResolveUrl("~/prijava?returnUrl=" + Page.Request.RawUrl);
            if (loginView1.FindControl("lnkCreateUser") != null)
                ((HyperLink)loginView1.FindControl("lnkCreateUser")).NavigateUrl = Page.ResolveUrl("~/registracija");

            showCompareBox();
        }

        private void loadFooter()
        {
            rptFt1.DataSource = new CustomPageBL().GetCustomPagesForCustomPageCategory(1);
            rptFt1.DataBind();

            rptFt2.DataSource = new CustomPageBL().GetCustomPagesForCustomPageCategory(2);
            rptFt2.DataBind();

            rptFt3.DataSource = new CustomPageBL().GetCustomPagesForCustomPageCategory(3);
            rptFt3.DataBind();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            CartBL cartBL = new CartBL();
            lblProductCount.Text = cartBL.GetProductsCount(Session["cartID"].ToString()).ToString();
            if (lblProductCount.Text != "0")
                lblProductCount.Style.Add("display", "block");
            lblCartPrice.Text = string.Format("{0:N2}", cartBL.GetTotal(Session["cartID"].ToString()));
            base.Render(writer);

            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            //Response.Redirect("~/");
            Response.Redirect(Request.RawUrl);
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtSearch.Text != string.Empty)
                Response.Redirect("~/pretraga?a=" + txtSearch.Text);
        }

        private void showCompareBox()
        {
            if(HttpContext.Current.Session["compare"] != null && ((System.Collections.Generic.List<int>)HttpContext.Current.Session["compare"]).Count > 0)
            {
                compareBox.Style.Add("display", "block");
                compareBoxText.InnerText = "Uporedi (" + ((System.Collections.Generic.List<int>)HttpContext.Current.Session["compare"]).Count.ToString() + ")";
            }

        }

        private void loadMenuPromotions()
        {
            rptPromotions.DataSource = new PromotionBL().GetPromotions(false, null, true);
            rptPromotions.DataBind();
        }
    }
}
