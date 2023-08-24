using NUnit.Framework.Internal;
using NUnit.Framework;
using UnityEngine;
using RubalNandal.SceneEditor.GenericBehaviour;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;

public class ObjectMovementTest : TestEnvironment
{

    [Test]
    public void MovementTest()
    {
        // Arrange
        Vector3 initialCubePosition = testCube.transform.position;
        Vector3 finalCubePosition = new Vector3(0, 1, 2);
        Vector3 initialSpherePosition = testSphere.transform.position;
        Vector3 finalSpherePosition = new Vector3(1, 2, 3);
        Vector3 initialCapsulePosition = testCapsule.transform.position;
        Vector3 finalCapsulePosition = new Vector3(2, 3, 4);


        // Act 
        testCube.GetComponent<Movable>().MoveObject(initialCubePosition, finalCubePosition, testCube.transform, testCube.GetComponent<Movable>().movableIndex);
        testSphere.GetComponent<Movable>().MoveObject(initialSpherePosition, finalSpherePosition, testSphere.transform, testSphere.GetComponent<Movable>().movableIndex);
        testCapsule.GetComponent<Movable>().MoveObject(initialCapsulePosition, finalCapsulePosition, testCapsule.transform, testCapsule.GetComponent<Movable>().movableIndex);


        // Assert
        Assert.AreEqual(testCube.transform.position, finalCubePosition);
        Assert.AreEqual(testSphere.transform.position, finalSpherePosition); 
        Assert.AreEqual(testCapsule.transform.position, finalCapsulePosition);

        
    }

/*
    [UnityTearDown]
    public IEnumerator Teardown()
    {
        AsyncOperation asyncLoad = SceneManager.UnloadSceneAsync("MainScene");
        // waiting untull scene is loaded
        while (!asyncLoad.isDone)
        {
            yield return null;
        }


        yield return new WaitForSeconds(10);
    }*/

}
