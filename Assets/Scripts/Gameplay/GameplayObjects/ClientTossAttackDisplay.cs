using System;
using Gameplay.GameplayObjects;
using Unity.Netcode;
using UnityEditor;
using UnityEngine;

namespace Unity.Multiplayer.Samples.BossRoom.Client
{
    public class ClientTossAttackDisplay : NetworkBehaviour
    {
        [SerializeField]
        Transform m_TossAttackDisplayTransform;

        const float k_DisplayHeight = 0.1f;

        readonly Quaternion k_TossAttackRadiusDisplayRotation = Quaternion.Euler(90f, 0f, 0f);
        readonly Quaternion k_TossAttackParticlesDisplayRotation = Quaternion.Euler(-90f, 0f, 0f);
        
        [SerializeField]
        NetworkTossAttackState m_NetState;

        [SerializeField] 
        ParticleSystem m_ParticleSystem;
        
        [SerializeField] 
        ParticleSystem m_RadiusParticleSystem;
        
        [SerializeField] 
        GameObject m_TossedObjectGraphics;

        [SerializeField]
        AudioSource m_FallingSound;
        
        [SerializeField]
        AudioSource m_ExplosionSound;

        void Awake()
        {
            enabled = false;
        }

        public override void OnNetworkSpawn()
        {
            if (!IsClient)
            {
                return;
            }

            enabled = true;
            m_TossAttackDisplayTransform.gameObject.SetActive(true);
            m_TossedObjectGraphics.SetActive(true);
            m_NetState.DetonateEvent += OnDetonate;
            m_FallingSound.Play();
        }

        public override void OnNetworkDespawn()
        {
            m_TossAttackDisplayTransform.gameObject.SetActive(false);
            m_NetState.DetonateEvent -= OnDetonate;
        }
        
        void LateUpdate()
        {
            var tossedItemPosition = transform.position;
            m_TossAttackDisplayTransform.SetPositionAndRotation(
                new Vector3(tossedItemPosition.x, k_DisplayHeight, tossedItemPosition.z),
                k_TossAttackRadiusDisplayRotation);
            m_ParticleSystem.transform.SetPositionAndRotation(new Vector3(tossedItemPosition.x, k_DisplayHeight, tossedItemPosition.z),
                k_TossAttackParticlesDisplayRotation);
        }

        private void OnDetonate()
        {
            m_TossedObjectGraphics.SetActive(false);
            m_ParticleSystem.Play();
            m_RadiusParticleSystem.Stop();
            m_ExplosionSound.Play();
        }
    }
}
