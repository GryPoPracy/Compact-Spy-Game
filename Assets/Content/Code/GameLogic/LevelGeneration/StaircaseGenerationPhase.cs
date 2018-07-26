using MapGenetaroion.BaseGenerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaircaseGenerationPhase : BaseDungeonGenerationPhaseMonoBehaviour
{
    private GenerationSettings settings;
    private LevelMetadata levelMetadata;

    public override IEnumerator Generate(LevelGenerator generator, object[] generationData)
    {
        settings = LevelGenerator.GetMetaDataObject<GenerationSettings>(generationData);
        levelMetadata = LevelGenerator.GetMetaDataObject<LevelMetadata>(generationData);

        for (int i = 0; i < levelMetadata.LevelData.Flors.Count; i++)
        {
            LevelMetadata.Level.Flor flor = levelMetadata.LevelData.Flors[i];
            GameObject instance = null;
            if(i < levelMetadata.LevelData.Flors.Count - 1)
            {
                instance = settings.StarCaseInstance;
                instance.transform.position = new Vector3(0, flor.Height + flor.GroundLevel, 0);
                var nextFlor = levelMetadata.LevelData.Flors[i + 1];
                var teleport = instance.GetComponent<TeleportPlayerAction>();
                teleport.Destination = new Vector3(0, nextFlor.Height + nextFlor.GroundLevel, 0);
            }
            yield return null;
        }

        _isDone = true;
    }
}
