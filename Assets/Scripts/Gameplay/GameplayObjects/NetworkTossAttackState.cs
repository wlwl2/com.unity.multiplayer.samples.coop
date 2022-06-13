using Unity.Netcode;

namespace Gameplay.GameplayObjects
{
    /// <summary>
    /// Shared state for a TossAttack.
    /// </summary>
    public class NetworkTossAttackState : NetworkBehaviour
    {
        /// <summary>
        /// This event is raised when the toss attack detonates.
        /// </summary>
        public System.Action DetonateEvent;

        [ClientRpc]
        public void DetonateClientRPC()
        {
            DetonateEvent?.Invoke();
        }
    }
}