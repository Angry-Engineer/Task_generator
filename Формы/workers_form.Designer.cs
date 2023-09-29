namespace Генератор_распоряжений
{
    partial class workers_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(workers_form));
            this.worker_pnl = new System.Windows.Forms.Panel();
            this.group_name_pnl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.worker_cancel_bttn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.worker_ok_bttn = new System.Windows.Forms.Button();
            this.worker_tb_gr_txtbx = new System.Windows.Forms.TextBox();
            this.worker_initials_txtbx = new System.Windows.Forms.TextBox();
            this.worker_name_txtbx = new System.Windows.Forms.TextBox();
            this.workers_cmnstrp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.set_order_source_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.set_main_worker_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.set_group_member_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.sep_1_cmi = new System.Windows.Forms.ToolStripSeparator();
            this.add_worker_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.add_group_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.edit_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.del_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.workers_imglst = new System.Windows.Forms.ImageList(this.components);
            this.group_pnl = new System.Windows.Forms.Panel();
            this.group_cancel_bttn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.group_ok_bttn = new System.Windows.Forms.Button();
            this.group_name_txtbx = new System.Windows.Forms.TextBox();
            this.workers_trvw = new Генератор_распоряжений.WorkersTreeView();
            this.file_pnl = new System.Windows.Forms.Panel();
            this.save_bttn = new System.Windows.Forms.Button();
            this.open_bttn = new System.Windows.Forms.Button();
            this.add_bttn = new System.Windows.Forms.Button();
            this.open_file_dlg = new System.Windows.Forms.OpenFileDialog();
            this.save_file_dlg = new System.Windows.Forms.SaveFileDialog();
            this.worker_pnl.SuspendLayout();
            this.workers_cmnstrp.SuspendLayout();
            this.group_pnl.SuspendLayout();
            this.file_pnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // worker_pnl
            // 
            this.worker_pnl.Controls.Add(this.group_name_pnl);
            this.worker_pnl.Controls.Add(this.label4);
            this.worker_pnl.Controls.Add(this.worker_cancel_bttn);
            this.worker_pnl.Controls.Add(this.label3);
            this.worker_pnl.Controls.Add(this.label2);
            this.worker_pnl.Controls.Add(this.label1);
            this.worker_pnl.Controls.Add(this.worker_ok_bttn);
            this.worker_pnl.Controls.Add(this.worker_tb_gr_txtbx);
            this.worker_pnl.Controls.Add(this.worker_initials_txtbx);
            this.worker_pnl.Controls.Add(this.worker_name_txtbx);
            this.worker_pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.worker_pnl.Location = new System.Drawing.Point(0, 347);
            this.worker_pnl.Name = "worker_pnl";
            this.worker_pnl.Size = new System.Drawing.Size(294, 87);
            this.worker_pnl.TabIndex = 0;
            this.worker_pnl.Visible = false;
            // 
            // group_name_pnl
            // 
            this.group_name_pnl.AutoSize = true;
            this.group_name_pnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.group_name_pnl.Location = new System.Drawing.Point(51, 3);
            this.group_name_pnl.Name = "group_name_pnl";
            this.group_name_pnl.Size = new System.Drawing.Size(95, 13);
            this.group_name_pnl.TabIndex = 9;
            this.group_name_pnl.Text = "Наименование";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Группа: ";
            // 
            // worker_cancel_bttn
            // 
            this.worker_cancel_bttn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.worker_cancel_bttn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.worker_cancel_bttn.Location = new System.Drawing.Point(152, 62);
            this.worker_cancel_bttn.Name = "worker_cancel_bttn";
            this.worker_cancel_bttn.Size = new System.Drawing.Size(140, 23);
            this.worker_cancel_bttn.TabIndex = 7;
            this.worker_cancel_bttn.Text = "Отмена";
            this.worker_cancel_bttn.UseVisualStyleBackColor = true;
            this.worker_cancel_bttn.Click += new System.EventHandler(this.worker_cancel_bttn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(233, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "гр. по э/б";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(176, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "И.О.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Фамилия";
            // 
            // worker_ok_bttn
            // 
            this.worker_ok_bttn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.worker_ok_bttn.Image = ((System.Drawing.Image)(resources.GetObject("worker_ok_bttn.Image")));
            this.worker_ok_bttn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.worker_ok_bttn.Location = new System.Drawing.Point(2, 62);
            this.worker_ok_bttn.Name = "worker_ok_bttn";
            this.worker_ok_bttn.Size = new System.Drawing.Size(150, 23);
            this.worker_ok_bttn.TabIndex = 3;
            this.worker_ok_bttn.Text = "Добавить";
            this.worker_ok_bttn.UseVisualStyleBackColor = true;
            this.worker_ok_bttn.Click += new System.EventHandler(this.worker_ok_bttn_Click);
            // 
            // worker_tb_gr_txtbx
            // 
            this.worker_tb_gr_txtbx.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.worker_tb_gr_txtbx.Location = new System.Drawing.Point(236, 40);
            this.worker_tb_gr_txtbx.MaxLength = 3;
            this.worker_tb_gr_txtbx.Name = "worker_tb_gr_txtbx";
            this.worker_tb_gr_txtbx.Size = new System.Drawing.Size(55, 20);
            this.worker_tb_gr_txtbx.TabIndex = 2;
            this.worker_tb_gr_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.worker_tb_gr_txtbx.TextChanged += new System.EventHandler(this.group_txtbx_TextChanged);
            // 
            // worker_initials_txtbx
            // 
            this.worker_initials_txtbx.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.worker_initials_txtbx.Location = new System.Drawing.Point(179, 40);
            this.worker_initials_txtbx.MaxLength = 4;
            this.worker_initials_txtbx.Name = "worker_initials_txtbx";
            this.worker_initials_txtbx.Size = new System.Drawing.Size(55, 20);
            this.worker_initials_txtbx.TabIndex = 1;
            this.worker_initials_txtbx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.worker_initials_txtbx.TextChanged += new System.EventHandler(this.in_txtbx_TextChanged);
            // 
            // worker_name_txtbx
            // 
            this.worker_name_txtbx.Location = new System.Drawing.Point(3, 40);
            this.worker_name_txtbx.MaxLength = 16;
            this.worker_name_txtbx.Name = "worker_name_txtbx";
            this.worker_name_txtbx.Size = new System.Drawing.Size(174, 20);
            this.worker_name_txtbx.TabIndex = 0;
            this.worker_name_txtbx.TextChanged += new System.EventHandler(this.sec_name_txtbx_TextChanged);
            // 
            // workers_cmnstrp
            // 
            this.workers_cmnstrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.set_order_source_cmi,
            this.set_main_worker_cmi,
            this.set_group_member_cmi,
            this.sep_1_cmi,
            this.add_worker_cmi,
            this.add_group_cmi,
            this.edit_cmi,
            this.del_cmi});
            this.workers_cmnstrp.Name = "printer_spool_cmnstrp";
            this.workers_cmnstrp.Size = new System.Drawing.Size(281, 164);
            this.workers_cmnstrp.Opening += new System.ComponentModel.CancelEventHandler(this.workers_cmnstrp_Opening);
            // 
            // set_order_source_cmi
            // 
            this.set_order_source_cmi.Enabled = false;
            this.set_order_source_cmi.Name = "set_order_source_cmi";
            this.set_order_source_cmi.Size = new System.Drawing.Size(280, 22);
            this.set_order_source_cmi.Text = "Назначить отдающим распоряжение";
            this.set_order_source_cmi.Visible = false;
            this.set_order_source_cmi.Click += new System.EventHandler(this.set_order_source_cmi_Click);
            // 
            // set_main_worker_cmi
            // 
            this.set_main_worker_cmi.Enabled = false;
            this.set_main_worker_cmi.Name = "set_main_worker_cmi";
            this.set_main_worker_cmi.Size = new System.Drawing.Size(280, 22);
            this.set_main_worker_cmi.Text = "Назначить производителем";
            this.set_main_worker_cmi.Visible = false;
            this.set_main_worker_cmi.Click += new System.EventHandler(this.set_main_worker_cmi_Click);
            // 
            // set_group_member_cmi
            // 
            this.set_group_member_cmi.Enabled = false;
            this.set_group_member_cmi.Name = "set_group_member_cmi";
            this.set_group_member_cmi.Size = new System.Drawing.Size(280, 22);
            this.set_group_member_cmi.Text = "Назначить членом бригады";
            this.set_group_member_cmi.Visible = false;
            this.set_group_member_cmi.Click += new System.EventHandler(this.set_group_member_cmi_Click);
            // 
            // sep_1_cmi
            // 
            this.sep_1_cmi.Name = "sep_1_cmi";
            this.sep_1_cmi.Size = new System.Drawing.Size(277, 6);
            this.sep_1_cmi.Visible = false;
            // 
            // add_worker_cmi
            // 
            this.add_worker_cmi.Enabled = false;
            this.add_worker_cmi.Image = ((System.Drawing.Image)(resources.GetObject("add_worker_cmi.Image")));
            this.add_worker_cmi.Name = "add_worker_cmi";
            this.add_worker_cmi.Size = new System.Drawing.Size(280, 22);
            this.add_worker_cmi.Text = "Добавить сотрудника";
            this.add_worker_cmi.Visible = false;
            this.add_worker_cmi.Click += new System.EventHandler(this.add_worker_cmi_Click);
            // 
            // add_group_cmi
            // 
            this.add_group_cmi.Enabled = false;
            this.add_group_cmi.Image = ((System.Drawing.Image)(resources.GetObject("add_group_cmi.Image")));
            this.add_group_cmi.Name = "add_group_cmi";
            this.add_group_cmi.Size = new System.Drawing.Size(280, 22);
            this.add_group_cmi.Text = "Добавить группу";
            this.add_group_cmi.Visible = false;
            this.add_group_cmi.Click += new System.EventHandler(this.add_group_cmi_Click);
            // 
            // edit_cmi
            // 
            this.edit_cmi.Enabled = false;
            this.edit_cmi.Image = ((System.Drawing.Image)(resources.GetObject("edit_cmi.Image")));
            this.edit_cmi.Name = "edit_cmi";
            this.edit_cmi.Size = new System.Drawing.Size(280, 22);
            this.edit_cmi.Text = "Редактировать";
            this.edit_cmi.Click += new System.EventHandler(this.edit_cmi_Click);
            // 
            // del_cmi
            // 
            this.del_cmi.Enabled = false;
            this.del_cmi.Image = ((System.Drawing.Image)(resources.GetObject("del_cmi.Image")));
            this.del_cmi.Name = "del_cmi";
            this.del_cmi.Size = new System.Drawing.Size(280, 22);
            this.del_cmi.Text = "Удалить";
            this.del_cmi.Click += new System.EventHandler(this.del_cmi_Click);
            // 
            // workers_imglst
            // 
            this.workers_imglst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("workers_imglst.ImageStream")));
            this.workers_imglst.TransparentColor = System.Drawing.Color.Transparent;
            this.workers_imglst.Images.SetKeyName(0, "group.png");
            this.workers_imglst.Images.SetKeyName(1, "worker.png");
            // 
            // group_pnl
            // 
            this.group_pnl.Controls.Add(this.group_cancel_bttn);
            this.group_pnl.Controls.Add(this.label6);
            this.group_pnl.Controls.Add(this.group_ok_bttn);
            this.group_pnl.Controls.Add(this.group_name_txtbx);
            this.group_pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.group_pnl.Enabled = false;
            this.group_pnl.Location = new System.Drawing.Point(0, 281);
            this.group_pnl.Name = "group_pnl";
            this.group_pnl.Size = new System.Drawing.Size(294, 66);
            this.group_pnl.TabIndex = 2;
            this.group_pnl.Visible = false;
            // 
            // group_cancel_bttn
            // 
            this.group_cancel_bttn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.group_cancel_bttn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.group_cancel_bttn.Location = new System.Drawing.Point(152, 41);
            this.group_cancel_bttn.Name = "group_cancel_bttn";
            this.group_cancel_bttn.Size = new System.Drawing.Size(140, 23);
            this.group_cancel_bttn.TabIndex = 5;
            this.group_cancel_bttn.Text = "Отмена";
            this.group_cancel_bttn.UseVisualStyleBackColor = true;
            this.group_cancel_bttn.Click += new System.EventHandler(this.group_cancel_bttn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Наименование группы";
            // 
            // group_ok_bttn
            // 
            this.group_ok_bttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.group_ok_bttn.Enabled = false;
            this.group_ok_bttn.Image = ((System.Drawing.Image)(resources.GetObject("group_ok_bttn.Image")));
            this.group_ok_bttn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.group_ok_bttn.Location = new System.Drawing.Point(2, 41);
            this.group_ok_bttn.Name = "group_ok_bttn";
            this.group_ok_bttn.Size = new System.Drawing.Size(150, 23);
            this.group_ok_bttn.TabIndex = 3;
            this.group_ok_bttn.Text = "Добавить";
            this.group_ok_bttn.UseVisualStyleBackColor = true;
            this.group_ok_bttn.Click += new System.EventHandler(this.group_ok_bttn_Click);
            // 
            // group_name_txtbx
            // 
            this.group_name_txtbx.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.group_name_txtbx.Location = new System.Drawing.Point(3, 19);
            this.group_name_txtbx.MaxLength = 50;
            this.group_name_txtbx.Name = "group_name_txtbx";
            this.group_name_txtbx.Size = new System.Drawing.Size(288, 20);
            this.group_name_txtbx.TabIndex = 0;
            this.group_name_txtbx.TextChanged += new System.EventHandler(this.group_name_txtbx_TextChanged);
            // 
            // workers_trvw
            // 
            this.workers_trvw.ContextMenuStrip = this.workers_cmnstrp;
            this.workers_trvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workers_trvw.FullRowSelect = true;
            this.workers_trvw.HideSelection = false;
            this.workers_trvw.ImageIndex = 0;
            this.workers_trvw.ImageList = this.workers_imglst;
            this.workers_trvw.Indent = 25;
            this.workers_trvw.ItemHeight = 25;
            this.workers_trvw.Location = new System.Drawing.Point(0, 0);
            this.workers_trvw.Name = "workers_trvw";
            this.workers_trvw.SelectedImageIndex = 0;
            this.workers_trvw.Size = new System.Drawing.Size(294, 281);
            this.workers_trvw.TabIndex = 3;
            // 
            // file_pnl
            // 
            this.file_pnl.Controls.Add(this.add_bttn);
            this.file_pnl.Controls.Add(this.save_bttn);
            this.file_pnl.Controls.Add(this.open_bttn);
            this.file_pnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.file_pnl.Location = new System.Drawing.Point(0, 434);
            this.file_pnl.Name = "file_pnl";
            this.file_pnl.Size = new System.Drawing.Size(294, 27);
            this.file_pnl.TabIndex = 4;
            // 
            // save_bttn
            // 
            this.save_bttn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.save_bttn.Image = ((System.Drawing.Image)(resources.GetObject("save_bttn.Image")));
            this.save_bttn.Location = new System.Drawing.Point(98, 2);
            this.save_bttn.Name = "save_bttn";
            this.save_bttn.Size = new System.Drawing.Size(98, 23);
            this.save_bttn.TabIndex = 5;
            this.save_bttn.UseVisualStyleBackColor = true;
            this.save_bttn.Click += new System.EventHandler(this.save_bttn_Click);
            // 
            // open_bttn
            // 
            this.open_bttn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.open_bttn.Image = ((System.Drawing.Image)(resources.GetObject("open_bttn.Image")));
            this.open_bttn.Location = new System.Drawing.Point(2, 2);
            this.open_bttn.Name = "open_bttn";
            this.open_bttn.Size = new System.Drawing.Size(96, 23);
            this.open_bttn.TabIndex = 3;
            this.open_bttn.UseVisualStyleBackColor = true;
            this.open_bttn.Click += new System.EventHandler(this.open_bttn_Click);
            // 
            // add_bttn
            // 
            this.add_bttn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.add_bttn.Image = ((System.Drawing.Image)(resources.GetObject("add_bttn.Image")));
            this.add_bttn.Location = new System.Drawing.Point(196, 2);
            this.add_bttn.Name = "add_bttn";
            this.add_bttn.Size = new System.Drawing.Size(96, 23);
            this.add_bttn.TabIndex = 6;
            this.add_bttn.UseVisualStyleBackColor = true;
            this.add_bttn.Click += new System.EventHandler(this.add_bttn_Click);
            // 
            // open_file_dlg
            // 
            this.open_file_dlg.DefaultExt = "xml";
            this.open_file_dlg.Filter = "Файлы персонала|*.xml";
            this.open_file_dlg.ShowReadOnly = true;
            // 
            // save_file_dlg
            // 
            this.save_file_dlg.DefaultExt = "xml";
            this.save_file_dlg.Filter = "Файлы персонала|*.xml";
            // 
            // workers_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 461);
            this.ControlBox = false;
            this.Controls.Add(this.workers_trvw);
            this.Controls.Add(this.group_pnl);
            this.Controls.Add(this.worker_pnl);
            this.Controls.Add(this.file_pnl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "workers_form";
            this.ShowInTaskbar = false;
            this.Text = "Персонал";
            this.Load += new System.EventHandler(this.workers_form_Load);
            this.Resize += new System.EventHandler(this.workers_form_Resize);
            this.worker_pnl.ResumeLayout(false);
            this.worker_pnl.PerformLayout();
            this.workers_cmnstrp.ResumeLayout(false);
            this.group_pnl.ResumeLayout(false);
            this.group_pnl.PerformLayout();
            this.file_pnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel worker_pnl;
        private System.Windows.Forms.TextBox worker_tb_gr_txtbx;
        private System.Windows.Forms.TextBox worker_initials_txtbx;
        private System.Windows.Forms.TextBox worker_name_txtbx;
        private System.Windows.Forms.Button worker_ok_bttn;
        private System.Windows.Forms.ImageList workers_imglst;
        private System.Windows.Forms.ContextMenuStrip workers_cmnstrp;
        private System.Windows.Forms.ToolStripMenuItem del_cmi;
        private System.Windows.Forms.ToolStripMenuItem add_group_cmi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem set_main_worker_cmi;
        private System.Windows.Forms.ToolStripMenuItem set_group_member_cmi;
        private System.Windows.Forms.ToolStripSeparator sep_1_cmi;
        private System.Windows.Forms.ToolStripMenuItem set_order_source_cmi;
        private System.Windows.Forms.Panel group_pnl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button group_ok_bttn;
        private System.Windows.Forms.TextBox group_name_txtbx;
        private WorkersTreeView workers_trvw;
        private System.Windows.Forms.ToolStripMenuItem add_worker_cmi;
        private System.Windows.Forms.ToolStripMenuItem edit_cmi;
        private System.Windows.Forms.Button group_cancel_bttn;
        private System.Windows.Forms.Button worker_cancel_bttn;
        private System.Windows.Forms.Label group_name_pnl;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel file_pnl;
        private System.Windows.Forms.Button save_bttn;
        private System.Windows.Forms.Button open_bttn;
        private System.Windows.Forms.Button add_bttn;
        private System.Windows.Forms.OpenFileDialog open_file_dlg;
        private System.Windows.Forms.SaveFileDialog save_file_dlg;
    }
}