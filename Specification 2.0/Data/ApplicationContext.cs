using System.Data.Entity;
using Specification_2._0.Models;

namespace Specification_2._0.Data
{

    public class ApplicationContext : DbContext //контекст данных для взаимодействия с БД
    {
        public ApplicationContext() : base("ApplicationContext") //строка подключения БД
        {
            Database.CreateIfNotExists();
        }

        public DbSet<Runner> Runners { get; set; }  //набор сущностей, хранящихся в БД
    }
}
