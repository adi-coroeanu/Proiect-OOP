namespace SistemRezervari.UI;

partial class AdminForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        button1 = new System.Windows.Forms.Button();
        listBox1 = new System.Windows.Forms.ListBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(643, 40);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(132, 42);
        button1.TabIndex = 0;
        button1.Text = "Add Field";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // listBox1
        // 
        listBox1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)224)), ((int)((byte)192)));
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Location = new System.Drawing.Point(12, 40);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(271, 229);
        listBox1.TabIndex = 2;
        // 
        // AdminForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(989, 464);
        Controls.Add(listBox1);
        Controls.Add(button1);
        Text = "Admin";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.Button button1;

    #endregion
}