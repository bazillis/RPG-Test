using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using UnityEngine;

namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 5f;
        [SerializeField] PatrolPath patrolPath;

        Fighter fighter;
        GameObject player;
        Health health;
        Mover mover;

        Vector3 guardLocation;
        float timeSinceLastSeenPlayer = Mathf.Infinity;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            player = GameObject.FindWithTag("Player");
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            guardLocation = transform.position;
        }

        public void Update()
        {
            if (health.IsDead()) return;
            if (player != null && InAttackRange() && fighter.CanAttack(player.gameObject))
            {
                timeSinceLastSeenPlayer = 0f;
                fighter.Attack(player.gameObject);
            }
            else if (timeSinceLastSeenPlayer < suspicionTime)
            {
                GetComponent<ActionScheduler>().CancelCurrentAction();
            }
            else
            {
                mover.StartMoveAction(guardLocation);
            }
            timeSinceLastSeenPlayer += Time.deltaTime;
        }

        private bool InAttackRange()
        {
            return Vector3.Distance(transform.position, player.transform.position) <= chaseDistance;
        }

        // called by unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}