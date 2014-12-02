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
using System.Windows.Navigation;
using System.Data.SqlClient;
using System.ComponentModel;

namespace CompuTrackWPF
{
    /// <summary>
    /// Interaction logic for ItemWindow.xaml
    /// </summary>
    public partial class ItemWindow : Window
    {
        public ItemWindow(InventoryMain inventoryMain)
        {
            InitializeComponent();
            this.im = inventoryMain;
        }

        public ItemWindow()
        {
            InitializeComponent();
        }

        InventoryMain im;

        private void cancelItemBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void saveItemBtn_Click(object sender, RoutedEventArgs e)
        {
            newItem();
        }

        public void newItem()
        {
            bool added = false;
            bool connected;
            int id = 0;

            try
            {
                Shared.ramdbConnection.Open();
                connected = true;
            }
            catch
            {
                connected = false;
            }

            if (connected)
            {

                SqlCommand saveItem = new SqlCommand("INSERT into Items (ItemCategory, ItemMake, ItemModel, ItemSpecs, ItemCount, Threshold) " +
                    "Values (@ItemCategory, @ItemMake, @ItemModel, @ItemSpecs, @ItemCount, @Threshold)" +
                    "SELECT Item_id FROM Items WHERE Item_id = SCOPE_IDENTITY()");
                saveItem.Connection = Shared.ramdbConnection;
                if (itemCategoryBox.SelectedItem == null || itemMakeBox.Text.Equals("") || quantityBox.Text.Equals("") || 
                    (itemCategoryBox.Text.Equals("New Category") && newCategoryBox.Text.Equals("")))
                {
                    messageLabel.Content = "Please make sure all required fields are filled in.";
                }
                else
                {
                    if (itemCategoryBox.Text.Equals("New Category"))
                    {
                        saveItem.Parameters.AddWithValue("@ItemCategory", newCategoryBox.Text);
                        SqlCommand saveCategory = new SqlCommand("INSERT into ItemTypes (ItemType)" + "Values (@ItemType)", Shared.ramdbConnection);
                        saveCategory.Parameters.AddWithValue("@ItemType", newCategoryBox.Text);
                        try
                        {
                            saveCategory.ExecuteNonQuery();
                        }
                        catch
                        {
                            //category wasn't saved
                        }

                    }
                    else
                    {
                        saveItem.Parameters.AddWithValue("@ItemCategory", itemCategoryBox.Text);
                    }
                    string model = "N/A";
                    string specs = "N/A";
                    if (!itemModelBox.Text.Equals("")) model = itemModelBox.Text;
                    if (!itemSpecsBox.Text.Equals("")) specs = itemSpecsBox.Text;

                    saveItem.Parameters.AddWithValue("@ItemMake", itemMakeBox.Text);
                    saveItem.Parameters.AddWithValue("@ItemModel", model);
                    saveItem.Parameters.AddWithValue("@ItemSpecs", specs);
                    saveItem.Parameters.AddWithValue("@ItemCount", quantityBox.Text);
                    saveItem.Parameters.AddWithValue("@Threshold", itemThresholdBox.Text);
                    try
                    {
                        SqlDataReader readId = saveItem.ExecuteReader();
                        while (readId.Read())
                        {
                            id = System.Convert.ToInt32(readId["Item_id"]);
                        }
                        saveItemBtn.IsEnabled = false;
                        Close();
                        im.newItemBtn.IsEnabled = true;
                        if (im.mw != null) im.mw.newItemMenuItem.IsEnabled = true;
                        added = true;
                    }
                    catch
                    {
                        messageLabel.Content = "Error saving to database.";
                    }
                }

                Shared.ramdbConnection.Close();

                if (added)
                {
                    addLog();
                    im.Refresh();
                    im.selectItem(id);
                }
            }
        }

        private void itemCategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (newCategoryBox != null && itemCategoryBox != null && itemCategoryBox.SelectedValue != null)
            {
                ItemCategory selectedItem = itemCategoryBox.Items.GetItemAt(itemCategoryBox.SelectedIndex) as ItemCategory;
                string typeCategoryString = selectedItem.CategoryString;
                if (typeCategoryString.Equals("New Category")) newCategoryBox.Visibility = System.Windows.Visibility.Visible;
                else newCategoryBox.Visibility = System.Windows.Visibility.Hidden;
            }
        }

        private void addLog()
        {
            bool connected;
            try
            {
                Shared.ramdbConnection.Open();
                connected = true;
            }
            catch
            {
                connected = false;
            }
            if (connected)
            {
                SqlCommand updateLogCmd = new SqlCommand("INSERT into InventoryLog (Entry, Reason, MadeBy)" + "Values (@Entry, @Reason, @MadeBy)", Shared.ramdbConnection);
                string entry = "Added new item:\n    \u2022 Category: " + itemCategoryBox.Text + "\n    \u2022 Make: " + itemMakeBox.Text + "\n    \u2022 Model: " + itemModelBox.Text;
                string reason = "New item";
                updateLogCmd.Parameters.AddWithValue("@Entry", entry);
                updateLogCmd.Parameters.AddWithValue("@Reason", reason);
                updateLogCmd.Parameters.AddWithValue("@MadeBy", Shared.currentUser._userName);

                updateLogCmd.ExecuteNonQuery();

                Shared.ramdbConnection.Close();
            }
        }
        
        private void newItemField_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter) newItem();
        }

        private void itemCategoryBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return || e.Key == Key.Enter)
            {
                newItem();
            }
            if (e.Key == Key.Delete)
            {
                deleteCategory();
            }
        }

        private void deleteCategory()
        {
            ItemCategory selectedCategory = itemCategoryBox.SelectedItem as ItemCategory;
            if (selectedCategory != null)
            {
                if (!selectedCategory.CategoryString.Equals("New Category"))
                {
                    int reselectCategory = itemCategoryBox.SelectedIndex;
                    DeleteCategoryWindow confirm = new DeleteCategoryWindow(selectedCategory);
                    confirm.Owner = Window.GetWindow(this);
                    confirm.ShowDialog();                    
                    var referenceToCategoryBox = (ItemCategoryData)FindResource("CategoryList");
                    referenceToCategoryBox.RefreshList();
                    itemCategoryBox.SelectedIndex = reselectCategory;

                }
            }
        }

        private void itemWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
        }

    }
}
