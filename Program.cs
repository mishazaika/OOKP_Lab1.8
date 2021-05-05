using System;
using System.Collections.Generic;
using System.Text;

namespace OOKP_Lab1._8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            University university = new University();
            Student student = new Student("Заіка Міхаіл", university);
            Lecturer lecturer = new Lecturer(university);

            university.Marks();
            student.StopMark();

            Notebook notebook = new Notebook();
            SoundReproducingEquipment equipment = new SoundReproducingEquipment();
            Computer computer = new Computer();
            Facade facade = new Facade(notebook, equipment, computer);

            Study study = new Study();
            study.Lesson(facade);

            Console.ReadKey();
        }
    }

    interface IObserver
    {
        void Update(Object ob);
    }

    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class University : IObservable
    {
        DisciplinesMarks disciplinesmarks;
        private List<IObserver> observers;

        public University()
        {
            observers = new List<IObserver>();
            disciplinesmarks = new DisciplinesMarks();
        }
        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }
        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }
        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
                o.Update(disciplinesmarks);
        }
        public void Marks()
        {
            Random rnd = new Random();
            disciplinesmarks.Math = rnd.Next(0, 100);
            disciplinesmarks.English = rnd.Next(0, 100);
            disciplinesmarks.Physics = rnd.Next(0, 100);
            disciplinesmarks.MathEx = rnd.Next(1, 4);
            disciplinesmarks.EnglishEx = rnd.Next(1, 4);
            disciplinesmarks.PhysicsEx = rnd.Next(1, 4);
            NotifyObservers();
        }
    }
    class DisciplinesMarks
    {
        public int Math { get; set; }
        public int English { get; set; }
        public int Physics { get; set; }
        public int MathEx { get; set; }
        public int EnglishEx { get; set; }
        public int PhysicsEx { get; set; }
    }

    class DisciplinesInfo
    {
        public string Math = "Вища математика";
        public string English = "Англійська мова";
        public string Physics = "Фізика";
    }

    class Student : IObserver
    {
        public string Name { get; set; }
        IObservable student;
        public Student(string name, IObservable obs)
        {
            this.Name = name;
            student = obs;
            student.AddObserver(this);
        }

        public void Update(Object ob)
        {
            DisciplinesInfo disciplines = new DisciplinesInfo();
            DisciplinesMarks disciplinesMarks = (DisciplinesMarks)ob;
            if (disciplinesMarks.MathEx == 1)
            {
                if (disciplinesMarks.Math >= 60)
                {
                    Console.WriteLine("Студент {0} отримує позитивну оцінку {1} по дисципліні {2}", Name, disciplinesMarks.Math, disciplines.Math);
                }
                else
                {
                    Console.WriteLine("Студент {0} отримує негативну оцінки {1} по дисципліні {2}", Name, disciplinesMarks.Math, disciplines.Math);
                }
            }
            else
            {
                Console.WriteLine("На лекції {0} студент {1} не отримав оцінки!!!", disciplines.Math, Name);
            }
            
            if(disciplinesMarks.EnglishEx == 1)
            {
                if (disciplinesMarks.English >= 60)
                {
                    Console.WriteLine("Студент {0} отримує позитивну оцінку  {1} по дисципліні {2}", Name, disciplinesMarks.English, disciplines.English);
                }
                else
                {
                    Console.WriteLine("Студент {0} отримує негативну оцінки {1} по дисципліні {2}", Name, disciplinesMarks.English, disciplines.English);
                }
            }
            else
            {
                Console.WriteLine("На лекції {0} студент {1} не отримав оцінки!!!", disciplines.Math, Name);
            }

            if (disciplinesMarks.PhysicsEx == 1)
            {
                if (disciplinesMarks.Physics >= 60)
                {
                    Console.WriteLine("Студент {0} отримує позитивну оцінку  {1} по дисципліні {2}", Name, disciplinesMarks.Physics, disciplines.Physics);
                }
                else
                {
                    Console.WriteLine("Студент {0} отримує негативну оцінки {1} по дисципліні {2}", Name, disciplinesMarks.Physics, disciplines.Physics);
                }
            }
            else
            {
                Console.WriteLine("На лекції {0} студент {1} не отримав оцінки!!!", disciplines.Math, Name);
            }

        }
        public void StopMark()
        {
            student.RemoveObserver(this);
            student = null;
        }
    }

    class Lecturer : IObserver
    {
        IObservable lecturer;
        public Lecturer(IObservable obs)
        {
            lecturer = obs;
            lecturer.AddObserver(this);
        }

        public void Update(Object ob)
        {
            DisciplinesInfo disciplines = new DisciplinesInfo();
            DisciplinesMarks disciplinesMarks = (DisciplinesMarks)ob;
            switch (disciplinesMarks.MathEx)
            {
                case 1:
                    Console.WriteLine("Було проведено лекцію по дисципліні {0}", disciplines.Math);
                    break;
                case 2:
                    Console.WriteLine("Було проведено модульну контрольну по дисципліні {0}", disciplines.Math);
                    break;
                case 3:
                    Console.WriteLine("Було проведено екзамен по дисципліні {0}", disciplines.Math);
                    break;
            }

            switch (disciplinesMarks.EnglishEx)
            {
                case 1:
                    Console.WriteLine("Було проведено лекцію по дисципліні {0}", disciplines.English);
                    break;
                case 2:
                    Console.WriteLine("Було проведено модульну контрольну по дисципліні {0}", disciplines.English);
                    break;
                case 3:
                    Console.WriteLine("Було проведено залік по дисципліні {0}", disciplines.English);
                    break;
            }

            switch (disciplinesMarks.PhysicsEx)
            {
                case 1:
                    Console.WriteLine("Було проведено лекцію по дисципліні {0}", disciplines.Physics);
                    break;
                case 2:
                    Console.WriteLine("Було проведено модульну контрольну по дисципліні {0}", disciplines.Physics);
                    break;
                case 3:
                    Console.WriteLine("Було проведено екзамен по дисципліні {0}", disciplines.Physics);
                    break;
            }
        }
    }

    class Notebook
    {
        public void Wrtitting()
        {
            Console.WriteLine("Студент веде записи у зошиті.");
        }
    }
    
    class SoundReproducingEquipment
    {
        public void Listening()
        {
            Console.WriteLine("Студент проходит аудіювання.");
        }
    }

    class Computer
    {
        public void Сompiler()
        {
            Console.WriteLine("Студент використовує комп'ютер.");
        }
    }

    class Facade
    {
        Notebook notebook;
        SoundReproducingEquipment equipment;
        Computer computer;

        public Facade(Notebook note, SoundReproducingEquipment eq, Computer pc)
        {
            this.notebook = note;
            this.equipment = eq;
            this.computer = pc;
        }

        public void Start()
        {
            notebook.Wrtitting();
            equipment.Listening();
            computer.Сompiler();
        }
    }

    class Study
    {
        public void Lesson(Facade facade)
        {
            facade.Start();
        }
    }
}
