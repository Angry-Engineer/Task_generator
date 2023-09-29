using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Генератор_распоряжений
{
    public class WorkersTreeView : TreeView
    {
        private void Начальная_настройка()
        {
            base.HideSelection = false;
            base.FullRowSelect = true;

            base.Nodes.Clear();
        }
        public void Добавить_группу(Группа Группа)
        {
            TreeNode Node = new TreeNode();
            Node.ImageIndex = 0;
            Node.SelectedImageIndex = 0;
            Node.Text = Группа.Наименование;
            Node.Tag = Группа;

            if (Группа.Лист_сотрудников != null)
            {
                foreach (Сотрудник Сотрудник in Группа.Лист_сотрудников)
                {
                    Добавить_сотрудника(Node, Сотрудник);
                }
            }
            

            base.Nodes.Add(Node);
            Node.Expand();
        }
        public void Добавить_сотрудника(TreeNode Группа, Сотрудник Сотрудник)
        {
            TreeNode Node = new TreeNode();
            Node.ImageIndex = 1;
            Node.SelectedImageIndex = 1;
            Node.Text = Сотрудник.Фамилия + " " + Сотрудник.Инициалы + " " + Сотрудник.Группа_ЭБ + " гр. по э/б";
            Node.Tag = Сотрудник;

            Группа.Nodes.Add(Node);
        }

        public WorkersTreeView()
        {
            Начальная_настройка();
        }

        protected override void OnNodeMouseClick(TreeNodeMouseClickEventArgs e)
        {
            // Если по узлу кликнули правой клавишей
            if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                this.SelectedNode = e.Node;
            }
            // Если по узлу кликнули левой клавишей
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                this.SelectedNode = e.Node;
            }

            base.OnNodeMouseClick(e);
        }
        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Escape)
            {
                this.SelectedNode = null;
            }

            base.OnKeyPress(e);
        }
    }
}
