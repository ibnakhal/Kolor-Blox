using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System;
using System.IO;

public class GameControl : MonoBehaviour {

    public static GameControl control;

    public List<LevelData> levelStars;

    public int levelCullModifier;

    public int soundVol;
    public int musicVol;


    //make sure only one ever exists. singleton design patern.
    private void Awake()
    {
        if(control == null)
        {
            DontDestroyOnLoad(gameObject);
            control = this;
        }
        else if(control != this)
        {
            Destroy(gameObject);
        }
        Load();
    }

    //save data
    //accessible by going GameControl.contol.Save();
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        //write data to file
        PlayerData data = new PlayerData();
        data.stars = levelStars;
        data.soundVol = soundVol;
        data.musicVol = musicVol;
        //serialize and close file
        bf.Serialize(file, data);
        file.Close();
    }

    //accessible by going GameControl.contol.Load();
    public void Load()
    {
        //look to see if the file exists
        if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat", FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            levelStars = data.stars;
            soundVol = data.soundVol;
            musicVol = data.musicVol;
        }
    }


    public void SoundOn(bool toggleState)
    {
        if (toggleState)
        {
            soundVol = 1;
        }
        else
        {
            soundVol = 0;
        }
        Save();
    }
    public void MusicOn(bool toggleState)
    {
        if (toggleState)
        {
            musicVol = 1;
        }
        else
        {
            musicVol = 0;
        }
        Save();
    }

}

[Serializable]
class PlayerData
{
    //holdable data
    public List<LevelData> stars;
    public int soundVol;
    public int musicVol;

}

[Serializable]
public class LevelData
{
    public int score;
    public bool active;
}