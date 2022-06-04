using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 250;
    [SerializeField] TextMeshProUGUI goldBalanceText;

    int currentBalance;
    public int CurrentBalance { get { return currentBalance; } }

    void Awake()
    {
        currentBalance = startingBalance;
        UpdateBalance();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateBalance();
    }

    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateBalance();

        if (currentBalance < 0)
        {
            Invoke("ReloadScene", 1f);
        }
    }

    void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    void UpdateBalance()
    {
        goldBalanceText.text = "Gold: " + currentBalance.ToString();
    }
}
