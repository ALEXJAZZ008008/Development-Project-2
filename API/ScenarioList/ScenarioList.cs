using System.Collections.Generic;

namespace API
{
    public class ScenarioList
    {
        public List<Scenario> Scenarios { get; set; }
    }

    public struct Scenario
    {
        /// <summary>
        /// The list of choices that can be made from this scenario.
        /// </summary>
        public List<Choice> Choices { get; set; }

        /// <summary>
        /// If null string, black screen. 
        /// If video path but wrong, then display error.
        /// </summary>
        public string VideoFilePath { get; set; }

        /// <summary>
        /// If null string, no sound. 
        /// Indicates the file path for the sound file for the scenario.
        /// </summary>
        public string SoundFilePath { get; set; }

        /// <summary>
        /// Null indicates no scenario text.
        /// </summary>
        public string ScenarioText { get; set; }

        /// <summary>
        /// The brightness of the scene as a percentage.
        /// </summary>
        public int ScenarioBrightness { get; set; }

        /// <summary>
        /// Sets emergency lighting intensity.
        /// </summary>
        public int EmergencyLighting { get; set; }

        /// <summary>
        /// The sound volume as a percentage (i.e. between 1 and 100).
        /// </summary>
        public int SoundVolume { get; set; }

        /// <summary>
        /// Indicates the presence of a fire effect in the scenario.
        /// </summary>
        public bool HasFire { get; set; }

        /// <summary>
        /// Indicates that the scenario has a smoke effect.
        /// </summary>
        public bool HasSmoke { get; set; }

        /// <summary>
        /// Indicates that the extinguisher effect should be activated. 
        /// </summary>
        public bool HasExtinguisher { get; set; }
    }

    public struct Choice
    {
        /// <summary>
        /// The scenario that the choice should. 
        /// </summary>
        public Scenario DestinationScenario { get; }

        /// <summary>
        /// The choice associated with the text.
        /// </summary>
        public string ChoiceText { get; set; }

        /// <summary>
        /// The feedback given at the end if this choice has been made.
        /// </summary>
        public string ChoiceFeedback { get; set; }

        /// <summary>
        /// Positive choice - positive score
        /// Negative choice - negative score
        /// Neutral choice/no decision needed - zero
        /// </summary>
        public int Score { get; }
    }
}