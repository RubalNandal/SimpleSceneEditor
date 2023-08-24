using System.Collections.Generic;
using UnityEngine;
using RubalNandal.DesignPattern.CommandPattern;
using RubalNandal.SaveLoadService.LoadService;
using RubalNandal.SceneEditor.Commands;
using RubalNandal.SceneEditor.GenericBehaviour;
using RubalNandal.SceneEditor.SpawnSystem;
using RubalNandal.DesignPattern.EventSystem;
using RubalNandal.SceneEditor.Environment;

public class LoadScene : MonoBehaviour
{
    public CommandHandler commandHandler;

    public GameEventSO spawnEvent;
    public GameEventSO selectEvent;
    public GameEventSO moveEvent;

    public SpawnableObjectsSO spawnableObjects;

    /// <summary>
    /// Load the game scene data from a specified path.
    /// </summary>
    /// <param name="sender">The sender of the load request.</param>
    /// <param name="sentData">Additional data (not used in this context).</param>
    public void LoadGame(Component sender , object sentData)
    {

        LoadSceneWrapper(ENV_CONSTANTS.SAVE_PATH);

    }

    /// <summary>
    /// Load the scene data from a specified path.
    /// </summary>
    /// <param name="path">The path to the save file.</param>
    public void LoadSceneWrapper(string path)
    {
        commandHandler.ClearScene();
        LoadDataServiceJson saveService = new LoadDataServiceJson();
        List<SerilizedGameData> loadedFile = saveService.LoadData<List<SerilizedGameData>>(path, false);


        foreach (var data in loadedFile)
        {

            if (data.commandType == ENV_CONSTANTS.COMMAND_TYPE.SPAWN)
            {
                GameObject prefab = spawnableObjects.spawnables[data.spawnObjectIndex].prefeb;
                ICommand command = new SpawnCommand(data.spawnPosition, prefab, data.spawnObjectIndex);
                spawnEvent.Raise(this, command);
            }
            else if (data.commandType == ENV_CONSTANTS.COMMAND_TYPE.SELECT)
            {
                Selectable selectedObject = (Selectable)ISelectable.selectableObjects[data.selectedIndex];
                ICommand command = new SelectCommand(selectedObject.meshRenderer, selectedObject.defaultColor, data.selectedIndex);

                selectEvent.Raise(this, command);
            }
            else if (data.commandType == ENV_CONSTANTS.COMMAND_TYPE.MOVE)
            {
                Movable selectedObject = (Movable)IMovable.movableObjects[data.movedIndex];
                ICommand command = new MoveCommand(data.initalPosition, data.finalPosition, selectedObject.transform, data.movedIndex);

                moveEvent.Raise(this, command);
            }

        }
    }

}
