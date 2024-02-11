using UnityEngine;
using Zenject;

public class GameIntaller : MonoInstaller
{
    [SerializeField] private GameInputManager gameInputManager;

    public override void InstallBindings()
    {
        Container.Bind<IGameInputSystem>().To<GameInputManager>().FromComponentInNewPrefab(gameInputManager).AsSingle();
    }
}