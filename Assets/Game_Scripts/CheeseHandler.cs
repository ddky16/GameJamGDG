using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseHandler : MonoBehaviour
{
    public enum CheeseState
    {
        NORMAL,
        SPEED,
        JUMP
    }

    public CheeseState cheeseState;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            GetHealed(player);
        }
        if (other.CompareTag("Player") && cheeseState == CheeseState.SPEED)
        {
            var player = other.GetComponent<Player>();
            GetHealed(player);
            StartCoroutine(player.SpeedBoosted());
        }
        if (other.CompareTag("Player") && cheeseState == CheeseState.JUMP)
        {
            var player = other.GetComponent<Player>();
            GetHealed(player);
            StartCoroutine(player.JumpBoosted());
        }
    }

    private void GetHealed(Player player)
    {
        player.IncreaseHealth();
        player.cheeseCounter++;

        Destroy(gameObject);
    }
}
