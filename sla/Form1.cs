using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

           
            //executaBuscaBasica();
            //executaBusca();
            executaBuscaTratada();
          
          

           
        }

        private void executaBuscaBasica()
        {
            int c = Convert.ToInt32(msktCepPesquisar.Text);

            BuscaCEP buscaCEP = new BuscaCEP(c);

            txtLogradouro.Text = buscaCEP.Rua;
            txtBairro.Text = buscaCEP.Bairro;
            txtCidade.Text = buscaCEP.Cidade;  
            txtUf.Text = buscaCEP.Estado;
        }
        private void executaBusca()
        {
            try
            {

                msktCepPesquisar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                var valorSemMascara1 = msktCepPesquisar.Text;

                int c;
                string entrada = valorSemMascara1;

                if (int.TryParse(entrada, out c))
                {
                    BuscaCEP buscaCEP = new BuscaCEP(c);

                    txtLogradouro.Text = buscaCEP.Rua;
                    txtBairro.Text = buscaCEP.Bairro;
                    txtCidade.Text = buscaCEP.Cidade;
                    txtUf.Text = buscaCEP.Estado;
                }
                else
                {
                    MessageBox.Show("Por favor, insira um CEP válido.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    msktCepPesquisar.Clear();
                    msktCepPesquisar.Focus();
                }
                msktCepPesquisar.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            catch
            {
                MessageBox.Show("Por favor, insira um CEP válido.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                msktCepPesquisar.Clear();
                msktCepPesquisar.Focus();
            }

            
        }
        private void executaBuscaTratada()
        {
            try
            {

                msktCepPesquisar.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                var valorSemMascara1 = msktCepPesquisar.Text;

                int c;
                string input = valorSemMascara1;

                if (int.TryParse(input, out c) && input.Length == 8)
                {
                    BuscaCEP buscaCEP = new BuscaCEP(c);

                    if (string.IsNullOrEmpty(buscaCEP.Cep))
                    {
                        limparcampos();
                        MessageBox.Show("CEP não encontrado." + "Verifique o número digitado e tente novamente." , "CEP Inválido", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        msktCepPesquisar.Clear();
                        msktCepPesquisar.Focus();
                    }
                    else
                    {
                        txtLogradouro.Text = buscaCEP.Rua;
                        txtBairro.Text = buscaCEP.Bairro;
                        txtCidade.Text = buscaCEP.Cidade;
                        txtUf.Text = buscaCEP.Estado;
                    }

                   
                }
                msktCepPesquisar.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }
            catch
            {
                limparcampos();
                MessageBox.Show("Por favor, insira um CEP válido.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                msktCepPesquisar.Focus();
            }
        }
        private void limparcampos()
        {
            txtBairro.Clear();
            txtCidade.Clear();
            txtLogradouro.Clear();
            txtUf.Clear();
            msktCepPesquisar.Clear();
        }

        private void msktCepPesquisar_Leave(object sender, EventArgs e)
        {
            if (msktCepPesquisar.MaskCompleted)
            {
                executaBuscaTratada();
            }
            
        }
    }
}
