using System;
using System.Linq;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Hardware;

using Finance;

namespace FinanceCalculator
{
    [Activity(Label = "Finance Calculator", MainLauncher = true, Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        internal static int[] spinner = new int[2];                             // Getting the position of the spinners.
        internal static int spaces = 0;                                        // Used to measure words in the InputBox
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            //Controlls
            var CSpinnerLabel = FindViewById<TextView>(Resource.Id.CSpinnerLabel);
            var OperationSpinner = FindViewById<Spinner>(Resource.Id.OperationSpinner);
            var CalculationSpinner = FindViewById<Spinner>(Resource.Id.CalculationSpinner);
            var DataFlipper = FindViewById<TextView>(Resource.Id.DataFlipper);
            var InputBox = FindViewById<EditText>(Resource.Id.InputBox);
            var CalculationButton = FindViewById<Button>(Resource.Id.CalculationButton);
            var ResultBox = FindViewById<CheckedTextView>(Resource.Id.ResultBox);

            CSpinnerLabel.Visibility = ViewStates.Invisible;
            CalculationSpinner.Visibility = ViewStates.Invisible;

            #region SpinnerConnection

            OperationSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(OperationSpinner_ItemSelected);
            var enumValuesOS = Enum.GetValues(typeof(Calculate));
            var arrayForAdapterOS = enumValuesOS.Cast<Calculate>().Select(e => e.ToString()).ToArray();
            var adapterOS = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, arrayForAdapterOS);
            OperationSpinner.Adapter = adapterOS;

            #endregion

            // Code
            InputBox.TextChanged += delegate
            {
                DataFlipper.Text = Calculation.ModifyFlipper(InputBox.Text);
            };

            CalculationButton.Click += delegate
              {
                  string[] attribute = InputBox.Text.Split();

                  if (CheckInput(ref attribute, (Calculate)spinner[0]))
                  {
                      try
                      {

                          ResultBox.Text = Calculation.DoCalculation(attribute);
                      }
                      catch (OverflowException)
                      {
                          ResultBox.Text = "Impossible calculation";
                      }
                  }
                  else
                      ResultBox.Text = "Wrong input.";
              };
        }

        private void OperationSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            var CSpinnerLabel = FindViewById<TextView>(Resource.Id.CSpinnerLabel);
            var CalculationSpinner = FindViewById<Spinner>(Resource.Id.CalculationSpinner);

            ClearData();
            Spinner OperationSpinner = (Spinner)sender;
            spinner[0] = e.Position;

            #region Spinner 2 activation
            if (spinner[0] != (int)Calculate.Nothing)
            {
                Array enumValuesCS;
                string[] arrayForAdapterCS = default(string[]);         // adapterCS won't work otherwise

                #region Second Spinner Condition
                switch (spinner[0])
                {
                    #region Future Value
                    case (int)Calculate.FutureValue:
                        CSpinnerLabel.Visibility = ViewStates.Visible;
                        CalculationSpinner.Visibility = ViewStates.Visible;

                        CSpinnerLabel.Text = "Choose Interest type:";
                        enumValuesCS = Enum.GetValues(typeof(Interest.IntrestType));
                        arrayForAdapterCS = enumValuesCS.Cast<Interest.IntrestType>().Select(f => f.ToString()).ToArray();
                        break;
                    #endregion

                    #region Present Value
                    case (int)Calculate.PresentValue:
                        CSpinnerLabel.Visibility = ViewStates.Visible;
                        CalculationSpinner.Visibility = ViewStates.Visible;

                        CSpinnerLabel.Text = "Choose Interest type:";
                        enumValuesCS = Enum.GetValues(typeof(Interest.IntrestType));
                        arrayForAdapterCS = enumValuesCS.Cast<Interest.IntrestType>().Select(f => f.ToString()).ToArray();
                        break;

                        #endregion
                }
                #endregion Second Spinner Condition

                CalculationSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(CalculationSpinner_ItemSelected);
                var adapterCS = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, arrayForAdapterCS);
                CalculationSpinner.Adapter = adapterCS;
            }
            else
                CalculationSpinner.Visibility = ViewStates.Invisible;
            #endregion
        }
        private void CalculationSpinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            ClearData();
            Spinner OperationSpinner = (Spinner)sender;
            spinner[1] = e.Position;
        }

        private void ClearData()
        {
            var DataFlipper = FindViewById<TextView>(Resource.Id.DataFlipper);
            var InputBox = FindViewById<EditText>(Resource.Id.InputBox);
            var ResultBox = FindViewById<CheckedTextView>(Resource.Id.ResultBox);

            DataFlipper.Text = "Enter data:";
            InputBox.Text = "";
            ResultBox.Text = "";
            spaces = 0;
        }

        private bool CheckInput(ref string[] input, Calculate type)
        {
            for (int i = 0; i < input.Length; i++)
            {
                foreach (char a in input[i])
                {
                    if ((a < '0' || a > '9') && a != ',' && a != '.' && a != ' ' && a != '-')
                        return false;
                }

                input[i] = input[i].Replace('.', ',');           // Dots are used as decimal points too

                decimal toOutput = 0;                                 // To avoid 2 decimal points or minuses
                decimal.TryParse(input[i], out toOutput);
                input[i] = toOutput.ToString();
            }
            return true;
        }
    }
}

