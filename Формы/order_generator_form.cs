using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Генератор_распоряжений
{
    public partial class order_generator_form : Form
    {
        private bool Проверка_на_корректность_заполнения()
        {
            bool no_error = true;
            String Error_msg = "";

            if (this.organization_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.organization_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - организация";
            }

            if (this.structure_unit_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.structure_unit_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - структурная единица";
            }

            if (this.main_worker_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.main_worker_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - производитель работ";
            }

            if (this.coordinator_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.coordinator_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - допускающий";
            }

            if (this.work_discr_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.work_discr_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - задание";
            }

            if (this.object_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.object_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - объект";
            }

            if (this.work_place_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.work_place_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - место работы";
            }

            if (this.work_terms_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.work_terms_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - условия производства работ";
            }

            if (this.order_source_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.order_source_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - распоряжение выдал";
            }

            if (no_error == false)
            {
                MessageBox.Show("Пожалуйста, заполните корректно следующие поля:" + Error_msg, "Генератор распоряжений", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return no_error;
        }
        public void Редактировать_распоряжение(Распоряжение Распоряжение)
        {
            DialogResult Result = MessageBox.Show("Все внесенные изменения в текущий документ будут утеряны. Продолжить?", "Генератор распоряжений", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Result == DialogResult.Yes)
            {
                this.organization_txtbx.Text = Распоряжение.Организация;
                this.structure_unit_txtbx.Text = Распоряжение.Структурная_единица;
                this.date_dtp.Value = Распоряжение.Дата;
                this.main_worker_txtbx.Text = Распоряжение.Производитель;
                this.coordinator_txtbx.Text = Распоряжение.Допускающий;
                this.group_txtbx.Text = Распоряжение.Бригада;
                this.work_discr_txtbx.Text = Распоряжение.Задание;
                this.object_txtbx.Text = Распоряжение.Объект;
                this.work_place_txtbx.Text = Распоряжение.Расположение;
                this.work_terms_txtbx.Text = Распоряжение.Условия_работы;
                this.order_source_txtbx.Text = Распоряжение.Распоряжение_выдал;
            }
        }
        private void Выстроить_кнопки()
        {
            Int32 Длина_кнопки = Convert.ToInt32((this.buttons_pnl.Width - 10) / 4);

            this.load_from_file_bttn.Width = Длина_кнопки;
            this.load_from_file_bttn.Location = new Point(2,2);
            this.save_to_file_bttn.Width = Длина_кнопки;
            this.save_to_file_bttn.Location = new Point(2 + Длина_кнопки + 2, 2);
            this.add_to_spool_bttn.Width = Длина_кнопки;
            this.add_to_spool_bttn.Location = new Point(this.buttons_pnl.Width - 2*Длина_кнопки - 4, 2);
            this.print_spool_bttn.Width = Длина_кнопки;
            this.print_spool_bttn.Location = new Point(this.buttons_pnl.Width - Длина_кнопки - 2, 2);
        }
        private void Выстроить_поля()
        {
            Int32 h_межбл = 3;
            Int32 H_общ = (this.work_terms_txtbx.Location.Y - h_межбл) - (this.group_txtbx.Location.Y + this.group_txtbx.Height + h_межбл);
            Int32 H_дост = H_общ - 2 * h_межбл - this.object_txtbx.Height;

            this.work_discr_txtbx.Height =  H_дост / 2;

            this.object_txtbx.Location = new Point(this.object_txtbx.Location.X, this.work_discr_txtbx.Location.Y + this.work_discr_txtbx.Height + h_межбл);
            this.object_lbl.Location = new Point(this.object_lbl.Location.X, this.object_txtbx.Location.Y);

            this.work_place_txtbx.Location = new Point(this.work_place_txtbx.Location.X, this.object_txtbx.Location.Y + this.object_txtbx.Height + h_межбл);
            this.work_place_lbl.Location = new Point(this.work_place_lbl.Location.X, this.work_place_txtbx.Location.Y);
            this.work_place_txtbx.Height = H_дост - this.work_discr_txtbx.Height;
        }

        private String Подготовить_фамилию_производителя(String Фамилия)
        {
            StringBuilder Result = new StringBuilder(Фамилия);

            //Мужская склоняемая фамилия
            if (Result[Result.Length - 1] == 'в' | Result[Result.Length - 1] == 'н')
            {
                Result.Append("у");
            }
            if (Result[Result.Length - 1] == 'й')
            {
                Result.Remove(Result.Length - 1, 2);
                Result.Append("ому");
            }

            //Женская склоняемая фамилия
            if (Result[Result.Length - 1] == 'а' | Result[Result.Length - 1] == 'я')
            {
                Result.Remove(Result.Length - 1, 1);
                Result.Append("ой");
            }
            if (Result[Result.Length - 1] == 'я')
            {
                Result.Remove(Result.Length - 1, 2);
                Result.Append("ой");
            }

            return Result.ToString();
        }
        private String Подготовить_фамилию_члена_бригады(String Фамилия)
        {
            StringBuilder Result = new StringBuilder(Фамилия);

            //Мужская склоняемая фамилия
            if (Result[Result.Length - 1] == 'в' | Result[Result.Length - 1] == 'н')
            {
                Result.Append("у");
            }
            if (Result[Result.Length - 1] == 'й')
            {
                Result.Remove(Result.Length - 1, 2);
                Result.Append("ому");
            }

            //Женская склоняемая фамилия
            if (Result[Result.Length - 1] == 'а' | Result[Result.Length - 1] == 'я')
            {
                Result.Remove(Result.Length - 1, 1);
                Result.Append("ой");
            }
            if (Result[Result.Length - 1] == 'я')
            {
                Result.Remove(Result.Length - 1, 2);
                Result.Append("ой");
            }

            return Result.ToString();
        }
        public void Добавить_отдающего_распоряжение(Сотрудник Производитель)
        {
            StringBuilder s_bldr = new StringBuilder();

            s_bldr.Append(Производитель.Фамилия);

            s_bldr.Append(' ');
            s_bldr.Append(Производитель.Инициалы);
            s_bldr.Append(' ');
            s_bldr.Append(Производитель.Группа_ЭБ);
            s_bldr.Append(" гр. по э/б");

            this.order_source_txtbx.Text = s_bldr.ToString();
        }
        public void Добавить_производителя(Сотрудник Производитель)
        {
            StringBuilder s_bldr = new StringBuilder();

            s_bldr.Append(Подготовить_фамилию_производителя(Производитель.Фамилия));

            s_bldr.Append(' ');
            s_bldr.Append(Производитель.Инициалы);
            s_bldr.Append(' ');
            s_bldr.Append(Производитель.Группа_ЭБ);
            s_bldr.Append(" гр. по э/б");

            this.main_worker_txtbx.Text = s_bldr.ToString();
        }
        public void Добавить_члена_бригады(Сотрудник Производитель)
        {
            StringBuilder s_bldr = new StringBuilder();

            s_bldr.Append(Подготовить_фамилию_члена_бригады(Производитель.Фамилия));

            s_bldr.Append(' ');
            s_bldr.Append(Производитель.Инициалы);
            s_bldr.Append(' ');
            s_bldr.Append(Производитель.Группа_ЭБ);
            s_bldr.Append(" гр. по э/б");

            if (this.group_txtbx.Text.Trim() != "")
            {
                this.group_txtbx.Text = this.group_txtbx.Text + Environment.NewLine;
            }

            this.group_txtbx.Text = this.group_txtbx.Text + s_bldr.ToString();
        }

        public void Печать_доступна()
        {
            this.print_spool_bttn.Enabled = true;
        }
        public void Печать_блокирована()
        {
            this.print_spool_bttn.Enabled = false;
        }

        public order_generator_form()
        {
            InitializeComponent();
        }
        private void order_generator_form_Load(object sender, EventArgs e)
        {
            this.Location = new Point(this.Location.X, this.Location.Y - 100);
            this.MinimumSize = this.Size;
            Выстроить_кнопки();

            Формы.Instance().Очередь_печати.Показать();
            Формы.Instance().Персонал.Показать();

            string user_docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Directory.Exists(user_docs + "\\Генератор распоряжений") == false)
            {
                Directory.CreateDirectory(user_docs + "\\Генератор распоряжений");
            }
            if (Directory.Exists(user_docs + "\\Генератор распоряжений\\Персонал") == false)
            {
                Directory.CreateDirectory(user_docs + "\\Генератор распоряжений\\Персонал");
            }
            if (Directory.Exists(user_docs + "\\Генератор распоряжений\\Распоряжения") == false)
            {
                Directory.CreateDirectory(user_docs + "\\Генератор распоряжений\\Распоряжения");
            }

            Формы.Instance().Персонал.Загрузить_список_сотрудников();
        }
        private void order_generator_form_Resize(object sender, EventArgs e)
        {
            Выстроить_кнопки();
            Выстроить_поля();
        }

        private void load_from_file_bttn_Click(object sender, EventArgs e)
        {
            string user_docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Directory.Exists(user_docs + "\\Генератор распоряжений\\Распоряжения") == true)
            {
                this.open_file_dlg.InitialDirectory = user_docs + "\\Генератор распоряжений\\Распоряжения";
            }
            
            DialogResult Dlg_result = this.open_file_dlg.ShowDialog();

            if (Dlg_result == DialogResult.OK)
            {
                string file_name = this.open_file_dlg.FileName;
                FileStream file_stream = new FileStream(file_name, FileMode.Open);
                XmlSerializer xs = new XmlSerializer(typeof(Распоряжение_шаблон));

                XmlReader xr = XmlReader.Create(file_stream);
                

                if (xs.CanDeserialize(xr) == true)
                {
                    Распоряжение_шаблон _Распоряжение_шаблон = xs.Deserialize(xr) as Распоряжение_шаблон;

                    DialogResult Result = MessageBox.Show("Все внесенные изменения в текущий документ будут утеряны. Продолжить?", "Генератор распоряжений", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (Result == DialogResult.Yes)
                    {
                        this.date_dtp.Value = DateTime.Today;
                        this.organization_txtbx.Text = _Распоряжение_шаблон.Организация;
                        this.structure_unit_txtbx.Text = _Распоряжение_шаблон.Структурная_единица;
                        this.main_worker_txtbx.Text = _Распоряжение_шаблон.Производитель;
                        this.coordinator_txtbx.Text = _Распоряжение_шаблон.Допускающий;
                        this.group_txtbx.Text = _Распоряжение_шаблон.Бригада;
                        this.work_discr_txtbx.Text = _Распоряжение_шаблон.Задание;
                        this.object_txtbx.Text = _Распоряжение_шаблон.Объект;
                        this.work_place_txtbx.Text = _Распоряжение_шаблон.Расположение;
                        this.work_terms_txtbx.Text = _Распоряжение_шаблон.Условия_работы;
                        this.order_source_txtbx.Text = _Распоряжение_шаблон.Распоряжение_выдал;
                    }

                    file_stream.Close();
                }
                else
                {
                    file_stream.Close();

                    MessageBox.Show("Ошибка формата файла", "Генератор распоряжений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void save_to_file_bttn_Click(object sender, EventArgs e)
        {
            string user_docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Directory.Exists(user_docs + "\\Генератор распоряжений\\Распоряжения") == true)
            {
                this.save_file_dlg.InitialDirectory = user_docs + "\\Генератор распоряжений\\Распоряжения";
            }

            DialogResult Dlg_result = this.save_file_dlg.ShowDialog();

            if (Dlg_result == DialogResult.OK)
            {
                DateTime Дата = this.date_dtp.Value;
                String Организация = this.organization_txtbx.Text.Trim();
                String Структурная_единица = this.structure_unit_txtbx.Text.Trim();
                String Производитель = this.main_worker_txtbx.Text.Trim();
                String Допускающий = this.coordinator_txtbx.Text.Trim();
                String Бригада = this.group_txtbx.Text.Trim();
                String Задание = this.work_discr_txtbx.Text.Trim();
                String Объект = this.object_txtbx.Text.Trim();
                String Расположение = this.work_place_txtbx.Text.Trim();
                String Условия = this.work_terms_txtbx.Text.Trim();
                String Выдал = this.order_source_txtbx.Text.Trim();

                Распоряжение_шаблон _Распоряжение_шаблон = new Распоряжение_шаблон(Организация, Структурная_единица, Производитель, Допускающий, Бригада, Задание, Объект, Расположение, Условия, Выдал);

                string file_name = this.save_file_dlg.FileName;
                FileStream file_stream = new FileStream(file_name, FileMode.Create);
                XmlSerializer xs = new XmlSerializer(typeof(Распоряжение_шаблон));

                XmlWriterSettings ws = new XmlWriterSettings();
                ws.NewLineHandling = NewLineHandling.Entitize;

                XmlWriter wr = XmlWriter.Create(file_stream, ws);
                xs.Serialize(wr, _Распоряжение_шаблон);
                
                file_stream.Close();
            }
        }
        private void add_to_spool_bttn_Click(object sender, EventArgs e)
        {
            if (Проверка_на_корректность_заполнения() == true)
            {
                DateTime Дата = this.date_dtp.Value;
                String Организация = this.organization_txtbx.Text.Trim();
                String Структурная_единица = this.structure_unit_txtbx.Text.Trim();
                String Производитель = this.main_worker_txtbx.Text.Trim();
                String Допускающий = this.coordinator_txtbx.Text.Trim();
                String Бригада = this.group_txtbx.Text.Trim();
                String Задание = this.work_discr_txtbx.Text.Trim();
                String Объект = this.object_txtbx.Text.Trim();
                String Расположение = this.work_place_txtbx.Text.Trim();
                String Условия = this.work_terms_txtbx.Text.Trim();
                String Выдал = this.order_source_txtbx.Text.Trim();

                Распоряжение _Распоряжение = new Распоряжение(Дата, Организация, Структурная_единица, Производитель, Допускающий, Бригада, Задание, Объект, Расположение, Условия, Выдал);
                Формы.Instance().Очередь_печати.Добавить_распоряжение(_Распоряжение);
            }
        }
        private void print_spool_bttn_Click(object sender, EventArgs e)
        {
            Формы.Instance().Очередь_печати.Печать_очереди();
        }

        private void main_worker_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as RichTextBox).BackColor = System.Drawing.SystemColors.Window;
        }
        private void group_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as RichTextBox).BackColor = System.Drawing.SystemColors.Window;
        }
        private void coordinator_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as RichTextBox).BackColor = System.Drawing.SystemColors.Window;
        }
        private void work_discr_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as RichTextBox).BackColor = System.Drawing.SystemColors.Window;
        }
        private void object_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as RichTextBox).BackColor = System.Drawing.SystemColors.Window;
        }
        private void work_place_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as RichTextBox).BackColor = System.Drawing.SystemColors.Window;
        }
        private void work_terms_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as RichTextBox).BackColor = System.Drawing.SystemColors.Window;
        }
        private void order_source_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as RichTextBox).BackColor = System.Drawing.SystemColors.Window;
        }
    }
}
