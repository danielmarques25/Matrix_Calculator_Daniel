﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_De_Matrizes
{
    class Calculos
    {
        #region Soma de matrizes
        public static float[,] SomandoMatrizes(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultado = new float[matriz1.GetLongLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y] = matriz1[x, y] += matriz2[x, y];
                }
            }
            return matrizResultado;
        }
        #endregion

        #region Subtração de matrizes
        public static float[,] SubtraindoMatrizes(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultado = new float[matriz1.GetLongLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y] = matriz1[x, y] -= matriz2[x, y];
                }
            }
            return matrizResultado;
        }
        public static float[,] MultiplicandoMatrizes(float[,] matriz1, float[,] matriz2)
        {
            float[,] matrizResultado = new float[matriz1.GetLength(0), matriz2.GetLength(1)];
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    for (int n = 0; n < matriz2.GetLength(0); n++)
                    {
                        string i = "" + matriz1[x, n];
                        matrizResultado[x, y] += matriz1[x, n] * matriz2[n, y];
                    }
                }
            }
            return matrizResultado;
        }
        #endregion

        #region Cofatora 2x2
        public static float[,] GerarCofatora2x2(float[,] matriz1)
        {
            float[,] matrizCofatora = new float[matriz1.GetLength(0), matriz1.GetLength(1)];
            float determinanteDaVez = 0;

            for (int x = 0; x < matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < matriz1.GetLength(1); y++)
                {
                    if (x == 0 && y == 0)
                    {
                        determinanteDaVez = matriz1[x + 1, y + 1];
                    }
                    else if (x == 0 && y == 1)
                    {
                        determinanteDaVez = matriz1[x + 1, y - 1];
                    }
                    else if (x == 1 && y == 0)
                    {
                        determinanteDaVez = matriz1[x - 1, y + 1];
                    }
                    else if (x == 1 && y == 1)
                    {
                        determinanteDaVez = matriz1[x - 1, y - 1];
                    }
                    double i = Math.Pow(-1, (x + y));
                    matrizCofatora[x, y] += (float)i * determinanteDaVez;
                }
            }
            return matrizCofatora;
        }
        #endregion

        #region Cofatora 3x3
        public static float[,] GerarCofatora3x3(float[,] matriz1)
        {
            float[,] matrizCofatora = new float[matriz1.GetLength(0), matriz1.GetLength(1)];
            float determinanteDaVez = 0;

            for (int x = 0; x < matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < matriz1.GetLength(1); y++)
                {
                    determinanteDaVez = DeterminanteCofator(x, y, matriz1);
                    double i = Math.Pow(-1, (x + y));
                    matrizCofatora[x, y] += (float)i * determinanteDaVez;
                }
            }
            return matrizCofatora;
        }
        #endregion

        #region Determinante Cofatora
        private static float DeterminanteCofator(int posX, int posY, float[,] matriz)
        {
            float[,] matrizResultante = new float[2, 2];
            int id = 0;
            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    if (x != posX && y != posY)
                    {
                        if (id == 0)
                        {
                            matrizResultante[0, 0] += matriz[x, y];
                        }
                        else if (id == 1)
                        {
                            matrizResultante[0, 1] += matriz[x, y];
                        }
                        else if (id == 2)
                        {
                            matrizResultante[1, 0] += matriz[x, y];
                        }
                        else if (id == 3)
                        {
                            matrizResultante[1, 1] += matriz[x, y];
                        }
                        id++;
                    }
                }
            }
            float determinate = GerarDeterminante2x2(matrizResultante);
            return determinate;
        }
        #endregion

        #region matriz Inversa
        public static float[,] GerarInversa(float determinante, float[,] matriz1)
        {
            float[,] matrizInversa = new float[matriz1.GetLength(0), matriz1.GetLength(1)];
            for (int x = 0; x < matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < matriz1.GetLength(1); y++)
                {
                    float n = matriz1[x, y];
                    n = n / determinante;
                    matrizInversa[x, y] += n;
                }
            }

            return matrizInversa;
        }
        #endregion

        #region Matriz Transposta
        public static float[,] GerarTransposta(float[,] matriz)
        {
            float[,] matrizTransposta = new float[matriz.GetLength(1), matriz.GetLength(0)];
            for (int x = 0; x < matrizTransposta.GetLength(0); x++)
            {
                for (int y = 0; y < matrizTransposta.GetLength(1); y++)
                {
                    matrizTransposta[x, y] += matriz[y, x];
                }
            }
            return matrizTransposta;
        }
        #endregion

        #region Determinante 2x2
        public static float GerarDeterminante2x2(float[,] matriz)
        {
            float diagonalPrincipal = 1;
            float diagonalSecundaria = 1;
            float determinanteFinal = 0;
            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    if (x == y)
                    {
                        diagonalPrincipal *= matriz[x, y];
                    }
                }
            }
            for (int x = 0; x < matriz.GetLength(0); x++)
            {
                for (int y = 0; y < matriz.GetLength(1); y++)
                {
                    if (x != y)
                    {
                        diagonalSecundaria *= matriz[x, y];
                    }
                }
            }
            determinanteFinal = diagonalPrincipal - diagonalSecundaria;
            return determinanteFinal;
        }
        #endregion

        #region Determinante 3x3
        public static float GerarDeterminante3x3(float[,] matriz)
        {
            float diagonalPrincipal = 0;
            float diagonalSecundaria = 0;
            float determinanteFinal = 0;
            int tamanhoSarrus = (((matriz.GetLength(0) * matriz.GetLength(1)) * 2) / 3) - 1;
            float[,] Sarrus = new float[matriz.GetLength(0), tamanhoSarrus];
            for (int x = 0; x < Sarrus.GetLength(0); x++)
            {
                for (int y = 0; y < Sarrus.GetLength(1); y++)
                {
                    if (y > matriz.GetLength(0) - 1)
                    {
                        Sarrus[x, y] += matriz[x, y - matriz.GetLength(0)];
                    }
                    else
                    {
                        Sarrus[x, y] += matriz[x, y];
                    }
                }
            }
            int voltas = 3;
            for (int i = 0; i < voltas; i++)
            {
                int numero = i;
                float mDiagonal = 1;
                for (int x = 0; x < Sarrus.GetLength(0); x++)
                {
                    for (int y = 0; y < Sarrus.GetLength(1); y++)
                    {
                        if (x == y)
                        {
                            string z = "" + Sarrus[x, y + numero];
                            mDiagonal *= Sarrus[x, y + numero];
                        }
                    }
                }
                diagonalPrincipal += mDiagonal;
            }

            for (int i = 0; i < voltas; i++)
            {
                int numero = i;
                float mDiagonal = 1;
                for (int x = 0; x < Sarrus.GetLength(0); x++)
                {
                    for (int y = Sarrus.GetLength(1) - 1; y > 0; y--)
                    {
                        if (x == (Sarrus.GetLength(1) - 1) - y)
                        {
                            string z = "" + Sarrus[x, y - numero];
                            mDiagonal *= Sarrus[x, y - numero];
                        }
                    }
                }
                diagonalSecundaria += mDiagonal;
            }
            determinanteFinal = diagonalPrincipal - diagonalSecundaria;
            return determinanteFinal;
        }
        #endregion

        #region Matriz Oposta
        public static float[,] GerarOposta(float[,] matriz)
        {
            float[,] matrizOposta = new float[matriz.GetLength(0), matriz.GetLength(1)];
            for (int x = 0; x < matrizOposta.GetLength(0); x++)
            {
                for (int y = 0; y < matrizOposta.GetLength(1); y++)
                {
                    matrizOposta[x, y] += matriz[x, y] * -1;
                }
            }
            return matrizOposta;
        }
        #endregion 
    }
}
