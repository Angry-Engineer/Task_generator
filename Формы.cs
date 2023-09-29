using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Генератор_распоряжений
{
    public class Формы
    {
        protected Формы()
        {
            this.InitClass();
        }
        static private Формы _Формы;
        static public Формы Instance()
        {
            if (_Формы == null)
            {
                _Формы = new Формы();
            }

            return _Формы;
        }
        private void InitClass()
        {
        }

        private order_generator_form _Основная_форма;
        public order_generator_form Основная_форма
        {
            get
            {
                if (_Основная_форма == null)
                {
                    _Основная_форма = new order_generator_form();
                    _Основная_форма.Disposed += new EventHandler(_Основная_форма_Disposed);
                }
                return _Основная_форма;
            }
        }
        void _Основная_форма_Disposed(object sender, EventArgs e)
        {
            _Основная_форма = null;
        }

        private printer_spool_form _Очередь_печати;
        public printer_spool_form Очередь_печати
        {
            get
            {
                if (_Очередь_печати == null)
                {
                    _Очередь_печати = new printer_spool_form();
                    _Очередь_печати.Disposed += new EventHandler(_Очередь_печати_Disposed);
                }
                return _Очередь_печати;
            }
        }
        void _Очередь_печати_Disposed(object sender, EventArgs e)
        {
            _Очередь_печати = null;
        }

        private workers_form _Персонал;
        public workers_form Персонал
        {
            get
            {
                if (_Персонал == null)
                {
                    _Персонал = new workers_form();
                    _Персонал.Disposed += new EventHandler(_Персонал_Disposed);
                }
                return _Персонал;
            }
        }
        void _Персонал_Disposed(object sender, EventArgs e)
        {
            _Персонал = null;
        }
    }
}
