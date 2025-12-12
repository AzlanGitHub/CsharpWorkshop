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

      private void LoadData()
      {
        // .Include ist wichtig, um die verknüpfte Klasse zu laden
        var studentList = _context.Students.Include(s => s.Klasse).ToList();
        var klassenList = _context.Klasses.ToList();
        Students = new ObservableCollection<Student>(studentList);
        Klassen = new ObservableCollection<Klasse>(klassenList);
      }

      [RelayCommand]
      public void CreateNew()
      {
          SelectedStudent = new Student
          {
            Vorname = "Neu",
            Nachname = "Student",
            Geburtsdatum = DateOnly.FromDateTime(DateTime.Now),
            Strasse = "",
            Stadt = ""
          };
      }

      [RelayCommand]
      public void Save()
      {
        if (SelectedStudent == null) return;
        try
        {
          // Prüfen, ob der Student neu ist (ID == 0 bei Autoincrement)
          if (SelectedStudent.StudentId == 0)
          {
            _context.Students.Add(SelectedStudent);
            Students.Add(SelectedStudent); 
          }
          _context.SaveChanges();
          OnPropertyChanged(nameof(Students));
          MessageBox.Show("Erfolgreich gespeichert!");
        }
        catch (Exception ex){
          MessageBox.Show($"Fehler beim Speichern: {ex.Message}");
        }
      }
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
