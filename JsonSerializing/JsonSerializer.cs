using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;

namespace JsonSerializing
{
    internal static class JsonSerializer
    {
        public static string Serialize<T>(T obj)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(obj.GetType());

            using var memoryStream = new MemoryStream();
            
            serializer.WriteObject(memoryStream, obj);
            
            return Encoding.Default.GetString(memoryStream.ToArray());
        }

        public static T Deserialize<T>(string json)
        {
            json = !string.IsNullOrWhiteSpace(json) ? json : "[]";

            using var memoryStream = new MemoryStream(Encoding.Unicode.GetBytes(json));

            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            
            return (T) serializer.ReadObject(memoryStream);
        }

        public static string FormatJson(string jsonText)
        {
            void ForEach<T>(IEnumerable<T> ie, Action<T> action)
            {
                foreach (var i in ie)
                {
                    action(i);
                }
            }

            const string INDENT_STRING = "    ";

            var indent = 0;
            var quoted = false;
            var sb = new StringBuilder();

            for (var i = 0; i < jsonText.Length; i++)
            {
                var ch = jsonText[i];
                switch (ch)
                {
                    case '{':
                    case '[':
                        sb.Append(ch);

                        if (!quoted)
                        {
                            sb.AppendLine();
                            ForEach(Enumerable.Range(0, ++indent), (item => sb.Append(INDENT_STRING)));
                        }
                        break;

                    case '}':
                    case ']':
                        if (!quoted)
                        {
                            sb.AppendLine();
                            ForEach(Enumerable.Range(0, --indent), item => sb.Append(INDENT_STRING));
                        }

                        sb.Append(ch);
                        break;

                    case '"':
                        sb.Append(ch);
                        bool escaped = false;
                        int index = i;
                        while (index > 0
                               && jsonText[--index] == '\\')
                        {
                            escaped = !escaped;
                        }

                        if (!escaped)
                        {
                            quoted = !quoted;
                        }
                        break;

                    case ',':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.AppendLine();
                            ForEach(Enumerable.Range(0, indent), item => sb.Append(INDENT_STRING));
                        }

                        break;
                    case ':':
                        sb.Append(ch);
                        if (!quoted)
                        {
                            sb.Append(" ");
                        }
                        break;

                    default:
                        sb.Append(ch);
                        break;
                }
            }

            return sb.ToString();
        }
    }
}