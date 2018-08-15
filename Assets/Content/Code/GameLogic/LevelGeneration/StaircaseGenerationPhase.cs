using MainGameLogic.Action;
using MapGenetaroion.BaseGenerator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BaseGameLogic.LevelGeneration
{
    public class StaircaseGenerationPhase : BaseDungeonGenerationPhaseMonoBehaviour
    {
        private GenerationSettings settings;
        private LevelMetadata levelMetadata;

        public override IEnumerator Generate(LevelGenerator generator, object[] generationData)
        {
            settings = LevelGenerator.GetMetaDataObject<GenerationSettings>(generationData);
            levelMetadata = LevelGenerator.GetMetaDataObject<LevelMetadata>(generationData);

            bool lastRoom = true;

            for (int i = 0; i < levelMetadata.LevelData.Flors.Count; i++)
            {
                GameObject instance = null;
                LevelMetadata.Level.Flor flor = levelMetadata.LevelData.Flors[i];
                if (i < levelMetadata.LevelData.Flors.Count - 1)
                {
                    instance = settings.StarCaseInstance;
                    var room = levelMetadata.LevelData.Flors[i].Rooms[lastRoom ? levelMetadata.LevelData.Flors[i].Rooms.Count - 1 : 0];
                    var position = room.gameObject.transform.position;
                    position = position + (room.gameObject.transform.right * (room.Size.x / 2)) + room.gameObject.transform.up * levelMetadata.LevelData.Flors[i].GroundLevel;
                    instance.transform.position = position;
                    var nextFlor = levelMetadata.LevelData.Flors[i + 1];
                    var teleport = instance.GetComponent<TeleportPlayerAction>();
                    teleport.GizmoColor = Color.green;
                    teleport.Destination = new Vector3(position.x, nextFlor.Height + nextFlor.GroundLevel, position.z);
                    instance = settings.StarCaseInstance;
                    instance.transform.position = teleport.Destination;
                    teleport = instance.GetComponent<TeleportPlayerAction>();
                    teleport.GizmoColor = Color.red;
                    teleport.Destination = position;
                    lastRoom = !lastRoom;
                }
                yield return null;
            }

            _isDone = true;
        }
    }
}
