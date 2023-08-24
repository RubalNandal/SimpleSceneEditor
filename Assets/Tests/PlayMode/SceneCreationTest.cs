using System.Collections;
using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using RubalNandal.SceneEditor.SpawnSystem;
using UnityEngine.SceneManagement;

public class SceneCreationTest : TestEnvironment
{
    string mainScene = "MainScene";

    [Test]
    public void SpawnPrimitiveObjectTest()
    {
/*        //yield return new WaitForSeconds(10);

        //Arrange

        //loading scene 
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(mainScene);

        // waiting untull scene is loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        yield return null;
        yield return null;

        //SpawnPrimitive spawner = new GameObject().AddComponent<SpawnPrimitive>();
        SpawnPrimitive spawner = GameObject.FindObjectOfType<SpawnPrimitive>();


        //Act

        //spawning Cube 
        spawner.SpawnPrimitiveObject(null, 0);

        //spawnning Sphere
        spawner.SpawnPrimitiveObject(null, 1);

        //spawwning capsule
        spawner.SpawnPrimitiveObject(null, 2);

*/      

        //Assert

        Assert.NotNull(GameObject.Find("Cube(Clone)"));
        Assert.NotNull(GameObject.Find("Sphere(Clone)"));
        Assert.NotNull(GameObject.Find("Capsule(Clone)"));

       

    }
}
