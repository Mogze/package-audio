namespace Mogze.Audio
{
    using System.Threading.Tasks;
    using Mogze.Core.Services;
    using UnityEngine;

    public class AudioService : IService
    {
        private AudioDictionary _audioDictionary;
        private readonly AudioSource _audioSource;
        private readonly AudioSource _audioSourcePitched;
        public bool IsMuted { private set; get; }

        public AudioService(Transform parent, AudioDictionary audioDictionary)
        {
            _audioDictionary = audioDictionary;
            var audioObject = new GameObject("AudioService");
            audioObject.transform.SetParent(parent);
            _audioSource = audioObject.AddComponent<AudioSource>();
            _audioSourcePitched = audioObject.AddComponent<AudioSource>();
            _audioSource.volume = _audioSourcePitched.volume = 0.4f;
        }

        public async Task Initialize()
        {
            await Task.Yield();
        }

        public void Play(string name)
        {
            if (IsMuted)
                return;

            _audioSource.PlayOneShot(_audioDictionary.GetAudioClipByName(name));
        }

        public void Play(string name, float pitch)
        {
            if (IsMuted)
                return;

            _audioSourcePitched.pitch = pitch;
            _audioSourcePitched.PlayOneShot(_audioDictionary.GetAudioClipByName(name));
        }

        public bool ToggleSound()
        {
            IsMuted = !IsMuted;

            return IsMuted;
        }

        public void Pause(bool isPaused)
        {
        }

        public void Close()
        {
        }
    }
}
