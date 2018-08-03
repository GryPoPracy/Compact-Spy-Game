using BaseGameLogic.States.Providers;
using MapGenetaroion.BaseGenerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerPhase : BaseDungeonGenerationPhaseMonoBehaviour
{
    private GenerationSettings settings = null;
    private LevelMetadata levelMetadata = null;

    public override IEnumerator Generate(LevelGenerator generator, object[] generationData)
    {
        settings = LevelGenerator.GetMetaDataObject<GenerationSettings>(generationData);
        levelMetadata = LevelGenerator.GetMetaDataObject<LevelMetadata>(generationData);

        var room = levelMetadata.LevelData.Flors[0].Rooms[0];
        var position = room.transform.position;
        position.x += room.Size.x / 2;
        position.y = levelMetadata.LevelData.Flors[0].GroundLevel;

        var instance = Instantiate(settings.PlayerObject);
        instance.transform.position = position;

        instance = Instantiate(settings.CameraObject);
        float z = instance.transform.position.z;
        instance.transform.position = new Vector3(position.x, position.y, z);

        yield return null;
        _isDone = true;
    }
}
