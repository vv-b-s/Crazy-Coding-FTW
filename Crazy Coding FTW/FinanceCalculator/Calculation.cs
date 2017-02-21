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
    public partial class MainActivity:Activity
    {
        private string ModifyFlipper(string InputBox)
        {
            var CalculationButton = FindViewById<Button>(Resource.Id.CalculationButton);

            #region Future Value
            if (spinner[0] == (int)Calculate.FutureValue)
            {
                spaces = 0;
                foreach (char a in InputBox)               // measuring spaces in order to define which attribute to display
                    if (a == ' ')
                        spaces++;

                if (spaces != 2 && spaces != 4)
                    CalculationButton.Enabled = false;
                else
                    CalculationButton.Enabled = true;

                if (spaces < Interest.FutureValue.attributes.Length)
                    return $"Enter: {Interest.FutureValue.attributes[spaces]}";
                else return "There is no more data to be filled.";
            }
            #endregion

            #region Present Value
            else if (spinner[0] == (int)Calculate.PresentValue)
            {

                spaces = 0;
                foreach (char a in InputBox)               // measuring spaces in order to define which attribute to display
                    if (a == ' ')
                        spaces++;

                if (spaces != 2 && spaces != 4)
                    CalculationButton.Enabled = false;
                else
                    CalculationButton.Enabled = true;

                if (spaces < Interest.PresentValue.attributes.Length)
                    return $"Enter: {Interest.PresentValue.attributes[spaces]}";
                else return "There is no more data to be filled.";
            }
            #endregion

            return "";
        }

        internal static string DoCalculation(string[] attribute)
        {
            #region Future Value
            if (spinner[0] == (int)Calculate.FutureValue)
            {
                switch (spinner[1])
                {
                    case (int)Interest.IntrestType.Simple:
                        return Interest.FutureValue.SimpleInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]));
                    case (int)Interest.IntrestType.Discursive:
                        if (spaces == 2)
                            return Interest.FutureValue.CDiscursiveInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]));
                        else if (spaces == 4)
                            return Interest.FutureValue.CDiscursiveInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]), int.Parse(attribute[3]), (Interest.InterestPeriods)int.Parse(attribute[4]));
                        break;
                    case (int)Interest.IntrestType.Anticipative:
                        if (spaces == 2)
                            return Interest.FutureValue.CAnticipativeInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]));
                        else if (spaces == 4)
                            return Interest.FutureValue.CAnticipativeInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]), int.Parse(attribute[3]), (Interest.InterestPeriods)int.Parse(attribute[4]));
                        break;
                }
            }
            #endregion

            #region Present Value
            else if (MainActivity.spinner[0] == (int)Calculate.PresentValue)
            {
                switch (MainActivity.spinner[1])
                {
                    case (int)Interest.IntrestType.Simple:
                        return Interest.PresentValue.SimpleInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]));
                    case (int)Interest.IntrestType.Discursive:
                        if (MainActivity.spaces == 2)
                            return Interest.PresentValue.CDiscursiveInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]));
                        else if (MainActivity.spaces == 4)
                            return Interest.PresentValue.CDiscursiveInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]), int.Parse(attribute[3]), (Interest.InterestPeriods)int.Parse(attribute[4]));
                        break;
                    case (int)Interest.IntrestType.Anticipative:
                        if (MainActivity.spaces == 2)
                            return Interest.PresentValue.CAnticipativeInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]));
                        else if (MainActivity.spaces == 4)
                            return Interest.PresentValue.CAnticipativeInterest(decimal.Parse(attribute[0]), decimal.Parse(attribute[1]), int.Parse(attribute[2]), int.Parse(attribute[3]), (Interest.InterestPeriods)int.Parse(attribute[4]));
                        break;
                }
            }
            #endregion

            return "";
        }
    }
}