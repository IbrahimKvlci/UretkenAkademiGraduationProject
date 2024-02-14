using UnityEngine;
using Zenject;

public class GameIntaller : MonoInstaller
{
    [SerializeField] private GameInputManager gameInputManager;

    public override void InstallBindings()
    {
        Container.Bind<IGameInputSystem>().To<GameInputManager>().FromComponentInNewPrefab(gameInputManager).AsSingle();

        Container.Bind<IEnemyTriggerCheckService>().To<EnemyTriggerCheckManager>().AsSingle();
        Container.Bind<IPlayerTriggerCheckService>().To<PlayerTriggerCheckManager>().AsSingle();
    }
}