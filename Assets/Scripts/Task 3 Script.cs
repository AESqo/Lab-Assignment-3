using UnityEngine;

public class Task3Script : MonoBehaviour
{
	public double first;
    	public double won;
    	public double lost;
    	void Start() {
        	double[] ahmed = {60, 80, 40}; //{first serve odds, won last serve odds, lost last serve odds}
        	double[] emma = {first, won, lost}; //same as above
        	double ahmedChance = oddsCalc(ahmed); //ahmed's chance to win
        	double emmaChance = oddsCalc(emma); //emma's chance to win
        	Debug.LogFormat("Ahmed has a {0:F2}% chance to win and Emma has a {1:F2}% chance to win.\n", ahmedChance, emmaChance);
    }
	public static double oddsCalc(double[] oldPlayer) {
        	double[] player = new double[3];
        	System.Array.Copy(oldPlayer, 0, player, 0, 3); //prevents reference to oldPlayer
        	player[0] = player[0] / 100.0; //changes percent to decimal for easy math
        	player[1] = player[1] / 100.0;
        	player[2] = player[2] / 100.0;
        	return ((player[0] * probs(1, 0, true, player)) + ((1 - player[0]) * probs(0, 1, false, player))) * 100; //begining of recursive code
    }
    	public static double probs(int server, int reciever, bool wonPoint, double[] player) {
        	if(server == 4 && reciever <= 2) {return 1.0;} //if server won, add 1 point
        	if(reciever == 4 && server <= 2) {return 0.0;} //if reciever 1, add 1 point
        	if(server == 3 && reciever == 3){return deuce(wonPoint, player);} //if at deuce, go to deuce function
        
        	double nextPoint = wonPoint ? player[1] : player[2]; //if player won, assign won odds and if not assign lost odds

        	return (nextPoint * probs(server + 1, reciever, true, player)) + ((1 - nextPoint) * probs(server, reciever + 1, false, player)); //continues recursive code
    }
    	public static double deuce(bool wonPoint, double[] player) {
        	double thisPoint = wonPoint ? player[1] : player[2]; //assigns odds based on if last point was won or not
        	return (thisPoint * player[1]) / (thisPoint * player[1] + (1 - thisPoint) * (1 - player[2])); //A markov chain formula that handles the odds of eventually winning a deuce stalemate
	}
}