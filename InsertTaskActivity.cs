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

namespace BasicDataAccess
{
    [Activity(Label = "InsertTaskActivity")]
    public class InsertTaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.InsertTaskLayout);

            Button btnAdd = FindViewById<Button>(Resource.Id.btntask);
            btnAdd.Click += BtnAdd_Click;
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            EditText txtTask = FindViewById<EditText>(Resource.Id.txttask);
            ORM.DBRepository dbr = new ORM.DBRepository();
            string result = dbr.InsertRecord(txtTask.Text);
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }
    }
}