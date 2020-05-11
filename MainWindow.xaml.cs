using CalculatorSharp.Engine;
using System;
using System.Windows;

namespace CalculatorSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {



        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new CalculatorEngine();
        }



    }
}
