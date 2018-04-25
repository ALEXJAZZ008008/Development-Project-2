using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;

namespace API
{
    class Test
    {
        static void Main(string[] args)
        {
            string directoryPath = Assembly.GetExecutingAssembly().CodeBase;

            directoryPath = Regex.Split(directoryPath, "file:///")[1];

            directoryPath = Regex.Split(directoryPath, "/API/API/bin/Debug/API.exe")[0];

            ScenarioList scenarioList = new ScenarioList();

            Scenario scenarioOne = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/scene1.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/scene1_audio.wav", directoryPath + string.Empty, directoryPath + "/Scenarios/Assets/Output", "scenarioText1", "scenarioChoiceText1", new List<float> {  }, new List<float> {  }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, false, false);
            Scenario scenarioTwo = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene2.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene2_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, "scenarioText2", "scenarioChoiceText2", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true);
            Scenario scenarioThree = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene3.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene3_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, "scenarioText3", "scenarioChoiceText3", new List<float> { }, new List<float> { }, 3.0f, 0.75f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, true, false, true, true);
            Scenario scenarioFour = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene4.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene4_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, "scenarioText4", "scenarioChoiceText4", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true);
            Scenario scenarioFive = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene5.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene5_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, "scenarioText5", "scenarioChoiceText5", new List<float> { }, new List<float> { }, 3.0f, 0.75f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, true, true, true, true, true);
            Scenario scenarioSix = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene6.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene6_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, "scenarioText6", "scenarioChoiceText6", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true);
            Scenario scenarioSeven = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene7.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene7_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, "scenarioText7", "scenarioChoiceText7", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true);
            Scenario scenarioEight = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene8.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene8_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, "scenarioText8", "scenarioChoiceText8", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true);
            Scenario scenarioNine = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene9.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene9_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Continuous.wav", string.Empty, "scenarioText9", "scenarioChoiceText9", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, false, true, true);
            Scenario scenarioTen = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Scene10.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Scene10_audio.wav", directoryPath + "/Scenarios/Assets/Audio/Intermittent.wav", string.Empty, "scenarioText10", "scenarioChoiceText10", new List<float> { }, new List<float> { }, 3.0f, 1.0f, 0.25f, 0.75f, 1.0f, 0.5f, 5.0f, false, false, true, false, true);

            scenarioOne.GetChoices().Add(new Choice(1, "Ring switchboard", "Rang switchboard", 1));
            scenarioOne.GetChoices().Add(new Choice(0, "Ring fire brigade", "Rang fire brigade", -1));
            scenarioOne.GetChoices().Add(new Choice(0, "Evacuate", "Evacuated", -1));

            scenarioTwo.GetChoices().Add(new Choice(1, "Evacuate", "Evacuated", -1));
            scenarioTwo.GetChoices().Add(new Choice(2, "Investigate", "Investigated", 1));
            scenarioTwo.GetChoices().Add(new Choice(1, "Wait", "Waited", -1));

            scenarioThree.GetChoices().Add(new Choice(2, "Evacuate", "Evacuated", -1));
            scenarioThree.GetChoices().Add(new Choice(3, "Fight the fire", "Fought the fire", 1));
            scenarioThree.GetChoices().Add(new Choice(2, "Wait", "Waited", -1));

            scenarioFour.GetChoices().Add(new Choice(4, "Foam", "Used foam", 1));
            scenarioFour.GetChoices().Add(new Choice(3, "CO2", "Used CO2", -1));

            scenarioFive.GetChoices().Add(new Choice(5, string.Empty, string.Empty, 0));

            scenarioSix.GetChoices().Add(new Choice(4, "Go to safety", "Went to safety", -1));
            scenarioSix.GetChoices().Add(new Choice(5, "Return to ward", "Returned to ward", 1));

            scenarioSeven.GetChoices().Add(new Choice(6, "Go to safety", "Went to safety", -1));
            scenarioSeven.GetChoices().Add(new Choice(7, "Return to ward", "Returned to ward", 1));

            scenarioEight.GetChoices().Add(new Choice(7, "Wait", "Waited", -1));
            scenarioEight.GetChoices().Add(new Choice(8, "Evacuate", "Evacuated", 1));

            scenarioNine.GetChoices().Add(new Choice(9, string.Empty, string.Empty, 0));

            string json = string.Empty;

            JSONParser.TObjectToJSON(ref json, scenarioList);

            Console.WriteLine(json);

            Console.ReadLine();

            using (StreamWriter streamWriter = new StreamWriter("json.txt"))
            {
                streamWriter.Write(json);
            }

            ScenarioList jsonScenarioList = new ScenarioList();

            JSONParser.JSONToTObject(json, ref jsonScenarioList);

            string jsonJSON = string.Empty;

            JSONParser.TObjectToJSON(ref jsonJSON, jsonScenarioList);

            JSONParser.TObjectToJSON(ref json, scenarioList);

            if (json == jsonJSON)
            {
                Console.WriteLine("Successful");
            }
            else
            {
                Console.WriteLine("Failure");
            }

            Console.ReadLine();
        }
    }
}