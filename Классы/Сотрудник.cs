using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Генератор_распоряжений
{
    [Serializable]
    public class Сотрудник
    {
        private String _Фамилия;
        private String _Инициалы;
        private String _Группа_ЭБ;

        public String Фамилия
        {
            get
            {
                return _Фамилия;
            }
            set
            {
                _Фамилия = value;
            }
        }
        public String Инициалы
        {
            get
            {
                return _Инициалы;
            }
            set
            {
                _Инициалы = value;
            }
        }
        public String Группа_ЭБ
        {
            get
            {
                return _Группа_ЭБ;
            }
            set
            {
                _Группа_ЭБ = value;
            }
        }

        protected Сотрудник()
        {
        }
        public Сотрудник(String Фамилия_сотрудника, String Инициалы_сотрудника, String Группа_ЭБ_сотрудника)
        {
            _Фамилия = Фамилия_сотрудника;
            _Инициалы = Инициалы_сотрудника;
            _Группа_ЭБ = Группа_ЭБ_сотрудника;
        }
    }
}
