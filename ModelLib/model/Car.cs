using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLib.model
{
    public class Car
    {
        private String _regNumber;
        private String _color;
        private String _model;

        public Car()
        {
        }

        public Car(string regNumber, string color, string model)
        {
            _regNumber = regNumber;
            _color = color;
            _model = model;
        }

        public string RegNumber
        {
            get => _regNumber;
            set => _regNumber = value;
        }

        public string Color
        {
            get => _color;
            set => _color = value;
        }

        public string Model
        {
            get => _model;
            set => _model = value;
        }

        public override string ToString()
        {
            return $"{nameof(RegNumber)}: {RegNumber}, {nameof(Color)}: {Color}, {nameof(Model)}: {Model}";
        }
    }
}
