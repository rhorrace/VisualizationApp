
namespace WindowsFormsApp
{
    partial class Visualizer
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
            this.ButtonReset = new System.Windows.Forms.Button();
            this.ButtonStart = new System.Windows.Forms.Button();
            this.PanelGraph = new System.Windows.Forms.Panel();
            this.ButtonRandomize = new System.Windows.Forms.Button();
            this.DropdownSorts = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(707, 12);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(81, 35);
            this.ButtonReset.TabIndex = 3;
            this.ButtonReset.Text = "Reset";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // ButtonStart
            // 
            this.ButtonStart.Location = new System.Drawing.Point(621, 12);
            this.ButtonStart.Name = "ButtonStart";
            this.ButtonStart.Size = new System.Drawing.Size(80, 35);
            this.ButtonStart.TabIndex = 2;
            this.ButtonStart.Text = "Start";
            this.ButtonStart.UseVisualStyleBackColor = true;
            this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
            // 
            // PanelGraph
            // 
            this.PanelGraph.Location = new System.Drawing.Point(12, 53);
            this.PanelGraph.Name = "PanelGraph";
            this.PanelGraph.Size = new System.Drawing.Size(776, 385);
            this.PanelGraph.TabIndex = 4;
            // 
            // ButtonRandomize
            // 
            this.ButtonRandomize.Location = new System.Drawing.Point(499, 12);
            this.ButtonRandomize.Name = "ButtonRandomize";
            this.ButtonRandomize.Size = new System.Drawing.Size(116, 35);
            this.ButtonRandomize.TabIndex = 1;
            this.ButtonRandomize.Text = "Randomize";
            this.ButtonRandomize.UseVisualStyleBackColor = true;
            this.ButtonRandomize.Click += new System.EventHandler(this.ButtonRandomize_Click);
            // 
            // DropdownSorts
            // 
            this.DropdownSorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.DropdownSorts.FormattingEnabled = true;
            this.DropdownSorts.Items.AddRange(new object[] {
            "Bubble",
            "Insertion",
            "Selection",
            "Heap",
            "Merge",
            "Quick",
            "Counting",
            "Radix"});
            this.DropdownSorts.Location = new System.Drawing.Point(12, 12);
            this.DropdownSorts.Name = "DropdownSorts";
            this.DropdownSorts.Size = new System.Drawing.Size(247, 28);
            this.DropdownSorts.TabIndex = 5;
            // 
            // Visualizer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.DropdownSorts);
            this.Controls.Add(this.ButtonRandomize);
            this.Controls.Add(this.PanelGraph);
            this.Controls.Add(this.ButtonStart);
            this.Controls.Add(this.ButtonReset);
            this.Name = "Visualizer";
            this.Text = "Sorting Visualizer";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ButtonReset;
        private System.Windows.Forms.Button ButtonStart;
        private System.Windows.Forms.Panel PanelGraph;
        private System.Windows.Forms.Button ButtonRandomize;
        private System.Windows.Forms.ComboBox DropdownSorts;
    }
}

