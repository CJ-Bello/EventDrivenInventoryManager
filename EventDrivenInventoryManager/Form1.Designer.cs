namespace EventDrivenInventoryManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtSKU = new TextBox();
            txtName = new TextBox();
            cmbCategory = new ComboBox();
            nudQuantity = new NumericUpDown();
            btnAddProduct = new Button();
            btnUpdateStock = new Button();
            btnRemoveSelected = new Button();
            btnClearAll = new Button();
            chkConfirmDelete = new CheckBox();
            cmbFilterCategory = new ComboBox();
            txtSearch = new TextBox();
            btnApplyFilter = new Button();
            btnResetFilter = new Button();
            dgInventory = new DataGridView();
            lblTotalQty = new Label();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgInventory).BeginInit();
            SuspendLayout();
            // 
            // txtSKU
            // 
            txtSKU.Location = new Point(27, 37);
            txtSKU.Name = "txtSKU";
            txtSKU.Size = new Size(100, 23);
            txtSKU.TabIndex = 0;
            txtSKU.Text = "Unique Code";
            // 
            // txtName
            // 
            txtName.Location = new Point(133, 38);
            txtName.Name = "txtName";
            txtName.Size = new Size(186, 23);
            txtName.TabIndex = 1;
            txtName.Text = "Product Name";
            // 
            // cmbCategory
            // 
            cmbCategory.FormattingEnabled = true;
            cmbCategory.Location = new Point(325, 38);
            cmbCategory.Name = "cmbCategory";
            cmbCategory.Size = new Size(99, 23);
            cmbCategory.TabIndex = 2;
            cmbCategory.Text = "Category";
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(430, 40);
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(99, 23);
            nudQuantity.TabIndex = 3;
            // 
            // btnAddProduct
            // 
            btnAddProduct.Location = new Point(535, 37);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(99, 24);
            btnAddProduct.TabIndex = 4;
            btnAddProduct.Text = "Add Product";
            btnAddProduct.UseVisualStyleBackColor = true;
            // 
            // btnUpdateStock
            // 
            btnUpdateStock.Location = new Point(640, 38);
            btnUpdateStock.Name = "btnUpdateStock";
            btnUpdateStock.Size = new Size(99, 23);
            btnUpdateStock.TabIndex = 5;
            btnUpdateStock.Text = "Update Stock";
            btnUpdateStock.UseVisualStyleBackColor = true;
            // 
            // btnRemoveSelected
            // 
            btnRemoveSelected.Location = new Point(559, 151);
            btnRemoveSelected.Name = "btnRemoveSelected";
            btnRemoveSelected.Size = new Size(75, 23);
            btnRemoveSelected.TabIndex = 6;
            btnRemoveSelected.Text = "Remove";
            btnRemoveSelected.UseVisualStyleBackColor = true;
            // 
            // btnClearAll
            // 
            btnClearAll.Location = new Point(559, 180);
            btnClearAll.Name = "btnClearAll";
            btnClearAll.Size = new Size(75, 23);
            btnClearAll.TabIndex = 7;
            btnClearAll.Text = "Clear All";
            btnClearAll.UseVisualStyleBackColor = true;
            // 
            // chkConfirmDelete
            // 
            chkConfirmDelete.AutoSize = true;
            chkConfirmDelete.Location = new Point(640, 155);
            chkConfirmDelete.Name = "chkConfirmDelete";
            chkConfirmDelete.Size = new Size(106, 19);
            chkConfirmDelete.TabIndex = 8;
            chkConfirmDelete.Text = "Confirm Delete";
            chkConfirmDelete.UseVisualStyleBackColor = true;
            // 
            // cmbFilterCategory
            // 
            cmbFilterCategory.FormattingEnabled = true;
            cmbFilterCategory.Location = new Point(27, 101);
            cmbFilterCategory.Name = "cmbFilterCategory";
            cmbFilterCategory.Size = new Size(100, 23);
            cmbFilterCategory.TabIndex = 9;
            cmbFilterCategory.Text = "Filter";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(133, 101);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(186, 23);
            txtSearch.TabIndex = 10;
            txtSearch.Text = "Search";
            // 
            // btnApplyFilter
            // 
            btnApplyFilter.Location = new Point(349, 101);
            btnApplyFilter.Name = "btnApplyFilter";
            btnApplyFilter.Size = new Size(75, 23);
            btnApplyFilter.TabIndex = 11;
            btnApplyFilter.Text = "Apply Filter";
            btnApplyFilter.UseVisualStyleBackColor = true;
            // 
            // btnResetFilter
            // 
            btnResetFilter.Location = new Point(430, 101);
            btnResetFilter.Name = "btnResetFilter";
            btnResetFilter.Size = new Size(75, 23);
            btnResetFilter.TabIndex = 12;
            btnResetFilter.Text = "Reset Filter";
            btnResetFilter.UseVisualStyleBackColor = true;
            // 
            // dgInventory
            // 
            dgInventory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgInventory.Location = new Point(27, 151);
            dgInventory.Name = "dgInventory";
            dgInventory.Size = new Size(498, 248);
            dgInventory.TabIndex = 13;
            // 
            // lblTotalQty
            // 
            lblTotalQty.AutoSize = true;
            lblTotalQty.Location = new Point(559, 218);
            lblTotalQty.Name = "lblTotalQty";
            lblTotalQty.Size = new Size(84, 15);
            lblTotalQty.TabIndex = 14;
            lblTotalQty.Text = "Total Quantity:";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(559, 243);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 15;
            lblStatus.Text = "Status";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lblStatus);
            Controls.Add(lblTotalQty);
            Controls.Add(dgInventory);
            Controls.Add(btnResetFilter);
            Controls.Add(btnApplyFilter);
            Controls.Add(txtSearch);
            Controls.Add(cmbFilterCategory);
            Controls.Add(chkConfirmDelete);
            Controls.Add(btnClearAll);
            Controls.Add(btnRemoveSelected);
            Controls.Add(btnUpdateStock);
            Controls.Add(btnAddProduct);
            Controls.Add(nudQuantity);
            Controls.Add(cmbCategory);
            Controls.Add(txtName);
            Controls.Add(txtSKU);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgInventory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtSKU;
        private TextBox txtName;
        private ComboBox cmbCategory;
        private NumericUpDown nudQuantity;
        private Button btnAddProduct;
        private Button btnUpdateStock;
        private Button btnRemoveSelected;
        private Button btnClearAll;
        private CheckBox chkConfirmDelete;
        private ComboBox cmbFilterCategory;
        private TextBox txtSearch;
        private Button btnApplyFilter;
        private Button btnResetFilter;
        private DataGridView dgInventory;
        private Label lblTotalQty;
        private Label lblStatus;
    }
}
