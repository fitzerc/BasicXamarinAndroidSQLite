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
    [Activity(Label = "UpdateTaskActivity")]
    public class UpdateTaskActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Search (Button_click)
            SetContentView(Resource.Layout.UpdateTaskLayout);
            Button btnSearch = FindViewById<Button>(Resource.Id.btnsearch);
            btnSearch.Click += BtnSearch_Click;

            //Update (button_click)
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnupdate);
            btnUpdate.Click += BtnUpdate_Click;
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            EditText txtId = FindViewById<EditText>(Resource.Id.txttaskid);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txttask);
            ORM.DBRepository dbr = new ORM.DBRepository();
            string result = dbr.UpdateRecord(int.Parse(txtId.Text),txtTask.Text);
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            ORM.DBRepository dbr = new ORM.DBRepository();
            EditText txtId = FindViewById<EditText>(Resource.Id.txttaskid);
            EditText txtTask = FindViewById<EditText>(Resource.Id.txttask);
            txtTask.Text = dbr.GetTaskById(int.Parse(txtId.Text));
        }
    }
}