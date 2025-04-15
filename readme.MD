# LongerDays

Il2Cpp - Only

Longer Days – doubles the length of in-game days by slowing down time progression.
Clocks, timers, schedules — everything still works as normal, just stretched out.
Great if you want more breathing room to actually do stuff without rushing the clock every 5 minutes.

🛠️ Mod Disclaimer

This mod is an independent project and is not affiliated with or endorsed by the game's developers or publishers.
Unauthorized use, reproduction, or distribution of this mod or its code is prohibited without explicit permission.
Suggestions and contributions are welcome.
Use at your own risk. I’m not responsible for any issues caused by this mod.


Always back up your saves before installing mods

Press: Win + R

And paste:%AppData%\..\LocalLow\TVGS\Schedule I


# Changelog

## [1.1]
### Added
-  **MelonPreferences config support**  
  - New `TimeMultiplier` setting allows players to customize time speed.
  - Range: `0.1` (very slow) to `2.0` (very fast). Default: `0.5`.
  - Setting includes descriptive comments in the generated config file.

### Changed
-  **Scene-based initialization**  
  - Mod now listens for `"Main"` scene to apply the time multiplier.
  - Automatically resets when `"Menu"` scene is loaded to ensure reinitialization on re-entry.

### Fixed
-  Prevented `NullReferenceException` by safely checking for config and delaying coroutine startup.
-  Avoided performance issues by reducing coroutine load and ensuring clean exit when done.

---

## [1.0.1]
- Multiplayer bug fix

## [1.0.0] – Initial Release
- Base functionality: slows down time by setting `TimeProgressionMultiplier` when `TimeManager` is found.
