using UnityEngine;

public class Task2Script : MonoBehaviour
{
    public int books;
    public double price;
    void Start()
    {
        if(books < 1) { //checks if zero books were bought
            Debug.LogFormat("The Bookstore made $0 at a cost of $0"); 
            return; //ends function to save on resources
        }
        double buyPrice = price * 0.6; //bookstore discount per book
        double amountSpent = buyPrice + 3.0; //cost for first book
        if(books > 1) { //cost for every other book
            amountSpent += ((books - 1) * buyPrice) + ((books - 1) * 0.75);
        }
        double profit = (books * price) - amountSpent; //how much bookstore made
        Debug.LogFormat("Task 2: The Bookstore made ${0} at a cost of ${1}\n", profit, amountSpent);
    }
}
