using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Collections.Generic;

namespace Генератор_распоряжений
{
    public partial class printer_spool_form : Form
    {
        private bool Необходимо_поднять_форму = false;
        public void Показать()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

            this.Location = new Point(Формы.Instance().Основная_форма.Location.X, Формы.Instance().Основная_форма.Location.Y + Формы.Instance().Основная_форма.Height);
            this.Width = Формы.Instance().Основная_форма.Width;
            this.Height = 150;

            Формы.Instance().Основная_форма.Activated += new EventHandler(this.Поднять_на_верх);
            Формы.Instance().Основная_форма.Deactivate += new EventHandler(this.Сброс_флага_активации);
            Формы.Instance().Основная_форма.Move += new EventHandler(this.Прикрепить_к_родителю);
            Формы.Instance().Основная_форма.Resize += new EventHandler(this.Согласовать_размер);
        }
        public void Добавить_распоряжение(Распоряжение Распоряжение)
        {
            this.printer_spool_lstvw.Добавить_распоряжение(Распоряжение);
            Проверка_очереди_печати();
        }
        public void Печать_очереди()
        {
            try
            {
                if (this.print_dlg.ShowDialog() == DialogResult.OK)
                {
                    this.print_doc.Print();
                }
            }
            catch (InvalidPrinterException exp)
            {
                MessageBox.Show(exp.Message, "Произошла внезапная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        public void Печать_очереди_с_предпросмотром()
        {
            try
            {
                if (this.print_prvw_dlg.ShowDialog() == DialogResult.OK)
                {
                    if (this.print_dlg.ShowDialog() == DialogResult.OK)
                    {
                        this.print_doc.Print();
                    }
                }
            }
            catch (InvalidPrinterException exp)
            {
                MessageBox.Show(exp.Message, "Произошла внезапная ошибка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        private void Проверка_очереди_печати()
        {
            if (this.printer_spool_lstvw.Items.Count == 0)
            {
                Формы.Instance().Основная_форма.Печать_блокирована();
            }
            else
            {
                Формы.Instance().Основная_форма.Печать_доступна();
            }
        }

        private List<Распоряжение> Спулл_распоряжений = new List<Распоряжение>();

        void Поднять_на_верх(object sender, EventArgs e)
        {
            if (Необходимо_поднять_форму == true)
            {
                this.TopMost = true;
                this.TopMost = false;
                Необходимо_поднять_форму = false;
            }
        }
        void Сброс_флага_активации(object sender, EventArgs e)
        {
            Необходимо_поднять_форму = true;
        }
        void Прикрепить_к_родителю(object sender, EventArgs e)
        {
            this.Location = new Point(Формы.Instance().Основная_форма.Location.X, Формы.Instance().Основная_форма.Location.Y + Формы.Instance().Основная_форма.Height);
            this.Width = Формы.Instance().Основная_форма.Width;
        }
        void Согласовать_размер(object sender, EventArgs e)
        {
            this.Location = new Point(Формы.Instance().Основная_форма.Location.X, Формы.Instance().Основная_форма.Location.Y + Формы.Instance().Основная_форма.Height);
            this.Width = Формы.Instance().Основная_форма.Width;
        }

        public printer_spool_form()
        {
            InitializeComponent();
        }
        private void printer_spool_form_Load(object sender, EventArgs e)
        {
            
        }

        private void printer_spool_cmnstrp_Opening(object sender, CancelEventArgs e)
        {
            this.del_cmi.Enabled = false;
            this.edit_cmi.Enabled = false;
            this.view_and_print_cmi.Enabled = false;

            if (this.printer_spool_lstvw.SelectedItems.Count > 0)
            {
                this.del_cmi.Enabled = true;
                this.view_and_print_cmi.Enabled = true;
            }
            if (this.printer_spool_lstvw.SelectedItems.Count == 1)
            {
                this.edit_cmi.Enabled = true;
            }
        }
        private void del_cmi_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem Item in this.printer_spool_lstvw.SelectedItems)
            {
                Item.Remove();
            }
            Проверка_очереди_печати();
        }
        private void edit_cmi_Click(object sender, EventArgs e)
        {
            Распоряжение Распоряжение = this.printer_spool_lstvw.SelectedItems[0].Tag as Распоряжение;
            Формы.Instance().Основная_форма.Редактировать_распоряжение(Распоряжение);
            Проверка_очереди_печати();
        }
        private void view_and_print_cmi_Click(object sender, EventArgs e)
        {
            Печать_очереди_с_предпросмотром();
        }

        private void print_doc_BeginPrint(object sender, PrintEventArgs e)
        {
            foreach (ListViewItem Item in this.printer_spool_lstvw.Items)
            {
                Спулл_распоряжений.Add(Item.Tag as Распоряжение);
            }
        }
        private void print_doc_EndPrint(object sender, PrintEventArgs e)
        {
            Спулл_распоряжений.Clear();
        }
        private void print_doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.HasMorePages = false;

            float Нижняя_граница = e.PageSettings.PrintableArea.Bottom;
            float Стартовая_позиция = 20;

            while (Спулл_распоряжений.Count > 0 & e.HasMorePages == false)
            {
                SizeF Размер_ОП_распоряжения = Спулл_распоряжений[0].Размер_печатного_оттиска(e);

                if (Размер_ОП_распоряжения.Height + Стартовая_позиция <= Нижняя_граница)
                {
                    Спулл_распоряжений[0].Печать(e, Стартовая_позиция);
                    Стартовая_позиция = Стартовая_позиция + Размер_ОП_распоряжения.Height + 20;
                    Спулл_распоряжений.RemoveAt(0);
                }
                else
                {
                    e.HasMorePages = true;
                }
            }
        }
    }
}
