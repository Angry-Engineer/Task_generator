using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Генератор_распоряжений
{
    [Serializable]
    public class Распоряжение_шаблон
    {
        private String _Производитель;
        private String _Допускающий;
        private String _Бригада;
        private String _Задание;
        private String _Объект;
        private String _Расположение;
        private String _Условия_работы;
        private String _Распоряжение_выдал;

        public String Производитель
        {
            get
            {
                return _Производитель;
            }
            set
            {
                _Производитель = value;
            }
        }
        public String Допускающий
        {
            get
            {
                return _Допускающий;
            }
            set
            {
                _Допускающий = value;
            }
        }
        public String Бригада
        {
            get
            {
                return _Бригада;
            }
            set
            {
                _Бригада = value;
            }
        }
        public String Задание
        {
            get
            {
                return _Задание;
            }
            set
            {
                _Задание = value;
            }
        }
        public String Объект
        {
            get
            {
                return _Объект;
            }
            set
            {
                _Объект = value;
            }
        }
        public String Расположение
        {
            get
            {
                return _Расположение;
            }
            set
            {
                _Расположение = value;
            }
        }
        public String Условия_работы
        {
            get
            {
                return _Условия_работы;
            }
            set
            {
                _Условия_работы = value;
            }
        }
        public String Распоряжение_выдал
        {
            get
            {
                return _Распоряжение_выдал;
            }
            set
            {
                _Распоряжение_выдал = value;
            }
        }

        protected Распоряжение_шаблон()
        {
        }
        public Распоряжение_шаблон(String Производитель_распоряжения, String Допускающий_распоряжения, String Бригада_распоряжения, String Задание_распоряжения, String Объект_распоряжения, String Расположение_распоряжения, String Условия_работы_распоряжения, String Источник_распоряжения)
        {
            _Производитель = Производитель_распоряжения;
            _Допускающий = Допускающий_распоряжения;
            _Бригада = Бригада_распоряжения;
            _Задание = Задание_распоряжения;
            _Объект = Объект_распоряжения;
            _Расположение = Расположение_распоряжения;
            _Условия_работы = Условия_работы_распоряжения;
            _Распоряжение_выдал = Источник_распоряжения;
        }
    }
}
