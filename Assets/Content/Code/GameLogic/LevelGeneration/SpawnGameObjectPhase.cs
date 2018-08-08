using BaseGameLogic.States;
using BaseGameLogic.States.Providers;
using Character;
using MapGenetaroion.BaseGenerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGameObjectPhase : BaseDungeonGenerationPhaseMonoBehaviour
{
    private GenerationSettings settings = null;
    private LevelMetadata levelMetadata = null;

    public override IEnumerator Generate(LevelGenerator generator, object[] generationData)
    {
        settings = LevelGenerator.GetMetaDataObject<GenerationSettings>(generationData);
        levelMetadata = LevelGenerator.GetMetaDataObject<LevelMetadata>(generationData);

        for (int i = settings.StartFlorIndex; i < levelMetadata.LevelData.Flors.Count; i++)
        {
            var chance = Random.Range(0f, 1f);
            if(chance <= settings.EnnemySpawnChance)
            {
                var enemy = settings.EnemyInstance;
                enemy.transform.position = new Vector3(Random.Range(levelMetadata.LevelBounds.MinWidth, levelMetadata.LevelBounds.MaxWidth), levelMetadata.LevelData.Flors[i].Height + levelMetadata.LevelData.Flors[i].GroundLevel, 0);
            }
            yield return null;
        }

        for (int i = 0; i < settings.ObjectsToSpanw.Count; i++)
        {
            Instantiate(settings.ObjectsToSpanw[i]);
            yield return null;
        }

        var room = levelMetadata.LevelData.Flors[0].Rooms[0];
        var position = new Vector3(room.Size.x / 2, levelMetadata.LevelData.Flors[0].GroundLevel, 0); // room.transform.position;

        var instance = Instantiate(settings.PlayerObject);
        instance.transform.position = position;
        PlayerCharacter.Instance.StartPosition = instance.transform.position;

        instance = Instantiate(settings.CameraObject);
        float z = instance.transform.position.z;
        instance.transform.position = new Vector3(position.x, position.y, z);
        yield return null;

        _isDone = true;
    }
}
