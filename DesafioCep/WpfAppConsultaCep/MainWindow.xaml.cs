using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Correios;
using WpfCep.Entities;
using WpfCep.Repositories;

namespace WpfAppConsultaCep
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LerCep();

        }

        private void LerCep()
        {
            var cep = new Cep();
            cep.NumCep = txtCep.Text;
            
            var repository = new BaseRepository();
            var carregarCep = repository.SelectCep(cep.NumCep);

            try
            {
                if(carregarCep is null)
                {
                    var ApiCep = new CorreiosApi();
                    var consulta = ApiCep.consultaCEP(txtCep.Text);

                    txtLogradouro.Text = consulta.end;
                    txtComplemento.Text = consulta.complemento;
                    txtBairro.Text = consulta.bairro;
                    txtLocalidade.Text = consulta.cidade;
                    txtUf.Text = consulta.uf;

                }

                else
                {
                    txtLogradouro.Text = carregarCep.Logradouro;
                    txtComplemento.Text = carregarCep.Complemento;
                    txtBairro.Text = carregarCep.Bairro;
                    txtLocalidade.Text = carregarCep.Localidade;
                    txtUf.Text = carregarCep.Uf;
                }
                
            }
            catch (Exception e)
            {
                MessageBox.Show("Erro de validação", e.Message);
            }

        

        }

        private void BtnSair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnGravar_Click(object sender, RoutedEventArgs e)
        {
            GravarCep();
        }

        private void GravarCep()
        {
            try
            {
                var cep = new Cep();
                cep.NumCep = txtCep.Text;

                var repository = new BaseRepository();
                var carregarCep = repository.SelectCep(cep.NumCep);

                if (carregarCep is null)
                {
                    cep.NumCep = txtCep.Text;
                    cep.Logradouro = txtLogradouro.Text;
                    cep.Complemento = txtComplemento.Text;
                    cep.Bairro = txtBairro.Text;
                    cep.Localidade = txtLocalidade.Text;
                    cep.Uf = txtUf.Text;

                    repository.Insert(cep);

                    MessageBox.Show("Cep cadastrado com sucesso");
                }
                else
                {
                    MessageBox.Show("Cep já está cadastrado no banco de dados");
                }

            }
            catch(Exception e)
            {
                MessageBox.Show("Erro de validação", e.Message);
            }
            
        }
    }
    
}
