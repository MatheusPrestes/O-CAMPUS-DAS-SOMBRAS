using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GerarEnemy : MonoBehaviour {

    private int inimigoSorteado;
    private Enemy inimigoFinal;
        

    private int numMin = 2;
    private int numMax = 5;


    public Enemy criarInimigo(Player jogador, Enemy inimigo1, Enemy inimigo2, Enemy inimigo3)
    {
        Enemy[] inimigos = { inimigo1, inimigo2, inimigo3 };
        inimigoSorteado = Random.Range(0, 3);
        for (int i = 0; i < inimigos.Length; i++)
        {
            if(i==inimigoSorteado)
            {
                inimigoFinal = (Enemy)inimigos.GetValue(i);
            }
        }
        int nivelJogador = jogador.getNivel();
        int lastJogadorNivel = jogador.getNivel();
        int vidaMonstro = Random.Range(numMin * 2, numMax * 3)*nivelJogador;
        int ataqueMonstro = Random.Range(numMin, numMax*2);       
        int sorteMonstro = Random.Range(jogador.getNivel(), ataqueMonstro);
        inimigoFinal.setVidaMonstro(vidaMonstro);
        inimigoFinal.setXpMonstro(60 - numMin);
        inimigoFinal.setNivelMonstro(nivelJogador);
        inimigoFinal.setAtaqueMonstro(ataqueMonstro);
        inimigoFinal.setSorteMonstro(sorteMonstro);
        inimigoFinal.setMoeda(gerarMoeda(jogador));
        if(nivelJogador>5)
        {
            numMin = numMax;
            numMax = numMax + 10;
        }        
        Debug.Log("-----------------------------");
        Debug.Log("Nome do Monstro: " + inimigoFinal.getNomeMonstro());
        Debug.Log("Vida do Monstro: " + inimigoFinal.getVidaMonstro());
        Debug.Log("Nivel do monstro " + inimigoFinal.getNivelMonstro());
        Debug.Log("Ataque do monstro " + inimigoFinal.getAtaqueMonstro());
        Debug.Log("XP do monstro " + inimigoFinal.getXPMonstro());
        Debug.Log("Sorte do monstro " + inimigoFinal.getSorteMonstro());
        Debug.Log("Moeda " + inimigoFinal.getMoeda());
        Debug.Log("-----------------------------");
        return inimigoFinal;
    }

    public int gerarMoeda(Player jogador)
    {
        int valor = 0;
        int nivelJogador = jogador.getNivel();        
        if (nivelJogador==1)
        {
            valor = Random.Range(1, 15);
        }
        if (nivelJogador == 2 || nivelJogador == 3)
        {
            valor = Random.Range(15, 30);
        }
        if (nivelJogador == 4 || nivelJogador == 5)
        {
            valor = Random.Range(30, 45);
        }
        if (nivelJogador == 6 || nivelJogador == 7)
        {
            valor = Random.Range(45, 60);
        }
        if (nivelJogador == 8 || nivelJogador == 9)
        {
            valor = Random.Range(60, 85);
        }
        if (nivelJogador >= 10)
        {
            valor = Random.Range(85, 100);
        }
        return valor;
    }



}
