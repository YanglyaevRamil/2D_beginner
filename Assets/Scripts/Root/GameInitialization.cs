using UnityEngine;

internal sealed class GameInitialization
{
    public GameInitialization(Controllers controllers, Data data, Camera camera, SpriteRenderer background)
    { 
        var userInput = new UserInput();
        var paralax = new ParalaxController(camera, background.transform);

        var loadPrefCharacter = new LoaderPrefabs(data.CharacterPrefPath);

        var playerGO = loadPrefCharacter.GetGO(CharacterType.Player);

        playerGO.transform.position += new Vector3(0,0f,0);

        var PlayerModel = new PlayerModel(data.Character[(int)CharacterType.Player]);
        var playerContoller = new Player(userInput, PlayerModel, playerGO.GetComponent<PlayerView>());

        camera.transform.SetParent(playerGO.transform); // ??? crutch ???

        controllers.Add(userInput);
        controllers.Add(paralax);
        controllers.Add(playerContoller);
    }
}