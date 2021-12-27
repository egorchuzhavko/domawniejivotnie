using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace reshenie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();
            List<Person> list_per = new List<Person>();
            bool firstflag = false;
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                if(!firstflag){}
                string[] temp = sr.ReadLine().Split(",");
                list.Add(new Animal(temp[1],temp[2],Convert.ToInt32(temp[3])));
                list_per.Add(new Person(temp[0], list));
                while (!sr.EndOfStream)
                {
                    temp = sr.ReadLine().Split(",");
                    bool flag = false;
                    foreach (var VARIABLE in list_per)
                    {
                        int k = 0;
                        if (VARIABLE.name_owner == temp[0])
                        {
                            list_per[k].list.Add((new Animal(temp[1], temp[2], Convert.ToInt32(temp[3]))));
                            flag = true;
                            break;
                        }
                        k++;
                    }
                    if (!flag)
                    {
                        list = new List<Animal>();
                        list.Add(new Animal(temp[1],temp[2],Convert.ToInt32(temp[3])));
                        list_per.Add(new Person(temp[0], list));
                    }
                }
            }
            int num = 0;
            do {
                System.Console.Write("Введите пункт меню 1-4 (0 - выход из программы) : ");
                num = Convert.ToInt32(Console.ReadLine());
                try
                {
                    switch (num)
                    {
                        case 1:
                            foreach (var VARIABLE in list_per)
                            {
                                Console.WriteLine(
                                    $"Владелец с именем {VARIABLE.name_owner} имеет {VARIABLE.HowManyTypesOfAnimals()}" +
                                    $" различных видов животных");
                            }
                            break;
                        case 2:
                            Console.Write("Введите необходимый тип животного для поиска: ");
                            string typeofneededanimal = Console.ReadLine();
                            foreach (var VARIABLE in list_per)
                            {
                                Console.WriteLine(VARIABLE.FindAnimalsByType(typeofneededanimal));
                            }
                            break;
                        case 3:
                            Console.Write("Введите кличку для подсчёта животных с такой кличкой: ");
                            string klichka = Console.ReadLine();
                            int k = 0;
                            foreach (var VARIABLE in list_per)
                            {
                                k += VARIABLE.FindCountWithNeededNickName(klichka);
                            }
                            Console.WriteLine($"Количество животных с кличкой {klichka} = {k}");
                            break;
                        case 4:
                            List<string> types = new List<string>();
                            foreach (var VARIABLE in list_per)
                            {
                                foreach (var V2 in VARIABLE.list)
                                {
                                    types.Add(V2.vid);
                                }
                            }

                            var newtypes = types.Distinct();
                            foreach (var VARIABLE in newtypes)
                            {
                                int minzn = 10000;
                                int maxzn = -10000;
                                foreach (var V2 in list_per)
                                {
                                    int mintemp = V2.FindMinInListWithNeededType(VARIABLE);
                                    int maxtemp = V2.FindMaxInListWithNeededType(VARIABLE);
                                    if (mintemp == 10000 & maxtemp == -10000)
                                        continue;
                                    else
                                    {
                                        if (mintemp < minzn)
                                            minzn = mintemp;
                                        if (maxtemp > maxzn)
                                            maxzn = maxtemp;
                                    }
                                }
                                Console.WriteLine($"У {VARIABLE} минимальный возраст равен" +
                                                  $" {minzn}, а максимальный -  {maxzn}");
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }while (num != 0);
        }
    }
}