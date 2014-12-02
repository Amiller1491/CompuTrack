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

namespace CompuTrackWPF
{
    /// <summary>
    /// Interaction logic for DeleteCategoryWindow.xaml
    /// </summary>
    public partial class DeleteCategoryWindow : Window
    {
        ItemCategory selectedCategory;
        string selectedCategoryName;

        public DeleteCategoryWindow(ItemCategory selected)
        {
            this.selectedCategory = selected;
            this.selectedCategoryName = selected.CategoryString;
            InitializeComponent();
            drawText();
        }

        private void drawText()
        {
            confirmText.Text = "Are you sure you want to delete the \"" + selectedCategoryName+ "\" item category?";
        }

        private void deleteCategory()
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
                SqlCommand deleteCategory = new SqlCommand("DELETE FROM ItemTypes WHERE ItemType = @ItemType", Shared.ramdbConnection);
                deleteCategory.Parameters.AddWithValue("@ItemType", selectedCategoryName);
                deleteCategory.ExecuteNonQuery();
                Shared.ramdbConnection.Close();                
            }

            deleteCategoryLog();
            Close();           
        }

        private void deleteCategoryLog()
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
                string entry = "Deleted item category:\n    \u2022 Category: " + selectedCategoryName;
                string reason = "Removed item category";

                updateLogCmd.Parameters.AddWithValue("@Entry", entry);
                updateLogCmd.Parameters.AddWithValue("@Reason", reason);
                updateLogCmd.Parameters.AddWithValue("@MadeBy", Shared.currentUser._userName);

                updateLogCmd.ExecuteNonQuery();

                Shared.ramdbConnection.Close();
            }
        }

        private void noButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deleteCategoryWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape) Close();
            if (e.Key == Key.Enter || e.Key == Key.Return) deleteCategory();
        }

        private void yesButton_Click(object sender, RoutedEventArgs e)
        {
            deleteCategory();
        }
    }
}
