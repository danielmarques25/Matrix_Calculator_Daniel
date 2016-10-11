using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora_De_Matrizes
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private TextBox[,] Matriz1;
        private TextBox[,] Matriz2;
        private TextBox[,] matrizResultado;
        private float determinante;

        int linha1, coluna1;
        int linha2, coluna2;


        #region Soma Subtração Multiplicação
        private void ADDmatriz1(object sender, EventArgs e)
        {
            groupBox1.Controls.Clear();


            if (!int.TryParse(textBox1.Text, out linha1))
            {
                MessageBox.Show("Por Favor adicione a linha.", "Erro");
                return;
            }

            if (!int.TryParse(textBox2.Text, out coluna1))
            {
                MessageBox.Show("Por Favor adicione a coluna.", "Erro");
                return;
            }

            Matriz1 = new TextBox[linha1, coluna1];
            int TamanhoText = groupBox1.Width / coluna1;
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = "0";
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 6;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBox1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        private void ADDmatriz2(object sender, EventArgs e)
        {
            groupBox2.Controls.Clear();

            if (!int.TryParse(textBox3.Text, out linha2))
            {
                MessageBox.Show("Por Favor adicione a lina.", "Erro");
                return;
            }
            if (!int.TryParse(textBox4.Text, out coluna2))
            {
                MessageBox.Show("Por Favor adicione a coluna.", "Erro");
                return;
            }
            int TamanhoText = groupBox2.Width / coluna2;
            Matriz2 = new TextBox[linha2, coluna2];
            TamanhoText = groupBox2.Width / coluna2;
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = "0";
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 6;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBox2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        private void btnSoma(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("Só é possível somar matrizes de mesma ordem !", "Erro - Soma Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = Calculos.SomandoMatrizes(tempMatriz1, tempMatriz2);
            matrizResultado = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
            groupBoxResultado.Controls.Clear();
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y] = new TextBox();
                    matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                    matrizResultado[x, y].Top = (x * matrizResultado[x, y].Height) + 20;
                    matrizResultado[x, y].Left = y * TamanhoText + 6;
                    matrizResultado[x, y].Width = TamanhoText;
                    groupBoxResultado.Controls.Add(matrizResultado[x, y]);
                }
            }
        }
        private void btnSubtração(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(0) != tempMatriz2.GetLength(0) || tempMatriz1.GetLength(1) != tempMatriz2.GetLength(1))
            {
                MessageBox.Show("Somente é possível a subtração de matrizes de mesma ordem !", "Erro - Soma Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = Calculos.SubtraindoMatrizes(tempMatriz1, tempMatriz2);
            matrizResultado = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
            groupBoxResultado.Controls.Clear();
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y] = new TextBox();
                    matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                    matrizResultado[x, y].Top = (x * matrizResultado[x, y].Height) + 20;
                    matrizResultado[x, y].Left = y * TamanhoText + 6;
                    matrizResultado[x, y].Width = TamanhoText;
                    groupBoxResultado.Controls.Add(matrizResultado[x, y]);
                }
            }
        }
        private void btnMultiplicação(object sender, EventArgs e)
        {
            if (Matriz1 == null || Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempMatriz1 = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] tempMatriz2 = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            if (tempMatriz1.GetLength(1) != tempMatriz2.GetLength(0))
            {
                MessageBox.Show("Só é possível a multiplicação de matrizes onde, a coluna da matriz 1 e igual a linha da matriz 2  !", "Erro - Multiplicação Matrizes");
                return;
            }

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempMatriz1[x, y] = n;
                }
            }
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempMatriz2[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = Calculos.MultiplicandoMatrizes(tempMatriz1, tempMatriz2);
            matrizResultado = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
            groupBoxResultado.Controls.Clear();
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y] = new TextBox();
                    matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                    matrizResultado[x, y].Top = (x * matrizResultado[x, y].Height) + 20;
                    matrizResultado[x, y].Left = y * TamanhoText + 6;
                    matrizResultado[x, y].Width = TamanhoText;
                    groupBoxResultado.Controls.Add(matrizResultado[x, y]);
                }
            }
        }
        #endregion

        #region Matriz1
        private void btnGerarOpostaM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = Calculos.GerarOposta(tempResultante);
            int TamanhoText = groupBox1.Width / Matriz1.GetLength(1);
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void btnGerarTranspostM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = Calculos.GerarTransposta(tempResultante);
            int TamanhoText = groupBox1.Width / Matriz1.GetLength(1);
            Matriz1 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBox1.Controls.Clear();
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y] = new TextBox();
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz1[x, y].Top = (x * Matriz1[x, y].Height) + 20;
                    Matriz1[x, y].Left = y * TamanhoText + 6;
                    Matriz1[x, y].Width = TamanhoText;
                    groupBox1.Controls.Add(Matriz1[x, y]);
                }
            }
        }
        private void btnGerarDeterminanteM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = Calculos.GerarDeterminante2x2(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = Calculos.GerarDeterminante3x3(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else
            {
                MessageBox.Show("Não é possível gerar determinante !", "Error - Matriz invalida ");
            }
        }
        private void btnGerarInversaM1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] matrizAdjunta = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float[,] matrizCofatora = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = Calculos.GerarCofatora2x2(tempResultante);
                matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                determinante = Calculos.GerarDeterminante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = Calculos.GerarCofatora3x3(tempResultante);
                matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                determinante = Calculos.GerarDeterminante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida !", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = Calculos.GerarInversa(determinante, matrizAdjunta);
            int TamanhoText = groupBox1.Width / Matriz1.GetLength(1);
            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    Matriz1[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }

        }
        #endregion

        #region Matriz2
        private void btnGerarOpostaM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }

            float[,] tempMatrizResultante = Calculos.GerarOposta(tempResultante);
            int TamanhoText = groupBox2.Width / Matriz2.GetLength(1);
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void btnGerarTranspostM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                    //tempResultante[x, y] = Convert.ToInt32(Matriz2[x, y].Text);
                }
            }

            float[,] tempMatrizResultante = Calculos.GerarTransposta(tempResultante);
            int TamanhoText = groupBox2.Width / Matriz2.GetLength(1);
            Matriz2 = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBox2.Controls.Clear();
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y] = new TextBox();
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                    Matriz2[x, y].Top = (x * Matriz2[x, y].Height) + 20;
                    Matriz2[x, y].Left = y * TamanhoText + 6;
                    Matriz2[x, y].Width = TamanhoText;
                    groupBox2.Controls.Add(Matriz2[x, y]);
                }
            }
        }
        private void btnGerarDeterminanteM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;
                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = Calculos.GerarDeterminante2x2(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = Calculos.GerarDeterminante3x3(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else
            {
                MessageBox.Show("Não é possével gerar determinante !", "Error - Matriz invalida ");
            }
        }
        private void btnGerarInversaM2_Click(object sender, EventArgs e)
        {
            if (Matriz2 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            float[,] matrizAdjunta = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            float[,] matrizCofatora = new float[Matriz2.GetLength(0), Matriz2.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }

            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz2[x, y].Text, out n);
                    tempResultante[x, y] = n;

                }
            }

            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = Calculos.GerarCofatora2x2(tempResultante);
                matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                determinante = Calculos.GerarDeterminante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = Calculos.GerarCofatora3x3(tempResultante);
                matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                determinante = Calculos.GerarDeterminante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida !", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = Calculos.GerarInversa(determinante, matrizAdjunta);
            int TamanhoText = groupBox2.Width / Matriz2.GetLength(1);
            for (int x = 0; x < Matriz2.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz2.GetLength(1); y++)
                {
                    Matriz2[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        #endregion

        #region ResultadoMatriz
        private void btnGerarInversa_Click(object sender, EventArgs e)
        {
            if (matrizResultado == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];
            float[,] matrizAdjunta = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];
            float[,] matrizCofatora = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];
            float determinante = 0;
            if (tempResultante.GetLength(0) != 2 || tempResultante.GetLength(1) != 2)
            {
                if (tempResultante.GetLength(0) != 3 || tempResultante.GetLength(1) != 3)
                {
                    MessageBox.Show("Matriz invalida !", "Error - Matriz");
                    return;
                }
            }

            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(matrizResultado[x, y].Text, out n);
                    tempResultante[x, y] = n;

                }
            }

            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                matrizCofatora = Calculos.GerarCofatora2x2(tempResultante);
                matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                determinante = Calculos.GerarDeterminante2x2(tempResultante);
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                matrizCofatora = Calculos.GerarCofatora3x3(tempResultante);
                matrizAdjunta = Calculos.GerarTransposta(matrizCofatora);
                determinante = Calculos.GerarDeterminante3x3(tempResultante);
            }
            else
            {
                MessageBox.Show("Matriz invalida 2!", "Error - Matriz");
                return;
            }
            if (determinante == 0)
            {
                MessageBox.Show("Matriz invalida, determinante igual a 0 !", "Error - Matriz");
                return;
            }
            float[,] tempMatrizResultante = Calculos.GerarInversa(determinante, matrizAdjunta);
            int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void btnGerarOposta_Click(object sender, EventArgs e)
        {
            if (matrizResultado == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];

            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(matrizResultado[x, y].Text, out n);
                    tempResultante[x, y] = n;
                   
                }
            }

            float[,] tempMatrizResultante = Calculos.GerarOposta(tempResultante);
            int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                }
            }
        }
        private void Determinante1_Click(object sender, EventArgs e)
        {
            if (Matriz1 == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[Matriz1.GetLength(0), Matriz1.GetLength(1)];

            for (int x = 0; x < Matriz1.GetLength(0); x++)
            {
                for (int y = 0; y < Matriz1.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(Matriz1[x, y].Text, out n);
                    tempResultante[x, y] = n;

                }
            }
            if (tempResultante.GetLength(0) == 2 && tempResultante.GetLength(1) == 2)
            {
                determinante = Calculos.GerarDeterminante2x2(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else if (tempResultante.GetLength(0) == 3 && tempResultante.GetLength(1) == 3)
            {
                determinante = Calculos.GerarDeterminante3x3(tempResultante);
                MessageBox.Show("" + determinante, "Determinante...");
            }
            else
            {
                MessageBox.Show("Não é possível gerar determinante !", "Error - Matriz invalida ");
            }
        }
        private void Transposta_Click(object sender, EventArgs e)
        {
            if (matrizResultado == null)
            {
                MessageBox.Show("Matriz nula !", "Error - Matriz");
                return;
            }
            float[,] tempResultante = new float[matrizResultado.GetLength(0), matrizResultado.GetLength(1)];

            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    float n = 0;
                    float.TryParse(matrizResultado[x, y].Text, out n);
                    tempResultante[x, y] = n;

                }
            }

            float[,] tempMatrizResultante = Calculos.GerarTransposta(tempResultante);
            int TamanhoText = groupBoxResultado.Width / matrizResultado.GetLength(1);
            matrizResultado = new TextBox[tempMatrizResultante.GetLength(0), tempMatrizResultante.GetLength(1)];
            groupBoxResultado.Controls.Clear();
            for (int x = 0; x < matrizResultado.GetLength(0); x++)
            {
                for (int y = 0; y < matrizResultado.GetLength(1); y++)
                {
                    matrizResultado[x, y] = new TextBox();
                    matrizResultado[x, y].Text = tempMatrizResultante[x, y].ToString();
                    matrizResultado[x, y].Top = (x * matrizResultado[x, y].Height) + 20;
                    matrizResultado[x, y].Left = y * TamanhoText + 6;
                    matrizResultado[x, y].Width = TamanhoText;
                    groupBoxResultado.Controls.Add(matrizResultado[x, y]);
                }
            }
        }
        #endregion
    }
}

       

      
    

