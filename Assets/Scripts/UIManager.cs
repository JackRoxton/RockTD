using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject GamePanel;
    public GameObject PausePanel;
    public GameObject CardsPanel;
    public GameObject MenuPanel;
    public GameObject GameOverPanel;
    public GameObject WinPanel;

    public TMP_Text WaveText;
    public TMP_Text MoneyText;
    public TMP_Text LifeText;

    public TMP_Text Card1Text1, Card1Text2;
    public TMP_Text Card2Text1, Card2Text2;

    public Button PlayButton, QuitButton;
    public Button Card1, Card2;

    public Image Bite;
    public Image Smash;

    private void Start()
    {
        GamePanel.SetActive(false);
        PausePanel.SetActive(false);
        CardsPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

    private void Update()
    {
        WaveText.text = "Wave : " + EnemyManager.Instance.WaveIndex + "/10";
        MoneyText.text = "Money : " + GameManager.Instance.Money.ToString();
        LifeText.text = "Life : " + GameManager.Instance.Life.ToString();

        Bite.fillAmount = 1 - (GameManager.Instance.Player.GetComponent<Character>().BiteTimer / GameManager.Instance.Player.GetComponent<Character>().BiteCD);
        Smash.fillAmount = 1 - (GameManager.Instance.Player.GetComponent<Character>().SmashTimer / GameManager.Instance.Player.GetComponent<Character>().SmashCD);
    }

    public void Play()
    {
        GamePanel.SetActive(true);
        MenuPanel.SetActive(false);
        GameManager.Instance.Play();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void ShowCards()
    {
        CardsPanel.SetActive(true);
        CardManager.Instance.CardEffect(Card1Text1, Card1Text2, Card2Text1, Card2Text2);
    }

    public void SelectCard(int i)
    {
        switch(i)
        {
            case 0:
                CardManager.Instance.Effects();
                break;
            case 1:
                CardManager.Instance.Effects2();
                break;
        }    
        EnemyManager.Instance.NextWave();
        SoundManager.Instance.Play("Card");
        CardsPanel.SetActive(false);
    }

    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }

    public void Win()
    {
        WinPanel.SetActive(true);
    }
}
