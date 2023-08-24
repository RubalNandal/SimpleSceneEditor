using NUnit.Framework;
using RubalNandal.DesignPattern.CommandPattern;
using RubalNandal.SceneEditor.GenericBehaviour;
using System;
using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.TestTools;

public class SaveLoadTest : TestEnvironment
{
    Vector3 initialCubePosition;
    Vector3 finalCubePosition = new Vector3(2, 2, 2);
    string testSavePath;

    [SetUp]
    public void SetTestData()
    {
        testSavePath =  "\\testSaveFile";
       
    }


    [Test,Order(1)]
    public void SaveTest()
    {
        SaveScene sceneSaver = GameObject.FindObjectOfType<SaveScene>();
        
        initialCubePosition = testCube.transform.position;

        // move cube
        testCube.GetComponent<Movable>().MoveObject(initialCubePosition, finalCubePosition, testCube.transform, testCube.GetComponent<Movable>().movableIndex);

        // delete if file already exixted
        if (File.Exists(testSavePath))
        {
            try
            {
                File.Delete(testSavePath);
            }
            catch (Exception e)
            {
                Debug.LogException(e);
            }
        }

        // veryfy file is deleted
        Assert.IsFalse(File.Exists(testSavePath));

        // save the current scene state
        sceneSaver.SaveSceneStateWrapper(testSavePath);

        //assert file exists
        Assert.IsTrue(File.Exists(Application.persistentDataPath + testSavePath));


    }

    [UnityTest,Order(2)]
    public IEnumerator LoadTest()
    {
        LoadScene sceneLoader = GameObject.FindObjectOfType<LoadScene>();

        // move cube to a new position
        testCube.GetComponent<Movable>().MoveObject(initialCubePosition, new Vector3(10,10,10), testCube.transform, testCube.GetComponent<Movable>().movableIndex);

        // checks if cube is moved to new position
        Assert.AreEqual(testCube.transform.position, new Vector3(10,10, 10));


        //load the file
        sceneLoader.LoadSceneWrapper(testSavePath);

        yield return null;

        GameObject[] cubeObjects = GameObject.FindGameObjectsWithTag("cube");
        testCube = cubeObjects[cubeObjects.Length-1];

        // check if the cubes postion is loded from savefile
        Assert.AreEqual(testCube.transform.position, finalCubePosition);

        CommandScheduler scheduler = GameObject.FindObjectOfType<CommandScheduler>();

        //undo the move command
        scheduler.UndoCommand();

        //veryfing if undo command cahnges cube to position in save file
        Assert.AreEqual(testCube.transform.position, initialCubePosition);
    }
}
