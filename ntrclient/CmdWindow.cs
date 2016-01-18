namespace ntrclient
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using Microsoft.VisualBasic;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Net;
    using System.IO;

    public class CmdWindow : Form
    {
        private ToolStripMenuItem asmScratchPadToolStripMenuItem;
        private IContainer components = null;
        public LogDelegate delAddLog;
        private MenuStrip menuStrip1;
        private StatusStrip statusStrip1;
        private TableLayoutPanel tableLayoutPanel1;
        private Timer timer1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private TextBox txtCmd;
        private TextBox txtLog;
        private ToolStripMenuItem 命令输入器ToolStripMenuItem;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private Label label7;
        private NumericUpDown numericUpDown2;
        private Label label6;
        private TextBox textBox6;
        private Label label4;
        private NumericUpDown numericUpDown1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox2;
        private Button button1;
        private TabPage tabPage2;
        private Label label11;
        private TextBox textBox4;
        private Label label8;
        private ComboBox comboBox1;
        private CheckBox checkBox2;
        private TabPage tabPage3;
        private TextBox textBox7;
        private TextBox textBox1;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private ToolStripMenuItem 窗口ToolStripMenuItem;
        private int header1;
        private int battleadd;
        private int slotoffset;
        private string battleoffset;
        private string commpoint;
        private CheckBox checkBox5;
        private Button button2;
        private ToolStripMenuItem connectToolStripMenuItem;
        private string po1;
        private TabPage tabPage4;
        private NumericUpDown numericUpDown3;
        private Button button3;
        private string battlec;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private ToolStripMenuItem timerSettingToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem toolStripMenuItem3;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem5;
        private DateTime start;
        private double time;
        private string content;
        private GroupBox groupBox2;
        private Button button5;
        private Button button4;
        private GroupBox groupBox1;
        private ToolStripMenuItem nopAddressToolStripMenuItem;
        private string battletimeoffset;
        private string vraddress;
        private string part1;
        private string part2;
        private Button button6;
        private string part3;
        private string savePart1 = "00";
        private string savePart2 = "00";
        private string savePart3 = "01";
        private ToolStripMenuItem referenceToolStripMenuItem1;
        private ToolStripMenuItem itemIndexToolStripMenuItem;
        private Label label13;
        private GroupBox groupBox4;
        private Label label12;
        private TextBox textBox11;
        private Label label9;
        private TextBox textBox9;
        private TextBox textBox10;
        private Label label5;
        private TextBox textBox8;
        private TextBox textBox5;
        private GroupBox groupBox3;
        private Button button7;
        private TextBox textBox12;
        private Button button8;
        private GroupBox groupBox7;
        private Button button13;
        private Button button12;
        private Button button11;
        private Button button10;
        private GroupBox groupBox6;
        private Button button9;
        private CheckBox checkBox1;
        private GroupBox groupBox5;
        private GroupBox groupBox8;
        private Button button14;
        private TextBox textBox13;
        private string finalboffset;
        private int nodis;
        private int laps;
        private int coins;
        private Label label10;
        private ToolStripMenuItem countryCodesToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private Button button15;
        private Button button17;
        private Button button16;
        private string racetab;

        public CmdWindow()
        {
            this.delAddLog = new LogDelegate(this.Addlog);
            this.InitializeComponent();

            MessageBox.Show("The use of this application in online play puts you at a very high risk of a ban. You're responsible if that happens!");

            textBox2.MaxLength = 2;
            textBox2.Text = "00";
            textBox3.MaxLength = 2;
            textBox3.Text = "00";
            textBox6.MaxLength = 3;
            textBox6.Text = "28";
            textBox4.MaxLength = 2;
            textBox4.Text = "63";
            textBox1.MaxLength = 2;
            textBox1.Text = "03";
            textBox7.MaxLength = 2;
            textBox7.Text = "E7";
            numericUpDown1.Minimum = 1;
            numericUpDown1.Maximum = 8;
            numericUpDown1.Value = 8;
            numericUpDown2.Maximum = 8;
            numericUpDown2.Minimum = 1;
            numericUpDown2.Value = 1;
            numericUpDown3.Maximum = 99999;
            numericUpDown3.Minimum = 1;
            numericUpDown3.Value = 1;
            tabPage1.Text = "Items";
            tabPage2.Text = "Battle";
            tabPage3.Text = "Race Stats";
            tabPage4.Text = "Profile";
            checkBox2.Checked = false;
            comboBox1.Items.AddRange(new string[] { "Balloon Battle", "Coin Runners" });
            checkBox3.Checked = false;
            time = 1.5;
            toolStripMenuItem3.Checked = true;
            groupBox2.Enabled = false;
            button6.Enabled = false;
            textBox4.Enabled = true;
            comboBox1.SelectedIndex = 0;
            battlec = "None";

            textBox11.Text = "00";
            textBox11.MaxLength = 2;
            textBox5.Text = "00";
            textBox5.MaxLength = 2;
            textBox8.Text = "00";
            textBox8.MaxLength = 2;
            textBox10.Text = "00";
            textBox10.MaxLength = 2;
            textBox9.Text = "00";
            textBox9.MaxLength = 2;

            textBox12.MaxLength = 8;
            textBox12.Text = "00000000";

            groupBox7.Enabled = false;
            groupBox8.Enabled = false;
            button9.Enabled = false;
            textBox13.Text = "0A";
            textBox8.MaxLength = 2;
        }

        public void Addlog(string l)
        {
            if (!l.Contains("\r\n"))
            {
                l = l.Replace("\n", "\r\n");
            }
            if (!l.EndsWith("\n"))
            {
                l = l + "\r\n";
            }
            this.txtLog.AppendText(l);
        }

        private void asmScratchPadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new AsmEditWindow().Show();
        }

        private void CmdWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.saveConfig();
            Program.ntrClient.disconnect(true);
        }

        private void CmdWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                int keyValue = e.KeyValue;
                if ((keyValue >= 0x30) && (keyValue <= 0x39))
                {
                    this.runCmd(Program.sm.quickCmds[keyValue - 0x30]);
                    e.SuppressKeyPress = true;
                }
            }
            if (e.KeyCode == Keys.Space)
            {
                button1_Click(this, new EventArgs());
            }
        }

        private void CmdWindow_Load(object sender, EventArgs e)
        {
            this.Addlog("NTR debugger by cell9");
            this.Addlog("Edited for Mario Kart 7 by Huntereb");
            this.runCmd(@"import sys;sys.path.append('.\python\Lib')");
            this.runCmd("for n in [n for n in dir(nc) if not n.startswith('_')]: globals()[n] = getattr(nc,n)    ");
            this.Addlog("Commands available: ");
            this.runCmd("repr([n for n in dir(nc) if not n.startswith('_')])");
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CmdWindow));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtCmd = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.checkBox5 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button6 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.button8 = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button17 = new System.Windows.Forms.Button();
            this.button16 = new System.Windows.Forms.Button();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.窗口ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nopAddressToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.命令输入器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asmScratchPadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.referenceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.itemIndexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.countryCodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerSettingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.txtLog, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtCmd, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.tabControl1, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 24);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(680, 464);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(3, 3);
            this.txtLog.MaxLength = 32767000;
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(674, 280);
            this.txtLog.TabIndex = 0;
            // 
            // txtCmd
            // 
            this.txtCmd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCmd.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCmd.Location = new System.Drawing.Point(3, 289);
            this.txtCmd.Name = "txtCmd";
            this.txtCmd.Size = new System.Drawing.Size(674, 26);
            this.txtCmd.TabIndex = 1;
            this.txtCmd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCmd_KeyDown);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 444);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(680, 20);
            this.statusStrip1.TabIndex = 2;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 15);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(3, 321);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(674, 120);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.textBox12);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.checkBox5);
            this.tabPage1.Controls.Add(this.checkBox4);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.numericUpDown2);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBox6);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(666, 94);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(8, 26);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(69, 20);
            this.textBox12.TabIndex = 60;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(501, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(78, 47);
            this.button2.TabIndex = 59;
            this.button2.Text = "Find Map and Offset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // checkBox5
            // 
            this.checkBox5.AutoSize = true;
            this.checkBox5.Location = new System.Drawing.Point(501, 60);
            this.checkBox5.Name = "checkBox5";
            this.checkBox5.Size = new System.Drawing.Size(52, 17);
            this.checkBox5.TabIndex = 57;
            this.checkBox5.Text = "Mirror";
            this.checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(585, 60);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(76, 17);
            this.checkBox4.TabIndex = 55;
            this.checkBox4.Text = "Auto-Enter";
            this.checkBox4.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(298, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 49;
            this.label7.Text = "Player Number";
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(301, 26);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown2.TabIndex = 48;
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(375, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Process ID";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(378, 26);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(42, 20);
            this.textBox6.TabIndex = 45;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(224, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 40;
            this.label4.Text = "Total Players";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(227, 26);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(32, 20);
            this.numericUpDown1.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(152, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 38;
            this.label3.Text = "Item Amount";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Item Index";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Item Offset";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(93, 26);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(39, 20);
            this.textBox3.TabIndex = 35;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(155, 26);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(39, 20);
            this.textBox2.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(585, 7);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 47);
            this.button1.TabIndex = 32;
            this.button1.Text = "Generate Code";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox2);
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.comboBox1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(666, 94);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Location = new System.Drawing.Point(215, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(88, 88);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Time";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(6, 48);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 1;
            this.button5.Text = "Set to Max";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(6, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "Set to Zero";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(133, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(76, 88);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Points";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(38, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(31, 23);
            this.button6.TabIndex = 7;
            this.button6.Text = "Set";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(6, 14);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(67, 17);
            this.checkBox2.TabIndex = 0;
            this.checkBox2.Text = "Auto-Set";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(9, 50);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(23, 20);
            this.textBox4.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 34);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Points";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 3);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 2;
            this.label8.Text = "Game Mode";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.TextChanged += new System.EventHandler(this.comboBox1_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox8);
            this.tabPage3.Controls.Add(this.groupBox7);
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(666, 94);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.button14);
            this.groupBox8.Controls.Add(this.textBox13);
            this.groupBox8.Location = new System.Drawing.Point(437, 6);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(73, 82);
            this.groupBox8.TabIndex = 11;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Coins";
            // 
            // button14
            // 
            this.button14.Location = new System.Drawing.Point(37, 17);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(31, 23);
            this.button14.TabIndex = 9;
            this.button14.Text = "Set";
            this.button14.UseVisualStyleBackColor = true;
            this.button14.Click += new System.EventHandler(this.button14_Click);
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(6, 19);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(25, 20);
            this.textBox13.TabIndex = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.label10);
            this.groupBox7.Controls.Add(this.button13);
            this.groupBox7.Controls.Add(this.button12);
            this.groupBox7.Controls.Add(this.button11);
            this.groupBox7.Controls.Add(this.button10);
            this.groupBox7.Location = new System.Drawing.Point(280, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(151, 82);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Laps";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(79, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 9);
            this.label10.TabIndex = 4;
            this.label10.Text = "(Buggy)";
            // 
            // button13
            // 
            this.button13.Location = new System.Drawing.Point(6, 48);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(69, 23);
            this.button13.TabIndex = 3;
            this.button13.Text = "Instant Win";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(102, 19);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(42, 23);
            this.button12.TabIndex = 2;
            this.button12.Text = "Lap 3";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(54, 19);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(42, 23);
            this.button11.TabIndex = 1;
            this.button11.Text = "Lap 2";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(6, 19);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(42, 23);
            this.button10.TabIndex = 0;
            this.button10.Text = "Lap 1";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.button9);
            this.groupBox6.Controls.Add(this.checkBox1);
            this.groupBox6.Location = new System.Drawing.Point(143, 6);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(130, 82);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "No Disconnect";
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(6, 42);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(54, 23);
            this.button9.TabIndex = 2;
            this.button9.Text = "Turn on";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(125, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Auto-apply with items";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.textBox7);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(131, 82);
            this.groupBox5.TabIndex = 9;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Points";
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(58, 40);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(31, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "Set";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(6, 19);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(125, 17);
            this.checkBox3.TabIndex = 0;
            this.checkBox3.Text = "Auto-apply with items";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(22, 20);
            this.textBox1.TabIndex = 3;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(30, 42);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(22, 20);
            this.textBox7.TabIndex = 4;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(666, 94);
            this.tabPage4.TabIndex = 2;
            this.tabPage4.Text = "tabPage4";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(505, 6);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(155, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Apply these before going online";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button8);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.textBox11);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.textBox9);
            this.groupBox4.Controls.Add(this.textBox10);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.textBox8);
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Location = new System.Drawing.Point(262, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(154, 82);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Region";
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(116, 13);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(32, 23);
            this.button8.TabIndex = 9;
            this.button8.Text = "Set";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Region Code:";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(78, 13);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(25, 20);
            this.textBox11.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(69, 38);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Y Coord";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(93, 54);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(23, 20);
            this.textBox9.TabIndex = 7;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(69, 54);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(23, 20);
            this.textBox10.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "X Coord";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(30, 54);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(23, 20);
            this.textBox8.TabIndex = 1;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(6, 54);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(23, 20);
            this.textBox5.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button15);
            this.groupBox3.Controls.Add(this.button17);
            this.groupBox3.Controls.Add(this.button16);
            this.groupBox3.Controls.Add(this.numericUpDown3);
            this.groupBox3.Controls.Add(this.button3);
            this.groupBox3.Location = new System.Drawing.Point(6, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(250, 82);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Save Data";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(143, 11);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(102, 23);
            this.button15.TabIndex = 5;
            this.button15.Text = "Unlock Everything";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click_1);
            // 
            // button17
            // 
            this.button17.Location = new System.Drawing.Point(70, 40);
            this.button17.Name = "button17";
            this.button17.Size = new System.Drawing.Size(67, 23);
            this.button17.TabIndex = 4;
            this.button17.Text = "Set Losses";
            this.button17.UseVisualStyleBackColor = true;
            this.button17.Click += new System.EventHandler(this.button17_Click);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(6, 40);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(58, 23);
            this.button16.TabIndex = 3;
            this.button16.Text = "Set Wins";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.Location = new System.Drawing.Point(6, 14);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(75, 20);
            this.numericUpDown3.TabIndex = 0;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(87, 11);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(50, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Set VR";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.窗口ToolStripMenuItem,
            this.referenceToolStripMenuItem1,
            this.optionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(680, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 窗口ToolStripMenuItem
            // 
            this.窗口ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.nopAddressToolStripMenuItem,
            this.命令输入器ToolStripMenuItem,
            this.asmScratchPadToolStripMenuItem});
            this.窗口ToolStripMenuItem.Name = "窗口ToolStripMenuItem";
            this.窗口ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.窗口ToolStripMenuItem.Text = "Tools";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // nopAddressToolStripMenuItem
            // 
            this.nopAddressToolStripMenuItem.Name = "nopAddressToolStripMenuItem";
            this.nopAddressToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.nopAddressToolStripMenuItem.Text = "Nop Address";
            this.nopAddressToolStripMenuItem.Click += new System.EventHandler(this.nopAddressToolStripMenuItem_Click);
            // 
            // 命令输入器ToolStripMenuItem
            // 
            this.命令输入器ToolStripMenuItem.Name = "命令输入器ToolStripMenuItem";
            this.命令输入器ToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.命令输入器ToolStripMenuItem.Text = "Hotkey Commands";
            this.命令输入器ToolStripMenuItem.Click += new System.EventHandler(this.命令输入器ToolStripMenuItem_Click);
            // 
            // asmScratchPadToolStripMenuItem
            // 
            this.asmScratchPadToolStripMenuItem.Name = "asmScratchPadToolStripMenuItem";
            this.asmScratchPadToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.asmScratchPadToolStripMenuItem.Text = "Asm ScratchPad";
            this.asmScratchPadToolStripMenuItem.Click += new System.EventHandler(this.asmScratchPadToolStripMenuItem_Click);
            // 
            // referenceToolStripMenuItem1
            // 
            this.referenceToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.itemIndexToolStripMenuItem,
            this.countryCodesToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.referenceToolStripMenuItem1.Name = "referenceToolStripMenuItem1";
            this.referenceToolStripMenuItem1.Size = new System.Drawing.Size(71, 20);
            this.referenceToolStripMenuItem1.Text = "Reference";
            // 
            // itemIndexToolStripMenuItem
            // 
            this.itemIndexToolStripMenuItem.Name = "itemIndexToolStripMenuItem";
            this.itemIndexToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.itemIndexToolStripMenuItem.Text = "Item Index";
            this.itemIndexToolStripMenuItem.Click += new System.EventHandler(this.itemIndexToolStripMenuItem_Click);
            // 
            // countryCodesToolStripMenuItem
            // 
            this.countryCodesToolStripMenuItem.Name = "countryCodesToolStripMenuItem";
            this.countryCodesToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.countryCodesToolStripMenuItem.Text = "Country Codes";
            this.countryCodesToolStripMenuItem.Click += new System.EventHandler(this.countryCodesToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.timerSettingToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // timerSettingToolStripMenuItem
            // 
            this.timerSettingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4,
            this.toolStripMenuItem5});
            this.timerSettingToolStripMenuItem.Name = "timerSettingToolStripMenuItem";
            this.timerSettingToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.timerSettingToolStripMenuItem.Text = "Timer Setting";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.CheckOnClick = true;
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem2.Text = "1 (Fast)";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.CheckOnClick = true;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem3.Text = "1.5 (Normal)";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.CheckOnClick = true;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem4.Text = "2 (Slow)";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.CheckOnClick = true;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(143, 22);
            this.toolStripMenuItem5.Text = "3 (Ultra slow)";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // CmdWindow
            // 
            this.ClientSize = new System.Drawing.Size(680, 488);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CmdWindow";
            this.Text = "NTR Debugger Client for MK7 V1.0 PUBLIC FINAL";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CmdWindow_FormClosed);
            this.Load += new System.EventHandler(this.CmdWindow_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CmdWindow_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void runCmd(string cmd)
        {
            try
            {
                this.Addlog("> " + cmd);
                object obj2 = Program.pyEngine.CreateScriptSourceFromString(cmd).Execute(Program.globalScope);
                if (obj2 != null)
                {
                    this.Addlog(obj2.ToString());
                }
                else
                {
                    this.Addlog("null");
                }
            }
            catch (Exception exception)
            {
                this.Addlog(exception.Message);
                this.Addlog(exception.StackTrace);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                this.updateProgress();
                Program.ntrClient.sendHeartbeatPacket();
            }
            catch (Exception)
            {
            }
        }

        private void txtCmd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string text = this.txtCmd.Text;
                this.txtCmd.Clear();
                this.runCmd(text);
            }
        }

        private void updateProgress()
        {
            string str = "";
            if (Program.ntrClient.progress != -1)
            {
                str = string.Format("{0}%", (int) Program.ntrClient.progress);
            }
            this.toolStripStatusLabel1.Text = str;
        }

        private void 命令输入器ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new QuickCmdWindow().Show();
        }

        public delegate void LogDelegate(string l);

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox12.Text == "" || textBox12.TextLength != 8 || textBox12.Text == "00000000")
            {
                MessageBox.Show("Error: You must find or supply an offset before generating item codes!");
                return;
            }

            if (battlec == "None")
            {
                checkBox2.Checked = false;
            }

            if (battlec != "None")
            {
                checkBox1.Checked = false;
            }

            int b1 = (Int32.Parse(textBox12.Text, System.Globalization.NumberStyles.HexNumber));         //Initial Box value converted to Decimal

            if (numericUpDown1.Value == 1)           //Set player count offset ammounts
            {
                header1 = 4;
            }

            if (numericUpDown1.Value == 2)
            {
                header1 = 8;
            }

            if (numericUpDown1.Value == 3)
            {
                header1 = 12;
            }

            if (numericUpDown1.Value == 4)
            {
                header1 = 16;
            }

            if (numericUpDown1.Value == 5)
            {
                header1 = 20;
            }

            if (numericUpDown1.Value == 6)
            {
                header1 = 24;
            }

            if (numericUpDown1.Value == 7)
            {
                header1 = 28;
            }

            if (numericUpDown1.Value == 8)
            {
                header1 = 32;
            }

            int itemgive1x1 = (b1 + slotoffset + 184 + header1);           //Additions to the original value to create valid offsets
            int amount1x1 = (b1 + slotoffset + 76 + header1);
            int item1x3 = (b1 + slotoffset + 216 + header1);

            string hexLine1x1 = itemgive1x1.ToString("X");            //Convert added decimal values back to hex
            string hexLine1x2 = amount1x1.ToString("X");
            string hexLine1x4 = item1x3.ToString("X");

            string itemcode = "write(0x" + hexLine1x2 + ", (0x" + textBox2.Text + ", ), pid=0x" + textBox6.Text + "), write(0x" + hexLine1x4 + ", (0x" + textBox3.Text + ", ), pid=0x" + textBox6.Text + "), write(0x" + hexLine1x1 + ", (0x03, ), pid=0x" + textBox6.Text + "), ";

            txtCmd.Text = (itemcode);

            if (checkBox2.Checked == true)          //Battle codes
            {
                txtCmd.AppendText("write(0x" + finalboffset + ", (0x" + textBox4.Text + ", 0x00, 0x00, 0x06), pid=0x" + textBox6.Text + "), ");
            }

            if (checkBox3.Checked == true)          //Community Points
            {
                txtCmd.AppendText("write(0x" + commpoint + ", (0x" + textBox7.Text + ", 0x" + textBox1.Text + "), pid=0x" + textBox6.Text + "), ");
                checkBox3.Checked = false;
            }

            if (checkBox1.Checked == true)
            {
                    int nd = (Int32.Parse(racetab, System.Globalization.NumberStyles.HexNumber));

                    int nd2 = (nd + nodis);

                    string nd3 = nd2.ToString("X");

                    txtCmd.AppendText("write(0x" + nd3 + ", (0x02, ), pid=0x" + textBox6.Text + "), ");
            }

            if (checkBox4.Checked == true)
            {
                string text = this.txtCmd.Text;
                this.txtCmd.Clear();
                this.runCmd(text);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtLog.Clear();
            this.runCmd("data(0x1417F5CF, 0x10, pid=0x" + textBox6.Text + ") #");

            start = DateTime.Now;

            while (DateTime.Now.Subtract(start).Seconds < time)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }

            po1 = "None";

            string trackname = txtLog.Text;

            if (trackname.Contains("47 63 74 72 5F 54 6F 61 64 43"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166DC580";
                    po1 = "166DB82C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166DC900";
                    po1 = "166DBBAC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 47 6C 69 64 65"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166DD880";
                    po1 = "166DCB2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166DDC00";
                    po1 = "166DCEAC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 4D 61 72 69 6E"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166E3000";
                    po1 = "166E22AC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166E3300";
                    po1 = "166E25AC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 53 61 6E 64 54"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "1671EA80";
                    po1 = "1671DD2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "1671EE00";
                    po1 = "1671E0AC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 57 75 68 75 49 73 6C 61 6E 64 31"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "16724700";
                    po1 = "167239AC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "16724A80";
                    po1 = "16723D2C";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 4D 61 72 69 6F"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166BEE80";
                    po1 = "166BE12C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166BF200";
                    po1 = "166BE4AC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 4D 75 73 69 63"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166E6B80";
                    po1 = "166E5E2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166E6F00";
                    po1 = "166E61AC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 52 61 6C 6C 79"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "16738500";
                    po1 = "167377AC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "16738880";
                    po1 = "16737B2C";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 55 6E 64 65 72"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "16701480";
                    po1 = "1670072C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "16701800";
                    po1 = "16700AAC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 57 61 72 69 6F"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "16706C00";
                    po1 = "16705EAC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "16706F80";
                    po1 = "1670622C";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 41 64 76 61 6E"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166C3F80";
                    po1 = "166C322C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166C4300";
                    po1 = "166C35AC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 57 75 68 75 49 73 6C 61 6E 64 32"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "16737280";
                    po1 = "1673652C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "16737600";
                    po1 = "167368AC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 44 4B 4A 75 6E"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "16760E00";
                    po1 = "167600AC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "16761180";
                    po1 = "1676042C";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 49 63 65 53 6C"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166F8380";
                    po1 = "166F762C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166F8700";
                    po1 = "166F79AC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 42 6F 77 73 65"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "16723780";
                    po1 = "16722A2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "16723B00";
                    po1 = "16722DAC";
                }
            }

            if (trackname.Contains("47 63 74 72 5F 52 61 69 6E 62"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "16719A80";
                    po1 = "16718D2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "1670F400";
                    po1 = "167190AC";
                }
            }

            if (trackname.Contains("47 6E 36 34 5F 4C 75 69 67 69"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "1670F080";
                    po1 = "1670E32C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "1670F400";
                    po1 = "1670E6AC";
                }
            }

            if (trackname.Contains("47 61 67 62 5F 42 6F 77 73 65"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166F8D00";
                    po1 = "166F7FAC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166F9080";
                    po1 = "166F832C";
                }
            }

            if (trackname.Contains("47 77 69 69 5F 4D 75 73 68 72"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "16715B80";
                    po1 = "16714E2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "16715F00";
                    po1 = "167151AC";
                }
            }

            if (trackname.Contains("47 64 73 5F 4C 75 69 67 69 73"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166DEC80";
                    po1 = "166DDF2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166DF000";
                    po1 = "166DE2AC";
                }
            }

            if (trackname.Contains("47 6E 36 34 5F 4B 6F 6F 70 61"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "1670AC80";
                    po1 = "16709F2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "1670B000";
                    po1 = "1670A2AC";
                }
            }

            if (trackname.Contains("47 73 66 63 5F 4D 61 72 69 6F"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166A7380";
                    po1 = "166A662C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166A7700";
                    po1 = "166A69AC";
                }
            }

            if (trackname.Contains("47 77 69 69 5F 43 6F 63 6F 6E"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166F5400";
                    po1 = "166F46AC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166F5780";
                    po1 = "166F4A2C";
                }
            }

            if (trackname.Contains("47 64 73 5F 57 61 6C 75 69 67"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "1670C780";
                    po1 = "1670BA2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "1670CB00";
                    po1 = "1670BDAC";
                }
            }

            if (trackname.Contains("47 6E 36 34 5F 4B 61 6C 69 6D"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166C2B00";
                    po1 = "166C1DAC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166C2E00";
                    po1 = "166C20AC";
                }
            }

            if (trackname.Contains("47 64 73 5F 44 4B 50 61 73 73"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166B3780";
                    po1 = "166B2A2C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166B3B00";
                    po1 = "166B2DAC";
                }
            }

            if (trackname.Contains("47 67 63 5F 44 61 69 73 79 43"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166F2E80";
                    po1 = "166F212C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166F3200";
                    po1 = "166F24AC";
                }
            }

            if (trackname.Contains("47 77 69 69 5F 4D 61 70 6C 65"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "1672AA00";
                    po1 = "16729CAC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "1672AD80";
                    po1 = "1672A02C";
                }
            }

            if (trackname.Contains("47 77 69 69 5F 4B 6F 6F 70 61"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166E4080";
                    po1 = "166E332C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166E4380";
                    po1 = "166E362C";
                }
            }

            if (trackname.Contains("47 67 63 5F 44 69 6E 6F 44 69"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166FB580";
                    po1 = "166FA82C";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166FB900";
                    po1 = "166FABAC";
                }
            }

            if (trackname.Contains("47 64 73 5F 41 69 72 73 68 69"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166C8000";
                    po1 = "166C72AC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166C8380";
                    po1 = "166C762C";
                }
            }

            if (trackname.Contains("47 73 66 63 5F 52 61 69 6E 62"))
            {
                if (checkBox5.Checked == false)
                {
                    racetab = "166CCE00";
                    po1 = "166CC0AC";
                }
                if (checkBox5.Checked == true)
                {
                    racetab = "166CD180";
                    po1 = "166CC42C";
                }
            }

            battlec = "None";
            if (trackname.Contains("42 61 67 62 5F 42 61 74 74 6C"))
            {
                po1 = "166B7B2C";
                battlec = "1";
            }

            if (trackname.Contains("42 6E 36 34 5F 42 69 67 44 6F"))
            {
                po1 = "167012AC";
                battlec = "2";
            }

            if (trackname.Contains("42 64 73 5F 50 61 6C 6D 53 68"))
            {
                po1 = "166F5B2C";
                battlec = "3";
            }

            if (trackname.Contains("42 63 74 72 5F 48 6F 6E 65 79"))
            {
                po1 = "166C6E2C";
                battlec = "4";
            }

            if (trackname.Contains("42 63 74 72 5F 49 63 65 52 69"))
            {
                po1 = "166E382C";
                battlec = "5";
            }

            if (trackname.Contains("42 63 74 72 5F 57 75 68 75 49"))
            {
                po1 = "166DE02C";
                battlec = "6";
            }
            if (po1 == "None")
            {
                MessageBox.Show("Error: No track detected");
                txtLog.Clear();
                txtLog.Text = "> Failed to find offset\n";
                return;
            }

            this.txtLog.Clear();
            this.runCmd("data(0x" + po1 + ", 0x4, pid=0x" + textBox6.Text + ") #");

            start = DateTime.Now;

            while (DateTime.Now.Subtract(start).Seconds < time)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1);
            }
            
            string pointer = (txtLog.Text.Split(new string[] { "= 4\r\n" }, StringSplitOptions.None))[1];
            string pointer1 = (pointer.Split(new string[] { " \r\nfin" }, StringSplitOptions.None))[0];
            string part1 = (pointer1.Split(new string[] { " " }, StringSplitOptions.None))[0];
            string part2 = (pointer1.Split(new string[] { " " }, StringSplitOptions.None))[1];
            string part3 = (pointer1.Split(new string[] { " " }, StringSplitOptions.None))[2];
            string part4 = (pointer1.Split(new string[] { " " }, StringSplitOptions.None))[3];
            string mainoffset = part4 + part3 + part2 + part1;

            if (!(part4.Contains("16") || part4.Contains("17")))
            {
                MessageBox.Show("Error: The offset does not look correct. Is this a Mirror Mode track?");
                txtLog.Clear();
                txtLog.Text = "> Failed to find offset; Offset Invalid\n";
                textBox12.Text = "00000000";
                return;
            }

            txtLog.Clear();
            txtLog.Text = "> Offset found successfully\n";

            textBox12.Text = mainoffset;

            button1.Focus();

            if (battlec != "None")
            {
                groupBox2.Enabled = true;
                groupBox1.Enabled = true;
                button6.Enabled = true;
                groupBox7.Enabled = false;
                groupBox8.Enabled = false;
                button9.Enabled = false;

                if (comboBox1.SelectedIndex == 0)
                {
                    if (battlec == "1")
                    {
                        battleoffset = "166b9c90";
                        battletimeoffset = "166B9138";
                    }

                    if (battlec == "2")
                    {
                        battleoffset = "16703410";
                        battletimeoffset = "167028B8";
                    }

                    if (battlec == "3")
                    {
                        battleoffset = "166F7c90";
                        battletimeoffset = "166F7138";
                    }

                    if (battlec == "4")
                    {
                        battleoffset = "166C8f90";
                        battletimeoffset = "166C8438";
                    }

                    if (battlec == "5")
                    {
                        battleoffset = "166E5990";
                        battletimeoffset = "166E4E38";
                    }

                    if (battlec == "6")
                    {
                        battleoffset = "166e0190";
                        battletimeoffset = "166DF638";
                    }
                }

                if (comboBox1.SelectedIndex == 1)
                {
                    if (battlec == "1")
                    {
                        battleoffset = "166b9482";
                        battletimeoffset = "166B8938";
                    }

                    if (battlec == "2")
                    {
                        battleoffset = "16702C02";
                        battletimeoffset = "167020B8";
                    }

                    if (battlec == "3")
                    {
                        battleoffset = "166F7482";
                        battletimeoffset = "166F6938";
                    }

                    if (battlec == "4")
                    {
                        battleoffset = "166C8782";
                        battletimeoffset = "166C7C38";
                    }

                    if (battlec == "5")
                    {
                        battleoffset = "166E5182";
                        battletimeoffset = "166E4638";
                    }

                    if (battlec == "6")
                    {
                        battleoffset = "166DF982";
                        battletimeoffset = "166DEE38";
                    }
                }

                int cbo = (Int32.Parse(battleoffset, System.Globalization.NumberStyles.HexNumber));

                int cfinaloffset = (cbo + battleadd);

                finalboffset = cfinaloffset.ToString("X");
            }

            if (battlec == "None")
            {
                button6.Enabled = false;
                groupBox2.Enabled = false;
                groupBox7.Enabled = true;
                groupBox8.Enabled = true;
                button9.Enabled = true;
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string ip = Interaction.InputBox("Enter IP", "Connect", "192.168.1.1");
            if (ip == "")
            {
                return;
            }
            this.runCmd("connect('" + ip + "', 8000)");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.runCmd("write(0x1413C144, (0x" + savePart3 + ", 0x" + savePart2 + ", 0x" + savePart1 + "), pid=0x" + textBox6.Text + ")");
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            time = 1;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            time = 1.5;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem5.Checked = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {

            time = 2;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem5.Checked = false;
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {

            time = 3;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            toolStripMenuItem2.Checked = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (battlec == "None")
            {
                MessageBox.Show("Error: No Map detected");
                return;
            }

            this.runCmd("write(0x" + battletimeoffset + ", (0x00, 0x00, 0x00, 0x00), pid=0x" + textBox6.Text + ")");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (battlec == "None")
            {
                MessageBox.Show("Error: No Map detected");
                return;
            }

            this.runCmd("write(0x" + battletimeoffset + ", (0xFF, 0xFF, 0xFF, 0xFF), pid=0x" + textBox6.Text + ")");
        }

        private void nopAddressToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string address = Interaction.InputBox("Enter address to nop", "Go", "00000000");
            if (address == "")
            {
                return;
            }
            this.runCmd("write(0x" + address + ", (0x00, 0x00, 0xA0, 0xE1), pid=0x" + textBox6.Text + ")");
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            var playernum = numericUpDown2.Value;

            if (playernum == 1)           //Set additions to offset based on player number
            {
                battleadd = 0;
                slotoffset = 0;
                commpoint = "15474A80";
                vraddress = "15474A88";
                nodis = 0;
                laps = 24;
                coins = 6;
            }

            if (playernum == 2)
            {
                battleadd = 112;
                slotoffset = 384;
                commpoint = "15474AAC";
                vraddress = "15474AB4";
                nodis = 112;
                laps = 136;
                coins = 118;
            }

            if (playernum == 3)
            {
                battleadd = 224;
                slotoffset = 768;
                commpoint = "15474AD8";
                vraddress = "15474AE0";
                nodis = 224;
                laps = 248;
                coins = 230;
            }

            if (playernum == 4)
            {
                battleadd = 336;
                slotoffset = 1152;
                commpoint = "15474B04";
                vraddress = "15474B0C";
                nodis = 336;
                laps = 360;
                coins = 342;
            }

            if (playernum == 5)
            {
                battleadd = 448;
                slotoffset = 1536;
                commpoint = "15474B30";
                vraddress = "15474B38";
                nodis = 448;
                laps = 472;
                coins = 454;
            }

            if (playernum == 6)
            {
                battleadd = 560;
                slotoffset = 1920;
                commpoint = "15474B5C";
                vraddress = "15474B64";
                nodis = 560;
                laps = 584;
                coins = 566;
            }

            if (playernum == 7)
            {
                battleadd = 672;
                slotoffset = 2304;
                commpoint = "15474B88";
                vraddress = "15474B90";
                nodis = 672;
                laps = 696;
                coins = 678;
            }

            if (playernum == 8)
            {
                battleadd = 784;
                slotoffset = 2688;
                commpoint = "15474BB4";
                vraddress = "15474BBC";
                nodis = 784;
                laps = 808;
                coins = 790;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.runCmd("write(0x" + finalboffset + ", (0x" + textBox4.Text + ", 0x00, 0x00, 0x06), pid=0x" + textBox6.Text + ")");
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            battleoffset = "16000000";

            if (battlec == "None")
            {
                return;
            }

            if (comboBox1.SelectedIndex == 0)
            {
                if (battlec == "1")
                {
                    battleoffset = "166b9c90";
                    battletimeoffset = "166B9138";
                }

                if (battlec == "2")
                {
                    battleoffset = "16703410";
                    battletimeoffset = "167028B8";
                }

                if (battlec == "3")
                {
                    battleoffset = "166F7c90";
                    battletimeoffset = "166F7138";
                }

                if (battlec == "4")
                {
                    battleoffset = "166C8f90";
                    battletimeoffset = "166C8438";
                }

                if (battlec == "5")
                {
                    battleoffset = "166E5990";
                    battletimeoffset = "166E4E38";
                }

                if (battlec == "6")
                {
                    battleoffset = "166e0190";
                    battletimeoffset = "166DF638";
                }
            }

            if (comboBox1.SelectedIndex == 1)
            {
                if (battlec == "1")
                {
                    battleoffset = "166b9482";
                    battletimeoffset = "166B8938";
                }

                if (battlec == "2")
                {
                    battleoffset = "16702C02";
                    battletimeoffset = "167020B8";
                }

                if (battlec == "3")
                {
                    battleoffset = "166F7482";
                    battletimeoffset = "166F6938";
                }

                if (battlec == "4")
                {
                    battleoffset = "166C8782";
                    battletimeoffset = "166C7C38";
                }

                if (battlec == "5")
                {
                    battleoffset = "166E5182";
                    battletimeoffset = "166E4638";
                }

                if (battlec == "6")
                {
                    battleoffset = "166DF982";
                    battletimeoffset = "166DEE38";
                }
            }
                int cbo = (Int32.Parse(battleoffset, System.Globalization.NumberStyles.HexNumber));

                int cfinaloffset = (cbo + battleadd);

                finalboffset = cfinaloffset.ToString("X");
        }

        private void itemIndexToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("00 - Banana\r\n01 - Green Shell\r\n02 - Red Shell\r\n03 - Mushroom\r\n04 - Bob-Omb\r\n05 - Blooper\r\n06 - Blue Shell\r\n07 - Triple Mushroom\r\n08 - Star\r\n09 - Bullet Bill\r\n0A - Lightning\r\n0B - Golden Mushroom\r\n0C - Fire Flower\r\n0D - Tanooki Tail\r\n0E - Lucky Number 7\r\n11 - Triple Bananas\r\n12 - Triple Green Shells\r\n13 - Triple Red Shells\r\n15 - Item Box Icon\r\n16 - Checkered Flag\r\n");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.runCmd("write(0x" + commpoint + ", (0x" + textBox7.Text + ", 0x" + textBox1.Text + "), pid=0x" + textBox6.Text + "), ");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.runCmd("write(0x14144D74, (0x" + textBox11.Text + ", ), pid=0x" + textBox6.Text + "), write(0x14144D72, (0x" + textBox8.Text + ", 0x" + textBox5.Text + "), pid=0x" + textBox6.Text + "), write(0x14144D70, (0x" + textBox9.Text + ", 0x" + textBox10.Text + "), pid=0x" + textBox6.Text + ")");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int nd = (Int32.Parse(racetab, System.Globalization.NumberStyles.HexNumber));

            int nd2 = (nd + nodis);

            string nd3 = nd2.ToString("X");

            this.runCmd("write(0x" + nd3 + ", (0x02, ), pid=0x" + textBox6.Text + ")");
        }

        private void button10_Click(object sender, EventArgs e)
        {
            int nd = (Int32.Parse(racetab, System.Globalization.NumberStyles.HexNumber));

            int nd2 = (nd + laps);

            string nd3 = nd2.ToString("X");

            this.runCmd("write(0x" + nd3 + ", (0x01, ), pid=0x" + textBox6.Text + ")");
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int nd = (Int32.Parse(racetab, System.Globalization.NumberStyles.HexNumber));

            int nd2 = (nd + laps);

            string nd3 = nd2.ToString("X");

            this.runCmd("write(0x" + nd3 + ", (0x02, ), pid=0x" + textBox6.Text + ")");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            int nd = (Int32.Parse(racetab, System.Globalization.NumberStyles.HexNumber));

            int nd2 = (nd + laps);

            string nd3 = nd2.ToString("X");

            this.runCmd("write(0x" + nd3 + ", (0x03, ), pid=0x" + textBox6.Text + ")");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            int nd = (Int32.Parse(racetab, System.Globalization.NumberStyles.HexNumber));

            int nd2 = (nd + laps);

            string nd3 = nd2.ToString("X");

            this.runCmd("write(0x" + nd3 + ", (0x03, ), pid=0x" + textBox6.Text + "), write(0x" + nd3 + ", (0x00, 0x00), pid=0x" + textBox6.Text + ")");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            int nd = (Int32.Parse(racetab, System.Globalization.NumberStyles.HexNumber));

            int nd2 = (nd + coins);

            string nd3 = nd2.ToString("X");

            this.runCmd("write(0x" + nd3 + ", (0x" + textBox13.Text + ", ), pid=0x" + textBox6.Text + ")");
        }

        private void countryCodesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://3dbrew.org/wiki/Country_Code_List");
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("NTR Client for MK7 created by:\r\rHuntereb\rhttps://huntereb.xyz/\rhttps://twitter.com/Huntereb_\rhttps://www.youtube.com/c/Huntereb\r\rMrEvil\rhttps://www.youtube.com/user/MrEvil35555vr\r\rFishguy6564\rhttps://www.youtube.com/user/fishguy6564");
        }

        private void button15_Click_1(object sender, EventArgs e)
        {
            this.runCmd("write(0x1413C148, (0xFF, 0xFF, 0xFF, 0xFF), pid=0x" + textBox6.Text + "), write(0x1413C150, (0xFF, 0xFF, 0x00, 0x00), pid=0x" + textBox6.Text + "), write(0x1413C154, (0xFF, 0x00, 0x00, 0x00), pid=0x" + textBox6.Text + "), write(0x1413C158, (0xFF, 0x00, 0x00, 0x00), pid=0x" + textBox6.Text + "), write(0x1413C15C, (0xFF, 0x00, 0x09, 0x00), pid=0x" + textBox6.Text + ")");
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            string decval = Convert.ToString(numericUpDown3.Value);
            int hexval = Int32.Parse(decval);

            string hexval2 = hexval.ToString("x");
            string hexval3 = hexval2.PadLeft(6, '0');

            string input = hexval3;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                if (i % 2 == 0)
                    sb.Append(' ');
                sb.Append(input[i]);
            }
            string hexval4 = sb.ToString();

            savePart1 = (hexval4.Split(new string[] { " " }, StringSplitOptions.None))[1];
            savePart2 = (hexval4.Split(new string[] { " " }, StringSplitOptions.None))[2];
            savePart3 = (hexval4.Split(new string[] { " " }, StringSplitOptions.None))[3];
        }

        private void button16_Click(object sender, EventArgs e)
        {
            this.runCmd("write(0x1413C13C, (0x" + savePart3 + ", 0x" + savePart2 + ", 0x" + savePart1 + "), pid=0x" + textBox6.Text + ")");
        }

        private void button17_Click(object sender, EventArgs e)
        {
            this.runCmd("write(0x1413C140, (0x" + savePart3 + ", 0x" + savePart2 + ", 0x" + savePart1 + "), pid=0x" + textBox6.Text + ")");
        }
    }
}

