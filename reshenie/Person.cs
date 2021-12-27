using System.Collections.Generic;
using System.Linq;

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

        public int HowManyTypesOfAnimals()
        {
            List<string> types = new List<string>();
            foreach (var VARIABLE in list)
            {
                types.Add(VARIABLE.vid);
            }

            var newtypes = types.Distinct();
            return newtypes.Count();
        }

        public string FindAnimalsByType(string typeofneededanimal)
        {
            string temp = $"Владелец: {name_owner}\n";
            foreach (var VARIABLE in list)
            {
                if (VARIABLE.vid == typeofneededanimal)
                    temp += $"Кличка: {VARIABLE.klichka}\n";
            }

            if (temp == $"Владелец: {name_owner}\n")
                return $"Владелец: {name_owner} не имеет животных такого типа";
            else
                return temp;
        }

        public int FindCountWithNeededNickName(string nickname)
        {
            int k = 0;
            foreach (var VARIABLE in list)
            {
                if (VARIABLE.klichka == nickname)
                    k++;
            }

            return k;
        }
    }
}