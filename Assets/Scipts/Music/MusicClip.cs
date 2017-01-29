using UnityEngine;

namespace Brawler.Music
{
    [CreateAssetMenu(menuName = "Music Clip")]
    public class MusicClip : ScriptableObject
    {
        public string ClipName { get { return _clipName; } set { _clipName = value; } }
        public bool Loop { get { return _loop; } set { _loop = value; } }
        public ClipType ClipType { get { return _clipType; } set { _clipType = value; } }
        public AudioClip AudioClip { get { return _audioClip; } set { _audioClip = value; } }
        
        [SerializeField] private string _clipName;
        [SerializeField] private bool _loop;
        [SerializeField] private ClipType _clipType;
        [SerializeField] private AudioClip _audioClip;
        [SerializeField] [Range(0,1)] private float _volume;

        private AudioSource _source;
        
        public void Init(AudioSource source, float volume)
        {
            _source = source;
            _volume += volume;
            
            _source.clip = _audioClip;
            _source.volume = _volume;
            _source.loop = _loop;
        }

        public void Play()
        {
            _source.Play();
        }

        public void Stop()
        {
            _source.Stop();
        }
    }
}