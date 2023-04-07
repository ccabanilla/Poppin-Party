using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class IceBalloon : Balloon
    {
        public float freezeDuration = 5f;
        public ScoreManager scoreManager;

        public bool frozen = false;
        private List<GameObject> balloons = new List<GameObject>();

        protected override void Start()
        {
            base.Start();
        }
        protected override void pop()
        {
            shake.CamShake();
            freezeAllBalloons();
            scoreManager.AddScore(1);

            Destroy(gameObject);

            Invoke("UnfreezeAllBalloons", freezeDuration);
        }

        public void freezeAllBalloons()
        {
            if (!frozen)
            {
                SpawnManager.Instance.StopSpawning();

                GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");

                foreach (GameObject balloon in balloons)
                {
                    Vector3 screenPos = Camera.main.WorldToScreenPoint(balloon.transform.position);
                    if (screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y >= 0 && screenPos.y <= Screen.height && screenPos.z >= 0)
                    {
                        balloon.GetComponent<Balloon>().Freeze(freezeDuration);
                    }
                }


                // Resume spawning after freeze duration
                Invoke("UnfreezeAllBalloons", freezeDuration);
                frozen = true;
            }
        }

        public void UnfreezeAllBalloons()
        {
            ResetAllBalloons();
            SpawnManager.Instance.ResumeSpawning();
            frozen = false;
        }

        private void ResetAllBalloons()
        {
            GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");

            foreach (GameObject balloon in balloons)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(balloon.transform.position);
                if (screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y >= 0 && screenPos.y <= Screen.height && screenPos.z >= 0)
                {
                    balloon.GetComponent<Balloon>().ResetBalloon();
                }
            }

        }
    }