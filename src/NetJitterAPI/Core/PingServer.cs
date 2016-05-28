using NetJitterAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading;
using System.Web;

namespace NetJitterAPI.Core
{
    public class PingServer
    {
        private static List<StatisticModel> statisticModelList;

        public PingServer()
        {
            statisticModelList = statisticModelList ?? new List<StatisticModel>();
        }
        public List<StatisticModel> GetStatistics()
        {
            var result = new List<StatisticModel>();

            if (statisticModelList.Count == 100)
            {
                statisticModelList.Clear();
            }

            using (var context = new LocalDatabaseEntities())
            {
                Ping ping = new Ping();
                context.SERVER.ToList().ForEach(w =>
                {
                    string addr = string.Empty;

                    if (string.IsNullOrWhiteSpace(w.NAME) && string.IsNullOrWhiteSpace(w.IP_ADDRESS))
                        throw new Exception("Server name and IP Address not found");

                    addr = string.IsNullOrWhiteSpace(w.NAME) ? w.IP_ADDRESS : w.NAME;

                    try
                    {
                        PingReply pingreply = ping.Send(addr);
                        long pingLong = pingreply.RoundtripTime;

                        var statisticModel = new StatisticModel() { Server = w, Ping = pingLong };
                        var lastServer = statisticModelList.Where(x => x.Server.ID == statisticModel.Server.ID).LastOrDefault();

                        var lastPing = lastServer == null ? 0 : lastServer.Ping;
                        statisticModel.Jitter = pingLong - lastPing < 0 ? 0 : pingLong - lastPing;
                        statisticModelList.Add(statisticModel);

                        var statisticServerQ = statisticModelList.Where(x => x.Server.ID == statisticModel.Server.ID);
                        var jitter = statisticServerQ.Select(s => s.Jitter).Sum() / statisticServerQ.Select(s => s.Jitter).Count();

                        result.Add(new StatisticModel()
                        {
                            Server = statisticModel.Server,
                            Jitter = jitter,
                            Ping = pingLong
                        });

                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                });
            }

            return result;
        }
    }
}