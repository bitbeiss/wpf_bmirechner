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
        private bool _Eingabefehler;
        public bool Eingabefehler { get => _Eingabefehler; set => _Eingabefehler = value; }
        private bool _Male;
        public bool Male { get => _Male; set => _Male = value; }
        private bool _Female;
        public bool Female { get => _Female; set => _Female = value; }

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
                ClassificationResult = "Klassifikation";
        }
        public void Calculate()
        {
            if (Eingabefehler)
            {
                Result = 0;
                return;
            }
            double dGrosse = Convert.ToDouble(Groesse) / 100.0;
            double dGewicht = Convert.ToDouble(Gewicht);

            Result = Math.Round(dGewicht / Math.Pow(dGrosse, 2.0), 1);
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
        private int _Groesse;
        public int Groesse
        {
            get { return _Groesse; }
            set
            {
                _Groesse = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Groesse"));
            }
        }

        private int _Alter;
        public int Alter
        {
            get { return _Alter; }
            set
            {
                _Alter = value;
                OnPropertyChanged(new PropertyChangedEventArgs("Alter"));
            }
        }

        private int _Gewicht;
        public int Gewicht
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
                    if ((_Alter < 1) || (_Alter > 120))
                        return "Das Alter muss zwischen 1 und 120 Jahren liegen.";
                }
                if (propertyName == "Gewicht")
                {
                    if ((_Gewicht < 1) || (_Gewicht > 300))
                        return "Das Gewicht muss zwischen 1 und 300 Kilogramm liegen.";
                }

                if (propertyName == "Groesse")
                {
                    if ((_Groesse < 1) || (_Groesse > 350))
                        return "Die Größe muss zwischen 1 und 350 cm sein.";
                }
                return null;
            }
        }
    }
}