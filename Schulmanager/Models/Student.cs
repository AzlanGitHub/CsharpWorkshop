
using System.Collections;
using System.ComponentModel;

namespace Schulmanager.Models;
public partial class Student: INotifyPropertyChanged, INotifyDataErrorInfo
{
    public event PropertyChangedEventHandler PropertyChanged;
    public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

  private int _studentId;
  public int StudentId { 
    get => _studentId; 
    set { 
      _studentId = value; 
      OnPropertyChanged(nameof(StudentId)); 
    } 
  }
  private string _vorname;
  public string Vorname
  {
    get => _vorname;
    set{ 
      _vorname = value; 
      OnPropertyChanged(nameof(Vorname)); 
      ValidateProperty(nameof(Vorname)); 
    }
  }
  private string _nachname;
  public string Nachname
  {
    get => _nachname;
    set { 
      _nachname = value; 
      OnPropertyChanged(nameof(Nachname)); 
      ValidateProperty(nameof(Nachname)); 
    }
  }
  // Wir speichern Geburtsdatum als DateOnly wie in deinem Projekt
  private DateOnly _geburtsdatum;
  public DateOnly Geburtsdatum
  {
    get => _geburtsdatum;
    set { 
      _geburtsdatum = value; 
      OnPropertyChanged(nameof(Geburtsdatum)); 
      ValidateProperty(nameof(Geburtsdatum)); 
    }
  }
  private string _strasse;
  public string Strasse
  {
    get => _strasse;
    set { 
      _strasse = value; 
      OnPropertyChanged(nameof(Strasse)); 
      ValidateProperty(nameof(Strasse)); 
    }
  }
  private string _stadt;
  public string Stadt
  {
    get => _stadt;
    set{ 
      _stadt = value; 
      OnPropertyChanged(nameof(Stadt)); 
      ValidateProperty(nameof(Stadt)); 
    }
  }
  // Fehlerverwaltung
  private readonly Dictionary<string, List<string>> _errors = new();
  public bool HasErrors => _errors.Any();
  public IEnumerable GetErrors(string propertyName)
  {
    if (string.IsNullOrEmpty(propertyName))
      return _errors.SelectMany(kv => kv.Value);
    return _errors.ContainsKey(propertyName) ? _errors[propertyName] : Enumerable.Empty<string>();
  }

  private void OnPropertyChanged(string propertyName) =>
      PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
  private void AddError(string propertyName, string error)
  {
    if (!_errors.ContainsKey(propertyName)) _errors[propertyName] = new List<string>();
    if (!_errors[propertyName].Contains(error))
    {
      _errors[propertyName].Add(error);
      ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
    }
  }
  private void ClearErrors(string propertyName)
  {
    if (_errors.Remove(propertyName))
      ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
  }
  private void ValidateProperty(string propertyName)
  {
    switch (propertyName)
    {
      case nameof(Vorname):
        ClearErrors(nameof(Vorname));
        if (string.IsNullOrWhiteSpace(Vorname))
          AddError(nameof(Vorname), "Vorname ist erforderlich.");
        else if (Vorname.Length > 50)
          AddError(nameof(Vorname), "Vorname darf max. 50 Zeichen haben.");
        break;

      case nameof(Nachname):
        ClearErrors(nameof(Nachname));
        if (string.IsNullOrWhiteSpace(Nachname))
          AddError(nameof(Nachname), "Nachname ist erforderlich.");
        else if (Nachname.Length > 50)
          AddError(nameof(Nachname), "Nachname darf max. 50 Zeichen haben.");
        break;

      case nameof(Geburtsdatum):
        ClearErrors(nameof(Geburtsdatum));
        // Altersprüfung: z.B. zwischen 5 und 120 Jahren
        var today = DateOnly.FromDateTime(DateTime.Today);
        var age = today.Year - Geburtsdatum.Year - (today < Geburtsdatum.AddYears(today.Year - Geburtsdatum.Year) ? 1 : 0);
        if (Geburtsdatum > today)
          AddError(nameof(Geburtsdatum), "Geburtsdatum darf nicht in der Zukunft liegen.");
        else if (age < 5)
          AddError(nameof(Geburtsdatum), "Schüler muss mindestens 5 Jahre alt sein.");
        else if (age > 120)
          AddError(nameof(Geburtsdatum), "Ungültiges Geburtsdatum.");
        break;

      case nameof(Strasse):
        ClearErrors(nameof(Strasse));
        if (!string.IsNullOrEmpty(Strasse) && Strasse.Length > 100)
          AddError(nameof(Strasse), "Straße darf max. 100 Zeichen haben.");
        break;

      case nameof(Stadt):
        ClearErrors(nameof(Stadt));
        if (!string.IsNullOrEmpty(Stadt) && Stadt.Length > 100)
          AddError(nameof(Stadt), "Stadt darf max. 100 Zeichen haben.");
        break;
    }
  }
    // Foreign Key 
    // Beziehung zu Klasse und anderen Entitäten
  public int? KlasseId { get; set; }
    public virtual ICollection<Anwesenheit> Anwesenheits { get; set; } = new List<Anwesenheit>();
    public virtual Klasse? Klasse { get; set; }
    public virtual ICollection<Noten> Notens { get; set; } = new List<Noten>();
    public virtual ICollection<StudentFach> StudentFaches { get; set; } = new List<StudentFach>();

}
