﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eshopDL;
using eshopBE;
using System.Data;
using eshopUtilities;

namespace eshopBL
{
    public class CategoryBL
    {
        /*public List<Category> GetNestedCategoriesList()
        {
            CategoryDL categoryDL = new CategoryDL();
            DataTable categoriesDT = categoryDL.GetCategories();

            List<Category> list = new List<Category>();
            list.Add(new Category((int)categoriesDT.Rows[0]["categoryID"], categoriesDT.Rows[0]["name"].ToString(), 0, categoriesDT.Rows[0]["url"].ToString(), categoriesDT.Rows[0]["imageUrl"].ToString()));
            Category temp = list[0];

            for (int i = 1; i < categoriesDT.Rows.Count; i++)
            {
                //while ((int)categoriesDT.Rows[i]["parentID"] == temp.CategoryID)
                if ((int)categoriesDT.Rows[i]["parentID"] == temp.CategoryID)
                {
                    if (temp.SubCategory == null)
                        temp.SubCategory = new List<Category>();

                    temp.SubCategory.Add(new Category((int)categoriesDT.Rows[i]["categoryID"], categoriesDT.Rows[i]["name"].ToString(), temp.CategoryID, categoriesDT.Rows[i]["url"].ToString(), categoriesDT.Rows[i]["imageUrl"].ToString()));

                }
                else
                {
                    if ((int)categoriesDT.Rows[i]["parentID"] > temp.CategoryID)
                    {

                        temp = temp.SubCategory[temp.SubCategory.Count - 1];
                        i--;
                    }
                    else
                    {
                        temp = list[0];
                        i--;
                    }
                }

            }

            return list[0].SubCategory;
        }*/

        
        /*public DataTable GetNestedCategoriesDataTable()
        {
            CategoryDL categoryDL = new CategoryDL();
            DataTable categoriesDT = categoryDL.GetCategories();
            int tempCategoryID = int.Parse(categoriesDT.Rows[0]["categoryID"].ToString());
            string baseString = "--";

            for (int i = 1; i < categoriesDT.Rows.Count; i++)
            {
                if (int.Parse(categoriesDT.Rows[i]["parentID"].ToString()) == tempCategoryID)
                    categoriesDT.Rows[i]["name"] = baseString + categoriesDT.Rows[i]["name"].ToString();
                else
                    if (int.Parse(categoriesDT.Rows[i]["parentID"].ToString()) > tempCategoryID)
                    {
                        tempCategoryID = int.Parse(categoriesDT.Rows[i-1]["categoryID"].ToString());
                        baseString += "--";
                        i--;
                    }
                    else
                    {
                        tempCategoryID = int.Parse(categoriesDT.Rows[0]["categoryID"].ToString());
                        baseString = "--";
                        i--;
                    }
            }

            return categoriesDT;
        }*/

        /*public List<Category> GetCategories2()
        {
            CategoryDL categoryDL = new CategoryDL();
            DataTable categoriesDT = categoryDL.GetCategories();
            int level = 1;

            List<Category> list = new List<Category>();
            list.Add(new Category((int)categoriesDT.Rows[0]["categoryID"], categoriesDT.Rows[0]["name"].ToString(), (int)categoriesDT.Rows[0]["parentID"], categoriesDT.Rows[0]["url"].ToString(), categoriesDT.Rows[0]["imageUrl"].ToString()));
            Category temp = list[0];

            for (int i = 1; i < categoriesDT.Rows.Count; i++)
            {
                for (int j = 0; j < categoriesDT.Rows.Count; j++)
                {
                    if ((int)categoriesDT.Rows[j]["parentID"] == temp.CategoryID)
                    {
                        if (temp.SubCategory == null)
                            temp.SubCategory = new List<Category>();
                        temp.SubCategory.Add(new Category((int)categoriesDT.Rows[j]["categoryID"], categoriesDT.Rows[j]["name"].ToString(), (int)categoriesDT.Rows[j]["parentID"], categoriesDT.Rows[j]["url"].ToString(), categoriesDT.Rows[j]["imageUrl"].ToString()));
                    }
                }
                if (level < 2)
                {
                    temp = temp.SubCategory[i - 1];
                    level++;
                }
                else
                {
                    if (i < 10)
                        temp = list[0].SubCategory[i - 1];
                    //level--;
                }
            }

            return list[0].SubCategory;
        }*/

        /*public List<Category> GetCategories3()
        {
            CategoryDL categoryDL = new CategoryDL();
            DataTable categoriesDT = categoryDL.GetCategories();

            List<Category> list = new List<Category>();

            for (int i = 0; i < categoriesDT.Rows.Count; i++)
            {
                if ((int)categoriesDT.Rows[i]["parentID"] == 2)
                    list.Add(new Category((int)categoriesDT.Rows[i]["categoryID"], categoriesDT.Rows[i]["name"].ToString(), (int)categoriesDT.Rows[i]["parentID"], categoriesDT.Rows[i]["url"].ToString(), categoriesDT.Rows[i]["imageUrl"].ToString()));
            }

            for (int i = 0; i < list.Count; i++)
                for (int j = 0; j < categoriesDT.Rows.Count; j++)
                    if (list[i].CategoryID == (int)categoriesDT.Rows[j]["parentID"])
                    {
                        if (list[i].SubCategory == null)
                            list[i].SubCategory = new List<Category>();
                        list[i].SubCategory.Add(new Category((int)categoriesDT.Rows[j]["categoryID"], categoriesDT.Rows[j]["name"].ToString(), (int)categoriesDT.Rows[j]["parentID"], categoriesDT.Rows[j]["url"].ToString(), categoriesDT.Rows[j]["imageUrl"].ToString()));
                    }

            return list;
        }*/

        public List<Category> GetNestedCategoriesList()
        {
            CategoryDL categoryDL = new CategoryDL();
            DataTable categoriesDT = categoryDL.GetCategories("sortOrder");

            return GetCategoriesList(categoriesDT, 1);
        }

        private List<Category> GetCategoriesList(DataTable categoriesDT, int parentID)
        {
            List<Category> list = null;

            DataView dv = new DataView(categoriesDT);
            dv.RowFilter = "parentID=" + parentID.ToString();
            Category category;

            if (dv.Count > 0)
                list = new List<Category>();
            foreach (DataRowView row in dv)
            {
                category = new Category();
                category.CategoryID = (int)row["categoryID"];
                category.Name = row["name"].ToString();
                category.Url = row["url"].ToString();
                category.ImageUrl = row["imageUrl"].ToString();
                category.SortOrder = (int)row["sortOrder"];
                category.CategoryBannerID = (int)row["categoryBannerID"];



                category.SubCategory = GetCategoriesList(categoriesDT, (int)row["categoryID"]);

                //foreach (Category childCategory in subCategory)
                    //childCategory.ParentCategoryID = category.CategoryID;

                list.Add(category);
            }
            return list;
        }

        /*public DataTable GetNestedCategoriesDataTable()
        {
            CategoryDL categoryDL = new CategoryDL();
            DataTable categoriesDT = categoryDL.GetCategories();

            return GetCategoriesDataTable(categoriesDT, 2);
        }*/

        public DataTable GetNestedCategoriesDataTable()
        {
            List<Category> list = GetNestedCategoriesList();
            DataTable categoriesDT = new DataTable();
            categoriesDT.Columns.Add("categoryID", typeof(int));
            categoriesDT.Columns.Add("name", typeof(string));
            categoriesDT.Columns.Add("parentID", typeof(int));
            DataRow newRow;

            if (list != null)
            {
                foreach (Category category in list)
                {
                    newRow = categoriesDT.NewRow();
                    newRow["categoryID"] = category.CategoryID;
                    newRow["name"] = "--" + category.Name;
                    categoriesDT.Rows.Add(newRow);
                    if (category.SubCategory != null)
                    {
                        foreach (Category childCategory in category.SubCategory)
                        {
                            newRow = categoriesDT.NewRow();
                            newRow["categoryID"] = childCategory.CategoryID;
                            newRow["name"] = "--------" + childCategory.Name;
                            categoriesDT.Rows.Add(newRow);
                        }
                    }
                }
            }

            return categoriesDT;
        }

        public DataTable GetCategories()
        {
            CategoryDL categoryDL = new CategoryDL();
            return categoryDL.GetCategories();
        }

        public int SaveCategory(Category category)
        {
            CategoryDL categoryDL = new CategoryDL();

            if (category.Name == string.Empty)
                throw new BLException("Unesite naziv kategorije");
            
            if (category.CategoryID > 0)
                return categoryDL.UpdateCategory(category);
            else
                return categoryDL.SaveCategory(category);
        }

        public Category GetCategory(int categoryID)
        {
            CategoryDL categoryDL = new CategoryDL();
            return categoryDL.GetCategory(categoryID);
        }

        public Category GetCategory(string name)
        {
            CategoryDL categoryDL = new CategoryDL();
            return categoryDL.GetCategory(name);
        }

        public int DeleteCategory(int categoryID)
        {
            CategoryDL categoryDL = new CategoryDL();
            return categoryDL.DeleteCategory(categoryID);
        }

        public DataTable GetCategoriesForFirstPage()
        {
            CategoryDL categoryDL = new CategoryDL();
            return categoryDL.GetCategoriesForFirstPage();
        }

        public Category GetCategoryByUrl(string url)
        {
            return new CategoryDL().GetCategoryByUrl(url);
        }

        public List<Category> GetAllSubCategories(int categoryID)
        {
            return new CategoryDL().GetAllSubCategories(categoryID);
        }
    }
}
