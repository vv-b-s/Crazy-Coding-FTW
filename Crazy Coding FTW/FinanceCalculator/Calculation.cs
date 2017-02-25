using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Finance;

namespace FinanceCalculator
{
    public partial class MainActivity : Activity
    {
        private string ModifyFlipper(string InputBox)
        {
            var CalculationButton = FindViewById<Button>(Resource.Id.CalculationButton);

            #region Future Value
            if (spinner[0] == (int)Calculate.FutureValue)
            {
                spaces = 0;
                CountSpaces(InputBox);

                if (spaces != 2 && spaces != 4)
                    CalculationButton.Enabled = false;
                else
                    CalculationButton.Enabled = true;

                return FlipperFeeder(Interest.FutureValue.attributes);
            }
            #endregion

            #region Present Value
            else if (spinner[0] == (int)Calculate.PresentValue)
            {
                spaces = 0;
                CountSpaces(InputBox);

                if (spaces != 2 && spaces != 4)
                    CalculationButton.Enabled = false;
                else
                    CalculationButton.Enabled = true;

                return FlipperFeeder(Interest.PresentValue.attributes);
            }
            #endregion

            #region Effective Interest Rate
            if (spinner[0] == (int)Calculate.EffectiveIR)
            {
                spaces = 0;
                CountSpaces(InputBox);

                if (spaces == 2)
                    CalculationButton.Enabled = true;
                else
                    CalculationButton.Enabled = false;

                return FlipperFeeder(Interest.EffectiveIR.attributes);
            }

            #endregion

            #region Rate of Return
            if (spinner[0] == (int)Calculate.RateOfReturn)
            {
                switch(spinner[1])
                {
                    case (int)Risk.CalcType.ExpectedReturns:
                        spaces = 0;
                        CountSpaces(InputBox);

                        if (spaces == 1)
                            CalculationButton.Enabled = true;
                        else CalculationButton.Enabled = false;

                        return FlipperFeeder(RateOfReturn.attributes);
                }
            }

            #endregion

            #region Risk
            if(spinner[0]==(int)Calculate.Risk&&spinner[1]==(int)Risk.CalcType.ExpectedReturns)
            {
                spaces = 0;
                CountSpaces(InputBox);

                if (spaces == 1)
                    CalculationButton.Enabled = true;
                else CalculationButton.Enabled = false;

                return FlipperFeeder(Risk.ExpectedReturns.attributes);
            }
            #endregion


            return "";
        }

        private string FlipperFeeder(string[] attributes) => (spaces <= attributes.Length - 1) ? $"Enter: {attributes[spaces]}" : "There is no more data to be filled.";

        private string DoCalculation(string[] attribute)
        {
            #region Future Value
            if (spinner[0] == (int)Calculate.FutureValue)
            {
                switch (spinner[1])
                {
                    case (int)Interest.IntrestType.Simple:
                        return Interest.FutureValue.SimpleInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]));

                    case (int)Interest.IntrestType.Discursive:
                        if (spaces == 2)
                            return Interest.FutureValue.CDiscursiveInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]));
                        else if (spaces == 4)
                            return Interest.FutureValue.CDiscursiveInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]), double.Parse(attribute[3]), (Interest.InterestPeriods)(int)double.Parse(attribute[4]));
                        break;

                    case (int)Interest.IntrestType.Anticipative:
                        if (spaces == 2)
                            return Interest.FutureValue.CAnticipativeInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]));
                        else if (spaces == 4)
                            return Interest.FutureValue.CAnticipativeInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]), double.Parse(attribute[3]), (Interest.InterestPeriods)(int)double.Parse(attribute[4]));
                        break;
                }
            }
            #endregion

            #region Present Value
            else if (spinner[0] == (int)Calculate.PresentValue)
            {
                switch (spinner[1])
                {
                    case (int)Interest.IntrestType.Simple:
                        return Interest.PresentValue.SimpleInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]));

                    case (int)Interest.IntrestType.Discursive:
                        if (spaces == 2)
                            return Interest.PresentValue.CDiscursiveInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]));
                        else if (spaces == 4)
                            return Interest.PresentValue.CDiscursiveInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]), double.Parse(attribute[3]), (Interest.InterestPeriods)(int)double.Parse(attribute[4]));
                        break;

                    case (int)Interest.IntrestType.Anticipative:
                        if (spaces == 2)
                            return Interest.PresentValue.CAnticipativeInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]));
                        else if (spaces == 4)
                            return Interest.PresentValue.CAnticipativeInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), double.Parse(attribute[2]), double.Parse(attribute[3]), (Interest.InterestPeriods)int.Parse(attribute[4]));
                        break;
                }
            }
            #endregion

            #region Effective Interest Rate
            else if (spinner[0] == (int)Calculate.EffectiveIR)
                return Interest.EffectiveIR.EiR(decimal.Parse(attribute[0]), double.Parse(attribute[1]), (Interest.InterestPeriods)((int)double.Parse(attribute[2])));
            #endregion

            #region Rate of Return
            else if (spinner[0] == (int)Calculate.RateOfReturn)
                return RateOfReturn.RoR(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]));
            #endregion

            #region Risk
            else if(spinner[0]==(int)Calculate.Risk)
            {
                switch(spinner[1])
                {
                    case (int)Risk.CalcType.ExpectedReturns:
                        return Risk.ExpectedReturns.eR.ExpRet(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]));
                }
            }
            #endregion

            return "";
        }
        private void CountSpaces(string text)
        {
            foreach (char a in text)               // measuring spaces in order to define which attribute to display
                if (a == ' ')
                    spaces++;
        }
    }
}