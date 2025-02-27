using Godot;
using Godot.Collections;
using Bitron.Ecs;

public class UpdateHoveredLocationSystem : IEcsSystem
{
    private Node3D _parent;

    private Vector3 previousCell = Vector3.Zero;

    public UpdateHoveredLocationSystem(Node3D parent)
    {
        _parent = parent;
    }

    public void Run(EcsWorld world)
    {
        if (!world.HasResource<Map>())
        {
            return;
        }

        if (!world.TryGetResource<HoveredLocation>(out var hoveredLocation))
        {
            world.AddResource(new HoveredLocation());
        }
        
        var result = ShootRay();

        if (result.Contains("position"))
        {
            var position = (Vector3)result["position"];
            var coords = Coords.FromWorld(position);

            if (previousCell != coords.Axial)
            {
                var map = world.GetResource<Map>();

                var locEntity = map.Locations.Get(coords.Cube);
                
                hoveredLocation.Entity = locEntity;
                hoveredLocation.HasChanged = true;

                previousCell = coords.Axial;
            }
        }
    }

    private Dictionary ShootRay()
    {
        var spaceState = _parent.GetWorld3d().DirectSpaceState;
        var viewport = _parent.GetViewport();

        var camera = viewport.GetCamera3d();
        var mousePosition = viewport.GetMousePosition();

        if (camera == null)
        {
            return new Dictionary();
        }
        
        var from = camera.ProjectRayOrigin(mousePosition);
        var to = from + camera.ProjectRayNormal(mousePosition) * 1000f;

        var parameters3D = new PhysicsRayQueryParameters3D();
        parameters3D.From = from;
        parameters3D.To = to;
        return spaceState.IntersectRay(parameters3D);
    }
}