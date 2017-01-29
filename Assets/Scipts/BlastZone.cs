using UnityEngine;
using Brawler.Characters;
using Brawler.GameSettings;
using Brawler.Music;

namespace Brawler.GamePlay
{
    [RequireComponent(typeof(BoxCollider))]
    public class BlastZone : MonoBehaviour
    {
        private void OnTriggerEnter(Collider c)
        {
            var sceneCharacter = c.GetComponent<Character>();

            if (sceneCharacter && sceneCharacter.CurrentStock > 0)
            {
                StartCoroutine(sceneCharacter.Respawn());
                return;
            }

            GameManager.Instance.Announcer.AnnounceDeath();
            Destroy(c.gameObject);
        }
    }
}