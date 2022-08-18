
namespace WinFormsApp1
{
    partial class Form2
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
            this.button1Fr2Copy = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonHide = new System.Windows.Forms.Button();
            this.buttonAspr = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1Fr2Copy
            // 
            this.button1Fr2Copy.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1Fr2Copy.Location = new System.Drawing.Point(4, 89);
            this.button1Fr2Copy.Name = "button1Fr2Copy";
            this.button1Fr2Copy.Size = new System.Drawing.Size(176, 47);
            this.button1Fr2Copy.TabIndex = 2;
            this.button1Fr2Copy.Text = "09546";
            this.button1Fr2Copy.UseVisualStyleBackColor = true;
            this.button1Fr2Copy.Click += new System.EventHandler(this.button1Fr2Copy_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(4, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "OpenPath";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonHide
            // 
            this.buttonHide.Location = new System.Drawing.Point(158, 60);
            this.buttonHide.Name = "buttonHide";
            this.buttonHide.Size = new System.Drawing.Size(16, 23);
            this.buttonHide.TabIndex = 4;
            this.buttonHide.UseVisualStyleBackColor = true;
            this.buttonHide.Click += new System.EventHandler(this.buttonHide_Click);
            // 
            // buttonAspr
            // 
            this.buttonAspr.Font = new System.Drawing.Font("Segoe UI", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAspr.Location = new System.Drawing.Point(4, 8);
            this.buttonAspr.Name = "buttonAspr";
            this.buttonAspr.Size = new System.Drawing.Size(176, 43);
            this.buttonAspr.TabIndex = 6;
            this.buttonAspr.Text = "ASPR-0000";
            this.buttonAspr.UseVisualStyleBackColor = true;
            this.buttonAspr.Click += new System.EventHandler(this.buttonAspr_Click);
            // 
            // Form2
            // 
            this.ClientSize = new System.Drawing.Size(182, 137);
            this.Controls.Add(this.buttonAspr);
            this.Controls.Add(this.buttonHide);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button1Fr2Copy);
            this.Name = "Form2";
            this.Opacity = 0.9D;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.ResumeLayout(false);

    }

        #endregion
        private System.Windows.Forms.Button button1Fr2Copy;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonHide;
        private System.Windows.Forms.Button buttonAspr;
    }
}