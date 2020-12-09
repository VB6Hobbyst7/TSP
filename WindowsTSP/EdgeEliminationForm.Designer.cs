namespace WindowsTSP
{
    partial class EdgeEliminationForm
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
            this.chkBoxCrossSpanningTree = new System.Windows.Forms.CheckBox();
            this.rdBtnRemained = new System.Windows.Forms.RadioButton();
            this.rdBtnEliminated = new System.Windows.Forms.RadioButton();
            this.rdBtnAll = new System.Windows.Forms.RadioButton();
            this.chkBoxCrossOwnHull = new System.Windows.Forms.CheckBox();
            this.lblNumEdges = new System.Windows.Forms.Label();
            this.lblEdges = new System.Windows.Forms.Label();
            this.chkBoxCentroid = new System.Windows.Forms.CheckBox();
            this.lblPointSize = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(659, 561);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkBoxCrossSpanningTree);
            this.groupBox1.Controls.Add(this.rdBtnRemained);
            this.groupBox1.Controls.Add(this.rdBtnEliminated);
            this.groupBox1.Controls.Add(this.rdBtnAll);
            this.groupBox1.Controls.Add(this.chkBoxCrossOwnHull);
            this.groupBox1.Controls.Add(this.lblNumEdges);
            this.groupBox1.Controls.Add(this.lblEdges);
            this.groupBox1.Controls.Add(this.chkBoxCentroid);
            this.groupBox1.Controls.Add(this.lblPointSize);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Location = new System.Drawing.Point(677, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(193, 561);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "******";
            // 
            // chkBoxCrossSpanningTree
            // 
            this.chkBoxCrossSpanningTree.AutoSize = true;
            this.chkBoxCrossSpanningTree.Location = new System.Drawing.Point(6, 303);
            this.chkBoxCrossSpanningTree.Name = "chkBoxCrossSpanningTree";
            this.chkBoxCrossSpanningTree.Size = new System.Drawing.Size(165, 24);
            this.chkBoxCrossSpanningTree.TabIndex = 9;
            this.chkBoxCrossSpanningTree.Text = "Cross Spanning Tree";
            this.chkBoxCrossSpanningTree.UseVisualStyleBackColor = true;
            // 
            // rdBtnRemained
            // 
            this.rdBtnRemained.AutoSize = true;
            this.rdBtnRemained.Location = new System.Drawing.Point(6, 192);
            this.rdBtnRemained.Name = "rdBtnRemained";
            this.rdBtnRemained.Size = new System.Drawing.Size(97, 24);
            this.rdBtnRemained.TabIndex = 7;
            this.rdBtnRemained.TabStop = true;
            this.rdBtnRemained.Text = "Remained";
            this.rdBtnRemained.UseVisualStyleBackColor = true;
            // 
            // rdBtnEliminated
            // 
            this.rdBtnEliminated.AutoSize = true;
            this.rdBtnEliminated.Location = new System.Drawing.Point(6, 162);
            this.rdBtnEliminated.Name = "rdBtnEliminated";
            this.rdBtnEliminated.Size = new System.Drawing.Size(101, 24);
            this.rdBtnEliminated.TabIndex = 6;
            this.rdBtnEliminated.Text = "Eliminated";
            this.rdBtnEliminated.UseVisualStyleBackColor = true;
            this.rdBtnEliminated.CheckedChanged += new System.EventHandler(this.RdBtnEliminated_CheckedChanged);
            // 
            // rdBtnAll
            // 
            this.rdBtnAll.AutoSize = true;
            this.rdBtnAll.Checked = true;
            this.rdBtnAll.Location = new System.Drawing.Point(6, 132);
            this.rdBtnAll.Name = "rdBtnAll";
            this.rdBtnAll.Size = new System.Drawing.Size(48, 24);
            this.rdBtnAll.TabIndex = 5;
            this.rdBtnAll.TabStop = true;
            this.rdBtnAll.Text = "All";
            this.rdBtnAll.UseVisualStyleBackColor = true;
            this.rdBtnAll.CheckedChanged += new System.EventHandler(this.RdBtnAll_CheckedChanged);
            // 
            // chkBoxCrossOwnHull
            // 
            this.chkBoxCrossOwnHull.AutoSize = true;
            this.chkBoxCrossOwnHull.Enabled = false;
            this.chkBoxCrossOwnHull.Location = new System.Drawing.Point(6, 273);
            this.chkBoxCrossOwnHull.Name = "chkBoxCrossOwnHull";
            this.chkBoxCrossOwnHull.Size = new System.Drawing.Size(183, 24);
            this.chkBoxCrossOwnHull.TabIndex = 8;
            this.chkBoxCrossOwnHull.Text = "Cross Own Convex Hull";
            this.chkBoxCrossOwnHull.UseVisualStyleBackColor = true;
            this.chkBoxCrossOwnHull.CheckedChanged += new System.EventHandler(this.ChkBoxCrossOwnHull_CheckedChanged);
            // 
            // lblNumEdges
            // 
            this.lblNumEdges.AutoSize = true;
            this.lblNumEdges.Location = new System.Drawing.Point(61, 90);
            this.lblNumEdges.Name = "lblNumEdges";
            this.lblNumEdges.Size = new System.Drawing.Size(45, 20);
            this.lblNumEdges.TabIndex = 4;
            this.lblNumEdges.Text = "------";
            // 
            // lblEdges
            // 
            this.lblEdges.AutoSize = true;
            this.lblEdges.Location = new System.Drawing.Point(6, 90);
            this.lblEdges.Name = "lblEdges";
            this.lblEdges.Size = new System.Drawing.Size(49, 20);
            this.lblEdges.TabIndex = 3;
            this.lblEdges.Text = "Edges";
            // 
            // chkBoxCentroid
            // 
            this.chkBoxCentroid.AutoSize = true;
            this.chkBoxCentroid.Location = new System.Drawing.Point(6, 63);
            this.chkBoxCentroid.Name = "chkBoxCentroid";
            this.chkBoxCentroid.Size = new System.Drawing.Size(88, 24);
            this.chkBoxCentroid.TabIndex = 2;
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
            // EdgeEliminationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 585);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "EdgeEliminationForm";
            this.Text = "EdgeEliminationForm";
            this.Load += new System.EventHandler(this.EdgeEliminationForm_Load);
            this.ResizeEnd += new System.EventHandler(this.EdgeEliminationForm_ResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.CheckBox chkBoxCrossOwnHull;
        private System.Windows.Forms.RadioButton rdBtnAll;
        private System.Windows.Forms.RadioButton rdBtnEliminated;
        private System.Windows.Forms.RadioButton rdBtnRemained;
        private System.Windows.Forms.CheckBox chkBoxCrossSpanningTree;
    }
}