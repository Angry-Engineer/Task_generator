﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace Генератор_распоряжений
{
    public class Распоряжение
    {
        private DateTime _Дата;
        private String _Организация;
        private String _Структурная_единица;
        private String _Производитель;
        private String _Допускающий;
        private String _Бригада;
        private String _Задание;
        private String _Объект;
        private String _Расположение;
        private String _Условия_работы;
        private String _Распоряжение_выдал;

        public DateTime Дата
        {
            get
            {
                return _Дата;
            }
            set
            {
                _Дата = value;
            }
        }
        public String Организация
        {
            get
            {
                return _Организация;
            }
            set
            {
                _Организация = value;
            }
        }
        public String Структурная_единица
        {
            get
            {
                return _Структурная_единица;
            }
            set
            {
                _Структурная_единица = value;
            }
        }
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

        private PointF _Позиция_каретки;
        private String _Текст;
        private Font _Шрифт_шапка = new Font("Microsoft Sans Serif", 14, FontStyle.Bold);
        private Font _Шрифт_заголовок = new Font("Microsoft Sans Serif", 10, FontStyle.Bold);
        private Font _Шрифт_текст = new Font("Microsoft Sans Serif", 10, FontStyle.Regular);
        private Brush _Перо = Brushes.Black;

        float _Межстрочный_отступ = 5;

        protected Распоряжение()
        {
        }
        public Распоряжение(DateTime Дата_распоряжения, String Организация, String Структурная_единица, String Производитель_распоряжения, String Допускающий_распоряжения, String Бригада_распоряжения, String Задание_распоряжения, String Объект_распоряжения, String Расположение_распоряжения, String Условия_работы_распоряжения, String Источник_распоряжения)
        {
            _Организация = Организация;
            _Структурная_единица = Структурная_единица;
            _Дата = Дата_распоряжения;
            _Производитель = Производитель_распоряжения;
            _Допускающий = Допускающий_распоряжения;
            _Бригада = Бригада_распоряжения;
            _Задание = Задание_распоряжения;
            _Объект = Объект_распоряжения;
            _Расположение = Расположение_распоряжения;
            _Условия_работы = Условия_работы_распоряжения;
            _Распоряжение_выдал = Источник_распоряжения;
        }
        public void Печать(PrintPageEventArgs Принтер, float Стартовая_позиция)
        {
            SizeF _Область_печати = Принтер.PageSettings.PrintableArea.Size;

            float _Левая_граница = Принтер.PageSettings.PrintableArea.Left;
            float _Правая_граница = Принтер.PageSettings.PrintableArea.Right;
            float _Верхняя_граница = Принтер.PageSettings.PrintableArea.Top;
            float _Нижняя_граница = Принтер.PageSettings.PrintableArea.Bottom;

            float X_заголовок_осн = _Левая_граница;
            float X_текст_осн = X_заголовок_осн + 240;
            float X_заголовок_доп = _Правая_граница - 250;
            float X_текст_доп = _Правая_граница - 150; ;

            float X_старт = _Левая_граница;
            float Y_старт;

            SizeF _размер_ОП_строки;
            RectangleF _ОП_строки;

            Int32 Ширина_ОП = Convert.ToInt32(_Область_печати.Width);

            Int32 Колонка_1 = 235;
            Int32 Колонка_3 = 120;
            Int32 Колонка_2 = Convert.ToInt32((Ширина_ОП - Колонка_1 - Колонка_3) * 0.65);
            Int32 Колонка_4 = Ширина_ОП - Колонка_1 - Колонка_2 - Колонка_3;

            Int32 Отступ = 15;

            #region Настройка начальной позиции каретки

            if (Стартовая_позиция > _Верхняя_граница)
            {
                Y_старт = Стартовая_позиция;
            }
            else
            {
                Y_старт = _Верхняя_граница;
            }

            #endregion

            #region Распоряжение

            _Позиция_каретки = new PointF(X_старт, Y_старт);

            #region Шапка

            _Текст = _Организация;

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_шапка, Convert.ToInt32(_Область_печати.Width - _Позиция_каретки.X));
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_шапка, _Перо, _ОП_строки);

            _Текст = _Структурная_единица;

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_шапка, Колонка_3);
            _Позиция_каретки = new PointF(_Область_печати.Width - Колонка_4 - _размер_ОП_строки.Width, Y_старт);

            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_шапка, _Перо, _ОП_строки);

            #endregion
            #region Номер распоряжения

            _Текст = "Распоряжение №:";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + 2 * _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = "__________";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            #endregion
            #region Дата распоряжения

            _Текст = "Дата:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_3);
            _Позиция_каретки.X = _Правая_граница - Колонка_4 - _размер_ОП_строки.Width - Отступ;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = _Дата.ToShortDateString();
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_4);
            _Позиция_каретки.X = Колонка_1 + Колонка_2 + Колонка_3;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            #endregion
            #region Производитель

            _Текст = "Производителю работ:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = _Производитель;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            float Сдвиг_членов_бригады = _ОП_строки.Height;
            #endregion         
            #region Допускающий

            _Текст = "Допускающему:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_3);
            _Позиция_каретки.X = _Правая_граница - Колонка_4 - _размер_ОП_строки.Width - Отступ + 4;
            _Позиция_каретки.Y = _Позиция_каретки.Y;

            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = _Допускающий;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_4);
            _Позиция_каретки.X = Колонка_1 + Колонка_2 + Колонка_3;
            _Позиция_каретки.Y = _Позиция_каретки.Y;

            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            float _Y_завершения_допускающий = _ОП_строки.Top + _ОП_строки.Height;
            #endregion          
            #region Бригада

            _Текст = "с членами бригады:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + Сдвиг_членов_бригады;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = "--/--";
            if (_Бригада != "")
            {
                _Текст = _Бригада;
            }

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            float _Y_завершения_бригада = _ОП_строки.Top + _ОП_строки.Height;
                
            float Сдвиг_содержания_работы = 0;

            if (_Y_завершения_допускающий >= _Y_завершения_бригада)
            {
                Сдвиг_содержания_работы = _Y_завершения_допускающий;
            }
            else
            {
                Сдвиг_содержания_работы = _Y_завершения_бригада;
            }
            #endregion
            #region Содержание работы

            _Текст = "Содержание работы:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = Сдвиг_содержания_работы + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = _Задание;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Ширина_ОП - Колонка_1);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            #endregion
            #region Объект

            _Текст = "Объект:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = _Объект;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Ширина_ОП - Колонка_1);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            #endregion
            #region Место работы и позиция

            _Текст = "Место работы и позиция:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = _Расположение;

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Ширина_ОП - Колонка_1);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            #endregion
            #region Условия производства работ

            _Текст = "Условия производства работ:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = _Условия_работы;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Ширина_ОП - Колонка_1);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            #endregion
            #region Распоряжение выдал

            _Текст = "Распоряжение выдал:";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = _Распоряжение_выдал;

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            _Текст = "Подпись:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_3);
            _Позиция_каретки.X = _Правая_граница - Колонка_4 - _размер_ОП_строки.Width - Отступ;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = "__________";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_4);
            _Позиция_каретки.X = Колонка_1 + Колонка_2 + Колонка_3;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            #endregion
            #region Допускающий

            _Текст = "Допускающий:";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = "_________________________";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            _Текст = "Подпись:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_3);
            _Позиция_каретки.X = _Правая_граница - Колонка_4 - _размер_ОП_строки.Width - Отступ;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_заголовок, _Перо, _ОП_строки);

            _Текст = "__________";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_4);
            _Позиция_каретки.X = Колонка_1 + Колонка_2 + Колонка_3;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);
            Принтер.Graphics.DrawString(_Текст, _Шрифт_текст, _Перо, _ОП_строки);

            #endregion
            #region Линия отрыва

            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + 5 * _Межстрочный_отступ;
            Принтер.Graphics.DrawLine(new Pen(_Перо, 2), new PointF(_Левая_граница, _Позиция_каретки.Y), new PointF(_Правая_граница, _Позиция_каретки.Y));
            #endregion
            #endregion
        }
        public SizeF Размер_печатного_оттиска(PrintPageEventArgs Принтер)
        {
            SizeF _Область_печати = Принтер.PageSettings.PrintableArea.Size;
            SizeF _Размер_печатного_оттиска = new SizeF(_Область_печати.Width, 0);

            float _Левая_граница = Принтер.PageSettings.PrintableArea.Left;
            float _Правая_граница = Принтер.PageSettings.PrintableArea.Right;
            float _Верхняя_граница = Принтер.PageSettings.PrintableArea.Top;
            float _Нижняя_граница = Принтер.PageSettings.PrintableArea.Bottom;

            float X_старт = _Левая_граница;
            float Y_старт = _Верхняя_граница;

            SizeF _размер_ОП_строки;
            RectangleF _ОП_строки;

            Int32 Ширина_ОП = Convert.ToInt32(_Область_печати.Width);

            Int32 Колонка_1 = 235;
            Int32 Колонка_3 = 120;
            Int32 Колонка_2 = Convert.ToInt32((Ширина_ОП - Колонка_1 - Колонка_3) * 0.60);
            Int32 Колонка_4 = Ширина_ОП - Колонка_1 - Колонка_2 - Колонка_3;

            Int32 Отступ = 15;

            #region Распоряжение

            #region Шапка

            _Текст = "Филиал ПАО \"ОГК-2\" - Сургутская ГРЭС-1";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_шапка, Convert.ToInt32(_Область_печати.Width - _Позиция_каретки.X));
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = "Цех ТАИ";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_шапка, Колонка_3);
            _Позиция_каретки = new PointF(_Область_печати.Width - Колонка_4 - _размер_ОП_строки.Width, Y_старт);

            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            #endregion
            #region Номер распоряжения

            _Текст = "Распоряжение №:";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + 2 * _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = "__________";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            #endregion
            #region Дата распоряжения

            _Текст = "Дата:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_3);
            _Позиция_каретки.X = _Правая_граница - Колонка_4 - _размер_ОП_строки.Width - Отступ;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = _Дата.ToShortDateString();
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_4);
            _Позиция_каретки.X = Колонка_1 + Колонка_2 + Колонка_3;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            #endregion
            #region Производитель

            _Текст = "Производителю работ:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = _Производитель;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            float Сдвиг_членов_бригады = _ОП_строки.Height;
            #endregion         
            #region Допускающий

            _Текст = "Допускающему:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_3);
            _Позиция_каретки.X = _Правая_граница - Колонка_4 - _размер_ОП_строки.Width - Отступ + 4;
            _Позиция_каретки.Y = _Позиция_каретки.Y;

            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = _Допускающий;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_4);
            _Позиция_каретки.X = Колонка_1 + Колонка_2 + Колонка_3;
            _Позиция_каретки.Y = _Позиция_каретки.Y;

            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            float _Y_завершения_допускающий = _ОП_строки.Top + _ОП_строки.Height;
            #endregion          
            #region Бригада

            _Текст = "с членами бригады:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + Сдвиг_членов_бригады;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = "--/--";
            if (_Бригада != "")
            {
                _Текст = _Бригада;
            }

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            float _Y_завершения_бригада = _ОП_строки.Top + _ОП_строки.Height;

            float Сдвиг_содержания_работы = 0;

            if (_Y_завершения_допускающий >= _Y_завершения_бригада)
            {
                Сдвиг_содержания_работы = _Y_завершения_допускающий;
            }
            else
            {
                Сдвиг_содержания_работы = _Y_завершения_бригада;
            }
            #endregion
            #region Содержание работы

            _Текст = "Содержание работы:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = Сдвиг_содержания_работы + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = _Задание;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Ширина_ОП - Колонка_1);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            #endregion
            #region Объект

            _Текст = "Объект:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = _Объект;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Ширина_ОП - Колонка_1);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            #endregion
            #region Место работы и позиция

            _Текст = "Место работы и позиция:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = _Расположение;

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Ширина_ОП - Колонка_1);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            #endregion
            #region Условия производства работ

            _Текст = "Условия производства работ:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = _Условия_работы;
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Ширина_ОП - Колонка_1);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            #endregion
            #region Распоряжение выдал

            _Текст = "Распоряжение выдал:";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = _Распоряжение_выдал;

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = "Подпись:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_3);
            _Позиция_каретки.X = _Правая_граница - Колонка_4 - _размер_ОП_строки.Width - Отступ;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = "__________";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_4);
            _Позиция_каретки.X = Колонка_1 + Колонка_2 + Колонка_3;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            #endregion
            #region Допускающий

            _Текст = "Допускающий:";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_1);
            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + _Межстрочный_отступ;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = "_________________________";

            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_2);
            _Позиция_каретки.X = Колонка_1;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = "Подпись:";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_заголовок, Колонка_3);
            _Позиция_каретки.X = _Правая_граница - Колонка_4 - _размер_ОП_строки.Width - Отступ;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            _Текст = "__________";
            _размер_ОП_строки = Принтер.Graphics.MeasureString(_Текст, _Шрифт_текст, Колонка_4);
            _Позиция_каретки.X = Колонка_1 + Колонка_2 + Колонка_3;
            _Позиция_каретки.Y = _Позиция_каретки.Y;
            _ОП_строки = new RectangleF(_Позиция_каретки, _размер_ОП_строки);

            #endregion
            #region Линия отрыва

            _Позиция_каретки.X = _Левая_граница;
            _Позиция_каретки.Y = _Позиция_каретки.Y + _ОП_строки.Height + 5 * _Межстрочный_отступ;
            #endregion

            #endregion

            _Позиция_каретки.Y = _Позиция_каретки.Y + _Межстрочный_отступ;
            _Размер_печатного_оттиска.Height = (_Позиция_каретки.Y - Y_старт);

            return _Размер_печатного_оттиска;
        }
    }
}
