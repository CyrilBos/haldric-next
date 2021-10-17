using Godot;
using System;

public enum DamageType
{
    Slash,
    Pierce,
    Impact,
    Arcane,
    Heat,
    Cold,
}

public enum RangeType
{
    Melee,
    Ranged,
}

public partial class Attack : Node
{
    [Export] public int Damage;
    [Export] public int Strikes;
    [Export] public DamageType DamageType;
    [Export] public RangeType Range;
}