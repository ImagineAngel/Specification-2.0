using System;
using System.Data.Entity;
using System.Linq;
using Specification_2._0.Models;


namespace Specification_2._0.Data
{ 

    public class ApplicationContext : DbContext //контекст данных для взаимодействия с БД
    {
        public ApplicationContext() : base("ApplicationContext") //строка подключения БЛ
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Runner> Runners { get; set; }  //набор сущностей, хранящихся в БД
    }
}
