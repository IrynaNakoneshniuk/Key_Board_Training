using MaterialDesignColors.Recommended;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Key_Board_Training
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = "ButtonStyle";
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            ResourceDictionary? resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        }
       
        private void tabControl_KeyDown(object sender, KeyEventArgs e)
        {
            string Key=e.Key.ToString();    
            try
            {
                e.Handled = true;
                Button button =(Button) GridWithButtons.FindName(e.Key.ToString()); ;
                 if(button != null)
                {
                    ColorAnimation animation;
                    animation = new ColorAnimation(Colors.Green, TimeSpan.FromSeconds(0.1));
                    animation.AutoReverse = true;
                    var item = (Button)button;
                    item.Background = new SolidColorBrush(((SolidColorBrush)item.Background).Color);
                    item.Background.BeginAnimation(SolidColorBrush.ColorProperty, animation);
                }
            }catch(AnimationException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.StopButton.IsEnabled=true;
                string? ForTrainning = null;
                timer.Start();
                Random random = new Random();
                for (int i = 0; i < sliderDifficulty.Value; i++)
                {
                    ForTrainning += (char)random.Next(39, 126);
                }
                this.textForTrainning.Text = ForTrainning;
            }catch(Exception ex)
            {
                this.textForTrainning.Text = ex.Message;
            }
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
            textForTrainning.Text="";
            this.StopButton.IsEnabled = false;
        }
    }
}
