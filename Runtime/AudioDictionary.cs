namespace Mogze.Audio
{
    using System.Collections.Generic;
    using UnityEngine;

    public class AudioDictionary : ScriptableObject
    {
        [SerializeField]
        private AudioClip[] AudioClips;
        private Dictionary<string, AudioClip> _audioClipsByName;

        public AudioClip GetAudioClipByName(string name)
        {
            return _audioClipsByName[name];
        }

        void OnEnable()
        {
            if (AudioClips == null)
                return;

            _audioClipsByName = new Dictionary<string, AudioClip>();
            for (int i = 0; i < AudioClips.Length; i++)
            {
                _audioClipsByName.Add(AudioClips[i].name, AudioClips[i]);
            }
        }
    }
}