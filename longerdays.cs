using MelonLoader;
using UnityEngine;
using Il2CppScheduleOne.GameTime;

[assembly: MelonInfo(typeof(LongerDaysMod), "LongerDays", "1.0.2", "xVilho")]

public class LongerDaysMod : MelonMod
{
    private bool initialized = false;

    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        if (!initialized)
        {
            Log($"🧩 Scene '{sceneName}' initialized. Will begin checking for TimeManager every 2s...");
            MelonCoroutines.Start(FindTimeManagerLoop());
        }
    }

    private System.Collections.IEnumerator FindTimeManagerLoop()
    {
        while (!initialized)
        {
            TimeManager timeManager = Object.FindObjectOfType<TimeManager>();

            if (timeManager != null)
            {
                timeManager.TimeProgressionMultiplier = 0.5f;
                Log("⏳ Time slowed down to 0.5x (found via 2s recheck loop).");
                initialized = true;
                yield break;
            }

            Log("🔁 TimeManager not found yet. Retrying in 2s...");
            yield return new WaitForSeconds(2f);
        }
    }
    private static void Log(string msg) => MelonLogger.Msg($"[LongerDays] {msg}");

}
