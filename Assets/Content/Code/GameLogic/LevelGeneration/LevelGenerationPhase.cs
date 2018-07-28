using MapGenetaroion.BaseGenerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationPhase : BaseDungeonGenerationPhaseMonoBehaviour
{
    private GenerationSettings settings = null;
    private LevelMetadata levelMetadata = null;

    public override IEnumerator Generate(LevelGenerator generator, object[] generationData)
    {
        settings = LevelGenerator.GetMetaDataObject<GenerationSettings>(generationData);
        levelMetadata = LevelGenerator.GetMetaDataObject<LevelMetadata>(generationData);

        var levelSize = settings.StartLevelSize;

        for (int i = 0; i < levelSize.x; i++)
        {
            GameObject floarObject = new GameObject(string.Format("Flor {0}", i));
            levelMetadata.LevelData.AddFlor(settings.GroundLevel);
            for (int j = 0; j < levelSize.y; j++)
            {
                var instance = settings.LevelBoxInstance;
                instance.transform.SetParent(floarObject.transform);
                var room = instance.GetComponent<Room>();
                if(room != null)
                {
                    instance.transform.position = new Vector3(j * room.Size.x, i * room.Size.y);
                    levelMetadata.LevelData.AddRoom(room);
                }
                else
                {
                    Debug.LogErrorFormat("Prefab named {0} don't contain component type of {1}", instance.name, typeof(Room).Name);
                    j--;
                }
                yield return null;
            }
            levelMetadata.LevelBounds.MaxWidth = levelMetadata.LevelBounds.MaxWidth < levelMetadata.LevelData.Flors[i].Width ? levelMetadata.LevelData.Flors[i].Width : levelMetadata.LevelBounds.MaxWidth;
            levelMetadata.LevelBounds.MaxHeight = levelMetadata.LevelData.Flors[i].Height + levelMetadata.LevelData.Flors[i].Rooms[0].Size.y;
        }

        _isDone = true;
    }
}
