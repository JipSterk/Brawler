using System;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Brawler.SaveLoad;

namespace Brawler.Music
{
    public class MusicManager : MonoBehaviour
    {
        public static MusicManager Instance { get { return _instance ?? new GameObject("Music Manager").AddComponent<MusicManager>(); } }
        public List<MusicClip> MusicClips { get { return _musicClips; } }

        [SerializeField] private List<MusicClip> _musicClips = new List<MusicClip>();
        
        private static MusicManager _instance;
        private AudioSource _backGroundAudioSource;
        private AudioSource _menuAudioSource;
        private AudioSource _effectAudioSource;
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
            _backGroundAudioSource = new GameObject("BackGround").AddComponent<AudioSource>();
            _menuAudioSource = new GameObject("Menu").AddComponent<AudioSource>();
            _effectAudioSource = new GameObject("Effect").AddComponent<AudioSource>();

            _backGroundAudioSource.transform.SetParent(transform);
            _menuAudioSource.transform.SetParent(transform);
            _effectAudioSource.transform.SetParent(transform);
            
            SaveLoadManager.Instance.WhenSaveFileExist += LoadSoundSettings;
        }
        
        public void PlayClip(MusicClip musicClip)
        {
            if(!musicClip)
                return;

            switch (musicClip.ClipType)
            {
                case ClipType.Menu:
                    musicClip.Init(_menuAudioSource, _menuVolume);
                    break;
                case ClipType.Ingame:
                    musicClip.Init(_backGroundAudioSource, _backGroundVolume);
                    break;
                case ClipType.Character:
                    musicClip.Init(_effectAudioSource, _soundEffectsVolume);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("musicClip", musicClip, null);
            }
            musicClip.Play();
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

        public MusicClip GetClipAndPlay(string clipName)
        {
            var musicClip = GetMusicClip(clipName);
            PlayClip(musicClip);
            return musicClip;
        }

        public MusicClip[] FindClipsByType(ClipType clipType)
        {
            return _musicClips.Where(x => x.ClipType == clipType).ToArray();
        }

        public MusicClip GetMusicClip(string clipName)
        {
            return _musicClips.First(x => x.ClipName == clipName);
        }
    }
}