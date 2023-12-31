﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using static ValorantNET.Enums;

namespace ValorantNET.Test
{
    class Program
    {
        private static ValorantClient ValorantClient;
        private static string username = "Teo230";
        private static string tag = "EUW";
        private static string matchId = "16580950-58f8-4eac-9642-a04468fa94c9";
        private static Regions region = Regions.AP;

        static void Main(string[] args)
        {
            ValorantClient = new ValorantClient(username,tag,region);
            //GetStatsV2();
            //GetMatches();
            //GetMatcheInfo();
            GetPUUID();
            //GetLeaderboard();
            //GetPlayerStatus();
            Console.ReadKey();
        }

        private static void GetStats()
        {
            var task = new Task(async () =>
            {
                var result = await ValorantClient.GetStatsAsync();
                if (result != null)
                    ShowProp(result);
            });
            task.Start();
        }

        private static void GetStatsV2()
        {
            var task = new Task(async () =>
            {
                var result = await ValorantClient.GetStatsAsync();
                if (result != null)
                    ShowProp(result);
            });
            task.Start();
        }

        private static void GetMatches()
        {
            var task = new Task(async () =>
            {
                var result = await ValorantClient.GetMatchesAsync();
                if(result != null)
                    ShowProp(result);
            });
            task.Start();
        }

        private static void GetMatcheInfo()
        {
            var task = new Task(async () =>
            {
                var result = await ValorantClient.GetMatchInfoAsync(matchId);
                if (result != null)
                    ShowProp(result);
            });
            task.Start();
        }

        private static void GetPUUID()
        {
            var task = new Task(async () =>
            {
                var result = await ValorantClient.GetPUUIDAsync();
                if (result != null)
                    ShowProp(result.data.puuid);
            });
            task.Start();
        }

        private static void GetLeaderboard()
        {
            var task = new Task(async () =>
            {
                var result = await ValorantClient.GetLeaderboardAsync();
                if (result != null)
                    ShowProp(result);
            });
            task.Start();
        }

        private static void GetPlayerStatus()
        {
            var task = new Task(async () =>
            {
                var result = await ValorantClient.GetPlayerMatchStatusAsync();
                if (result != null)
                    ShowProp(result);
            });
            task.Start();
        }

        private static void ShowProp(object obj)
        {
            foreach (var p in obj.GetType().GetProperties().Where(p => !p.GetGetMethod().GetParameters().Any()))
            {
                Console.WriteLine(p.GetValue(obj, null));
            }
        }
    }
}
