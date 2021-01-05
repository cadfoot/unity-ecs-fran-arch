using Leopotam.Ecs;
using UnityEngine;

namespace FranArch
{
    sealed class EcsStartup : MonoBehaviour
    {
        private EcsWorld _world;
        private EcsSystems _systems;

        private CubeViewCreatorBase _cubeViewCreator;
        private IGameState _gameState;

        [SerializeField] private SceneContext _scene;
        [SerializeField] private GameUI _ui;
        [SerializeField] private Config _config;

        [Space, SerializeField] private bool _cheatMode;

        private void Awake()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);

            _cubeViewCreator = new CubeViewCreator(_config.CubePrefab, _scene.CubeRoot);
            
            _gameState = new GameState();
            _gameState.OnScoreChange += _ui.SetScore;
            _gameState.Score = 0;
            _gameState.OnCountChange += _ui.SetCount;
            _gameState.Count = 0;

#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif
            _systems

                .Add(new CubePlaceInitialSystem())

                .Add(new CubeTagLastSystem())
                .Add(new InputSystem())
                .Add(new FallCheckSystem())

                .Add(new NextCubeUpdateTimerSystem())

                .Add(new NextCubePositionUpdateSystem(_cheatMode))

                .Add(new NextCubePlaceSystem())

                .Add(new FallSystem())
                .Add(new ScoreSystem())
                .Add(new CountSystem())

                .Add(new CubeViewCreateSystem())
                .Add(new CubeViewUpdatePositionSystem())
                .Add(new CubeViewUpdatePhysicsSystem())
                .Add(new NewCubeParticleEmitSystem())
                .Add(new CameraSystem())

                .Inject(_cubeViewCreator)
                .Inject(_scene)
                .Inject(_gameState)
                .Inject(_config)

                .OneFrame<Last>()
                .OneFrame<New>()
                .OneFrame<ChangeNextCubePositionEvent>()
                .OneFrame<InputReleasedEvent>()

                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null)
            {
                _systems.Destroy();
                _systems = null;
                _world.Destroy();
                _world = null;
            }

            _gameState.OnScoreChange -= _ui.SetScore;
            _gameState.OnCountChange -= _ui.SetCount;
        }
    }
}
