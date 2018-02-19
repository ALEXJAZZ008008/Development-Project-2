using System;

public class ScenarioAggregate
{ 
    public List<Scenario> Scenarios { get; }
}

public struct Scenario
{
    //If null string, black screen. 
    //If video path but wrong, then display error.
    public string VideoFilePath { get; }

    /// <summary>
    /// Indicates that the scenario has a smoke effect.
    /// </summary>
    public bool HasSmoke { get; }

    /// <summary>
    /// Indicates the presence of a fire effect in the scenario.
    /// </summary>
    public bool HasFire { get; }
    
    /// <summary>
    /// Indicates that the extinguisher effect should be activated. 
    /// </summary>
    public bool HasExtinguisher { get; }

    /// <summary>
    /// Indicates the presence of a timer on the screen.
    /// </summary>
    public bool HasTimer { get; }

    /// <summary>
    /// Indicates the file path for the sound file for the scenario.
    /// </summary>
    public string SoundFilePath { get; }

    /// <summary>
    /// The sound volume as a percentage (i.e. between 1 and 100).
    /// </summary>
    public int SoundVolume { get; }

    /// <summary>
    /// The brightness of the scene as a percentage.
    /// </summary>
    public int ScenarioBrightness { get; }

    /// <summary>
    /// Sets emergency lighting intensity.
    /// </summary>
    public int EmergencyLighting { get;  } 

    public bool IsSafe { get; }

    /// <summary>
    /// Null indicates no scenario text.
    /// </summary>
    public string ScenarioText { get; }

    /// <summary>
    /// The list of choices that can be made from this scenario.
    /// </summary>
    public List<Choice> Choices { get; }

    public bool IsLastScenario => Choices.Count == 0;
}

public struct Choice
{
    /// <summary>
    /// The choice associated with the text.
    /// </summary>
    public string ChoiceText { get; }

    /// <summary>
    /// The feedback given at the end if this choice has been made.
    /// </summary>
    public string ChoiceFeedback { get; }
    
    // Positive choice - positive score
    // Negative choice - negative score
    // Neutral choice/no decision needed - zero
    public int Score { get; }

    /// <summary>
    /// The scenario that the choice should. 
    /// </summary>
    public Scenario DestinationScenario { get; }
}