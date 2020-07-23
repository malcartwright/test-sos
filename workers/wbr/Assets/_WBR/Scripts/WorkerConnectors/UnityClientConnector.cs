using Improbable.Gdk.Core;
using Improbable.Gdk.Core.Representation;
using Improbable.Gdk.GameObjectCreation;
using Improbable.Gdk.PlayerLifecycle;
using System;
using UnityEngine;

public class UnityClientConnector : WorkerConnector
{
    [SerializeField] private EntityRepresentationMapping entityRepresentationMapping = default;

    public const string WorkerType = "UnityClient";

    private async void Start()
    {
        Debug.Log("Creating client worker");
        await Connect(GetConnectionHandlerBuilder(), new ForwardingDispatcher()).ConfigureAwait(false);
        //var connParams = CreateConnectionParameters(WorkerType);

        //var builder = new SpatialOSConnectionHandlerBuilder()
        //    .SetConnectionParameters(connParams);

        //if (!Application.isEditor)
        //{
        //    var initializer = new CommandLineConnectionFlowInitializer();
        //    switch (initializer.GetConnectionService())
        //    {
        //        case ConnectionService.Receptionist:
        //            builder.SetConnectionFlow(new ReceptionistFlow(CreateNewWorkerId(WorkerType), initializer));
        //            break;
        //        case ConnectionService.Locator:
        //            builder.SetConnectionFlow(new LocatorFlow(initializer));
        //            break;
        //        default:
        //            throw new ArgumentOutOfRangeException();
        //    }
        //}
        //else
        //{
        //    builder.SetConnectionFlow(new ReceptionistFlow(CreateNewWorkerId(WorkerType)));
        //}

        //await Connect(builder, new ForwardingDispatcher()).ConfigureAwait(false);
    }

    protected virtual IConnectionHandlerBuilder GetConnectionHandlerBuilder()
    {
        IConnectionFlow connectionFlow;
        var connectionParams = CreateConnectionParameters(WorkerType);
        var workerId = CreateNewWorkerId(WorkerType);

        if (Application.isEditor)
        {
            connectionFlow = new ReceptionistFlow(workerId);
        }
        else
        {
            var initializer = new CommandLineConnectionFlowInitializer();

            switch (initializer.GetConnectionService())
            {
                case ConnectionService.Receptionist:
                    connectionFlow = new ReceptionistFlow(workerId, initializer);
                    break;
                case ConnectionService.Locator:
                    connectionParams.Network.UseExternalIp = true;
                    connectionFlow = new LocatorFlow(initializer);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        Debug.Log("Client worker connection configured");

        return new SpatialOSConnectionHandlerBuilder()
            .SetConnectionFlow(connectionFlow)
            .SetConnectionParameters(connectionParams);
    }

    protected override void HandleWorkerConnectionEstablished()
    {
        Debug.Log("Handling client worker connection established");

        PlayerLifecycleHelper.AddClientSystems(Worker.World);
        GameObjectCreationHelper.EnableStandardGameObjectCreation(Worker.World, entityRepresentationMapping);
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
