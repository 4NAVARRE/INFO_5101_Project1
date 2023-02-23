﻿using System;
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

namespace INFO_5101_Project1
{
    /// <summary>
    /// Interaction logic for Province.xaml
    /// </summary>
    public partial class Province : Window
    {
        public List<string> cities = new List<string>();
        public Province()
        {
            InitializeComponent();
        }

        private void Province_Change(object sender, DependencyPropertyChangedEventArgs e)
        {
            string? prov = sender.ToString();
            BackEnd.Statistics statistics = new();
            cities = statistics.DisplayProvinceCities(prov);
        }
        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            list.Items.Clear();
            foreach (var city in cities)
            {
                list.Items.Add(city);
            }
        }
    }
}
