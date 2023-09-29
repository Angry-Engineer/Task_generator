namespace Генератор_распоряжений
{
    partial class printer_spool_form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(printer_spool_form));
            this.printer_spool_cmnstrp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.edit_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.del_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.view_and_print_cmi = new System.Windows.Forms.ToolStripMenuItem();
            this.printer_spool_imglst = new System.Windows.Forms.ImageList(this.components);
            this.print_dlg = new System.Windows.Forms.PrintDialog();
            this.print_doc = new System.Drawing.Printing.PrintDocument();
            this.print_prvw_dlg = new System.Windows.Forms.PrintPreviewDialog();
            this.printer_spool_lstvw = new Генератор_распоряжений.PrinterSpoolListView();
            this.printer_spool_cmnstrp.SuspendLayout();
            this.SuspendLayout();
            // 
            // printer_spool_cmnstrp
            // 
            this.printer_spool_cmnstrp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edit_cmi,
            this.del_cmi,
            this.toolStripSeparator1,
            this.view_and_print_cmi});
            this.printer_spool_cmnstrp.Name = "printer_spool_cmnstrp";
            this.printer_spool_cmnstrp.Size = new System.Drawing.Size(158, 76);
            this.printer_spool_cmnstrp.Opening += new System.ComponentModel.CancelEventHandler(this.printer_spool_cmnstrp_Opening);
            // 
            // edit_cmi
            // 
            this.edit_cmi.Enabled = false;
            this.edit_cmi.Image = ((System.Drawing.Image)(resources.GetObject("edit_cmi.Image")));
            this.edit_cmi.Name = "edit_cmi";
            this.edit_cmi.Size = new System.Drawing.Size(157, 22);
            this.edit_cmi.Text = "Редактировать";
            this.edit_cmi.Click += new System.EventHandler(this.edit_cmi_Click);
            // 
            // del_cmi
            // 
            this.del_cmi.Enabled = false;
            this.del_cmi.Image = ((System.Drawing.Image)(resources.GetObject("del_cmi.Image")));
            this.del_cmi.Name = "del_cmi";
            this.del_cmi.Size = new System.Drawing.Size(157, 22);
            this.del_cmi.Text = "Удалить";
            this.del_cmi.Click += new System.EventHandler(this.del_cmi_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(154, 6);
            // 
            // view_and_print_cmi
            // 
            this.view_and_print_cmi.Image = ((System.Drawing.Image)(resources.GetObject("view_and_print_cmi.Image")));
            this.view_and_print_cmi.Name = "view_and_print_cmi";
            this.view_and_print_cmi.Size = new System.Drawing.Size(157, 22);
            this.view_and_print_cmi.Text = "Предпросмотр";
            this.view_and_print_cmi.Click += new System.EventHandler(this.view_and_print_cmi_Click);
            // 
            // printer_spool_imglst
            // 
            this.printer_spool_imglst.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("printer_spool_imglst.ImageStream")));
            this.printer_spool_imglst.TransparentColor = System.Drawing.Color.Transparent;
            this.printer_spool_imglst.Images.SetKeyName(0, "order.png");
            // 
            // print_dlg
            // 
            this.print_dlg.Document = this.print_doc;
            // 
            // print_doc
            // 
            this.print_doc.BeginPrint += new System.Drawing.Printing.PrintEventHandler(this.print_doc_BeginPrint);
            this.print_doc.EndPrint += new System.Drawing.Printing.PrintEventHandler(this.print_doc_EndPrint);
            this.print_doc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.print_doc_PrintPage);
            // 
            // print_prvw_dlg
            // 
            this.print_prvw_dlg.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.print_prvw_dlg.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.print_prvw_dlg.ClientSize = new System.Drawing.Size(400, 300);
            this.print_prvw_dlg.Document = this.print_doc;
            this.print_prvw_dlg.Enabled = true;
            this.print_prvw_dlg.Icon = ((System.Drawing.Icon)(resources.GetObject("print_prvw_dlg.Icon")));
            this.print_prvw_dlg.Name = "print_prvw_dlg";
            this.print_prvw_dlg.ShowIcon = false;
            this.print_prvw_dlg.Visible = false;
            // 
            // printer_spool_lstvw
            // 
            this.printer_spool_lstvw.ContextMenuStrip = this.printer_spool_cmnstrp;
            this.printer_spool_lstvw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.printer_spool_lstvw.FullRowSelect = true;
            this.printer_spool_lstvw.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.printer_spool_lstvw.HideSelection = false;
            this.printer_spool_lstvw.Location = new System.Drawing.Point(0, 0);
            this.printer_spool_lstvw.Name = "printer_spool_lstvw";
            this.printer_spool_lstvw.Size = new System.Drawing.Size(881, 135);
            this.printer_spool_lstvw.SmallImageList = this.printer_spool_imglst;
            this.printer_spool_lstvw.TabIndex = 1;
            this.printer_spool_lstvw.UseCompatibleStateImageBehavior = false;
            this.printer_spool_lstvw.View = System.Windows.Forms.View.Details;
            // 
            // printer_spool_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 135);
            this.ControlBox = false;
            this.Controls.Add(this.printer_spool_lstvw);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "printer_spool_form";
            this.ShowInTaskbar = false;
            this.Text = "Очередь печати";
            this.Load += new System.EventHandler(this.printer_spool_form_Load);
            this.printer_spool_cmnstrp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private PrinterSpoolListView printer_spool_lstvw;
        private System.Windows.Forms.ContextMenuStrip printer_spool_cmnstrp;
        private System.Windows.Forms.ImageList printer_spool_imglst;
        private System.Windows.Forms.ToolStripMenuItem del_cmi;
        private System.Windows.Forms.ToolStripMenuItem edit_cmi;
        private System.Windows.Forms.PrintDialog print_dlg;
        private System.Drawing.Printing.PrintDocument print_doc;
        private System.Windows.Forms.PrintPreviewDialog print_prvw_dlg;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem view_and_print_cmi;
    }
}