using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Генератор_распоряжений
{
    public class WorkersListView : ListView
    {
        private Int32 ScrollbarWidth = SystemInformation.VerticalScrollBarWidth + 6;
        private ColumnHeader W_ch = new ColumnHeader();
        private ColumnHeader I_ch = new ColumnHeader();
        private ColumnHeader G_ch = new ColumnHeader();

        private void Начальная_настройка()
        {
            base.View = View.Details;
            base.HideSelection = false;
            base.FullRowSelect = true;
            base.MultiSelect = false;
            base.AllowColumnReorder = false;
            base.HeaderStyle = ColumnHeaderStyle.None
;

            base.Items.Clear();
            base.Columns.Clear();

            Int32 ColumnWidth = (base.Width - ScrollbarWidth) / 3;

            W_ch.Width = Convert.ToInt32(ColumnWidth * 1.5);
            I_ch.Width = Convert.ToInt32(ColumnWidth * 0.5);
            G_ch.Width = Convert.ToInt32(ColumnWidth * 1);

            base.Columns.Add(W_ch);
            base.Columns.Add(I_ch);
            base.Columns.Add(G_ch);
        }
        public void Добавить_сотрудника(Сотрудник Сотрудник)
        {
            ListViewItem Item = new ListViewItem();
            Item.ImageIndex = 0;
            Item.Text = Сотрудник.Фамилия;
            Item.Tag = Сотрудник;
            Item.UseItemStyleForSubItems = true;

            if (base.Items.Count % 2 != 0)
            {
                Item.BackColor = System.Drawing.Color.Lavender;
            }

            ListViewItem.ListViewSubItem Subitem_1 = new ListViewItem.ListViewSubItem();
            Subitem_1.Text = Сотрудник.Инициалы;
            Subitem_1.Tag = Сотрудник;

            ListViewItem.ListViewSubItem Subitem_2 = new ListViewItem.ListViewSubItem();
            Subitem_2.Text = Сотрудник.Группа_ЭБ;
            Subitem_2.Tag = Сотрудник;

            Item.SubItems.Add(Subitem_1);
            Item.SubItems.Add(Subitem_2);
            base.Items.Add(Item);
        }

        public WorkersListView()
        {
            Начальная_настройка();
        }
        protected override void OnResize(EventArgs e)
        {
            Int32 ColumnWidth = (base.Width - ScrollbarWidth) / 3;

            W_ch.Width = Convert.ToInt32(ColumnWidth * 1.5);
            I_ch.Width = Convert.ToInt32(ColumnWidth * 0.5);
            G_ch.Width = Convert.ToInt32(ColumnWidth * 1);

            base.OnResize(e);
        }
    }
}
