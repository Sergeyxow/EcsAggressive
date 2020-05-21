using Leopotam.Ecs;
using UnityEngine;

namespace Client {
    sealed class EcsStartup : MonoBehaviour {
        EcsWorld _world;
        EcsSystems _systems;

        public GameData _gameData;

        void Start () {
            // void can be switched to IEnumerator for support coroutines.
            
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new NpcInitSystem())
                .Add(new FollowRouteSystem())
                .Add(new FollowTargetSystem())
                .Add(new MoveSystem())
                .Add(new CheckForNextPoint())
                .Add(new RestSystem())
                .Add(new SwitchToAggressiveSystem())
                .Add(new SwitchToIdleSystem())
                .Add(new AttackCooldownSystem())
                
                // register one-frame components (order is important), for example:
                .OneFrame<SwitchToAggressiveFlag>()
                .OneFrame<SwitchToIdleFlag>()
                .OneFrame<AttackFlag>()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Inject(_gameData)
                .Init ();
        }

        void Update () {
            _systems?.Run ();
        }

        void OnDestroy () {
            if (_systems != null) {
                _systems.Destroy ();
                _systems = null;
                _world.Destroy ();
                _world = null;
            }
        }
    }
}