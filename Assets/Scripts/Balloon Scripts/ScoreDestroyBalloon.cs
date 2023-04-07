using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   public class ScoreDestroyBalloon : Balloon
    {
        public SpawnManager spawnManager;
        private List<GameObject> activeBalloons = new List<GameObject>();
        public IceBalloon iceBalloon;

        protected override void Start()
        {
            base.Start();
            spawnManager = FindObjectOfType<SpawnManager>();
            // Add all balloons to the activeBalloons list at the start of the game
            GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
            foreach (GameObject balloon in balloons)
            {
                activeBalloons.Add(balloon);
            }
        }

        protected override void pop()
        {
        shake.CamShake();
        if (isFrozen() == false)
            {
                scoreManager.AddScore(20);
                DestroyAllBalloons();
                Destroy(gameObject);
            }
            else
            {
                scoreManager.AddScore(1);
                Destroy(gameObject);
            }
        }

        private bool isFrozen()
        {
            IceBalloon iceBalloon = GetComponent<IceBalloon>();
            if (iceBalloon != null)
            {
                return iceBalloon.frozen;
            }
            return false;
        }

        private void DestroyAllBalloons()
        {
            GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");

            foreach (GameObject balloon in balloons)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(balloon.transform.position);
                if (screenPos.x >= 0 && screenPos.x <= Screen.width && screenPos.y >= 0 && screenPos.y <= Screen.height && screenPos.z >= 0)
                {
                    Destroy(balloon);
                }
            }

        }


        protected override void OnMouseDown()
        {
            if (!isPopped)
            {
                pop();
                isPopped = true;
                GetComponent<SpriteRenderer>().sprite = balloonSprites[1];
                rb2d.velocity = Vector2.zero;
                rb2d.AddForce(force, ForceMode2D.Impulse);

                AudioSource.PlayClipAtPoint(popSound, transform.position);
                gameController.PlayBalloonPopSound();
            }
        }

        private void OnDestroy()
        {
            // Remove this balloon from the activeBalloons list when it's destroyed
            activeBalloons.Remove(gameObject);
        }
    }

