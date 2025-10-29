namespace Autotrophe;

partial class MainForm
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
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        label3 = new System.Windows.Forms.Label();
        label4 = new System.Windows.Forms.Label();
        label5 = new System.Windows.Forms.Label();
        label6 = new System.Windows.Forms.Label();
        label7 = new System.Windows.Forms.Label();
        richTextBox1 = new System.Windows.Forms.RichTextBox();
        label8 = new System.Windows.Forms.Label();
        checkBox1 = new System.Windows.Forms.CheckBox();
        SuspendLayout();
        // 
        // label1
        // 
        label1.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label1.ForeColor = System.Drawing.Color.WhiteSmoke;
        label1.Location = new System.Drawing.Point(25, 25);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(254, 20);
        label1.TabIndex = 5;
        label1.Text = "Detected Characters";
        // 
        // label2
        // 
        label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        label2.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label2.ForeColor = System.Drawing.Color.Gainsboro;
        label2.Location = new System.Drawing.Point(25, 50);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(254, 20);
        label2.TabIndex = 6;
        // 
        // label3
        // 
        label3.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label3.ForeColor = System.Drawing.Color.WhiteSmoke;
        label3.Location = new System.Drawing.Point(25, 75);
        label3.Name = "label3";
        label3.Size = new System.Drawing.Size(254, 20);
        label3.TabIndex = 7;
        label3.Text = "Detected Word";
        // 
        // label4
        // 
        label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        label4.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label4.ForeColor = System.Drawing.Color.Gainsboro;
        label4.Location = new System.Drawing.Point(25, 100);
        label4.Name = "label4";
        label4.Size = new System.Drawing.Size(254, 20);
        label4.TabIndex = 8;
        // 
        // label5
        // 
        label5.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label5.ForeColor = System.Drawing.Color.WhiteSmoke;
        label5.Location = new System.Drawing.Point(25, 125);
        label5.Name = "label5";
        label5.Size = new System.Drawing.Size(254, 20);
        label5.TabIndex = 9;
        label5.Text = "Suggested Word";
        // 
        // label6
        // 
        label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        label6.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label6.ForeColor = System.Drawing.Color.Gainsboro;
        label6.Location = new System.Drawing.Point(25, 150);
        label6.Name = "label6";
        label6.Size = new System.Drawing.Size(254, 20);
        label6.TabIndex = 10;
        // 
        // label7
        // 
        label7.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label7.ForeColor = System.Drawing.Color.WhiteSmoke;
        label7.Location = new System.Drawing.Point(316, 25);
        label7.Name = "label7";
        label7.Size = new System.Drawing.Size(472, 20);
        label7.TabIndex = 11;
        label7.Text = "Word Candidates";
        // 
        // richTextBox1
        // 
        richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)((byte)43)), ((int)((byte)45)), ((int)((byte)48)));
        richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        richTextBox1.ForeColor = System.Drawing.Color.Gainsboro;
        richTextBox1.Location = new System.Drawing.Point(316, 62);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.ReadOnly = true;
        richTextBox1.Size = new System.Drawing.Size(472, 376);
        richTextBox1.TabIndex = 12;
        richTextBox1.Text = "";
        // 
        // label8
        // 
        label8.Font = new System.Drawing.Font("Bahnschrift", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
        label8.ForeColor = System.Drawing.Color.WhiteSmoke;
        label8.Location = new System.Drawing.Point(25, 418);
        label8.Name = "label8";
        label8.Size = new System.Drawing.Size(254, 20);
        label8.TabIndex = 13;
        label8.Text = "Run at Startup";
        // 
        // checkBox1
        // 
        checkBox1.Location = new System.Drawing.Point(267, 423);
        checkBox1.Name = "checkBox1";
        checkBox1.Size = new System.Drawing.Size(12, 15);
        checkBox1.TabIndex = 14;
        checkBox1.Text = "checkBox1";
        checkBox1.UseVisualStyleBackColor = true;
        checkBox1.CheckedChanged += checkBox1_CheckedChanged;
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        BackColor = System.Drawing.Color.FromArgb(((int)((byte)43)), ((int)((byte)45)), ((int)((byte)48)));
        ClientSize = new System.Drawing.Size(800, 450);
        Controls.Add(checkBox1);
        Controls.Add(label8);
        Controls.Add(richTextBox1);
        Controls.Add(label7);
        Controls.Add(label6);
        Controls.Add(label5);
        Controls.Add(label4);
        Controls.Add(label3);
        Controls.Add(label2);
        Controls.Add(label1);
        Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)0));
        Location = new System.Drawing.Point(15, 15);
        Text = "Autotrophe";
        Load += MainForm_Load;
        ResumeLayout(false);
    }

    private System.Windows.Forms.CheckBox checkBox1;

    private System.Windows.Forms.Label label8;

    private System.Windows.Forms.RichTextBox richTextBox1;

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label7;

    private System.Windows.Forms.Label label1;

    #endregion
}