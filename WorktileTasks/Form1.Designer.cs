namespace WorktileTasks
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            labelUrl = new Label();
            textBoxUrl = new TextBox();
            richTextBoxInfo = new RichTextBox();
            wTBindingSourceProject = new BindingSource(components);
            wTBindingSourceRoleGroup = new BindingSource(components);
            wTBindingSourceTask = new BindingSource(components);
            wTBindingSourceMyTask = new BindingSource(components);
            comboBoxProject = new ComboBox();
            labelProjectName = new Label();
            comboBoxTaskType = new ComboBox();
            labelTaskName = new Label();
            buttonApplyTask = new Button();
            comboBoxRoleGroup = new ComboBox();
            labelRoleGroup = new Label();
            monthCalendar1 = new MonthCalendar();
            textBoxTaskTitle = new TextBox();
            labelWorkloadDuration = new Label();
            labelWorkloadDescription = new Label();
            numericUpDownWorkloadDuration = new NumericUpDown();
            textBoxWorkloadDescription = new TextBox();
            labelAccount = new Label();
            labelPassword = new Label();
            buttonLogin = new Button();
            textBoxPassword = new TextBox();
            textBoxAccount = new TextBox();
            radioButtonNewTask = new RadioButton();
            radioButtonExist = new RadioButton();
            comboBoxMyTask = new ComboBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            textBoxDeriveTaskTitle = new TextBox();
            checkBoxAsDeriveTask = new CheckBox();
            tabPage2 = new TabPage();
            textBoxDeriveTaskTitle1 = new TextBox();
            checkBoxAsDeriveTask1 = new CheckBox();
            labelProgress = new Label();
            labelCsv = new Label();
            richTextBoxProgress = new RichTextBox();
            buttonImportCsv = new Button();
            buttonUploadCsv = new Button();
            buttonDownloadCsv = new Button();
            comboBoxMyTask1 = new ComboBox();
            radioButtonExist1 = new RadioButton();
            radioButtonNewTask2 = new RadioButton();
            radioButtonNewTask1 = new RadioButton();
            progressBar1 = new CustomProgressBar();
            buttonExit = new Button();
            ((System.ComponentModel.ISupportInitialize)wTBindingSourceProject).BeginInit();
            ((System.ComponentModel.ISupportInitialize)wTBindingSourceRoleGroup).BeginInit();
            ((System.ComponentModel.ISupportInitialize)wTBindingSourceTask).BeginInit();
            ((System.ComponentModel.ISupportInitialize)wTBindingSourceMyTask).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWorkloadDuration).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            SuspendLayout();
            // 
            // labelUrl
            // 
            labelUrl.AutoSize = true;
            labelUrl.Location = new Point(32, 53);
            labelUrl.Name = "labelUrl";
            labelUrl.Size = new Size(47, 31);
            labelUrl.TabIndex = 0;
            labelUrl.Text = "Url";
            labelUrl.Click += labelUrl_Click;
            // 
            // textBoxUrl
            // 
            textBoxUrl.Location = new Point(118, 50);
            textBoxUrl.Name = "textBoxUrl";
            textBoxUrl.Size = new Size(639, 38);
            textBoxUrl.TabIndex = 1;
            textBoxUrl.Text = "https://worktile.xxx.com";
            textBoxUrl.TextChanged += textBoxUrl_TextChanged;
            // 
            // richTextBoxInfo
            // 
            richTextBoxInfo.Location = new Point(850, 36);
            richTextBoxInfo.Name = "richTextBoxInfo";
            richTextBoxInfo.Size = new Size(439, 402);
            richTextBoxInfo.TabIndex = 9;
            richTextBoxInfo.Text = "";
            richTextBoxInfo.TextChanged += richTextBoxInfo_TextChanged;
            // 
            // wTBindingSourceRoleGroup
            // 
            wTBindingSourceRoleGroup.CurrentChanged += wTBindingSourceRoleGroup_CurrentChanged;
            // 
            // comboBoxProject
            // 
            comboBoxProject.DisplayMember = "name";
            comboBoxProject.FormattingEnabled = true;
            comboBoxProject.Location = new Point(515, 135);
            comboBoxProject.Name = "comboBoxProject";
            comboBoxProject.Size = new Size(242, 39);
            comboBoxProject.TabIndex = 10;
            comboBoxProject.ValueMember = "id";
            comboBoxProject.SelectedIndexChanged += comboBoxProject_SelectedIndexChanged;
            // 
            // labelProjectName
            // 
            labelProjectName.AutoSize = true;
            labelProjectName.Location = new Point(428, 138);
            labelProjectName.Name = "labelProjectName";
            labelProjectName.Size = new Size(62, 31);
            labelProjectName.TabIndex = 11;
            labelProjectName.Text = "项目";
            // 
            // comboBoxTaskType
            // 
            comboBoxTaskType.FormattingEnabled = true;
            comboBoxTaskType.Location = new Point(515, 234);
            comboBoxTaskType.Name = "comboBoxTaskType";
            comboBoxTaskType.Size = new Size(242, 39);
            comboBoxTaskType.TabIndex = 12;
            comboBoxTaskType.SelectedIndexChanged += comboBoxTask_SelectedIndexChanged;
            // 
            // labelTaskName
            // 
            labelTaskName.AutoSize = true;
            labelTaskName.Location = new Point(428, 242);
            labelTaskName.Name = "labelTaskName";
            labelTaskName.Size = new Size(62, 31);
            labelTaskName.TabIndex = 13;
            labelTaskName.Text = "任务";
            // 
            // buttonApplyTask
            // 
            buttonApplyTask.Location = new Point(611, 49);
            buttonApplyTask.Name = "buttonApplyTask";
            buttonApplyTask.Size = new Size(488, 111);
            buttonApplyTask.TabIndex = 14;
            buttonApplyTask.Text = "提交";
            buttonApplyTask.UseVisualStyleBackColor = true;
            buttonApplyTask.Click += buttonApplyTask_Click;
            // 
            // comboBoxRoleGroup
            // 
            comboBoxRoleGroup.FormattingEnabled = true;
            comboBoxRoleGroup.Location = new Point(515, 337);
            comboBoxRoleGroup.Name = "comboBoxRoleGroup";
            comboBoxRoleGroup.Size = new Size(242, 39);
            comboBoxRoleGroup.TabIndex = 15;
            comboBoxRoleGroup.SelectedIndexChanged += comboBoxRoleGroup_SelectedIndexChanged;
            // 
            // labelRoleGroup
            // 
            labelRoleGroup.AutoSize = true;
            labelRoleGroup.Location = new Point(428, 340);
            labelRoleGroup.Name = "labelRoleGroup";
            labelRoleGroup.Size = new Size(62, 31);
            labelRoleGroup.TabIndex = 16;
            labelRoleGroup.Text = "角色";
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(27, 315);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 17;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // textBoxTaskTitle
            // 
            textBoxTaskTitle.Location = new Point(170, 47);
            textBoxTaskTitle.Name = "textBoxTaskTitle";
            textBoxTaskTitle.Size = new Size(247, 38);
            textBoxTaskTitle.TabIndex = 19;
            textBoxTaskTitle.TextChanged += textBoxTaskTitle_TextChanged;
            // 
            // labelWorkloadDuration
            // 
            labelWorkloadDuration.AutoSize = true;
            labelWorkloadDuration.Location = new Point(38, 231);
            labelWorkloadDuration.Name = "labelWorkloadDuration";
            labelWorkloadDuration.Size = new Size(110, 31);
            labelWorkloadDuration.TabIndex = 20;
            labelWorkloadDuration.Text = "工时时长";
            // 
            // labelWorkloadDescription
            // 
            labelWorkloadDescription.AutoSize = true;
            labelWorkloadDescription.Location = new Point(496, 191);
            labelWorkloadDescription.Name = "labelWorkloadDescription";
            labelWorkloadDescription.Size = new Size(134, 31);
            labelWorkloadDescription.TabIndex = 21;
            labelWorkloadDescription.Text = "工时描述：";
            // 
            // numericUpDownWorkloadDuration
            // 
            numericUpDownWorkloadDuration.Location = new Point(170, 229);
            numericUpDownWorkloadDuration.Maximum = new decimal(new int[] { 24, 0, 0, 0 });
            numericUpDownWorkloadDuration.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownWorkloadDuration.Name = "numericUpDownWorkloadDuration";
            numericUpDownWorkloadDuration.Size = new Size(247, 38);
            numericUpDownWorkloadDuration.TabIndex = 22;
            numericUpDownWorkloadDuration.Value = new decimal(new int[] { 8, 0, 0, 0 });
            numericUpDownWorkloadDuration.ValueChanged += numericUpDownWorkloadDuration_ValueChanged;
            // 
            // textBoxWorkloadDescription
            // 
            textBoxWorkloadDescription.AcceptsReturn = true;
            textBoxWorkloadDescription.AllowDrop = true;
            textBoxWorkloadDescription.Location = new Point(496, 234);
            textBoxWorkloadDescription.Multiline = true;
            textBoxWorkloadDescription.Name = "textBoxWorkloadDescription";
            textBoxWorkloadDescription.Size = new Size(736, 416);
            textBoxWorkloadDescription.TabIndex = 23;
            textBoxWorkloadDescription.TextChanged += textBoxWorkloadDescription_TextChanged;
            // 
            // labelAccount
            // 
            labelAccount.AutoSize = true;
            labelAccount.Location = new Point(32, 138);
            labelAccount.Name = "labelAccount";
            labelAccount.Size = new Size(62, 31);
            labelAccount.TabIndex = 2;
            labelAccount.Text = "账号";
            // 
            // labelPassword
            // 
            labelPassword.AutoSize = true;
            labelPassword.Location = new Point(32, 237);
            labelPassword.Name = "labelPassword";
            labelPassword.Size = new Size(62, 31);
            labelPassword.TabIndex = 3;
            labelPassword.Text = "密码";
            labelPassword.Click += labelPassword_Click;
            // 
            // buttonLogin
            // 
            buttonLogin.BackColor = Color.FromArgb(128, 255, 128);
            buttonLogin.Location = new Point(48, 311);
            buttonLogin.Name = "buttonLogin";
            buttonLogin.Size = new Size(270, 60);
            buttonLogin.TabIndex = 8;
            buttonLogin.Text = "登录";
            buttonLogin.UseVisualStyleBackColor = false;
            buttonLogin.Click += buttonLogin_Click;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(118, 234);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '*';
            textBoxPassword.Size = new Size(200, 38);
            textBoxPassword.TabIndex = 5;
            textBoxPassword.TextChanged += textBoxPassword_TextChanged;
            // 
            // textBoxAccount
            // 
            textBoxAccount.Location = new Point(118, 138);
            textBoxAccount.Name = "textBoxAccount";
            textBoxAccount.Size = new Size(200, 38);
            textBoxAccount.TabIndex = 4;
            textBoxAccount.TextChanged += textBoxAccount_TextChanged;
            // 
            // radioButtonNewTask
            // 
            radioButtonNewTask.AutoSize = true;
            radioButtonNewTask.Checked = true;
            radioButtonNewTask.Location = new Point(23, 48);
            radioButtonNewTask.Name = "radioButtonNewTask";
            radioButtonNewTask.Size = new Size(141, 35);
            radioButtonNewTask.TabIndex = 24;
            radioButtonNewTask.TabStop = true;
            radioButtonNewTask.Text = "新建任务";
            radioButtonNewTask.UseVisualStyleBackColor = true;
            radioButtonNewTask.CheckedChanged += radioButtonNewTask_CheckedChanged;
            // 
            // radioButtonExist
            // 
            radioButtonExist.AutoSize = true;
            radioButtonExist.Location = new Point(23, 138);
            radioButtonExist.Name = "radioButtonExist";
            radioButtonExist.Size = new Size(141, 35);
            radioButtonExist.TabIndex = 25;
            radioButtonExist.Text = "现有任务";
            radioButtonExist.UseVisualStyleBackColor = true;
            radioButtonExist.CheckedChanged += radioButtonExist_CheckedChanged;
            // 
            // comboBoxMyTask
            // 
            comboBoxMyTask.Enabled = false;
            comboBoxMyTask.FormattingEnabled = true;
            comboBoxMyTask.Location = new Point(170, 138);
            comboBoxMyTask.Name = "comboBoxMyTask";
            comboBoxMyTask.Size = new Size(247, 39);
            comboBoxMyTask.TabIndex = 26;
            comboBoxMyTask.SelectedIndexChanged += comboBoxMyTask_SelectedIndexChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            tabControl1.Location = new Point(12, 488);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1285, 739);
            tabControl1.SizeMode = TabSizeMode.Fixed;
            tabControl1.TabIndex = 27;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.Transparent;
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(textBoxDeriveTaskTitle);
            tabPage1.Controls.Add(checkBoxAsDeriveTask);
            tabPage1.Controls.Add(comboBoxMyTask);
            tabPage1.Controls.Add(radioButtonExist);
            tabPage1.Controls.Add(textBoxTaskTitle);
            tabPage1.Controls.Add(radioButtonNewTask);
            tabPage1.Controls.Add(numericUpDownWorkloadDuration);
            tabPage1.Controls.Add(textBoxWorkloadDescription);
            tabPage1.Controls.Add(labelWorkloadDescription);
            tabPage1.Controls.Add(monthCalendar1);
            tabPage1.Controls.Add(buttonApplyTask);
            tabPage1.Controls.Add(labelWorkloadDuration);
            tabPage1.Location = new Point(8, 45);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1269, 686);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "手动添加";
            tabPage1.Click += tabPage1_Click;
            // 
            // textBoxDeriveTaskTitle
            // 
            textBoxDeriveTaskTitle.BackColor = SystemColors.Window;
            textBoxDeriveTaskTitle.Enabled = false;
            textBoxDeriveTaskTitle.Location = new Point(268, 180);
            textBoxDeriveTaskTitle.Name = "textBoxDeriveTaskTitle";
            textBoxDeriveTaskTitle.Size = new Size(200, 38);
            textBoxDeriveTaskTitle.TabIndex = 28;
            // 
            // checkBoxAsDeriveTask
            // 
            checkBoxAsDeriveTask.AutoSize = true;
            checkBoxAsDeriveTask.Enabled = false;
            checkBoxAsDeriveTask.Location = new Point(58, 179);
            checkBoxAsDeriveTask.Name = "checkBoxAsDeriveTask";
            checkBoxAsDeriveTask.Size = new Size(214, 35);
            checkBoxAsDeriveTask.TabIndex = 27;
            checkBoxAsDeriveTask.Text = "作为子任务添加";
            checkBoxAsDeriveTask.UseVisualStyleBackColor = true;
            checkBoxAsDeriveTask.CheckedChanged += checkBoxAsDeriveTask_CheckedChanged;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Transparent;
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Controls.Add(textBoxDeriveTaskTitle1);
            tabPage2.Controls.Add(checkBoxAsDeriveTask1);
            tabPage2.Controls.Add(labelProgress);
            tabPage2.Controls.Add(labelCsv);
            tabPage2.Controls.Add(richTextBoxProgress);
            tabPage2.Controls.Add(buttonImportCsv);
            tabPage2.Controls.Add(buttonUploadCsv);
            tabPage2.Controls.Add(buttonDownloadCsv);
            tabPage2.Controls.Add(comboBoxMyTask1);
            tabPage2.Controls.Add(radioButtonExist1);
            tabPage2.Controls.Add(radioButtonNewTask2);
            tabPage2.Controls.Add(radioButtonNewTask1);
            tabPage2.Controls.Add(progressBar1);
            tabPage2.Location = new Point(8, 45);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1269, 686);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "批量添加";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // textBoxDeriveTaskTitle1
            // 
            textBoxDeriveTaskTitle1.Enabled = false;
            textBoxDeriveTaskTitle1.Location = new Point(270, 104);
            textBoxDeriveTaskTitle1.Name = "textBoxDeriveTaskTitle1";
            textBoxDeriveTaskTitle1.Size = new Size(200, 38);
            textBoxDeriveTaskTitle1.TabIndex = 18;
            // 
            // checkBoxAsDeriveTask1
            // 
            checkBoxAsDeriveTask1.AutoSize = true;
            checkBoxAsDeriveTask1.Enabled = false;
            checkBoxAsDeriveTask1.Location = new Point(50, 107);
            checkBoxAsDeriveTask1.Name = "checkBoxAsDeriveTask1";
            checkBoxAsDeriveTask1.Size = new Size(214, 35);
            checkBoxAsDeriveTask1.TabIndex = 17;
            checkBoxAsDeriveTask1.Text = "作为子任务添加";
            checkBoxAsDeriveTask1.UseVisualStyleBackColor = true;
            checkBoxAsDeriveTask1.CheckedChanged += checkBoxAsDeriveTask1_CheckedChanged;
            // 
            // labelProgress
            // 
            labelProgress.AutoSize = true;
            labelProgress.Location = new Point(525, 25);
            labelProgress.Name = "labelProgress";
            labelProgress.Size = new Size(86, 31);
            labelProgress.TabIndex = 11;
            labelProgress.Text = "状态栏";
            // 
            // labelCsv
            // 
            labelCsv.AutoSize = true;
            labelCsv.Location = new Point(28, 592);
            labelCsv.Name = "labelCsv";
            labelCsv.Size = new Size(0, 31);
            labelCsv.TabIndex = 9;
            // 
            // richTextBoxProgress
            // 
            richTextBoxProgress.Location = new Point(523, 73);
            richTextBoxProgress.Name = "richTextBoxProgress";
            richTextBoxProgress.Size = new Size(717, 516);
            richTextBoxProgress.TabIndex = 8;
            richTextBoxProgress.Text = "";
            // 
            // buttonImportCsv
            // 
            buttonImportCsv.Location = new Point(293, 357);
            buttonImportCsv.Name = "buttonImportCsv";
            buttonImportCsv.Size = new Size(150, 232);
            buttonImportCsv.TabIndex = 7;
            buttonImportCsv.Text = "导入";
            buttonImportCsv.UseVisualStyleBackColor = true;
            buttonImportCsv.Click += buttonImportCsv_Click;
            // 
            // buttonUploadCsv
            // 
            buttonUploadCsv.Location = new Point(28, 499);
            buttonUploadCsv.Name = "buttonUploadCsv";
            buttonUploadCsv.Size = new Size(198, 90);
            buttonUploadCsv.TabIndex = 6;
            buttonUploadCsv.Text = "选择工时csv";
            buttonUploadCsv.UseVisualStyleBackColor = true;
            buttonUploadCsv.Click += buttonUploadCsv_Click;
            // 
            // buttonDownloadCsv
            // 
            buttonDownloadCsv.Location = new Point(28, 357);
            buttonDownloadCsv.Name = "buttonDownloadCsv";
            buttonDownloadCsv.Size = new Size(198, 98);
            buttonDownloadCsv.TabIndex = 5;
            buttonDownloadCsv.Text = "下载csv模板";
            buttonDownloadCsv.UseVisualStyleBackColor = true;
            buttonDownloadCsv.Click += buttonDownloadCsv_Click;
            // 
            // comboBoxMyTask1
            // 
            comboBoxMyTask1.Enabled = false;
            comboBoxMyTask1.FormattingEnabled = true;
            comboBoxMyTask1.Location = new Point(174, 59);
            comboBoxMyTask1.Name = "comboBoxMyTask1";
            comboBoxMyTask1.Size = new Size(242, 39);
            comboBoxMyTask1.TabIndex = 4;
            comboBoxMyTask1.SelectedIndexChanged += comboBoxMyTask1_SelectedIndexChanged;
            // 
            // radioButtonExist1
            // 
            radioButtonExist1.AutoSize = true;
            radioButtonExist1.Location = new Point(23, 59);
            radioButtonExist1.Name = "radioButtonExist1";
            radioButtonExist1.Size = new Size(141, 35);
            radioButtonExist1.TabIndex = 3;
            radioButtonExist1.Text = "现有任务";
            radioButtonExist1.UseVisualStyleBackColor = true;
            radioButtonExist1.CheckedChanged += radioButtonExist1_CheckedChanged;
            // 
            // radioButtonNewTask2
            // 
            radioButtonNewTask2.AutoSize = true;
            radioButtonNewTask2.Checked = true;
            radioButtonNewTask2.Location = new Point(23, 247);
            radioButtonNewTask2.Name = "radioButtonNewTask2";
            radioButtonNewTask2.Size = new Size(393, 35);
            radioButtonNewTask2.TabIndex = 2;
            radioButtonNewTask2.TabStop = true;
            radioButtonNewTask2.Text = "新建任务，标题=日期+任务名称";
            radioButtonNewTask2.UseVisualStyleBackColor = true;
            radioButtonNewTask2.CheckedChanged += radioButtonNewTask2_CheckedChanged;
            // 
            // radioButtonNewTask1
            // 
            radioButtonNewTask1.AutoSize = true;
            radioButtonNewTask1.Location = new Point(23, 161);
            radioButtonNewTask1.Name = "radioButtonNewTask1";
            radioButtonNewTask1.Size = new Size(327, 35);
            radioButtonNewTask1.TabIndex = 1;
            radioButtonNewTask1.Text = "新建任务，标题=任务名称";
            radioButtonNewTask1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            progressBar1.AccessibleDescription = "";
            progressBar1.AccessibleName = "";
            progressBar1.CustomText = null;
            progressBar1.DisplayStyle = ProgressBarDisplayText.CustomText;
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(3, 645);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1261, 36);
            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.TabIndex = 16;
            progressBar1.Visible = false;
            progressBar1.Click += progressBar1_Click;
            // 
            // buttonExit
            // 
            buttonExit.BackColor = Color.FromArgb(255, 128, 128);
            buttonExit.Location = new Point(48, 396);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(270, 60);
            buttonExit.TabIndex = 28;
            buttonExit.Text = "退出";
            buttonExit.UseVisualStyleBackColor = false;
            buttonExit.Click += buttonExit_Click;
            // 
            // Form1
            // 
            AcceptButton = buttonLogin;
            AutoScaleDimensions = new SizeF(14F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = buttonExit;
            ClientSize = new Size(1310, 1221);
            Controls.Add(buttonExit);
            Controls.Add(tabControl1);
            Controls.Add(labelRoleGroup);
            Controls.Add(comboBoxRoleGroup);
            Controls.Add(labelTaskName);
            Controls.Add(comboBoxTaskType);
            Controls.Add(labelProjectName);
            Controls.Add(comboBoxProject);
            Controls.Add(richTextBoxInfo);
            Controls.Add(buttonLogin);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxAccount);
            Controls.Add(labelPassword);
            Controls.Add(labelAccount);
            Controls.Add(textBoxUrl);
            Controls.Add(labelUrl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "Worktile工时导入 v0.9.9_20230905_RC";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)wTBindingSourceProject).EndInit();
            ((System.ComponentModel.ISupportInitialize)wTBindingSourceRoleGroup).EndInit();
            ((System.ComponentModel.ISupportInitialize)wTBindingSourceTask).EndInit();
            ((System.ComponentModel.ISupportInitialize)wTBindingSourceMyTask).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownWorkloadDuration).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelUrl;
        private TextBox textBoxUrl;
        private RichTextBox richTextBoxInfo;
        private BindingSource wTBindingSourceProject;
        private BindingSource wTBindingSourceRoleGroup;
        private BindingSource wTBindingSourceTask;
        private BindingSource wTBindingSourceMyTask;
        private ComboBox comboBoxProject;
        private Label labelProjectName;
        private ComboBox comboBoxTaskType;
        private Label labelTaskName;
        private Button buttonApplyTask;
        private ComboBox comboBoxRoleGroup;
        private Label labelRoleGroup;
        private MonthCalendar monthCalendar1;
        private TextBox textBoxTaskTitle;
        private Label labelWorkloadDuration;
        private Label labelWorkloadDescription;
        private NumericUpDown numericUpDownWorkloadDuration;
        private TextBox textBoxWorkloadDescription;
        private Label labelAccount;
        private Label labelPassword;
        private Button buttonLogin;
        private TextBox textBoxPassword;
        private TextBox textBoxAccount;
        private RadioButton radioButtonNewTask;
        private RadioButton radioButtonExist;
        private ComboBox comboBoxTaskList;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private ComboBox comboBoxMyTask;
        private RadioButton radioButtonNewTask2;
        private RadioButton radioButtonNewTask1;
        private Button buttonDownloadCsv;
        private ComboBox comboBoxMyTask1;
        private RadioButton radioButtonExist1;
        private Button buttonImportCsv;
        private Button buttonUploadCsv;
        private RichTextBox richTextBoxProgress;
        private Label labelCsv;
        private CustomProgressBar progressBar1;
        private Label labelProgress;
        private Button buttonExit;
        private CheckBox checkBoxAsDeriveTask;
        private TextBox textBoxDeriveTaskTitle;
        private TextBox textBoxDeriveTaskTitle1;
        private CheckBox checkBoxAsDeriveTask1;
    }
}
