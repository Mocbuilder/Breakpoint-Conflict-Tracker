using BreakpointConflictTracker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BreakpointConflictTracker
{
    public partial class MainForm : Form
    {
        private XMLHelper xmlHelper;

        public MainForm()
        {
            InitializeComponent();
            xmlHelper = new XMLHelper("items.xml");

            LoadData();
            LoadUI();
        }

        public void LoadUI()
        {
            listBox.ContextMenuStrip = new ContextMenuStrip();
            listBox.ContextMenuStrip.Items.Add("Remove").Click += RemoveMenuItem_Click;

            //Trigger this so that the vanilla items are in their combobox on startup, otherwise it's empty until a category is changed
            UpdateVanillaItemsComboBox(ItemType.Camo);
        }

        private void LoadData()
        {
            xmlHelper.LoadItems();
        }

        private void UpdateVanillaItemsComboBox(ItemType selectedCategory)
        {
            vanillaItemComboBox.DataSource = null;
            vanillaItemComboBox.DisplayMember = "Name";
            vanillaItemComboBox.DataSource = xmlHelper._itemsCache.Where(item => item.Type == selectedCategory).ToList();
        }

        private void CategoryComboBox_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (categoryComboBox.SelectedItem is not ItemType itemType)
            {
                MessageBox.Show("Invalid category selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UpdateVanillaItemsComboBox(itemType);
        }

        private bool IsItemAlreadyAdded(string vanillaItem)
        {
            // Check if the vanilla item exists in the list box
            foreach (var item in listBox.Items)
            {
                string? itemText = item?.ToString();
                if (!string.IsNullOrEmpty(itemText) && itemText.Contains($": {vanillaItem}"))
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveConflictListToCSV(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                // Write CSV header
                writer.WriteLine("Mod Name,Category,Category Item,Description");

                foreach (var item in listBox.Items)
                {
                    string? itemText = item.ToString();
                    if (itemText is null)
                        throw new Exception("One of the items in the list box is null.");

                    //Moved this logic into its own method too. I didnt change it tho, if it aint broke dont fix it
                    ConflictItem conflictItem = ParseItemTextToConflictItem(itemText);

                    // Write CSV line
                    writer.WriteLine($"{conflictItem.ModName},{conflictItem.Category},{conflictItem.ItemName},{conflictItem.Description}");
                }
            }
            MessageBox.Show("Conflict list exported successfully!", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public ConflictItem ParseItemTextToConflictItem(string itemText)
        {
            // Parse the item text to extract mod name, category, and item
            string[] parts = itemText.Split(new[] { " -> " }, StringSplitOptions.None);
            string modName = parts.Length > 0 ? parts[0].Trim() : string.Empty;
            string categoryItemPart = parts.Length > 1 ? parts[1] : string.Empty;

            string[] categoryParts = categoryItemPart.Split(new[] { ": " }, StringSplitOptions.None);
            string category = categoryParts.Length > 0 ? categoryParts[0].Trim() : string.Empty;
            string itemName = categoryParts.Length > 1 ? categoryParts[1].Trim() : string.Empty;

            // Extract description if present
            string description = string.Empty;
            if (itemName.Contains("(") && itemName.Contains(")"))
            {
                string[] descParts = itemName.Split(new[] { "(" }, StringSplitOptions.None);
                itemName = descParts[0].Trim();
                description = descParts.Length > 1 ? descParts[1].Replace(")", "").Trim() : string.Empty;
            }

            return new ConflictItem
            {
                ModName = modName,
                Category = category,
                ItemName = itemName,
                Description = description
            };
        }

        private void VanillaItemComboBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            string? itemText = vanillaItemComboBox.Items[e.Index]?.ToString();
            if (string.IsNullOrEmpty(itemText)) return;

            // Check if this item has been added to the list
            bool isAdded = IsItemAlreadyAdded(itemText);

            // Set the background color
            e.DrawBackground();

            // Set the text color based on whether it's been added
            Brush textBrush = isAdded ? Brushes.Red : Brushes.Black;

            // Draw the text
            e.Graphics.DrawString(itemText, e.Font ?? SystemFonts.DefaultFont, textBrush, e.Bounds, StringFormat.GenericDefault);

            // Draw focus rectangle if needed
            e.DrawFocusRectangle();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            string modName = modNameTextBox.Text.Trim();
            string? category = categoryComboBox.SelectedItem?.ToString();
            string? vanillaItem = vanillaItemComboBox.SelectedItem?.ToString();
            string description = descriptionTextBox.Text.Trim();

            if (string.IsNullOrEmpty(modName) || string.IsNullOrEmpty(category) || string.IsNullOrEmpty(vanillaItem))
            {
                MessageBox.Show("Mod Name, Category, and Vanilla Item are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string itemText = $"{modName} -> {category}: {vanillaItem}";
            if (!string.IsNullOrEmpty(description))
            {
                itemText += $" ({description})";
            }

            listBox.Items.Add(itemText);

            modNameTextBox.Clear();
            descriptionTextBox.Clear();
        }

        private void RemoveMenuItem_Click(object? sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                listBox.Items.Remove(listBox.SelectedItem);
            }
        }

        private void ExportMenuItem_Click(object? sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*|CSV files (*.csv)|*.csv";
            saveFileDialog.Title = "Export Conflict List";
            saveFileDialog.DefaultExt = "csv";

            //Made this a guard clause to reduce nesting
            if (saveFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Export cancelled.", "Export Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                //Moved the actual saving logic into its own method for clarity
                SaveConflictListToCSV(saveFileDialog.FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting conflict list: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ImportMenuItem_Click(object? sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog.Title = "Import Conflict List";

            //Made this a guard clause to reduce nesting
            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                MessageBox.Show("Export cancelled.", "Export Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                listBox.Items.Clear();
                using (StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    string? line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        listBox.Items.Add(line);
                    }
                }
                MessageBox.Show("Conflict list imported successfully!", "Import Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error importing conflict list: {ex.Message}", "Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
