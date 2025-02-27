using System.Collections.Generic;
using Bitron.Ecs;
using Godot;
using Haldric.Wdk;

public partial class PlayState : GameState
{
    private string _mapName;
    private Dictionary<int, string> _factions;

    public PlayState(EcsWorld world, string mapName, Dictionary<int, string> factions) : base(world)
    {
        _mapName = mapName;
        _factions = factions;

        AddInitSystem(new SpawnCameraOperatorSystem(this));

        AddInputSystem(new SelectUnitSystem());
        AddInputSystem(new SelectTargetSystem());
        AddInputSystem(new DeselectUnitSystem());
        AddInputSystem(new UndoCommandSystem());
        AddInputSystem(new RecruitInputSystem());

        AddUpdateSystem(new UpdateTerrainInfoSystem());
        AddUpdateSystem(new UpdatePlayerInfoSystem());
        AddUpdateSystem(new UpdateUnitPlateSystem());
        AddUpdateSystem(new UpdateStatsInfoSystem());
        AddUpdateSystem(new UpdateHoveredLocationSystem(this));
        AddUpdateSystem(new PreviewPathSystem());
        AddUpdateSystem(new UpdateMapCursorSystem());
        AddUpdateSystem(new UpdateCameraOperatorSystem());
        AddUpdateSystem(new UpdateHoveredUnitSystem());
        AddUpdateSystem(new MoveUnitSystem());

        AddEventSystem<UpdateMapEvent>(new UpdateMapEventSystem());
        AddEventSystem<UpdateTerrainMeshEvent>(new UpdateTerrainMeshEventSystem());
        AddEventSystem<UpdateTerrainFeaturePopulatorEvent>(new UpdateTerrainFeaturePopulatorEventSystem());
        AddEventSystem<LoadMapEvent>(new LoadMapEventSystem());
        AddEventSystem<DespawnMapEvent>(new DespawnMapEventSystem());
        AddEventSystem<SpawnMapEvent>(new SpawnMapEventSystem(this));
        AddEventSystem<SpawnPlayersEvent>(new SpawnPlayersEventSystem());
        AddEventSystem<SpawnPlayerEvent>(new SpawnPlayerEventSystem());
        AddEventSystem<SpawnUnitEvent>(new SpawnUnitEventSystem(this));
        AddEventSystem<RecruitUnitEvent>(new RecruitUnitEventSystem(this));
        AddEventSystem<UnitHoveredEvent>(new UnitHoveredEventSystem());
        AddEventSystem<UnitDeselectedEvent>(new UnitDeselectedEventSystem());
        AddEventSystem<UnitSelectedEvent>(new UnitSelectedEventSystem());
        AddEventSystem<HighlightLocationEvent>(new HighlightLocationsEventSystem());
        AddEventSystem<DamageEvent>(new DamageEventSystem());
        AddEventSystem<MissEvent>(new MissEventSystem());
        AddEventSystem<GainExperienceEvent>(new GainExperienceEventSystem());
        AddEventSystem<AdvanceEvent>(new AdvanceEventSystem());
        AddEventSystem<DeathEvent>(new DeathEventSystem());
        AddEventSystem<CaptureVillageEvent>(new CaptureVillageEventSystem(this));
        AddEventSystem<SpawnFloatingLabelEvent>(new SpawnFloatingLabelEventSystem());
        AddEventSystem<TurnEndEvent>(new TurnEndEventSystem());
        AddEventSystem<CheckVictoryConditionEvent>(new CheckVictoryConditionEventSystem());

        AddDestroySystem(new DespawnCameraOperatorSystem());
    }

    public override void Enter(GameStateController gameStates)
    {
        _world.AddResource(new Commander());

        _world.AddResource(new Scenario());
        _world.AddResource(Data.Instance.Schedules["DefaultSchedule"].Instantiate<Schedule>());

        var hudView = Scenes.Instance.HUDView.Instantiate<HUDView>();
        AddChild(hudView);

        _world.AddResource(hudView);

        _world.Spawn().Add(new LoadMapEvent(_mapName));
        _world.Spawn().Add(new SpawnPlayersEvent(_factions));
        _world.Spawn().Add(new TurnEndEvent());
    }

    public override void Exit(GameStateController gameStates)
    {
        _world.RemoveResource<Commander>();
        _world.RemoveResource<Scenario>();
        _world.RemoveResource<Schedule>();

        _world.RemoveResource<HUDView>();
        _world.Spawn().Add(new DespawnMapEvent());
    }

    public override void Input(GameStateController gameStates, Godot.InputEvent e)
    {
        if (e.IsActionPressed("ui_cancel"))
        {
            gameStates.PopState();
        }
    }
}