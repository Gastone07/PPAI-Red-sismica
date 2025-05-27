using Controladores;
using System.Windows;

namespace Vistas
{
    public partial class pantallaRegistrarResultadoRevisionManual : Window
    {
        #region atributos

        private controladorRegistrarResultadoRevisionManual gestor;

        #endregion
        public pantallaRegistrarResultadoRevisionManual()
        {
            habilitar();
            gestor = new controladorRegistrarResultadoRevisionManual(this);
            gestor.registrarResultadoDeRevisionManual();
        }

        public void habilitar()
        {
            InitializeComponent();
        }
       
        private void btnAceptar_Click(object sender, RoutedEventArgs e)
        {
            // Aqu� puedes agregar la l�gica para procesar el resultado y observaciones
            MessageBox.Show("Resultado registrado correctamente.", "Informaci�n", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}