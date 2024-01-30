using System;
using System.Collections;
using System.Diagnostics;
using ABI_RC.Core.UI;
using HarmonyLib;
using MelonLoader;
using UnityEngine;

namespace CVRHudUtils
{
    public static class BuildInfo
    {
        public const string Name = "CVRHudUtils"; 
        public const string Description = null; 
        public const string Author = "Swordsith"; 
        public const string Company = null; 
        public const string Version = "1.0.0";
        public const string DownloadLink = null; 
    }

    #region MelonMod
    public class CVRHudUtils : MelonMod
    {
        public override void OnApplicationStart()
        {
            Instance.PatchAll();
            SpotifyTitleGrabber.Start();
            TimeUtils.Start();
        }
        public override void OnApplicationQuit()
        {
            Instance.UnpatchSelf();
        }

        public static HarmonyLib.Harmony Instance = new HarmonyLib.Harmony("CVRHudUtils");
    }
    #endregion

    #region PatchHud
        [HarmonyPatch(typeof(ABI_RC.Core.UI.CohtmlHud), nameof(ABI_RC.Core.UI.CohtmlHud.Instance.ViewDropTextImmediate))]
        public static class SkeletalTextBlock
        { 
            static bool Prefix(string __0, string __1, string __2) { if (__1 == "Skeletal Input changed ") {  return false; } else { return true; } } //skips skeletal input changed popup with index controllers
        }

        [HarmonyPatch(typeof(ABI_RC.Core.UI.CohtmlHud), nameof(ABI_RC.Core.UI.CohtmlHud.Instance.ViewDropText), new Type[] { typeof(string), typeof(string) })]
        public static class RightHudPatch
        {
            static bool Prefix(string __0, string __1) { if (__0 == "Switch Flight Mode" || __0 == "Prop was blocked by the content filter System") { return false; } else { return true; } }
        }
    #endregion

    #region SpotifyTitleAlert
        public static class SpotifyTitleGrabber
        {
        public static string CurrentSong;
        public static string WindowTitle;
        public static string LastSong;
        public static void Start() { MelonCoroutines.Start(SpotifyUpdate()); }
        public static IEnumerator SpotifyUpdate()
        {

            while (true)
            {
                try
                {
                    CurrentSong = GrabWindowTitle("Spotify"); //detects open but not playing
                    if (CurrentSong != null && CurrentSong != "Spotify" && CurrentSong != "Spotify Premium")//detects song name
                    {
                        string[] SPLIT = CurrentSong.Split('-'); string Artist = SPLIT[0]; string Song = SPLIT[1];
                        if (LastSong == CurrentSong) { goto Skip; } LastSong = CurrentSong;
                        CohtmlHud.Instance.ViewDropTextImmediate("[SpotifyUtils]", $"{Song}", $"{Artist}");
                        Skip:;
                    }
                }
                catch { }
                yield return new WaitForSeconds(4f);
            }
        }
        public static string GrabWindowTitle(string processname) //grabs any window name used for spotify song name
        {
            Process[] processe = Process.GetProcessesByName(processname);
            foreach (Process process in processe)
            {
                if (!string.IsNullOrEmpty(process.MainWindowTitle)) { WindowTitle = process.MainWindowTitle; }
            }
            return WindowTitle;
        }
    }
    #endregion

    #region TimeUtils
    public static class TimeUtils
    {
        string previoustime;
        public static string CurrentTime;
        public static void Start() { MelonCoroutines.Start(TimeAlert()); }
        public static IEnumerator TimeAlert()
        {
            while (true)
            {
                CurrentTime = DateTime.Now.ToString("HH:mm");

                switch (CurrentTime > previoustime)
                {
                    case false: yield return new WaitForSeconds(50f); break;
                    case true: previoustime = CurrentTime; break;
                }

                switch (CurrentTime)
                {
                    case "04:20": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "YEET"); yield return new WaitForSeconds(50f); break;
                    case "00:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "01:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "02:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "03:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "04:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "05:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "06:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "07:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "08:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "09:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "10:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "11:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "AM"); yield return new WaitForSeconds(50f); break;
                    case "12:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", $"{CurrentTime}", "PM"); yield return new WaitForSeconds(50f); break;

                    case "13:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "1:00",  "PM"); yield return new WaitForSeconds(50f); break;
                    case "14:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "2:00",  "PM"); yield return new WaitForSeconds(50f); break;
                    case "15:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "3:00",  "PM"); yield return new WaitForSeconds(50f); break;
                    case "16:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "4:00",  "PM"); yield return new WaitForSeconds(50f); break;
                    case "17:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "5:00",  "PM"); yield return new WaitForSeconds(50f); break;
                    case "18:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "6:00",  "PM"); yield return new WaitForSeconds(50f); break;
                    case "19:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "7:00",  "PM"); yield return new WaitForSeconds(50f); break;
                    case "20:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "8:00",  "PM"); yield return new WaitForSeconds(50f); break;
                    case "21:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "9:00",  "PM"); yield return new WaitForSeconds(50f); break;
                    case "22:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "10:00", "PM"); yield return new WaitForSeconds(50f); break;
                    case "23:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "11:00", "PM"); yield return new WaitForSeconds(50f); break;
                    case "24:00": CohtmlHud.Instance.ViewDropTextImmediate($"[TimeUtils]", "12:00", "AM"); yield return new WaitForSeconds(50f); break;
                    default: new WaitForSeconds(5f); break;
                }
                yield return new WaitForSeconds(5f);
            }
        }
    }
    #endregion
}
