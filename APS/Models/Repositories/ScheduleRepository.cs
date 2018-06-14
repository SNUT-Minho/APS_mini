using APS.Models.Views;
using Dapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace APS.Models.Repositories
{
    public class ScheduleRepository
    {
        static int key;
        static int n;
        static int[,] check;
        private IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        static DateTime Standard;

        public IEnumerable<Schedule> GetAllSchedule(int groupUID, DateTime s, DateTime e)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@GroupUID", groupUID);
            parameters.Add("@StartDate", s);
            parameters.Add("@EndDate", e);
            var result = db.Query<Schedule>("GetAllSchedule", parameters, commandType: CommandType.StoredProcedure);

            return result;
        }

        public void CreateSchedule(Order order, int rid, IEnumerable<Routing> node, IEnumerable<Routing> connection)
        {
            n = node.ToList().Count;
            check = new int[2, n + 1];

            double[,] path = new double[n + 1, n + 1];
            double[] processing = new double[n + 1];
            double[] setup = new double[n + 1];
            int[] cycle = new int[n + 1];

            int i = 1;
            foreach (var item in node)
            {
                path[0, i] = item.SourceWID;
                path[i, 0] = item.SourceWID;

                processing[i] = item.ProcessingTime;
                setup[i] = item.SetupTime;
                cycle[i] = item.Cycle;
                check[0, i] = item.SourceWID;
                i++;
            }

            foreach (var item in connection)
            {
                int a = 0;
                int b = 0;

                for (int k = 1; k <= n; k++)
                {
                    if (path[0, k] == item.SourceWID)
                    {
                        a = k;
                    }

                    if (path[0, k] == item.TargetWID)
                    {
                        b = k;
                    }

                    if (a != 0 && b != 0)
                    {
                        break;
                    }
                }

                if (setup[b] == 0)
                {
                    key = a;
                    path[a, b] = -99;
                }
                else
                {
                    path[a, b] = (setup[b] + (order.LotSize * processing[b]) * cycle[b]);
                }
            }

            Standard = order.EndDate.AddHours(18);
            solve(order, path, key, order.EndDate.AddHours(18));
        }

        public void solve(Order order, double[,] arr, int w, DateTime endDate)
        {
            if (arr[0, w] == -1)
            {
                return;
            }


            var count = 0;
            for (int i = 1; i <= n; i++)
            {
                if (arr[i, w] > 0)
                {
                    count++;
                }
            }
            DateTime multi = new DateTime();

            for (int i = 1; i <= n; i++)
            {

                if (arr[i, w] > 0)
                {

                    if (check[1, w] != 0)
                    {
                        solve(order, arr, i, multi);
                    }
                    else
                    {
                        check[1, w] = 1;

                        int time = (int)arr[i, w];

                        if (time % 5 == 1)
                        {
                            time += 4;
                        }
                        else if (time % 5 == 2)
                        {
                            time += 3;
                        }
                        else if (time % 5 == 3)
                        {
                            time += 2;
                        }
                        else if (time % 5 == 4)
                        {
                            time += 1;
                        }

                        int wid = (int)arr[0, w];

                        DateTime s;
                        var flag = true;
                        if (endDate.AddMinutes(-time).Hour < 8)
                        {

                            int m = endDate.AddMinutes(-time).Minute;
                            int h = endDate.AddMinutes(-time).Hour;
                            int sum = (7 - h) * 60 + (60 - m); // 그전날 저녁 6시로 이동

                            int dif = time - sum; // 해당 일자 아침 8시까지만

                            s = endDate.AddMinutes(-dif);
                            DateTime e = endDate;
                            // check before Insert // if false? -> continue;

                            // insert 
                            DynamicParameters parameters = new DynamicParameters();
                            parameters.Add("@OId", order.OId);
                            parameters.Add("@GroupUID", order.GroupUID);
                            parameters.Add("@WId", wid);
                            parameters.Add("@StartDate", s);
                            parameters.Add("@EndDate", e);
                            var result = db.Execute("CreateSchedule", parameters, commandType: CommandType.StoredProcedure);

                            Standard = Standard.AddDays(-1);
                            s = Standard.AddMinutes(-sum);
                            e = Standard;

                            // insert 
                            parameters = new DynamicParameters();
                            parameters.Add("@OId", order.OId);
                            parameters.Add("@GroupUID", order.GroupUID);
                            parameters.Add("@WId", wid);
                            parameters.Add("@StartDate", s);
                            parameters.Add("@EndDate", e);

                            result = db.Execute("CreateSchedule", parameters, commandType: CommandType.StoredProcedure);

                        }
                        else
                        {
                            s = endDate.AddMinutes(-time);
                            DateTime e = endDate;

                            while (flag)
                            {

                                // check before Insert // if false? -> continue;
                                DynamicParameters parameters = new DynamicParameters();
                                parameters.Add("@GroupUID", order.GroupUID);
                                parameters.Add("@WId", wid);
                                parameters.Add("@EndDate", e);
                                var result = db.Query<int>("CheckSchedule", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                                if (result > 0)
                                {
                                    s = s.AddMinutes(-5);
                                    e = e.AddMinutes(-5);
                                    continue;
                                }

                                // insert 
                                DynamicParameters parameter = new DynamicParameters();
                                parameter.Add("@GroupUID", order.GroupUID);
                                parameter.Add("@WId", wid);
                                parameter.Add("@StartDate", s);
                                parameter.Add("@EndDate", e);
                                parameter.Add("@OId", order.OId);
                                db.Execute("CreateSchedule", parameter, commandType: CommandType.StoredProcedure);

                                flag = false;
                            }

                        }
                        if (count > 1)
                        {
                            multi = s;
                        }
                        solve(order, arr, i, s);
                    }
                }
            }
        }
    }
}


