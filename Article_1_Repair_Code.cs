using System;
using System.Collections.Generic;
namespace Home_work_2
{
    enum Menu
    {
        RegisterNewStudent = 1,
        RegisterNewTeacher,
        GetListPersons
    }
    class Person
    {
        protected string name;
        protected string address;
        protected string citizenID;

        public Person(string name, string address, string citizenID)
        {
            this.name = name;
            this.address = address;
            this.citizenID = citizenID;
        }

        public string GetName()
        {
            return this.name;
        }

    }
    class Teacher : Person
    {
        private string employeeID;

        public Teacher(string name, string address, string citizenID, string employeeID)
        : base(name, address, citizenID)
        {
            this.employeeID = employeeID;
        }

    }
    class PersonList
    {
        private List<Person> personList;

        public PersonList()
        {
            this.personList = new List<Person>();
        }

        public void AddNewPerson(Person person)
        {
            this.personList.Add(person);
        }

        public void FetchPersonsList()
        {
            Console.WriteLine("List Persons");
            Console.WriteLine("---------------------");
            foreach (Person person in this.personList)
            {
                if (person is Student)
                {
                    Console.WriteLine("Name: {0} \nType: Student \n", person.GetName());
                }
                else if (person is Teacher)
                {
                    Console.WriteLine("Name: {0} \nType: Teacher \n", person.GetName());
                }
            }
        }
    }
    class Student : Person
    {
        private string studentID;

        public Student(string name, string address, string citizenID, string studentID)
        : base(name, address, citizenID) {
            this.studentID = studentID;
        }

    }
    class Program
    {
        static PersonList personList;

        static void Main(string[] args)
        {
            PreparePersonListWhenProgramIsLoad();
            PrintMenuScreen();
        }

        static void PreparePersonListWhenProgramIsLoad()
        {
            Program.personList = new PersonList();
        }

        static void PrintMenuScreen()
        {
            Console.Clear();
            PreparePersonListNew.PrintHeader();
            PreparePersonListNew.PrintListMenu();
            InputMenuFromKeyboard();
        }

        static void InputMenuFromKeyboard()
        {
            Console.Write("Please Select Menu: ");
            Menu menu = (Menu)(int.Parse(Console.ReadLine()));

            PresentMenu(menu);
        }

        static void PresentMenu(Menu menu)
        {
            if (menu == Menu.RegisterNewStudent)
            {
                ShowInputRegisterNewStudentScreen();
            }
            else if (menu == Menu.RegisterNewTeacher)
            {
                ShowInputRegisterNewTeacherScreen();
            }
            else if (menu == Menu.GetListPersons)
            {
                ShowGetListPersonScreen();
            }
            else
            {
                ShowMessageInputMenuIsInCorrect();
            }
        }

        static void ShowInputRegisterNewStudentScreen()
        {
            Console.Clear();
            newregister.PrintHeaderRegisterStudent();

            int totalStudent = newTotalStudentsTeacher.TotalNewStudents();
            InputNewStudentFromKeyboard(totalStudent);
        }

        static void ShowInputRegisterNewTeacherScreen()
        {
            Console.Clear();
            newregister.PrintHeaderRegisterTeacher();

            int totalTeacher = newTotalStudentsTeacher.TotalNewTeacher();
            InputNewTeacherFromKeyboard(totalTeacher);
        }

        static void ShowGetListPersonScreen()
        {
            Console.Clear();
            Program.personList.FetchPersonsList();
            InputExitFromKeyboard();
        }

        static void InputExitFromKeyboard()
        {
            string text = "";
            while (text != "exit")
            {
                Console.WriteLine("Input: ");
                text = Console.ReadLine();
            }

            Console.Clear();
            PrintMenuScreen();
        }

        static void InputNewTeacherFromKeyboard(int totalTeacher)
        {
            for (int i = 0; i < totalTeacher; i++)
            {
                Console.Clear();
                newregister.PrintHeaderRegisterTeacher();

                Teacher teacher = NewCreateNewStudent.CreateNewTeacher();
                Program.personList.AddNewPerson(teacher);
            }

            Console.Clear();
            PrintMenuScreen();
        }

        static void InputNewStudentFromKeyboard(int totalStudent)
        {
            for (int i = 0; i < totalStudent; i++)
            {
                Console.Clear();
                newregister.PrintHeaderRegisterStudent();

                Student student = NewCreateNewStudent.CreateNewStudent();
                Program.personList.AddNewPerson(student);
            }

            Console.Clear();
            PrintMenuScreen();
        }
        static void ShowMessageInputMenuIsInCorrect()
        {
            Console.Clear();
            Console.WriteLine("Menu Incorrect Please try again.");
            InputMenuFromKeyboard();
        }
    }

    class PreparePersonListNew
    {
        public static void PrintHeader()
        {
            Console.WriteLine("Welcome to registration new user school application.");
            Console.WriteLine("----------------------------------------------------");
        }
        public static void PrintListMenu()
        {
            Console.WriteLine("1. Register new student.");
            Console.WriteLine("2. Register new Teacher.");
            Console.WriteLine("3. Get List Persons.");
        }

    }
    class InputNamenew
    {
        public static string InputName()
        {
            Console.Write("Name: ");

            return Console.ReadLine();
        }
        public static string InputStudentID()
        {
            Console.Write("Student ID: ");

            return Console.ReadLine();
        }

        public static string InputAddress()
        {
            Console.Write("Address: ");

            return Console.ReadLine();
        }

        public static string InputCitizenID()
        {
            Console.Write("Citizen ID: ");

            return Console.ReadLine();
        }

        public static string InputEmployeeID()
        {
            Console.Write("Employee ID: ");

            return Console.ReadLine();
        }

    }

    class newTotalStudentsTeacher
    { 
        public static int TotalNewStudents()
    {
        Console.Write("Input Total new Student: ");

        return int.Parse(Console.ReadLine());
    }

        public static int TotalNewTeacher()
    {
        Console.Write("Input Total new Teacher: ");

        return int.Parse(Console.ReadLine());
    }

    }

    class newregister
    {
        public static void PrintHeaderRegisterStudent()
        {
            Console.WriteLine("Register new student.");
            Console.WriteLine("---------------------");
        }

        public static void PrintHeaderRegisterTeacher()
        {
            Console.WriteLine("Register new teacher.");
            Console.WriteLine("---------------------");
        }
    }
    class NewCreateNewStudent
    {
        public static Student CreateNewStudent()
        {
            return new Student(InputNamenew.InputName(),
             InputNamenew.InputAddress(),
             InputNamenew.InputCitizenID(),
             InputNamenew.InputStudentID());
        }

        public static Teacher CreateNewTeacher()
        {
            return new Teacher(InputNamenew.InputName(),
            InputNamenew.InputAddress(),
            InputNamenew.InputCitizenID(),
            InputNamenew.InputEmployeeID());
        }

    }
}


