using System;
using UnityEngine;


namespace UnityStandardAssets.Effects
{
    public class FireExtinguisher : MonoBehaviour
    {
        public ParticleSystem[] hoseWaterSystems;
        public Renderer systemRenderer;
        public float maxPower = 25;
        public float minPower = 1;
        public float changeSpeed = 0.1f;

        private float m_Power;

        // Update is called once per frame
        private void Update()
        {
            m_Power = Mathf.Lerp(m_Power, maxPower, Time.deltaTime * changeSpeed);

            foreach (var system in hoseWaterSystems)
            {
                ParticleSystem.MainModule mainModule = system.main;

                mainModule.startSpeed = m_Power;

                var emission = system.emission;

                emission.enabled = (m_Power > minPower * 1.1f);
            }
        }
    }
}
