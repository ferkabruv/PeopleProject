using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleProject
{
    public class PersonStatistics
    {
        public List<Person> People { private get; set; }

        public PersonStatistics(List<Person> people)
        {
            if (people == null)
            {
                throw new ArgumentNullException("Hibás lista!", nameof(people));
            }

            People = people;
        }

        public double GetAverageAge()
        {
            if (People.Count == 0)
            {
                return 0;
            }
            return People.Average(p => p.Age);
        }

        public int GetNumberOfStudents()
        {
            return People.Count(p => p.IsStudent);
        }

        public Person? GetPersonWithHighestScore()
        {
            if (People.Count == 0)
            {
                return null;
            }
            return People.OrderByDescending(p => p.Score).First();
        }

        public double GetAverageScoreOfStudents()
        {
            if (People.Count == 0)
            {
                return 0;
            }
            return People.Where(p => p.IsStudent).Average(p => p.Score);
        }

        public Person? GetOldestStudent()
        {
            if (People.Count == 0)
            {
                return null;
            }
            var Students = People.Where(p => p.IsStudent);
            if (Students.Count() == 0)
            {
                return null;
            }
            return Students.OrderByDescending(p => p.Age).First();
            
        }

        public Boolean IsAnyoneFailing()
        {
            return People.Any(p => p.Score < 40);
        }
    }
}
