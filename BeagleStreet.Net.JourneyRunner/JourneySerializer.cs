using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BeagleStreet.Net.JourneyRunner.Models;
using Newtonsoft.Json;

namespace BeagleStreet.Net.JourneyRunner
{
    public class JourneySerializer
    {
        public static void SerializeJourneyToFile(Journey journey)
        {
            try
            {
                var directory = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\journeys";

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var filePath = $"{directory}\\{journey.Name}.json";

                if (File.Exists(filePath))
                {
                    return;
                }
                
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

        public static List<Journey> DeserializeJourniesFromFiles()
        {
            try
            {
                var directory = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\journeys";

                if (!Directory.Exists(directory))
                {
                    return new List<Journey>();
                }

                var filePaths = new DirectoryInfo(directory).GetFiles("*.json").Select(s => directory + "\\" + s.Name);

                return filePaths.Select(filePath => JsonConvert.DeserializeObject<Journey>(File.ReadAllText(filePath))).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
