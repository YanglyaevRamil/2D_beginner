using System.Collections.Generic;

public class Controllers : IInitialization, IExecute, IFixedExecute, ILateExecute, ICleanup
{
    private readonly List<IInitialization> initializeControllers;
    private readonly List<IExecute> executeControllers;
    private readonly List<IFixedExecute> fixedExecuteControllers;
    private readonly List<ILateExecute> lateControllers;
    private readonly List<ICleanup> cleanupControllers;

    public Controllers()
    {
        initializeControllers = new List<IInitialization>();
        executeControllers = new List<IExecute>();
        fixedExecuteControllers = new List<IFixedExecute>();
        lateControllers = new List<ILateExecute>();
        cleanupControllers = new List<ICleanup>();
    }

    internal Controllers Add(IController controller)
    {
        if (controller is IInitialization initializeController)
        {
            initializeControllers.Add(initializeController);
        }

        if (controller is IExecute executeController)
        {
            executeControllers.Add(executeController);
        }

        if (controller is IFixedExecute fixedExecuteController)
        {
            fixedExecuteControllers.Add(fixedExecuteController);
        }

        if (controller is ILateExecute lateExecuteController)
        {
            lateControllers.Add(lateExecuteController);
        }

        if (controller is ICleanup cleanupController)
        {
            cleanupControllers.Add(cleanupController);
        }

        return this;
    }

    public void Initialization()
    {
        for (var index = 0; index < initializeControllers.Count; ++index)
        {
            initializeControllers[index].Initialization();
        }
    }

    public void Execute(float deltaTime)
    {
        for (var index = 0; index < executeControllers.Count; ++index)
        {
            executeControllers[index].Execute(deltaTime);
        }
    }

    public void FixedExecute()
    {
        for (var index = 0; index < fixedExecuteControllers.Count; ++index)
        {
            fixedExecuteControllers[index].FixedExecute();
        }
    }

    public void LateExecute(float deltaTime)
    {
        for (var index = 0; index < lateControllers.Count; ++index)
        {
            lateControllers[index].LateExecute(deltaTime);
        }
    }

    public void Cleanup()
    {
        for (var index = 0; index < cleanupControllers.Count; ++index)
        {
            cleanupControllers[index].Cleanup();
        }
    }
}