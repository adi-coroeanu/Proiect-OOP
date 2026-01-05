using System.ComponentModel;

namespace SistemRezervari.UI;

partial class LogInForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInForm));
        tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        btnLogIn = new System.Windows.Forms.Button();
        labelPass = new System.Windows.Forms.Label();
        labelUser = new System.Windows.Forms.Label();
        tableLayoutPanel1.SuspendLayout();
        SuspendLayout();
        // 
        // tableLayoutPanel1
        // 
        tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
        tableLayoutPanel1.ColumnCount = 2;
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.25F));
        tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.75F));
        tableLayoutPanel1.Controls.Add(textBox1, 1, 0);
        tableLayoutPanel1.Controls.Add(textBox2, 1, 1);
        tableLayoutPanel1.Controls.Add(btnLogIn, 1, 2);
        tableLayoutPanel1.Controls.Add(labelPass, 0, 1);
        tableLayoutPanel1.Controls.Add(labelUser, 0, 0);
        tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
        tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
        tableLayoutPanel1.Name = "tableLayoutPanel1";
        tableLayoutPanel1.RowCount = 3;
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
        tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 102F));
        tableLayoutPanel1.Size = new System.Drawing.Size(800, 310);
        tableLayoutPanel1.TabIndex = 0;
        // 
        // textBox1
        // 
        textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
        textBox1.Location = new System.Drawing.Point(301, 78);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(196, 23);
        textBox1.TabIndex = 0;
        // 
        // textBox2
        // 
        textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left));
        textBox2.Location = new System.Drawing.Point(301, 125);
        textBox2.Margin = new System.Windows.Forms.Padding(3, 3, 3, 60);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(196, 23);
        textBox2.TabIndex = 1;
        // 
        // btnLogIn
        // 
        btnLogIn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
        btnLogIn.Location = new System.Drawing.Point(338, 211);
        btnLogIn.Margin = new System.Windows.Forms.Padding(40, 3, 3, 3);
        btnLogIn.Name = "btnLogIn";
        btnLogIn.Size = new System.Drawing.Size(108, 45);
        btnLogIn.TabIndex = 2;
        btnLogIn.Text = "Log In";
        btnLogIn.UseVisualStyleBackColor = true;
        // 
        // labelPass
        // 
        labelPass.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        labelPass.Location = new System.Drawing.Point(205, 125);
        labelPass.Margin = new System.Windows.Forms.Padding(3, 0, 3, 60);
        labelPass.Name = "labelPass";
        labelPass.Size = new System.Drawing.Size(90, 23);
        labelPass.TabIndex = 4;
        labelPass.Text = "Password:";
        labelPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // labelUser
        // 
        labelUser.Anchor = ((System.Windows.Forms.AnchorStyles)(System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right));
        labelUser.Location = new System.Drawing.Point(205, 78);
        labelUser.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
        labelUser.Name = "labelUser";
        labelUser.Size = new System.Drawing.Size(90, 23);
        labelUser.TabIndex = 5;
        labelUser.Text = "Username:";
        labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        // 
        // LogInForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImage = ((System.Drawing.Image)resources.GetObject("$this.BackgroundImage"));
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(tableLayoutPanel1);
        Text = "Logging";
        tableLayoutPanel1.ResumeLayout(false);
        tableLayoutPanel1.PerformLayout();
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label labelUser;

    private System.Windows.Forms.Label labelPass;

    private System.Windows.Forms.Button btnLogIn;

    private System.Windows.Forms.TextBox textBox2;

    private System.Windows.Forms.TextBox textBox1;

    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

    #endregion
}