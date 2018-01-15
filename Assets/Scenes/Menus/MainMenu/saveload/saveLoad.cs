using UnityEngine;
using System.Collections;
using System.Collections.Generic;//Sånn at man kan bruke Dynamic lister i C#
using System.Runtime.Serialization.Formatters.Binary;//Så vi kan bruke opperativ systemets serialization muligheter i skriptet
using System.IO;//IO = Input/Output. Gjør sånn at vi får lov til å skrive og lese fra pc'n eller mobilen Gjør at vi kan lage unike filer og lese fra disse filene senere.

public class saveLoad {
    //List of type the type Game called savedGames. This is a static List. 
    public static List<Game> savedGames = new List<Game>();

//Static Save Game function. Static so that we can call it anywhere. 
public static void Save()
{
   
        savedGames.Add(Game.current);//Adds current game to list of saved games
        BinaryFormatter bf = new BinaryFormatter();//Need to create a new BinaryFormatter to serialze the list.
        //filestream is a pathway to the new file. File.Create creates the new file at the location. Unity has a built in location to store game files.
        //The builtin location updates automatically. savedGames->filename and gd->game data example options.gd if you want to save user options differently
        //Game data can have a different name, what kind of file it is. bob.fries
        //put Application.persistentDataPath into debug.log to know where save games are located(if needed)
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.gd");
        //Save the list to the new file. 
        bf.Serialize(file, saveLoad.savedGames);
        file.Close();//Closes the file
    }

    public static void Load()
    {//Checks if a save file already exists.
        if(File.Exists(Application.persistentDataPath + "/savedGames.gd"))
        {//Create the BinaryFormatter just like in the save function. 
            BinaryFormatter bf = new BinaryFormatter();
            //Opens file instead of create and points to where the saved game file lies by using Application.persistentDataPath
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.gd", FileMode.Open);
            //bf.Deserialize(file) finds the file at the location mentioned about and deserializes it. 
            //Converts/casts the deserialized file to the datatype we want it to be. That is a List here. 
            //Then the list is set as our list of saved games.
            saveLoad.savedGames = (List<Game>)bf.Deserialize(file);
            file.Close();//Closes the file
        }
    }
}