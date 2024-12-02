using System.Collections.ObjectModel;
using System.Windows.Input;

namespace zh2
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<Animal> Animals { get; set; }
        public ICommand AddAnimalCommand { get; set; }
        public ICommand CountAAnimalsCommand { get; set; }
        private int _aAnimalsCount;
        public int AAnimalsCount
        {
            get => _aAnimalsCount;
            set
            {
                _aAnimalsCount = value;
                OnPropertyChanged(nameof(AAnimalsCount));
            }
        }
        public MainPage()
        {
            InitializeComponent();
            Animals = new ObservableCollection<Animal>();
            AddAnimalCommand = new Command(AddAnimal);
            CountAAnimalsCommand = new Command(async () => await CountAAnimalsAsync());
            BindingContext = this;
        }

        private async Task CountAAnimalsAsync()
        {
            await Task.Run(() =>
            {
                AAnimalsCount = Animals.Count(a => a.Name.Contains("A"));
            });
        }

        private void AddAnimal(object obj)
        {
            if (string.IsNullOrWhiteSpace(NameEntry.Text) ||
                string.IsNullOrWhiteSpace(TypeEntry.Text) ||
                !int.TryParse(AgeEntry.Text, out int age)) return;

            Animals.Add(new Animal(
                NameEntry.Text,
                TypeEntry.Text,
                age));

            NameEntry.Text = string.Empty;
            TypeEntry.Text = string.Empty;
            AgeEntry.Text = string.Empty;
        }
    }

}
