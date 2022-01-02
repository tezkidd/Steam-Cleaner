using System;
using System.Diagnostics;
using Microsoft.Win32;
using Steam_Cleaner.Classes;

namespace Steam_Cleaner
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			foreach (var process in Constants.processesToCheck)
			{
				Process[] ps = Process.GetProcessesByName(process);
				foreach (Process p in ps)
					try
					{
						p.Kill();
					}
					catch
					{ }
			}
			Clean();
		}

		private static void Clean()
        {

			var currentUser = Registry.CurrentUser;
			var classesRoot = Registry.ClassesRoot;
			var localMachine = Registry.LocalMachine;

			try
			{
				Method.DeleteFile(Constants.nativeFolder, "GameOverlayRenderer.log");
				Method.DeleteFile(Constants.nativeFolder, "GameOverlayUI.exe.log");
				Method.DeleteFile(Constants.nativeFolder, "GameOverlayUI.exe.log.last");
				Method.DeleteFile(@"bin\cef\cef.win7", "GameOverlayUI.exe.log.last");
				Method.DeleteSentryfiles("ssfn*");
				Method.DeleteDir(@"C:\Program Files (x86)\Steam\logs");
				Method.DeleteDir(@"C:\Program Files (x86)\Steam\config");
				Method.DeleteDir(@"C:\Program Files (x86)\Steam\userdata");
				Method.DeleteDir(@"C:\Program Files (x86)\Steam\dumps");
				Method.DeleteDir(@"C:\Program Files (x86)\Steam\appcache");
				Method.DeleteRegKey(currentUser, @"Software\\Valve\Steam\Users");
				Method.DeleteRegKey(currentUser, @"Software\Valve");
				Method.DeleteRegKey(currentUser, @"Software\Classes\Steam");
				Method.DeleteRegKey(classesRoot, @"Steam");
				Method.DeleteRegKey(localMachine, @"SOFTWARE\Wow6432Node\Valve");
				Method.DeleteRegKey(localMachine, @"SOFTWARE\Classes\Steam");
			}
			catch
			{ }
		}
	}
}
