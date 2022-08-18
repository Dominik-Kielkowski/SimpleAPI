using SimpleAPI.Data;
using SimpleAPI.Models;

namespace SimpleAPI
{
    public class PeopleSeeder
    {
        private readonly ApplicationDbContext _db;

        public PeopleSeeder(ApplicationDbContext db)
        {
            _db = db;
        }

        Random random = new Random();
        string[] names = new string[] { "Liam", "Olivia", "Noah", "Emma", "Oliver", "Charlotte", "Elijah", "Amelia", "James", "Ava", "William", "Sophia", "Benjamin", "Isabella", "Lucas", "Mia", "Henry", "Evelyn", "Theodore", "Harper" };

        public void Seed()
        {
            if (_db.Database.CanConnect())
            {
                var people = GetPeople();
                _db.People.AddRange(people);
                _db.SaveChanges();
            }
        }

        private IEnumerable<Person> GetPeople()
        {
            int randomValue = random.Next(0, names.Length);
            List<Person> people = new List<Person>();

            foreach(var x in Enumerable.Range(0,100))
            {
                var person = new Person()
                {
                    Name = names[randomValue],
                    Age = random.Next(18, 100),
                    Salary = random.Next(1000, 999999),
                    PhoneNumber = random.Next(100000000, 999999999),
                    OccupationId = random.Next(0, 3)
                };
                people.Add(person);
            }
            return people;
        }
    }
};
