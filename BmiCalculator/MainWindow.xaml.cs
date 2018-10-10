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
using System.Diagnostics;
using System.ComponentModel;

namespace BmiCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {

        bool gewicht_ok;
        bool alter_ok;
        bool groesse_ok;

        int Gewicht;
        int Groesse;
        int Alter;
        int Bmi;
        string Geschlecht;

        public MainWindow()
        {
            InitializeComponent();
            _genderFemale.Style = FindResource("gender_selection_missing") as Style;
            _genderMale.Style = FindResource("gender_selection_missing") as Style;
            
        }

        private void OnTextChangedGewicht(object sender, TextChangedEventArgs e)
        {
            int value;
            if (int.TryParse(_gewicht.Text, out value))
            {
                if ((value > 0) && (value < 300))
                {
                    Gewicht = value;
                    gewicht_ok = true;
                }
            }
            else
                _gewicht.BorderBrush = System.Windows.Media.Brushes.Red;
                gewicht_ok = false;

            Calculate();
        }

        private void OnTextChangedGroesse(object sender, TextChangedEventArgs e)
        {
            int value;
            if (int.TryParse(_groesse.Text,out value))
            {
                if ((value > 0) && (value < 300))
                    Groesse = value;
            }
            
            Calculate();
        }

        private void OnTextChangedAlter(object sender, TextChangedEventArgs e)
        {
            int value;
            if (int.TryParse(_alter.Text,out value))
            {
                if ((value > 0) && (value < 300))
                    Alter = value;
            }
            
            Calculate();
        }

        private void Calculate()
        {
            var alter = _alter.Text;

            _result.Value = _result.Value + 10;
        }

        private void CheckedChanged(object sender, RoutedEventArgs e)
        {
            _genderFemale.Style = FindResource("gender_selection_done") as Style;
            _genderMale.Style = FindResource("gender_selection_done") as Style;
            Calculate();
        }
    }
}
