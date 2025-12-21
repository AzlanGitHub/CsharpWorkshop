using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore;
using Schulmanager.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace Schulmanager.ViewModels
{
  public partial class StudentViewModel: ObservableObject
  {
      private readonly SchoolDbContext _context;
      [ObservableProperty]
      private ObservableCollection<Student> _students;
      [ObservableProperty]
      private ObservableCollection<Klasse> _klassen;
      [ObservableProperty]
      private Student _selectedStudent;

      public StudentViewModel()
      {
        _context = new SchoolDbContext();
        LoadData();
      }

    partial void OnSelectedStudentChanged(Student oldValue, Student newValue)
    {
      if (oldValue != null)
        oldValue.ErrorsChanged -= SelectedStudent_ErrorsChanged;
      if (newValue != null)
        newValue.ErrorsChanged += SelectedStudent_ErrorsChanged;

      // Notify CanExecute initial
      SaveCommand.NotifyCanExecuteChanged();
    }

    private void SelectedStudent_ErrorsChanged(object sender, System.ComponentModel.DataErrorsChangedEventArgs e)
    {
      // Wenn sich Validierungsfehler ändern, aktualisiere CanExecute
      SaveCommand.NotifyCanExecuteChanged();
    }

    private bool CanSave()
    {
      return SelectedStudent != null && !SelectedStudent.HasErrors;
    }
    /// <summary>
    /// Die Funktion speichert den ausgewählten Studenten in der Datenbank.
    /// </summary>
    [RelayCommand(CanExecute = nameof(CanSave))]
    public void Save()
    {
      if (SelectedStudent == null) return;
      try
      {
        if (SelectedStudent.StudentId == 0)
        {
          _context.Students.Add(SelectedStudent);
          Students.Add(SelectedStudent);
        }
        _context.SaveChanges();
        OnPropertyChanged(nameof(Students));
        MessageBox.Show("Erfolgreich gespeichert!");
      }
      catch (Exception ex)
      {
        MessageBox.Show($"Fehler beim Speichern: {ex.Message}");
      }
    }

    /// <summary>
    /// die Methode lädt die Daten aus der Datenbank und füllt die ObservableCollections
    /// </summary>
    private void LoadData()
    {
          var studentList = _context.Students.Include(s => s.Klasse).ToList();
          var klassenList = _context.Klasses.ToList();
          Students = new ObservableCollection<Student>(studentList);
          Klassen = new ObservableCollection<Klasse>(klassenList);
     }

    /// <summary>
    /// Die Methode erzeugt einen neuen Studenten mit Standardwerten.
    /// </summary>
    [RelayCommand]
      public void CreateNew()
      {
          SelectedStudent = new Student
          {
              Vorname = "Neu",
              Nachname = "Student",
              Geburtsdatum = DateOnly.FromDateTime(DateTime.Now),
              Strasse = "Dummystraße",
              Stadt = "Dummystadt"
          };
      }

    /// <summary>
    /// die Methode löscht den ausgewählten Studenten aus der Datenbank nach der Bestätigung der MessageBox-Anzeige.
    /// </summary>
    [RelayCommand]
      public void Delete()
      {
        if (SelectedStudent == null) return;

        if (MessageBox.Show("Wirklich löschen?", "Bestätigung", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        {
            _context.Students.Remove(SelectedStudent);
            _context.SaveChanges();
            Students.Remove(SelectedStudent);
            SelectedStudent = null;
        }
      }
    }
}
