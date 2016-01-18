namespace ntrclient
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class QuickCmdWindow : Form
    {
        private DataGridViewTextBoxColumn Cmd;
        private IContainer components = null;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn ID;

        public QuickCmdWindow()
        {
            this.InitializeComponent();
            this.loadCmds();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string str = (string) this.dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                string s = (string) this.dataGridView1.Rows[e.RowIndex].Cells[0].Value;
                Program.sm.quickCmds[int.Parse(s)] = str;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new DataGridView();
            this.ID = new DataGridViewTextBoxColumn();
            this.Cmd = new DataGridViewTextBoxColumn();
            ((ISupportInitialize) this.dataGridView1).BeginInit();
            base.SuspendLayout();
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new DataGridViewColumn[] { this.ID, this.Cmd });
            this.dataGridView1.Dock = DockStyle.Fill;
            this.dataGridView1.Location = new Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 0x17;
            this.dataGridView1.Size = new Size(0x1c5, 280);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellValueChanged += new DataGridViewCellEventHandler(this.dataGridView1_CellValueChanged);
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.Cmd.HeaderText = "Command";
            this.Cmd.Name = "Cmd";
            this.Cmd.Width = 300;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x1c5, 280);
            base.Controls.Add(this.dataGridView1);
            base.Name = "QuickCmdWindow";
            this.Text = "CmdInputWindow";
            ((ISupportInitialize) this.dataGridView1).EndInit();
            base.ResumeLayout(false);
        }

        private void listView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void loadCmds()
        {
            for (int i = 0; i <= 9; i++)
            {
                string[] values = new string[] { i.ToString(), Program.sm.quickCmds[i] };
                this.dataGridView1.Rows.Add(values);
            }
        }
    }
}

