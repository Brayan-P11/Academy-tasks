using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.VisualStyles;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using task_negozio_270324.DAL;
using task_negozio_270324.Models;

namespace task_negozio_270324
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Lista di prodotti in una grid
            //dgProdotti.ItemsSource = ProdottoDAL.getIstanza().GetAll();
            Console.WriteLine(ProdottoDAL.GetIstance().GetById(1));
            

        }

        #region METODI PRODOTTI

        private void btnSalva_Click(object sender, RoutedEventArgs e)
        {
            string? nome = this.tbNome.Text;
            string? marca = this.tbMarca.Text;
            string? galleria = this.tbGalleria.Text;
            string? colore = this.tbColore.Text;
            string? taglia = this.tbTaglia.Text;
            int categoriaRIF = Convert.ToInt32(this.tbCategoriaRif.Text);

            Prodotto temp = new Prodotto()
            {
                Nome = nome,
                Marca = marca,
                Galleria = galleria,
                Colore = colore,
                Taglia = taglia,
                CategoriaRif = categoriaRIF
            };

            if (ProdottoDAL.GetIstance().Insert(temp))
            {
                MessageBox.Show("Prodotto inserito!");
                // possibilita di controllare la lista dopo l'inserimento
                //dgProdotti.ItemsSource = ProdottoDAL.GetIstance().GetAll();
            }
            else
                MessageBox.Show("Errore di inserimento");

            this.tbNome.Text = "";
            this.tbMarca.Text = "";
            this.tbGalleria.Text = "";
            this.tbColore.Text = "";
            this.tbTaglia.Text = "";
            this.tbCategoriaRif.Text = "";


        }

        private void btnLista_Prodotti(object sender, RoutedEventArgs e)
        {
            dgProdotti.ItemsSource = ProdottoDAL.GetIstance().GetAll();
        }

        private void btnElimina_Prodotto(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.tbProdottoId.Text);
            if (ProdottoDAL.GetIstance().DeleteById(id))
            {
                MessageBox.Show("Prodotto eliminato!");
            }
            else
            {
                MessageBox.Show("Errore riprova!");
            }
            this.tbProdottoId.Text = "";
        }

        //METODO UPDATE NON FUNZIONA
        private void btnModifica_Prodotto(object sender, RoutedEventArgs e)
        {
            // apertura di un'altra pagina
            //if (MainFrame != null)
            //{
            //    MainFrame.Navigate(new Uri("ProdottoWindow.xaml", UriKind.Relative));
            //}
            //else
            //{
            //    Console.WriteLine("Il frame principale non è stato impostato correttamente.");
            //}

            //------------------------------------------------
            int id = Convert.ToInt32(this.tbProdottoIdMod.Text);
            Prodotto? tmpProd = ProdottoDAL.GetIstance().GetById(id);
            Console.WriteLine(tmpProd.ToString());

            if( tmpProd != null)
            {
                string? nome = this.tbNome.Text;
                string? marca = this.tbMarca.Text;
                string? galleria = this.tbGalleria.Text;
                string? colore = this.tbColore.Text;
                string? taglia = this.tbTaglia.Text;

                tmpProd.Nome = nome;
                tmpProd.Marca = marca;
                tmpProd.Galleria = galleria;
                tmpProd.Colore = colore;
                tmpProd.Taglia = taglia;

                ProdottoDAL.GetIstance().Update(tmpProd);
                MessageBox.Show("Prodotto modificato!");
                dgProdotti.ItemsSource = ProdottoDAL.GetIstance().GetAll();
            }
            else 
            {
                MessageBox.Show("Errore di modifica");
            }
        }
        #endregion

        #region METODI CATEGORIE

        private void btnSalvaCat_Click(object sender, RoutedEventArgs e)
        {
            string? nome = this.tbNomeCat.Text;

            Categorium cate = new Categorium()
            {
                Nome = nome,
            };
            if(CategoriumDAL.GetIstance().Insert(cate))
            {
                MessageBox.Show("Categroria inserita correttamente!");
            }
            else
            {
                MessageBox.Show("Errore di inserimento :(");
            }
            this.tbNomeCat.Text = "";


        }

        private void btnElimina_Categoria(object sender, RoutedEventArgs e)
        {
            int id = Convert.ToInt32(this.tbCategoriaId.Text);

            if (CategoriumDAL.GetIstance().DeleteById(id))
            {
                MessageBox.Show("Categoria eliminata correttamente!");
            }else
            {
                MessageBox.Show("Errore riprova!");
            }
            this.tbCategoriaId.Text = "";
        }

        

        private void btnLista_Categorie(object sender, RoutedEventArgs e)
        {
            dgCategorie.ItemsSource = CategoriumDAL.GetIstance().GetAll();
        }
        #endregion
    }
}