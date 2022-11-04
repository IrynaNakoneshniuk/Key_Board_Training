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

namespace Key_Board_Training
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
           
        }
        private void ThemeChange(object sender, SelectionChangedEventArgs e)
        {
            string style = "ButtonStyle";
            var uri = new Uri(style + ".xaml", UriKind.Relative);
            ResourceDictionary? resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);
        } 
    }
    public class MyCommands
    {
        public static RoutedCommand MyCommand1 { get; set; }
        static MyCommands()
        {
            MyCommand1 = new RoutedCommand("MyCommand1", typeof(MainWindow));
        }
        private void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
