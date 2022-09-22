﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Globalization;

namespace FreebitcoinClaimer.Utility
{
    internal static class Config
    {
        private static JToken? root;
        private static readonly string SettingsFile = Path.Combine(Folders.Configuration, "FreeBitcoinClaimerSettings.json");

        internal static void Load()
        {
            // Make sure the config directory exists 
            if (!Directory.Exists(Folders.Configuration))
                Directory.CreateDirectory(Folders.Configuration);

            Logger.Info($"Loading settings from \"{SettingsFile}\"");

            // Check if settings exist
            if (File.Exists(SettingsFile))
            {
                try
                {
                    // Load settings from JSON
                    root = Util.ReadJson<JToken>(SettingsFile);
                }
                catch (JsonSerializationException ex)
                {
                    Logger.PrintException("Syntax error occured while reading settings JSON", ex);
                    MessageBox.Show($"Failed to load settings from \"{SettingsFile}\". Please check your syntax and try again.", "FreeBitcoin Claimer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    Logger.PrintException("Failed to read settings JSON", ex);
                    MessageBox.Show($"Failed to load settings from \"{SettingsFile}\".", "FreeBitcoin Claimer", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                Logger.Info("Settings file does not exist. Loading default");
                LoadDefault();
                Save();
            }
        }

        private static void LoadDefault()
        {
            root = JObject.FromObject(new
            {
                Claim = new
                {
                    Delay = 1000
                },
                LogToFile = true,
                LogLevel = "info",
                CheckForUpdates = true
            });
        }

        internal static void Save()
        {
            Logger.Info($"Saving settings to \"{SettingsFile}\"");

            try
            {
                Util.WriteJson(SettingsFile, root);
            }
            catch (Exception ex)
            {
                Logger.PrintException("Failed to write settings JSON", ex);
            }
        }

        internal static string GetStringValue(string key, string defaultValue)
        {
            var node = GetTokenByPath(key);

            if (node == null || node is not JProperty || (node as JProperty)!.Value.Type != JTokenType.String)
                return defaultValue;

            return (node as JProperty)!.Value.ToString();
        }

        internal static byte GetByteValue(string key, byte defaultValue)
        {
            var node = GetTokenByPath(key);

            if (node == null || node is not JProperty || (node as JProperty)!.Value.Type != JTokenType.Bytes)
                return defaultValue;

            string strValue = (node as JProperty)!.Value.ToString();

            if (!byte.TryParse(strValue, out byte value))
            {
                Logger.Warn("Failed to parse \"{0}\" as byte", strValue);
                return defaultValue;
            }

            return value;
        }

        internal static int GetIntegerValue(string key, int defaultValue)
        {
            var node = GetTokenByPath(key);

            if (node == null || node is not JProperty || (node as JProperty)!.Value.Type != JTokenType.Integer)
                return defaultValue;

            string strValue = (node as JProperty)!.Value.ToString();

            if (!int.TryParse(strValue, out int value))
            {
                Logger.Warn("Failed to parse \"{0}\" as integer", strValue);
                return defaultValue;
            }

            return value;
        }

        internal static float GetFloatValue(string key, float defaultValue)
        {
            var node = GetTokenByPath(key);

            if (node == null || node is not JProperty || (node as JProperty)!.Value.Type != JTokenType.Float)
                return defaultValue;

            string strValue = (node as JProperty)!.Value.ToString();

            if (!float.TryParse(strValue, NumberStyles.Float, CultureInfo.InvariantCulture, out float value))
            {
                Logger.Warn("Failed to parse \"{0}\" as float", strValue);
                return defaultValue;
            }

            return value;
        }

        internal static bool GetBooleanValue(string key, bool defaultValue)
        {
            var node = GetTokenByPath(key);

            if (node == null || node is not JProperty || (node as JProperty)!.Value.Type != JTokenType.Boolean)
                return defaultValue;

            string strValue = (node as JProperty)!.Value.ToString();

            if (!bool.TryParse(strValue, out bool value))
            {
                Logger.Warn("Failed to parse \"{0}\" as boolean", strValue);
                return defaultValue;
            }

            return value;
        }

        internal static void SetValue(string key, object value)
        {
            SetTokenByPath(key, value);
            Save();
        }

        private static JToken GetTokenByPath(string key)
        {
            Logger.Trace($"Getting key \"{key}\"");

            string[] parts = key.Split('.');
            JToken currentToken = root!;

            for (int i = 0; i < parts.Length; i++)
            {
                if (currentToken != null && (currentToken as JObject)!.ContainsKey(parts[i]))
                    currentToken = currentToken[parts[i]]!;
                else
                    break;
            }

            if (currentToken == null)
                Logger.Trace("Failed to find node with key " + key);

            return currentToken!.Parent!;
        }

        private static void SetTokenByPath(string key, object value)
        {
            Logger.Trace($"Setting key \"{key}\" to \"{value}\"");

            string[] parts = key.Split('.');
            JToken currentToken = root!;

            for (int i = 0; i < parts.Length; i++)  
            {
                if (currentToken is not JObject)
                {
                    Logger.Error("{0} is not a JObject", string.Join(".", parts.Take(i + 1)));
                    return;
                }

                var mappingToken = currentToken as JObject;

                if (!mappingToken!.ContainsKey(parts[i]))
                {
                    if (i == parts.Length - 1)
                        mappingToken.Add(new JProperty(parts[i], null!));
                    else
                        mappingToken.Add(new JProperty(parts[i], new JObject()));
                }

                if (i == parts.Length - 1)
                    (currentToken[parts[i]]!.Parent! as JProperty)!.Value = JToken.FromObject(value);
                else
                    currentToken = currentToken[parts[i]]!;
            }
        }
    }
}