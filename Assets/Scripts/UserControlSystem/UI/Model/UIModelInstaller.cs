using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UIModelInstaller : MonoInstaller
{
    [SerializeField] private AssetsContext _legacyContext;

    public override void InstallBindings()
    {
        Container.Bind<AssetsContext>().FromInstance(_legacyContext);

        Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
            .To<ProduceUnitCommandCreate>().AsTransient();
        Container.Bind<CommandCreatorBase<IAttackCommand>>()
            .To<AttackCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IMoveCommand>>()
            .To<MoveCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IPatrolCommand>>()
            .To<PatrolCommandCreator>().AsTransient();
        Container.Bind<CommandCreatorBase<IStopCommand>>()
            .To<StopCommandCreator>().AsTransient();
        Container.Bind<Vector3Value>().AsTransient();

        Container.Bind<CommandsButtonModel>().AsTransient();
    }
}
