using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactsApp.Model
{
    public static class ProjectManager
    {
        private const string _fileName = "ContactsApp.notes";

        private static readonly string _folder = Environment.GetFolderPath(
                Environment.SpecialFolder.ApplicationData) +
            "\\ContactsApp\\";

        private static readonly string _path = _folder + _fileName;

        public static string DefaultPath { get; set; } = _path;

        public static void SaveToFile(Project data)
        {
            var serializer = new JsonSerializer();
            serializer.Formatting = Formatting.Indented;
            using (var sw = new StreamWriter(DefaultPath))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, data);
            }
        }
        public static Project LoadFromFile()
        {
            var serializer = new JsonSerializer();
            try
            {
                using (var sr = new StreamReader(DefaultPath))
                using (JsonReader reader = new JsonTextReader(sr))
                {
                    var project = (Project)serializer.Deserialize<Project>(reader);
                    if (project == null)
                    {
                        return new Project();
                    }

                    return project;
                }
            }
            catch (Exception exception)
            {
                return new Project();
            }
        }
    }
}
