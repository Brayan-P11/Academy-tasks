using Microsoft.EntityFrameworkCore.Diagnostics.Internal;
using System.Text;
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
                dgProdotti.ItemsSource = ProdottoDAL.GetIstance().GetAll();
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
            int id = Convert.ToInt32(this.tbProdottoId1.Text);
            if (ProdottoDAL.GetIstance().DeleteById(id))
            {
                MessageBox.Show("Prodotto eliminato!");
            }
            else
            {
                MessageBox.Show("errore!");
            }
            this.tbProdottoId1.Text = "";
        }

        private void btnModifica_Prodotto(object sender, RoutedEventArgs e)
        {
            if (MainFrame != null)
            {
                MainFrame.Navigate(new Uri("Pagina2.xaml", UriKind.Relative));
            }
            else
            {
                Console.WriteLine("Il frame principale non è stato impostato correttamente.");
            }
            string? nome = this.tbNome.Text;
            string? marca = this.tbMarca.Text;
            string? galleria = this.tbGalleria.Text;
            string? colore = this.tbColore.Text;
            string? taglia = this.tbTaglia.Text;

            Prodotto temp = new Prodotto()
            {
                Nome = nome,
                Marca = marca,
                Galleria = galleria,
                Colore = colore,
                Taglia = taglia,
                
            };
            if (ProdottoDAL.GetIstance().Update(temp))
            {
                MessageBox.Show("Prodotto modificato!");
                dgProdotti.ItemsSource = ProdottoDAL.GetIstance().GetAll();
            }
            else
                MessageBox.Show("Errore di modifica");

        }
    }
}