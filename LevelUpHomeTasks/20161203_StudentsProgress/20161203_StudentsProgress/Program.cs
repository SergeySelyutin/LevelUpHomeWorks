using System;
using System.Text;

namespace _20161203_StudentsProgress
{
    class Program
    {
        public static Random rnd = new Random();
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            byte choise;
            GroupOfStudents group1 = new GroupOfStudents(50);
            bool isExit = false;
            Student std = new Student(111, "Sergey", "Selyutin", DateTime.Parse("3.11.87"));
            group1.AddStudent(ref std);
            std = new Student(222, "222", "222", DateTime.Parse("2.2.2"));
            group1.AddStudent(ref std);
            std = new Student(333, "333", "333", DateTime.Parse("3.3.3"));
            group1.AddStudent(ref std);
            std = new Student(444, "444", "444", DateTime.Parse("4.4.4"));
            group1.AddStudent(ref std);
            do
            {
                sb.Clear();
                Console.Clear();
                sb.Append("Выберите действие:\n");
                sb.Append("1. Добавить студента\n");
                sb.Append("2. Изменить студента\n");
                sb.Append("3. Удалить студента\n");
                sb.Append("4. Лучший/худший студент\n");
                sb.Append("5. Средний балл студента\n");
                sb.Append("6. Средний балл по группе\n");
                sb.Append("7. Поиск студента и вывод его данных\n");
                sb.Append("8. Вывод размера группы\n");
                sb.Append("9. Выход");
                Console.WriteLine(sb.ToString());
                if (byte.TryParse(Console.ReadLine(), out choise))
                {
                    switch (choise)
                    {

                        case 1:
                            Console.Clear();
                            Console.WriteLine("Введите Номер Зачетки нового студента:");
                            int id = int.Parse(Console.ReadLine());
                            Console.WriteLine("Введите Имя нового студента:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Введите Фамилию нового студента:");
                            string lastName = Console.ReadLine();
                            Console.WriteLine("Введите Дату Рождения нового студента:");
                            DateTime birthDay = DateTime.Parse(Console.ReadLine());

                            Student newStudent = new Student(id, name, lastName, birthDay);
                            group1.AddStudent(ref newStudent);
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("Введите Номер Зачетки студента для изменения:");
                            id = int.Parse(Console.ReadLine());
                            group1.ChangeStudentsInformation(id);
                            break;

                        case 3:
                            Console.Clear();
                            Console.WriteLine("Введите Номер Зачетки студента для изменения:");
                            id = int.Parse(Console.ReadLine());
                            group1.RemoveStudent(id);
                            break;

                        case 4:
                            group1.PrintBestWhorstStudent();
                            Console.WriteLine("Для продолжения нажмите любую кнопку...");
                            Console.ReadKey();
                            break;

                        case 5:
                            Console.Clear();
                            Console.WriteLine("Введите Номер Зачетки студента:");
                            id = int.Parse(Console.ReadLine());
                            for (int i = 0; i < group1.StudentsCount; i++)
                            {
                                if (group1.Students[i].Id == id)
                                {
                                    Console.WriteLine("Средний балл студента = {0}", group1.Students[i].GetGPA());
                                    break;
                                }
                            }
                            Console.WriteLine("Для продолжения нажмите любую кнопку...");
                            Console.ReadKey();
                            break;

                        case 6:
                            Console.Clear();
                            Console.WriteLine("Средний балл группы = {0}", group1.getGroupGPA());
                            Console.WriteLine("Для продолжения нажмите любую кнопку...");
                            Console.ReadKey();
                            break;

                        case 7:
                            Console.Clear();
                            Console.WriteLine("Введите Номер Зачетки студента или его Фамилию:");
                            string idOrLastName;
                            if (int.TryParse(idOrLastName = Console.ReadLine(), out id))
                            {
                                group1.FindStudent(id);
                            }
                            else
                            {
                                group1.FindStudent(idOrLastName);
                            }
                            Console.WriteLine("Для продолжения нажмите любую кнопку...");
                            Console.ReadKey();
                            break;

                        case 8:
                            Console.Clear();
                            Console.WriteLine("Размер группы: {0}", group1.StudentsCount);
                            Console.WriteLine("Нажмите любую кнопку для продолжения...");
                            Console.ReadKey();
                            break;

                        case 9:
                            isExit = true;
                            break;
                        default:
                            break;
                    }
                }
            } while (!isExit);
        }
    }
}
