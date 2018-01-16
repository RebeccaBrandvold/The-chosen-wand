using UnityEngine;
using System.Collections;
//Holds the different objects
[System.Serializable]//Tells unity that we can save all the variables in the script. 
public class Game  {
    public static Game current;
    public Character player;
    public Character animal;
    
    public Game()
    {
        player = new Character();
        animal = new Character();
    }
}
