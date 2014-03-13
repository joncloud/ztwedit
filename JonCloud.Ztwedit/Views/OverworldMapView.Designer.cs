namespace JonCloud.Ztwedit.Views
{
    partial class OverworldMapView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelMap = new System.Windows.Forms.Panel();
            this.pictureBoxMap = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanelTiles = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.panelMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMap
            // 
            this.panelMap.AutoScroll = true;
            this.panelMap.Controls.Add(this.pictureBoxMap);
            this.panelMap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMap.Location = new System.Drawing.Point(64, 0);
            this.panelMap.Margin = new System.Windows.Forms.Padding(0);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(236, 150);
            this.panelMap.TabIndex = 2;
            // 
            // pictureBoxMap
            // 
            this.pictureBoxMap.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxMap.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxMap.MaximumSize = new System.Drawing.Size(1024, 1024);
            this.pictureBoxMap.MinimumSize = new System.Drawing.Size(1024, 0);
            this.pictureBoxMap.Name = "pictureBoxMap";
            this.pictureBoxMap.Size = new System.Drawing.Size(1024, 100);
            this.pictureBoxMap.TabIndex = 0;
            this.pictureBoxMap.TabStop = false;
            this.pictureBoxMap.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseDown);
            this.pictureBoxMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseMove);
            this.pictureBoxMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMap_MouseUp);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.flowLayoutPanelTiles, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.pictureBoxLeft, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.pictureBoxRight, 1, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(64, 150);
            this.tableLayoutPanel.TabIndex = 3;
            // 
            // flowLayoutPanelTiles
            // 
            this.tableLayoutPanel.SetColumnSpan(this.flowLayoutPanelTiles, 2);
            this.flowLayoutPanelTiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelTiles.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelTiles.Location = new System.Drawing.Point(0, 32);
            this.flowLayoutPanelTiles.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelTiles.Name = "flowLayoutPanelTiles";
            this.flowLayoutPanelTiles.Size = new System.Drawing.Size(64, 118);
            this.flowLayoutPanelTiles.TabIndex = 2;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxLeft.TabIndex = 0;
            this.pictureBoxLeft.TabStop = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxRight.Location = new System.Drawing.Point(32, 0);
            this.pictureBoxRight.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(32, 32);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxRight.TabIndex = 1;
            this.pictureBoxRight.TabStop = false;
            // 
            // OverworldMapView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "OverworldMapView";
            this.Size = new System.Drawing.Size(300, 150);
            this.panelMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMap)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMap;
        private System.Windows.Forms.PictureBox pictureBoxMap;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelTiles;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxRight;

    }
}
