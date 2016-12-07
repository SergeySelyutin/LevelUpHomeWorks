using System;
using System.Text;

namespace _20161203_StudentsProgress
{
    struct Student
    {
        int _id;             // Номер зачётной книжки студента
        string _name;        // Имя студента
        string _lastName;    // Фамилия студента
        DateTime _birthDay; // Дата рождения студента
        Marks[] _marks;      // Оценки студента

        #region Getters And Setters
        public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }

            set
            {
                _lastName = value;
            }
        }

        public DateTime BirthDate
        {
            get
            {
                return _birthDay;
            }

            set
            {
                _birthDay = value;
            }
        }

        internal Marks[] Marks
        {
            get
            {
                return _marks;
            }

            set
            {
                _marks = value;
            }
        }
        #endregion

        /// <summary>
        /// Конструктор, инициализирующий все поля
        /// </summary>
        /// <param name="id"> Номер зачётной книжки студента </param>
        /// <param name="name"> Имя студента </param>
        /// <param name="lastName"> Фамилия студента </param>
        /// <param name="birthDate"> Дата рождения студента </param>
        /// <param name="marks"> Оценки студента </param>
        public Student(int id, string name, string lastName, DateTime birthDate)
        {
            _id = id;
            _name = name;
            _lastName = lastName;
            _birthDay = birthDate;
            _marks = new Marks[4];
            for (int i = 0; i < 4; i++)
            {
                _marks[i].Programming = (byte)Program.rnd.Next(1, 5);
                _marks[i].Math = (byte)Program.rnd.Next(1, 5);
                _marks[i].Physics = (byte)Program.rnd.Next(1, 5);
                _marks[i].History = (byte)Program.rnd.Next(1, 5);
            }
        }

        /// <summary>
        /// Возвращает средний балл студента GPA - Grade Point Average
        /// </summary>
        /// <returns> средний балл студента </returns>
        public double GetGPA()
        {
            double averageGPA = 0;
            for (int i = 0; i < _marks.Length; i++)
            {
                averageGPA += _marks[i].GetGPA();
            }

            return averageGPA/_marks.Length;
        }


        /// <summary>
        /// Возвращает возраст студента
        /// </summary>
        /// <returns> Возраст студента </returns>
        public byte GetAge()
        {
            return (byte)((DateTime.Now - BirthDate).Days / 365);
        }

        public override string ToString()
        {
            StringBuilder sbStudents = new StringBuilder();
            sbStudents.Append("Информация о студенте:\n");
            sbStudents.AppendFormat("1. ID:\t{0}\n", _id);
            sbStudents.AppendFormat("2. Имя:\t{0}\n", _name);
            sbStudents.AppendFormat("3. Фамилия:\t{0}\n", _lastName);
            sbStudents.AppendFormat("4. День рождения:\t{0}\n", _birthDay);
            sbStudents.Append("5. Оценки студента:\n");
            for (int i = 0; i < _marks.Length; i++)
            {
                sbStudents.AppendFormat("  {0} неделя:\n", i);
                sbStudents.Append(_marks[i].ToString());
            }
            return sbStudents.ToString();
        }
    }
}
