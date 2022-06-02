using Newtonsoft.Json;
using labparser.Model;
using System.IO;

namespace labparser
{
    public class LabParser
    {
        public static string GenerateAeJson(DirectoryInfo LabDirectory, string PremiereJson)
        {
            // Parse PremiereJson
            var prJson = JsonConvert.DeserializeObject<PremiereJson>(PremiereJson);

            var response = new LabShape();

            if (prJson == null)
                return String.Empty;

            // Retrieve List of file in the directory
            var files = LabDirectory.GetFiles("*.lab");

            //prJson.TargetClipStartsAt
            foreach (var items in prJson.AudioClips)
            {
                var target = files.Where(x => Path.GetFileNameWithoutExtension(x.Name) == Path.GetFileNameWithoutExtension(items.Name));
                if (!target.Any() || items.StartSeconds < prJson.TargetClipStartsAt
                    || items.StartSeconds > prJson.TargetClipEndsAt)
                    continue;

                using (var sr = new StreamReader(target.First().FullName, System.Text.Encoding.UTF8))
                {
                    while(sr.Peek() >= 0)
                    {
                        var phoneRecord = sr.ReadLine()?.Split(" ", StringSplitOptions.RemoveEmptyEntries) ?? null;
                        double phoneStartsAt = 0;
                        double phoneEndsAt = 0;

                        // phone would contain
                        // 50000 2000000 k
                        if (phoneRecord == null || phoneRecord.Length < 3 ||
                            !double.TryParse(phoneRecord[0], out phoneStartsAt) ||
                            !double.TryParse(phoneRecord[1], out phoneEndsAt) ||
                            string.IsNullOrEmpty(phoneRecord[2]))
                            continue;

                        string phone = phoneRecord[2];
                        string lipShape = string.Empty;

                        // Correct value by deviding by 10000000
                        phoneStartsAt /= 10000000;
                        phoneEndsAt /= 10000000;

                        // Calculate time based on offset;
                        var startSeconds = items.StartSeconds - prJson.TargetClipStartsAt + phoneStartsAt;
                        var endSeconds = items.EndSeconds - prJson.TargetClipStartsAt + phoneEndsAt;
                        
                        // maps to other sounds (for similar shape)
                        switch (phone)
                        {
                            case "m":
                                lipShape = "N";
                                break;
                            case "p":
                                lipShape = "N";
                                break;
                            case "b":
                                lipShape = "N";
                                break;
                            case "w":
                                lipShape = "o";
                                break;
                            case "pau":
                                lipShape = "N";
                                break;
                            default:
                                lipShape = phone;
                                break;
                        }

                        var phoneLabel = new PhoneLabel(startSeconds, endSeconds, phone, lipShape);
                        response.PhoneLabels.Add(phoneLabel);
                    }
                }
            }

            return JsonConvert.SerializeObject(response);
        }
    }
}