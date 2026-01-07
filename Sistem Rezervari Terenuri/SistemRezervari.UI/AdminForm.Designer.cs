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
        textBox1 = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        textBox3 = new System.Windows.Forms.TextBox();
        textBox4 = new System.Windows.Forms.TextBox();
        textBox5 = new System.Windows.Forms.TextBox();
        textBox6 = new System.Windows.Forms.TextBox();
        button2 = new System.Windows.Forms.Button();
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
        // textBox1
        // 
        textBox1.Location = new System.Drawing.Point(346, 43);
        textBox1.Name = "textBox1";
        textBox1.Size = new System.Drawing.Size(129, 23);
        textBox1.TabIndex = 3;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(346, 72);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(129, 23);
        textBox2.TabIndex = 4;
        // 
        // textBox3
        // 
        textBox3.Location = new System.Drawing.Point(346, 101);
        textBox3.Name = "textBox3";
        textBox3.Size = new System.Drawing.Size(129, 23);
        textBox3.TabIndex = 5;
        // 
        // textBox4
        // 
        textBox4.Location = new System.Drawing.Point(346, 130);
        textBox4.Name = "textBox4";
        textBox4.Size = new System.Drawing.Size(129, 23);
        textBox4.TabIndex = 8;
        // 
        // textBox5
        // 
        textBox5.Location = new System.Drawing.Point(346, 159);
        textBox5.Name = "textBox5";
        textBox5.Size = new System.Drawing.Size(129, 23);
        textBox5.TabIndex = 7;
        // 
        // textBox6
        // 
        textBox6.Location = new System.Drawing.Point(346, 188);
        textBox6.Name = "textBox6";
        textBox6.Size = new System.Drawing.Size(129, 23);
        textBox6.TabIndex = 6;
        // 
        // button2
        // 
        button2.Location = new System.Drawing.Point(645, 103);
        button2.Name = "button2";
        button2.Size = new System.Drawing.Size(129, 49);
        button2.TabIndex = 9;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // AdminForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(989, 464);
        Controls.Add(button2);
        Controls.Add(textBox4);
        Controls.Add(textBox5);
        Controls.Add(textBox6);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(listBox1);
        Controls.Add(button1);
        Text = "Admin";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;
    private System.Windows.Forms.TextBox textBox4;
    private System.Windows.Forms.TextBox textBox5;
    private System.Windows.Forms.TextBox textBox6;
    private System.Windows.Forms.Button button2;

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.Button button1;

    #endregion
}