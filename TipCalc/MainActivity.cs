using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace TipCalc
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView tipPercent;
        TextView tipCost;
        EditText baseBill;
        TextView totalBill;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            SeekBar Seekbar = FindViewById<SeekBar>(Resource.Id.Seekbar_Tip);
            Seekbar.ProgressChanged += SeekBar_ProgressChanged;

            tipPercent = FindViewById<TextView>(Resource.Id.TextView_TipPercent);
            tipCost = FindViewById<TextView>(Resource.Id.TextView_TipCostNumber);

            baseBill = FindViewById<EditText>(Resource.Id.EditText_Bill);
            totalBill = FindViewById<TextView>(Resource.Id.TextView_TotalNumber);
        }

        public void SeekBar_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            tipPercent.Text = e.Progress.ToString();
            int tipAmount = int.Parse(tipPercent.Text) * int.Parse(baseBill.Text) / 100;
            tipCost.Text = tipAmount.ToString();
            int total = int.Parse(tipCost.Text) + int.Parse(baseBill.Text);
            totalBill.Text = total.ToString();
        }
    }
}