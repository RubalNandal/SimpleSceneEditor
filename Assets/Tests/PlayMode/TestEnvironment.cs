using NUnit.Framework;
using RubalNandal.SceneEditor.SpawnSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;


public class TestEnvironment
{
    string mainScene = "MainScene";
    public GameObject testCube, testSphere, testCapsule;


    [UnitySetUp]
    public IEnumerator SetupCoroutine()
    {
        if (!SceneManager.GetSceneByName(mainScene).isLoaded)
        {
            //loading scene 
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainScene);

            // waiting untull scene is loaded
            while (!asyncLoad.isDone)
            {
                yield return null;
            }

            //SpawnPrimitive spawner = new GameObject().AddComponent<SpawnPrimitive>();
            SpawnPrimitive spawner = GameObject.FindObjectOfType<SpawnPrimitive>();

            //spawning Cube 
            spawner.SpawnPrimitiveObject(null, 0);

            //spawnning Sphere
            spawner.SpawnPrimitiveObject(null, 1);

            //spawwning capsule
            spawner.SpawnPrimitiveObject(null, 2);
        }

        testCube = GameObject.Find("Cube(Clone)");
        testSphere = GameObject.Find("Sphere(Clone)");
        testCapsule = GameObject.Find("Capsule(Clone)");
    }

    
}
