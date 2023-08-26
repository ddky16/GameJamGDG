using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    private Player _player;

    public TMP_InputField movementField;
    public TMP_InputField jumpField;

    private void Start()
    {
        _player = FindAnyObjectByType<Player>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            _player.speedAmount = float.Parse(movementField.text);
            _player.jumpAmount = float.Parse(jumpField.text);
        }
    }
}
