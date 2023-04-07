using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shop : MonoBehaviour
{
    public SpawnBalloons spawnBalloons;
    public SpawnManager spawnManager;
    public MoneyManager moneyManager;
    public Button basicButton;
    public Button heartButton;
    public Button bearButton;
    public Button bubbleButton;
    public Button starButton;
    public int basic = 0;
    public int heart = 15;
    public int bear = 20;
    public int bubble = 5;
    public int star = 10;
    public TextMeshProUGUI shopkeeper;

    void Start()
    {
         spawnBalloons = FindObjectOfType<SpawnBalloons>();
         spawnManager = FindObjectOfType<SpawnManager>();
         moneyManager = FindObjectOfType<MoneyManager>();
         basicButton.onClick.AddListener(SetBasicBalloonPrefab);
         heartButton.onClick.AddListener(SetHeartBalloonPrefab);
         bearButton.onClick.AddListener(SetBearBalloonPrefab);
         bubbleButton.onClick.AddListener(SetBubbleBalloonPrefab);
         starButton.onClick.AddListener(SetStarBalloonPrefab);
    }

    public void SetBasicBalloonPrefab()
    {
        if (CanAffordBalloon(basic) && !IsBalloonPurchased("Basic"))
        {
            spawnManager.SetBalloonPrefab("Basic");
            GameManager.prefabName = "Basic";
            moneyManager.SpendMoney(basic);
            PlayerPrefs.SetInt("Basic", 1);
            Debug.Log("Basic Saved!");
            shopkeeper.text = "Good Choice! " +
                "I love the basic balloon!";
        }
        else
        {
            Debug.Log("Not enough money!");
            shopkeeper.text = "oops! " +
                "not enough money";
        }

        if (IsBalloonPurchased("Basic"))
        {
            spawnManager.SetBalloonPrefab("Basic");
            GameManager.prefabName = "Basic";
            shopkeeper.text = "you are now " +
                "using the basic balloon!";
        }

    }

    public void SetHeartBalloonPrefab()
    {
        if (CanAffordBalloon(heart) && !IsBalloonPurchased("Heart"))
        {
            spawnManager.SetBalloonPrefab("Heart");
            GameManager.prefabName = "Heart";
            moneyManager.SpendMoney(heart);
            PlayerPrefs.SetInt("Heart", 1);
            Debug.Log("Heart Saved!");
            shopkeeper.text = "my favorite! " +
                "I love the heart balloon!";
        }
        else
        {
            Debug.Log("Not enough money!");
            shopkeeper.text = "oops! " +
               "not enough money";
        }

        if (IsBalloonPurchased("Heart"))
        {
            spawnManager.SetBalloonPrefab("Heart");
            GameManager.prefabName = "Heart";
            shopkeeper.text = "you are now " +
                "using the heart balloon!";
        }
    }

    public void SetBearBalloonPrefab()
    {

        if (CanAffordBalloon(bear) && !IsBalloonPurchased("Bear"))
        {
            spawnManager.SetBalloonPrefab("Bear");
            GameManager.prefabName = "Bear";
            moneyManager.SpendMoney(bear);
            PlayerPrefs.SetInt("Bear", 1);
            Debug.Log("Bear Saved!");
            shopkeeper.text = "super cute! " +
            "I love the bear balloon!";
        }
        else
        {
            Debug.Log("Not enough money!");
            shopkeeper.text = "oops! " +
               "not enough money";
        }

        if (IsBalloonPurchased("Bear"))
        {
            spawnManager.SetBalloonPrefab("Bear");
            GameManager.prefabName = "Bear";
            shopkeeper.text = "you are now " +
                "using the bear balloon!";
        }

    }

    public void SetBubbleBalloonPrefab()
    {
        if (CanAffordBalloon(bubble) && !IsBalloonPurchased("Bubble"))
        {
            spawnManager.SetBalloonPrefab("Bubble");
            GameManager.prefabName = "Bubble";
            moneyManager.SpendMoney(bubble);
            PlayerPrefs.SetInt("Bubble", 1);
            Debug.Log("Bubble Saved!");
            shopkeeper.text = "ooh! " +
            "I love the bubble balloon!";
        }
        else
        {
            Debug.Log("Not enough money!");
            shopkeeper.text = "oops! " +
               "not enough money";
        }

        if (IsBalloonPurchased("Bubble"))
        {
            spawnManager.SetBalloonPrefab("Bubble");
            GameManager.prefabName = "Bubble";
            shopkeeper.text = "you are now " +
                "using the bubble balloon!";
        }

    }

    public void SetStarBalloonPrefab()
    {
        if (CanAffordBalloon(star) && !IsBalloonPurchased("Star"))
        {
            spawnManager.SetBalloonPrefab("Star");
            GameManager.prefabName = "Star";
            moneyManager.SpendMoney(star);
            PlayerPrefs.SetInt("Star", 1);
            Debug.Log("Star Saved!");
            shopkeeper.text = " " +
           "Reach for the stars!";
        }
        else
        {
            Debug.Log("Not enough money!");
            shopkeeper.text = "oops! " +
               "not enough money";
        }

        if (IsBalloonPurchased("Star"))
        {
            spawnManager.SetBalloonPrefab("Star");
            GameManager.prefabName = "Star";
            shopkeeper.text = "you are now " +
                "using the star balloon!";
        }
    }

    // Check if the player has enough money to purchase the balloon
    public bool CanAffordBalloon(int price)
    {
        return moneyManager.currentMoney >= price;
    }

    // Check if the player has already purchased the balloon
    public bool IsBalloonPurchased(string balloonType)
    {
        return PlayerPrefs.GetInt(balloonType, 0) == 1;
    }

    public void resetShop()
    {
        Debug.Log("Button Clicked");
        PlayerPrefs.SetInt("Basic", 0);
        PlayerPrefs.SetInt("Heart", 0);
        PlayerPrefs.SetInt("Bubble", 0);
        PlayerPrefs.SetInt("Bear", 0);
        PlayerPrefs.SetInt("Star", 0);
        Debug.Log("Shop Reset");
    }

}
