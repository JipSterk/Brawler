using Brawler.Music;
using UnityEngine;

public class Announcer : MonoBehaviour
{
    [SerializeField] private MusicClip _announceDeathClip;

    public void AnnounceDeath()
    {
        MusicManager.Instance.PlayClip(_announceDeathClip);
    }
}