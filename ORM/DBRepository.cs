using System.Data;
using System.IO;
using SQLite;
using System;

namespace BasicDataAccess.ORM
{
    public class DBRepository
    {
        //code to create the database
        public string CreateDB()
        {
            string output = "";
            output += "Creating DataBase if it doesn't exist.";
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "demo.db");
            SQLiteConnection db = new SQLiteConnection(dbPath);
            output += "\nDatabase Created...";
            return output;
        }

        //Code to create the table
        public string CreateTable()
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "demo.db");
                SQLiteConnection db = new SQLiteConnection(dbPath);
                db.CreateTable<ToDoTask>();
                string result = "Table Created successfully..";
                return result;
            }
            catch(Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }

        //Code to insert a record
        public string InsertRecord(string task)
        {
            try
            {
                string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "demo.db");
                SQLiteConnection db = new SQLiteConnection(dbPath);
                db.CreateTable<ToDoTask>();
                ToDoTask item = new ToDoTask();
                item.Task = task;
                db.Insert(item);
                return "Record Added...";
            }
            catch(Exception ex)
            {
                return "Error : " + ex.Message;
            }
        }
        //code to retrieve all the records
        public string GetAllRecords()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "demo.db");
            SQLiteConnection db = new SQLiteConnection(dbPath);
            string output = "";
            output += "Retrieving the data using ORM...";
            TableQuery<ToDoTask> table = db.Table<ToDoTask>();
            foreach(ToDoTask item in table)
            {
                output += "\n" + item.Id + " --- " + item.Task;
            }
            return output;
        }

        //code to retrieve specific record using ORM
        public string GetTaskById(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "demo.db");
            SQLiteConnection db = new SQLiteConnection(dbPath);
            ToDoTask item = db.Get<ToDoTask>(id);
            return item.Task;
        }

        //code to update the record using ORM
        public string UpdateRecord(int id, string task)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "demo.db");
            SQLiteConnection db = new SQLiteConnection(dbPath);
            ToDoTask item = db.Get<ToDoTask>(id);
            item.Task = task;
            db.Update(item);
            return "Record Updated...";
        }

        //code to remove the record using orm
        public string RemoveTask(int id)
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "demo.db");
            SQLiteConnection db = new SQLiteConnection(dbPath);
            ToDoTask item = db.Get<ToDoTask>(id);
            db.Delete(item);
            return "Record Deleted";
        }
    }
}