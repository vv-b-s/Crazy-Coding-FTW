using System;

namespace Finance
{
    public enum Calculate { None, FutureValue, PresentValue, EffectiveIR, RateOfReturn, Risk }

    public static class Interest
    {
        public enum IntrestType { Simple, Discursive, Anticipative }
        public enum InterestPeriods { Daily, Weekly, Monthly }

        static double iTimesPeriod(double iTimes, InterestPeriods iPeriods) // if interest is not accounted Annually.
        {
            switch (iPeriods)
            {
                case InterestPeriods.Daily:
                    return 365 / iTimes;
                case InterestPeriods.Weekly:
                    return 52 / iTimes;
                case InterestPeriods.Monthly:
                    return 12 / iTimes;
                default:
                    return 1;

            }
        }

        public static class FutureValue
        {
            public static readonly string[] attributes = { "Present Value", "Interest Rate", "Period", "Interest periods", "Type of periods (Daily - 0, Weekly - 1, Monthly - 2)" };

            public static string SimpleInterest(decimal presentValue, decimal interestRate, double period)
            {
                decimal futureValue = presentValue * (1 + (interestRate / 100) * (decimal)period);
                futureValue = Math.Round(futureValue, 2);
                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV × (1 + n × r%)\nSolution: {presentValue} × (1 + {period} × {interestRate / 100}) = {futureValue:0.00}";
                return output;
            }

            public static string CDiscursiveInterest(decimal presentValue, decimal interestRate, double period)
            {
                decimal futureValue = presentValue * (decimal)Math.Pow((double)(1 + interestRate / 100), period);
                futureValue = Math.Round(futureValue, 2);

                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV × (1 + r%)^n\nSolution: {presentValue} × (1 + {interestRate / 100})^{period} = {futureValue:0.00}";
                return output;
            }

            public static string CDiscursiveInterest(decimal presentValue, decimal interestRate, double period, double iTimes, InterestPeriods iPeriods)     // if interest is not accounted Annually
            {
                decimal futureValue = presentValue * (decimal)Math.Pow((double)(1 + ((interestRate / 100) / (decimal)iTimesPeriod(iTimes, iPeriods))), period * iTimesPeriod(iTimes, iPeriods));
                futureValue = Math.Round(futureValue, 2);

                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV × (1 + r%/m)^(m × n)\nSolution: {presentValue} × (1 + {interestRate / 100}/{iTimesPeriod(iTimes, iPeriods)})^({period} × {iTimesPeriod(iTimes, iPeriods)}) = {futureValue:0.00}";
                return output;
            }

            public static string CAnticipativeInterest(decimal presentValue, decimal interestRate, double period)
            {
                decimal futureValue = presentValue / (decimal)Math.Pow((double)(1 - interestRate / 100), period);
                futureValue = Math.Round(futureValue, 2);

                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV/(1-r%)^n\nSolution: {presentValue}/(1 + {interestRate / 100})^{period} = {futureValue:0.00}";
                return output;
            }

            public static string CAnticipativeInterest(decimal presentValue, decimal interestRate, double period, double iTimes, InterestPeriods iPeriods)     // if interest is not accounted Annually
            {
                decimal futureValue = presentValue / (decimal)Math.Pow((double)(1 - ((interestRate / 100) / (decimal)(iTimesPeriod(iTimes, iPeriods)))), period * iTimesPeriod(iTimes, iPeriods));
                futureValue = Math.Round(futureValue, 2);

                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV / (1 - r%/m)^(m × n)\nSolution: {presentValue} / (1 - {interestRate / 100}/{iTimesPeriod(iTimes, iPeriods)})^({period} × {iTimesPeriod(iTimes, iPeriods)}) = {futureValue:0.00}";
                return output;
            }
        }

        public static class PresentValue
        {
            public static readonly string[] attributes = { "Future Value", "Interest Rate", "Period", "Interest periods", "Type of periods (Daily - 0, Weekly - 1, Monthly - 2)" };

            public static string SimpleInterest(decimal futureValue, decimal interestRate, double period)
            {
                decimal presentValue = futureValue / (1 + (interestRate / 100) * (decimal)period);
                presentValue = Math.Round(presentValue, 2);
                string output = $"Present Value: {presentValue:0.00}\nUsed formula: PV = FV / (1 + n × r%)\nSolution: {futureValue} / (1 + {period} × {interestRate / 100}) = {presentValue:0.00}";
                return output;
            }

            public static string CDiscursiveInterest(decimal futureValue, decimal interestRate, double period)
            {
                decimal presentValue = futureValue / (decimal)Math.Pow((double)(1 + interestRate / 100), period);
                presentValue = Math.Round(presentValue, 2);

                string output = $"Present Value: {presentValue:0.00}\nUsed formula: PV = FV / (1 + r%)^n\nSolution: {futureValue} / (1 + {interestRate / 100})^{period} = {presentValue:0.00}";
                return output;
            }

            public static string CDiscursiveInterest(decimal futureValue, decimal interestRate, double period, double iTimes, InterestPeriods iPeriods)     // if interest is not accounted Annually
            {
                decimal presentValue = futureValue / (decimal)Math.Pow((double)(1 + ((interestRate / 100) / (decimal)iTimesPeriod(iTimes, iPeriods))), period * iTimesPeriod(iTimes, iPeriods));
                presentValue = Math.Round(presentValue, 2);

                string output = $"Present Value: {presentValue:0.00}\nUsed formula: PV = FV / (1 + r%/m)^(m × n)\nSolution: {futureValue} / (1 + {interestRate / 100}/{iTimesPeriod(iTimes, iPeriods)})^({period} × {iTimesPeriod(iTimes, iPeriods)}) = {presentValue:0.00}";
                return output;
            }

            public static string CAnticipativeInterest(decimal futureValue, decimal interestRate, double period)
            {
                decimal presentValue = futureValue * (decimal)Math.Pow((double)(1 - interestRate / 100), period);
                presentValue = Math.Round(presentValue, 2);

                string output = $"Present Value: {presentValue:0.00}\nUsed formula: FV = PV × (1-r%)^n\nSolution: {futureValue} × (1 + {interestRate / 100})^{period} = {presentValue:0.00}";
                return output;
            }

            public static string CAnticipativeInterest(decimal futureValue, decimal interestRate, double period, double iTimes, InterestPeriods iPeriods)     // if interest is not accounted Annually
            {
                decimal presentValue = futureValue * (decimal)Math.Pow((double)(1 - ((interestRate / 100) / (decimal)iTimesPeriod(iTimes, iPeriods))), period * iTimesPeriod(iTimes, iPeriods));
                presentValue = Math.Round(presentValue, 2);

                string output = $"Present Value: {presentValue:0.00}\nUsed formula: PV = FV × (1 - r%/m)^(m × n)\nSolution: {futureValue} × (1 - {interestRate / 100}/{iTimesPeriod(iTimes, iPeriods)})^({period} × {iTimesPeriod(iTimes, iPeriods)}) = {presentValue:0.00}";
                return output;
            }
        }

        public static class EffectiveIR
        {
            public static readonly string[] attributes = { "Interest rate", "Interest period times", "Type of periods (Daily - 0, Weekly - 1, Monthly - 2)" };

            public static string EiR(decimal interestRate, double iTimes, InterestPeriods iPeriods)
            {
                decimal eir = (((decimal)Math.Pow((double)(1 + (interestRate / 100) / (decimal)iTimesPeriod(iTimes, iPeriods)), iTimesPeriod(iTimes, iPeriods))) - 1) * 100;
                eir = Math.Round(eir, 2);

                string output = $"Effective Interest Rate: {eir:0.00}%\nUsed formula: [(1 + r%/m)^m-1] × 100\nSolution: [(1 + {interestRate / 100}/{iTimesPeriod(iTimes, iPeriods)})^{iTimesPeriod(iTimes, iPeriods)}-1] × 100 = {eir:0.00}%";
                return output;
            }
        }
    }

    public static class RateOfReturn
    {
        public enum CalculationType { InvestmentAndFV, Profit }
        public static readonly string[] attributes = { "Value of investment", "Future Value" };

        public static string RoR(decimal ValueOfInvestment, decimal FutureValue)
        {
            decimal result = ((FutureValue - ValueOfInvestment) / ValueOfInvestment) * 100;
            result = Math.Round(result, 2);

            string output = $"Rate of return: {result:0.00}%\nUsed formula: ((FV-I)/I) × 100 = r%\nSolution: (({FutureValue} - {ValueOfInvestment}) / {ValueOfInvestment}) × 100 = {result:0.00}%";
            return output;
        }
    }
    public class Risk
    {
        public enum CalcType { ExpectedReturns, StandardDeviation, VariationCoefficient }

        public class ExpectedReturns
        {
            public static readonly string[] attributes = { "Anticipated Revenues", "Probability" };
            private decimal _ER = 0;
            public decimal ER
            {
                set { _ER += value; }
                get { return _ER; }
            }

            private string _output = "";
            public string output => _output;

            public static ExpectedReturns eR = new ExpectedReturns();

            public string ExpRet(decimal anticipatedR, decimal probability)
            {
                decimal currentER;
                ER = currentER = anticipatedR * (probability / 100);
                _ER = Math.Round(_ER, 1);
                return $"Expected Returns: {ER:0.0}\nUsed formula: ER = {(char)8721}Ri × Pi\nCurrent Expected Returns: {Math.Round(currentER, 1):0.0}";
            }

            public void Clear() => _ER = 0;
        }

        public class StandardDeviation
        {
            public static readonly string[] attributes = { "Anticipated Revenues", "Probability", "Expected Returns" };
            private decimal _SD = 0;

            public decimal SD
            {
                set { _SD += value; }
                get { return Math.Round((decimal)Math.Sqrt((double)_SD),2); }
            }

            public static StandardDeviation sD = new StandardDeviation();

            public string StandDev(decimal ARevenues, decimal Probability, decimal ExpectedR)
            {
                decimal Dispersion = (decimal)Math.Pow((double)(ARevenues - ExpectedR), 2) * (Probability / 100);
                SD = Dispersion = Math.Round(Dispersion, 2);

                string output = $"Standard deviation: {SD:0.00}\nUsed formula: {(char)963}{(char)178} = {(char)8721}(Ri - ER){(char)178} × Pi%\nCurrent disperison: {Dispersion:0.00}\nTotal dispersion: {_SD:0.00}";
                return output;
            }

            public void Clear() => _SD = 0;
        }

        public static class VariationCoefficient
        {
            public static readonly string[] attributes = { "Standard Devration", "Expected Returns" };
            public static string CV (decimal SD, decimal ER)
            {
                decimal CV = Math.Round(SD / ER, 2);
                string output = $"Variation Coefficient: {CV:0.00}\nUsed formula: CV = {(char)963} / ER\nSolution: {SD} / {ER} = {CV:0.00}";
                return output;
            }
        }
    }
}
