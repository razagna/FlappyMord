using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxer : MonoBehaviour
{
    class PoolObject
    {
        public Transform transform;
        public bool inUse;
        public PoolObject(Transform t) { transform = t; }
        public void Use() { inUse = true; }
        public void Dispose() { inUse = fale; }
    }

    [System.Serializable]
    public struct YSpawnRange 
    {
        public float min;
        public float max;
    }

    public GameObject Prefab;
    public int poolSize;
    public float shiftSpeed;
    public float spawnRate;

    public YSpawnRange YSpawnRange;
    public Vector3 defaultSpawnPos;
    public bool spawnImmediate;
    public Vector3 immediateSpawnPos;
    public Vector2 targetAspectRatio;

    float spawnTimer;
    float targetAspect;
    PoolObject[] poolObjects
    GameManager game;

    private void Awake()
    {
        Configure();
    }

    private void Start()
    {
        game = GameManager.Instance;
    }

    private void OnEnable()
    {
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }

    private void OnDisable()
    {
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;
    }

    void OnGameOverConfirmed()
    {
        Configure();
    }

    private void Update()
    {
        
    }

    void Configure()
    {
    
    }

    void Spawn()
    {
    
    }

    void SpawnImmediate()
    {
    
    }

    void Shift()
    {
    
    }

    void CheckDisposeObject(PoolObject poolObject)
    {
        
    }

    Transform GetPoolObject()
    {
        for (int i = 0; i < poolObjects.Length; i ++)
        {
            if(!poolObjects[i].inUse)
            {
                poolObjects[i].Use();
                return PoolObject[i];
            }
        }

        return null;
    }

}
