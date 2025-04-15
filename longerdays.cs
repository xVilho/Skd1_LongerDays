using MelonLoader;
using UnityEngine;
using Il2CppScheduleOne.GameTime;

[assembly: MelonInfo(typeof(LongerDaysMod), "LongerDays", "1.1", "xVilho")]
[assembly: MelonColor(255, 200, 150, 255)]
public class LongerDaysMod : MelonMod
{
    private MelonPreferences_Category cfgCategory = null!;
    private MelonPreferences_Entry<float> cfgMultiplier = null!;


    private bool initialized = false;

    public override void OnInitializeMelon()
    {
        cfgCategory = MelonPreferences.CreateCategory("LongerDays", "Longer Days Mod Settings");
        cfgMultiplier = cfgCategory.CreateEntry(
        "TimeMultiplier",
        0.5f,
        "Time Speed Multiplier",
        "Controls how fast in-game time passes.\n" +
        "1.0 = normal speed (100%), 0.5 = 50% (slower), 2.0 = 200% (faster).\n" +
        "Allowed range: 0.1 (very slow) to 2.0 (very fast)."
        );

    }

    public override void OnSceneWasInitialized(int buildIndex, string sceneName)
    {
        if (sceneName == "Menu")
        {
            initialized = false;
            Log("🔁 Scene 'menu' loaded — reset mod state.");
        }

        if (sceneName == "Main")
        {
            Log("🧩 Scene 'main' initialized. Will begin checking for TimeManager every 2s...");
            MelonCoroutines.Start(FindTimeManagerLoop());
        }
    }

    private System.Collections.IEnumerator FindTimeManagerLoop()
    {
        yield return null; // let scene settle a frame

        while (!initialized)
        {
            if (cfgMultiplier == null)
            {
                Log("❌ cfgMultiplier is null — config was not initialized?");
                yield break;
            }

            TimeManager timeManager = Object.FindObjectOfType<TimeManager>();
            if (timeManager != null)
            {
                float multiplier = Mathf.Clamp(cfgMultiplier.Value, 0.1f, 2f);
                timeManager.TimeProgressionMultiplier = multiplier;
                Log($"⏳ Time slowed down to {multiplier:0.##}x ({multiplier * 100f:0.#}% of normal speed).");
                initialized = true;
                yield break;
            }

            yield return new WaitForSeconds(2f);
        }
    }

    private static void Log(string msg) => MelonLogger.Msg($"[LongerDays] {msg}");

}
