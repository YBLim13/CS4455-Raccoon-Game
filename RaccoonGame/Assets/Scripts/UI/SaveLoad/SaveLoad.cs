using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{

    [System.Serializable]
    public class Save
    {
        public List<string> items;
        public int location;
        public int prevLocation;
        public int food;
        public int health;
        public bool  isCutscene;
        public bool hadStartGameScene;
        public bool hadMidGameScene;
        public bool hadEndGameScene;
        public bool  isCityGateClosed;
        public bool  isTownCenterClosed;
        public bool isCityHallDoorClosed;
    }

    [SerializeField]
    private Button _button;
    [SerializeField]
    private AudioSource _audio;

    private void Start() {     // Update because what if player brings it over while it's running
        if (File.Exists(Application.persistentDataPath + "/gamesave.save") && _button != null) {
            _button.interactable = true;
        }
    }

    private Save CreateSaveGameObject()
    {
        Save save = new Save();

        save.items = InventoryManager.Instance.inventory;
        save.food = InventoryManager.Instance.foodCount;
        //save.location = SceneManager.GetActiveScene().name;
        save.location = (int) LevelStateManager.Instance.GetCurr();
        save.prevLocation = (int) LevelStateManager.Instance.GetPrev();
        save.health = InventoryManager.Instance.healthCount;
        save.isCutscene = CutsceneManager.Instance.isCutscene();
        save.hadStartGameScene = CutsceneManager.Instance.hadStartGameScene();
        save.hadMidGameScene = CutsceneManager.Instance.hadMidGameScene();
        save.hadEndGameScene = CutsceneManager.Instance.hadEndGameScene();
        save.isCityGateClosed = CutsceneManager.Instance.isCityGateClosed();
        save.isTownCenterClosed = CutsceneManager.Instance.isTownCenterGateClosed();
        save.isCityHallDoorClosed = CutsceneManager.Instance.isCityHallDoorClosed();

        return save;
    }

    public void SaveGame()
    {
        Save save = CreateSaveGameObject();

        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/gamesave.save");
        bf.Serialize(file, save);
        file.Close();
    }

    public void LoadGame()
    {
        if (File.Exists(Application.persistentDataPath + "/gamesave.save"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/gamesave.save", FileMode.Open);
            Save save = (Save)bf.Deserialize(file);
            file.Close();

            InventoryManager.Instance.LoadItems(save.items);
            InventoryManager.Instance.LoadFood(save.food);
            InventoryManager.Instance.LoadHealth(save.health);
            CutsceneManager.Instance.setIsCutscene(save.isCutscene);
            CutsceneManager.Instance.setHadStartGameScene(save.hadStartGameScene);
            CutsceneManager.Instance.setHadMidGameScene(save.hadMidGameScene);
            CutsceneManager.Instance.setHadEndGameScene(save.hadEndGameScene);
            CutsceneManager.Instance.setIsCityGateClosed(save.isCityGateClosed);
            CutsceneManager.Instance.setIsTownCenterGateClosed(save.isTownCenterClosed);
            CutsceneManager.Instance.setIsCityHallDoorClosed(save.isCityHallDoorClosed);
            LevelStateManager.Instance.SetCurr((LevelStateManager.LevelState) save.prevLocation);
            StartCoroutine(DropVolume());
            LevelStateManager.Instance.ChangeState((LevelStateManager.LevelState) save.location);
            //SceneManager.LoadScene(save.location);
        } else {
            Debug.LogError("No Save Game Exists");
        }
    }

    IEnumerator DropVolume() {
        float currVol = _audio.volume;
        while (_audio.volume > 0) {
            _audio.volume -= currVol/10;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
