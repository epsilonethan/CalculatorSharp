using CalculatorSharp.Models.Commands;
using CalculatorSharp.Models.Enums;
using CalculatorSharp.Models.Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
namespace CalculatorSharp.Engine
{
    public class CalculatorEngine : INotifyPropertyChanged
    {
        #region INotifyProperty

        //Properties used for notify the UI when a Property change

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion



        private Regex _regex_AllowOnlyNumbers = new Regex(@"^-?[0-9]\d*(\,\d+)?");

        private List<OperationModel> _operationsEntered;

        private string _numberText;

        private Decimal _numberEntered;

        private Decimal _result;
        
        

        public string CalculatorText
        {
            get
            {
                return _numberText;
            }
            set
            {

                _numberText = value;
                OnPropertyChanged();
            }
        } 
        public Decimal Result
        {
            get
            {
                return _result;
            }
            set
            {

                _result = value;
                OnPropertyChanged();
            }
        }




        #region Commands
        //List of command binded to UI
        public ICommand Command_Addition { get; set; }
        public ICommand Command_Subtraction { get; set; }
        public ICommand Command_Multiplication { get; set; }
        public ICommand Command_Division { get; set; }
        public ICommand Command_CalculateResult { get; set; }
        public ICommand Command_Clear { get; set; }
        public ICommand Command_Inverse { get; set; }
        public ICommand Command_InsertDot { get; set; }
        public ICommand Command_Number0 { get; set; }
        public ICommand Command_Number1 { get; set; }
        public ICommand Command_Number2 { get; set; }
        public ICommand Command_Number3 { get; set; }
        public ICommand Command_Number4 { get; set; }
        public ICommand Command_Number5 { get; set; }
        public ICommand Command_Number6 { get; set; }
        public ICommand Command_Number7 { get; set; }
        public ICommand Command_Number8 { get; set; }
        public ICommand Command_Number9 { get; set; } 
        #endregion



        public CalculatorEngine()
        {
            SetupProperties();
        }
        

        private void SetupProperties()
        {
            Command_Addition = new RelayCommand(async () => await Addition());
            Command_Subtraction = new RelayCommand(async () => await Subtraction());
            Command_Multiplication = new RelayCommand(async () => await Multiplication());
            Command_Division = new RelayCommand(async () => await Division());
            Command_CalculateResult = new RelayCommand(async () => await CalculateResult());
            Command_Clear = new RelayCommand(async () => await Clear());
            Command_Inverse = new RelayCommand(async () => await Inverse());
            Command_InsertDot = new RelayCommand(async () => await InsertDot());
            Command_Number0 = new RelayCommand(async () => await InputTextNum("0"));
            Command_Number1 = new RelayCommand(async () => await InputTextNum("1"));
            Command_Number2 = new RelayCommand(async () => await InputTextNum("2"));
            Command_Number3 = new RelayCommand(async () => await InputTextNum("3"));
            Command_Number4 = new RelayCommand(async () => await InputTextNum("4"));
            Command_Number5 = new RelayCommand(async () => await InputTextNum("5"));
            Command_Number6 = new RelayCommand(async () => await InputTextNum("6"));
            Command_Number7 = new RelayCommand(async () => await InputTextNum("7"));
            Command_Number8 = new RelayCommand(async () => await InputTextNum("8"));
            Command_Number9 = new RelayCommand(async () => await InputTextNum("9"));


            _operationsEntered = new List<OperationModel>();
            _numberEntered = 0;
            CalculatorText = string.Empty;
        }






        public async Task InsertDot()
        {
            await Task.Run(() =>
            {
                if (_regex_AllowOnlyNumbers.Match(CalculatorText).Success || !string.IsNullOrWhiteSpace(CalculatorText))
                {
                    if (!CalculatorText.Contains(","))
                    {
                        CalculatorText += ",";
                    }
                }

            });
        }
        public async Task Clear()
        {
            await Task.Run(() =>
            {
                _operationsEntered = new List<OperationModel>();
                CalculatorText = string.Empty;
                _numberEntered = 0;
            });
        }
        public async Task Inverse()
        {
            await Task.Run(() =>
            {
                if (_regex_AllowOnlyNumbers.Match(CalculatorText).Success)
                {
                    _numberEntered = Convert.ToDecimal(CalculatorText);
                    _numberEntered = _numberEntered * -1;
                    CalculatorText = _numberEntered.ToString();
                }
            });
        }
        public async Task Addition()
        {
            await DoOperation(enumOperationType.Addition);
        }
        public async Task Subtraction()
        {
            await DoOperation(enumOperationType.Subtraction);
        }
        public async Task Multiplication()
        {
            await DoOperation(enumOperationType.Multiplication);
        }
        public async Task Division()
        {
            await DoOperation(enumOperationType.Division);
        }
        private async Task InputTextNum(string numberInTextFormat)
        {
            await InputNumber(numberInTextFormat);
        }
        private async Task InputNumber(string textNumber)
        {
            await Task.Run(() =>
            {
                if (_regex_AllowOnlyNumbers.Match(CalculatorText).Success || string.IsNullOrWhiteSpace(CalculatorText))
                {
                    CalculatorText += textNumber;
                }
                else
                {
                    CalculatorText = textNumber;
                }

            });
        }
        private async Task DoOperation(enumOperationType operationType)
        {
            await Task.Run(() =>
            {


                if (_regex_AllowOnlyNumbers.Match(CalculatorText).Success)
                {
                    _numberEntered = Convert.ToDecimal(CalculatorText);

                    var myOperation = new OperationModel(operationType, _numberEntered);
                    _operationsEntered.Add(myOperation);
                    CalculatorText = GetTextFoOperation(operationType);
                    _numberEntered = 0;
                }

            });
        }
        private string GetTextFoOperation(enumOperationType operationType)
        {
            switch (operationType)
            {

                case enumOperationType.Addition:
                    return "+";
                case enumOperationType.Subtraction:
                    return "-";
                case enumOperationType.Multiplication:
                    return "*";
                case enumOperationType.Division:
                    return "/";
                case enumOperationType.Squared:
                case enumOperationType.None:
                default:
                    return string.Empty;
            }
        }
        public async Task CalculateResult()
        {
            await Task.Run(() =>
            {
                if (_regex_AllowOnlyNumbers.Match(CalculatorText).Success)
                {
                    _numberEntered = Convert.ToDecimal(CalculatorText);

                    Result = _numberEntered;
                }
                foreach (OperationModel operation in _operationsEntered)
                {
                    switch (operation.OperationType)
                    {

                        case enumOperationType.Addition:
                            Result = operation.Number + Result;
                            break;
                        case enumOperationType.Subtraction:
                            Result = operation.Number - Result;
                            break;
                        case enumOperationType.Multiplication:
                            Result = operation.Number * Result;
                            break;
                        case enumOperationType.Division:
                            Result = operation.Number / Result;
                            break;
                        case enumOperationType.Squared:
                            break;
                        case enumOperationType.None:
                        default:
                            break;
                    }
                }

                CalculatorText = Result.ToString();
                _operationsEntered = new List<OperationModel>();

            });
        }
    }
}
