using System.ComponentModel;

namespace SistemRezervari.UI;

partial class AdminResForm
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminResForm));
        listboxReservations = new System.Windows.Forms.ListBox();
        label1 = new System.Windows.Forms.Label();
        labelUser = new System.Windows.Forms.Label();
        txtFrom = new System.Windows.Forms.TextBox();
        labelTo = new System.Windows.Forms.Label();
        txtTo = new System.Windows.Forms.TextBox();
        labelFrom = new System.Windows.Forms.Label();
        labelDay = new System.Windows.Forms.Label();
        dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
        btnModify = new System.Windows.Forms.Button();
        label2 = new System.Windows.Forms.Label();
        btnRemove = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // listboxReservations
        // 
        listboxReservations.FormattingEnabled = true;
        listboxReservations.ItemHeight = 15;
        listboxReservations.Location = new System.Drawing.Point(29, 39);
        listboxReservations.Name = "listboxReservations";
        listboxReservations.Size = new System.Drawing.Size(241, 364);
        listboxReservations.TabIndex = 0;
        listboxReservations.SelectedIndexChanged += listboxReservations_SelectedIndexChanged;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.BackColor = System.Drawing.Color.Transparent;
        label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(303, 28);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(73, 40);
        label1.TabIndex = 1;
        label1.Text = "Info:";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        label1.Visible = false;
        // 
        // labelUser
        // 
        labelUser.BackColor = System.Drawing.Color.Transparent;
        labelUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        labelUser.Location = new System.Drawing.Point(303, 77);
        labelUser.Name = "labelUser";
        labelUser.Size = new System.Drawing.Size(422, 39);
        labelUser.TabIndex = 2;
        labelUser.Text = "Made by:";
        labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        labelUser.Visible = false;
        // 
        // txtFrom
        // 
        txtFrom.Location = new System.Drawing.Point(391, 195);
        txtFrom.Name = "txtFrom";
        txtFrom.Size = new System.Drawing.Size(154, 23);
        txtFrom.TabIndex = 3;
        txtFrom.Visible = false;
        // 
        // labelTo
        // 
        labelTo.BackColor = System.Drawing.Color.Transparent;
        labelTo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelTo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        labelTo.Location = new System.Drawing.Point(303, 233);
        labelTo.Name = "labelTo";
        labelTo.Size = new System.Drawing.Size(82, 29);
        labelTo.TabIndex = 5;
        labelTo.Text = "To:";
        labelTo.Visible = false;
        // 
        // txtTo
        // 
        txtTo.Enabled = false;
        txtTo.Location = new System.Drawing.Point(391, 233);
        txtTo.Name = "txtTo";
        txtTo.Size = new System.Drawing.Size(154, 23);
        txtTo.TabIndex = 6;
        txtTo.Visible = false;
        // 
        // labelFrom
        // 
        labelFrom.BackColor = System.Drawing.Color.Transparent;
        labelFrom.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelFrom.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        labelFrom.Location = new System.Drawing.Point(303, 189);
        labelFrom.Name = "labelFrom";
        labelFrom.Size = new System.Drawing.Size(82, 29);
        labelFrom.TabIndex = 7;
        labelFrom.Text = "From:";
        labelFrom.Visible = false;
        // 
        // labelDay
        // 
        labelDay.BackColor = System.Drawing.Color.Transparent;
        labelDay.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelDay.Location = new System.Drawing.Point(303, 146);
        labelDay.Name = "labelDay";
        labelDay.Size = new System.Drawing.Size(82, 29);
        labelDay.TabIndex = 8;
        labelDay.Text = "Day:";
        labelDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        labelDay.Visible = false;
        // 
        // dateTimePicker1
        // 
        dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dateTimePicker1.Location = new System.Drawing.Point(395, 154);
        dateTimePicker1.Name = "dateTimePicker1";
        dateTimePicker1.Size = new System.Drawing.Size(149, 23);
        dateTimePicker1.TabIndex = 9;
        dateTimePicker1.Visible = false;
        // 
        // btnModify
        // 
        btnModify.Location = new System.Drawing.Point(613, 150);
        btnModify.Name = "btnModify";
        btnModify.Size = new System.Drawing.Size(133, 53);
        btnModify.TabIndex = 10;
        btnModify.Text = "Modify";
        btnModify.UseVisualStyleBackColor = true;
        btnModify.Visible = false;
        btnModify.Click += btnModify_Click;
        // 
        // label2
        // 
        label2.BackColor = System.Drawing.Color.Transparent;
        label2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.Location = new System.Drawing.Point(29, 5);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(240, 34);
        label2.TabIndex = 11;
        label2.Text = "Select a reservation:";
        label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // btnRemove
        // 
        btnRemove.Location = new System.Drawing.Point(613, 209);
        btnRemove.Name = "btnRemove";
        btnRemove.Size = new System.Drawing.Size(133, 53);
        btnRemove.TabIndex = 12;
        btnRemove.Text = "Remove";
        btnRemove.UseVisualStyleBackColor = true;
        btnRemove.Visible = false;
        btnRemove.Click += btnRemove_Click;
        // 
        // AdminResForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackgroundImage = ((System.Drawing.Image)resources.GetObject("$this.BackgroundImage"));
        BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(btnRemove);
        Controls.Add(label2);
        Controls.Add(btnModify);
        Controls.Add(dateTimePicker1);
        Controls.Add(labelDay);
        Controls.Add(labelFrom);
        Controls.Add(txtTo);
        Controls.Add(labelTo);
        Controls.Add(txtFrom);
        Controls.Add(labelUser);
        Controls.Add(label1);
        Controls.Add(listboxReservations);
        DoubleBuffered = true;
        Text = "AdminResForm";
        Load += AdminResForm_Load;
        Click += AdminResForm_Click;
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Button btnRemove;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Button btnModify;

    private System.Windows.Forms.DateTimePicker dateTimePicker1;

    private System.Windows.Forms.Label labelDay;

    private System.Windows.Forms.Label labelFrom;

    private System.Windows.Forms.Label labelTo;

    private System.Windows.Forms.TextBox txtTo;
    private System.Windows.Forms.TextBox txtFrom;

    private System.Windows.Forms.Label labelUser;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.ListBox listboxReservations;

    #endregion
}