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
    public partial class MainActivity : Activity
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

            CSpinnerVisibility(false);
            InputBox.Enabled = false;
            CalculationButton.Enabled = false;

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
                DataFlipper.Text = ModifyFlipper(InputBox.Text);
            };

            CalculationButton.Click += delegate
              {
                  string[] attribute = InputBox.Text.Split();

                  if (CheckInput(ref attribute, (Calculate)spinner[0]))
                  {
                      try
                      {
                          ResultBox.Text = DoCalculation(attribute);
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
            var DataFlipper = FindViewById<TextView>(Resource.Id.DataFlipper);
            var InputBox = FindViewById<EditText>(Resource.Id.InputBox);
            var CalculationButton = FindViewById<Button>(Resource.Id.CalculationButton);

            ClearData();

            Spinner OperationSpinner = (Spinner)sender;
            spinner[0] = e.Position;

            #region Spinner 2 activation
            if (spinner[0] != (int)Calculate.None)
            {
                ClearData();
                InputBox.Enabled = true;

                #region Second Spinner Condition
                switch (spinner[0])
                {
                    #region Future Value
                    case (int)Calculate.FutureValue:
                        CSpinnerVisibility<Interest.IntrestType>("Choose Interest type:");
                        break;
                    #endregion

                    #region Present Value
                    case (int)Calculate.PresentValue:
                        CSpinnerVisibility<Interest.IntrestType>("Choose Interest type:");
                        break;

                    #endregion

                    #region Effective Interest Rate
                    case (int)Calculate.EffectiveIR:
                        CSpinnerVisibility(false);
                        break;
                        #endregion
                }
                #endregion Second Spinner Condition
            }
            else
            {
                CSpinnerVisibility(false);
                InputBox.Enabled = false;
                CalculationButton.Enabled = false;
                DataFlipper.Text = "Enter data:";

            }
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
            var CalculationButton = FindViewById<Button>(Resource.Id.CalculationButton);

            DataFlipper.Text = "Enter data:";
            InputBox.Text = "";
            ResultBox.Text = "";
            CalculationButton.Enabled = false;
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
        private void CSpinnerVisibility(bool state)
        {
            var CSpinnerLabel = FindViewById<TextView>(Resource.Id.CSpinnerLabel);
            var CalculationSpinner = FindViewById<Spinner>(Resource.Id.CalculationSpinner);

            switch (state)
            {
                case true:
                    CSpinnerLabel.Visibility = ViewStates.Visible;
                    CalculationSpinner.Visibility = ViewStates.Visible;
                    break;
                case false:
                    CSpinnerLabel.Visibility = ViewStates.Invisible;
                    CalculationSpinner.Visibility = ViewStates.Invisible;
                    break;
            }
        }
        private void CSpinnerVisibility<T>(string labelText)                                   // Easily creates the data for the secons spinner
        {
            var CSpinnerLabel = FindViewById<TextView>(Resource.Id.CSpinnerLabel);
            var CalculationSpinner = FindViewById<Spinner>(Resource.Id.CalculationSpinner);
            CSpinnerVisibility(true);

            var enumValuesCS = Enum.GetValues(typeof(T));
            var arrayForAdapterCS = enumValuesCS.Cast<Interest.IntrestType>().Select(f => f.ToString()).ToArray();

            CalculationSpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(CalculationSpinner_ItemSelected);
            var adapterCS = new ArrayAdapter<string>(this, Android.Resource.Layout.SimpleSpinnerItem, arrayForAdapterCS);
            CalculationSpinner.Adapter = adapterCS;
            CSpinnerLabel.Text = labelText;
        }
    }
}

