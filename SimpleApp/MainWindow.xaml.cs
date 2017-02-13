﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
using SimpleApp.BL;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media.Animation;

namespace SimpleApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            InitializeComponent();
            //DataContext = new RateObject();
            Controller c = new Controller();
            c.RetrieveCurrent();
            
            c.UpdateTrends();

            DataContext = c.Rates;
        }


    }
}
