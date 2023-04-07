using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


    public class MoneyBalloon : Balloon
    {
        private MoneyManager moneyManager;

        private void Start()
        {
            base.Start();
            // Get a reference to the MoneyManager script
            moneyManager = FindObjectOfType<MoneyManager>();
        }

        protected override void pop()
        {
            shake.CamShake();
             moneyManager.AddMoney(1);
            Destroy(gameObject);
        }
    }
