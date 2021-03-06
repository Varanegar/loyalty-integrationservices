﻿using System;
using System.Net.Http;
using Quartz;
using Thinktecture.IdentityModel.Client;
using VNAppServer.Anatoli.Loyalty.DataTranster.DataTransferHandler;
using VNAppServer.Anatoli.PMC.Scheduler.Interface;

namespace VNAppServer.Anatoli.Loyalty.Scheduler
{
    public class UploadLatestDataTest : IAnatoliJob, IJob    
    {
        public void Execute(IJobExecutionContext context)
        {
            try
            {
                GetServerInfo(context.JobDetail.JobDataMap);
                log.Info("Start Transfer Data Job");
                var oauthClient = new OAuth2Client(new Uri(ServerURI + "/oauth/token"));
                var client = new HttpClient();
                client.Timeout = TimeSpan.FromMinutes(3);

                var oauthresult = oauthClient.RequestResourceOwnerPasswordAsync(GlobalValue.UserName, GlobalValue.UserPass, OwnerKey + "," + DataOwnerKey).Result; //, "foo bar"
                if (oauthresult.AccessToken != null)
                {
                    client.SetBearerToken(oauthresult.AccessToken);
                    client.Timeout = TimeSpan.FromMilliseconds(120 * 60 * 1000);

                    log.Info("Transfer test");
                    DataTestHandler.UploadDataToServer(client, ServerURI, OwnerKey, DataOwnerKey, DataOwnerKey);
                }
                else
                    log.Error("Login Failed user : "+ GlobalValue.UserName);
            }
            catch(Exception ex)
            {
                log.Error("Sync job failed ", ex);
            }
        }
    }
}
