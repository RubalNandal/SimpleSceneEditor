using NUnit.Framework;
using RubalNandal.DesignPattern.CommandPattern;
using RubalNandal.SceneEditor.GenericBehaviour;
using UnityEngine;

public class UndoRedoTest : TestEnvironment
{
    Vector3 initialCubePosition;
    Vector3 finalCubePosition = new Vector3(0, 1, 2);

    [SetUp]
    public void SendMoveCommand()
    {
        initialCubePosition = testCube.transform.position;

        // move cube
        testCube.GetComponent<Movable>().MoveObject(initialCubePosition, finalCubePosition, testCube.transform, testCube.GetComponent<Movable>().movableIndex);

    }

    [Test,Order(1)]
    public void UndoTest()
    {
        
        CommandScheduler scheduler = GameObject.FindObjectOfType<CommandScheduler>();

        
        //undo the move command
        scheduler.UndoCommand();


        Assert.AreEqual(testCube.transform.position, initialCubePosition);


    }

    [Test,Order(2)]
    public void RedoTest()
    {

        CommandScheduler scheduler = GameObject.FindObjectOfType<CommandScheduler>();
        
        scheduler.RedoCommand();

        Assert.AreEqual(testCube.transform.position, finalCubePosition);
    }
}
