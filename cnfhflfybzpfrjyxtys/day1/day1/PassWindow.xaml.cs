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

namespace day1
{
    /// <summary>
    /// Логика взаимодействия для PassWindow.xaml
    /// </summary>
    public partial class PassWindow : Window
    {
        public PassWindow()
        {
            InitializeComponent();
        }
        private readonly List<string> Passwords = new List<string>
{
    "c8DzJeTC9t",
    "rvbrYASYyh",
    "SUTniBMrme",
    "uTZgVwuoHs",
    "v7eerXyUru",
    "YGDS3ds",
    "Hfd221da"
};
        private readonly Random random = new Random();
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
        public string Password
        {
            get { return passwordBox.Text; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var index = random.Next(Passwords.Count);
            var password = Passwords[index];
            passwordBox.Text = password;
            info.io = passwordBox.Text;
        }
    }
}
