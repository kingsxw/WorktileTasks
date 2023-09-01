using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace WorktileTasks
{
    internal class Worktile
    {
        public static string GetMD5Hash(string input)
        {
            MD5 md5 = MD5.Create();
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append(data[i].ToString("x2"));
            }
            return sb.ToString();
        }
        public static string GetId(dynamic input, string keyword)
        {
            List<dynamic> _t = input;
            string id = _t.Find(t => t.name == keyword)._id;
            return id;
        }
        public static double GetTimestamp(DateTime date)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double timestamp = (long)(date.ToUniversalTime() - unixEpoch).TotalSeconds;
            return timestamp;
        }

        public static DateTime GetDate(double timestamp)
        {
            DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //unixEpoch.AddSeconds(long.Parse(timestamp + "0000000")).ToLocalTime();
            long lTime = long.Parse(timestamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return unixEpoch.Add(toNow).ToLocalTime();
            //return unixEpoch;
        }
        internal static async Task GetTeamId()
        {
            if (WT.teamId == null)
            {
                var response = await WT.baseUrl
       .AppendPathSegment("api/team/lite")
       .WithHeader("Content-Type", "application/json")
       .GetJsonAsync();
                if (response.code == 200)
                {
                    //string json = JsonConvert.SerializeObject(response);
                    //DingTalkAccessToken result = JsonConvert.DeserializeObject<DingTalkAccessToken>(json);
                    WT.teamId = response.data._id;
                }
                else
                {
                    throw new Exception($"Error getting Worktile Team Id:\n {response.code} \n{response.error_message}");
                }
            }
        }
        internal static async Task GetCookie()
        {
            await GetTeamId();
            if (WT.cookie == null || WT.cookie.Where(t => t.Expires < DateTime.Now.AddSeconds(30)).Count() != 0)
            {
                var body = new
                {
                    team_id = WT.teamId,
                    name = WT.username,
                    password = GetMD5Hash(WT.password),
                    locale = "zh-cn"
                };
                Console.WriteLine(GetMD5Hash(WT.password));
                //string json = JsonConvert.SerializeObject(body);
                try
                {
                    var response = await WT.baseUrl
               .AppendPathSegment("api/user/signin")
               .WithHeader("Content-Type", "application/json")
               .WithCookies(out var jar)
               .PostJsonAsync(body)
               .ReceiveJson();
                    WT.cookie = jar;
                    WT.userId = response.data.uid;
                }
                catch (FlurlHttpException ex)
                {
                    var error = await ex.GetResponseJsonAsync<dynamic>();
                    Console.WriteLine("pause");
                    throw new Exception($"Error returned from {ex.Call.Request.Url}: \n{error.code} \n{error.message}");
                }
            }
        }
        internal static async Task GetMyProject()
        {
            await GetCookie();
            var response = await WT.baseUrl
                .AppendPathSegment("api/mission-vnext/work/my/directed/active")
                .WithAutoRedirect(true)
                .WithHeader("Content-Type", "application/json")
                .WithCookies(WT.cookie)
                .GetJsonAsync();
            var projects = response.data.references.projects;

            if (WT.project != null)
            {
                WT.project.Clear();

            }

            foreach (var item in projects)
            {
                WT.project.Add(new ProjectList
                {
                    name = item.name,
                    id = item._id,
                    identifier = item.identifier,
                });
            }
            WT.projectId = WT.project[0].id;

            var tasks = response.data.value;

            if (WT.myTask != null)
            {

                WT.myTask.Clear();
            }

            foreach (var item in tasks)
            {
                WT.myTask.Add(new TaskList
                {
                    name = item.title,
                    id = item._id,
                    properties = item.properties
                });
            }

            WT.newTaskId = WT.myTask[0].id;

        }

        internal static async Task GetProjectDetail()
        {
            await GetCookie();
            var response = await WT.baseUrl
                .AppendPathSegment($"api/mission-vnext/projects/{WT.projectId}")
                .SetQueryParams(new
                {
                    members = "false",
                    addons = "true"
                })
                .WithAutoRedirect(true)
                .WithHeader("Content-Type", "application/json")
                .WithCookies(WT.cookie)
                .GetJsonAsync();

            //WT.projectDetail = null;
            WT.projectDetail = response.data;
            List<dynamic> _kanban = WT.projectDetail.references.addons;
            var kanban = _kanban.Find(t => t.name == "看板");
            WT.kanbanId = kanban._id;
            //List<dynamic> _views = kanban.views;
            //WT.projectAllTaskId = _views.Find(t => t.name == "全部任务")._id;
            WT.projectAllTaskId = GetId(kanban.views, "全部任务");
            Console.WriteLine("");
        }
        internal static async Task GetProjectTaskRole()
        {
            await GetCookie();
            var response = await WT.baseUrl
                .AppendPathSegment($"api/mission-vnext/kanban/{WT.kanbanId}/views/{WT.projectAllTaskId}/content")
                .WithAutoRedirect(true)
                .WithHeader("Content-Type", "application/json")
                .WithCookies(WT.cookie)
                .GetJsonAsync();

            //var task = response.data.references.task_types;
            var role = response.data.references.groups;
            if (WT.projectTask != null)
            {
                //WT.projectTask.Clear();
                WT.roleGroup.Clear();
            }

            //foreach (var item in task)
            //{
            //    WT.projectTask.Add(new TaskList
            //    {
            //        name = item.name,
            //        id = item._id,
            //        properties = item.properties
            //    });
            //}

            foreach (var item in role)
            {
                WT.roleGroup.Add(new RoleGroupList
                {
                    name = item.name,
                    id = item._id
                });
            }
            //var project = response.data.references.projects;
            //WT.projectTaskId = WT.projectTask[0].id;
            WT.roleId = WT.roleGroup[0].id;

            Console.WriteLine("");
        }

        internal static async Task GetProjectTask()
        {
            await GetCookie();
            var response = await WT.baseUrl
                .AppendPathSegment($"api/mission-vnext/kanban/{WT.kanbanId}/task-types/addable")
                .WithAutoRedirect(true)
                .WithHeader("Content-Type", "application/json")
                .WithCookies(WT.cookie)
                .GetJsonAsync();

            var task = response.data.value;
            if (WT.projectTask != null)
            {
                WT.projectTask.Clear();
            }

            foreach (var item in task)
            {
                WT.projectTask.Add(new TaskList
                {
                    name = item.name,
                    id = item._id,
                    properties = item.properties,
                });
            }
            //var project = response.data.references.projects;
            WT.projectTaskId = WT.projectTask[0].id;

            Console.WriteLine("");
        }

        internal static async Task AddNewTask()
        {
            //      var body = @"    {
            //  ""project_id"": ""5ebcfc57fe9da70032c0997a"",
            //  ""task_type_id"": ""5ebce660fe9da70032c09952"",
            //  ""properties"": [
            //    {
            //      ""property_id"": ""5e8449c61f1c4c00232b6e68"",
            //      ""value"": ""a5ebbb85c41440d58eae6ec3ac27db31""
            //    },
            //    {
            //      ""property_id"": ""5e8449c61f1c4c00232b6e69"",
            //      ""value"": {
            //        ""date"": null,
            //        ""with_time"": 0
            //      }
            //    }
            //  ],
            //  ""group_id"": ""6035c721001daf2e5b13a192"",
            //  ""title"": ""test""
            //}";


            string body = $"{{\"project_id\": \"{WT.projectId}\", \"task_type_id\": \"{WT.projectTaskId}\", \"properties\": [{{\"property_id\": \"{WT.assigneeId}\", \"value\": \"{WT.userId}\"}}, {{\"property_id\": \"{WT.dueId}\", \"value\": {{\"date\": null, \"with_time\": 0}}}}], \"group_id\": \"{WT.roleId}\", \"title\": \"{WT.taskTitle}\"}}";

            var bodyJson = JsonConvert.DeserializeObject(body);
            try
            {
                var response = await WT.baseUrl
                       .AppendPathSegment($"api/mission-vnext/kanban/{WT.kanbanId}/create/task")
                       .SetQueryParam("append", "true")
                       .WithHeader("Content-Type", "application/json")
                       .WithCookies(WT.cookie)
                       .PostJsonAsync(bodyJson)
                       .ReceiveJson();
                WT.newTaskId = response.data.value[0]._id;
                WT.taskId = WT.newTaskId;
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<dynamic>();
                Console.WriteLine("pause");
                throw new Exception($"Error returned from {ex.Call.Request.Url}: \n{error.code} \n{error.message}");
            }

            body = $"{{\"task_state_id\": \"5e8449c61f1c4c00232b6e44\"}}";
            bodyJson = JsonConvert.DeserializeObject(body);
            try
            {
                var response = await WT.baseUrl
                       .AppendPathSegment($"api/mission-vnext/tasks/{WT.newTaskId}/state")
                       .WithHeader("Content-Type", "application/json")
                       .WithCookies(WT.cookie)
                       .PutJsonAsync(bodyJson)
                       .ReceiveJson();
                //WT.cookie = jar;
                //WT.userId = response.data.uid;
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<dynamic>();
                throw new Exception($"Error returned from {ex.Call.Request.Url}: \n{error.code} \n{error.message}");
            }
        }
        internal static async Task AddWorkload()
        {
            string body = $"{{\"duration\": {WT.workloadDuration}, \"description\": \"{WT.workloadDescription}\", \"reported_at\": {WT.workloadTimestamp}}}";
            var bodyJson = JsonConvert.DeserializeObject(body);
            try
            {
                var response = await WT.baseUrl
                    .AppendPathSegment($"api/mission-vnext/tasks/{WT.taskId}/workload-entry")
                    .WithHeader("Content-Type", "application/json")
                    .WithCookies(WT.cookie)
                    .PostJsonAsync(bodyJson)
                    .ReceiveJson();
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<dynamic>();
                throw new Exception($"Error returned from {ex.Call.Request.Url}: \n{error.code} \n{error.message}");
            }
        }
    }
}

