using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class S_IO
{
    public static void Save (string playerName, S_Character character)
    {
        string path = $"{Application.persistentDataPath}/{playerName}.sav";
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream stream = new FileStream(path, FileMode.Create );

        S_IOCharacter playerData = new S_IOCharacter(character);

        formatter.Serialize( stream, playerData );
        stream.Close();
    }

    public static S_IOCharacter Load (string playerName)
    {
        string path = $"{Application.persistentDataPath}/{playerName}.sav";
        S_IOCharacter playerData;

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open );

            playerData = formatter.Deserialize( stream ) as S_IOCharacter;

            stream.Close();
        }
        else
        {
            playerData = new S_IOCharacter();
        }

        return playerData;
    }
}
