namespace ntrclient
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    public class AsmEditWindow : Form
    {
        private string asPath = "bin/arm-none-eabi-as";
        private Button button1;
        private Button button2;
        private ComboBox comboBox1;
        private byte[] compileResult = null;
        private IContainer components = null;
        private Label label1;
        private Label label2;
        private string ldPath = "bin/arm-none-eabi-ld";
        private string ocPath = "bin/arm-none-eabi-objcopy";
        private Panel panel1;
        private SplitContainer splitContainer1;
        private TableLayoutPanel tableLayoutPanel1;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox txtAsmText;

        public AsmEditWindow()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.compileAsmCode();
        }

        private bool callToolchain(string asOpts, string ldOpts, string ocOpts, ref string result)
        {
            string output = null;
            result = "";
            int num = Utility.runCommandAndGetOutput(this.asPath, asOpts, ref output);
            string str2 = result;
            result = str2 + this.asPath + asOpts + "\r\n" + output + "\r\n";
            if (num != 0)
            {
                return false;
            }
            num = Utility.runCommandAndGetOutput(this.ldPath, ldOpts, ref output);
            str2 = result;
            result = str2 + this.ldPath + ldOpts + "\r\n" + output + "\r\n";
            if (num != 0)
            {
                return false;
            }
            num = Utility.runCommandAndGetOutput(this.ocPath, ocOpts, ref output);
            str2 = result;
            result = str2 + this.ocPath + ocOpts + "\r\n" + output + "\r\n";
            if (num != 0)
            {
                return false;
            }
            return true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void compileAsmCode()
        {
            this.compileResult = null;
            string text = this.txtAsmText.Text;
            string[] strArray = this.comboBox1.Text.Split(new char[] { ',' });
            string str2 = strArray[0];
            string asOpts = " ";
            string ldOpts = " ";
            string ocOpts = " ";
            uint num = Convert.ToUInt32(this.textBox1.Text, 0x10);
            File.WriteAllText("payload.s", text);
            asOpts = (asOpts + "-o payload.o -mlittle-endian") + " -march=" + str2;
            if ((strArray.Length > 1) && (strArray[1] == "thumb"))
            {
                asOpts = asOpts + " -mthumb";
            }
            asOpts = asOpts + " payload.s";
            ldOpts = ldOpts + " -Ttext 0x" + num.ToString("X8") + " payload.o";
            ocOpts = ocOpts + " -I elf32-little -O binary a.out payload.bin ";
            string result = "";
            if (!this.callToolchain(asOpts, ldOpts, ocOpts, ref result))
            {
                result = result + "compile failed...";
            }
            else
            {
                this.compileResult = File.ReadAllBytes("payload.bin");
                result = result + "result: \r\n" + Utility.convertByteArrayToHexString(this.compileResult);
            }
            this.textBox2.Text = result;
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
            this.splitContainer1 = new SplitContainer();
            this.txtAsmText = new TextBox();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.panel1 = new Panel();
            this.label1 = new Label();
            this.textBox1 = new TextBox();
            this.label2 = new Label();
            this.comboBox1 = new ComboBox();
            this.button1 = new Button();
            this.textBox2 = new TextBox();
            this.button2 = new Button();
            this.splitContainer1.BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Panel1.Controls.Add(this.txtAsmText);
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new Size(0x342, 0x1e6);
            this.splitContainer1.SplitterDistance = 0x1c1;
            this.splitContainer1.TabIndex = 0;
            this.txtAsmText.Dock = DockStyle.Fill;
            this.txtAsmText.Font = new Font("Consolas", 12f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.txtAsmText.Location = new Point(0, 0);
            this.txtAsmText.MaxLength = 0x1f3fc18;
            this.txtAsmText.Multiline = true;
            this.txtAsmText.Name = "txtAsmText";
            this.txtAsmText.ScrollBars = ScrollBars.Vertical;
            this.txtAsmText.Size = new Size(0x1c1, 0x1e6);
            this.txtAsmText.TabIndex = 1;
            this.txtAsmText.Text = ".global _start\r\n.type _start, %function\r\n_start:\r\n";
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50f));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox2, 0, 1);
            this.tableLayoutPanel1.Dock = DockStyle.Fill;
            this.tableLayoutPanel1.Location = new Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 35.32009f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 64.67991f));
            this.tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 46f));
            this.tableLayoutPanel1.Size = new Size(0x17d, 0x1e6);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.Paint += new PaintEventHandler(this.tableLayoutPanel1_Paint);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x173, 0x83);
            this.panel1.TabIndex = 0;
            this.label1.AutoSize = true;
            this.label1.Location = new Point(3, 6);
            this.label1.Name = "label1";
            this.label1.Size = new Size(0x41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "BaseAddr: ";
            this.label1.Click += new EventHandler(this.label1_Click);
            this.textBox1.Location = new Point(0x6d, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new Size(100, 0x15);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "00000000";
            this.label2.AutoSize = true;
            this.label2.Location = new Point(3, 0x20);
            this.label2.Name = "label2";
            this.label2.Size = new Size(0x6b, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Instruction Set: ";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] { "armv5t", "armv5t,thumb", "armv6k", "armv6k,thumb" });
            this.comboBox1.Location = new Point(0x6d, 0x1d);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new Size(0x79, 20);
            this.comboBox1.TabIndex = 3;
            this.comboBox1.Text = "armv6k";
            this.comboBox1.SelectedIndexChanged += new EventHandler(this.comboBox1_SelectedIndexChanged);
            this.button1.Location = new Point(5, 0x55);
            this.button1.Name = "button1";
            this.button1.Size = new Size(0x4b, 0x17);
            this.button1.TabIndex = 4;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new EventHandler(this.button1_Click);
            this.textBox2.Dock = DockStyle.Fill;
            this.textBox2.Location = new Point(3, 0xae);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = ScrollBars.Vertical;
            this.textBox2.Size = new Size(0x177, 0x135);
            this.textBox2.TabIndex = 1;
            this.button2.Location = new Point(0x9b, 0x55);
            this.button2.Name = "button2";
            this.button2.Size = new Size(0x4b, 0x17);
            this.button2.TabIndex = 5;
            this.button2.Text = "Write";
            this.button2.UseVisualStyleBackColor = true;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x342, 0x1e6);
            base.Controls.Add(this.splitContainer1);
            base.Name = "AsmEditWindow";
            this.Text = "AsmEditWindow";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}

