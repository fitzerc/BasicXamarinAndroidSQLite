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
    [Activity(Label = "SearchActivity")]
    public class SearchActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here

            SetContentView(Resource.Layout.SearchLayout);
            Button btnSearch = FindViewById<Button>(Resource.Id.btnsearch);
            btnSearch.Click += BtnSearch_Click;
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ORM.DBRepository dbr = new ORM.DBRepository();
            EditText txtId = FindViewById<EditText>(Resource.Id.txttaskid);
            string task = dbr.GetTaskById(int.Parse(txtId.Text));
            Toast.MakeText(this, task, ToastLength.Short).Show();
        }
    }
}