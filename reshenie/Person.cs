using System.Collections.Generic;

namespace reshenie
{
    public class Person
    {
        public string name_owner;
        public List<Animal> list;

        public Person(string name_owner, List<Animal> list) {
            this.name_owner = name_owner;
            this.list = list;
        }

        public override string ToString()
        {
            string info = "";
            foreach (var item in list) {
                info += item.vid + "," + item.klichka + "," + item.age + "\n";
            }
            return $"\nИмя: {name_owner}\nЖивотные:\n{info}";
        }   
    }
}