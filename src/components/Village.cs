using System.Collections.Generic;
using Bitron.Ecs;

public struct Village : IEcsAutoReset<Village>
{
    public List<EcsEntity> List { get; set; }

    public void AutoReset(ref Village c)
    {
        c.List = new List<EcsEntity>();
    }
}