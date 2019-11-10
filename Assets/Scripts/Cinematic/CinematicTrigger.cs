using UnityEngine;
using UnityEngine.Playables;

namespace RPG.Cinematic
{
    public class CinematicTrigger : MonoBehaviour
    {
        bool isAlreadyTriggered = false;

        private void OnTriggerEnter(Collider other)
        {
            if (!isAlreadyTriggered && other.gameObject.tag == "Player")
            {
                GetComponent<PlayableDirector>().Play();
                isAlreadyTriggered = true;
            }
        }
    }
}
