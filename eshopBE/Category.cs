﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eshopBE
{
    public class Category
    {
        private int _categoryID;
        private string _name;
        private List<Category> _subCategory;
        private int? _parentCategoryID;
        private string _url;
        private string _imageUrl;
        private int _sortOrder;
        private double _pricePercent;
        private double _webPricePercent;
        private bool _showOnFirstPage;
        private int _numberOfProducts;
        private int _firstPageSortOrder;
        private string _firstPageOrderBy;
        private string _description;
        private bool _active;
        private Slider _slider;
        private int _categoryBannerID;

        public Category()
        {
        }

        public Category(int categoryID, string name, int? parentCategoryID, string url, string imageUrl, int sortOrder, double pricePercent, double webPricePercent, string description, bool active, int categoryBannerID, Slider slider = null)
        {
            _categoryID = categoryID;
            _name = name;
            _parentCategoryID = parentCategoryID;
            _url = url;
            _imageUrl = imageUrl;
            _sortOrder = sortOrder;
            _pricePercent = pricePercent;
            _webPricePercent = webPricePercent;
            _description = description;
            _active = active;
            _slider = slider;
            _categoryBannerID = categoryBannerID;
        }

        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public List<Category> SubCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }

        public int? ParentCategoryID
        {
            get { return _parentCategoryID; }
            set { _parentCategoryID = value; }
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public int SortOrder
        {
            get { return _sortOrder; }
            set { _sortOrder = value; }
        }

        public double PricePercent
        {
            get { return _pricePercent; }
            set { _pricePercent = value; }
        }

        public double WebPricePercent
        {
            get { return _webPricePercent; }
            set { _webPricePercent = value; }
        }

        public bool ShowOnFirstPage
        {
            get { return _showOnFirstPage; }
            set { _showOnFirstPage = value; }
        }

        public int NumberOfProducts
        {
            get { return _numberOfProducts; }
            set { _numberOfProducts = value; }
        }

        public int firstPageSortOrder
        {
            get { return _firstPageSortOrder; }
            set { _firstPageSortOrder = value; }
        }

        public string firstPageOrderBy
        {
            get { return _firstPageOrderBy; }
            set { _firstPageOrderBy = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public bool Active
        {
            get { return _active; }
            set { _active = value; }
        }

        public Slider Slider
        {
            get { return _slider; }
            set { _slider = value; }
        }

        public int CategoryBannerID
        {
            get { return _categoryBannerID; }
            set { _categoryBannerID = value; }
        }
    }
}
