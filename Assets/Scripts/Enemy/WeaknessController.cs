using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class WeaknessController : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> m_weaknesses;

        


        private bool m_isAppQuiting = false;

        private void OnEnable()
        {
            CameraManager.Instance.OnSwitchCallback += OnSwitch;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = Quaternion.identity;
        }

        private void OnApplicationQuit()
        {
            m_isAppQuiting = true;
        }

        private void OnDisable()
        {
            if (!m_isAppQuiting)
                CameraManager.Instance.OnSwitchCallback -= OnSwitch;
        }

        public bool HasWeakness()
        {
            for (int i = 0; i < m_weaknesses.Count; i++)
            {
                if (m_weaknesses[i] == null)
                    m_weaknesses.RemoveAt(i--);
            }
            return m_weaknesses.Count > 0;
        }


        void ActiveWeakness(bool active)
        {
            for (int i = 0; i < m_weaknesses.Count; i++)
            {
                if (m_weaknesses[i] == null)
                    m_weaknesses.RemoveAt(i--);
                else
                    m_weaknesses[i]?.SetActive(active);

            }
        }

        void OnSwitch(CameraManager.Dimension state)
        {
            if (state == CameraManager.Dimension.TwoD)
            {
                ActiveWeakness(false);
            }
            else
            {
                ActiveWeakness(true);
            }
        }
    }
}
