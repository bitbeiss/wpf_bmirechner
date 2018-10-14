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

        bool gewicht_ok=false;
        bool alter_ok=false;
        bool groesse_ok=false;
        bool gender_ok=false;

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
            if (int.TryParse(_gewicht.Text, out int value))
            {
                if ((value > 0) && (value < 200))
                {
                    Gewicht = value;
                    gewicht_ok = true;
                    _gewicht.Style = FindResource("input_valid") as Style;
                    _gewicht.ToolTip = "";           }

                else
                {
                    _gewicht.Style = FindResource("input_invalid") as Style;
                    gewicht_ok = false;
                    
                    _gewicht.ToolTip = "Gewicht: 0 bis 200 kg möglich.";
                }
            }

            Calculate();
        }

        private void OnTextChangedGroesse(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(_groesse.Text,out int value))
            {
                if ((value > 0) && (value < 300))
                {
                    Groesse = value;
                    groesse_ok = true;
                    _groesse.Style = FindResource("input_valid") as Style;
                }
                else
                {
                    groesse_ok = false;
                    _groesse.Style = FindResource("input_invalid") as Style;
                }
            }

            Calculate();
        }

        private void OnTextChangedAlter(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(_alter.Text, out int value))
            {
                if ((value > 0) && (value < 130))
                {
                    Alter = value;
                    alter_ok = true;
                    _alter.Style = FindResource("input_valid") as Style;
                }
                else
                {
                    alter_ok = false;
                    _alter.Style = FindResource("input_invalid") as Style;
                }
            }

            Calculate();
        }

        private void Calculate()
        {
            if (gewicht_ok == true && groesse_ok == true && alter_ok == true)
            {
                _result.Value = _result.Value + 10;
            }
        }

        private void CheckedChanged(object sender, RoutedEventArgs e)
        {
            _genderFemale.Style = FindResource("gender_selection_done") as Style;
            _genderMale.Style = FindResource("gender_selection_done") as Style;
            gender_ok = true;
            Calculate();
        }
    }
}
