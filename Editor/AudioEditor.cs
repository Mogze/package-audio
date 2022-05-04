namespace Mogze.Audio
{
    using UnityEngine;
    using UnityEditor;

    public class AudioEditor
    {
        [MenuItem("Mogze/Create/AudioDictionary")]
        static void CreateAudioDictionary()
        {
            AudioDictionary asset = ScriptableObject.CreateInstance<AudioDictionary>();

            AssetDatabase.CreateAsset(asset, "Assets/Resources/AudioDictionary.asset");
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();

            Selection.activeObject = asset;
        }
    }
}