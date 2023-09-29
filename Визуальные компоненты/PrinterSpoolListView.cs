using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Генератор_распоряжений
{
    public class PrinterSpoolListView : ListView
    {
        private Int32 ScrollbarWidth = SystemInformation.VerticalScrollBarWidth + 6;
        private ColumnHeader MW_ch = new ColumnHeader();
        private ColumnHeader Object_ch = new ColumnHeader();
        private ColumnHeader Work_desc_ch = new ColumnHeader();

        private void Начальная_настройка()
        {
            base.View = View.Details;
            base.HideSelection = false;
            base.FullRowSelect = true;
            base.AllowColumnReorder = false;
            base.HeaderStyle = ColumnHeaderStyle.None
;

            base.Items.Clear();
            base.Columns.Clear();

            Int32 ColumnWidth = (base.Width - ScrollbarWidth) / 3;

            MW_ch.Width = Convert.ToInt32(ColumnWidth * 1);
            Object_ch.Width = Convert.ToInt32(ColumnWidth * 0.7);
            Work_desc_ch.Width = Convert.ToInt32(ColumnWidth * 1.3);

            base.Columns.Add(MW_ch);
            base.Columns.Add(Object_ch);
            base.Columns.Add(Work_desc_ch);
        }
        public void Добавить_распоряжение(Распоряжение Распоряжение)
        {
            ListViewItem Item = new ListViewItem();
            Item.ImageIndex = 0;
            Item.Text = Распоряжение.Производитель;
            Item.Tag = Распоряжение;
            Item.UseItemStyleForSubItems = true;

            if (base.Items.Count % 2 != 0)
            {
                Item.BackColor = System.Drawing.Color.Lavender;
            }

            ListViewItem.ListViewSubItem Subitem_1 = new ListViewItem.ListViewSubItem();
            Subitem_1.Text = Распоряжение.Объект;
            Subitem_1.Tag = Распоряжение;

            ListViewItem.ListViewSubItem Subitem_2 = new ListViewItem.ListViewSubItem();
            Subitem_2.Text = Распоряжение.Задание;
            Subitem_2.Tag = Распоряжение;

            Item.SubItems.Add(Subitem_1);
            Item.SubItems.Add(Subitem_2);
            base.Items.Add(Item);
        }

        public PrinterSpoolListView()
        {
            Начальная_настройка();
        }
        protected override void OnResize(EventArgs e)
        {
            Int32 ColumnWidth = (base.Width - ScrollbarWidth) / 3;

            MW_ch.Width = Convert.ToInt32(ColumnWidth * 1);
            Object_ch.Width = Convert.ToInt32(ColumnWidth * 0.7);
            Work_desc_ch.Width = Convert.ToInt32(ColumnWidth * 1.3);

            base.OnResize(e);
        }
    }
}
