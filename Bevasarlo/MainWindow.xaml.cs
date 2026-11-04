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

namespace Bevasarlo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<string> shoppingList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            EnterKeyDownHandler();
        }

        private void AddItemButton_Click(object sender, RoutedEventArgs e)
        {
            string item = ItemTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(item))
            {
                shoppingList.Add(item);
                UpdateShoppingList();
                ItemTextBox.Clear();
                UpdateItemCount();
            }
            else
            {
                MessageBox.Show("Kérlek, adj meg egy tételt a bevásárlólistához.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            if (ShoppingListBox.SelectedItem != null)
            {
                shoppingList.Remove(ShoppingListBox.SelectedItem.ToString());
                UpdateShoppingList();
                UpdateItemCount();
            }
            else
            {
                MessageBox.Show("Kérlek, válassz ki egy tételt a törléshez.", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void RemoveAllButton_Click(object sender, RoutedEventArgs e)
        {
            shoppingList.Clear();
            UpdateShoppingList();
            UpdateItemCount();
        }

        private void UpdateShoppingList()
        {
            ShoppingListBox.ItemsSource = null;
            ShoppingListBox.ItemsSource = shoppingList;
        }

        private void UpdateItemCount()
        {
            ItemCountLabel.Content = $"Összesen: {shoppingList.Count} tétel";
        }

        private void EnterKeyDownHandler()
        {
            ItemTextBox.KeyDown += (sender, e) =>
            {
                if (e.Key == Key.Enter)
                {
                    AddItemButton_Click(sender, e);
                }
            };
        }
    }
}