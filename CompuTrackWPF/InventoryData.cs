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
using System.Collections.ObjectModel;
using System.ComponentModel;


namespace CompuTrackWPF
{
    
    public class InventoryData : ObservableCollection<InventoryItem> 
    {
        public InventoryData() : base()
        {            
            PopulateInventoryListView();
        }

        private void PopulateInventoryListView()
        {
            try
            {
                Shared.ramdbConnection.Open();
                try
                {
                    SqlCommand populateInventoryCmd = new SqlCommand("SELECT Item_id, ItemCategory, ItemMake, ItemModel, ItemSpecs, ItemCount, Threshold FROM Items");
                    populateInventoryCmd.Connection = Shared.ramdbConnection;
                    SqlDataReader inventoryReader = populateInventoryCmd.ExecuteReader();
                    while (inventoryReader.Read())
                    {
                        int id = System.Convert.ToInt32(inventoryReader["Item_id"]);
                        string category = inventoryReader["ItemCategory"].ToString();
                        string make = inventoryReader["ItemMake"].ToString();
                        string model = inventoryReader["ItemModel"].ToString();
                        string specs = inventoryReader["ItemSpecs"].ToString();
                        int count = System.Convert.ToInt32(inventoryReader["ItemCount"]);
                        int threshold = System.Convert.ToInt32(inventoryReader["Threshold"]);
                        Add(new InventoryItem(id, category, make, model, specs, count, threshold));
                    }

                    Shared.ramdbConnection.Close();
                }
                catch { }
            }
            catch
            {
                Add(new InventoryItem(0, "No", "Connection", "", "", 0, 0));
            }
        }

        public void RefreshList()
        {
            Clear();
            PopulateInventoryListView();
        }
    }


    public class InventoryItem : INotifyPropertyChanged
    {
        private int item_id;
        private string itemCategory;
        private string itemMake;
        private string itemModel;
        private string itemSpecs;
        private int itemCount;
        private int itemThreshold;

        //auto update stuff
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName)) ;
            
        }


        public InventoryItem(int id, string category, string make, string model, string specs, int count, int threshold)
        {
            this.item_id = id;
            this.itemCategory = category;
            this.itemMake = make;
            this.itemModel = model;
            this.itemSpecs = specs;
            this.itemCount = count;
            this.itemThreshold = threshold;
        }

        public int Item_id
        {
            get {return item_id;}
            set { item_id = value; OnPropertyChanged("Item_id"); }
        }
        public string ItemCategory
        {
            get {return itemCategory;}
            set { itemCategory = value; OnPropertyChanged("ItemCategory"); }
        }

        public string ItemMake
        {
            get { return itemMake; }
            set { itemMake = value; OnPropertyChanged("ItemMake"); }
        }

        public string ItemModel
        {
            get { return itemModel; }
            set { itemModel = value; OnPropertyChanged("ItemModel"); }
        }

        public string ItemSpecs
        {
            get { return itemSpecs; }
            set { itemSpecs = value; OnPropertyChanged("ItemSpecs"); }
        }

        public int ItemCount
        {
            get { return itemCount; }
            set { itemCount = value; OnPropertyChanged("ItemCount"); }
        }

        public int ItemThreshold
        {
            get { return itemThreshold; }
            set { itemThreshold = value; OnPropertyChanged("ItemThreshold"); }
        }
    } 
}
