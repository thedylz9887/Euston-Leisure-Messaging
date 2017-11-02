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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Euston_Leisure_Messaging
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

        private void addMessagebtn_Click(object sender, RoutedEventArgs e)
        {
            String text = inputMessagetbx.Text;
            String ID = messageIDtbx.Text;
            FormatMessage fm = new FormatMessage(ID, text);

            Test test = new Test(fm);
            test.ShowDialog();
        }
    }
}
