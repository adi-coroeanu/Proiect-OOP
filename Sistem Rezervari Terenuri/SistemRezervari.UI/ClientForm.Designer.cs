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
        ComponentResourceManager resources = new ComponentResourceManager(typeof(ClientForm));
        labelLoad = new Label();
        listboxFields = new ListBox();
        comboBoxSport = new ComboBox();
        listBoxRes = new ListBox();
        labelRes = new Label();
        labelUser = new Label();
        btnView = new Button();
        dateTimePicker1 = new DateTimePicker();
        btnCancel = new Button();
        SuspendLayout();
        // 
        // labelLoad
        // 
        labelLoad.BackColor = Color.Transparent;
        labelLoad.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelLoad.ForeColor = SystemColors.ControlText;
        labelLoad.Location = new Point(312, 56);
        labelLoad.Name = "labelLoad";
        labelLoad.Size = new Size(269, 71);
        labelLoad.TabIndex = 7;
        labelLoad.Text = "Choose a sport:";
        labelLoad.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // listboxFields
        // 
        listboxFields.FormattingEnabled = true;
        listboxFields.Location = new Point(416, 73);
        listboxFields.Margin = new Padding(3, 4, 3, 4);
        listboxFields.Name = "listboxFields";
        listboxFields.Size = new Size(268, 264);
        listboxFields.TabIndex = 3;
        listboxFields.Visible = false;
        listboxFields.SelectedIndexChanged += listboxFields_SelectedIndexChanged;
        // 
        // comboBoxSport
        // 
        comboBoxSport.FormattingEnabled = true;
        comboBoxSport.Items.AddRange(new object[] { "Fotbal", "Baschet", "Tenis" });
        comboBoxSport.Location = new Point(358, 131);
        comboBoxSport.Margin = new Padding(3, 4, 3, 4);
        comboBoxSport.Name = "comboBoxSport";
        comboBoxSport.Size = new Size(189, 28);
        comboBoxSport.TabIndex = 4;
        comboBoxSport.SelectedIndexChanged += comboBoxSport_SelectedIndexChanged;
        // 
        // listBoxRes
        // 
        listBoxRes.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        listBoxRes.FormattingEnabled = true;
        listBoxRes.ItemHeight = 28;
        listBoxRes.Items.AddRange(new object[] { "No active reservation" });
        listBoxRes.Location = new Point(6, 85);
        listBoxRes.Margin = new Padding(3, 4, 3, 4);
        listBoxRes.Name = "listBoxRes";
        listBoxRes.Size = new Size(268, 312);
        listBoxRes.TabIndex = 5;
        listBoxRes.SelectedIndexChanged += listBoxRes_SelectedIndexChanged;
        // 
        // labelRes
        // 
        labelRes.BackColor = Color.Transparent;
        labelRes.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
        labelRes.Location = new Point(6, 36);
        labelRes.Name = "labelRes";
        labelRes.Size = new Size(269, 45);
        labelRes.TabIndex = 6;
        labelRes.Text = "Active reservations";
        labelRes.TextAlign = ContentAlignment.BottomLeft;
        // 
        // labelUser
        // 
        labelUser.BackColor = Color.Transparent;
        labelUser.Location = new Point(711, 5);
        labelUser.Name = "labelUser";
        labelUser.Size = new Size(193, 51);
        labelUser.TabIndex = 8;
        labelUser.Text = "Welcome back, ...";
        // 
        // btnView
        // 
        btnView.Location = new Point(730, 268);
        btnView.Margin = new Padding(3, 4, 3, 4);
        btnView.Name = "btnView";
        btnView.Size = new Size(145, 59);
        btnView.TabIndex = 9;
        btnView.Text = "View";
        btnView.UseVisualStyleBackColor = true;
        btnView.Visible = false;
        btnView.Click += btnView_Click;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Location = new Point(730, 169);
        dateTimePicker1.Margin = new Padding(3, 4, 3, 4);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new Size(145, 27);
        dateTimePicker1.TabIndex = 11;
        dateTimePicker1.Visible = false;
        // 
        // btnCancel
        // 
        btnCancel.Location = new Point(6, 404);
        btnCancel.Name = "btnCancel";
        btnCancel.Size = new Size(132, 44);
        btnCancel.TabIndex = 13;
        btnCancel.Text = "Cancel";
        btnCancel.UseVisualStyleBackColor = true;
        btnCancel.Visible = false;
        btnCancel.Click += btnCancel_Click;
        // 
        // ClientForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.Control;
        BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
        BackgroundImageLayout = ImageLayout.Stretch;
        ClientSize = new Size(914, 600);
        Controls.Add(btnCancel);
        Controls.Add(dateTimePicker1);
        Controls.Add(btnView);
        Controls.Add(labelUser);
        Controls.Add(labelRes);
        Controls.Add(listBoxRes);
        Controls.Add(comboBoxSport);
        Controls.Add(listboxFields);
        Controls.Add(labelLoad);
        DoubleBuffered = true;
        Location = new Point(15, 15);
        Margin = new Padding(3, 4, 3, 4);
        Name = "ClientForm";
        Text = "Client";
        Click += ClientForm_Click;
        ResumeLayout(false);
    }

    private System.Windows.Forms.DateTimePicker dateTimePicker1;

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
    private Button btnCancel;
}