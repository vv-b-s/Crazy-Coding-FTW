using System;

namespace Finance
{
    public enum Calculate { Nothing, FutureValue, PresentValue }
    public class Interest
    {
        public enum IntrestType { Simple, Discursive, Anticipative }
        public enum InterestPeriods { Daily, Weekly, Monthly }

        static int iTimesPeriod(int iTimes, InterestPeriods iPeriods) // if interest is not accounted Annually.
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
        static int iTimesPeriodPow(int Period)                       // Gives the right power to the Complicated Interest when using iTimesPeriod
        {
            switch (Period)
            {
                case 365:
                    return 1;
                case 52:
                    return 1;
                case 12:
                    return 1;
                default:
                    return Period;
            }
        }

        public class FutureValue
        {
            public static readonly string[] attributes = { "Present Value", "Interest Rate", "Period", "Interest periods", "Type of periods (Daily - 0, Weekly - 1, Monthly - 2)" };
            public static string SimpleInterest(decimal presentValue, decimal interestRate, int period)
            {
                decimal futureValue = presentValue * (1 + (interestRate / 100) * period);
                futureValue = Math.Round(futureValue, 2);
                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV × (1 + n × r%)\nSolution: {presentValue} × (1 + {period} × {interestRate / 100}) = {futureValue:0.00}";
                return output;
            }

            public static string CDiscursiveInterest(decimal presentValue, decimal interestRate, int period)
            {
                decimal futureValue = presentValue * (decimal)Math.Pow((double)(1 + interestRate / 100), period);
                futureValue = Math.Round(futureValue, 2);

                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV × (1 + r%)^n\nSolution: {presentValue} × (1 + {period} × {interestRate / 100})^{period} = {futureValue:0.00}";
                return output;
            }

            public static string CDiscursiveInterest(decimal presentValue, decimal interestRate, int period, int iTimes, InterestPeriods iPeriods)     // if interest is not accounted Annually
            {
                decimal futureValue = presentValue * (decimal)Math.Pow((double)(1 + ((interestRate / 100) / iTimesPeriod(iTimes, iPeriods))), period * iTimesPeriodPow(iTimesPeriod(iTimes, iPeriods)));
                futureValue = Math.Round(futureValue, 2);

                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV × (1 + r%/m)^(m × n)\nSolution: {presentValue} × (1 + {interestRate / 100}/{iTimesPeriod(iTimes, iPeriods)})^({period} × {iTimesPeriodPow(iTimesPeriod(iTimes, iPeriods))}) = {futureValue:0.00}";
                return output;
            }

            public static string CAnticipativeInterest(decimal presentValue, decimal interestRate, int period)
            {
                decimal futureValue = presentValue / (decimal)Math.Pow((double)(1 - interestRate / 100), period);
                futureValue = Math.Round(futureValue, 2);

                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV/(1-r%)^n\nSolution: {presentValue}/(1 + {interestRate / 100})^{period} = {futureValue:0.00}";
                return output;
            }

            public static string CAnticipativeInterest(decimal presentValue, decimal interestRate, int period, int iTimes, InterestPeriods iPeriods)     // if interest is not accounted Annually
            {
                decimal futureValue = presentValue / (decimal)Math.Pow((double)(1 - ((interestRate / 100) / iTimesPeriod(iTimes, iPeriods))), period * iTimesPeriodPow(iTimesPeriod(iTimes, iPeriods)));
                futureValue = Math.Round(futureValue, 2);

                string output = $"Future Value: {futureValue:0.00}\nUsed formula: FV = PV / (1 - r%/m)^(m × n)\nSolution: {presentValue} / (1 - {interestRate / 100}/{iTimesPeriod(iTimes, iPeriods)})^({period} × {iTimesPeriodPow(iTimesPeriod(iTimes, iPeriods))}) = {futureValue:0.00}";
                return output;
            }
        }

        public class PresentValue
        {
            public static readonly string[] attributes = { "Future Value", "Interest Rate", "Period", "Interest periods", "Type of periods (Daily - 0, Weekly - 1, Monthly - 2)" };
            public static string SimpleInterest(decimal futureValue, decimal interestRate, int period)
            {
                decimal presentValue = futureValue / (1 + (interestRate / 100) * period);
                presentValue = Math.Round(presentValue, 2);
                string output = $"Present Value: {presentValue:0.00}\nUsed formula: PV = FV / (1 + n × r%)\nSolution: {futureValue} / (1 + {period} × {interestRate / 100}) = {presentValue:0.00}";
                return output;
            }

            public static string CDiscursiveInterest(decimal futureValue, decimal interestRate, int period)
            {
                decimal presentValue = futureValue / (decimal)Math.Pow((double)(1 + interestRate / 100), period);
                presentValue = Math.Round(presentValue, 2);

                string output = $"Present Value: {presentValue:0.00}\nUsed formula: PV = FV / (1 + r%)^n\nSolution: {futureValue} / (1 + {period} × {interestRate / 100})^{period} = {presentValue:0.00}";
                return output;
            }

            public static string CDiscursiveInterest(decimal futureValue, decimal interestRate, int period, int iTimes, InterestPeriods iPeriods)     // if interest is not accounted Annually
            {
                decimal presentValue = futureValue * (decimal)Math.Pow((double)(1 + ((interestRate / 100) / iTimesPeriod(iTimes, iPeriods))), period * iTimesPeriodPow(iTimesPeriod(iTimes, iPeriods)));
                presentValue = Math.Round(presentValue, 2);

                string output = $"Present Value: {presentValue:0.00}\nUsed formula: PV = FV / (1 + r%/m)^(m × n)\nSolution: {futureValue} / (1 + {interestRate / 100}/{iTimesPeriod(iTimes, iPeriods)})^({period} × {iTimesPeriodPow(iTimesPeriod(iTimes, iPeriods))}) = {presentValue:0.00}";
                return output;
            }

            public static string CAnticipativeInterest(decimal futureValue, decimal interestRate, int period)
            {
                decimal presentValue = futureValue * (decimal)Math.Pow((double)(1 - interestRate / 100), period);
                presentValue = Math.Round(presentValue, 2);

                string output = $"Present Value: {presentValue:0.00}\nUsed formula: FV = PV × (1-r%)^n\nSolution: {futureValue} × (1 + {interestRate / 100})^{period} = {presentValue:0.00}";
                return output;
            }

            public static string CAnticipativeInterest(decimal futureValue, decimal interestRate, int period, int iTimes, InterestPeriods iPeriods)     // if interest is not accounted Annually
            {
                decimal presentValue = futureValue * (decimal)Math.Pow((double)(1 - ((interestRate / 100) / iTimesPeriod(iTimes, iPeriods))), period * iTimesPeriodPow(iTimesPeriod(iTimes, iPeriods)));
                presentValue = Math.Round(presentValue, 2);

                string output = $"Present Value: {presentValue:0.00}\nUsed formula: PV = FV × (1 - r%/m)^(m × n)\nSolution: {futureValue} × (1 - {interestRate / 100}/{iTimesPeriod(iTimes, iPeriods)})^({period} × {iTimesPeriodPow(iTimesPeriod(iTimes, iPeriods))}) = {presentValue:0.00}";
                return output;
            }
        }

    }
}