using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace netLab04
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString= "Data Source=LAB1504-17\\SQLEXPRESS ;Initial Catalog=NeptunoDB;User Id=userTecsup04;Password=userTecsup4;TrustServerCertificate=true";
            ;
            List<Tienda> productos = new List<Tienda>();
            try
            {
                //Cadena de conexión
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                //Comandos de TRANSACT SQL
                SqlCommand command = new SqlCommand("USP_ListarProductos", connection);
                command.CommandType = CommandType.StoredProcedure;

                //CONECTADA
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idproducto = reader.GetInt32(reader.GetOrdinal("idproducto"));
                    string nombreProducto = reader.GetString("nombreProducto");
                    int idProveedor = reader.GetInt32(reader.GetOrdinal("idProveedor"));
                    int idCategoria = reader.GetInt32(reader.GetOrdinal("idCategoria"));
                    string cantidadPorUnidad = reader.GetString("cantidadPorUnidad");

                    productos.Add(new Tienda { idproducto = idproducto, nombreProducto = nombreProducto, idProveedor = idProveedor, idCategoria = idCategoria, cantidadPorUnidad = cantidadPorUnidad });

                }
                dgvDemo.ItemsSource = productos;

                connection.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la recuperación o llenado de datos
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LAB1504-17\\SQLEXPRESS ;Initial Catalog=NeptunoDB;User Id=userTecsup04;Password=userTecsup4;TrustServerCertificate=true";
            ;
            List<Categoria> productos = new List<Categoria>();
            try
            {
                //Cadena de conexión
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                //Comandos de TRANSACT SQL
                SqlCommand command = new SqlCommand("USP_ListarCategorias", connection);
                command.CommandType = CommandType.StoredProcedure;

                //CONECTADA
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idcategoria = reader.GetInt32(reader.GetOrdinal("idcategoria"));
                    string nombrecategoria = reader.GetString("nombrecategoria");
                    int descripcion = reader.GetInt32(reader.GetOrdinal("descripcion"));
                    int activo = reader.GetInt32(reader.GetOrdinal("activo"));
                    string codcategoria = reader.GetString("codcategoria");

                    productos.Add(new Categoria { idcategoria = idcategoria, nombrecategoria = nombrecategoria, descripcion = descripcion, activo = activo, codcategoria = codcategoria });

                }
                dgvDemo.ItemsSource = productos;

                connection.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepción que pueda ocurrir durante la recuperación o llenado de datos
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}