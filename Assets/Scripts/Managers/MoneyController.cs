using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyController : MonoBehaviour
{
    public static MoneyController instance;
    float myMoney;
    TextMeshProUGUI txtMyMoney;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        txtMyMoney = GameObject.Find("MyMoney").GetComponent<TextMeshProUGUI>();
        SetMoney(PlayerPrefs.GetFloat("myMoney", 5000));
    }
    public float GetMoney()
    {
        return myMoney;
    }
    public bool SetMoney(float newMoney)
    {
        if (newMoney > 0)
        {
            myMoney = newMoney;
            PlayerPrefs.SetFloat("myMoney", myMoney);
            txtMyMoney.text = myMoney.ToString();
        }
        return newMoney > 0;
    }
    public bool AddMoney(float extraMoney)
    {
        myMoney += extraMoney;
        return SetMoney(myMoney);
    }
}
