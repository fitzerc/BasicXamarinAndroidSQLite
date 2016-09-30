using System;
using System.IO;
using System.Data;
using SQLite;

namespace BasicDataAccess.ORM
{
    [Table("ToDoTasks")]
    public class ToDoTask
    {
        [PrimaryKey,AutoIncrement,Column("_Id")]
        public int Id {get; set;}

        [MaxLength(50)]
        public string Task { get; set;}









    }
}