using System;
using System.Reflection;
using MelonLoader;

[assembly: AssemblyTitle(CVRHudUtils.BuildInfo.Description)]
[assembly: AssemblyDescription(CVRHudUtils.BuildInfo.Description)]
[assembly: AssemblyCompany(CVRHudUtils.BuildInfo.Company)]
[assembly: AssemblyProduct(CVRHudUtils.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + CVRHudUtils.BuildInfo.Author)]
[assembly: AssemblyTrademark(CVRHudUtils.BuildInfo.Company)]
[assembly: AssemblyVersion(CVRHudUtils.BuildInfo.Version)]
[assembly: AssemblyFileVersion(CVRHudUtils.BuildInfo.Version)]
[assembly: MelonInfo(typeof(CVRHudUtils.CVRHudUtils), CVRHudUtils.BuildInfo.Name, CVRHudUtils.BuildInfo.Version, CVRHudUtils.BuildInfo.Author, CVRHudUtils.BuildInfo.DownloadLink)]
[assembly: MelonColor(ConsoleColor.DarkRed)]
[assembly: MelonGame(null, null)]