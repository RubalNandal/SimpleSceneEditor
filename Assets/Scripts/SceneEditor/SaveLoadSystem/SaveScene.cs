using System.Collections.Generic;
using UnityEngine;
using RubalNandal.SceneEditor.Commands;
using RubalNandal.SaveLoadService.SaveService;
using RubalNandal.DesignPattern.CommandPattern;
using RubalNandal.SceneEditor.Environment;


public class SaveScene : MonoBehaviour
{
    public CommandHandler commandHandler;

    [SerializeField]List<SerilizedGameData> gameData = new List<SerilizedGameData>();

    /// <summary>
    /// Save the current state of the scene.
    /// </summary>
    public void SaveSceneState(Component sender , object data)
    {
        SaveSceneStateWrapper(ENV_CONSTANTS.SAVE_PATH);
    }

    /// <summary>
    /// Save the scene state to a file.
    /// </summary>
    /// <param name="path">The path to save the data to.</param>
    public void SaveSceneStateWrapper(string path)
    {
        // clear list if its not the last index of all the commands before saving
        if (commandHandler.index < gameData.Count)
        {
            gameData.RemoveRange(commandHandler.index, gameData.Count - commandHandler.index);
        }

        SaveDataServiceJson saveService = new SaveDataServiceJson();

        saveService.SaveData(path, gameData, false);
    }


    /// <summary>
    /// Save spawn data from a Spawn event.
    /// </summary>
    public void SaveSpawnData(Component sender, object Data)
    {
        SpawnCommand spawnCommand = Data as SpawnCommand;


        SerilizedGameData data = new SerilizedGameData();
        data.commandType = spawnCommand.commandType;
        data.spawnObjectIndex = spawnCommand.spawnableObjectIndex;
        data.spawnPosition = spawnCommand.spawnPosition;
        gameData.Add(data);


    }


    /// <summary>
    /// Save select data from a SelectCommand Event.
    /// </summary>
    public void SaveSelectData(Component sender, object Data)
    {
        SelectCommand selectCommand = Data as SelectCommand;

        SerilizedGameData data = new SerilizedGameData();
        data.commandType = selectCommand.commandType;
        data.selectedIndex = selectCommand._selectIndex;
        gameData.Add(data);

    }

    /// <summary>
    /// Save move data from a MoveCommand Event.
    /// </summary>
    public void SaveMoveData(Component sender, object Data)
    {
        MoveCommand moveCommand = Data as MoveCommand;

        SerilizedGameData data = new SerilizedGameData();
        data.commandType = moveCommand.commandType;
        data.initalPosition = moveCommand.initialPosition;
        data.finalPosition = moveCommand.finalPosition;
        data.movedIndex = moveCommand.movableIndex;
        gameData.Add(data);
    }


    /// <summary>
    /// Clear the stored game data On load event.
    /// </summary>
    public void OnLoadEvent()
    {
        gameData.Clear();

    }
    


}


/// <summary>
/// Scene state is serilized using this class
/// </summary>
[System.Serializable]
public class SerilizedGameData
{
    public string commandType;

    public int spawnObjectIndex;
    public Vector3 spawnPosition;
    
    public int selectedIndex;

    public Vector3 initalPosition;
    public Vector3 finalPosition;
    public int movedIndex;

    
}



