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
        components = new System.ComponentModel.Container();
        btnView = new System.Windows.Forms.Button();
        listboxFields = new System.Windows.Forms.ListBox();
        txtName = new System.Windows.Forms.TextBox();
        textBox2 = new System.Windows.Forms.TextBox();
        txtCapacity = new System.Windows.Forms.TextBox();
        txtOpenFT = new System.Windows.Forms.TextBox();
        txtClosedFT = new System.Windows.Forms.TextBox();
        txtMaxRes = new System.Windows.Forms.TextBox();
        btnAdd = new System.Windows.Forms.Button();
        txtResDur = new System.Windows.Forms.TextBox();
        btnRemove = new System.Windows.Forms.Button();
        btnModify = new System.Windows.Forms.Button();
        txtUser = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        label8 = new System.Windows.Forms.Label();
        errorProvider1 = new System.Windows.Forms.ErrorProvider(components);
        comboBoxType = new System.Windows.Forms.ComboBox();
        ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
        SuspendLayout();
        // 
        // btnView
        // 
        btnView.Location = new System.Drawing.Point(78, 295);
        btnView.Name = "btnView";
        btnView.Size = new System.Drawing.Size(132, 42);
        btnView.TabIndex = 0;
        btnView.Text = "View Reservations";
        btnView.UseVisualStyleBackColor = true;
        btnView.Click += btnView_Click;
        // 
        // listboxFields
        // 
        listboxFields.BackColor = System.Drawing.Color.FromArgb(((int)((byte)255)), ((int)((byte)224)), ((int)((byte)192)));
        listboxFields.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        listboxFields.FormattingEnabled = true;
        listboxFields.ItemHeight = 21;
        listboxFields.Location = new System.Drawing.Point(12, 66);
        listboxFields.Name = "listboxFields";
        listboxFields.Size = new System.Drawing.Size(271, 214);
        listboxFields.TabIndex = 2;
        listboxFields.SelectedIndexChanged += listboxFields_SelectedIndexChanged;
        // 
        // txtName
        // 
        txtName.Location = new System.Drawing.Point(486, 80);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(129, 23);
        txtName.TabIndex = 3;
        // 
        // textBox2
        // 
        textBox2.Location = new System.Drawing.Point(327, 40);
        textBox2.Name = "textBox2";
        textBox2.Size = new System.Drawing.Size(129, 23);
        textBox2.TabIndex = 4;
        // 
        // txtCapacity
        // 
        txtCapacity.Location = new System.Drawing.Point(486, 129);
        txtCapacity.Name = "txtCapacity";
        txtCapacity.Size = new System.Drawing.Size(129, 23);
        txtCapacity.TabIndex = 5;
        // 
        // txtOpenFT
        // 
        txtOpenFT.Location = new System.Drawing.Point(644, 129);
        txtOpenFT.Name = "txtOpenFT";
        txtOpenFT.Size = new System.Drawing.Size(129, 23);
        txtOpenFT.TabIndex = 8;
        // 
        // txtClosedFT
        // 
        txtClosedFT.Location = new System.Drawing.Point(328, 180);
        txtClosedFT.Name = "txtClosedFT";
        txtClosedFT.Size = new System.Drawing.Size(129, 23);
        txtClosedFT.TabIndex = 7;
        // 
        // txtMaxRes
        // 
        txtMaxRes.Location = new System.Drawing.Point(486, 180);
        txtMaxRes.Name = "txtMaxRes";
        txtMaxRes.Size = new System.Drawing.Size(129, 23);
        txtMaxRes.TabIndex = 6;
        // 
        // btnAdd
        // 
        btnAdd.Location = new System.Drawing.Point(334, 227);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(123, 42);
        btnAdd.TabIndex = 9;
        btnAdd.Text = "Add Field";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // txtResDur
        // 
        txtResDur.Location = new System.Drawing.Point(644, 180);
        txtResDur.Name = "txtResDur";
        txtResDur.Size = new System.Drawing.Size(129, 23);
        txtResDur.TabIndex = 10;
        // 
        // btnRemove
        // 
        btnRemove.Location = new System.Drawing.Point(486, 227);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new System.Drawing.Size(132, 42);
        btnRemove.TabIndex = 11;
        btnRemove.Text = "Remove Field";
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Click += btnRemove_Click;
        // 
        // btnModify
        // 
        btnModify.Location = new System.Drawing.Point(644, 227);
        btnModify.Name = "btnModify";
        btnModify.Size = new System.Drawing.Size(129, 42);
        btnModify.TabIndex = 12;
        btnModify.Text = "Modify";
        btnModify.UseVisualStyleBackColor = true;
        btnModify.Visible = false;
        btnModify.Click += btnModify_Click;
        // 
        // txtUser
        // 
        txtUser.Location = new System.Drawing.Point(684, 9);
        txtUser.Name = "txtUser";
        txtUser.Size = new System.Drawing.Size(129, 31);
        txtUser.TabIndex = 13;
        txtUser.Text = "Welcome back, ...";
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(486, 58);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(128, 22);
        label1.TabIndex = 14;
        label1.Text = "Name";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(328, 104);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(128, 22);
        label2.TabIndex = 15;
        label2.Text = "Sport Type";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label3
        // 
        label3.Location = new System.Drawing.Point(486, 104);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(128, 22);
        label3.TabIndex = 16;
        label3.Text = "Capacity";
        label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label4
        // 
        label4.Location = new System.Drawing.Point(645, 104);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(128, 22);
        label4.TabIndex = 17;
        label4.Text = "Open from/to";
        label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label5
        // 
        label5.Location = new System.Drawing.Point(329, 155);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(128, 22);
        label5.TabIndex = 18;
        label5.Text = "Closed from/to";
        label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label6
        // 
        label6.Location = new System.Drawing.Point(486, 155);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(128, 22);
        label6.TabIndex = 19;
        label6.Text = "Max Reservations";
        label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label7
        // 
        label7.Location = new System.Drawing.Point(645, 155);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(128, 22);
        label7.TabIndex = 20;
        label7.Text = "Reservation duration";
        label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // label8
        // 
        label8.Font = new System.Drawing.Font("Myanmar Text", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label8.Location = new System.Drawing.Point(12, 26);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(257, 37);
        label8.TabIndex = 21;
        label8.Text = "Select a field :";
        label8.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
        // 
        // errorProvider1
        // 
        errorProvider1.ContainerControl = this;
        // 
        // comboBoxType
        // 
        comboBoxType.FormattingEnabled = true;
        comboBoxType.Items.AddRange(new object[] { "Fotbal", "Baschet", "Tenis" });
        comboBoxType.Location = new System.Drawing.Point(329, 129);
        comboBoxType.Name = "comboBoxType";
        comboBoxType.Size = new System.Drawing.Size(127, 23);
        comboBoxType.TabIndex = 22;
        // 
        // AdminForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(825, 464);
        Controls.Add(comboBoxType);
        Controls.Add(label8);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(txtUser);
        Controls.Add(btnModify);
        Controls.Add(btnRemove);
        Controls.Add(txtResDur);
        Controls.Add(btnAdd);
        Controls.Add(txtOpenFT);
        Controls.Add(txtClosedFT);
        Controls.Add(txtMaxRes);
        Controls.Add(txtCapacity);
        Controls.Add(textBox2);
        Controls.Add(txtName);
        Controls.Add(listboxFields);
        Controls.Add(btnView);
        Text = "Admin";
        Load += AdminForm_Load;
        Click += AdminForm_Click;
        ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.ComboBox comboBoxType;

    private System.Windows.Forms.ErrorProvider errorProvider1;

    private System.Windows.Forms.Label label8;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Label txtUser;

    private System.Windows.Forms.Button btnModify;

    private System.Windows.Forms.Button btnRemove;

    private System.Windows.Forms.TextBox txtResDur;

    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.TextBox textBox2;
    private System.Windows.Forms.TextBox txtCapacity;
    private System.Windows.Forms.TextBox txtOpenFT;
    private System.Windows.Forms.TextBox txtClosedFT;
    private System.Windows.Forms.TextBox txtMaxRes;
    private System.Windows.Forms.Button btnAdd;

    private System.Windows.Forms.ListBox listboxFields;

    private System.Windows.Forms.Button btnView;

    #endregion
}