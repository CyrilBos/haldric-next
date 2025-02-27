using System.Collections.Generic;
using Haldric.Wdk;

public class TerrainScript : TerrainLoader
{
	public override void Load()
	{
		NewBase("Gg", new List<TerrainType>() { TerrainType.Flat });
		NewBase("Rd", new List<TerrainType>() { TerrainType.Flat });
		NewBase("Sd", new List<TerrainType>() { TerrainType.Rough });
		NewBase("Sm", new List<TerrainType>() { TerrainType.Rough }, -0.4f);
		NewBase("Sb", new List<TerrainType>() { TerrainType.Rough }, -0.4f);
		NewBase("Mm", new List<TerrainType>() { TerrainType.Rough });
		
		NewShallowWater("Ws", new List<TerrainType>() { TerrainType.ShallowWaters });
		NewDeepWater("Wo", new List<TerrainType>() { TerrainType.DeepWaters });
		
		NewOverlay("Ff", new List<TerrainType>() { TerrainType.Forested });

		NewKeep("Kh", new List<TerrainType>() { TerrainType.Fortified });
		NewCastle("Ch", new List<TerrainType>() { TerrainType.Fortified });

		NewHouses("Vh", new List<TerrainType>() { TerrainType.Settled });
		NewVillage("VHh", new List<TerrainType>() { TerrainType.Settled });

		AddTerrainTexture("Gg", "assets/graphics/images/grass_basecolor.png");
		AddTerrainNormalTexture("Gg", "assets/graphics/images/grass_normal.png");
		AddTerrainRoughnessTexture("Gg", "assets/graphics/images/grass_roughness.png");

		AddTerrainTexture("Sd", "assets/graphics/images/sand_basecolor.png");
		AddTerrainNormalTexture("Sd", "assets/graphics/images/sand_normal.png");
		AddTerrainRoughnessTexture("Sd", "assets/graphics/images/sand_roughness.png");

		AddTerrainTexture("Sb", "assets/graphics/images/sand_basecolor.png");
		AddTerrainNormalTexture("Sb", "assets/graphics/images/sand_normal.png");
		AddTerrainRoughnessTexture("Sb", "assets/graphics/images/sand_roughness.png");

		AddTerrainTexture("Sm", "assets/graphics/images/mud_basecolor.png");
		AddTerrainNormalTexture("Sm", "assets/graphics/images/mud_normal.png");
		AddTerrainRoughnessTexture("Sm", "assets/graphics/images/mud_roughness.png");

		AddTerrainTexture("Rd", "assets/graphics/images/dirt_basecolor.png");
		AddTerrainNormalTexture("Rd", "assets/graphics/images/dirt_normal.png");
		AddTerrainRoughnessTexture("Rd", "assets/graphics/images/dirt_roughness.png");

		AddTerrainTexture("Ch", "assets/graphics/images/dirt_basecolor.png");
		AddTerrainNormalTexture("Ch", "assets/graphics/images/dirt_normal.png");
		AddTerrainRoughnessTexture("Ch", "assets/graphics/images/dirt_roughness.png");
		
		AddTerrainTexture("Kh", "assets/graphics/images/dirt_basecolor.png");
		AddTerrainNormalTexture("Kh", "assets/graphics/images/dirt_normal.png");
		AddTerrainRoughnessTexture("Kh", "assets/graphics/images/dirt_roughness.png");
		
		AddTerrainTexture("Ws", "assets/graphics/images/mud_basecolor.png");
		AddTerrainNormalTexture("Ws", "assets/graphics/images/mud_normal.png");
		AddTerrainRoughnessTexture("Ws", "assets/graphics/images/mud_roughness.png");

		AddTerrainTexture("Wo", "assets/graphics/images/mud_basecolor.png");
		AddTerrainNormalTexture("Wo", "assets/graphics/images/mud_normal.png");
		AddTerrainRoughnessTexture("Wo", "assets/graphics/images/mud_roughness.png");

		AddTerrainTexture("Mm", "assets/graphics/images/stone_basecolor.png");
		AddTerrainNormalTexture("Mm", "assets/graphics/images/stone_normal.png");
		AddTerrainRoughnessTexture("Mm", "assets/graphics/images/stone_roughness.png");



		// AddKeepPlateauGraphic("Kh", "assets/graphics/models/keep_plateau.tres", new Godot.Vector3(0f, 1.5f, 0f));
		AddWallSegmentGraphic("Kh", "assets/graphics/models/keep_wall.tres");
		AddWallTowerGraphic("Kh", "assets/graphics/models/keep_tower.tres");

		// AddKeepPlateauGraphic("Ch", "assets/graphics/models/castle_plateau.tres", new Godot.Vector3(0f, 0.05f, 0f));
		AddWallSegmentGraphic("Ch", "assets/graphics/models/castle_wall.tres");
		AddWallTowerGraphic("Ch", "assets/graphics/models/castle_tower.tres");

		AddDecorationGraphic("Ff", "assets/graphics/models/forest_pine_center_01.tres", "center");
		AddDecorationGraphic("Ff", "assets/graphics/models/forest_pine_center_02.tres", "center");

		AddDirectionalDecorationGraphic("Ff", "assets/graphics/models/forest_pine_outer_01.tres", "outer");
		AddDirectionalDecorationGraphic("Ff", "assets/graphics/models/forest_pine_outer_02.tres", "outer");
		AddDirectionalDecorationGraphic("Ff", "assets/graphics/models/forest_pine_outer_03.tres", "outer");

		AddDecorationGraphic("Mm", "assets/graphics/models/rock_center_01_mesh_01.tres", "center");

		
		AddDirectionalDecorationGraphic("Mm", "assets/graphics/models/rock_prop_01_mesh1.tres", "outer");

		AddDecorationGraphic("Vh", "assets/graphics/models/Village_human_center_01.tres", "center");
		AddDecorationGraphic("Vh", "assets/graphics/models/Village_human_center_02.tres", "center");
		AddDecorationGraphic("Vh", "assets/graphics/models/Village_human_center_03.tres", "center");
		
		AddDirectionalDecorationGraphic("Vh", "assets/graphics/models/Village_human_outer_01.tres", "outer");
		AddDirectionalDecorationGraphic("Vh", "assets/graphics/models/Village_human_outer_02.tres", "outer");
		AddDirectionalDecorationGraphic("Vh", "assets/graphics/models/Village_human_outer_03.tres", "outer");
		AddDirectionalDecorationGraphic("Vh", "assets/graphics/models/Village_human_outer_04.tres", "outer");
		
		AddDecorationGraphic("VHh", "assets/graphics/models/Village_human_hall_base_01.tres");
		AddDecorationGraphic("VHh", "assets/graphics/models/Village_human_hall_center_01.tres");
		AddDirectionalDecorationGraphic("VHh", "assets/graphics/models/Village_human_hall_outer_01.tres", "outer");
		AddDirectionalDecorationGraphic("VHh", "assets/graphics/models/Village_human_hall_outer_02.tres", "outer");
		AddDirectionalDecorationGraphic("VHh", "assets/graphics/models/Village_human_hall_outer_03.tres", "outer");
		
		AddWaterGraphic("Ws", "assets/graphics/models/water.tres");
		AddWaterGraphic("Wo", "assets/graphics/models/water.tres");
	}
}
