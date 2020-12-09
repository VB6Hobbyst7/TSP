namespace WindowsTSP
{
    partial class EdgeClassificationForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpBoxHulls = new System.Windows.Forms.GroupBox();
            this.cmbBoxHulls1 = new System.Windows.Forms.ComboBox();
            this.btnHullColor2 = new System.Windows.Forms.Button();
            this.btnHullColor1 = new System.Windows.Forms.Button();
            this.cmbBoxHulls2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkBoxHullsSpanTree = new System.Windows.Forms.CheckBox();
            this.lblEdgeNodeRatio = new System.Windows.Forms.Label();
            this.lblEdgeNode = new System.Windows.Forms.Label();
            this.btnPenColor = new System.Windows.Forms.Button();
            this.btnCanvasColor = new System.Windows.Forms.Button();
            this.chkBoxAxis = new System.Windows.Forms.CheckBox();
            this.lblEdgeTotalRatio = new System.Windows.Forms.Label();
            this.lblEdgeTotal = new System.Windows.Forms.Label();
            this.lblEdgesPerNode = new System.Windows.Forms.Label();
            this.lblEdgesNode = new System.Windows.Forms.Label();
            this.lblNumEdges = new System.Windows.Forms.Label();
            this.lblEdges = new System.Windows.Forms.Label();
            this.chkBoxCentroid = new System.Windows.Forms.CheckBox();
            this.lblPointSize = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpBoxHulls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Black;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(688, 561);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.grpBoxHulls);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkBoxHullsSpanTree);
            this.groupBox1.Controls.Add(this.lblEdgeNodeRatio);
            this.groupBox1.Controls.Add(this.lblEdgeNode);
            this.groupBox1.Controls.Add(this.btnPenColor);
            this.groupBox1.Controls.Add(this.btnCanvasColor);
            this.groupBox1.Controls.Add(this.chkBoxAxis);
            this.groupBox1.Controls.Add(this.lblEdgeTotalRatio);
            this.groupBox1.Controls.Add(this.lblEdgeTotal);
            this.groupBox1.Controls.Add(this.lblEdgesPerNode);
            this.groupBox1.Controls.Add(this.lblEdgesNode);
            this.groupBox1.Controls.Add(this.lblNumEdges);
            this.groupBox1.Controls.Add(this.lblEdges);
            this.groupBox1.Controls.Add(this.chkBoxCentroid);
            this.groupBox1.Controls.Add(this.lblPointSize);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(706, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(164, 561);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "******";
            // 
            // grpBoxHulls
            // 
            this.grpBoxHulls.Controls.Add(this.cmbBoxHulls1);
            this.grpBoxHulls.Controls.Add(this.btnHullColor2);
            this.grpBoxHulls.Controls.Add(this.btnHullColor1);
            this.grpBoxHulls.Controls.Add(this.cmbBoxHulls2);
            this.grpBoxHulls.Location = new System.Drawing.Point(6, 281);
            this.grpBoxHulls.Name = "grpBoxHulls";
            this.grpBoxHulls.Size = new System.Drawing.Size(149, 170);
            this.grpBoxHulls.TabIndex = 15;
            this.grpBoxHulls.TabStop = false;
            this.grpBoxHulls.Text = "Hulls";
            this.grpBoxHulls.Visible = false;
            // 
            // cmbBoxHulls1
            // 
            this.cmbBoxHulls1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxHulls1.FormattingEnabled = true;
            this.cmbBoxHulls1.Location = new System.Drawing.Point(44, 26);
            this.cmbBoxHulls1.Name = "cmbBoxHulls1";
            this.cmbBoxHulls1.Size = new System.Drawing.Size(99, 28);
            this.cmbBoxHulls1.TabIndex = 16;
            this.cmbBoxHulls1.Visible = false;
            this.cmbBoxHulls1.SelectedIndexChanged += new System.EventHandler(this.CmbBoxHulls1_SelectedIndexChanged);
            // 
            // btnHullColor2
            // 
            this.btnHullColor2.Location = new System.Drawing.Point(44, 129);
            this.btnHullColor2.Name = "btnHullColor2";
            this.btnHullColor2.Size = new System.Drawing.Size(99, 29);
            this.btnHullColor2.TabIndex = 19;
            this.btnHullColor2.Text = "Color";
            this.btnHullColor2.UseVisualStyleBackColor = true;
            this.btnHullColor2.Click += new System.EventHandler(this.BtnHullColor2_Click);
            // 
            // btnHullColor1
            // 
            this.btnHullColor1.Location = new System.Drawing.Point(44, 60);
            this.btnHullColor1.Name = "btnHullColor1";
            this.btnHullColor1.Size = new System.Drawing.Size(99, 29);
            this.btnHullColor1.TabIndex = 17;
            this.btnHullColor1.Text = "Color";
            this.btnHullColor1.UseVisualStyleBackColor = true;
            this.btnHullColor1.Visible = false;
            this.btnHullColor1.Click += new System.EventHandler(this.BtnHullColor1_Click);
            // 
            // cmbBoxHulls2
            // 
            this.cmbBoxHulls2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBoxHulls2.FormattingEnabled = true;
            this.cmbBoxHulls2.Location = new System.Drawing.Point(44, 95);
            this.cmbBoxHulls2.Name = "cmbBoxHulls2";
            this.cmbBoxHulls2.Size = new System.Drawing.Size(99, 28);
            this.cmbBoxHulls2.TabIndex = 18;
            this.cmbBoxHulls2.SelectedIndexChanged += new System.EventHandler(this.CmbBoxHulls2_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 528);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "label1";
            // 
            // chkBoxHullsSpanTree
            // 
            this.chkBoxHullsSpanTree.AutoSize = true;
            this.chkBoxHullsSpanTree.Location = new System.Drawing.Point(6, 251);
            this.chkBoxHullsSpanTree.Name = "chkBoxHullsSpanTree";
            this.chkBoxHullsSpanTree.Size = new System.Drawing.Size(79, 24);
            this.chkBoxHullsSpanTree.TabIndex = 14;
            this.chkBoxHullsSpanTree.Text = "--------";
            this.chkBoxHullsSpanTree.UseVisualStyleBackColor = true;
            this.chkBoxHullsSpanTree.Visible = false;
            this.chkBoxHullsSpanTree.CheckedChanged += new System.EventHandler(this.ChkBoxHullsSpanTree_CheckedChanged);
            // 
            // lblEdgeNodeRatio
            // 
            this.lblEdgeNodeRatio.AutoSize = true;
            this.lblEdgeNodeRatio.Location = new System.Drawing.Point(98, 228);
            this.lblEdgeNodeRatio.Name = "lblEdgeNodeRatio";
            this.lblEdgeNodeRatio.Size = new System.Drawing.Size(57, 20);
            this.lblEdgeNodeRatio.TabIndex = 13;
            this.lblEdgeNodeRatio.Text = "--------";
            // 
            // lblEdgeNode
            // 
            this.lblEdgeNode.AutoSize = true;
            this.lblEdgeNode.Location = new System.Drawing.Point(6, 228);
            this.lblEdgeNode.Name = "lblEdgeNode";
            this.lblEdgeNode.Size = new System.Drawing.Size(86, 20);
            this.lblEdgeNode.TabIndex = 12;
            this.lblEdgeNode.Text = "Edge-Node";
            // 
            // btnPenColor
            // 
            this.btnPenColor.Location = new System.Drawing.Point(6, 98);
            this.btnPenColor.Name = "btnPenColor";
            this.btnPenColor.Size = new System.Drawing.Size(152, 29);
            this.btnPenColor.TabIndex = 3;
            this.btnPenColor.Text = "Pen Color";
            this.btnPenColor.UseVisualStyleBackColor = true;
            this.btnPenColor.Click += new System.EventHandler(this.BtnPenColor_Click);
            // 
            // btnCanvasColor
            // 
            this.btnCanvasColor.Location = new System.Drawing.Point(6, 63);
            this.btnCanvasColor.Name = "btnCanvasColor";
            this.btnCanvasColor.Size = new System.Drawing.Size(152, 29);
            this.btnCanvasColor.TabIndex = 2;
            this.btnCanvasColor.Text = "Canvas Color";
            this.btnCanvasColor.UseVisualStyleBackColor = true;
            this.btnCanvasColor.Click += new System.EventHandler(this.BtnCanvasColor_Click);
            // 
            // chkBoxAxis
            // 
            this.chkBoxAxis.AutoSize = true;
            this.chkBoxAxis.Location = new System.Drawing.Point(100, 133);
            this.chkBoxAxis.Name = "chkBoxAxis";
            this.chkBoxAxis.Size = new System.Drawing.Size(58, 24);
            this.chkBoxAxis.TabIndex = 5;
            this.chkBoxAxis.Text = "Axis";
            this.chkBoxAxis.UseVisualStyleBackColor = true;
            this.chkBoxAxis.CheckedChanged += new System.EventHandler(this.ChkBoxAxis_CheckedChanged);
            // 
            // lblEdgeTotalRatio
            // 
            this.lblEdgeTotalRatio.AutoSize = true;
            this.lblEdgeTotalRatio.Location = new System.Drawing.Point(98, 208);
            this.lblEdgeTotalRatio.Name = "lblEdgeTotalRatio";
            this.lblEdgeTotalRatio.Size = new System.Drawing.Size(57, 20);
            this.lblEdgeTotalRatio.TabIndex = 11;
            this.lblEdgeTotalRatio.Text = "--------";
            // 
            // lblEdgeTotal
            // 
            this.lblEdgeTotal.AutoSize = true;
            this.lblEdgeTotal.Location = new System.Drawing.Point(6, 208);
            this.lblEdgeTotal.Name = "lblEdgeTotal";
            this.lblEdgeTotal.Size = new System.Drawing.Size(89, 20);
            this.lblEdgeTotal.TabIndex = 10;
            this.lblEdgeTotal.Text = "Edges/Total";
            // 
            // lblEdgesPerNode
            // 
            this.lblEdgesPerNode.AutoSize = true;
            this.lblEdgesPerNode.Location = new System.Drawing.Point(98, 188);
            this.lblEdgesPerNode.Name = "lblEdgesPerNode";
            this.lblEdgesPerNode.Size = new System.Drawing.Size(57, 20);
            this.lblEdgesPerNode.TabIndex = 9;
            this.lblEdgesPerNode.Text = "--------";
            // 
            // lblEdgesNode
            // 
            this.lblEdgesNode.AutoSize = true;
            this.lblEdgesNode.Location = new System.Drawing.Point(6, 188);
            this.lblEdgesNode.Name = "lblEdgesNode";
            this.lblEdgesNode.Size = new System.Drawing.Size(92, 20);
            this.lblEdgesNode.TabIndex = 8;
            this.lblEdgesNode.Text = "Edges/Node";
            // 
            // lblNumEdges
            // 
            this.lblNumEdges.AutoSize = true;
            this.lblNumEdges.Location = new System.Drawing.Point(98, 168);
            this.lblNumEdges.Name = "lblNumEdges";
            this.lblNumEdges.Size = new System.Drawing.Size(57, 20);
            this.lblNumEdges.TabIndex = 7;
            this.lblNumEdges.Text = "--------";
            // 
            // lblEdges
            // 
            this.lblEdges.AutoSize = true;
            this.lblEdges.Location = new System.Drawing.Point(6, 168);
            this.lblEdges.Name = "lblEdges";
            this.lblEdges.Size = new System.Drawing.Size(49, 20);
            this.lblEdges.TabIndex = 6;
            this.lblEdges.Text = "Edges";
            // 
            // chkBoxCentroid
            // 
            this.chkBoxCentroid.AutoSize = true;
            this.chkBoxCentroid.Location = new System.Drawing.Point(6, 133);
            this.chkBoxCentroid.Name = "chkBoxCentroid";
            this.chkBoxCentroid.Size = new System.Drawing.Size(88, 24);
            this.chkBoxCentroid.TabIndex = 4;
            this.chkBoxCentroid.Text = "Centroid";
            this.chkBoxCentroid.UseVisualStyleBackColor = true;
            this.chkBoxCentroid.CheckedChanged += new System.EventHandler(this.ChkBoxCentroid_CheckedChanged);
            // 
            // lblPointSize
            // 
            this.lblPointSize.AutoSize = true;
            this.lblPointSize.Location = new System.Drawing.Point(6, 32);
            this.lblPointSize.Name = "lblPointSize";
            this.lblPointSize.Size = new System.Drawing.Size(72, 20);
            this.lblPointSize.TabIndex = 0;
            this.lblPointSize.Text = "Point size";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(84, 30);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(66, 27);
            this.numericUpDown1.TabIndex = 1;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.NumericUpDown1_ValueChanged);
            // 
            // EdgeClassificationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 585);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EdgeClassificationForm";
            this.Text = "EdgeClassificationForm";
            this.Load += new System.EventHandler(this.EdgeClassificationForm_Load);
            this.ResizeEnd += new System.EventHandler(this.EdgeClassificationForm_ResizeEnd);
            this.SizeChanged += new System.EventHandler(this.EdgeClassificationForm_StateChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpBoxHulls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPointSize;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.CheckBox chkBoxCentroid;
        private System.Windows.Forms.Label lblEdges;
        private System.Windows.Forms.Label lblNumEdges;
        private System.Windows.Forms.Label lblEdgesPerNode;
        private System.Windows.Forms.Label lblEdgesNode;
        private System.Windows.Forms.Label lblEdgeTotalRatio;
        private System.Windows.Forms.Label lblEdgeTotal;
        private System.Windows.Forms.CheckBox chkBoxAxis;
        private System.Windows.Forms.Button btnCanvasColor;
        private System.Windows.Forms.ComboBox cmbBoxHulls1;
        private System.Windows.Forms.Button btnPenColor;
        private System.Windows.Forms.Label lblEdgeNode;
        private System.Windows.Forms.Button btnHullColor1;
        private System.Windows.Forms.Label lblEdgeNodeRatio;
        private System.Windows.Forms.CheckBox chkBoxHullsSpanTree;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBoxHulls;
        private System.Windows.Forms.Button btnHullColor2;
        private System.Windows.Forms.ComboBox cmbBoxHulls2;
    }
}