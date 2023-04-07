using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyManager : MonoBehaviour
{
    public int startingMoney = 0;
    public int currentMoney = 0;
    public TextMeshProUGUI moneyDisplay;

    private void Start()
    {
        currentMoney = PlayerPrefs.GetInt("Money", startingMoney);
        UpdateMoneyDisplay();
    }

    private void OnDestroy()
    {
        PlayerPrefs.SetInt("Money", currentMoney);
        PlayerPrefs.Save();
    }

    public void AddMoney(int amount)
    {
        currentMoney += amount;
        UpdateMoneyDisplay();
    }

    public bool SpendMoney(int amount)
    {
        if (currentMoney >= amount)
        {
            currentMoney -= amount;
            UpdateMoneyDisplay();
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ResetMoney()
    {
        currentMoney = startingMoney;
        PlayerPrefs.SetInt("Money", startingMoney);
        UpdateMoneyDisplay();
    }

    private void UpdateMoneyDisplay()
    {
        if (moneyDisplay != null)
        {
            moneyDisplay.text = "$" + currentMoney.ToString();
        }
    }
}
