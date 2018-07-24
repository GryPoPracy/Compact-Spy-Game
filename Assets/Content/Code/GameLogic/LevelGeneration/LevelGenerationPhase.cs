using MapGenetaroion.BaseGenerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerationPhase : BaseDungeonGenerationPhaseMonoBehaviour
{
    private GenerationSettings settings = null;
    public override IEnumerator Generate(LevelGenerator generator, object[] generationData)
    {
        settings = LevelGenerator.GetMetaDataObject<GenerationSettings>(generationData);
        var levelSize = settings.StartLevelSize;

        for (int i = 0; i < levelSize.x; i++)
        {
            for (int j = 0; j < levelSize.y; j++)
            {
                var instance = GetBoxInstance();
                instance.transform.position = new Vector3(j, i) * settings.LevelBoxSize;
                yield return null;
            }
        }
    }

    private GameObject GetBoxInstance()
    {
        SpriteRenderer spriteRenderer;
        return Instantiate(settings.LevelPrefabBoxList[Random.Range(0, settings.LevelPrefabBoxList.Count)]);
    }
}
