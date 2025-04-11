using MelonLoader;
using Il2CppScheduleOne.GameTime;
using UnityEngine;

[assembly: MelonInfo(typeof(LongerDaysMod), "LongerDays", "1.0.0", "xVilho")]

public class LongerDaysMod : MelonMod
{
    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        TimeManager timeManager = Object.FindObjectOfType<TimeManager>();
        if (timeManager == null)
        {
            MelonLogger.Warning("TimeManager not found.");
            return;
        }

        timeManager.TimeProgressionMultiplier = 0.5f;
        MelonLogger.Msg("TimeProgressionMultiplier set to 0.5 (2x longer days)");
    }
}
