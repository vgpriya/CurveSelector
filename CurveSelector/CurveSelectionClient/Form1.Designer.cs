namespace CurveSelectionClient
{
    partial class Form1
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
            this.chkCurveA = new System.Windows.Forms.CheckBox();
            this.chkCurveB = new System.Windows.Forms.CheckBox();
            this.chkCurveA2 = new System.Windows.Forms.CheckBox();
            this.chkCurveC = new System.Windows.Forms.CheckBox();
            this.grdCurve = new System.Windows.Forms.DataGridView();
            this.CurveIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurveA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurveA2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurveB = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurveC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnLoad = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdCurve)).BeginInit();
            this.SuspendLayout();
            // 
            // chkCurveA
            // 
            this.chkCurveA.AutoSize = true;
            this.chkCurveA.Location = new System.Drawing.Point(24, 57);
            this.chkCurveA.Name = "chkCurveA";
            this.chkCurveA.Size = new System.Drawing.Size(64, 17);
            this.chkCurveA.TabIndex = 4;
            this.chkCurveA.Text = "Curve A";
            this.chkCurveA.UseVisualStyleBackColor = true;
            this.chkCurveA.CheckedChanged += new System.EventHandler(this.chkCurveA_CheckedChanged);
            // 
            // chkCurveB
            // 
            this.chkCurveB.AutoSize = true;
            this.chkCurveB.Location = new System.Drawing.Point(122, 57);
            this.chkCurveB.Name = "chkCurveB";
            this.chkCurveB.Size = new System.Drawing.Size(64, 17);
            this.chkCurveB.TabIndex = 5;
            this.chkCurveB.Text = "Curve B";
            this.chkCurveB.UseVisualStyleBackColor = true;
            this.chkCurveB.CheckedChanged += new System.EventHandler(this.chkCurveB_CheckedChanged);
            // 
            // chkCurveA2
            // 
            this.chkCurveA2.AutoSize = true;
            this.chkCurveA2.Location = new System.Drawing.Point(218, 57);
            this.chkCurveA2.Name = "chkCurveA2";
            this.chkCurveA2.Size = new System.Drawing.Size(70, 17);
            this.chkCurveA2.TabIndex = 6;
            this.chkCurveA2.Text = "Curve A2";
            this.chkCurveA2.UseVisualStyleBackColor = true;
            this.chkCurveA2.CheckedChanged += new System.EventHandler(this.chkCurveA2_CheckedChanged);
            // 
            // chkCurveC
            // 
            this.chkCurveC.AutoSize = true;
            this.chkCurveC.Location = new System.Drawing.Point(312, 57);
            this.chkCurveC.Name = "chkCurveC";
            this.chkCurveC.Size = new System.Drawing.Size(64, 17);
            this.chkCurveC.TabIndex = 7;
            this.chkCurveC.Text = "Curve C";
            this.chkCurveC.UseVisualStyleBackColor = true;
            this.chkCurveC.CheckedChanged += new System.EventHandler(this.chkCurveC_CheckedChanged);
            // 
            // grdCurve
            // 
            this.grdCurve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdCurve.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CurveIndex,
            this.CurveA,
            this.CurveA2,
            this.CurveB,
            this.CurveC});
            this.grdCurve.Location = new System.Drawing.Point(24, 103);
            this.grdCurve.Name = "grdCurve";
            this.grdCurve.Size = new System.Drawing.Size(545, 306);
            this.grdCurve.TabIndex = 8;
            // 
            // CurveIndex
            // 
            this.CurveIndex.Frozen = true;
            this.CurveIndex.HeaderText = "Index";
            this.CurveIndex.Name = "CurveIndex";
            // 
            // CurveA
            // 
            this.CurveA.HeaderText = "A";
            this.CurveA.Name = "CurveA";
            this.CurveA.ReadOnly = true;
            this.CurveA.Visible = false;
            // 
            // CurveA2
            // 
            this.CurveA2.HeaderText = "A2";
            this.CurveA2.Name = "CurveA2";
            this.CurveA2.ReadOnly = true;
            this.CurveA2.Visible = false;
            // 
            // CurveB
            // 
            this.CurveB.HeaderText = "B";
            this.CurveB.Name = "CurveB";
            this.CurveB.ReadOnly = true;
            this.CurveB.Visible = false;
            // 
            // CurveC
            // 
            this.CurveC.HeaderText = "C";
            this.CurveC.Name = "CurveC";
            this.CurveC.ReadOnly = true;
            this.CurveC.Visible = false;
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(404, 51);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 9;
            this.btnLoad.Text = "Load Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 10;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(545, 415);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 11;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(24, 18);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(114, 23);
            this.btnConnect.TabIndex = 12;
            this.btnConnect.Text = "Connect To Server";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(516, 51);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 13;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 450);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.grdCurve);
            this.Controls.Add(this.chkCurveC);
            this.Controls.Add(this.chkCurveA2);
            this.Controls.Add(this.chkCurveB);
            this.Controls.Add(this.chkCurveA);
            this.Name = "Form1";
            this.Text = "Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdCurve)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkCurveA;
        private System.Windows.Forms.CheckBox chkCurveB;
        private System.Windows.Forms.CheckBox chkCurveA2;
        private System.Windows.Forms.CheckBox chkCurveC;
        private System.Windows.Forms.DataGridView grdCurve;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurveIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurveA;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurveA2;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurveB;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurveC;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnClear;
    }
}

