using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace CompuTrackWPF
{
    class ItemCategoryData : ObservableCollection<ItemCategory>
    {
        public ItemCategoryData() : base()
        {
            PopulateCategories();
        }

        private void PopulateCategories()
        {
            //adds an item that will be used for New Category item and filtering option None
            ItemCategory noneFilter = new ItemCategory("New Category");
            noneFilter.filterString = "None";
            Add(noneFilter);

            try
            {
                Shared.ramdbConnection.Open();

                try
                {                    
                    SqlCommand populateCategoryCmd = new SqlCommand("SELECT ItemType FROM ItemTypes ORDER BY ItemType", Shared.ramdbConnection);
                    SqlDataReader categoryReader = populateCategoryCmd.ExecuteReader();
                    while (categoryReader.Read())
                    {
                        string categoryString = categoryReader["ItemType"].ToString();
                        Add(new ItemCategory(categoryString));
                    }

                    Shared.ramdbConnection.Close();
                }
                catch { }
            }
            catch
            {
                //couldn't open database connection
            }
        }

        public void RefreshList()
        {
            Clear();
            PopulateCategories();
        }
    }

    public class ItemCategory
    {
        private string categoryString;
        public string filterString;

        public ItemCategory(string category)
        {
            this.categoryString = category;
            this.filterString = category;
        }
        
        public ItemCategory()
        {
        }

        public string CategoryString
        {
            get { return categoryString; }
            set { CategoryString = value; }
        }

        public string FilterString
        {
            get { return filterString; }
            set { FilterString = value; }
        }
    }
}
