namespace WindowsTSP
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
            this.btnLoad = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblNodes = new System.Windows.Forms.Label();
            this.lblNumNodes = new System.Windows.Forms.Label();
            this.grpBoxGraph = new System.Windows.Forms.GroupBox();
            this.btnShowGraph = new System.Windows.Forms.Button();
            this.lblNumConvexHulls = new System.Windows.Forms.Label();
            this.lblConvexHulls = new System.Windows.Forms.Label();
            this.lblNumEdges = new System.Windows.Forms.Label();
            this.lblEdges = new System.Windows.Forms.Label();
            this.grpBoxElimination = new System.Windows.Forms.GroupBox();
            this.btnShowElimination = new System.Windows.Forms.Button();
            this.rdBtnEliminatedConvexHulls = new System.Windows.Forms.RadioButton();
            this.rdBtnEliminatedBetweenHulls = new System.Windows.Forms.RadioButton();
            this.rdBtnEliminatedOverHulls = new System.Windows.Forms.RadioButton();
            this.btnEdgeElimination = new System.Windows.Forms.Button();
            this.rdBtnRemained = new System.Windows.Forms.RadioButton();
            this.rdBtnEliminated = new System.Windows.Forms.RadioButton();
            this.btnWriteModel = new System.Windows.Forms.Button();
            this.btnReadSolution = new System.Windows.Forms.Button();
            this.btnComputeSpanningTree = new System.Windows.Forms.Button();
            this.btnComputeConvexHulls = new System.Windows.Forms.Button();
            this.grpBoxConvexHulls = new System.Windows.Forms.GroupBox();
            this.chkBoxAddBoundary = new System.Windows.Forms.CheckBox();
            this.btnShowConvexHulls = new System.Windows.Forms.Button();
            this.grpBoxModel = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNumComponents = new System.Windows.Forms.Label();
            this.btnComponents = new System.Windows.Forms.Button();
            this.btnShowSolution = new System.Windows.Forms.Button();
            this.grpBoxSpanningTree = new System.Windows.Forms.GroupBox();
            this.chkBoxSpanTreeAlternatives = new System.Windows.Forms.CheckBox();
            this.btnShowSpanningTree = new System.Windows.Forms.Button();
            this.btnComputeExpandSpanningTree = new System.Windows.Forms.Button();
            this.grpBoxEdges = new System.Windows.Forms.GroupBox();
            this.rdBtnOverHulls = new System.Windows.Forms.RadioButton();
            this.btnShowClassification = new System.Windows.Forms.Button();
            this.rdBtnBetweenHulls = new System.Windows.Forms.RadioButton();
            this.btnClassify = new System.Windows.Forms.Button();
            this.rdBtnInsideHulls = new System.Windows.Forms.RadioButton();
            this.grpBoxFinal = new System.Windows.Forms.GroupBox();
            this.btnShowTest = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnShowFinal = new System.Windows.Forms.Button();
            this.grpBoxTour = new System.Windows.Forms.GroupBox();
            this.btnSaveTour = new System.Windows.Forms.Button();
            this.btnShowTour = new System.Windows.Forms.Button();
            this.btnUploadTour = new System.Windows.Forms.Button();
            this.grpBoxExpandSpanTree = new System.Windows.Forms.GroupBox();
            this.chkBoxCleanExpandSpanTree = new System.Windows.Forms.CheckBox();
            this.btnShowExpandSpanningTree = new System.Windows.Forms.Button();
            this.grpBoxGraph.SuspendLayout();
            this.grpBoxElimination.SuspendLayout();
            this.grpBoxConvexHulls.SuspendLayout();
            this.grpBoxModel.SuspendLayout();
            this.grpBoxSpanningTree.SuspendLayout();
            this.grpBoxEdges.SuspendLayout();
            this.grpBoxFinal.SuspendLayout();
            this.grpBoxTour.SuspendLayout();
            this.grpBoxExpandSpanTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(784, 44);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(94, 29);
            this.btnLoad.TabIndex = 3;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.BackColor = System.Drawing.Color.White;
            this.txtFile.Location = new System.Drawing.Point(50, 10);
            this.txtFile.Name = "txtFile";
            this.txtFile.ReadOnly = true;
            this.txtFile.Size = new System.Drawing.Size(728, 27);
            this.txtFile.TabIndex = 1;
            this.txtFile.TabStop = false;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 13);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(32, 20);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(784, 9);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(94, 29);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.BtnBrowse_Click);
            // 
            // lblNodes
            // 
            this.lblNodes.AutoSize = true;
            this.lblNodes.Location = new System.Drawing.Point(10, 20);
            this.lblNodes.Name = "lblNodes";
            this.lblNodes.Size = new System.Drawing.Size(52, 20);
            this.lblNodes.TabIndex = 0;
            this.lblNodes.Text = "Nodes";
            // 
            // lblNumNodes
            // 
            this.lblNumNodes.AutoSize = true;
            this.lblNumNodes.Location = new System.Drawing.Point(119, 20);
            this.lblNumNodes.Name = "lblNumNodes";
            this.lblNumNodes.Size = new System.Drawing.Size(57, 20);
            this.lblNumNodes.TabIndex = 1;
            this.lblNumNodes.Text = "--------";
            // 
            // grpBoxGraph
            // 
            this.grpBoxGraph.Controls.Add(this.btnShowGraph);
            this.grpBoxGraph.Controls.Add(this.lblNumConvexHulls);
            this.grpBoxGraph.Controls.Add(this.lblConvexHulls);
            this.grpBoxGraph.Controls.Add(this.lblNumEdges);
            this.grpBoxGraph.Controls.Add(this.lblEdges);
            this.grpBoxGraph.Controls.Add(this.lblNodes);
            this.grpBoxGraph.Controls.Add(this.lblNumNodes);
            this.grpBoxGraph.Enabled = false;
            this.grpBoxGraph.Location = new System.Drawing.Point(12, 48);
            this.grpBoxGraph.Name = "grpBoxGraph";
            this.grpBoxGraph.Size = new System.Drawing.Size(185, 140);
            this.grpBoxGraph.TabIndex = 4;
            this.grpBoxGraph.TabStop = false;
            this.grpBoxGraph.Text = "Graph";
            // 
            // btnShowGraph
            // 
            this.btnShowGraph.Location = new System.Drawing.Point(6, 105);
            this.btnShowGraph.Name = "btnShowGraph";
            this.btnShowGraph.Size = new System.Drawing.Size(176, 29);
            this.btnShowGraph.TabIndex = 6;
            this.btnShowGraph.Text = "Show";
            this.btnShowGraph.UseVisualStyleBackColor = true;
            this.btnShowGraph.Click += new System.EventHandler(this.BtnShowGraph_Click);
            // 
            // lblNumConvexHulls
            // 
            this.lblNumConvexHulls.AutoSize = true;
            this.lblNumConvexHulls.Location = new System.Drawing.Point(119, 70);
            this.lblNumConvexHulls.Name = "lblNumConvexHulls";
            this.lblNumConvexHulls.Size = new System.Drawing.Size(57, 20);
            this.lblNumConvexHulls.TabIndex = 5;
            this.lblNumConvexHulls.Text = "--------";
            // 
            // lblConvexHulls
            // 
            this.lblConvexHulls.AutoSize = true;
            this.lblConvexHulls.Location = new System.Drawing.Point(10, 70);
            this.lblConvexHulls.Name = "lblConvexHulls";
            this.lblConvexHulls.Size = new System.Drawing.Size(94, 20);
            this.lblConvexHulls.TabIndex = 4;
            this.lblConvexHulls.Text = "Convex Hulls";
            // 
            // lblNumEdges
            // 
            this.lblNumEdges.AutoSize = true;
            this.lblNumEdges.Location = new System.Drawing.Point(119, 45);
            this.lblNumEdges.Name = "lblNumEdges";
            this.lblNumEdges.Size = new System.Drawing.Size(57, 20);
            this.lblNumEdges.TabIndex = 3;
            this.lblNumEdges.Text = "--------";
            // 
            // lblEdges
            // 
            this.lblEdges.AutoSize = true;
            this.lblEdges.Location = new System.Drawing.Point(10, 45);
            this.lblEdges.Name = "lblEdges";
            this.lblEdges.Size = new System.Drawing.Size(49, 20);
            this.lblEdges.TabIndex = 2;
            this.lblEdges.Text = "Edges";
            // 
            // grpBoxElimination
            // 
            this.grpBoxElimination.Controls.Add(this.btnShowElimination);
            this.grpBoxElimination.Controls.Add(this.rdBtnEliminatedConvexHulls);
            this.grpBoxElimination.Controls.Add(this.rdBtnEliminatedBetweenHulls);
            this.grpBoxElimination.Controls.Add(this.rdBtnEliminatedOverHulls);
            this.grpBoxElimination.Controls.Add(this.btnEdgeElimination);
            this.grpBoxElimination.Enabled = false;
            this.grpBoxElimination.Location = new System.Drawing.Point(203, 194);
            this.grpBoxElimination.Name = "grpBoxElimination";
            this.grpBoxElimination.Size = new System.Drawing.Size(185, 202);
            this.grpBoxElimination.TabIndex = 9;
            this.grpBoxElimination.TabStop = false;
            this.grpBoxElimination.Text = "Elimination";
            // 
            // btnShowElimination
            // 
            this.btnShowElimination.Enabled = false;
            this.btnShowElimination.Location = new System.Drawing.Point(6, 161);
            this.btnShowElimination.Name = "btnShowElimination";
            this.btnShowElimination.Size = new System.Drawing.Size(174, 29);
            this.btnShowElimination.TabIndex = 4;
            this.btnShowElimination.Text = "Show";
            this.btnShowElimination.UseVisualStyleBackColor = true;
            this.btnShowElimination.Click += new System.EventHandler(this.BtnShowElimination_Click);
            // 
            // rdBtnEliminatedConvexHulls
            // 
            this.rdBtnEliminatedConvexHulls.AutoSize = true;
            this.rdBtnEliminatedConvexHulls.Enabled = false;
            this.rdBtnEliminatedConvexHulls.Location = new System.Drawing.Point(6, 124);
            this.rdBtnEliminatedConvexHulls.Name = "rdBtnEliminatedConvexHulls";
            this.rdBtnEliminatedConvexHulls.Size = new System.Drawing.Size(115, 24);
            this.rdBtnEliminatedConvexHulls.TabIndex = 3;
            this.rdBtnEliminatedConvexHulls.Text = "Convex Hulls";
            this.rdBtnEliminatedConvexHulls.UseVisualStyleBackColor = true;
            this.rdBtnEliminatedConvexHulls.CheckedChanged += new System.EventHandler(this.RdBtnEliminatedConvexHulls_CheckedChanged);
            // 
            // rdBtnEliminatedBetweenHulls
            // 
            this.rdBtnEliminatedBetweenHulls.AutoSize = true;
            this.rdBtnEliminatedBetweenHulls.Checked = true;
            this.rdBtnEliminatedBetweenHulls.Enabled = false;
            this.rdBtnEliminatedBetweenHulls.Location = new System.Drawing.Point(6, 64);
            this.rdBtnEliminatedBetweenHulls.Name = "rdBtnEliminatedBetweenHulls";
            this.rdBtnEliminatedBetweenHulls.Size = new System.Drawing.Size(176, 24);
            this.rdBtnEliminatedBetweenHulls.TabIndex = 1;
            this.rdBtnEliminatedBetweenHulls.TabStop = true;
            this.rdBtnEliminatedBetweenHulls.Text = "Between Convex Hulls";
            this.rdBtnEliminatedBetweenHulls.UseVisualStyleBackColor = true;
            this.rdBtnEliminatedBetweenHulls.CheckedChanged += new System.EventHandler(this.RdBtnEliminatedBetweenHulls_CheckedChanged);
            // 
            // rdBtnEliminatedOverHulls
            // 
            this.rdBtnEliminatedOverHulls.AutoSize = true;
            this.rdBtnEliminatedOverHulls.Enabled = false;
            this.rdBtnEliminatedOverHulls.Location = new System.Drawing.Point(6, 94);
            this.rdBtnEliminatedOverHulls.Name = "rdBtnEliminatedOverHulls";
            this.rdBtnEliminatedOverHulls.Size = new System.Drawing.Size(150, 24);
            this.rdBtnEliminatedOverHulls.TabIndex = 2;
            this.rdBtnEliminatedOverHulls.Text = "Over Convex Hulls";
            this.rdBtnEliminatedOverHulls.UseVisualStyleBackColor = true;
            this.rdBtnEliminatedOverHulls.CheckedChanged += new System.EventHandler(this.RdBtnEliminatedOverHulls_CheckedChanged);
            // 
            // btnEdgeElimination
            // 
            this.btnEdgeElimination.Location = new System.Drawing.Point(6, 26);
            this.btnEdgeElimination.Name = "btnEdgeElimination";
            this.btnEdgeElimination.Size = new System.Drawing.Size(174, 29);
            this.btnEdgeElimination.TabIndex = 0;
            this.btnEdgeElimination.Text = "Compute";
            this.btnEdgeElimination.UseVisualStyleBackColor = true;
            this.btnEdgeElimination.Click += new System.EventHandler(this.BtnEdgeElimination_Click);
            // 
            // rdBtnRemained
            // 
            this.rdBtnRemained.AutoSize = true;
            this.rdBtnRemained.Checked = true;
            this.rdBtnRemained.Location = new System.Drawing.Point(6, 26);
            this.rdBtnRemained.Name = "rdBtnRemained";
            this.rdBtnRemained.Size = new System.Drawing.Size(97, 24);
            this.rdBtnRemained.TabIndex = 0;
            this.rdBtnRemained.TabStop = true;
            this.rdBtnRemained.Text = "Remained";
            this.rdBtnRemained.UseVisualStyleBackColor = true;
            // 
            // rdBtnEliminated
            // 
            this.rdBtnEliminated.AutoSize = true;
            this.rdBtnEliminated.Location = new System.Drawing.Point(6, 56);
            this.rdBtnEliminated.Name = "rdBtnEliminated";
            this.rdBtnEliminated.Size = new System.Drawing.Size(101, 24);
            this.rdBtnEliminated.TabIndex = 1;
            this.rdBtnEliminated.Text = "Eliminated";
            this.rdBtnEliminated.UseVisualStyleBackColor = true;
            // 
            // btnWriteModel
            // 
            this.btnWriteModel.Location = new System.Drawing.Point(6, 27);
            this.btnWriteModel.Name = "btnWriteModel";
            this.btnWriteModel.Size = new System.Drawing.Size(164, 29);
            this.btnWriteModel.TabIndex = 0;
            this.btnWriteModel.Text = "Write Model";
            this.btnWriteModel.UseVisualStyleBackColor = true;
            this.btnWriteModel.Click += new System.EventHandler(this.BtnWriteModel_Click);
            // 
            // btnReadSolution
            // 
            this.btnReadSolution.Location = new System.Drawing.Point(6, 62);
            this.btnReadSolution.Name = "btnReadSolution";
            this.btnReadSolution.Size = new System.Drawing.Size(164, 29);
            this.btnReadSolution.TabIndex = 1;
            this.btnReadSolution.Text = "Read Solution";
            this.btnReadSolution.UseVisualStyleBackColor = true;
            this.btnReadSolution.Click += new System.EventHandler(this.BtnReadSolution_Click);
            // 
            // btnComputeSpanningTree
            // 
            this.btnComputeSpanningTree.Location = new System.Drawing.Point(6, 27);
            this.btnComputeSpanningTree.Name = "btnComputeSpanningTree";
            this.btnComputeSpanningTree.Size = new System.Drawing.Size(120, 29);
            this.btnComputeSpanningTree.TabIndex = 0;
            this.btnComputeSpanningTree.Text = "Compute";
            this.btnComputeSpanningTree.UseVisualStyleBackColor = true;
            this.btnComputeSpanningTree.Click += new System.EventHandler(this.BtnComputeSpanningTree_Click);
            // 
            // btnComputeConvexHulls
            // 
            this.btnComputeConvexHulls.Location = new System.Drawing.Point(6, 27);
            this.btnComputeConvexHulls.Name = "btnComputeConvexHulls";
            this.btnComputeConvexHulls.Size = new System.Drawing.Size(120, 29);
            this.btnComputeConvexHulls.TabIndex = 0;
            this.btnComputeConvexHulls.Text = "Compute";
            this.btnComputeConvexHulls.UseVisualStyleBackColor = true;
            this.btnComputeConvexHulls.Click += new System.EventHandler(this.BtnComputeConvexHulls_Click);
            // 
            // grpBoxConvexHulls
            // 
            this.grpBoxConvexHulls.Controls.Add(this.chkBoxAddBoundary);
            this.grpBoxConvexHulls.Controls.Add(this.btnShowConvexHulls);
            this.grpBoxConvexHulls.Controls.Add(this.btnComputeConvexHulls);
            this.grpBoxConvexHulls.Enabled = false;
            this.grpBoxConvexHulls.Location = new System.Drawing.Point(203, 48);
            this.grpBoxConvexHulls.Name = "grpBoxConvexHulls";
            this.grpBoxConvexHulls.Size = new System.Drawing.Size(135, 140);
            this.grpBoxConvexHulls.TabIndex = 6;
            this.grpBoxConvexHulls.TabStop = false;
            this.grpBoxConvexHulls.Text = "Convex Hulls";
            // 
            // chkBoxAddBoundary
            // 
            this.chkBoxAddBoundary.AutoSize = true;
            this.chkBoxAddBoundary.Location = new System.Drawing.Point(6, 65);
            this.chkBoxAddBoundary.Name = "chkBoxAddBoundary";
            this.chkBoxAddBoundary.Size = new System.Drawing.Size(126, 24);
            this.chkBoxAddBoundary.TabIndex = 2;
            this.chkBoxAddBoundary.Text = "Add Boundary";
            this.chkBoxAddBoundary.UseVisualStyleBackColor = true;
            // 
            // btnShowConvexHulls
            // 
            this.btnShowConvexHulls.Enabled = false;
            this.btnShowConvexHulls.Location = new System.Drawing.Point(6, 97);
            this.btnShowConvexHulls.Name = "btnShowConvexHulls";
            this.btnShowConvexHulls.Size = new System.Drawing.Size(120, 29);
            this.btnShowConvexHulls.TabIndex = 1;
            this.btnShowConvexHulls.Text = "Show";
            this.btnShowConvexHulls.UseVisualStyleBackColor = true;
            this.btnShowConvexHulls.Click += new System.EventHandler(this.BtnShowConvexHulls_Click);
            // 
            // grpBoxModel
            // 
            this.grpBoxModel.Controls.Add(this.label1);
            this.grpBoxModel.Controls.Add(this.lblNumComponents);
            this.grpBoxModel.Controls.Add(this.btnComponents);
            this.grpBoxModel.Controls.Add(this.btnShowSolution);
            this.grpBoxModel.Controls.Add(this.btnWriteModel);
            this.grpBoxModel.Controls.Add(this.btnReadSolution);
            this.grpBoxModel.Enabled = false;
            this.grpBoxModel.Location = new System.Drawing.Point(512, 194);
            this.grpBoxModel.Name = "grpBoxModel";
            this.grpBoxModel.Size = new System.Drawing.Size(176, 202);
            this.grpBoxModel.TabIndex = 5;
            this.grpBoxModel.TabStop = false;
            this.grpBoxModel.Text = "Model";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Components";
            // 
            // lblNumComponents
            // 
            this.lblNumComponents.AutoSize = true;
            this.lblNumComponents.Location = new System.Drawing.Point(113, 170);
            this.lblNumComponents.Name = "lblNumComponents";
            this.lblNumComponents.Size = new System.Drawing.Size(57, 20);
            this.lblNumComponents.TabIndex = 5;
            this.lblNumComponents.Text = "--------";
            // 
            // btnComponents
            // 
            this.btnComponents.Enabled = false;
            this.btnComponents.Location = new System.Drawing.Point(6, 97);
            this.btnComponents.Name = "btnComponents";
            this.btnComponents.Size = new System.Drawing.Size(164, 29);
            this.btnComponents.TabIndex = 2;
            this.btnComponents.Text = "Components";
            this.btnComponents.UseVisualStyleBackColor = true;
            this.btnComponents.Click += new System.EventHandler(this.BtnComponents_Click);
            // 
            // btnShowSolution
            // 
            this.btnShowSolution.Enabled = false;
            this.btnShowSolution.Location = new System.Drawing.Point(6, 132);
            this.btnShowSolution.Name = "btnShowSolution";
            this.btnShowSolution.Size = new System.Drawing.Size(164, 29);
            this.btnShowSolution.TabIndex = 3;
            this.btnShowSolution.Text = "Show";
            this.btnShowSolution.UseVisualStyleBackColor = true;
            this.btnShowSolution.Click += new System.EventHandler(this.BtnShowSolution_Click);
            // 
            // grpBoxSpanningTree
            // 
            this.grpBoxSpanningTree.Controls.Add(this.chkBoxSpanTreeAlternatives);
            this.grpBoxSpanningTree.Controls.Add(this.btnShowSpanningTree);
            this.grpBoxSpanningTree.Controls.Add(this.btnComputeSpanningTree);
            this.grpBoxSpanningTree.Enabled = false;
            this.grpBoxSpanningTree.Location = new System.Drawing.Point(344, 48);
            this.grpBoxSpanningTree.Name = "grpBoxSpanningTree";
            this.grpBoxSpanningTree.Size = new System.Drawing.Size(135, 140);
            this.grpBoxSpanningTree.TabIndex = 7;
            this.grpBoxSpanningTree.TabStop = false;
            this.grpBoxSpanningTree.Text = "Spanning Tree";
            // 
            // chkBoxSpanTreeAlternatives
            // 
            this.chkBoxSpanTreeAlternatives.AutoSize = true;
            this.chkBoxSpanTreeAlternatives.Location = new System.Drawing.Point(6, 65);
            this.chkBoxSpanTreeAlternatives.Name = "chkBoxSpanTreeAlternatives";
            this.chkBoxSpanTreeAlternatives.Size = new System.Drawing.Size(109, 24);
            this.chkBoxSpanTreeAlternatives.TabIndex = 1;
            this.chkBoxSpanTreeAlternatives.Text = "Alternatives";
            this.chkBoxSpanTreeAlternatives.UseVisualStyleBackColor = true;
            // 
            // btnShowSpanningTree
            // 
            this.btnShowSpanningTree.Enabled = false;
            this.btnShowSpanningTree.Location = new System.Drawing.Point(6, 97);
            this.btnShowSpanningTree.Name = "btnShowSpanningTree";
            this.btnShowSpanningTree.Size = new System.Drawing.Size(120, 29);
            this.btnShowSpanningTree.TabIndex = 2;
            this.btnShowSpanningTree.Text = "Show";
            this.btnShowSpanningTree.UseVisualStyleBackColor = true;
            this.btnShowSpanningTree.Click += new System.EventHandler(this.BtnShowSpanningTree_Click);
            // 
            // btnComputeExpandSpanningTree
            // 
            this.btnComputeExpandSpanningTree.Location = new System.Drawing.Point(6, 27);
            this.btnComputeExpandSpanningTree.Name = "btnComputeExpandSpanningTree";
            this.btnComputeExpandSpanningTree.Size = new System.Drawing.Size(138, 29);
            this.btnComputeExpandSpanningTree.TabIndex = 0;
            this.btnComputeExpandSpanningTree.Text = "Compute";
            this.btnComputeExpandSpanningTree.UseVisualStyleBackColor = true;
            this.btnComputeExpandSpanningTree.Click += new System.EventHandler(this.BtnExpandSpanningTree_Click);
            // 
            // grpBoxEdges
            // 
            this.grpBoxEdges.Controls.Add(this.rdBtnOverHulls);
            this.grpBoxEdges.Controls.Add(this.btnShowClassification);
            this.grpBoxEdges.Controls.Add(this.rdBtnBetweenHulls);
            this.grpBoxEdges.Controls.Add(this.btnClassify);
            this.grpBoxEdges.Controls.Add(this.rdBtnInsideHulls);
            this.grpBoxEdges.Enabled = false;
            this.grpBoxEdges.Location = new System.Drawing.Point(12, 194);
            this.grpBoxEdges.Name = "grpBoxEdges";
            this.grpBoxEdges.Size = new System.Drawing.Size(185, 202);
            this.grpBoxEdges.TabIndex = 8;
            this.grpBoxEdges.TabStop = false;
            this.grpBoxEdges.Text = "Edges";
            // 
            // rdBtnOverHulls
            // 
            this.rdBtnOverHulls.AutoSize = true;
            this.rdBtnOverHulls.Enabled = false;
            this.rdBtnOverHulls.Location = new System.Drawing.Point(6, 124);
            this.rdBtnOverHulls.Name = "rdBtnOverHulls";
            this.rdBtnOverHulls.Size = new System.Drawing.Size(150, 24);
            this.rdBtnOverHulls.TabIndex = 3;
            this.rdBtnOverHulls.Text = "Over Convex Hulls";
            this.rdBtnOverHulls.UseVisualStyleBackColor = true;
            this.rdBtnOverHulls.CheckedChanged += new System.EventHandler(this.RdBtnOverHulls_CheckedChanged);
            // 
            // btnShowClassification
            // 
            this.btnShowClassification.Enabled = false;
            this.btnShowClassification.Location = new System.Drawing.Point(6, 161);
            this.btnShowClassification.Name = "btnShowClassification";
            this.btnShowClassification.Size = new System.Drawing.Size(174, 29);
            this.btnShowClassification.TabIndex = 4;
            this.btnShowClassification.Text = "Show";
            this.btnShowClassification.UseVisualStyleBackColor = true;
            this.btnShowClassification.Click += new System.EventHandler(this.BtnShowClassification_Click);
            // 
            // rdBtnBetweenHulls
            // 
            this.rdBtnBetweenHulls.AutoSize = true;
            this.rdBtnBetweenHulls.Enabled = false;
            this.rdBtnBetweenHulls.Location = new System.Drawing.Point(6, 94);
            this.rdBtnBetweenHulls.Name = "rdBtnBetweenHulls";
            this.rdBtnBetweenHulls.Size = new System.Drawing.Size(176, 24);
            this.rdBtnBetweenHulls.TabIndex = 2;
            this.rdBtnBetweenHulls.Text = "Between Convex Hulls";
            this.rdBtnBetweenHulls.UseVisualStyleBackColor = true;
            this.rdBtnBetweenHulls.CheckedChanged += new System.EventHandler(this.RdBtnBetweenHulls_CheckedChanged);
            // 
            // btnClassify
            // 
            this.btnClassify.Location = new System.Drawing.Point(6, 26);
            this.btnClassify.Name = "btnClassify";
            this.btnClassify.Size = new System.Drawing.Size(174, 29);
            this.btnClassify.TabIndex = 0;
            this.btnClassify.Text = "Classify";
            this.btnClassify.UseVisualStyleBackColor = true;
            this.btnClassify.Click += new System.EventHandler(this.BtnClassify_Click);
            // 
            // rdBtnInsideHulls
            // 
            this.rdBtnInsideHulls.AutoSize = true;
            this.rdBtnInsideHulls.Checked = true;
            this.rdBtnInsideHulls.Enabled = false;
            this.rdBtnInsideHulls.Location = new System.Drawing.Point(6, 64);
            this.rdBtnInsideHulls.Name = "rdBtnInsideHulls";
            this.rdBtnInsideHulls.Size = new System.Drawing.Size(158, 24);
            this.rdBtnInsideHulls.TabIndex = 1;
            this.rdBtnInsideHulls.TabStop = true;
            this.rdBtnInsideHulls.Text = "Inside Convex Hulls";
            this.rdBtnInsideHulls.UseVisualStyleBackColor = true;
            this.rdBtnInsideHulls.CheckedChanged += new System.EventHandler(this.RdBtnInsideHulls_CheckedChanged);
            // 
            // grpBoxFinal
            // 
            this.grpBoxFinal.Controls.Add(this.btnShowTest);
            this.grpBoxFinal.Controls.Add(this.btnTest);
            this.grpBoxFinal.Controls.Add(this.btnShowFinal);
            this.grpBoxFinal.Controls.Add(this.rdBtnEliminated);
            this.grpBoxFinal.Controls.Add(this.rdBtnRemained);
            this.grpBoxFinal.Enabled = false;
            this.grpBoxFinal.Location = new System.Drawing.Point(394, 194);
            this.grpBoxFinal.Name = "grpBoxFinal";
            this.grpBoxFinal.Size = new System.Drawing.Size(112, 202);
            this.grpBoxFinal.TabIndex = 10;
            this.grpBoxFinal.TabStop = false;
            this.grpBoxFinal.Text = "Final";
            // 
            // btnShowTest
            // 
            this.btnShowTest.Enabled = false;
            this.btnShowTest.Location = new System.Drawing.Point(6, 161);
            this.btnShowTest.Name = "btnShowTest";
            this.btnShowTest.Size = new System.Drawing.Size(101, 29);
            this.btnShowTest.TabIndex = 4;
            this.btnShowTest.Text = "Show";
            this.btnShowTest.UseVisualStyleBackColor = true;
            this.btnShowTest.Click += new System.EventHandler(this.BtnShowTest_Click);
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(7, 122);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(100, 29);
            this.btnTest.TabIndex = 3;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.BtnTest_Click);
            // 
            // btnShowFinal
            // 
            this.btnShowFinal.Location = new System.Drawing.Point(7, 86);
            this.btnShowFinal.Name = "btnShowFinal";
            this.btnShowFinal.Size = new System.Drawing.Size(100, 29);
            this.btnShowFinal.TabIndex = 2;
            this.btnShowFinal.Text = "Show";
            this.btnShowFinal.UseVisualStyleBackColor = true;
            this.btnShowFinal.Click += new System.EventHandler(this.BtnShowFinal_Click);
            // 
            // grpBoxTour
            // 
            this.grpBoxTour.Controls.Add(this.btnSaveTour);
            this.grpBoxTour.Controls.Add(this.btnShowTour);
            this.grpBoxTour.Controls.Add(this.btnUploadTour);
            this.grpBoxTour.Enabled = false;
            this.grpBoxTour.Location = new System.Drawing.Point(641, 48);
            this.grpBoxTour.Name = "grpBoxTour";
            this.grpBoxTour.Size = new System.Drawing.Size(135, 140);
            this.grpBoxTour.TabIndex = 11;
            this.grpBoxTour.TabStop = false;
            this.grpBoxTour.Text = "Tour";
            // 
            // btnSaveTour
            // 
            this.btnSaveTour.Enabled = false;
            this.btnSaveTour.Location = new System.Drawing.Point(6, 97);
            this.btnSaveTour.Name = "btnSaveTour";
            this.btnSaveTour.Size = new System.Drawing.Size(120, 29);
            this.btnSaveTour.TabIndex = 2;
            this.btnSaveTour.Text = "Save";
            this.btnSaveTour.UseVisualStyleBackColor = true;
            this.btnSaveTour.Click += new System.EventHandler(this.BtnSaveTour_Click);
            // 
            // btnShowTour
            // 
            this.btnShowTour.Enabled = false;
            this.btnShowTour.Location = new System.Drawing.Point(6, 62);
            this.btnShowTour.Name = "btnShowTour";
            this.btnShowTour.Size = new System.Drawing.Size(120, 29);
            this.btnShowTour.TabIndex = 1;
            this.btnShowTour.Text = "Show";
            this.btnShowTour.UseVisualStyleBackColor = true;
            this.btnShowTour.Click += new System.EventHandler(this.BtnShowTour_Click);
            // 
            // btnUploadTour
            // 
            this.btnUploadTour.Location = new System.Drawing.Point(6, 26);
            this.btnUploadTour.Name = "btnUploadTour";
            this.btnUploadTour.Size = new System.Drawing.Size(120, 29);
            this.btnUploadTour.TabIndex = 0;
            this.btnUploadTour.Text = "Upload";
            this.btnUploadTour.UseVisualStyleBackColor = true;
            this.btnUploadTour.Click += new System.EventHandler(this.BtnUploadTour_Click);
            // 
            // grpBoxExpandSpanTree
            // 
            this.grpBoxExpandSpanTree.Controls.Add(this.chkBoxCleanExpandSpanTree);
            this.grpBoxExpandSpanTree.Controls.Add(this.btnShowExpandSpanningTree);
            this.grpBoxExpandSpanTree.Controls.Add(this.btnComputeExpandSpanningTree);
            this.grpBoxExpandSpanTree.Enabled = false;
            this.grpBoxExpandSpanTree.Location = new System.Drawing.Point(485, 48);
            this.grpBoxExpandSpanTree.Name = "grpBoxExpandSpanTree";
            this.grpBoxExpandSpanTree.Size = new System.Drawing.Size(150, 140);
            this.grpBoxExpandSpanTree.TabIndex = 12;
            this.grpBoxExpandSpanTree.TabStop = false;
            this.grpBoxExpandSpanTree.Text = "Span Tree - Hulls";
            // 
            // chkBoxCleanExpandSpanTree
            // 
            this.chkBoxCleanExpandSpanTree.AutoSize = true;
            this.chkBoxCleanExpandSpanTree.Location = new System.Drawing.Point(6, 65);
            this.chkBoxCleanExpandSpanTree.Name = "chkBoxCleanExpandSpanTree";
            this.chkBoxCleanExpandSpanTree.Size = new System.Drawing.Size(68, 24);
            this.chkBoxCleanExpandSpanTree.TabIndex = 1;
            this.chkBoxCleanExpandSpanTree.Text = "Clean";
            this.chkBoxCleanExpandSpanTree.UseVisualStyleBackColor = true;
            // 
            // btnShowExpandSpanningTree
            // 
            this.btnShowExpandSpanningTree.Enabled = false;
            this.btnShowExpandSpanningTree.Location = new System.Drawing.Point(6, 97);
            this.btnShowExpandSpanningTree.Name = "btnShowExpandSpanningTree";
            this.btnShowExpandSpanningTree.Size = new System.Drawing.Size(138, 29);
            this.btnShowExpandSpanningTree.TabIndex = 2;
            this.btnShowExpandSpanningTree.Text = "Show";
            this.btnShowExpandSpanningTree.UseVisualStyleBackColor = true;
            this.btnShowExpandSpanningTree.Click += new System.EventHandler(this.BtnShowExpandSpanningTree_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(885, 405);
            this.Controls.Add(this.grpBoxExpandSpanTree);
            this.Controls.Add(this.grpBoxTour);
            this.Controls.Add(this.grpBoxFinal);
            this.Controls.Add(this.grpBoxEdges);
            this.Controls.Add(this.grpBoxSpanningTree);
            this.Controls.Add(this.grpBoxElimination);
            this.Controls.Add(this.grpBoxModel);
            this.Controls.Add(this.grpBoxConvexHulls);
            this.Controls.Add(this.grpBoxGraph);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.lblFile);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnLoad);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "TSP";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.grpBoxGraph.ResumeLayout(false);
            this.grpBoxGraph.PerformLayout();
            this.grpBoxElimination.ResumeLayout(false);
            this.grpBoxElimination.PerformLayout();
            this.grpBoxConvexHulls.ResumeLayout(false);
            this.grpBoxConvexHulls.PerformLayout();
            this.grpBoxModel.ResumeLayout(false);
            this.grpBoxModel.PerformLayout();
            this.grpBoxSpanningTree.ResumeLayout(false);
            this.grpBoxSpanningTree.PerformLayout();
            this.grpBoxEdges.ResumeLayout(false);
            this.grpBoxEdges.PerformLayout();
            this.grpBoxFinal.ResumeLayout(false);
            this.grpBoxFinal.PerformLayout();
            this.grpBoxTour.ResumeLayout(false);
            this.grpBoxExpandSpanTree.ResumeLayout(false);
            this.grpBoxExpandSpanTree.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblNodes;
        private System.Windows.Forms.Label lblNumNodes;
        private System.Windows.Forms.GroupBox grpBoxGraph;
        private System.Windows.Forms.Label lblNumEdges;
        private System.Windows.Forms.Label lblEdges;
        private System.Windows.Forms.RadioButton rdBtnRemained;
        private System.Windows.Forms.RadioButton rdBtnEliminated;
        private System.Windows.Forms.GroupBox grpBoxElimination;
        private System.Windows.Forms.Label lblNumConvexHulls;
        private System.Windows.Forms.Label lblConvexHulls;
        private System.Windows.Forms.Button btnWriteModel;
        private System.Windows.Forms.Button btnReadSolution;
        private System.Windows.Forms.Button btnComputeSpanningTree;
        private System.Windows.Forms.Button btnComputeConvexHulls;
        private System.Windows.Forms.GroupBox grpBoxConvexHulls;
        private System.Windows.Forms.GroupBox grpBoxModel;
        private System.Windows.Forms.Button btnEdgeElimination;
        private System.Windows.Forms.Button btnShowSolution;
        private System.Windows.Forms.GroupBox grpBoxSpanningTree;
        private System.Windows.Forms.Button btnShowConvexHulls;
        private System.Windows.Forms.Button btnShowSpanningTree;
        private System.Windows.Forms.Button btnShowGraph;
        private System.Windows.Forms.GroupBox grpBoxEdges;
        private System.Windows.Forms.Button btnShowClassification;
        private System.Windows.Forms.Button btnClassify;
        private System.Windows.Forms.RadioButton rdBtnInsideHulls;
        private System.Windows.Forms.RadioButton rdBtnBetweenHulls;
        private System.Windows.Forms.RadioButton rdBtnOverHulls;
        private System.Windows.Forms.RadioButton rdBtnEliminatedBetweenHulls;
        private System.Windows.Forms.RadioButton rdBtnEliminatedOverHulls;
        private System.Windows.Forms.RadioButton rdBtnEliminatedConvexHulls;
        private System.Windows.Forms.Button btnShowElimination;
        private System.Windows.Forms.GroupBox grpBoxFinal;
        private System.Windows.Forms.Button btnShowFinal;
        private System.Windows.Forms.Button btnComputeExpandSpanningTree;
        private System.Windows.Forms.Button btnComponents;
        private System.Windows.Forms.Label lblNumComponents;
        private System.Windows.Forms.CheckBox chkBoxAddBoundary;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBoxTour;
        private System.Windows.Forms.Button btnShowTour;
        private System.Windows.Forms.Button btnUploadTour;
        private System.Windows.Forms.Button btnSaveTour;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnShowTest;
        private System.Windows.Forms.CheckBox chkBoxSpanTreeAlternatives;
        private System.Windows.Forms.GroupBox grpBoxExpandSpanTree;
        private System.Windows.Forms.Button btnShowExpandSpanningTree;
        private System.Windows.Forms.CheckBox chkBoxCleanExpandSpanTree;
    }
}