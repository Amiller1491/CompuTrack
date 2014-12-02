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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.ComponentModel;
using CompuTrackWPF;

namespace CompuTrackWPF
{
    /// <summary>
    /// Interaction logic for InventoryMain.xaml
    /// </summary>
    public partial class InventoryMain : Page
    {
        public InventoryMain()
        {
            InitializeComponent();            
        }

        InventoryItem selectedItem = null;
        public MainWindow mw;
        bool connected;

        public void getMainWindow(MainWindow mainWindow)
        {
            this.mw = mainWindow;
        }

        public void Refresh()
        {
            int reselectFilter = filterbyType.SelectedIndex;
            int reselectCategory = itemCategoryBox.SelectedIndex;
            var referenceToFilterBox = (ItemCategoryData)FindResource("CategoryList");
            referenceToFilterBox.RefreshList();
            var referenceToCategoryBox = (ItemCategoryData)FindResource("CategoryList");
            referenceToCategoryBox.RefreshList();
            var referenceToInventoryList = (InventoryData)FindResource("DataList");
            referenceToInventoryList.RefreshList();
            updateItem();
            filterbyType.SelectedIndex = reselectFilter;
            itemCategoryBox.SelectedIndex = reselectCategory;
        }

        public void selectItem(int selectItemId)
        {
            if (selectItemId < 0)
            {
                inventoryListView.SelectedIndex = -1;
            }
            else
            {
                for (int i = 0; i < inventoryListView.Items.Count; i++)
                {
                    InventoryItem item = inventoryListView.Items.GetItemAt(i) as InventoryItem;
                    if (item.Item_id == selectItemId)
                    {
                        inventoryListView.SelectedIndex = i;
                        break;
                    }

                }
            }
        }

        public void updateItem() 
        {
            try
            {

                newCategoryBox.Text = "";
                reasonBox.Text = "Insert any log comments here...";

                if (selectedItem == null)
                {
                    itemLabel.Content = ("Select an item to view details");
                    countTextBox.Text = "";
                    thresholdBox.Text = "";
                    descriptionTextBox.Text = "";
                    makeBox.Text = "";
                    modelBox.Text = "";
                    errorLabel.Content = "";
                    itemCategoryBox.SelectedIndex = -1;
                }
                else
                {
                    errorLabel.Content = "";
                    itemLabel.Content = ("Viewing selected item:");
                    countTextBox.Text = selectedItem.ItemCount.ToString();
                    descriptionTextBox.Text = selectedItem.ItemSpecs.ToString();
                    makeBox.Text = selectedItem.ItemMake.ToString();
                    modelBox.Text = selectedItem.ItemModel.ToString();
                    thresholdBox.Text = selectedItem.ItemThreshold.ToString();
                    updateCategoryBox();
                }
            }
            catch { }
        }

        public void updateCategoryBox()
        {
            string itemCategoryString = selectedItem.ItemCategory.ToString();
            int selectedIndex = 0;
            for (int i = 0; i < itemCategoryBox.Items.Count; i++)
            {
                ItemCategory selectedItemCategory = itemCategoryBox.Items[i] as ItemCategory;
                selectedIndex = i;
                if (selectedItemCategory.CategoryString.Equals(itemCategoryString)) break;
            }
            itemCategoryBox.SelectedIndex = selectedIndex;
            ItemCategory item = itemCategoryBox.Items.GetItemAt(itemCategoryBox.SelectedIndex) as ItemCategory;
            string typeCategoryString = item.CategoryString;
            if (typeCategoryString.Equals("New Category")) newCategoryBox.Visibility = System.Windows.Visibility.Visible;                
            else newCategoryBox.Visibility = System.Windows.Visibility.Hidden;
        }

        private void saveItem()
        {

            bool newCategoryBool = false;

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
                SqlCommand updateCmd = new SqlCommand("UPDATE Items SET ItemCount=@ItemCount, ItemSpecs=@ItemSpecs, ItemCategory=@ItemCategory, ItemMake=@ItemMake, ItemModel=@ItemModel, Threshold=@Threshold WHERE Item_id=@Item_id", Shared.ramdbConnection);

                string model = "N/A";
                string description = "N/A";
                if (!modelBox.Text.Equals("")) model = modelBox.Text;
                if (!descriptionTextBox.Text.Equals("")) description = descriptionTextBox.Text;

                updateCmd.Parameters.AddWithValue("@ItemCount", countTextBox.Text);
                updateCmd.Parameters.AddWithValue("@ItemSpecs", description);
                updateCmd.Parameters.AddWithValue("@ItemMake", makeBox.Text);
                updateCmd.Parameters.AddWithValue("@ItemModel", model);
                updateCmd.Parameters.AddWithValue("@Threshold", thresholdBox.Text);
                updateCmd.Parameters.AddWithValue("@Item_id", selectedItem.Item_id);

                if (itemCategoryBox.Text.Equals("New Category") && !newCategoryBox.Text.Equals(""))
                {
                    updateCmd.Parameters.AddWithValue("@ItemCategory", newCategoryBox.Text);
                    SqlCommand saveCategory = new SqlCommand("INSERT into ItemTypes (ItemType)" + "Values (@ItemType)", Shared.ramdbConnection);
                    saveCategory.Parameters.AddWithValue("@ItemType", newCategoryBox.Text);
                    saveCategory.ExecuteNonQuery();
                    newCategoryBool = true;
                }
                else if (!itemCategoryBox.Text.Equals("New Category"))
                {
                    updateCmd.Parameters.AddWithValue("@ItemCategory", itemCategoryBox.Text);
                    newCategoryBool = false;
                }
                else 
                {
                    updateCmd.Parameters.AddWithValue("@ItemCategory", selectedItem.ItemCategory);
                }                
                errorLabel.Content = "";
                updateCmd.ExecuteNonQuery();                
                Shared.ramdbConnection.Close();
                updateLog(newCategoryBool, model, description);  
            }
        }

        private void deleteItem()
        {
            DeleteItemWindow deleteWindow = new DeleteItemWindow();
            deleteWindow.Owner = Window.GetWindow(this);
            deleteWindow.ShowDialog();
            bool terminated = deleteWindow.deleteConfirmed;

            if (terminated)
            {
                deleteLog();

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
                    SqlCommand deleteItem = new SqlCommand("DELETE FROM Items WHERE Item_id = @Item_id", Shared.ramdbConnection);
                    deleteItem.Parameters.AddWithValue("@Item_id", selectedItem.Item_id);
                    deleteItem.ExecuteNonQuery();
                    Shared.ramdbConnection.Close();
                    Refresh();
                }
            }
        }

        private void deleteCategory()
        {
            ItemCategory selectedCategory = itemCategoryBox.SelectedItem as ItemCategory;
            if (selectedCategory != null)
            {
                if (!selectedCategory.CategoryString.Equals("New Category"))
                {
                    DeleteCategoryWindow confirm = new DeleteCategoryWindow(selectedCategory);
                    confirm.Owner = Window.GetWindow(this);
                    confirm.ShowDialog();
                    Refresh();
                }
            }
        }

        #region Log Methods

        private void updateLog(bool newCat, string model, string description)
        {
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

                string entry = "Edited item:\n    \u2022 Category: " + selectedItem.ItemCategory + "\n    \u2022 Make: " + selectedItem.ItemMake + "\n    \u2022 Model: " + selectedItem.ItemModel + "\nChanges:\n";

                if (selectedItem.ItemCount != System.Convert.ToInt32(countTextBox.Text))
                {
                    entry += ("    \u2022 Quantity changed from " + selectedItem.ItemCount + " to " + countTextBox.Text + ".\n");
                }
                if (selectedItem.ItemThreshold != System.Convert.ToInt32(thresholdBox.Text))
                {
                    entry += ("    \u2022 Threshold changed from " + selectedItem.ItemThreshold + " to " + thresholdBox.Text + ".\n");
                }
                if (!selectedItem.ItemMake.Equals(makeBox.Text))
                {
                    entry += ("    \u2022 Make changed from \"" + selectedItem.ItemMake + "\" to \"" + makeBox.Text) + "\".\n";
                }
                if (!selectedItem.ItemModel.Equals(model))
                {
                    entry += ("    \u2022 Model changed from \"" + selectedItem.ItemModel + "\" to \"" + model + "\".\n");
                }
                if (!selectedItem.ItemSpecs.Equals(description))
                {
                    entry += ("    \u2022 Description changed from \"" + selectedItem.ItemSpecs + "\" to \"" + description + "\".\n");
                }
                if (newCat)
                {
                    entry += ("    \u2022 Category changed from \"" + selectedItem.ItemCategory + "\" to \"" + newCategoryBox.Text + "\".\n");
                }
                else if (!selectedItem.ItemCategory.Equals(itemCategoryBox.Text))
                {
                    entry += ("    \u2022 Category changed from \"" + selectedItem.ItemCategory + "\" to \"" + itemCategoryBox.Text + "\".\n");
                }
                
                string reason = "";
                if (reasonBox.Text.Equals("Insert any log comments here..."))
                {
                    reason = "None given.";
                }
                else
                {
                    reason = reasonBox.Text;
                }                  

                updateLogCmd.Parameters.AddWithValue("@Entry", entry);
                updateLogCmd.Parameters.AddWithValue("@Reason", reason);
                updateLogCmd.Parameters.AddWithValue("@MadeBy", Shared.currentUser._userName);

                updateLogCmd.ExecuteNonQuery();

                Shared.ramdbConnection.Close();
            }
        }

        private void deleteLog()
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
                string entry = "Deleted item:\n    \u2022 Category: " + selectedItem.ItemCategory + "\n    \u2022 Make: " + selectedItem.ItemMake + "\n    \u2022 Model: " + selectedItem.ItemModel;
                string reason = "";
                if (reasonBox.Text.Equals("Insert any log comments here..."))
                {
                    reason = "None given.";
                }
                else
                {
                    reason = reasonBox.Text;
                }

                updateLogCmd.Parameters.AddWithValue("@Entry", entry);
                updateLogCmd.Parameters.AddWithValue("@Reason", reason);
                updateLogCmd.Parameters.AddWithValue("@MadeBy", Shared.currentUser._userName);

                updateLogCmd.ExecuteNonQuery();

                Shared.ramdbConnection.Close();
            }
        }

        #endregion

        private bool hasItemChanged()
        {
            if (selectedItem.ItemCount != System.Convert.ToInt32(countTextBox.Text))
            {
                return true;
            }
            if (selectedItem.ItemThreshold != System.Convert.ToInt32(thresholdBox.Text))
            {
                return true;
            }
            if (!selectedItem.ItemMake.Equals(makeBox.Text))
            {
                return true;
            }
            if (!selectedItem.ItemModel.Equals(modelBox.Text))
            {
                return true;
            }
            if (!selectedItem.ItemSpecs.Equals(descriptionTextBox.Text))
            {
                return true;
            }
            if (!selectedItem.ItemCategory.Equals(itemCategoryBox.Text))
            {
                return true;
            }
            return false;
        }

        private void emailAlert()
        {
            EmailCreator.sendEmail("Quantity Low", "The following item is low in stock:\n    \u2022 Category: " + selectedItem.ItemCategory +
                "\n    \u2022 Make: " + selectedItem.ItemMake + "\n    \u2022 Model: " + selectedItem.ItemModel + "\n    \u2022 Quantity: " +
                selectedItem.ItemCount + "\n\n\n This item is currently set to send automated emails whenever the quantity falls below " + 
                selectedItem.ItemThreshold + ". You can change this threshold and other emailing options within Computrack.");

        }

        #region Sorting/Filtering

        private void Sort(String sortBy, ListSortDirection direction)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(inventoryListView.ItemsSource);
            dataView.SortDescriptions.Clear();   
            //needs to be named the databinding not the header. used different names so setting here.
            if (sortBy.Equals("Type")) sortBy = "ItemCategory";
            if (sortBy.Equals("Make")) sortBy = "ItemMake";
            if (sortBy.Equals("Specs")) sortBy = "ItemSpecs";
            if (sortBy.Equals("Quantity")) sortBy = "ItemCount";            
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();           
        }       

        public bool inventoryFilter(object ob)
        {
            InventoryItem item = ob as InventoryItem;

            string filterString = "";
            if (searchInventoryBox != null)
            {
                if (!(searchInventoryBox.Text == "Search inventory..."))
                {
                    filterString = searchInventoryBox.Text.ToLower();
                }            
            }

            string itemType = item.ItemCategory.ToLower();
            string itemSpecs = item.ItemSpecs.ToLower();
            string itemMake = item.ItemMake.ToLower();
            string itemModel = item.ItemModel.ToLower();
            int typeFilterIndex = filterbyType.SelectedIndex;
            ItemCategory typeFilterItem = null;
            try
            {
                typeFilterItem = filterbyType.Items.GetItemAt(typeFilterIndex) as ItemCategory;
            }
            catch (ArgumentOutOfRangeException e)
            {                  
            }

            if (typeFilterItem != null)
            {
                string typeFilterString = typeFilterItem.FilterString;
                if (typeFilterString == "None")
                {
                    if (filterString == "")
                    {
                        return true;
                    }
                    else if (itemType.Contains(filterString) || itemSpecs.Contains(filterString) || itemMake.Contains(filterString) || itemModel.Contains(filterString))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    if (filterString == "")
                    {
                        return (item.ItemCategory == typeFilterString);
                    }
                    else if ((itemType.Contains(filterString) || itemSpecs.Contains(filterString) || itemMake.Contains(filterString) || itemModel.Contains(filterString))
                        && item.ItemCategory == typeFilterString)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            else
            {
                return (itemType.Contains(filterString) || itemSpecs.Contains(filterString) || itemMake.Contains(filterString) || itemModel.Contains(filterString));
            }
        }

        #endregion

        #region EventHandlers

            #region Sorting/Filtering Handlers

        private void InventoryHeaderClicked(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader clicked = e.OriginalSource as GridViewColumnHeader; 

            if (clicked != null && clicked.Role != GridViewColumnHeaderRole.Padding)
            {
                string header = clicked.Column.Header as string;
                Sort(header, inventoryListView.getSortDirection(clicked));                
            }
        }

        

        private void typeFilter_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (inventoryListView != null)
            {
                ICollectionView dataView = CollectionViewSource.GetDefaultView(inventoryListView.ItemsSource);
                dataView.Filter = new Predicate<object>(inventoryFilter);
            }
        }

        private void searchInventoryBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (inventoryListView != null)
            {
                ICollectionView dataview = CollectionViewSource.GetDefaultView(inventoryListView.ItemsSource);
                dataview.Filter = new Predicate<object>(inventoryFilter);
            }
        }

        private void itemCategoryBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (errorLabel != null) errorLabel.Content = "";

            if (newCategoryBox != null && itemCategoryBox != null && itemCategoryBox.SelectedValue != null)
            {
                ItemCategory item = itemCategoryBox.Items.GetItemAt(itemCategoryBox.SelectedIndex) as ItemCategory;
                string typeCategoryString = item.CategoryString;
                if (typeCategoryString.Equals("New Category")) newCategoryBox.Visibility = System.Windows.Visibility.Visible;
                else newCategoryBox.Visibility = System.Windows.Visibility.Hidden;

            }
        }

            #endregion

            #region Item Management Handlers

        private void inventoryListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedItem = (InventoryItem)this.inventoryListView.SelectedItem;
            updateItem();
        }

        public void newItemBtn_Click(object sender, RoutedEventArgs e)
        {
            ItemWindow iw = new ItemWindow(this);
            iw.Owner = Window.GetWindow(this);
            iw.ShowDialog();
        }

        private void fixNumberBoxes()
        {
            if (thresholdBox.Text.Equals("")) thresholdBox.Text = "0";
            if (countTextBox.Text.Equals("")) countTextBox.Text = "0";
        }

        private bool saveChecks()
        {
            if (selectedItem == null)
            {
                printError("Must select an item.");
                return false;
            }
            if (!hasItemChanged())
            {
                printError("No changes have been made.");
                return false;
            }
            if (makeBox.Text.Equals(""))
            {
                printError("An item make is required.");
                return false;
            }
            if (newCategoryBox.Visibility==Visibility.Visible && (newCategoryBox.Text.Equals("") || newCategoryBox.Text.Equals("New Category")))
            {
                printError("An item category is required.");
                return false;
            }
            fixNumberBoxes();
            return true;
        }

        private void printError(string content)
        {
            errorLabel.Foreground = Brushes.Red;
            errorLabel.Content = content;
        }
        
        private void printMessage(string content)
        {
            errorLabel.Foreground = Brushes.Black;
            errorLabel.Content = content;
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {    

            int reselectItemId = -1;
            if (saveChecks())
            {
                saveItem();
                InventoryItem reselectItem = inventoryListView.SelectedItem as InventoryItem;
                reselectItemId = reselectItem.Item_id;
                Refresh();                
                selectItem(reselectItemId);
                printMessage("Item successfully saved.");
                if (selectedItem.ItemThreshold > selectedItem.ItemCount && selectedItem.ItemThreshold != 0)
                {
                    emailAlert();
                }
            }         
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedItem != null)
            {
                deleteItem();
            }

        }

        private void countIncreaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (errorLabel != null) errorLabel.Content = "";

            if (selectedItem != null)
            {
                fixNumberBoxes();
                countTextBox.Text = ((System.Convert.ToInt32(countTextBox.Text)) + 1).ToString();
            }
        }

        private void countDecreaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (errorLabel != null) errorLabel.Content = "";

            if (selectedItem != null)
            {
                fixNumberBoxes();
                countTextBox.Text = ((System.Convert.ToInt32(countTextBox.Text)) - 1).ToString();
            }
        }

        private void thresholdIncreaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (errorLabel != null) errorLabel.Content = "";

            if (selectedItem != null)
            {
                fixNumberBoxes();
                thresholdBox.Text = ((System.Convert.ToInt32(thresholdBox.Text)) + 1).ToString();
            }
        }

        private void thresholdDecreaseBtn_Click(object sender, RoutedEventArgs e)
        {
            if (errorLabel != null) errorLabel.Content = "";

            if (selectedItem != null)
            {
                fixNumberBoxes();
                thresholdBox.Text = ((System.Convert.ToInt32(thresholdBox.Text)) - 1).ToString();
            }
        }

            #endregion

        private void Page_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F5)
            {
                Refresh();
            }
        }

        private void itemCategoryBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                deleteCategory();
            }
            else if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                editing_KeyDown(sender, e);
            }
        }

        private void editing_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                int reselectItemId = -1;
                if (saveChecks())
                {
                    saveItem();
                    InventoryItem reselectItem = inventoryListView.SelectedItem as InventoryItem;
                    reselectItemId = reselectItem.Item_id;
                    Refresh();
                    selectItem(reselectItemId);
                    printMessage("Item successfully saved.");
                    if (selectedItem.ItemThreshold > selectedItem.ItemCount && selectedItem.ItemThreshold != 0)
                    {
                        emailAlert();
                    }
                }
            }
        }

        private void inventoryListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                if (selectedItem != null)
                {
                    deleteItem();
                }
            }
        }

        #endregion        


        private void editing_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (errorLabel != null) errorLabel.Content = "";
        }




    }
}
