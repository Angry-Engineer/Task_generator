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
    public partial class workers_form : Form
    {
        private bool Список_сотрудников_изменен = false;
        private bool Необходимо_поднять_форму = false;
        private enum Действие {Добавление, Редактирование};

        private Действие Выполняемое_действие;

        public void Показать()
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;

            this.Location = new Point(Формы.Instance().Основная_форма.Location.X + Формы.Instance().Основная_форма.Width, Формы.Instance().Основная_форма.Location.Y);           
            this.Height = Формы.Instance().Основная_форма.Height;
            this.Width = 250;

            Выстроить_поля_сотрудник();
            Выстроить_кнопки_сотрудник();
            Выстроить_кнопки_группа();

            Формы.Instance().Основная_форма.Activated += new EventHandler(this.Поднять_на_верх);
            Формы.Instance().Основная_форма.Deactivate += new EventHandler(this.Сброс_флага_активации);
            Формы.Instance().Основная_форма.Move += new EventHandler(this.Прикрепить_к_родителю);
            Формы.Instance().Основная_форма.Resize += new EventHandler(this.Согласовать_размер);
        }
        public void Выстроить_поля_сотрудник()
        {
            Int32 Длина_поля = Convert.ToInt32((this.worker_pnl.Width - 8) / 5.5);

            this.worker_tb_gr_txtbx.Width = Длина_поля;
            this.worker_tb_gr_txtbx.Location = new Point(this.worker_pnl.Width - Длина_поля - 3, this.worker_tb_gr_txtbx.Location.Y);
            this.label3.Location = new Point(this.worker_tb_gr_txtbx.Location.X - 2, this.label3.Location.Y);

            this.worker_initials_txtbx.Width = Длина_поля;
            this.worker_initials_txtbx.Location = new Point(this.worker_pnl.Width - 2 * Длина_поля - 5, this.worker_initials_txtbx.Location.Y);
            this.label2.Location = new Point(this.worker_initials_txtbx.Location.X - 2, this.label2.Location.Y);

            this.worker_name_txtbx.Width = Convert.ToInt32(this.worker_pnl.Width -3 - 2 * Длина_поля - 7);
            this.worker_name_txtbx.Location = new Point(3, this.worker_name_txtbx.Location.Y);
        }
        public void Выстроить_кнопки_сотрудник()
        {
            Int32 ButtonWidth = (this.worker_pnl.Width - 6) / 2;

            this.worker_ok_bttn.Location = new Point(2, this.worker_ok_bttn.Location.Y);
            this.worker_cancel_bttn.Location = new Point(this.worker_pnl.Width - 2 - ButtonWidth, this.worker_cancel_bttn.Location.Y);

            this.worker_ok_bttn.Width = ButtonWidth;
            this.worker_cancel_bttn.Width = this.worker_pnl.Width - 6 - ButtonWidth;
        }
        public void Выстроить_кнопки_группа()
        {
            Int32 ButtonWidth = (this.group_pnl.Width - 6) / 2;

            this.group_ok_bttn.Location = new Point(2, this.group_ok_bttn.Location.Y);
            this.group_cancel_bttn.Location = new Point(this.group_pnl.Width - 2 - ButtonWidth, this.group_cancel_bttn.Location.Y);

            this.group_ok_bttn.Width = ButtonWidth;
            this.group_cancel_bttn.Width = this.group_pnl.Width - 6 - ButtonWidth;
        }
        public void Выстроить_кнопки_файл()
        {
            Int32 ButtonWidth = (this.file_pnl.Width - 8) / 3;

            this.open_bttn.Location = new Point(2, this.open_bttn.Location.Y);
            this.open_bttn.Width = ButtonWidth;

            this.save_bttn.Location = new Point(2 + this.open_bttn.Width + 2, this.save_bttn.Location.Y);
            this.save_bttn.Width = this.file_pnl.Width - 8 - 2* ButtonWidth;

            this.add_bttn.Location = new Point(this.file_pnl.Width - 2 - ButtonWidth, this.add_bttn.Location.Y);
            this.add_bttn.Width = ButtonWidth;
        }

        private bool Проверка_на_корректность_заполнения()
        {
            bool no_error = true;
            String Error_msg = "";

            if (this.worker_name_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.worker_name_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - Фамилия";
            }

            if (this.worker_initials_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.worker_initials_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - И.О.";
            }

            if (this.worker_tb_gr_txtbx.Text.Trim() == "")
            {
                no_error = false;
                this.worker_tb_gr_txtbx.BackColor = System.Drawing.Color.Salmon;
                Error_msg = Error_msg + "\n   - гр. по э.б.";
            }

            if (no_error == false)
            {
                MessageBox.Show("Пожалуйста, заполните корректно следующие поля:" + Error_msg, "Генератор распоряжений", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return no_error;
        }
        public void Сохранить_список_сотрудников()
        {
            if (Список_сотрудников_изменен == true)
            {
                string Файл = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                Файл = Файл + "\\Генератор распоряжений\\Персонал\\Персонал.xml";

                Сохранить_список_сотрудников(Файл);
            }
        }
        public void Загрузить_список_сотрудников()
        {
            string Файл = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            Файл = Файл + "\\Генератор распоряжений\\Персонал\\Персонал.xml";

            Загрузить_список_сотрудников(Файл);
        }

        private void Загрузить_список_сотрудников(string Файл)
        {
            if (File.Exists(Файл) == true)
            {
                FileStream file_stream = new FileStream(Файл, FileMode.Open);
                XmlSerializer xs = new XmlSerializer(typeof(List<Группа>));
                XmlReader xr = XmlReader.Create(file_stream);

                if (xs.CanDeserialize(xr) == true)
                {
                    this.workers_trvw.Nodes.Clear();

                    List<Группа> Лист_групп = xs.Deserialize(xr) as List<Группа>;

                    foreach (Группа Группа in Лист_групп)
                    {
                        this.workers_trvw.Добавить_группу(Группа);
                    }

                    Список_сотрудников_изменен = false;
                }
                else
                {
                    MessageBox.Show("Ошибка формата файла персонала", "Генератор распоряжений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                file_stream.Close();
            }
        }
        private void Сохранить_список_сотрудников(string Файл)
        {
            List<Группа> Лист_групп = new List<Группа>();

            foreach (TreeNode _Группа_tn in this.workers_trvw.Nodes)
            {
                Группа _Группа = _Группа_tn.Tag as Группа;
                List<Сотрудник> Лист_сотрудников = new List<Сотрудник>();

                foreach (TreeNode _Сотрудник_tn in _Группа_tn.Nodes)
                {
                    Сотрудник Сотрудник = _Сотрудник_tn.Tag as Сотрудник;
                    Лист_сотрудников.Add(Сотрудник);
                }
                _Группа.Лист_сотрудников = Лист_сотрудников;

                Лист_групп.Add(_Группа);
            }

            FileStream file_stream = new FileStream(Файл, FileMode.Create);
            XmlSerializer xs = new XmlSerializer(typeof(List<Группа>));

            XmlWriterSettings ws = new XmlWriterSettings();
            ws.NewLineHandling = NewLineHandling.Entitize;

            XmlWriter wr = XmlWriter.Create(file_stream, ws);
            xs.Serialize(wr, Лист_групп);

            file_stream.Close();
        }
        private void Добавить_список_сотрудников(string Файл)
        {
            if (File.Exists(Файл) == true)
            {
                FileStream file_stream = new FileStream(Файл, FileMode.Open);
                XmlSerializer xs = new XmlSerializer(typeof(List<Группа>));
                XmlReader xr = XmlReader.Create(file_stream);

                if (xs.CanDeserialize(xr) == true)
                {
                    List<Группа> Лист_групп = xs.Deserialize(xr) as List<Группа>;

                    foreach (Группа Группа in Лист_групп)
                    {
                        this.workers_trvw.Добавить_группу(Группа);
                    }

                    Список_сотрудников_изменен = true;
                }
                else
                {
                    MessageBox.Show("Ошибка формата файла персонала", "Генератор распоряжений", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                file_stream.Close();
            }
        }

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
            this.Location = new Point(Формы.Instance().Основная_форма.Location.X + Формы.Instance().Основная_форма.Width, Формы.Instance().Основная_форма.Location.Y);
            this.Height = Формы.Instance().Основная_форма.Height;
        }
        void Согласовать_размер(object sender, EventArgs e)
        {
            this.Location = new Point(Формы.Instance().Основная_форма.Location.X + Формы.Instance().Основная_форма.Width, Формы.Instance().Основная_форма.Location.Y);
            this.Height = Формы.Instance().Основная_форма.Height;
        }
        
        public workers_form()
        {
            InitializeComponent();
        }
        private void workers_form_Load(object sender, EventArgs e)
        {
            this.MinimumSize = this.Size;
        }
        private void workers_form_Resize(object sender, EventArgs e)
        {
            Выстроить_поля_сотрудник();
            Выстроить_кнопки_сотрудник();
            Выстроить_кнопки_группа();
            Выстроить_кнопки_файл();
        }

        private void sec_name_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = System.Drawing.SystemColors.Window;
        }
        private void in_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = System.Drawing.SystemColors.Window;
        }
        private void group_txtbx_TextChanged(object sender, EventArgs e)
        {
            (sender as TextBox).BackColor = System.Drawing.SystemColors.Window;
        }

        private void workers_cmnstrp_Opening(object sender, CancelEventArgs e)
        {
            this.set_main_worker_cmi.Enabled = false;
            this.set_main_worker_cmi.Visible = false;
            this.set_group_member_cmi.Enabled = false;
            this.set_group_member_cmi.Visible = false;
            this.set_order_source_cmi.Enabled = false;
            this.set_order_source_cmi.Visible = false;

            this.sep_1_cmi.Visible = false;

            this.add_group_cmi.Enabled = false;
            this.add_group_cmi.Visible = false;

            this.add_worker_cmi.Enabled = false;
            this.add_worker_cmi.Visible = false;

            this.edit_cmi.Enabled = false;
            this.del_cmi.Enabled = false;

            if (this.workers_trvw.SelectedNode != null)
            {
                if (this.workers_trvw.SelectedNode.Tag as Группа != null)
                {
                    this.add_worker_cmi.Enabled = true;
                    this.add_worker_cmi.Visible = true;

                    this.edit_cmi.Enabled = true;
                    this.del_cmi.Enabled = true;
                }
                if (this.workers_trvw.SelectedNode.Tag as Сотрудник != null)
                {
                    this.set_main_worker_cmi.Enabled = true;
                    this.set_main_worker_cmi.Visible = true;
                    this.set_group_member_cmi.Enabled = true;
                    this.set_group_member_cmi.Visible = true;
                    this.set_order_source_cmi.Enabled = true;
                    this.set_order_source_cmi.Visible = true;

                    this.sep_1_cmi.Visible = true;

                    this.edit_cmi.Enabled = true;
                    this.del_cmi.Enabled = true;
                }
            }
            else
            {
                this.add_group_cmi.Visible = true;
                this.add_group_cmi.Enabled = true;
            }
        }
        
        private void set_main_worker_cmi_Click(object sender, EventArgs e)
        {
            Сотрудник Сотрудник = this.workers_trvw.SelectedNode.Tag as Сотрудник;
            Формы.Instance().Основная_форма.Добавить_производителя(Сотрудник);
        }
        private void set_group_member_cmi_Click(object sender, EventArgs e)
        {
            Сотрудник Сотрудник = this.workers_trvw.SelectedNode.Tag as Сотрудник;
            Формы.Instance().Основная_форма.Добавить_члена_бригады(Сотрудник);
        }
        private void set_order_source_cmi_Click(object sender, EventArgs e)
        {
            Сотрудник Сотрудник = this.workers_trvw.SelectedNode.Tag as Сотрудник;
            Формы.Instance().Основная_форма.Добавить_отдающего_распоряжение(Сотрудник);
        }

        private void worker_ok_bttn_Click(object sender, EventArgs e)
        {
            if (Проверка_на_корректность_заполнения() == true)
            {
                String Фамилия = this.worker_name_txtbx.Text.Trim();
                String Инициалы = this.worker_initials_txtbx.Text.Trim();
                String Группа_ЭБ = this.worker_tb_gr_txtbx.Text.Trim();

                Сотрудник _Сотрудник = new Сотрудник(Фамилия, Инициалы, Группа_ЭБ);

                switch (Выполняемое_действие)
                {
                    case Действие.Добавление:

                        this.workers_trvw.Добавить_сотрудника(this.workers_trvw.SelectedNode, _Сотрудник);

                        break;
                    case Действие.Редактирование:

                        this.workers_trvw.SelectedNode.ImageIndex = 1;
                        this.workers_trvw.SelectedNode.SelectedImageIndex = 1;
                        this.workers_trvw.SelectedNode.Text = _Сотрудник.Фамилия + " " + _Сотрудник.Инициалы + " " + _Сотрудник.Группа_ЭБ + " гр. по э/б";
                        this.workers_trvw.SelectedNode.Tag = _Сотрудник;
                        
                        break;
                }

                Список_сотрудников_изменен = true;

                this.worker_pnl.Enabled = false;
                this.worker_pnl.Visible = false;

                this.workers_trvw.Enabled = true;

                this.worker_name_txtbx.Text = "";
                this.worker_initials_txtbx.Text = "";
                this.worker_tb_gr_txtbx.Text = "";

                this.AcceptButton = null;
                this.CancelButton = null;
            }
        }
        private void worker_cancel_bttn_Click(object sender, EventArgs e)
        {
            this.worker_pnl.Enabled = false;
            this.worker_pnl.Visible = false;

            this.workers_trvw.Enabled = true;

            this.worker_name_txtbx.Text = "";
            this.worker_initials_txtbx.Text = "";
            this.worker_tb_gr_txtbx.Text = "";

            this.AcceptButton = null;
            this.CancelButton = null;
        }

        private void group_ok_bttn_Click(object sender, EventArgs e)
        {
            String Наименование_группы = this.group_name_txtbx.Text.Trim();

            Группа _Группа = new Группа(Наименование_группы);

            switch (Выполняемое_действие)
            {
                case Действие.Добавление:

                    this.workers_trvw.Добавить_группу(_Группа);

                    break;
                case Действие.Редактирование:

                    this.workers_trvw.SelectedNode.ImageIndex = 0;
                    this.workers_trvw.SelectedNode.SelectedImageIndex = 0;
                    this.workers_trvw.SelectedNode.Text = _Группа.Наименование;
                    this.workers_trvw.SelectedNode.Tag = _Группа;

                    break;
            }

            Список_сотрудников_изменен = true;

            this.group_pnl.Enabled = false;
            this.group_pnl.Visible = false;

            this.workers_trvw.Enabled = true;

            this.group_name_txtbx.Text = "";

            this.AcceptButton = null;
            this.CancelButton = null;
        }
        private void group_cancel_bttn_Click(object sender, EventArgs e)
        {
            this.group_pnl.Enabled = false;
            this.group_pnl.Visible = false;

            this.workers_trvw.Enabled = true;

            this.group_name_txtbx.Text = "";

            this.AcceptButton = null;
            this.CancelButton = null;
        }

        private void del_cmi_Click(object sender, EventArgs e)
        {
            if (this.workers_trvw.SelectedNode.Tag as Группа != null)
            {
                Группа _Группа = this.workers_trvw.SelectedNode.Tag as Группа;

                DialogResult Result = MessageBox.Show("Удалить группу " + _Группа.Наименование + "?", "Генератор распоряжений", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    this.workers_trvw.SelectedNode.Remove();
                    Список_сотрудников_изменен = true;
                }
            }
            if (this.workers_trvw.SelectedNode.Tag as Сотрудник != null)
            {
                Сотрудник _Сотрудник = this.workers_trvw.SelectedNode.Tag as Сотрудник;

                DialogResult Result = MessageBox.Show("Удалить работника " + _Сотрудник.Фамилия + " " + _Сотрудник .Инициалы + "?", "Генератор распоряжений", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Result == DialogResult.Yes)
                {
                    this.workers_trvw.SelectedNode.Remove();
                    Список_сотрудников_изменен = true;
                }
            }
        }
        private void edit_cmi_Click(object sender, EventArgs e)
        {
            Выполняемое_действие = Действие.Редактирование;

            Выстроить_поля_сотрудник();
            Выстроить_кнопки_сотрудник();
            Выстроить_кнопки_группа();

            if (this.workers_trvw.SelectedNode.Tag as Группа != null)
            {
                Группа _Группа = this.workers_trvw.SelectedNode.Tag as Группа;

                this.group_pnl.Visible = true;
                this.group_pnl.Enabled = true;
                this.workers_trvw.Enabled = false;

                this.group_ok_bttn.Text = "Редактировать";
                this.AcceptButton = this.group_ok_bttn;
                this.CancelButton = this.group_cancel_bttn;

                this.group_name_txtbx.Text = _Группа.Наименование;
            }
            if (this.workers_trvw.SelectedNode.Tag as Сотрудник != null)
            {
                Сотрудник _Сотрудник = this.workers_trvw.SelectedNode.Tag as Сотрудник;
                Группа _Группа = this.workers_trvw.SelectedNode.Parent.Tag as Группа;

                this.group_name_pnl.Text = _Группа.Наименование;

                this.worker_pnl.Visible = true;
                this.worker_pnl.Enabled = true;
                this.workers_trvw.Enabled = false;

                this.worker_ok_bttn.Text = "Редактировать";
                this.AcceptButton = this.worker_ok_bttn;
                this.CancelButton = this.worker_cancel_bttn;

                this.worker_name_txtbx.Text = _Сотрудник.Фамилия;
                this.worker_initials_txtbx.Text = _Сотрудник.Инициалы;
                this.worker_tb_gr_txtbx.Text = _Сотрудник.Группа_ЭБ;
            }
        }

        private void add_group_cmi_Click(object sender, EventArgs e)
        {
            Выполняемое_действие = Действие.Добавление;

            Выстроить_поля_сотрудник();
            Выстроить_кнопки_сотрудник();
            Выстроить_кнопки_группа();

            this.group_pnl.Visible = true;
            this.group_pnl.Enabled = true;
            this.workers_trvw.Enabled = false;

            this.group_ok_bttn.Text = "Добавить";
            this.AcceptButton = this.group_ok_bttn;
            this.CancelButton = this.group_cancel_bttn;
        }
        private void add_worker_cmi_Click(object sender, EventArgs e)
        {
            Выполняемое_действие = Действие.Добавление;

            Выстроить_поля_сотрудник();
            Выстроить_кнопки_сотрудник();
            Выстроить_кнопки_группа();

            Группа _Группа = this.workers_trvw.SelectedNode.Tag as Группа;
            this.group_name_pnl.Text = _Группа.Наименование;

            this.worker_pnl.Visible = true;
            this.worker_pnl.Enabled = true;
            this.workers_trvw.Enabled = false;

            this.worker_ok_bttn.Text = "Добавить";
            this.AcceptButton = this.worker_ok_bttn;
            this.CancelButton = this.worker_cancel_bttn;
        }

        private void group_name_txtbx_TextChanged(object sender, EventArgs e)
        {
            if (this.group_name_txtbx.Text.Trim() == "")
            {
                this.group_ok_bttn.Enabled = false;
            }
            else
            {
                this.group_ok_bttn.Enabled = true;
            }
        }

        private void open_bttn_Click(object sender, EventArgs e)
        {
            string user_docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Directory.Exists(user_docs + "\\Генератор распоряжений\\Персонал") == true)
            {
                this.open_file_dlg.InitialDirectory = user_docs + "\\Генератор распоряжений\\Персонал";
            }

            DialogResult Dlg_result = this.open_file_dlg.ShowDialog();

            if (Dlg_result == DialogResult.OK)
            {
                string Файл = this.open_file_dlg.FileName;
                Загрузить_список_сотрудников(Файл);
            }
        }
        private void save_bttn_Click(object sender, EventArgs e)
        {
            string user_docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Directory.Exists(user_docs + "\\Генератор распоряжений\\Персонал") == true)
            {
                this.save_file_dlg.InitialDirectory = user_docs + "\\Генератор распоряжений\\Персонал";
            }

            DialogResult Dlg_result = this.save_file_dlg.ShowDialog();

            if (Dlg_result == DialogResult.OK)
            {
                string Файл = this.save_file_dlg.FileName;
                Сохранить_список_сотрудников(Файл);
            }
        }
        private void add_bttn_Click(object sender, EventArgs e)
        {
            string user_docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            if (Directory.Exists(user_docs + "\\Генератор распоряжений\\Персонал") == true)
            {
                this.open_file_dlg.InitialDirectory = user_docs + "\\Генератор распоряжений\\Персонал";
            }

            DialogResult Dlg_result = this.open_file_dlg.ShowDialog();

            if (Dlg_result == DialogResult.OK)
            {
                string Файл = this.open_file_dlg.FileName;
                Добавить_список_сотрудников(Файл);
            }
        }
    }
}
