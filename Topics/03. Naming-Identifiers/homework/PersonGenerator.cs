//Task 2. Make_Чуек in C#

class PersonGenerator
{
    enum Gender { Male, Female };

    class Person
    {
        public Gender Gender { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
    }

    public void CreatePerson(int id)
    {
        Person generatedPerson = new Person();
        generatedPerson.Id = id;
        if (id % 2 == 0)
        {
            generatedPerson.Name = "Батката";
            generatedPerson.Gender = Gender.Male;
        }
        else
        {
            generatedPerson.Name = "Мацето";
            generatedPerson.Gender = Gender.Female;
        }
    }
}

