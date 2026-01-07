using System.ComponentModel;

namespace SistemRezervari.UI;

partial class ClientForm
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
        txtStart = new System.Windows.Forms.TextBox();
        listBox1 = new System.Windows.Forms.ListBox();
        txtSport = new System.Windows.Forms.TextBox();
        txtEnd = new System.Windows.Forms.TextBox();
        button1 = new System.Windows.Forms.Button();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        comboBox1 = new System.Windows.Forms.ComboBox();
        SuspendLayout();
        // 
        // txtStart
        // 
        txtStart.Location = new System.Drawing.Point(51, 61);
        txtStart.Name = "txtStart";
        txtStart.Size = new System.Drawing.Size(171, 23);
        txtStart.TabIndex = 1;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.ItemHeight = 15;
        listBox1.Location = new System.Drawing.Point(344, 18);
        listBox1.Name = "listBox1";
        listBox1.Size = new System.Drawing.Size(235, 109);
        listBox1.TabIndex = 3;
        // 
        // txtSport
        // 
        txtSport.Location = new System.Drawing.Point(51, 18);
        txtSport.Name = "txtSport";
        txtSport.Size = new System.Drawing.Size(171, 23);
        txtSport.TabIndex = 4;
        // 
        // txtEnd
        // 
        txtEnd.Location = new System.Drawing.Point(51, 104);
        txtEnd.Name = "txtEnd";
        txtEnd.Size = new System.Drawing.Size(171, 23);
        txtEnd.TabIndex = 5;
        // 
        // button1
        // 
        button1.Location = new System.Drawing.Point(56, 147);
        button1.Name = "button1";
        button1.Size = new System.Drawing.Size(165, 31);
        button1.TabIndex = 6;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dateTimePicker1.Location = new System.Drawing.Point(51, 216);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new System.Drawing.Size(125, 23);
        dateTimePicker1.TabIndex = 7;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Items.AddRange(new object[] { "Fotbal", "Baschet", "Tenis" });
        comboBox1.Location = new System.Drawing.Point(57, 268);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new System.Drawing.Size(118, 23);
        comboBox1.TabIndex = 8;
        // 
        // ClientForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(comboBox1);
        Controls.Add(dateTimePicker1);
        Controls.Add(button1);
        Controls.Add(txtEnd);
        Controls.Add(txtSport);
        Controls.Add(listBox1);
        Controls.Add(txtStart);
        Text = "Client";
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ComboBox comboBox1;

    private System.Windows.Forms.DateTimePicker dateTimePicker1;

    private System.Windows.Forms.TextBox txtSport;
    private System.Windows.Forms.Button button1;

    private System.Windows.Forms.TextBox txtStart;

    private System.Windows.Forms.ListBox listBox1;

    private System.Windows.Forms.TextBox txtEnd;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;

    #endregion
}