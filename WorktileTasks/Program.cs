using Flurl.Http;
using Newtonsoft.Json;
using System.Dynamic;
using System.Text;
using System.Windows.Forms;
using WorktileTasks;

namespace WorktileTasks
{
    public class MyObject
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }



    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            WT.project = new List<ProjectList>();
            WT.roleGroup = new List<RoleGroupList>();
            WT.projectTask = new List<TaskList>();
            WT.myTask = new List<TaskList>();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }

    public class ProjectList
    {
        public string name { get; set; }
        public string id { get; set; }
        public string identifier { get; set; }

    }

    public class RoleGroupList
    {
        public string name { get; set; }
        public string id { get; set; }

    }

    public class TaskList
    {
        public string name { get; set; }
        public string id { get; set; }
        public dynamic properties { get; set; }

    }

    public class WT
    {
        public static string baseUrl { get; set; }
        public static string username { get; set; }
        public static string password { get; set; }
        public static string userId { get; set; }
        public static string roleId { get; set; }
        public static string assigneeId { get; set; }
        public static string dueId { get; set; }
        public static string teamId { get; set; }
        public static List<ProjectList> project { get; set; }
        public static List<RoleGroupList> roleGroup { get; set; }
        public static List<TaskList> projectTask { get; set; }
        public static List<TaskList> myTask { get; set; }
        public static dynamic projectDetail { get; set; }
        public static string projectId { get; set; }
        public static string projectAllTaskId { get; set; }
        public static string projectTaskId { get; set; }
        public static string kanbanId { get; set; }
        public static string taskTitle { get; set; }
        public static string newTaskId { get; set; }
        public static string taskId { get; set; }
        public static CookieJar cookie { get; set; }
        public static DateTime cookieExpires { get; set; }
        public static int workloadDuration { get; set; } = 8;
        public static string workloadDescription { get; set; }
        public static double workloadTimestamp { get; set; }
        public static bool isCreatNewTask { get; set; } = true;
        public static string csvFile { get; set; }

    }
    public class Workload
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
    }
}