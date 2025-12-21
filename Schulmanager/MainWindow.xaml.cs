using Schulmanager.ViewModels;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;


namespace Schulmanager
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {

    private static readonly Regex _lettersRegex = new(@"^[a-zA-ZäöüÄÖÜß\s-]+$");
    public MainWindow()
    {
      InitializeComponent();
      this.DataContext = new StudentViewModel();

    }
    private void OnlyLetters_PreviewTextInput(object sender, TextCompositionEventArgs e)
    {
      e.Handled = !_lettersRegex.IsMatch(e.Text);
    }


    private void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
    {
      if (e.DataObject.GetDataPresent(DataFormats.Text))
      {
        var text = e.DataObject.GetData(DataFormats.Text) as string;
        if (string.IsNullOrEmpty(text) || !_lettersRegex.IsMatch(text))
          e.CancelCommand();
      }
      else e.CancelCommand();
    }

  }
}