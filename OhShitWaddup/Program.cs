﻿using Configuration;
using Listener;
using Reddit;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace OhShitWaddup
{
    class Program
    {
        private static Lazy<HttpClient> _httpClient = new Lazy<HttpClient>(() => new HttpClient(), true);
        private static string _configurationFileName = "configurationFile.json";

        static void Main(string[] args)
        {
            Task.Run(() => Run()).Wait();
        }

        private async static Task Run()
        {
            using (var httpClient = new HttpClient())
            {
                TaskedListener taskedListener = await CreateListenerAsync();

                await taskedListener.StartAsync();

                Console.Read();
            }
        }

        private async static Task<TaskedListener> CreateListenerAsync()
        {
            Configurations configurations = await LoadConfigurationsAsync();

            CommentsRepository commentsRepository = new CommentsRepository(_httpClient.Value, new Uri(configurations.RedditApiEndpoint));
            RedditListener redditListener = new RedditListener(commentsRepository);

            return new TaskedListener(redditListener, Console.WriteLine);
        }

        private async static Task<Configurations> LoadConfigurationsAsync()
        {
            ConfigurationsLoader configurationsLoader = new ConfigurationsLoader();

            using (var streamReader = new StreamReader(_configurationFileName))
            {
                return await configurationsLoader.LoadAsync(streamReader);
            }
        }
    }
}
