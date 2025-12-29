namespace BreakpointConflictTracker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel1 = new TableLayoutPanel();
            modNameLabel = new Label();
            modNameTextBox = new TextBox();
            categoryLabel = new Label();
            categoryComboBox = new ComboBox();
            vanillaItemLabel = new Label();
            vanillaItemComboBox = new ComboBox();
            descriptionLabel = new Label();
            descriptionTextBox = new TextBox();
            addButton = new Button();
            listBox = new ListBox();
            removeButton = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            exportConflictListToolStripMenuItem = new ToolStripMenuItem();
            importConflictListToolStripMenuItem = new ToolStripMenuItem();
            tableLayoutPanel1.SuspendLayout();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));
            tableLayoutPanel1.Controls.Add(modNameLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(modNameTextBox, 1, 0);
            tableLayoutPanel1.Controls.Add(categoryLabel, 0, 1);
            tableLayoutPanel1.Controls.Add(categoryComboBox, 1, 1);
            tableLayoutPanel1.Controls.Add(vanillaItemLabel, 0, 2);
            tableLayoutPanel1.Controls.Add(vanillaItemComboBox, 1, 2);
            tableLayoutPanel1.Controls.Add(descriptionLabel, 0, 3);
            tableLayoutPanel1.Controls.Add(descriptionTextBox, 1, 3);
            tableLayoutPanel1.Controls.Add(addButton, 0, 4);
            tableLayoutPanel1.Controls.Add(listBox, 0, 5);
            tableLayoutPanel1.Controls.Add(removeButton, 1, 4);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(778, 544);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // modNameLabel
            // 
            modNameLabel.Anchor = AnchorStyles.Right;
            modNameLabel.AutoSize = true;
            modNameLabel.Location = new Point(124, 2);
            modNameLabel.Name = "modNameLabel";
            modNameLabel.Size = new Size(106, 25);
            modNameLabel.TabIndex = 0;
            modNameLabel.Text = "Mod Name:";
            // 
            // modNameTextBox
            // 
            modNameTextBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            modNameTextBox.Location = new Point(236, 3);
            modNameTextBox.Name = "modNameTextBox";
            modNameTextBox.Size = new Size(539, 31);
            modNameTextBox.TabIndex = 1;
            // 
            // categoryLabel
            // 
            categoryLabel.Anchor = AnchorStyles.Right;
            categoryLabel.AutoSize = true;
            categoryLabel.Location = new Point(142, 32);
            categoryLabel.Name = "categoryLabel";
            categoryLabel.Size = new Size(88, 25);
            categoryLabel.TabIndex = 2;
            categoryLabel.Text = "Category:";
            // 
            // categoryComboBox
            // 
            categoryComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            categoryComboBox.FormattingEnabled = true;
            categoryComboBox.Location = new Point(236, 33);
            categoryComboBox.Name = "categoryComboBox";
            categoryComboBox.Size = new Size(539, 33);
            categoryComboBox.TabIndex = 3;
            categoryComboBox.SelectedIndexChanged += CategoryComboBox_SelectedIndexChanged;
            // 
            // vanillaItemLabel
            // 
            vanillaItemLabel.Anchor = AnchorStyles.Right;
            vanillaItemLabel.AutoSize = true;
            vanillaItemLabel.Location = new Point(123, 62);
            vanillaItemLabel.Name = "vanillaItemLabel";
            vanillaItemLabel.Size = new Size(107, 25);
            vanillaItemLabel.TabIndex = 4;
            vanillaItemLabel.Text = "Vanilla Item:";
            // 
            // vanillaItemComboBox
            // 
            vanillaItemComboBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            vanillaItemComboBox.DrawMode = DrawMode.OwnerDrawFixed;
            vanillaItemComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            vanillaItemComboBox.FormattingEnabled = true;
            vanillaItemComboBox.Location = new Point(236, 63);
            vanillaItemComboBox.Name = "vanillaItemComboBox";
            vanillaItemComboBox.Size = new Size(539, 32);
            vanillaItemComboBox.TabIndex = 5;
            vanillaItemComboBox.DrawItem += VanillaItemComboBox_DrawItem;
            // 
            // descriptionLabel
            // 
            descriptionLabel.Anchor = AnchorStyles.Right;
            descriptionLabel.AutoSize = true;
            descriptionLabel.Location = new Point(43, 107);
            descriptionLabel.Name = "descriptionLabel";
            descriptionLabel.Size = new Size(187, 25);
            descriptionLabel.TabIndex = 6;
            descriptionLabel.Text = "Description (optional):";
            // 
            // descriptionTextBox
            // 
            descriptionTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            descriptionTextBox.Location = new Point(236, 93);
            descriptionTextBox.Multiline = true;
            descriptionTextBox.Name = "descriptionTextBox";
            descriptionTextBox.Size = new Size(539, 54);
            descriptionTextBox.TabIndex = 7;
            // 
            // addButton
            // 
            addButton.Anchor = AnchorStyles.Left;
            addButton.Location = new Point(3, 161);
            addButton.Name = "addButton";
            addButton.Size = new Size(112, 38);
            addButton.TabIndex = 8;
            addButton.Text = "Add to List";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += AddButton_Click;
            // 
            // listBox
            // 
            listBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(listBox, 2);
            listBox.FormattingEnabled = true;
            listBox.Location = new Point(3, 213);
            listBox.Name = "listBox";
            listBox.Size = new Size(772, 304);
            listBox.TabIndex = 9;
            // 
            // removeButton
            // 
            removeButton.Anchor = AnchorStyles.Left;
            removeButton.Location = new Point(236, 160);
            removeButton.Name = "removeButton";
            removeButton.Size = new Size(176, 39);
            removeButton.TabIndex = 10;
            removeButton.Text = "Remove from List";
            removeButton.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(24, 24);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { exportConflictListToolStripMenuItem, importConflictListToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(236, 68);
            // 
            // exportConflictListToolStripMenuItem
            // 
            exportConflictListToolStripMenuItem.Name = "exportConflictListToolStripMenuItem";
            exportConflictListToolStripMenuItem.Size = new Size(235, 32);
            exportConflictListToolStripMenuItem.Text = "Export Conflict List";
            exportConflictListToolStripMenuItem.Click += ExportMenuItem_Click;
            // 
            // importConflictListToolStripMenuItem
            // 
            importConflictListToolStripMenuItem.Name = "importConflictListToolStripMenuItem";
            importConflictListToolStripMenuItem.Size = new Size(235, 32);
            importConflictListToolStripMenuItem.Text = "Import Conflict List";
            importConflictListToolStripMenuItem.Click += ImportMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(778, 544);
            Controls.Add(tableLayoutPanel1);
            Name = "MainForm";
            Text = "Breakpoint Conflict Tracker";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label modNameLabel;
        private TextBox modNameTextBox;
        private Label categoryLabel;
        private ComboBox categoryComboBox;
        private Label vanillaItemLabel;
        private ComboBox vanillaItemComboBox;
        private Label descriptionLabel;
        private TextBox descriptionTextBox;
        private Button addButton;
        private ListBox listBox;
        private Button removeButton;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem exportConflictListToolStripMenuItem;
        private ToolStripMenuItem importConflictListToolStripMenuItem;
    }
}