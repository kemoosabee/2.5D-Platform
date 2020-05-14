using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _score, _lives;
    private int _coinNum = 0;
    // Start is called before the first frame update
    void Start()
    {
        _score.text = "Coins collected: 0";
        _lives.text = "Lives: 3";
    }

    public void CoinUpdate()
    {
        _coinNum++;
        _score.text = "Coins Collected: " + _coinNum.ToString();
    }

    public void MinusHP(int hp)
    {
        _lives.text = "Lives: " + hp.ToString();
    }
}
