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
            levelMetadata.LevelData.AddFlor();
            for (int j = 0; j < levelSize.y; j++)
            {
                var instance = GetBoxInstance();
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
        }

        _isDone = true;
    }

    private GameObject GetBoxInstance()
    {
        return Instantiate(settings.LevelPrefabBoxList[Random.Range(0, settings.LevelPrefabBoxList.Count)]);
    }
}
