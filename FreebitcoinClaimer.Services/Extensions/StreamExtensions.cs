using FreebitcoinClaimer.Services.Exceptions;
using Newtonsoft.Json;
using System.Reflection;

namespace FreebitcoinClaimer.Services.Extensions
{
    internal static class StreamExtensions
    {
        /// <summary>
        /// Deserialized JSON in Stream into <typeparamref name="T"/>
        /// </summary>
        /// <param name="stream"><see cref="Stream"/> with content</param>
        /// <typeparam name="T">Type of the resulting object</typeparam>
        /// <returns>Deserialized instance of <typeparamref name="T" /> or <c>null</c></r
        internal static T? DeserializeJsonFromStream<T>(this Stream? stream)
        {
            if (stream is null || !stream.CanRead) { return default; }

            using var streamReader = new StreamReader(stream);
            using var jsonTextReader = new JsonTextReader(streamReader);

            var jsonSerializer = JsonSerializer.CreateDefault();
            var searchResult = jsonSerializer.Deserialize<T>(jsonTextReader);

            return searchResult;
        }

        /// <summary>
        /// Deserialized custom format in Stream into <typeparamref name="T"/>
        /// </summary>
        /// <param name="stream"><see cref="Stream"/> with content</param>
        /// <typeparam name="T">Type of the resulting object</typeparam>
        /// <returns>Deserialized instance of <typeparamref name="T" /> or <c>null</c></r
        internal static T? DeserializeCustomFormatFromStream<T>(this Stream? stream)
        {
            if (stream is null || !stream.CanRead) { return default; }

            using var streamReader = new StreamReader(stream);
            var text = streamReader.ReadToEnd();

            var split = text.Split(':');

            var values = split.Skip(1).ToArray();

            if (split[0].StartsWith('e'))
            {
                throw new Exception(values[0]);
            }

            T obj = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] properties = typeof(T).GetProperties();

            for (int i = 0; i < Math.Min(properties.Length, values.Length); i++)
            {
                object convertedValue = Convert.ChangeType(values[i], properties[i].PropertyType);

                properties[i].SetValue(obj, convertedValue);
            }
            return (T)obj;
        }
    }
}
