using Controladores;
using System.Windows;

namespace Vistas
{
    public partial class pantallaRegistrarResultadoRevisionManual : Window
    {
        #region atributos

        public controladorRegistrarResultadoRevisionManual gestor;
        public List<EventoSismico> eventosSismicos = new List<EventoSismico>();


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
            // Aquí puedes agregar la lógica para procesar el resultado y observaciones
            MessageBox.Show("Resultado registrado correctamente.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            this.DialogResult = true;
            this.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }

        public void presentarEventosSismicosPendientesDeRevision(List<EventoSismico> eventosSismicos)
        {
            // Asume que tienes un DataGrid llamado "dgEventosSismicos" en tu XAML
            dgEventosSismicos.ItemsSource = eventosSismicos;
        }

    }
}