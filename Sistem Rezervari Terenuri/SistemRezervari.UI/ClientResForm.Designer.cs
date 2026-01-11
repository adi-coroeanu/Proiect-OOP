using System.ComponentModel;

namespace SistemRezervari.UI;

partial class ClientResForm
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
        listBoxAvailable = new ListBox();
        btnReservation = new Button();
        SuspendLayout();
        // 
        // listBoxAvailable
        // 
        listBoxAvailable.FormattingEnabled = true;
        listBoxAvailable.Location = new Point(40, 83);
        listBoxAvailable.Margin = new Padding(3, 4, 3, 4);
        listBoxAvailable.Name = "listBoxAvailable";
        listBoxAvailable.Size = new Size(278, 384);
        listBoxAvailable.TabIndex = 0;
        // 
        // btnReservation
        // 
        btnReservation.Location = new Point(384, 218);
        btnReservation.Name = "btnReservation";
        btnReservation.Size = new Size(175, 63);
        btnReservation.TabIndex = 1;
        btnReservation.Text = "Make a reservation";
        btnReservation.UseVisualStyleBackColor = true;
        btnReservation.Click += btnReservation_Click;
        // 
        // ClientResForm
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(914, 600);
        Controls.Add(btnReservation);
        Controls.Add(listBoxAvailable);
        Margin = new Padding(3, 4, 3, 4);
        Name = "ClientResForm";
        Text = "ClientResForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox listBoxAvailable;

    #endregion

    private Button btnReservation;
}