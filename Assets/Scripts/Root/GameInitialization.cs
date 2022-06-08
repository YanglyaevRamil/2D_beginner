using UnityEngine;

internal sealed class GameInitialization
{
    public GameInitialization(Controllers controllers, Data data, Camera camera, SpriteRenderer background)
    { 
        var userInput = new UserInput();
        var paralax = new ParalaxController(camera, background.transform);

        var playerBuilder = new BuilderPlayer(PlayerCnst.PATH_GO);
        var player = new Player(userInput, data.Player, playerBuilder.GetGO());

        var characterFactory = new CharacterFactory(CharacterCnst.PATH_GO);
         characterFactory.GetGO(CharacterType.Swordsman);

        controllers.Add(userInput);
        controllers.Add(paralax);
        controllers.Add(player);
    }
}