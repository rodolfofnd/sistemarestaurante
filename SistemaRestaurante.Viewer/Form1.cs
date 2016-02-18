using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SistemaRestaurante;
using SistemaRestaurante.Business;
using SistemaRestaurante.Entity;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new CategoriaBO().ListaCategoria();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new CategoriaBO().IncluiCategoria(new Categoria
                    {
                        descricaoCategoria = "teste de categoria",
                        nomeCategoria = "teste",
                    });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new OpcaoMudancaBO().IncluiOpcaoMudanca(new OpcaoMudanca { descricao = "teste"});
        }
    }
}
