using MelonLoader;
using UnityEngine;
using Il2CppScheduleOne.GameTime;
using Il2CppFishNet.Object; // Needed for IsServer (used by FishNet networking)

[assembly: MelonInfo(typeof(LongerDaysMod), "LongerDays", "1.0.1", "xVilho")]

public class LongerDaysMod : MelonMod
{
    private TimeManager timeManager = null;
    private bool attemptedInit = false;

    public override void OnUpdate()
    {
        // Only try to find TimeManager once to avoid performance issues
        if (!attemptedInit)
        {
            timeManager = Object.FindObjectOfType<TimeManager>();
            attemptedInit = true;

            if (timeManager == null)
            {
                MelonLogger.Warning("⏳ TimeManager not found yet.");
                return;
            }

            if (timeManager.IsServer)
            {
                timeManager.TimeProgressionMultiplier = 0.5f;
                MelonLogger.Msg("⏳ Time slowed down to 0.5x (host only)");
            }
            else
            {
                MelonLogger.Msg("🧭 Client detected – will not modify time.");
            }
        }
    }
}
