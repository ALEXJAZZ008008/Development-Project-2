using System.Collections.Generic;

namespace API
{
    public class ScenarioList
    {
        private List<Scenario> m_Scenarios;

        public ScenarioList()
        {
            m_Scenarios = new List<Scenario>();
        }

        public ScenarioList(ScenarioList scenarioList)
        {
            m_Scenarios = scenarioList.GetScenarios();
        }

        public List<Scenario> GetScenarios()
        {
            return m_Scenarios;
        }

        public void SetScenarios(List<Scenario> scenarios)
        {
            m_Scenarios = scenarios;
        }
    }

    public class Scenario
    {
        /// <summary>
        /// The list of choices that can be made from this scenario.
        /// </summary>
        private List<Choice> m_Choices;

        /// <summary>
        /// If null string, black screen. 
        /// If video path but wrong, then display error.
        /// </summary>
        private string m_VideoFilePath;

        /// <summary>
        /// If null string, no sound. 
        /// Indicates the file path for the sound file for the scenario.
        /// </summary>
        private string m_SoundFilePath;

        /// <summary>
        /// Null indicates no scenario text.
        /// </summary>
        private string m_ScenarioText;

        /// <summary>
        /// The brightness of the scene as a percentage.
        /// </summary>
        private int m_VideoBrightness;

        /// <summary>
        /// Sets emergency lighting intensity.
        /// </summary>
        private int m_AmbientBrightness;

        /// <summary>
        /// The sound volume as a percentage (i.e. between 1 and 100).
        /// </summary>
        private int m_SoundVolume;

        /// <summary>
        /// Indicates the presence of a fire effect in the scenario.
        /// </summary>
        private bool m_HasFire;

        /// <summary>
        /// Indicates that the scenario has a smoke effect.
        /// </summary>
        private bool m_HasSmoke;

        /// <summary>
        /// Indicates that the extinguisher effect should be activated. 
        /// </summary>
        private bool m_HasExtinguisher;
    }

    public class Choice
    {
        /// <summary>
        /// The scenario that the choice should. 
        /// </summary>
        private Scenario m_NextScenario;

        /// <summary>
        /// The choice associated with the text.
        /// </summary>
        private string m_ChoiceText;

        /// <summary>
        /// The feedback given at the end if this choice has been made.
        /// </summary>
        private string m_FeedbackText;

        /// <summary>
        /// Positive choice - positive score
        /// Negative choice - negative score
        /// Neutral choice/no decision needed - zero
        /// </summary>
        private int m_Score;
    }
}