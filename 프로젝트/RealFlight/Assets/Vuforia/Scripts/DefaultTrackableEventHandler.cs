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
                // ����(�� �ڿ�)��Ŀ �ν� => 1.5�� �̻� �ν��ϸ� �� ����
                // 1.5�ʴ� 1�� �ִ� 20�� ���� ����
                // �ִ� �ӹ��� �ð� 30��
                // ���� 0.5kg �ִ� ��ݽ� ���� 10kg
                // ���� �ǹ� ������ ���� �ʿ��� �ڿ��� : 10
                IsRenderYellow = true;
            }

            if (this.gameObject.tag == "HpResources")
            {
                // Hp(����) ��Ŀ �ν� => 1�� �̻� �ν��ϸ� ���� ����
                // 1�ʴ� 1�� �ִ� 30��
                // �ִ� �ӹ��� �ð� 30��
                // ���� 0.2kg �ִ� ��ݽ� ���� 6kg
                IsRenderBlue = true;
            }

            if (this.gameObject.tag == "AttackResources")
            {
                // attk(����) ��Ŀ �ν� => 0.5�� �̻� �ν��ϸ� ���� ����
                // �ʴ� 1�� �ִ� 60��
                // �ִ� �ӹ��� �ð� 30��
                // ���� 0.05kg �ִ� ��ݽ� ���� 3kg
                IsRenderGreen = true;
            }

            if (this.gameObject.tag == "Build")
            {
                // �ǹ��� ���� �� �ִ� ����
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
