using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] int startingBalance = 1000;
    [SerializeField] int currentBalance;
    [SerializeField] TextMeshProUGUI displayBalance;
    public int CurrentBalance { get { return currentBalance; } }

    private void Awake() {
        currentBalance = startingBalance;
        UpdateDisplay();    
    }

    public void Deposit(int amount){
        currentBalance += Mathf.Abs(amount);
        UpdateDisplay();    
    }

    public void WithDraw(int amount){
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplay();
        if(currentBalance < 0){
            ReloadScene();
        }
    }

    void UpdateDisplay(){
        displayBalance.text = "Gold : " + currentBalance;
    }

    void ReloadScene(){
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
