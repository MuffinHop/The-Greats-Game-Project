using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private bool _redPerson;
    [SerializeField] private bool _greenPerson;
    [SerializeField] private bool _bluePerson;

    void Update()
    {
        if (Vector3.Distance(_player.transform.position, transform.position) < 6f)
        {
            if (_redPerson)
            {
                _player.TurnRed();
            }
            if (_greenPerson)
            {
                _player.TurnGreen();
            }
            if (_bluePerson)
            {
                _player.TurnBlue();
            }
            transform.LookAt(_player.transform);
        }
    }
}
