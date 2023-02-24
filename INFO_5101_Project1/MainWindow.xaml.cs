/**
 * FileName: MainWindow.cs
 * Purpose: The purpose of the file is to connect statistics.cs to UI implementation.
 * Author: Kieran Primeau, Stanislav Kovalenko, Agnita Paul, Bhavin Patel
 * Creation Date: 20 February, 2023
 * 
 **/
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.IO;

namespace INFO_5101_Project1
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

        private void XML_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "Canadacities-XML.xml");
            BackEnd.Statistics statistics = new(path, "xml");
            Statistics statisticPage = new();
            statisticPage.Show();
        }

        private void JSON_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "Canadacities-JSON.json");
            BackEnd.Statistics statistics = new(path, "json");
            Statistics statisticPage = new();
            statisticPage.Show();
        }
        private void CSV_Click(object sender, RoutedEventArgs e)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Files", "Canadacities.csv");
            BackEnd.Statistics statistics = new(path, "csv");
            Statistics statisticPage = new();
            statisticPage.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Hide_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Exit_MouseMove(object sender, MouseEventArgs e)
        {
            Exit.Background = new SolidColorBrush(Color.FromArgb(255, 132, 40, 40));
        }

        private void Hide_MouseMove(object sender, MouseEventArgs e)
        {
            Exit.Background = new SolidColorBrush(Color.FromArgb(255, 219, 49, 49));
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
