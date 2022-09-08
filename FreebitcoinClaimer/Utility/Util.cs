using Microsoft.Win32;
using Newtonsoft.Json;
using System.Text;

namespace FreebitcoinClaimer.Utility
{
    internal static class Util
    {
        internal static string GetFriendlyOSVersion()
        {
            string productName = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ProductName", "")!.ToString()!;
            string csdVersion = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "CSDVersion", "")!.ToString()!;
            string releaseId = Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion", "ReleaseId", "")!.ToString()!;

            if (string.IsNullOrEmpty(productName))
                return "Unknown";

            StringBuilder name = new();

            if (!productName.StartsWith("Microsoft"))
                name.Append("Microsoft ");

            name.Append(productName);

            if (!string.IsNullOrEmpty(csdVersion))
            {
                name.Append(' ');
                name.Append(csdVersion);
            }

            if (!string.IsNullOrEmpty(releaseId))
            {
                name.Append(" release ");
                name.Append(releaseId);
            }

            name.Append(Environment.Is64BitOperatingSystem ? " x64" : " x86");

            return name.ToString();
        }

        internal static T ReadJson<T>(string file)
        {
            T? read = default;

            using (var reader = new StreamReader(file))
            {
                var fileContent = reader.ReadToEnd();
                read = JsonConvert.DeserializeObject<T>(fileContent, GetJsonSerializerSettings(true));
            }

            return read!;
        }

        internal static void WriteJson<T>(string file, T root)
        {
            using (var writer = new StreamWriter(file))
            {
                var fileContent = JsonConvert.SerializeObject(root, GetJsonSerializerSettings(true));
                writer.Write(fileContent);
            }
        }

        internal static JsonSerializerSettings GetJsonSerializerSettings(bool prettyPrint = false)
        {
            JsonSerializerSettings settings = new()
            {
                Formatting = prettyPrint ? Formatting.Indented : Formatting.None
            };

            return settings;
        }
    }
}