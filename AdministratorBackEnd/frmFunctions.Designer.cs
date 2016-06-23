namespace AdministratorBackEnd
{
    partial class frmFunctions
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
            this.btnLineAdd = new System.Windows.Forms.Button();
            this.btnLineView = new System.Windows.Forms.Button();
            this.btnLineDelete = new System.Windows.Forms.Button();
            this.tabs = new System.Windows.Forms.TabControl();
            this.tabLine = new System.Windows.Forms.TabPage();
            this.tabCities = new System.Windows.Forms.TabPage();
            this.tabOrder = new System.Windows.Forms.TabPage();
            this.btnCityAdd = new System.Windows.Forms.Button();
            this.btnLineModify = new System.Windows.Forms.Button();
            this.btnCityDelete = new System.Windows.Forms.Button();
            this.btnCityView = new System.Windows.Forms.Button();
            this.btnCityModify = new System.Windows.Forms.Button();
            this.btnOrderView = new System.Windows.Forms.Button();
            this.tabs.SuspendLayout();
            this.tabLine.SuspendLayout();
            this.tabCities.SuspendLayout();
            this.tabOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLineAdd
            // 
            this.btnLineAdd.Location = new System.Drawing.Point(6, 6);
            this.btnLineAdd.Name = "btnLineAdd";
            this.btnLineAdd.Size = new System.Drawing.Size(75, 23);
            this.btnLineAdd.TabIndex = 0;
            this.btnLineAdd.Text = "添加";
            this.btnLineAdd.UseVisualStyleBackColor = true;
            this.btnLineAdd.Click += new System.EventHandler(this.btnLineAdd_Click);
            // 
            // btnLineView
            // 
            this.btnLineView.Location = new System.Drawing.Point(168, 6);
            this.btnLineView.Name = "btnLineView";
            this.btnLineView.Size = new System.Drawing.Size(75, 23);
            this.btnLineView.TabIndex = 1;
            this.btnLineView.Text = "查看";
            this.btnLineView.UseVisualStyleBackColor = true;
            // 
            // btnLineDelete
            // 
            this.btnLineDelete.Location = new System.Drawing.Point(249, 6);
            this.btnLineDelete.Name = "btnLineDelete";
            this.btnLineDelete.Size = new System.Drawing.Size(75, 23);
            this.btnLineDelete.TabIndex = 2;
            this.btnLineDelete.Text = "删除";
            this.btnLineDelete.UseVisualStyleBackColor = true;
            // 
            // tabs
            // 
            this.tabs.Controls.Add(this.tabLine);
            this.tabs.Controls.Add(this.tabCities);
            this.tabs.Controls.Add(this.tabOrder);
            this.tabs.Location = new System.Drawing.Point(12, 12);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(342, 65);
            this.tabs.TabIndex = 3;
            // 
            // tabLine
            // 
            this.tabLine.Controls.Add(this.btnLineModify);
            this.tabLine.Controls.Add(this.btnLineAdd);
            this.tabLine.Controls.Add(this.btnLineDelete);
            this.tabLine.Controls.Add(this.btnLineView);
            this.tabLine.Location = new System.Drawing.Point(4, 26);
            this.tabLine.Name = "tabLine";
            this.tabLine.Padding = new System.Windows.Forms.Padding(3);
            this.tabLine.Size = new System.Drawing.Size(334, 35);
            this.tabLine.TabIndex = 0;
            this.tabLine.Text = "线路管理";
            this.tabLine.UseVisualStyleBackColor = true;
            // 
            // tabCities
            // 
            this.tabCities.Controls.Add(this.btnCityModify);
            this.tabCities.Controls.Add(this.btnCityView);
            this.tabCities.Controls.Add(this.btnCityDelete);
            this.tabCities.Controls.Add(this.btnCityAdd);
            this.tabCities.Location = new System.Drawing.Point(4, 26);
            this.tabCities.Name = "tabCities";
            this.tabCities.Padding = new System.Windows.Forms.Padding(3);
            this.tabCities.Size = new System.Drawing.Size(334, 35);
            this.tabCities.TabIndex = 1;
            this.tabCities.Text = "地点管理";
            this.tabCities.UseVisualStyleBackColor = true;
            // 
            // tabOrder
            // 
            this.tabOrder.Controls.Add(this.btnOrderView);
            this.tabOrder.Location = new System.Drawing.Point(4, 26);
            this.tabOrder.Name = "tabOrder";
            this.tabOrder.Size = new System.Drawing.Size(334, 35);
            this.tabOrder.TabIndex = 2;
            this.tabOrder.Text = "订单信息查看";
            this.tabOrder.UseVisualStyleBackColor = true;
            // 
            // btnCityAdd
            // 
            this.btnCityAdd.Location = new System.Drawing.Point(7, 7);
            this.btnCityAdd.Name = "btnCityAdd";
            this.btnCityAdd.Size = new System.Drawing.Size(75, 23);
            this.btnCityAdd.TabIndex = 0;
            this.btnCityAdd.Text = "添加";
            this.btnCityAdd.UseVisualStyleBackColor = true;
            // 
            // btnLineModify
            // 
            this.btnLineModify.Location = new System.Drawing.Point(87, 6);
            this.btnLineModify.Name = "btnLineModify";
            this.btnLineModify.Size = new System.Drawing.Size(75, 23);
            this.btnLineModify.TabIndex = 3;
            this.btnLineModify.Text = "修改";
            this.btnLineModify.UseVisualStyleBackColor = true;
            // 
            // btnCityDelete
            // 
            this.btnCityDelete.Location = new System.Drawing.Point(250, 7);
            this.btnCityDelete.Name = "btnCityDelete";
            this.btnCityDelete.Size = new System.Drawing.Size(75, 23);
            this.btnCityDelete.TabIndex = 2;
            this.btnCityDelete.Text = "删除";
            this.btnCityDelete.UseVisualStyleBackColor = true;
            // 
            // btnCityView
            // 
            this.btnCityView.Location = new System.Drawing.Point(169, 7);
            this.btnCityView.Name = "btnCityView";
            this.btnCityView.Size = new System.Drawing.Size(75, 23);
            this.btnCityView.TabIndex = 3;
            this.btnCityView.Text = "查看";
            this.btnCityView.UseVisualStyleBackColor = true;
            // 
            // btnCityModify
            // 
            this.btnCityModify.Location = new System.Drawing.Point(88, 7);
            this.btnCityModify.Name = "btnCityModify";
            this.btnCityModify.Size = new System.Drawing.Size(75, 23);
            this.btnCityModify.TabIndex = 4;
            this.btnCityModify.Text = "修改";
            this.btnCityModify.UseVisualStyleBackColor = true;
            // 
            // btnOrderView
            // 
            this.btnOrderView.Location = new System.Drawing.Point(3, 6);
            this.btnOrderView.Name = "btnOrderView";
            this.btnOrderView.Size = new System.Drawing.Size(324, 23);
            this.btnOrderView.TabIndex = 0;
            this.btnOrderView.Text = "查看";
            this.btnOrderView.UseVisualStyleBackColor = true;
            // 
            // frmFunctions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 88);
            this.Controls.Add(this.tabs);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmFunctions";
            this.Text = "功能选择";
            this.tabs.ResumeLayout(false);
            this.tabLine.ResumeLayout(false);
            this.tabCities.ResumeLayout(false);
            this.tabOrder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnLineAdd;
        private System.Windows.Forms.Button btnLineView;
        private System.Windows.Forms.Button btnLineDelete;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage tabLine;
        private System.Windows.Forms.TabPage tabCities;
        private System.Windows.Forms.TabPage tabOrder;
        private System.Windows.Forms.Button btnLineModify;
        private System.Windows.Forms.Button btnCityModify;
        private System.Windows.Forms.Button btnCityView;
        private System.Windows.Forms.Button btnCityDelete;
        private System.Windows.Forms.Button btnCityAdd;
        private System.Windows.Forms.Button btnOrderView;
    }
}