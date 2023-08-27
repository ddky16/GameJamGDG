using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseHandler : MonoBehaviour
{
    public enum CheeseState
    {
        Normal,
        BoostSpeed,
        BoostJump
    }

    public CheeseState cheeseState;

    private void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player") && cheeseState == CheeseState.Normal)
        {
            var player = other.GetComponent<Player>();
            GetHealed(player);
        }
        else if (other.CompareTag("Player") && cheeseState == CheeseState.BoostSpeed)
        {
            var player = other.GetComponent<Player>();
            StartCoroutine(player.SpeedBooster());
            GetHealed(player);
        }
        else if (other.CompareTag("Player") && cheeseState == CheeseState.BoostJump)
        {
            var player = other.GetComponent<Player>();
            StartCoroutine(player.JumpBooster());
            GetHealed(player);
        }
    }

    private void GetHealed(Player player)
    {
        player.IncreaseHealth();
        player.cheeseCounter++;

        Destroy(gameObject);
    }
}
