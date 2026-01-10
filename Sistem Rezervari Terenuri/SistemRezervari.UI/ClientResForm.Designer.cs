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
        listBoxAvailable = new System.Windows.Forms.ListBox();
        SuspendLayout();
        // 
        // listBoxAvailable
        // 
        listBoxAvailable.FormattingEnabled = true;
        listBoxAvailable.ItemHeight = 15;
        listBoxAvailable.Location = new System.Drawing.Point(35, 62);
        listBoxAvailable.Name = "listBoxAvailable";
        listBoxAvailable.Size = new System.Drawing.Size(244, 289);
        listBoxAvailable.TabIndex = 0;
        // 
        // ClientResForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(listBoxAvailable);
        Text = "ClientResForm";
        ResumeLayout(false);
    }

    private System.Windows.Forms.ListBox listBoxAvailable;

    #endregion
}