using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;

public class ParticleRender : MonoBehaviour, ISharedComponentData
{
    [SerializeField] private GameObject Prefab;

    [SerializeField] private int CountX, CountY;

    public void DeclareReferencedPrefabs(List<GameObject> gameObjects)
    {
        gameObjects.Add(Prefab);
        // gameObjects.Add();
    }

    // Lets you convert the editor data representation to the entity optimal runtime representation
    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        var spawnerData = new UnitSpawner
        {
            // The referenced prefab will be converted due to DeclareReferencedPrefabs.
            // So here we simply map the game object to an entity reference to that prefab.
            Prefab = conversionSystem.GetPrimaryEntity(Prefab),
            CountX = CountX,
            CountY = CountY
        };
        dstManager.AddComponentData(entity, spawnerData);
    }
}
