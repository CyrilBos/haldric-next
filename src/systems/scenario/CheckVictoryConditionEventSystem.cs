using Bitron.Ecs;
using Godot;

public struct CheckVictoryConditionEvent { }
public class CheckVictoryConditionEventSystem : IEcsSystem
{
    public void Run(EcsWorld world)
    {
        var eventQuery = world.Query<CheckVictoryConditionEvent>().End();

        foreach (var e in eventQuery)
        {
            if (!world.TryGetResource<Scenario>(out var scenario))
            {
                return;
            }

            var query = world.Query<IsLeader>().End();

            foreach (var playerEntity in scenario.Players)
            {
                var leaderCount = 0;

                foreach (var unitId in query)
                {
                    var unitEntity = world.Entity(unitId);

                    if (unitEntity.Has<IsLeader>() && unitEntity.Get<Side>().Value == playerEntity.Get<Side>().Value)
                    {
                        leaderCount += 1;
                    }
                }

                if (leaderCount == 0)
                {
                    GD.Print($"Player {playerEntity.Get<Side>().Value} lost the game!");
                    world.GetResource<GameStateController>().PopState();
                }
            }
        }
    }
}