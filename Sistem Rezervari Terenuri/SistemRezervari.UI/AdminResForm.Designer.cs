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
        listboxReservations = new System.Windows.Forms.ListBox();
        label1 = new System.Windows.Forms.Label();
        labelUser = new System.Windows.Forms.Label();
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
        label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.Location = new System.Drawing.Point(451, 39);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(171, 50);
        label1.TabIndex = 1;
        label1.Text = "Info:";
        label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // labelUser
        // 
        labelUser.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        labelUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
        labelUser.Location = new System.Drawing.Point(306, 109);
        labelUser.Name = "labelUser";
        labelUser.Size = new System.Drawing.Size(422, 39);
        labelUser.TabIndex = 2;
        labelUser.Text = "Made by:";
        labelUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        labelUser.Visible = false;
        // 
        // AdminResForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(labelUser);
        Controls.Add(label1);
        Controls.Add(listboxReservations);
        Text = "AdminResForm";
        Load += AdminResForm_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.Label labelUser;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.ListBox listboxReservations;

    #endregion
}