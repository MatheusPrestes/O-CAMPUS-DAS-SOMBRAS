using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    public int nivel;
    public int vida;
    public int ataque;
    //public int defesa;
    public int XPLevels;
    public int sorte;
    public int moeda;
    public int maxVida;

    public int getXP()
    {
        return XPLevels;
    }

    public int getVida()
    {
        return vida;
    }

    public  int getAtaque()
    {
        return ataque;
    }

    //public int getDefesa()
    //{
    //    return defesa;
    //}

    public int getNivel()
    {
        return nivel;
    }

    public int getSorte()
    {
        return sorte;
    }

    public int getMoeda()
    {
        return moeda;
    }

    public int getMaxVida()
    {
        return maxVida;
    }

    public void setVida(int vidaNova)
    {
        vida = vidaNova;
    }

    public void setNivel(int nivelNovo)
    {
        nivel = nivelNovo;
    }

    public void setAtaque(int ataqueNovo)
    {
        ataque = ataqueNovo;
    }

    //public void setDefesa(int defesaNova)
    //{
    //    defesa = defesaNova;
    //}

    public void setXP(int xp)
    {
        XPLevels = xp;
    }

    public void setSorte(int sorteNova)
    {
        sorte = sorteNova;
    }

    public void setMoeda(int moedaNova)
    {
        moeda = moedaNova;
    }

    public void setMaxVida(int maxVidaNova)
    {
        maxVida = maxVidaNova;
    }


}
