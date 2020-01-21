using Knjiznica;
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
using System.Windows.Shapes;

namespace WPFProject
{
    /// <summary>
    /// Interaction logic for MatchStatistics.xaml
    /// </summary>
    public partial class MatchStatistics : Window
    {
        public MatchStatistics(Statistics s1, Statistics s2)
        {
            InitializeComponent();

            Grid.SetColumn(s1, 0);
            gStats.Children.Add(s1);

            Grid.SetColumn(s2, 2);

            gStats.Children.Add(s2);

        }
 
    }
}
