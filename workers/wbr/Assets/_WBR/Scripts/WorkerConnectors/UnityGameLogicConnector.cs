using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Representation;
using Improbable.Gdk.GameObjectCreation;
using Improbable.Gdk.PlayerLifecycle;
using Improbable.Worker.CInterop;
using UnityEngine;
public class UnityGameLogicConnector : WorkerConnector
{
    [SerializeField] private EntityRepresentationMapping entityRepresentationMapping = default;
    public const string WorkerType = "UnityGameLogic";
    //public bool DisableRenderers = true;

    private async void Start()
    {
        Debug.Log("Creating server worker");

        Application.targetFrameRate = 60;

        PlayerLifecycleConfig.CreatePlayerEntityTemplate = EntityTemplates.CreatePlayerEntityTemplate;

        IConnectionFlow flow;
        ConnectionParameters connectionParameters;

        if (Application.isEditor)
        {
            flow = new ReceptionistFlow(CreateNewWorkerId(WorkerType));
            connectionParameters = CreateConnectionParameters(WorkerType);
        }
        else
        {
            flow = new ReceptionistFlow(CreateNewWorkerId(WorkerType),
                new CommandLineConnectionFlowInitializer());
            connectionParameters = CreateConnectionParameters(WorkerType,
                new CommandLineConnectionParameterInitializer());
        }

        var builder = new SpatialOSConnectionHandlerBuilder()
            .SetConnectionFlow(flow)
            .SetConnectionParameters(connectionParameters);

        Debug.Log("Server configured; connecting");
        await Connect(builder, new ForwardingDispatcher()).ConfigureAwait(false);

        //if (DisableRenderers)
        //{
        //    foreach (var childRenderer in LevelInstance.GetComponentsInChildren<Renderer>())
        //    {
        //        childRenderer.enabled = false;
        //    }
        //}
    }

    protected override void HandleWorkerConnectionEstablished()
    {
        Debug.Log("Server connection established");
        var world = Worker.World;
        PlayerLifecycleHelper.AddServerSystems(world);
        GameObjectCreationHelper.EnableStandardGameObjectCreation(Worker.World, entityRepresentationMapping);

        // Add server systems
    }
}
