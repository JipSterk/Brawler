using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Brawler.SaveLoad;

namespace Brawler.Music
{
    public class MusicManager : MonoBehaviour
    {
        public List<MusicClip> MusicClips { get { return _musicClips; } }
        public static MusicManager Instance { get { return _instance; } }

        [SerializeField] private List<MusicClip> _musicClips = new List<MusicClip>();
        [SerializeField] private AudioSource _backGroundAudioSource;
        [SerializeField] private AudioSource _menuAudioSource;
        [SerializeField] private AudioSource _effectAudioSource;

        private static MusicManager _instance;
        private float _backGroundVolume;
        private float _menuVolume;
        private float _soundEffectsVolume;

        private void Awake()
        {
            if (_instance)
            {
                Destroy(gameObject);
                return;
            }

            _instance = this;
            DontDestroyOnLoad(gameObject);
        }

        private void Start()
        {
            SaveLoadManager.Instance.WhenSaveFileExist += LoadSoundSettings;
        }
        
        public void PlayClip(MusicClip clip)
        {
            switch (clip.ClipType)
            {
                case ClipType.Menu:
                    clip.Init(_menuAudioSource, _menuVolume);
                    break;
                case ClipType.Ingame:
                    clip.Init(_backGroundAudioSource, _backGroundVolume);
                    break;
                case ClipType.Character:
                    clip.Init(_effectAudioSource, _soundEffectsVolume);
                    break;
            }
            clip.Play();
        }

        public void StopClip(MusicClip clip)
        {
            clip.Stop();
        }

        private void LoadSoundSettings(SaveData saveData)
        {
            _backGroundVolume = saveData.Settings.BackGroundVolume;
            _menuVolume = saveData.Settings.MenuVolume;
            _soundEffectsVolume = saveData.Settings.SoundEffectsVolume;
        }

        public MusicClip[] FindClipsByType(ClipType clipType)
        {
            return _musicClips.Where(clip => clip.ClipType == clipType).ToArray();
        }

        public MusicClip GetClipAndPlay(string clipName)
        {
            var musicClip = GetMusicClip(clipName);
            PlayClip(musicClip);
            return musicClip;
        }

        public MusicClip GetMusicClip(string clipName)
        {
            return _musicClips.First(x => x.ClipName == clipName);
        }
    }
}