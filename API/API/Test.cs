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

            Scenario scenarioOne = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Stationary1.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Narration.wav", directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", "scenarioText", "scenarioChoiceText", 0.25f, 0.75f, 1.0f, 0.75f, false, false, false);
            Scenario scenarioTwo = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Stationary2.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Narration.wav", directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", "scenarioText", "scenarioChoiceText", 0.25f, 0.75f, 1.0f, 0.75f, false, false, false);
            Scenario scenarioThree = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Stationary3.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Narration.wav", directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", "scenarioText", "scenarioChoiceText", 0.25f, 0.75f, 1.0f, 0.75f, false, false, false);
            Scenario scenarioFour = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Stationary4.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Narration.wav", directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", "scenarioText", "scenarioChoiceText", 0.25f, 0.75f, 1.0f, 0.75f, false, false, false);
            Scenario scenarioFive = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Trolly1.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Narration.wav", directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", "scenarioText", "scenarioChoiceText", 0.25f, 0.75f, 1.0f, 0.75f, false, false, false);
            Scenario scenarioSix = new Scenario(new List<Choice>(), directoryPath + "/Scenarios/Assets/Videos/Walking1.mp4", directoryPath + "/Scenarios/Assets/Audio/AmbientHospital.wav", directoryPath + "/Scenarios/Assets/Audio/Narration.wav", directoryPath + "/Scenarios/Assets/Audio/AlarmSound.wav", "scenarioText", "scenarioChoiceText", 0.25f, 0.75f, 1.0f, 0.75f, false, false, false);

            Choice choiceOne = new Choice(scenarioTwo, "choiceText", "feedbackText", 0);

            scenarioOne.GetChoices().Add(choiceOne);

            Choice choiceTwo = new Choice(scenarioOne, "choiceText", "feedbackText", 0);
            Choice choiceThree = new Choice(scenarioThree, "choiceText", "feedbackText", 0);

            scenarioTwo.GetChoices().Add(choiceTwo);
            scenarioTwo.GetChoices().Add(choiceThree);

            Choice choiceFour = new Choice(scenarioOne, "choiceText", "feedbackText", 0);
            Choice choiceFive = new Choice(scenarioTwo, "choiceText", "feedbackText", 0);
            Choice choiceSix = new Choice(scenarioFour, "choiceText", "feedbackText", 0);

            scenarioThree.GetChoices().Add(choiceFour);
            scenarioThree.GetChoices().Add(choiceFive);
            scenarioThree.GetChoices().Add(choiceSix);

            Choice choiceSeven = new Choice(scenarioOne, "choiceText", "feedbackText", 0);
            Choice choiceEight = new Choice(scenarioTwo, "choiceText", "feedbackText", 0);
            Choice choiceNine = new Choice(scenarioThree, "choiceText", "feedbackText", 0);
            Choice choiceTen = new Choice(scenarioFive, "choiceText", "feedbackText", 0);

            scenarioFour.GetChoices().Add(choiceSeven);
            scenarioFour.GetChoices().Add(choiceEight);
            scenarioFour.GetChoices().Add(choiceNine);
            scenarioFour.GetChoices().Add(choiceTen);

            Choice choiceEleven = new Choice(scenarioOne, "choiceText", "feedbackText", 0);
            Choice choiceTwelve = new Choice(scenarioTwo, "choiceText", "feedbackText", 0);
            Choice choiceThirteen = new Choice(scenarioThree, "choiceText", "feedbackText", 0);
            Choice choiceFourteen = new Choice(scenarioFour, "choiceText", "feedbackText", 0);
            Choice choiceFifteen = new Choice(scenarioSix, "choiceText", "feedbackText", 0);

            scenarioFive.GetChoices().Add(choiceEleven);
            scenarioFive.GetChoices().Add(choiceTwelve);
            scenarioFive.GetChoices().Add(choiceThirteen);
            scenarioFive.GetChoices().Add(choiceFourteen);
            scenarioFive.GetChoices().Add(choiceFifteen);

            scenarioList.GetScenarios().Add(scenarioOne);
            scenarioList.GetScenarios().Add(scenarioTwo);
            scenarioList.GetScenarios().Add(scenarioThree);
            scenarioList.GetScenarios().Add(scenarioFour);
            scenarioList.GetScenarios().Add(scenarioFive);
            scenarioList.GetScenarios().Add(scenarioSix);

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