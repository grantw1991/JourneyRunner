using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Life.JourneyRunner.Models.BGL;
using Newtonsoft.Json;

namespace Life.JourneyRunner
{
    public class JourneySerializer
    {
        public static void SerializeJourneyToFile(Journey journey)
        {
            Process(journey.Name, journey);
        }

        public static void SerializeJourneyToFile(Models.MSM.Journey journey)
        {
            Process(journey.Name, journey);
        }

        private static void Process(string journeyName, object journey)
        {
            try
            {
                var directory = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\journeys";

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var filePath = $"{directory}\\{journeyName}.json";

                if (File.Exists(filePath))
                    return;

                using (var streamWriter = new StreamWriter(File.Create(filePath)))
                {
                    streamWriter.Write(JsonConvert.SerializeObject(journey, Formatting.Indented));
                    streamWriter.Close();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Journey> DeserializeBGLJourniesFromFiles()
        {
            try
            {
                var directory = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\journeys";

                if (!Directory.Exists(directory))
                {
                    return new List<Journey>();
                }

                var filePaths = new DirectoryInfo(directory).GetFiles("*.json").Select(s => directory + "\\" + s.Name);

                var items = filePaths
                    .Select(filePath => JsonConvert.DeserializeObject<Journey>(File.ReadAllText(filePath)))
                    .Where(journey => string.IsNullOrEmpty(journey.JourneyType) || journey.JourneyType == "BGL")
                    .ToList();

                return items;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public static List<Models.MSM.Journey> DeserializeMSMJourniesFromFiles()
        {
            try
            {
                var directory = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\journeys";

                if (!Directory.Exists(directory))
                {
                    return new List<Models.MSM.Journey>();
                }

                var filePaths = new DirectoryInfo(directory).GetFiles("*.json").Select(s => directory + "\\" + s.Name);

                var items = filePaths
                    .Select(filePath => JsonConvert.DeserializeObject<Models.MSM.Journey>(File.ReadAllText(filePath)))
                    .Where(journey => journey.JourneyType == "MSM")
                    .ToList();

                return items;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
