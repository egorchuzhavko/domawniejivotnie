using System;
using System.IO;
using System.Collections.Generic;

namespace reshenie
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Animal> list = new List<Animal>();
            List<Person> list_per = new List<Person>();
          
            int num = 0;
            do {
                System.Console.Write("Введите пунIкт: ");
                num = Convert.ToInt32(Console.ReadLine());
                switch (num) {
                    case 1:
                        list=new List<Animal>();
                        System.Console.WriteLine("imya vladelcya:");
                        string imyavlad = Console.ReadLine();
                        string buffer = "";
                        do
                        {
                            System.Console.WriteLine("Введите имя, кличку и возраст дживотного" +
                                                     " в формате имя;кличка;возраст " +
                                                     "(Если нет клички - ввод запятой, если больше животных нет - ввод точки)");
                            buffer = Console.ReadLine();
                            if(buffer==".")
                                continue;
                            string[] temp = buffer.Split(";");
                            int tempp=Convert.ToInt32(temp[2]);
                            
                            list.Add(new Animal(temp[0], temp[1], tempp));
                        }while(buffer !=".");

                        list_per.Add(new Person(imyavlad,list));
                        break;
                    case 2: 
                        foreach (var item in list_per) {
                            System.Console.WriteLine(item);
                        }
                        break;
                    case 3: 
                        StreamWriter sw = new StreamWriter("input.txt");
                        foreach(var item in list_per){
                            sw.WriteLine(item);
                        }
                        sw.Close();
                        break;
                }

            }while (num != 0);
        }
    }
}