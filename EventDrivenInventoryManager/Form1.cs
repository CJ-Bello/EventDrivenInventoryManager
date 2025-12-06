using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EventDrivenInventoryManager
{
    public partial class Form1 : Form
    {
        public class Product
        {
            public string SKU { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public int Quantity { get; set; }
        }

        private readonly List<Product> _catalog = new();

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            WireEvents();
        }

        private void InitializeUI()
        {
            cmbCategory.Items.AddRange(new[] { "Food", "Beverage", "Household", "Stationery", "Misc" });
            cmbFilterCategory.Items.AddRange(new[] { "All", "Food", "Beverage", "Household", "Stationery", "Misc" });
            cmbFilterCategory.SelectedIndex = 0;

            nudQuantity.Minimum = 0;
            nudQuantity.Maximum = 100000;
            nudQuantity.Value = 0;

            txtSearch.PlaceholderText = "Search by SKU/Name...";

            lblStatus.Text = "Ready";
            lblTotalQty.Text = "Total Quantity: 0";

            btnAddProduct.Enabled = false;
            btnUpdateStock.Enabled = false;

            dgInventory.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgInventory.MultiSelect = true;
            dgInventory.ReadOnly = true;
            dgInventory.AutoGenerateColumns = false;
            dgInventory.Columns.Clear();
            dgInventory.Columns.Add("SKU", "SKU");
            dgInventory.Columns.Add("Name", "Name");
            dgInventory.Columns.Add("Category", "Category");
            dgInventory.Columns.Add("Quantity", "Quantity");
        }

        private void WireEvents()
        {
            btnAddProduct.Click += BtnAddProduct_Click;
            btnUpdateStock.Click += BtnUpdateStock_Click;
            btnRemoveSelected.Click += BtnRemoveSelected_Click;
            btnClearAll.Click += BtnClearAll_Click;
            btnApplyFilter.Click += BtnApplyFilter_Click;
            btnResetFilter.Click += BtnResetFilter_Click;
            dgInventory.SelectionChanged += DgInventory_SelectionChanged;

            txtSKU.TextChanged += InputChanged;
            txtName.TextChanged += InputChanged;
            cmbCategory.SelectedIndexChanged += InputChanged;
            nudQuantity.ValueChanged += InputChanged;
        }

        private void InputChanged(object? sender, EventArgs e)
        {
            bool validAdd =
                !string.IsNullOrWhiteSpace(txtSKU.Text) &&
                !string.IsNullOrWhiteSpace(txtName.Text) &&
                cmbCategory.SelectedIndex >= 0 &&
                nudQuantity.Value >= 0;

            btnAddProduct.Enabled = validAdd;
            btnUpdateStock.Enabled = !string.IsNullOrWhiteSpace(txtSKU.Text);
        }

        private void BtnAddProduct_Click(object? sender, EventArgs e)
        {
            if (_catalog.Any(p => p.SKU.Equals(txtSKU.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                lblStatus.Text = "Duplicate SKU not allowed.";
                MessageBox.Show("SKU already exists.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _catalog.Add(new Product
            {
                SKU = txtSKU.Text.Trim(),
                Name = txtName.Text.Trim(),
                Category = cmbCategory.Text,
                Quantity = (int)nudQuantity.Value
            });

            ClearInputs();
            RenderInventory(_catalog);
            UpdateTotals();
            lblStatus.Text = "Product added.";
        }

        private void BtnUpdateStock_Click(object? sender, EventArgs e)
        {
            var product = _catalog.FirstOrDefault(p => p.SKU.Equals(txtSKU.Text.Trim(), StringComparison.OrdinalIgnoreCase));

            if (product == null)
            {
                lblStatus.Text = "Product not found.";
                MessageBox.Show("No product found with that SKU.");
                return;
            }

            product.Quantity = (int)nudQuantity.Value;
            RenderInventory(_catalog);
            UpdateTotals();
            lblStatus.Text = "Stock updated.";
        }

        private void BtnRemoveSelected_Click(object? sender, EventArgs e)
        {
            if (dgInventory.SelectedRows.Count == 0)
            {
                lblStatus.Text = "No item selected.";
                return;
            }

            if (chkConfirmDelete.Checked)
            {
                var result = MessageBox.Show("Delete selected item(s)?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes) return;
            }

            foreach (DataGridViewRow row in dgInventory.SelectedRows)
            {
                string sku = row.Cells[0].Value.ToString();
                var item = _catalog.FirstOrDefault(p => p.SKU == sku);
                if (item != null)
                    _catalog.Remove(item);
            }

            RenderInventory(_catalog);
            UpdateTotals();
            lblStatus.Text = "Selected product(s) removed.";
        }

        private void BtnClearAll_Click(object? sender, EventArgs e)
        {
            if (_catalog.Count == 0) return;

            var result = MessageBox.Show("Clear all inventory?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result != DialogResult.Yes) return;

            _catalog.Clear();
            RenderInventory(_catalog);
            UpdateTotals();
            lblStatus.Text = "Inventory cleared.";
        }

        private void BtnApplyFilter_Click(object? sender, EventArgs e)
        {
            var query = _catalog.AsEnumerable();

            if (cmbFilterCategory.Text != "All")
                query = query.Where(p => p.Category == cmbFilterCategory.Text);

            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                query = query.Where(p =>
                    p.SKU.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase) ||
                    p.Name.Contains(txtSearch.Text, StringComparison.OrdinalIgnoreCase));
            }

            RenderInventory(query.ToList());
            lblStatus.Text = "Filter applied.";
        }

        private void BtnResetFilter_Click(object? sender, EventArgs e)
        {
            cmbFilterCategory.SelectedIndex = 0;
            txtSearch.Clear();
            RenderInventory(_catalog);
            lblStatus.Text = "Filter reset.";
        }

        private void DgInventory_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgInventory.SelectedRows.Count == 0) return;

            var row = dgInventory.SelectedRows[0];
            lblStatus.Text = $"{row.Cells[0].Value} | {row.Cells[1].Value} | {row.Cells[2].Value} | Qty: {row.Cells[3].Value}";
        }

        private void RenderInventory(List<Product> list)
        {
            dgInventory.Rows.Clear();
            foreach (var p in list)
                dgInventory.Rows.Add(p.SKU, p.Name, p.Category, p.Quantity);
        }

        private void UpdateTotals()
        {
            int total = _catalog.Sum(p => p.Quantity);
            lblTotalQty.Text = $"Total Quantity: {total}";
        }

        private void ClearInputs()
        {
            txtSKU.Clear();
            txtName.Clear();
            cmbCategory.SelectedIndex = -1;
            nudQuantity.Value = 0;
        }
    }
}
