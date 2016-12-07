using System.Text;

namespace _20161203_StudentsProgress
{
    struct Marks
    {
        const double NUMBER_OF_MARKS = 4;   // Количество оценок студента по каждому предмету
        byte _programming;                  // Оценка по программированию
        byte _math;                         // Оценка по математике
        byte _physics;                      // Оценка по физике
        byte _history;                      // Оценка по истории

        public enum subjects : byte
        {
            empty,
            programming,
            math,
            physics,
            history
        }

        public Marks(byte programming, byte math, byte physics, byte history)
        {
            _programming = programming;
            _math = math;
            _physics = physics;
            _history = history;
        }
        
        #region GettersAndSetters
        public byte Programming
        {
            get
            {
                return _programming;
            }

            set
            {
                if (value > 0 && value < 6)
                {
                    _programming = value;
                }
            }
        }

        public byte Math
        {
            get
            {
                return _math;
            }

            set
            {
                if (value > 0 && value < 6)
                {
                    _math = value;
                }
            }
        }

        public byte Physics
        {
            get
            {
                return _physics;
            }

            set
            {
                if (value > 0 && value < 6)
                {
                    _physics = value;
                }
            }
        }

        public byte History
        {
            get
            {
                return _history;
            }

            set
            {
                if (value > 0 && value < 6)
                {
                    _history = value;
                }
            }
        }
        #endregion

        /// <summary>
        /// Возвращает средний балл по всем предметам
        /// </summary>
        /// <returns> Средний балл по всем предметам </returns>
        public double GetGPA()
        {
            return (Programming * 1.0 + Math + Physics + History) / NUMBER_OF_MARKS;
        }

        public override string ToString()
        {
            StringBuilder sbMarks = new StringBuilder();
            sbMarks.AppendFormat("\t\t1. Программирование:\t{0}\n", _programming);
            sbMarks.AppendFormat("\t\t2. Математика:\t\t{0}\n", _math);
            sbMarks.AppendFormat("\t\t3. Физика:\t\t{0}\n", _physics);
            sbMarks.AppendFormat("\t\t4. История:\t\t{0}\n", _history);
            return sbMarks.ToString();
        }
    }
}
