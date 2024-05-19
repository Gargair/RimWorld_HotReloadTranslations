using LudeonTK;
using RimWorld;
using Verse;

namespace HotReloadTranslations
{
    public class DebugActions
    {
        [DebugAction("General", null, false, false, false, false, 0, false, name = "Hot reload Translations", allowedGameStates = AllowedGameStates.Playing, displayPriority = 9999)]
        private static void HotReloadTranslations()
        {
            LongEventHandler.QueueLongEvent(delegate
            {
                LongEventHandler.SetCurrentEventText("LoadingTranslations".Translate());
                DeepProfiler.Start("LanguageDatabase.Clear()");
                try
                {
                    LanguageDatabase.Clear();
                }
                finally
                {
                    DeepProfiler.End();
                }
                DeepProfiler.Start("Load language metadata.");
                try
                {
                    LanguageDatabase.InitAllMetadata();
                }
                finally
                {
                    DeepProfiler.End();
                }
            }, "LoadingTranslations", doAsynchronously: false, null);
        }
    }
}