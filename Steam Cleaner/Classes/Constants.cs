namespace Steam_Cleaner.Classes
{
    public class Constants
    {
        public const string nativeFolder = "";
        public const string steamSubkey = @"HKEY_CURRENT_USER\Software\\Valve\Steam\";
        public const string SteamPath = "SteamPath";


        public static readonly string[] processesToCheck = { "BEService", "EscapeFromTarkov_BE", "BsgLauncher", "EscapeFromTarkov", "EasyAntiCheat",
            "Steam", "steamwebhelper", "steamwebhelper.exe"};
    }
}
