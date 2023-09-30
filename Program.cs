using System;
using System.Windows.Forms;

namespace Генератор_распоряжений
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Формы.Instance().Основная_форма);
        }
    }
}
