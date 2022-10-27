using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Toolbox : MonoBehaviour
{
    public Animator animCoin;

    private float randomNumber;

    public int player1Wins;
    public int player1Black;
    public int player1White;

    public int player2Wins;
    public int player2Black;
    public int player2White;

    //-1 means player one / black & 1 means player two / white
    public int playerTurn = -1;
    public int coinChoise = -1;
    public int coinResult;
    bool canFlip = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        randomNumber = Random.Range(-10f, 10f);
        if (Input.GetKeyDown(KeyCode.Space) && canFlip == true)
        {
            FlipCoin();
        }

        if (Input.GetKeyDown(KeyCode.E) && canFlip == true)
        {
            canFlip = false;
            Invoke("BlackSide", 0.5f);
            animCoin.SetBool("ChangeToBlack", true);
        }

        if (Input.GetKeyDown(KeyCode.Q) && canFlip == true)
        {
            canFlip = false;
            Invoke("WhiteSide", 0.5f);
            animCoin.SetBool("ChangeToWhite", true);
        }
        //ChooseTurn();
    }

    public void BlackSide()
    {
        canFlip = true;
        coinChoise = -1;
        animCoin.SetBool("ChangeToBlack", false);
    }

    public void WhiteSide()
    {
        canFlip = true;
        coinChoise = 1;
        animCoin.SetBool("ChangeToWhite", false);
    }

    void CollectPoint1()
    {
        player1Wins++;
        if(coinResult == -1)
        {
            player1Black++;
        } 
        else if (coinResult == 1)
        {
            player1White++;
        }
    }

    void CollectPoint2()
    {
        player2Wins++;
        if (coinResult == -1)
        {
            player2Black++;
        }
        else if (coinResult == 1)
        {
            player2White++;
        }
    }

    void FlipCoin()
    {
        canFlip = false;
        if (randomNumber > 0)
        {
            animCoin.SetBool("FlipBlack", true);
            coinResult = -1;
        }
        else if (randomNumber <= 0)
        {
            animCoin.SetBool("FlipWhite", true);
            coinResult = 1;
        }
        if (coinChoise == coinResult)
        {
            if (playerTurn == -1)
            {
                CollectPoint1();
            }
            else if (playerTurn == 1)
            {
                CollectPoint2();
            }
        }

        Invoke("EndTurn", 1.1f);
    }

    void EndTurn()
    {
        playerTurn = -playerTurn;
        animCoin.SetBool("FlipWhite", false);
        animCoin.SetBool("FlipBlack", false);
        canFlip = true;
    }
}
