using System;
using System.Collections.Generic;
using UnityEngine;

internal sealed class GameInitialization
{
    public GameInitialization(Controllers controllers, Data data, Camera camera, SpriteRenderer background)
    { 
        var userInput = new UserInput();
        var paralax = new ParalaxController(camera, background.transform);

        controllers.Add(userInput);
        controllers.Add(paralax);
    }
}