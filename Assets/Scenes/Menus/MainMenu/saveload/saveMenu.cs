using UnityEngine;
using System.Collections;

public class saveMenu : MonoBehaviour {


    public enum Menu
    {
        MainMenu,
        NewGame,
        Continue
    }

    public Menu currentMenu;

    void OnGUI()
    {

        GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
        GUILayout.BeginHorizontal();
        GUILayout.FlexibleSpace();
        GUILayout.BeginVertical();
        GUILayout.FlexibleSpace();

        if (currentMenu == Menu.MainMenu) //First menu choose Make new game/Save or load already saved file
        {          
            if (GUILayout.Button("New Game"))
            {
                Game.current = new Game();//new save/save over?
                currentMenu = Menu.NewGame;
            }

            if (GUILayout.Button("Continue"))
            {
                saveLoad.Load();//Load the already saved
                currentMenu = Menu.Continue;
            }

            if (GUILayout.Button("Quit"))
            {
                Application.Quit();
            }
        }

        else if (currentMenu == Menu.NewGame) //Second menu
        {

            GUILayout.Box("Choose where to save");
            GUILayout.Space(10);

            GUILayout.Label("Player");
            Game.current.player.name = GUILayout.TextField(Game.current.player.name, 20);
            GUILayout.Label("animal");
            Game.current.animal.name = GUILayout.TextField(Game.current.animal.name, 20);

            if (GUILayout.Button("Save"))
            {
                //Save the current Game as a new saved Game
                saveLoad.Save();
                //Move on to game...
                Application.LoadLevel(1);
            }

            GUILayout.Space(10);
            if (GUILayout.Button("Cancel"))
            {
                currentMenu = Menu.MainMenu;
            }

        }

        else if (currentMenu == Menu.Continue)
        {
            //Load already saved game
            GUILayout.Box("Select Save File");
            GUILayout.Space(10);

            foreach (Game g in saveLoad.savedGames)
            {
                if (GUILayout.Button(g.player.name + " - " + g.animal.name))
                {
                    Game.current = g;
                    //Move on to game...
                    Application.LoadLevel(1);
                }

            }

            GUILayout.Space(10);
            if (GUILayout.Button("Cancel"))
            {
                currentMenu = Menu.MainMenu;
            }

        }

        GUILayout.FlexibleSpace();
        GUILayout.EndVertical();
        GUILayout.FlexibleSpace();
        GUILayout.EndHorizontal();
        GUILayout.EndArea();

    }
}

/*
if(GUILayout.Button("Save")) {
				//Save the current Game as a new saved Game
				SaveLoad.Save();
				//Move on to game...
				Application.LoadLevel(1);
			}
       
  foreach(Game g in SaveLoad.savedGames) {
				if(GUILayout.Button(g.knight.name + " - " + g.rogue.name + " - " + g.wizard.name)) {
					Game.current = g;
					//Move on to game...
					Application.LoadLevel(1);
				}
                */