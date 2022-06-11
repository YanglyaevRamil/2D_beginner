using UnityEngine;

internal sealed class GameInitialization
{
    public GameInitialization(Controllers controllers, Data data, Camera camera, SpriteRenderer background)
    { 
        var userInput = new UserInput();
        var paralax = new ParalaxController(camera, background.transform);

        var loadPrefCharacter = new LoaderPrefabs(data.CharacterPrefPath);
        var playerGO = loadPrefCharacter.GetGO(CharacterType.Player);

        playerGO.transform.position += new Vector3(0,1,0);

        var player = new Player(userInput, data.Player, playerGO);

        camera.transform.SetParent(playerGO.transform); // ??? crutch ???

        controllers.Add(userInput);
        controllers.Add(paralax);
        controllers.Add(player);
    }
}