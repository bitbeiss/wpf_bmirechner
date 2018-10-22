using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BmiCalculator
{
    public class Calculator : INotifyPropertyChanged, IDataErrorInfo
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private bool _Male;
        public bool Male { get => _Male; set => _Male = value; }
        private bool _Female;
        public bool Female { get => _Female; set => _Female = value; }

        private bool _Valid;
        public bool Valid { get => _Valid; set => _Valid = value; }

        public int iAlter;
        double dGroesse;
        double dGewicht;




        private string _ClassificationResult;
        public string ClassificationResult
        {
            get { return _ClassificationResult; }
            set
            {
                _ClassificationResult = value;
                OnPropertyChanged(new PropertyChangedEventArgs("ClassificationResult"));
            }
        }

        public void Classification()
        {
            if (Male)
            {
                if (Result < 20.0)
                    ClassificationResult = "Untergewicht";
                if ((Result > 20.0) && (Result < 25.0))
                    ClassificationResult = "Normalgewicht";
                if ((Result > 25.0) && (Result < 30.0))
                    ClassificationResult = "Übergewicht";
                if ((Result > 30) && (Result < 40))
                    ClassificationResult = "Adipositas";
                if (Result > 40)
                    ClassificationResult = "massive Adipositas";
            }
            else if (Female)
            {
                if (Result < 19.0)
                    ClassificationResult = "Untergewicht";
                if ((Result > 19.0) && (Result < 24.0))
                    ClassificationResult = "Normalgewicht";
                if ((Result > 24.0) && (Result < 30.0))
                    ClassificationResult = "Übergewicht";
                if ((Result > 30) && (Result < 40))
                    ClassificationResult = "Adipositas";
                if (Result > 40)
                    ClassificationResult = "massive Adipositas";
            }
            else
                ClassificationResult = "";
        }
        public void Calculate()
        {
                double dGroesse_in_m = dGroesse / 100.0;

                Result = Math.Round(dGewicht / Math.Pow(dGroesse_in_m, 2.0), 1);
                Classification();
        }
        public virtual void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, e);
        }

        private double _Result;
        public double Result
        {
            get { return _Result; }
            set
            {
                _Result = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Result"));
            }
        }
        private string _Groesse;
        public string Groesse
        {
            get { return _Groesse; }
            set
            {
                _Groesse = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Groesse"));
            }
        }

        private string _Alter;
        public string Alter
        {
            get { return _Alter; }
            set
            {
                _Alter = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Alter"));
            }
        }

        private string _Gewicht;
        public string Gewicht
        {
            get { return _Gewicht; }
            set
            {
                _Gewicht = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Gewicht"));
            }
        }

        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get
            {
                if (propertyName == "Alter")
                {
                    if (!int.TryParse(Alter, out iAlter))
                    {
                        return "Das Alter muss zwischen 1 und 120 Jahren liegen.";
                    }
                    if ((iAlter < 1) || (iAlter > 120))
                        return "Das Alter muss zwischen 1 und 120 Jahren liegen."; ;
                }
                if (propertyName == "Gewicht")
                {
                    if (!double.TryParse(Gewicht, out dGewicht))
                    {
                        return "Das Gewicht muss zwischen 1 und 300 Kilogramm liegen.";
                    }

                    if ((dGewicht < 1) || (dGewicht > 300))
                        return "Das Gewicht muss zwischen 1 und 300 Kilogramm liegen.";
                }

                if (propertyName == "Groesse")
                {
                    if (!double.TryParse(Groesse, out dGroesse))
                    {
                        return "Die Größe muss zwischen 1 und 350 cm liegen.";
                    }

                    if ((dGroesse < 1) || (dGroesse > 350))
                        return "Die Größe muss zwischen 1 und 350 cm liegen.";
                }
                return null;
            }
        }
        public bool IsValid()
        {
            if (string.IsNullOrEmpty(this["Alter"]) &&
                string.IsNullOrEmpty(this["Gewicht"]) &&
                string.IsNullOrEmpty(this["Groesse"]))
            {
                return true;
            }

            return false;
        }

    }
}