using System.Windows;

namespace PPAI_REDSISMICA
{
    public partial class VentanaRevisionManual : Window
    {
        public VentanaRevisionManual()
        {
            InitializeComponent();
        }

        // M�todo para instanciar y mostrar la pantalla para su posterior uso
        public static VentanaRevisionManual Habilitar()
        {
            return new VentanaRevisionManual();         
        }
    }
}