using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace WpfApp1
{
     public enum ActivityTypes { All,Air,Land,Water}
    public partial class MainWindow : Window
    {
        	        
		
	
        ObservableCollection<Activities> ActivityList;//list to gather activities

        ObservableCollection<Activities> SelectedList = new ObservableCollection<Activities>();//list for the activites selected

        ObservableCollection<Activities> FilteredList = new ObservableCollection<Activities>();//list for filtering
        ObservableCollection<Descriptions> DescList = new ObservableCollection<Descriptions>();//list of descriptions

        public MainWindow()

        {
            try
            {
                InitializeComponent();
                Activities Kayaking = new Activities("Kayaking", new DateTime(1922, 2, 2), 45, ActivityTypes.Water,"waterBoat");
                Activities Parachuting = new Activities("Parachuting", new DateTime(1978, 2, 28), 279, ActivityTypes.Air,"Jump from plane");
                Activities MountainBiking = new Activities("MountainBiking", new DateTime(2011, 10, 24), 627, ActivityTypes.Land,"Cycling");
                Activities HangGliding = new Activities("HangGliding", new DateTime(1937, 9, 21), 310, ActivityTypes.Air,"jump from mountain");
                Activities Abseiling = new Activities("Abseiling", new DateTime(1916, 12, 29), 299, ActivityTypes.Water,"Sail with the wind");
                Activities Sailing = new Activities("Sailing", new DateTime(1916, 12, 29), 299, ActivityTypes.Water,"Sailwithnowind");
                ActivityList = new ObservableCollection<Activities>();
                ActivityList.Add(Kayaking);
                ActivityList.Add(Parachuting);
                ActivityList.Add(MountainBiking);
                ActivityList.Add(HangGliding);
                ActivityList.Add(Abseiling);
                ActivityList.Add(Sailing);
                ActivityList = new ObservableCollection<Activities>(ActivityList.OrderBy(i => i.ActivityDate));
                Descriptions KayakingDesc = new Descriptions("Kayaking", new DateTime(1922, 2, 2));
                Descriptions ParachutingDesc = new Descriptions("Kayaking", new DateTime(1922, 2, 2));
                Descriptions MountainBikingDesc = new Descriptions("Parachuting", new DateTime(1978, 2, 28));
                Descriptions HangGlidingDesc = new Descriptions("MountainBiking", new DateTime(2011, 10, 24));
                Descriptions AbseilingDesc = new Descriptions("Abseiling", new DateTime(1916, 12, 29));
                Descriptions SailingDesc = new Descriptions("Sailing", new DateTime(1916, 12, 29));
                DescList = new ObservableCollection<Descriptions>();
                DescList.Add(KayakingDesc);
                DescList.Add(ParachutingDesc);
                DescList.Add(MountainBikingDesc);
                DescList.Add(HangGlidingDesc);
                DescList.Add(AbseilingDesc);
                DescList.Add(SailingDesc);
                DescList = new ObservableCollection<Descriptions>(DescList.OrderBy(i => i.DescDate));


                AllActivitesBListox.ItemsSource = ActivityList;
                SelectedActivesListBox.ItemsSource = SelectedList;
                TotalTextBox.Text = "0";
            }
            catch(InvalidOperationException)
            {

            }
            
        }

        private void AllButton_Click(object sender, RoutedEventArgs e)
        {
            AllActivitesBox.Text = ("All activites");
            AllActivitesBListox.ItemsSource = ActivityList;
        }

        private void AirButton_Click(object sender, RoutedEventArgs e)
        {
            AllActivitesBox.Text = ("Air activites");
            var selected = ActivityList.Where(item => item.ActivityTyoe1 ==ActivityTypes.Air).ToList();
            selected.ForEach(item => FilteredList.Add(item));

            AllActivitesBListox.ItemsSource = FilteredList;
        }

        private void LandButton_Checked(object sender, RoutedEventArgs e)
        {
            AllActivitesBox.Text = ("Land activites");
            var selected = ActivityList.Where(item => item.ActivityTyoe1 == ActivityTypes.Land).ToList();
            selected.ForEach(item => FilteredList.Add(item));
            AllActivitesBListox.ItemsSource = FilteredList;
        }

        private void WaterButton_Click(object sender, RoutedEventArgs e)
        {
            AllActivitesBox.Text = ("Water activites");
            var selected = ActivityList.Where(item => item.ActivityTyoe1 == ActivityTypes.Water).ToList();
            selected.ForEach(item => FilteredList.Add(item));
            AllActivitesBListox.ItemsSource = FilteredList;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void SelectedActivesBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Activities selected = AllActivitesBListox.SelectedItem as Activities;
            if (selected.ActivityDate!= ;
            {


                if (selected != null)
                {
                    SelectedList.Add(selected);
                    ActivityList.Remove(selected);

                }
            }
            decimal newtot= decimal.Parse(TotalTextBox.Text);
            newtot =newtot+ selected.Cost;
            TotalTextBox.Text = newtot.ToString();



        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            Activities selected = SelectedActivesListBox.SelectedItem as Activities;
            if (selected!=null)
            {
                SelectedList.Remove(selected);
                ActivityList.Add(selected);
            }
            decimal total = decimal.Parse(TotalTextBox.Text);
            total = total - selected.Cost;
            if (total<0)
            {
                total = 0;
            }
            TotalTextBox.Text = total.ToString();
            
        }

        private void AllActivitesBListox_MouseMove(object sender, MouseEventArgs e)
        {
            Activities selected = AllActivitesBListox.SelectedItem as Activities;
            if (selected!=null)
            {
                Description.Text = selected.Description;
            }
        }

    }
    public class Activities : IComparable<Activities>
    {
        private string name;
        private DateTime activityDate;
        private ActivityTypes ActivityTyoe;
        private decimal cost;
        private string description;

        public string Name { get => name; set => name = value; }
        public DateTime ActivityDate { get => activityDate; set => activityDate = value; }
        public decimal Cost { get => cost; set => cost = value; }
        public string Description { get => description; set => description = value; }
        public ActivityTypes ActivityTyoe1 { get => ActivityTyoe; set => ActivityTyoe = value; }

       

        public  Activities(string _name,DateTime _dateTime,decimal _cost,ActivityTypes _activityTypes, string _description)
        {
            Name = _name;
            ActivityDate = _dateTime;
            ActivityTyoe1 = _activityTypes;
            cost = _cost;
            description = _description;
            
            
        }
        public int CompareTo(Activities other)
        {
            if (ActivityDate == other.ActivityDate)
            {
                return Name.CompareTo(other.Name);
            }
            
            return other.ActivityDate.CompareTo(ActivityDate);
        }
        public override string ToString()
        {
            return (Name + " " + ActivityDate + " " + ActivityTyoe1 + " " + cost);
        }
    }
    public class Descriptions
    {
        private string description;
        private DateTime descDate;
        public string Description { get => description; set => description = value; }
        public DateTime DescDate { get => descDate; set => descDate = value; }

        public Descriptions(string _descriptions,DateTime _descDate)
        {
            description = _descriptions;
            descDate = _descDate;
        }
        public override string ToString()
        {
            return (description + " " + descDate );
        }
    }
}
