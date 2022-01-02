using Microsoft.Win32;
using System;
using System.IO;

namespace Steam_Cleaner.Classes
{
    public class Method
    {

		public static void DeleteRegKey(RegistryKey keyFolderName, string keyLocation)
		{
			try
			{
				using (RegistryKey registryKey = keyFolderName.OpenSubKey(keyLocation, true))
				{
					if (registryKey == null)
					{
						Console.WriteLine("Registry key not found or does not exist");
					}
					else
					{
						foreach (string name in registryKey.GetValueNames())
						{
							registryKey.DeleteValue(name);
							Console.WriteLine("Deleted Steam registry");
						}
						keyFolderName.DeleteSubKeyTree(keyLocation);
					}
				}
			}
			catch
			{ }
		}

		public static void DeleteDir(string dir)
		{
			try
			{
				Directory.Delete(dir, true);
				Console.WriteLine("Deleted Steam folder");
			}
			catch
			{ }
		}

		public static void DeleteSentryfiles(string prefix)
		{
			string subKey = (string)Registry.GetValue(Constants.steamSubkey, Constants.SteamPath, null);
			if (subKey != null)
			{
				FileInfo[] files = new DirectoryInfo(subKey).GetFiles(prefix);
				if (files.Length != 0)
				{
					foreach (FileInfo fileInfo in files)
					{
						try
						{
							fileInfo.Delete();
							Console.WriteLine("Deleted Steam Sentry file");
						}
						catch
						{ }
					}
					return;
				}
			}
		}

		public static void DeleteFile(string folder, string filename)
		{
			try
			{
				string subKey = (string)Registry.GetValue(Constants.steamSubkey, Constants.SteamPath, null);
				if (subKey != null)
				{
					string path;
					if (folder.Length > 0)
					{
						path = string.Concat(new string[]
						{
							subKey,
							"/",
							folder,
							"/",
							filename
						});
					}
					else
					{
						path = subKey + "/" + filename;
					}
					File.Delete(path);
					Console.WriteLine("Deleted Steam Overlay log");
				}
			}
			catch
			{ }
		}
	}
}
