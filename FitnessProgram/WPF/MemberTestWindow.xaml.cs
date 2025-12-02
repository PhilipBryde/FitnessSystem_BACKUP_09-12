using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace FitnessProgram
{
    public partial class ActivityWindow : Window
    {
        private Fitness _fitness = new Fitness();
        public ObservableCollection<string> Activities { get; set; } = new ObservableCollection<string>();


        public ActivityWindow()
        {
            InitializeComponent();
            DataContext = this;
            ShowActivity();
        }

        private void ShowActivity()
        {
            string filePath = @"ActivityList.txt";
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                Activities.Add(line);
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var activity = button.DataContext as string;
            ActivityOptionsWindow options = new ActivityOptionsWindow(activity); //Opretter et objekt 
            options.Show();

        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NextWindow next = new NextWindow();
            next.Show();
            this.Close();
        }
    }
}
