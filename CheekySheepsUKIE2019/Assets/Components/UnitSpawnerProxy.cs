using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

[RequiresEntityConversion]
public class UnitSpawnerProxy : MonoBehaviour, IDeclareReferencedPrefabs, IConvertGameObjectToEntity
{
    [SerializeField] private GameObject[] trees;

    [SerializeField] private int CountX, CountY;

    // Referenced prefabs have to be declared so that the conversion system knows about them ahead of time
    public void DeclareReferencedPrefabs(List<GameObject> gameObjects)
    {
        foreach (GameObject tree in trees)
        {
            gameObjects.Add(tree);
        }
    }

    // Lets you convert the editor data representation to the entity optimal runtime representation
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var spawnerData = new UnitSpawner
        {
            // The referenced prefab will be converted due to DeclareReferencedPrefabs.
            // So here we simply map the game object to an entity reference to that prefab.
            Prefab1 = conversionSystem.GetPrimaryEntity(trees[0]),
            Prefab2 = conversionSystem.GetPrimaryEntity(trees[1]),
            Prefab3 = conversionSystem.GetPrimaryEntity(trees[2]),
            CountX = CountX,
            CountY = CountY
        };
        dstManager.AddComponentData(entity, spawnerData);
    }
}