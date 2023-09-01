using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.IO.Pipes;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WorktileTasks
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void StartProgress(int nowCount, int totalCount)
        {
            progressBar1.Visible = true;
            progressBar1.Minimum = 1;
            progressBar1.Maximum = totalCount;
            progressBar1.Value = nowCount;
            progressBar1.Step = 1;
            //progressBar1.DisplayStyle = ProgressBarDisplayText.CustomText;

            //progressBar1.Style = ProgressBarStyle.Blocks;

            progressBar1.PerformStep();
            if (nowCount == totalCount)
            {
                progressBar1.CustomText = "导入完成：" + nowCount + "/" + totalCount;
                MessageBox.Show("导入完成");
                progressBar1.Visible = false;
            }
            else
            {
                progressBar1.CustomText = "导入中：" + nowCount + "/" + totalCount;
            }
        }

        private void textBoxUrl_TextChanged(object sender, EventArgs e)
        {
            //WT.baseUrl = textBoxUrl.Text;
        }
        private void textBoxAccount_TextChanged(object sender, EventArgs e)
        {
            //WT.username = textBoxAccount.Text.Trim();
        }

        private void labelPassword_Click(object sender, EventArgs e)
        {
            //WT.password = textBoxPassword.Text;
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {

            WT.baseUrl = textBoxUrl.Text;
            WT.username = textBoxAccount.Text.Trim();
            WT.password = textBoxPassword.Text;

            if (string.IsNullOrEmpty(WT.baseUrl))
            {
                MessageBox.Show("Url不能为空！");
                return;
            }

            if (string.IsNullOrEmpty(WT.username))
            {
                MessageBox.Show("请输入用户名！");
                return;
            }
            if (string.IsNullOrEmpty(WT.password))
            {
                MessageBox.Show("请输入密码！");
                return;
            }

            await Worktile.GetMyProject();
            await Worktile.GetProjectDetail();
            wTBindingSourceProject.DataSource = WT.project;
            comboBoxProject.DataSource = wTBindingSourceProject;
            comboBoxProject.DisplayMember = "name";
            comboBoxProject.ValueMember = "id";

            wTBindingSourceMyTask.DataSource = WT.myTask;
            comboBoxMyTask.DataSource = wTBindingSourceMyTask;
            comboBoxMyTask.DisplayMember = "name";
            comboBoxMyTask.ValueMember = "id";
            comboBoxMyTask1.DataSource = wTBindingSourceMyTask;
            comboBoxMyTask1.DisplayMember = "name";
            comboBoxMyTask1.ValueMember = "id";

            await Worktile.GetProjectTask();
            wTBindingSourceTask.DataSource = WT.projectTask;
            comboBoxTaskType.DataSource = wTBindingSourceTask;
            comboBoxTaskType.DisplayMember = "name";
            comboBoxTaskType.ValueMember = "id";

            await Worktile.GetProjectTaskRole();
            wTBindingSourceRoleGroup.DataSource = WT.roleGroup;
            comboBoxRoleGroup.DataSource = wTBindingSourceRoleGroup;
            comboBoxRoleGroup.DisplayMember = "name";
            comboBoxRoleGroup.ValueMember = "id";


            richTextBoxInfo.Text = $"TeamId: {WT.teamId} \nUserId: {WT.userId} \nProjectId: {WT.projectId}";
        }

        private void richTextBoxInfo_TextChanged(object sender, EventArgs e)
        {

        }

        private async void comboBoxProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            //comboBoxProject.DataSource = WT.project;
            //comboBoxProject.DisplayMember = "name";
            //comboBoxProject.ValueMember = "_id";
            var selected = comboBoxProject.SelectedItem;
            WT.projectId = ((ProjectList)selected).id;
            await Worktile.GetProjectDetail();
            await Worktile.GetProjectTask();

        }

        private void comboBoxTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBoxTaskType.SelectedItem;
            WT.projectTaskId = ((TaskList)selected).id;
            WT.assigneeId = Worktile.GetId(((TaskList)selected).properties, "负责人");
            WT.dueId = Worktile.GetId(((TaskList)selected).properties, "截止时间");

            richTextBoxInfo.Text = $"ProjectTaskId: {WT.projectTaskId} \nProjectId: {WT.projectId}";

        }

        private async void buttonApplyTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(WT.workloadDescription))
            {
                MessageBox.Show("工时描述不能为空！");
                return;
            }

            if (radioButtonNewTask.Checked)
            {
                if (string.IsNullOrEmpty(WT.taskTitle))
                {
                    MessageBox.Show("新建任务标题不能为空！");
                    return;
                }
                await Worktile.AddNewTask();
            }

            await Worktile.AddWorkload();
            string t = ("\n" + WT.taskTitle + ", " + Worktile.GetDate(WT.workloadTimestamp).ToString("yyMMdd") + "," + WT.workloadDuration + " 导入成功");
            //MessageBox.Show(t);
            //MessageBox.Show("Pause");
            //Thread.Sleep(10000);
            richTextBoxInfo.Text += t;
        }

        private void comboBoxRoleGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBoxRoleGroup.SelectedItem;
            WT.roleId = ((RoleGroupList)selected).id;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBoxTaskTitle_TextChanged(object sender, EventArgs e)
        {
            WT.taskTitle = textBoxTaskTitle.Text;
        }

        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDownWorkloadDuration_ValueChanged(object sender, EventArgs e)
        {
            WT.workloadDuration = (int)numericUpDownWorkloadDuration.Value;
        }

        private void textBoxWorkloadDescription_TextChanged(object sender, EventArgs e)
        {
            WT.workloadDescription = textBoxWorkloadDescription.Text;
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            WT.workloadTimestamp = Worktile.GetTimestamp(monthCalendar1.SelectionStart);
        }

        private void wTBindingSourceRoleGroup_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void radioButtonExist_CheckedChanged(object sender, EventArgs e)
        {

            if (radioButtonExist.Checked)
            {
                WT.isCreatNewTask = false;
                comboBoxMyTask.Visible = true;
                textBoxTaskTitle.Visible = false;
            }
        }

        private void radioButtonNewTask_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonNewTask.Checked)
            {
                WT.isCreatNewTask = true;
                WT.taskId = WT.newTaskId;
                comboBoxMyTask.Visible = false;
                textBoxTaskTitle.Visible = true;
            }
        }

        private void comboBoxMyTask_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBoxMyTask.SelectedItem;
            WT.taskId = ((TaskList)selected).id;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void labelTaskTitle_Click(object sender, EventArgs e)
        {

        }

        private void buttonDownloadCsv_Click(object sender, EventArgs e)
        {
            DataTable dataTable = CsvCreator.createDataTable();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.DereferenceLinks = false;
            saveFileDialog1.Filter = "csv文件(*.csv)|*.csv";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.DefaultExt = "csv";
            DialogResult dr = saveFileDialog1.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                dataTable.ToCSV(filename);
                //CsvCreator.ConvertStringToUtf8Bom(filename);
                //save file using stream.
            }
        }

        private void buttonUploadCsv_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            //openFileDialog1.InitialDirectory = @"Desktop";
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            //openFileDialog1.RestoreDirectory = true;
            openFileDialog1.DereferenceLinks = false;
            openFileDialog1.Filter = "csv文件(*.csv)|*.csv";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Title = "导入工时CSV";
            openFileDialog1.DefaultExt = "csv";
            openFileDialog1.CheckFileExists = true;
            openFileDialog1.CheckPathExists = true;
            //openFileDialog1.ShowDialog();


            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                labelCsv.Text = openFileDialog1.FileName;
                labelProgress.Text = "内容预览";
                //Get the selected file path
                string filePath = openFileDialog1.FileName;

                WT.csvFile = openFileDialog1.FileName;
                // Read the contents of the file

                string fileContents = File.ReadAllText(WT.csvFile, Encoding.GetEncoding("gb2312"));

                // Do something with the file contents
                // For example, display it in a TextBox
                richTextBoxProgress.Text = fileContents;
            }

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private async void buttonImportCsv_Click(object sender, EventArgs e)
        {
            using (StreamReader reader = new StreamReader(WT.csvFile, Encoding.GetEncoding("gb2312")))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HeaderValidated = null,
                MissingFieldFound = null,
                PrepareHeaderForMatch = args => args.Header.ToLower()
            }))
            {
                int progress = 0;
                var records = csv.GetRecords<Workload>().ToList();
                int count = records.Count();


                //StartProgress(progress, count);
                richTextBoxProgress.Text = "";
                labelProgress.Text = "导入进度";
                if (radioButtonExist1.Checked)
                {
                    foreach (var record in records)
                    {
                        progress++;
                        WT.workloadDuration = (int)record.Duration;
                        WT.workloadTimestamp = Worktile.GetTimestamp(record.Date);
                        WT.workloadDescription = record.Description;
                        await Worktile.AddWorkload();
                        string t = (progress + "：" + WT.taskTitle + ", " + record.Date.ToString("yyMMdd") + "," + record.Duration + "导入成功" + "\n");
                        //MessageBox.Show(t);
                        //MessageBox.Show("Pause");
                        //Thread.Sleep(10000);
                        richTextBoxProgress.Text += t;
                        StartProgress(progress, count);
                        Thread.Sleep(100);
                    }
                }
                else
                {
                    foreach (var record in records)
                    {
                        progress++;
                        if (radioButtonNewTask1.Checked)
                        {
                            WT.taskTitle = record.Name;
                        }
                        else
                        {
                            WT.taskTitle = record.Date.ToString("yyMMdd") + "_" + record.Name;
                        }

                        WT.workloadDuration = (int)record.Duration;
                        WT.workloadTimestamp = Worktile.GetTimestamp(record.Date);
                        WT.workloadDescription = record.Description;
                        await Worktile.AddNewTask();
                        await Worktile.AddWorkload();
                        string t = (progress + "：" + WT.taskTitle + ", " + record.Date.ToString("yyMMdd") + "," + record.Duration + "导入成功" + "\n");
                        //MessageBox.Show(t);
                        //MessageBox.Show("Pause");
                        //Thread.Sleep(10000);
                        richTextBoxProgress.Text += t;
                        StartProgress(progress, count);
                        Thread.Sleep(100);
                    }
                }



                MessageBox.Show("所有工时导入成功，共计" + count.ToString() + "条");
            }
        }

        private void comboBoxMyTask1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = comboBoxMyTask1.SelectedItem;
            WT.taskId = ((TaskList)selected).id;
            WT.taskTitle = ((TaskList)selected).name;
        }

        private void labelUrl_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonExist1_CheckedChanged(object sender, EventArgs e)
        {
            var selected = comboBoxMyTask1.SelectedItem;
            WT.taskTitle = ((TaskList)selected).name;
        }

        private void radioButtonNewTask2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认退出程序?", "确认退出", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认退出程序?", "确认退出", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Environment.Exit(0);
            }
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}