using System.Collections.Generic;
using Bitron.Ecs;

public struct Attacks : IEcsAutoReset<Attacks>
{
    public List<EcsEntity> List { get; set; }

    public void Add(EcsEntity attackEntity)
    {
        if (List == null)
        {
            List = new List<EcsEntity>();
        }

        List.Add(attackEntity);
    }

    public EcsEntity GetUsableAttack(int attackRange, int bonusAttackRange = 0)
    {
        bool isInMeleeRange = attackRange == 1;

        foreach(var attack in List)
        {
            if (isInMeleeRange)
            {
                if (attack.Get<Range>().Value == 1)
                {
                    return attack;
                }
            }
            else
            {
                if (attack.Get<Range>().Value + bonusAttackRange >= attackRange)
                {
                    return attack;
                }
            }
        }
        return default;
    }

    public EcsEntity[] GetUsableAttacks(int attackDistance, int bonusAttackRange = 0)
    {
        List<EcsEntity> list = new List<EcsEntity>();

        bool isInMeleeRange = attackDistance == 1;
        
        foreach(var attack in List)
        {
            if (isInMeleeRange)
            {
                if (attack.Get<Range>().Value == 1)
                {
                    list.Add(attack);
                }
            }
            else
            {
                if (attack.Get<Range>().Value + bonusAttackRange >= attackDistance)
                {
                    list.Add(attack);
                }
            }
        }
        return list.ToArray();
    }

    public int GetMaxAttackRange()
    {
        var range = 0;

        foreach(var attack in List)
        {
            var attackRange = attack.Get<Range>().Value;

            if (attackRange > range)
            {
                range = attackRange;
            }
        }

        return range;
    }

    public void AutoReset(ref Attacks c)
    {
        if (c.List == null)
        {
            c.List = new List<EcsEntity>();
        }
        else
        {
            c.List.Clear();
        }
    }
}