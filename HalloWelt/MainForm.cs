namespace HalloWelt
{
  public partial class MainForm : Form
  {
    public MainForm()
    {
      InitializeComponent();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      base.OnPaint(e);
      DrawMessageString(e);
    }

    private void DrawMessageString(PaintEventArgs e)
    {
      if (showText)
      {

        using (Font font = new Font("Arial", 24, FontStyle.Bold))
        using (Brush brush = new SolidBrush(Color.DarkBlue))
        {
          SizeF textSize = e.Graphics.MeasureString("Hallo Welt", font);
          float x = (this.ClientSize.Width - textSize.Width) / 2;
          float y = (this.ClientSize.Height - textSize.Height) / 2;
          e.Graphics.DrawString("Hallo Welt", font, brush, x, y);
        }
      }
    }

    private bool showText = true;
    private void btnClear_Click(object sender, EventArgs e)
    {
      showText = false;
      this.Invalidate();

    }

    private void btnShow_Click(object sender, EventArgs e)
    {
      showText = true;
      this.Invalidate();
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
      PutButtonCenter();
    }
    public void PutButtonCenter()
    {
      btnClear.Left = (this.ClientSize.Width - btnClear.Width) / 2;
      btnClear.Top = (this.ClientSize.Height - btnClear.Height)/2 + 70;
      btnShow.Left = (this.ClientSize.Width - btnShow.Width)/2;
      btnShow.Top = (this.ClientSize.Height - btnShow.Height)/2 + 120;

    }

    private void MainForm_Resize(object sender, EventArgs e)
    {
      PutButtonCenter();
      this.Invalidate();
   
    }
  }
}
