using HarmonyLib;
using UnityEngine;

namespace DisableSubsForGameMiSide;

internal static class PatchDialogue3DText
{
    [HarmonyPatch(typeof(Dialogue_3DText), "Start")]
    [HarmonyPostfix]
    private static void Postfix_DialogueStart(Dialogue_3DText __instance)
    {
        if (__instance != null)
        {
            // 3d сабы
            __instance.gameObject.GetComponent<Canvas>().enabled = false;
            __instance.exampleSymbol.GetComponent<UnityEngine.UI.Text>().enabled = false;
            __instance.exampleSymbol.GetComponent<Coffee.UIEffects.UIGradient>().enabled = false;
            GameObject shadow3DGameObject = GameObject.Find("SymbolShadow");
            if (shadow3DGameObject != null)
            {
                shadow3DGameObject.GetComponent<UnityEngine.UI.Text>().enabled = false;
                shadow3DGameObject.GetComponent<Coffee.UIEffects.UIGradient>().enabled = false;
            }
            
            // Текстовые сабы
            // GameController/Interface/SubtitlesFrame
            // GameController/Interface/SubtitlesFrame/Text 1
            // GameController/Interface/SubtitlesFrame/Text 2
            GameObject subtitlesFrame = GameObject.Find("GameController/Interface/SubtitlesFrame");
            if (subtitlesFrame != null)
            {
                subtitlesFrame.GetComponent<UnityEngine.UI.Image>().enabled = false;
                var text1Object = subtitlesFrame.transform.Find("Text 1");
                var text2Object = subtitlesFrame.transform.Find("Text 2");

                if (text1Object != null)
                    text1Object.GetComponent<UnityEngine.UI.Text>().enabled = false;
                if (text2Object != null)
                    text2Object.GetComponent<UnityEngine.UI.Text>().enabled = false;
            }
            
            Plugin.Log.LogInfo($"Dialogue_3DText создан: {__instance.name}, и сабы были отключены.");
        }
    }
}