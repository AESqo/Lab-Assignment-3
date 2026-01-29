using UnityEngine;

public class Task1Script : MonoBehaviour
{
    public int cash;
    void Start() {
        int[] bills = new int[6]; //holds how many of each bill there are

    	bills[0] = cash / 100; //adds $100 bills to the first spot in array
	    int currMoney = cash % 100; //the remainder from the previous task
        bills[1] = currMoney / 50; //$50 bills
        currMoney = currMoney % 50; //remainder
        bills[2] = currMoney / 20; //$20 bills
        currMoney = currMoney % 20; //remainder
        bills[3] = currMoney / 10; //$10 bills
        currMoney = currMoney % 10; //remainder
        bills[4] = currMoney / 5; //$5 bills
        currMoney = currMoney % 5; //remainder
        bills[5] = currMoney / 1; //$1 bills
        
        Debug.LogFormat("Task 1: {0}x $100 bills, {1}x $50 bills, {2}x $20 bills, {3}x $10 bills, {4}x $5 bills, {5}x $1 bills\n", bills[0], bills[1], bills[2], bills[3], bills[4], bills[5]); //debug output
    }
}
