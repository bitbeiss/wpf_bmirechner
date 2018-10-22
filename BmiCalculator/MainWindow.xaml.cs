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

namespace BmiCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Calculator BMIRechner = new Calculator { };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = BMIRechner;
            _genderFemale.Style = FindResource("gender_selection_missing") as Style;
            _genderMale.Style = FindResource("gender_selection_missing") as Style;
        }

        private void OnTextChanged(object sender, TextChangedEventArgs e)
        {
            reset();
        }

        private void CheckedChanged(object sender, RoutedEventArgs e)
        {
            _genderFemale.Style = FindResource("gender_selection_done") as Style;
            _genderMale.Style = FindResource("gender_selection_done") as Style;
            BMIRechner.Female = Convert.ToBoolean(_genderFemale.IsChecked);
            BMIRechner.Male = Convert.ToBoolean(_genderMale.IsChecked);
            reset();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!(BMIRechner.Male || BMIRechner.Female))
                return;

            BMIRechner.Calculate();

            if(BMIRechner.IsValid())
            {
                BMI_value.Text = BMIRechner.Result.ToString();
                _slider.Value = BMIRechner.Result;
            }
            else
            {
                reset();
            }
        }

        public void reset()
        {
            BMI_value.Text = " ";
            _slider.Value = 0;
            BMIRechner.ClassificationResult = "";
        }
    }
}
