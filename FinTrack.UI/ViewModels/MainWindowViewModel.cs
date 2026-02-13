using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FinTrack.UI.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public string Greeting { get; } = "Welcome to Avalonia!";
        public ObservableCollection<Person> People { get; }

        public MainWindowViewModel()
        {
            var people = new List<Person>
            {
                new Person("Neil", "Armstrong", false),
                new Person("Buzz", "Lightyear", true),
                new Person("James", "Kirk", true)
            };
            People = new ObservableCollection<Person>(people);
        }
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsFictitious { get; set; }

    public Person(string firstName, string lastName, bool isFictitious)
    {
        FirstName = firstName;
        LastName = lastName;
        IsFictitious = isFictitious;
    }
}

