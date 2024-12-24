using PeopleProject;

namespace TestPeopleProject
{

    public class Tests
    {
        PersonStatistics kenyer;

        [SetUp]
        public void Setup()
        {
            kenyer = new PersonStatistics(new List<Person>());
        }

        #region Konstruktor
        [Test]
        public void Konstruktor_HibasLista_ExceptiontDob()
        {
            Assert.Throws<ArgumentNullException>(() => new PersonStatistics(null));
        }


        #endregion

        #region AverageAge
        [Test]
        public void AverageAge_UresLista_0tAd()
        {
            Assert.That(kenyer.GetAverageAge(), Is.EqualTo(0));
        }

        [Test]
        public void AverageAge_Egesz_Kul()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 20, false, 0),
                new Person(2, "Nagy Pista", 30, false, 0),
                new Person(3, "Kiss Mari", 40, false, 0),
                new Person(4, "Nagy Mari", 50, false, 0),
            };
            Assert.That(kenyer.GetAverageAge(), Is.EqualTo(35));
        }


        [Test]
        public void AverageAge_Tort_Kul()
        {
            kenyer.People = new List<Person>() 
            {
                new Person(1, "Kiss Pista", 20, false, 0),
                new Person(2, "Nagy Pista", 35, false, 0),
                new Person(3, "Kiss Mari", 40, false, 0),
                new Person(4, "Nagy Mari", 55, false, 0),
            };
                Assert.That(kenyer.GetAverageAge(), Is.EqualTo(37.5));
        }



        #endregion

        #region NumberOfStudents
        [Test]
        public void NumberOfStudents_UresLista_0tAd()
        {
            Assert.That(kenyer.GetNumberOfStudents(), Is.EqualTo(0));
        }

        [Test]
        public void NumberOfStudents_VanStudent_Kul()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 20, true, 0),
                new Person(2, "Nagy Pista", 35, false, 0),
                new Person(3, "Kiss Mari", 40, true, 0),
                new Person(4, "Nagy Mari", 55, true, 0),
            };
            Assert.That(kenyer.GetNumberOfStudents(), Is.EqualTo(3));
        }

        [Test]
        public void NumberOfStudents_NincsStudent_Kul()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 20, false, 0),
                new Person(2, "Nagy Pista", 35, false, 0),
                new Person(3, "Kiss Mari", 40, false, 0),
                new Person(4, "Nagy Mari", 55, false, 0),
            };
            Assert.That(kenyer.GetNumberOfStudents(), Is.EqualTo(0));
        }


        #endregion

        #region PersonWithHighestScore
        [Test]
        public void GetPersonWithHighestScore_UresLista_NulltAd()
        {
            Assert.IsNull(kenyer.GetPersonWithHighestScore());
        }

        [Test]
        public void GetPersonWithHighestScore_Kul()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 20, true, 30),
                new Person(2, "Nagy Pista", 35, false, 0),
                new Person(3, "Kiss Mari", 40, true, 50),
                new Person(4, "Nagy Mari", 55, true, 40),
            };
            Assert.That(kenyer.GetPersonWithHighestScore()!.Name, Is.EqualTo("Kiss Mari"));
        }

        [Test]
        public void GetPersonWithHighestScore_Ugyanannyi_Kul()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 20, true, 10),
                new Person(2, "Nagy Pista", 35, false, 0),
                new Person(3, "Kiss Mari", 40, true, 50),
                new Person(4, "Nagy Mari", 55, true, 50),
            };
            Assert.That(kenyer.GetPersonWithHighestScore()!.Name, Is.EqualTo("Kiss Mari"));
        }

        #endregion

        #region AverageScoreOfStudents
        [Test]
        public void AverageScoreOfStudents_UresLista_0tAd()
        {
            Assert.That(kenyer.GetAverageScoreOfStudents(), Is.EqualTo(0));
        }

        [Test]
        public void AverageScoreOfStudents_Kul()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 20, true, 30),
                new Person(2, "Nagy Pista", 35, false, 0),
                new Person(3, "Kiss Mari", 40, true, 50),
                new Person(4, "Nagy Mari", 55, true, 40),
            };
            Assert.That(kenyer.GetAverageScoreOfStudents(), Is.EqualTo(40));
        }

        #endregion

        #region OldestStudent
        [Test]
        public void GetOldestStudent_UresLista_NulltAd()
        {
            Assert.IsNull(kenyer.GetOldestStudent());
        }

        [Test]
        public void GetOldestStudent_Kul()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 20, true, 30),
                new Person(2, "Nagy Pista", 35, false, 0),
                new Person(3, "Kiss Mari", 40, true, 50),
                new Person(4, "Nagy Mari", 55, true, 40),
            };
            Assert.That(kenyer.GetOldestStudent()!.Name, Is.EqualTo("Nagy Mari"));
        }

        [Test]
        public void GetOldestStudent_NincsStudent_NulltAd()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 20, false, 30),
                new Person(2, "Nagy Pista", 35, false, 0),
                new Person(3, "Kiss Mari", 40, false, 50),
                new Person(4, "Nagy Mari", 55, false, 40),
            };
            Assert.IsNull(kenyer.GetOldestStudent());
        }

        [Test]
        public void GetOldestStudent_Egyidos_Kul()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 10, false, 30),
                new Person(2, "Nagy Pista", 55, false, 0),
                new Person(3, "Kiss Mari", 20, true, 50),
                new Person(4, "Nagy Mari", 20, true, 40),
            };
            Assert.That(kenyer.GetOldestStudent()!.Name, Is.EqualTo("Kiss Mari"));
        }

        #endregion

        #region IsAnyoneFailing
        [Test]
        public void AnyoneFailing_UresLista_FalseTAd()
        {
            Assert.IsFalse(kenyer.IsAnyoneFailing());
        }

        [Test]
        public void AnyoneFailing_Kul()
        {
            kenyer.People = new List<Person>()
            {
                new Person(1, "Kiss Pista", 20, true, 30),
                new Person(2, "Nagy Pista", 35, false, 0),
                new Person(3, "Kiss Mari", 40, true, 50),
                new Person(4, "Nagy Mari", 55, true, 40),
            };
            Assert.IsTrue(kenyer.IsAnyoneFailing());
        }
        #endregion
    }
}