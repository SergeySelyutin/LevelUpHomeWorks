using System;
using System.Text;

namespace _20161203_StudentsProgress
{
    struct GroupOfStudents
    {
        Student[] _students;
        byte _studentsCount;

        internal Student[] Students
        {
            get
            {
                return _students;
            }

            set
            {
                //_students = value;
            }
        }

        public byte StudentsCount
        {
            get
            {
                return _studentsCount;
            }

            set
            {
                _studentsCount = value;
            }
        }

        /// <summary>
        /// Добавляет студента в список группы
        /// </summary>
        /// <param name="newStudent"> Новый студент </param>
        public void AddStudent(ref Student newStudent)
        {
            _students[StudentsCount] = newStudent;
            StudentsCount++;
        }

        public GroupOfStudents(int studMaxCount)
        {
            _students = new Student[studMaxCount];
            _studentsCount = 0;
        }

        /// <summary>
        /// Удаляет студента по заданному номеру зачетки
        /// </summary>
        /// <param name="id"> Номер зачетки </param>
        public void RemoveStudent(int id)
        {
            for (int i = 0; i < StudentsCount; i++)
            {
                if (Students[i].Id == id)
                {
                    for (int j = i; j < StudentsCount; j++)
                    {
                        Students[j] = Students[j + 1];
                    }
                    break;
                }
            }
            _studentsCount--;
        }

        public void ChangeStudentsInformation(int id)
        {
            bool isExit = false;
            for (int i = 0; i < StudentsCount; i++)
            {
                if (Students[i].Id == id)
                {
                    do
                    {
                        Console.Clear();
                        Console.WriteLine(Students[i].ToString());
                        Console.WriteLine("Выберите, что нужно изменить, или нажмите 6 для завершения редактирования:");
                        byte selected = byte.Parse(Console.ReadLine());
                        if (selected > 0 && selected < 7)
                        {
                            switch (selected)
                            {
                                case 1:
                                    Console.Clear();
                                    Console.WriteLine("Введите новый ID:");
                                    bool isIDExists = false;                                 // Проверка на существование такого же ID
                                    int idcode = int.Parse(Console.ReadLine());
                                    foreach (Student std in Students)
                                    {
                                        if (std.Id == idcode)
                                        {
                                            isIDExists = true;
                                            break;
                                        }
                                    }
                                    if (!isIDExists)
                                    {
                                        Students[i].Id = idcode;
                                    }
                                    break;
                                case 2:
                                    Console.Clear();
                                    Console.WriteLine("Введите новое имя:");
                                    Students[i].Name = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.Clear();
                                    Console.WriteLine("Введите новую фамилию:");
                                    Students[i].LastName = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.Clear();
                                    Console.WriteLine("Введите новую дату рождения:");
                                    Students[i].BirthDate = DateTime.Parse(Console.ReadLine());
                                    break;
                                case 5:
                                    Console.Clear();
                                    Console.WriteLine("Ввод оценок:");
                                    InputMarks(ref Students[i]);
                                    break;
                                default:
                                    isExit = true;
                                    break;
                            }
                        }
                        Console.WriteLine("Escape");
                    }
                    while (!isExit);
                }
            }
        }

        private void InputMarks(ref Student stud)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < stud.Marks.Length; i++)
            {
                sb.AppendFormat("\t{0} неделя:\n", i);
                sb.Append(stud.Marks[i].ToString());
            }
            Console.WriteLine(sb.ToString());
            Console.WriteLine("\nВведите номер недели для редактирования:");
            byte weekNumber = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите номер предмета для редактирования:");
            byte subject = byte.Parse(Console.ReadLine());
            Console.WriteLine("Введите оценку:");
            byte mark = byte.Parse(Console.ReadLine());
            switch (subject)
            {
                case (byte)Marks.subjects.programming:
                    stud.Marks[weekNumber].Programming = mark;
                    break;
                case (byte)Marks.subjects.math:
                    stud.Marks[weekNumber].Math = mark;
                    break;
                case (byte)Marks.subjects.physics:
                    stud.Marks[weekNumber].Physics = mark;
                    break;
                case (byte)Marks.subjects.history:
                    stud.Marks[weekNumber].History = mark;
                    break;
                default:
                    Console.WriteLine("Вы ввели не верное значение!");
                    break;
            }
        }

        public void FindStudent(int id)
        {
            foreach (Student stud in _students)
            {
                if (stud.Id == id)
                {
                    Console.WriteLine(stud.ToString());
                }
            }
        }
        public void FindStudent(string lastName)
        {
            foreach (Student stud in _students)
            {
                if (stud.LastName == lastName)
                {
                    Console.WriteLine(stud.ToString());
                }
            }
        }

        public void PrintBestWhorstStudent()
        {
            Student bestStud = _students[0];
            Student whorstStud = _students[0];
            for (int i = 0; i < _studentsCount; i++)
            {
                if (bestStud.GetGPA() < _students[i].GetGPA())
                {
                    bestStud = _students[i];
                }
                if (whorstStud.GetGPA() > _students[i].GetGPA())
                {
                    whorstStud = _students[i];
                }
            }
            Console.Clear();
            Console.WriteLine("Лучший студент:\n{0}", bestStud.ToString());
            Console.WriteLine("Хучший студент:\n{0}", whorstStud.ToString());
        }

        public double getGroupGPA()
        {
            double groupGPA = 0;
            for (int i = 0; i < StudentsCount; i++)
            {
                groupGPA += Students[i].GetGPA();
            }
            groupGPA /= StudentsCount;
            return groupGPA;
        }
    }
}
