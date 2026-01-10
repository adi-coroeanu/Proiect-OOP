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
        labelLoad = new System.Windows.Forms.Label();
        listboxFields = new System.Windows.Forms.ListBox();
        comboBoxSport = new System.Windows.Forms.ComboBox();
        listBoxRes = new System.Windows.Forms.ListBox();
        labelRes = new System.Windows.Forms.Label();
        labelUser = new System.Windows.Forms.Label();
        btnView = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        SuspendLayout();
        // 
        // labelLoad
        // 
        labelLoad.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelLoad.Location = new System.Drawing.Point(273, 42);
        labelLoad.Name = "labelLoad";
        labelLoad.Size = new System.Drawing.Size(235, 53);
        labelLoad.TabIndex = 7;
        labelLoad.Text = "Choose a sport:";
        labelLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // listboxFields
        // 
        listboxFields.FormattingEnabled = true;
        listboxFields.ItemHeight = 15;
        listboxFields.Location = new System.Drawing.Point(370, 64);
        listboxFields.Name = "listboxFields";
        listboxFields.Size = new System.Drawing.Size(235, 244);
        listboxFields.TabIndex = 3;
        listboxFields.Visible = false;
        listboxFields.SelectedIndexChanged += listboxFields_SelectedIndexChanged;
        // 
        // comboBoxSport
        // 
        comboBoxSport.FormattingEnabled = true;
        comboBoxSport.Items.AddRange(new object[] { "Fotbal", "Baschet", "Tenis" });
        comboBoxSport.Location = new System.Drawing.Point(313, 98);
        comboBoxSport.Name = "comboBoxSport";
        comboBoxSport.Size = new System.Drawing.Size(166, 23);
        comboBoxSport.TabIndex = 4;
        comboBoxSport.SelectedIndexChanged += comboBoxSport_SelectedIndexChanged;
        // 
        // listBoxRes
        // 
        listBoxRes.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        listBoxRes.FormattingEnabled = true;
        listBoxRes.ItemHeight = 21;
        listBoxRes.Items.AddRange(new object[] { "No active reservation" });
        listBoxRes.Location = new System.Drawing.Point(5, 64);
        listBoxRes.Name = "listBoxRes";
        listBoxRes.Size = new System.Drawing.Size(235, 235);
        listBoxRes.TabIndex = 5;
        listBoxRes.SelectedIndexChanged += listBoxRes_SelectedIndexChanged;
        // 
        // labelRes
        // 
        labelRes.BackColor = System.Drawing.Color.Transparent;
        labelRes.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelRes.Location = new System.Drawing.Point(5, 27);
        labelRes.Name = "labelRes";
        labelRes.Size = new System.Drawing.Size(235, 34);
        labelRes.TabIndex = 6;
        labelRes.Text = "Active reservations";
        labelRes.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        // 
        // labelUser
        // 
        labelUser.BackColor = System.Drawing.Color.Transparent;
        labelUser.Location = new System.Drawing.Point(622, 4);
        labelUser.Name = "labelUser";
        labelUser.Size = new System.Drawing.Size(169, 38);
        labelUser.TabIndex = 8;
        labelUser.Text = "Welcome back, ...";
        // 
        // btnView
        // 
        btnView.Location = new System.Drawing.Point(645, 210);
        btnView.Name = "btnView";
        btnView.Size = new System.Drawing.Size(127, 44);
        btnView.TabIndex = 9;
        btnView.Text = "View";
        btnView.UseVisualStyleBackColor = true;
        btnView.Visible = false;
        btnView.Click += btnView_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new System.Drawing.Point(5, 305);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new System.Drawing.Size(125, 44);
        btnDelete.TabIndex = 10;
        btnDelete.Text = "Delete";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Visible = false;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new System.Drawing.Point(645, 136);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new System.Drawing.Size(127, 23);
        dateTimePicker1.TabIndex = 11;
        dateTimePicker1.Visible = false;
        // 
        // ClientForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.SystemColors.Control;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(dateTimePicker1);
        Controls.Add(btnDelete);
        Controls.Add(btnView);
        Controls.Add(labelUser);
        Controls.Add(labelRes);
        Controls.Add(listBoxRes);
        Controls.Add(comboBoxSport);
        Controls.Add(listboxFields);
        Controls.Add(labelLoad);
        Location = new System.Drawing.Point(15, 15);
        Text = "Client";
        Click += ClientForm_Click;
        ResumeLayout(false);
    }

    private System.Windows.Forms.DateTimePicker dateTimePicker1;

    private System.Windows.Forms.Button btnDelete;

    private System.Windows.Forms.Button btnView;

    private System.Windows.Forms.Label labelLoad;
    private System.Windows.Forms.ListBox listboxFields;
    private System.Windows.Forms.ComboBox comboBoxSport;
    private System.Windows.Forms.ListBox listBoxRes;
    private System.Windows.Forms.Label labelRes;
    private System.Windows.Forms.Label labelUser;

    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox textBox3;

    #endregion
}