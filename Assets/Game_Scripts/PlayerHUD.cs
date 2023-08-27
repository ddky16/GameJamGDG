using System.Collections;
using System.Collections.Generic;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    Player player;

    public TextMeshProUGUI cheeseCounterTxt;
    public Image healthBar;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    private void Update()
    {
        UpdateHealthBar(player.currentHealth, player.maxHealth);
        cheeseCounterTxt.text = $"{player.cheeseCounter} / 16";
    }

    public void UpdateHealthBar(float health, float maxHealth)
    {
        healthBar.fillAmount = health / maxHealth;
    }
}
