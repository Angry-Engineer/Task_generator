using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Генератор_распоряжений
{
    [Serializable]
    public class Группа
    {
        private String _Наименование;
        public String Наименование
        {
            get
            {
                return _Наименование;
            }
            set
            {
                _Наименование = value;
            }
        }

        private List<Сотрудник> _Лист_сотрудников;
        public List<Сотрудник> Лист_сотрудников
        {
            get
            {
                return _Лист_сотрудников;
            }
            set
            {
                _Лист_сотрудников = value;
            }
        }

        protected Группа()
        {
        }
        public Группа(String Наименование_группы, List<Сотрудник> Лист_сотрудников_группы)
        {
            _Наименование = Наименование_группы;
            _Лист_сотрудников = Лист_сотрудников_группы;
        }
        public Группа(String Наименование_группы)
        {
            _Наименование = Наименование_группы;
        }
    }
}
