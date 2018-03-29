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

            Scenario scenarioZero = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Stationary1.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Narration.wav", directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", directoryPath + "/Scenarios/Assets/Output", "scenarioText0", "scenarioChoiceText0", 3.0f, 0.25f, 0.75f, 1.0f, 0.5f, 10.0f, false, false, false, false, false);
            Scenario scenarioOne = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Stationary2.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientRadio.wav", string.Empty, directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", string.Empty, "scenarioText1", "scenarioChoiceText1", 3.0f, 0.25f, 0.3f, 0.0f, 0.5f, 9.0f, true, false, false, false, false);
            Scenario scenarioTwo = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Stationary3.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Narration.wav", directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", string.Empty, "scenarioText2", "scenarioChoiceText2", 3.0f, 0.25f, 0.75f, 1.0f, 0.5f, 8.0f, true, true, false, false, false);
            Scenario scenarioThree = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Stationary4.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientRadio.wav", string.Empty, directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", string.Empty, "scenarioText3", "scenarioChoiceText3", 3.0f, 0.25f, 0.3f, 0.0f, 0.5f, 7.0f, true, true, false, true, true);
            Scenario scenarioFour = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Trolly1.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Narration.wav", directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", string.Empty, "scenarioText4", "scenarioChoiceText4", 3.0f, 0.25f, 0.75f, 1.0f, 0.5f, 6.0f, true, true, true, true, true);
            Scenario scenarioFive = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Walking1.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientRadio.wav", string.Empty, directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", string.Empty, "scenarioText5", "scenarioChoiceText5", 3.0f, 0.25f, 0.3f, 1.0f, 0.5f, 5.0f, false, false, false, false, false);
            Scenario scenarioSix = new Scenario(new List<Choice>(), string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, "scenarioText6", "scenarioChoiceText6", 3.0f, 0.25f, 0.75f, 1.0f, 0.75f, 4.0f, false, false, false, false, false);

            Choice choiceZero = new Choice(1, "Scenario 1", "Went to 1", 0);

            scenarioZero.GetChoices().Add(choiceZero);

            Choice choiceOne = new Choice(0, "Scenario 0", "Went to 0", -1);
            Choice choiceTwo = new Choice(2, "Scenario 2", "Went to 2", 1);

            scenarioOne.GetChoices().Add(choiceOne);
            scenarioOne.GetChoices().Add(choiceTwo);

            Choice choiceThree = new Choice(0, "Scenario 0", "Went to 0", -1);
            Choice choiceFour = new Choice(1, "Scenario 1", "Went to 1", -1);
            Choice choiceFive = new Choice(3, "Scenario 3", "Went to 3", 1);

            scenarioTwo.GetChoices().Add(choiceThree);
            scenarioTwo.GetChoices().Add(choiceFour);
            scenarioTwo.GetChoices().Add(choiceFive);

            Choice choiceSix = new Choice(0, "Scenario 0", "Went to 0", -1);
            Choice choiceSeven = new Choice(1, "Scenario 1", "Went to 1", -1);
            Choice choiceEight = new Choice(2, "Scenario 2", "Went to 2", -1);
            Choice choiceNine = new Choice(4, "Scenario 4", "Went to 4", 1);

            scenarioThree.GetChoices().Add(choiceSix);
            scenarioThree.GetChoices().Add(choiceSeven);
            scenarioThree.GetChoices().Add(choiceEight);
            scenarioThree.GetChoices().Add(choiceNine);

            Choice choiceTen = new Choice(0, "Scenario 0", "Went to 0", -1);
            Choice choiceEleven = new Choice(1, "Scenario 1", "Went to 1", -1);
            Choice choiceTwelve = new Choice(2, "Scenario 2", "Went to 2", -1);
            Choice choiceThirteen = new Choice(3, "Scenario 3", "Went to 3", -1);
            Choice choiceFourteen = new Choice(5, "Scenario 5", "Went to 5", 1);

            scenarioFour.GetChoices().Add(choiceTen);
            scenarioFour.GetChoices().Add(choiceEleven);
            scenarioFour.GetChoices().Add(choiceTwelve);
            scenarioFour.GetChoices().Add(choiceThirteen);
            scenarioFour.GetChoices().Add(choiceFourteen);

            Choice choiceFifteen = new Choice(6, "Scenario 6", "Went to 6", 0);

            scenarioList.GetScenarios().Add(scenarioZero);
            scenarioList.GetScenarios().Add(scenarioOne);
            scenarioList.GetScenarios().Add(scenarioTwo);
            scenarioList.GetScenarios().Add(scenarioThree);
            scenarioList.GetScenarios().Add(scenarioFour);
            scenarioList.GetScenarios().Add(scenarioFive);

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