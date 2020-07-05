using OrdenSuplidor.BLL;
using OrdenSuplidor.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrdenSuplidor.UI.Registros
{
    /// <summary>
    /// Interaction logic for rOrdenes.xaml
    /// </summary>
    public partial class rOrdenes : Window
    {
        private Ordenes Orden = new Ordenes();

        public rOrdenes()
        {
            InitializeComponent();
            this.DataContext = Orden;

            //Llenamos el SuplidorComboBox
            SuplidorIdComboBox.ItemsSource = SuplidorBLL.GetSuplidores();
            SuplidorIdComboBox.SelectedValuePath = "Suplidores";
            SuplidorIdComboBox.DisplayMemberPath = "SuplidorId";

            //Llenamos el ProductosComboBox
            ProductosComboBox.ItemsSource = ProductosBLL.GetProductos();
            ProductosComboBox.SelectedValuePath = "Productos";
            ProductosComboBox.DisplayMemberPath = "ProductoId";

        }

        private void BucarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarOrdenId())
            {
                return;
            }

            Orden = OrdenesBLL.Buscar(int.Parse(OrdenIdTextBox.Text));
            Cargar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarAgregar())
                return;

            

            Cargar();

            
        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.SelectedIndex < 0)
                return;

            Orden.OrdenesDetalles.RemoveAt(DetalleDataGrid.SelectedIndex);
            
            Cargar();

        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarGuardar())
                return;

            if (OrdenesBLL.Guardar(Orden))
            {
                Limpiar();
                MessageBox.Show("Guardado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidarOrdenId())
                return;
            if (OrdenesBLL.Eliminar(int.Parse(OrdenIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Eliminado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Algo salio mal.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void Cargar()
        {
            this.DataContext = null;
            this.DataContext = Orden;
        }

        public bool ValidarOrdenId()
        {
            if (!OrdenesBLL.Existe(int.Parse(OrdenIdTextBox.Text)))
            {
                MessageBox.Show("Ese registro no existe.", "", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            if (!Regex.IsMatch(OrdenIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se admiten caracteres numericos.", "Campo OrdenId.", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

            return true;
        }

        public void Limpiar()
        {
            this.Orden = new Ordenes();
            this.DataContext = Orden;
        }

        public bool ValidarAgregar()
        {
            if (CantidadTextBox.Text.Length == 0 || CostoTextBox.Text.Length == 0)
            {
                MessageBox.Show("No pueden haber campos vacios.", "Campo vacio.", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (!Regex.IsMatch(CantidadTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo Cantidad.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(CostoTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo Costo.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(OrdenIdTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo OrdenId.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }


            if (!Regex.IsMatch(MontoTextBox.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo Monto.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        public bool ValidarGuardar()
        {
            if (!Regex.IsMatch(OrdenIdTextBox.Text, "^[1-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo OrdenId.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            if (!Regex.IsMatch(MontoTextBox.Text, "^[1-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.", "Campo Monto.", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }

        private void SuplidorIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var suplidor = ((Suplidores)SuplidorIdComboBox.SelectedItem);
 
            NombresSuplidorTextBox.Text = suplidor.Nombres;
        }

        private void ProductosComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var producto = ((Productos)ProductosComboBox.SelectedItem);

            CostoTextBox.Text = producto.Costo.ToString();
            DescripcionTextBox.Text = producto.Descripcion;
            InventarioTextBox.Text = producto.Inventario.ToString();
        }
    }
}
