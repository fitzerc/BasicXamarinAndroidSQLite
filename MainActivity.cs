using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace BasicDataAccess
{
    [Activity(Label = "BasicDataAccess", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Home);

            //Create the database..
            Button btnCreateDB = FindViewById<Button>(Resource.Id.btncreatedb);
            btnCreateDB.Click += BtnCreateDB_Click;

            //To Create the Table
            Button btnCreateTable = FindViewById<Button>(Resource.Id.btncreatetable);
            btnCreateTable.Click += BtnCreateTable_Click;

            //To Insert the record
            Button btnAddRecord = FindViewById<Button>(Resource.Id.btninsert);
            btnAddRecord.Click += BtnAddRecord_Click;

            //To Retrieve the Data
            Button btnGetAll = FindViewById<Button>(Resource.Id.btngetdata);
            btnGetAll.Click += BtnGetAll_Click;

            //To Retrieve specific record
            Button btnGetById = FindViewById<Button>(Resource.Id.btngetdatabyid);
            btnGetById.Click += BtnGetById_Click;

            //To Update the record
            Button btnUpdate = FindViewById<Button>(Resource.Id.btnupdate);
            btnUpdate.Click += BtnUpdate_Click;

            //To delete the record
            Button btnDelete = FindViewById<Button>(Resource.Id.btndelete);
            btnDelete.Click += BtnDelete_Click;

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(RemoveTaskActivity));
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(UpdateTaskActivity));
        }

        private void BtnGetById_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(SearchActivity));
        }

        private void BtnGetAll_Click(object sender, EventArgs e)
        {
            ORM.DBRepository dbr = new ORM.DBRepository();
            string result = dbr.GetAllRecords();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void BtnAddRecord_Click(object sender, EventArgs e)
        {
            StartActivity(typeof(InsertTaskActivity));
        }

        private void BtnCreateTable_Click(object sender, EventArgs e)
        {
            ORM.DBRepository dbr = new ORM.DBRepository();
            string result = dbr.CreateTable();
            Toast.MakeText(this, result, ToastLength.Short).Show();
        }

        private void BtnCreateDB_Click(object sender, EventArgs e)
        {
            ORM.DBRepository dbr = new ORM.DBRepository();
            string result = dbr.CreateDB();
            Toast.MakeText(this, result, ToastLength.Long).Show();

        }
    }
}

