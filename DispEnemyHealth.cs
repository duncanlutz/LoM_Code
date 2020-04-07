using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DispEnemyHealth : MonoBehaviour
{

    public Text eHealthDisp;
    public GameObject enemyPlayer;

    void Update()
    {
        CharacterStats cStat = enemyPlayer.GetComponent<CharacterStats>();
        eHealthDisp.text = "Enemy Health = " + cStat.currentHealth;
    }
}
