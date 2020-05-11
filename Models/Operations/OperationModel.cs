using CalculatorSharp.Models.Enums;

namespace CalculatorSharp.Models.Operations
{
    public class OperationModel    {

        public enumOperationType OperationType { get; set; }
        public decimal Number { get; set; }

        public OperationModel()
        {
            SetupProperties();
        }

        public OperationModel(enumOperationType operationType, decimal number)
        {
            OperationType = operationType;
            Number = number;
        }
        private void SetupProperties()
        {
            OperationType = enumOperationType.None;
            Number = 0;
        }
    }
}
