using Godot;
using System;
using Leopotam.Ecs;

public partial class EditorView : CanvasLayer
{
    public int BrushSize { get { return (int)_brushSizeSlider.Value; } }
    public int Elevation { get { return (int)_elevationSlider.Value; } }

    public bool UseElevation { get { return _elevationCheckBox.Pressed; } }
    public bool UseTerrain { get { return _terrainCheckBox.Pressed; } }

    public EcsEntity TerrainEntity { get { return _selectedTerrain; } }

    EcsEntity _selectedTerrain;

    HSlider _brushSizeSlider;
    HSlider _elevationSlider;

    CheckBox _elevationCheckBox;
    CheckBox _terrainCheckBox;

    Control _terrains;

    public override void _Ready()
    {
        _terrains = GetNode<Control>("PanelContainer/VBoxContainer/Terrains/GridContainer");

        _elevationSlider = GetNode<HSlider>("PanelContainer/VBoxContainer/Elevation/HSlider");
        _brushSizeSlider = GetNode<HSlider>("PanelContainer/VBoxContainer/BrushSize/HSlider");

        _elevationCheckBox = GetNode<CheckBox>("PanelContainer/VBoxContainer/Elevation/HBoxContainer/CheckBox");
        _terrainCheckBox = GetNode<CheckBox>("PanelContainer/VBoxContainer/Terrains/HBoxContainer/CheckBox");

        InitializeTerrains();
    }

    public void InitializeTerrains()
    {
        _selectedTerrain = Data.Instance.Terrains["Gg"];

        foreach (var item in Data.Instance.Terrains)
        {
            var code = item.Key;

            var button = new Button();
            button.Text = code;
            button.Connect("pressed", new Callable(this, "OnTerrainSelected"), new Godot.Collections.Array() { code });
            _terrains.AddChild(button);
        }
    }

    public void OnTerrainSelected(string code)
    {
        _selectedTerrain = Data.Instance.Terrains[code];
    }
}