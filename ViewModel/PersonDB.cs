using Model;
using ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PersonDB:BaseDB
    {

        private string firstName;
        private string lastName;
        private City livingCity;

        public PersonList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Person";
            PersonList pList = new PersonList(base.Select());
            return pList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Person p = entity as Person;
            p.FirstName = reader["firstName"].ToString();
            p.LastName = reader["lastName"].ToString();
            p.LivingCity = CityDB.SelectById((int)reader["citycode"]);
            base.CreateModel(entity);
            return p;
        }
        public override BaseEntity NewEntity()
        {
                return new Person();
        }
        private static PersonList list = new PersonList();
        
        public static Person SelectById(int id)
        {
            PersonDB db = new PersonDB();
            list = db.SelectAll();

            Person g = list.Find(item => item.Id == id);
            return g;
        }

    }
}
