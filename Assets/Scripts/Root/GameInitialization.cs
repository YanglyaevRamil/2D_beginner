using UnityEngine;

internal sealed class GameInitialization
{
    public GameInitialization(Controllers controllers, Data data, Camera camera, SpriteRenderer background)
    { 
        var userInput = new UserInput();
        var paralax = new ParalaxController(camera, background.transform);

        var playerBuilder = new BuilderPlayer();
        var playerGO = playerBuilder.GetGO(PlayerCnst.PATH_GO);
        var player = new Player(userInput, data.Player, playerGO);

        camera.transform.SetParent(playerGO.transform); // ??? crutch ???

        controllers.Add(userInput);
        controllers.Add(paralax);
        controllers.Add(player);
    }
}