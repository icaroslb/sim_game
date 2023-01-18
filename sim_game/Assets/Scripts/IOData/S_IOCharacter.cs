using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class S_IOCharacter
{
    public int _idShirt;
    public int _idShort;
    public int _idShoes;

    public S_IOCharacter(S_Character player)
    {
        _idShirt = player.idShirt;
        _idShort = player.idShort;
        _idShoes = player.idShoes;
    }

    public S_IOCharacter(int idShirt = 0, int idShort = 0, int idShoes = 0)
    {
        _idShirt = idShirt;
        _idShort = idShort;
        _idShoes = idShoes;
    }
}
