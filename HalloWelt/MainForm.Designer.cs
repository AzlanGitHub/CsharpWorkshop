namespace HalloWelt
{
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      btnClear = new Button();
      btnShow = new Button();
      SuspendLayout();
      // 
      // btnClear
      // 
      btnClear.Font = new Font("Georgia", 12F);
      btnClear.Location = new Point(435, 453);
      btnClear.Margin = new Padding(4, 3, 4, 3);
      btnClear.Name = "btnClear";
      btnClear.Size = new Size(252, 40);
      btnClear.TabIndex = 0;
      btnClear.Text = "Hide Message";
      btnClear.UseVisualStyleBackColor = true;
      btnClear.Click += btnClear_Click;
      // 
      // btnShow
      // 
      btnShow.Font = new Font("Georgia", 12F);
      btnShow.Location = new Point(435, 521);
      btnShow.Margin = new Padding(4, 3, 4, 3);
      btnShow.Name = "btnShow";
      btnShow.Size = new Size(252, 40);
      btnShow.TabIndex = 1;
      btnShow.Text = "Show Message";
      btnShow.UseVisualStyleBackColor = true;
      btnShow.Click += btnShow_Click;
      // 
      // MainForm
      // 
      AutoScaleDimensions = new SizeF(14F, 29F);
      AutoScaleMode = AutoScaleMode.Font;
      ClientSize = new Size(1120, 595);
      Controls.Add(btnShow);
      Controls.Add(btnClear);
      Font = new Font("Georgia", 12F);
      Margin = new Padding(4, 3, 4, 3);
      Name = "MainForm";
      Text = "Form1";
      Load += MainForm_Load;
      Resize += MainForm_Resize;
      ResumeLayout(false);
    }

    #endregion

    private Button btnClear;
    private Button btnShow;
  }
}
