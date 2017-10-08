/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class DefaultTrackableEventHandler : MonoBehaviour,
                                                ITrackableEventHandler
    {
        public bool IsRenderYellow;
        public bool IsRenderBlue;
        public bool IsRenderGreen;
        public bool IsRenderRed;
        public bool IsRenderWhite;

        public bool hpCapacity;
        public bool armorCapacity;
        public bool attackCapacity;

        public float ytrackingTimer;
        public float btrackingTimer;
        public float gtrackingTimer;

        private TrackableBehaviour mTrackableBehaviour;
        private bool isRender;

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();
            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }

            hpCapacity = true;
            armorCapacity = true;
            attackCapacity = true;
        }


        public void OnTrackableStateChanged(
                                        TrackableBehaviour.Status previousStatus,
                                        TrackableBehaviour.Status newStatus)
        {
            if (newStatus == TrackableBehaviour.Status.DETECTED ||
                newStatus == TrackableBehaviour.Status.TRACKED ||
                newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
            {
                OnTrackingFound();
            }
            else
            {
                OnTrackingLost();
            }
        }

        private void OnTrackingFound()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);


            // Enable rendering:
            foreach (Renderer component in rendererComponents)
            {
                component.enabled = true;
            }

            // Enable colliders:
            foreach (Collider component in colliderComponents)
            {
                component.enabled = true;
            }

            if (this.gameObject.tag == "ArmorResources")
            {
                // 방어력(돌 자원)마커 인식 => 1.5초 이상 인식하면 돌 수집
                // 1.5초당 1개 최대 20개 수집 가능
                // 최대 머무는 시간 30초
                // 무게 0.5kg 최대 운반시 무게 10kg
                // 방어력 건물 생성을 위해 필요한 자원수 : 10
                IsRenderYellow = true;
            }

            if (this.gameObject.tag == "HpResources")
            {
                // Hp(벽돌) 마커 인식 => 1초 이상 인식하면 벽돌 수집
                // 1초당 1개 최대 30개
                // 최대 머무는 시간 30초
                // 무게 0.2kg 최대 운반시 무게 6kg
                IsRenderBlue = true;
            }

            if (this.gameObject.tag == "AttackResources")
            {
                // attk(나무) 마커 인식 => 0.5초 이상 인식하면 나무 수집
                // 초당 1개 최대 60개
                // 최대 머무는 시간 30초
                // 무게 0.05kg 최대 운반시 무게 3kg
                IsRenderGreen = true;
            }

            if (this.gameObject.tag == "Build")
            {
                // 건물을 지을 수 있는 상태
                IsRenderRed = true;
                isRender = true;
            }

            if (this.gameObject.tag == "EnemyArea")

            {
                IsRenderWhite = true;
            }
        }


        private void OnTrackingLost()
        {
            Renderer[] rendererComponents = GetComponentsInChildren<Renderer>(true);
            Collider[] colliderComponents = GetComponentsInChildren<Collider>(true);

            //// Disable rendering:
            foreach (Renderer component in rendererComponents)
            {
                if (isRender)
                {
					if (component.transform.parent.gameObject.tag == "AttkUnit")
                    {
                        component.enabled = true;
                    }
                    else
                    {
                        component.enabled = false;
                    }
                }
                else
                {
                    component.enabled = false;
                }
            }

            // Disable colliders:
            foreach (Collider component in colliderComponents)
            {
                if (isRender)
                {
                    if (component.transform.parent.gameObject.tag == "AttkUnit")
                    {
                        component.enabled = true;
                    }
                    else
                    {
                        component.enabled = false;
                    }
                }
                else
                {
                    component.enabled = false;
                }
            }

            if (this.gameObject.tag == "ArmorResources")
            {
                IsRenderYellow = false;
                ytrackingTimer = 0;
            }

            if (this.gameObject.tag == "HpResources")
            {
                IsRenderBlue = false;
                btrackingTimer = 0;
            }

            if (this.gameObject.tag == "AttackResources")
            {
                IsRenderGreen = false;
                gtrackingTimer = 0;
            }

            if (this.gameObject.tag == "Build")
            {
                IsRenderRed = false;
            }

        }
    }
}
