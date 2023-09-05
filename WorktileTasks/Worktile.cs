using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WorktileTasks
{
    internal class Worktile
    {
        public static string GetMD5Hash(string input)
        {
            byte[] data = MD5.HashData(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new();
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
            DateTime unixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            double timestamp = (long)(date.ToUniversalTime() - unixEpoch).TotalSeconds;
            return timestamp;
        }

        public static DateTime GetDate(double timestamp)
        {
            DateTime unixEpoch = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            //unixEpoch.AddSeconds(long.Parse(timestamp + "0000000")).ToLocalTime();
            long lTime = long.Parse(timestamp + "0000000");
            TimeSpan toNow = new(lTime);
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
            if (WT.cookie == null || WT.cookie.Where(t => t.Expires < DateTime.Now.AddSeconds(30)).Any())
            {
                var body = new
                {
                    team_id = WT.teamId,
                    name = WT.username,
                    password = GetMD5Hash(WT.password),
                    locale = "zh-cn"
                };
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

            WT.project?.Clear();

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

            WT.myTask?.Clear();

            foreach (var item in tasks)
            {
                if (!((IDictionary<string, object>)item).ContainsKey("parent_id"))
                {
                    WT.myTask.Add(new TaskList
                    {
                        name = item.title,
                        id = item._id,
                        projectid = item.project_id,
                        typeid = item.task_type_id,
                        deriveid = await GetProjectTaskStatusId(item._id, "子任务"),
                        properties = item.properties
                    });
                }
                //WT.projectDeriveTaskTypeId = WT.projectTask[0].deriveid;

            }

            WT.projectDeriveTaskTypeId = WT.myTask[0].deriveid;
            WT.projectTaskTypeId = WT.myTask[0].typeid;
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
            WT.projectAllTaskId = GetId(kanban.views, "全部任务");

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
            WT.projectTask?.Clear();

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
            WT.projectTask?.Clear();

            foreach (var item in task)
            {
                WT.projectTask.Add(new TaskList
                {
                    name = item.name,
                    id = item._id,
                    //deriveid = await GetProjectTaskStatusId("子任务"),
                    properties = item.properties,
                });
            }
            //var project = response.data.references.projects;
            //WT.projectTaskTypeId = WT.projectTask[0].id;
            //WT.projectDeriveTaskTypeId = WT.projectTask[0].deriveid;
        }

        internal static async Task<string> GetProjectTaskStatusId(string task, string keyword)
        {
            await GetCookie();
            var response = await WT.baseUrl
                .AppendPathSegment($"api/mission-vnext/tasks/{task}")
                .WithAutoRedirect(true)
                .WithHeader("Content-Type", "application/json")
                .WithCookies(WT.cookie)
                .GetJsonAsync();
            return GetId(response.data.value.relations, keyword);
        }

        internal static async Task AddTask()
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


            string body = $"{{\"project_id\": \"{WT.projectId}\", \"task_type_id\": \"{WT.projectTaskTypeId}\", \"properties\": [{{\"property_id\": \"{WT.assigneeId}\", \"value\": \"{WT.userId}\"}}, {{\"property_id\": \"{WT.dueId}\", \"value\": {{\"date\": null, \"with_time\": 0}}}}], \"group_id\": \"{WT.roleId}\", \"title\": \"{WT.taskTitle}\"}}";

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

            await SetTaskState();
        }

        internal static async Task SetTaskState()
        {
            string body = $"{{\"task_state_id\": \"5e8449c61f1c4c00232b6e44\"}}";
            var bodyJson = JsonConvert.DeserializeObject(body);
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
        internal static async Task AddDeriveTask()
        {
            //string body = $"{{\"project_id\": \"{WT.projectId}\", \"task_type_id\": \"{WT.projectTaskId}\", \"properties\": [{{\"property_id\": \"{WT.assigneeId}\", \"value\": \"{WT.userId}\"}}, {{\"property_id\": \"{WT.dueId}\", \"value\": {{\"date\": null, \"with_time\": 0}}}}], \"group_id\": \"{WT.roleId}\", \"title\": \"{WT.taskTitle}\"}}";

            //string body = "{\"title\":\"tttttttttttttttttt\",\"project_id\":\"5ebcfc57fe9da70032c0997a\",\"task_type_id\":\"5ebce660fe9da70032c09952\",\"parent\":\"64f18f07eeec4d3959badc9a\",\"properties\":[{\"property_id\":\"5e8449c61f1c4c00232b6e69\",\"value\":{\"date\":1696064574,\"with_time\":false}},{\"property_id\":\"5e8449c61f1c4c00232b6e68\",\"value\":\"a5ebbb85c41440d58eae6ec3ac27db31\"}],\"relation\":{\"associate_task_id\":\"64f18f07eeec4d3959badc9a\",\"relation_id\":\"5ebce660fe9da70032c09953\"}}";
            string body = $"{{\r\n    \"title\": \"{WT.taskTitle}\",\r\n    \"project_id\": \"{WT.projectId}\",\r\n    \"task_type_id\": \"{WT.projectTaskTypeId}\",\r\n    \"parent\": \"{WT.taskId}\",\r\n    \"properties\": [\r\n        {{\r\n            \"property_id\": \"{WT.dueId}\",\r\n            \"value\": {{\r\n                \"date\": \"{WT.workloadTimestamp}\",\r\n                \"with_time\": false\r\n            }}\r\n        }},\r\n        {{\r\n            \"property_id\": \"{WT.assigneeId}\",\r\n            \"value\": \"{WT.userId}\"\r\n        }}\r\n    ],\r\n    \"relation\": {{\r\n        \"associate_task_id\": \"{WT.taskId}\",\r\n        \"relation_id\": \"{WT.projectDeriveTaskTypeId}\"\r\n    }}\r\n}}";
            //MessageBox.Show(body);
            //string body = $"{{\"title\":\"{WT.taskTitle}\",\"project_id\":\"{WT.projectId}\",\"task_type_id\":\"{WT.projectTaskTypeId}\",\"parent\":\"{WT.taskId}\",\"properties\":[{{\"property_id\":\"{WT.dueId}\",\"value\":{{\"date\":\"{WT.workloadTimestamp}\",\"with_time\":false}},{{\"property_id\":\"{WT.assigneeId}\",\"value\":\"{WT.userId}\"}}],\"relation\":{{\"associate_task_id\":\"{WT.taskId}\",\"relation_id\":\"{WT.projectDeriveTaskTypeId}\"}}";
            var bodyJson = JsonConvert.DeserializeObject(body);
            try
            {
                var response = await WT.baseUrl
                       .AppendPathSegment("api/mission-vnext/derive-task")
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
            await SetTaskState();
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

