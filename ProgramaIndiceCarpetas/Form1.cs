using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace ProgramaIndiceCarpetas
{
    public partial class Form1 : Form
    {
        // Esta variable mantiene nuestro índice en memoria para búsquedas rápidas
        private List<DirectorioInfo> _indiceGlobal;
        private string _rutaActualSeleccionada = string.Empty;

        public Form1()
        {
            InitializeComponent();
            _indiceGlobal = new List<DirectorioInfo>();

            // Opcional: Configurar el DataGridView para que se ajuste bonito
            dgvIndice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvIndice.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvIndice.ReadOnly = true;
        }



        // 🔹 MÉTODO CENTRAL: ESCANEAR, MOSTRAR Y GUARDAR
        private void ProcesarCarpeta()
        {
            Cursor = Cursors.WaitCursor; // Cambia el cursor para indicar que está cargando

            // 1. Escanear
            _indiceGlobal = _motorIndice.EscanearDirectorio(_rutaActualSeleccionada);

            // 2. Mostrar en el DataGridView
            ActualizarGrid(_indiceGlobal);

            // 3. Generar el CSV en la misma carpeta raíz (o donde prefieras)
            string rutaCsv = Path.Combine(_rutaActualSeleccionada, "IndiceDeArchivos.csv");
            _motorIndice.GenerarArchivoCSV(_indiceGlobal, rutaCsv);

            Cursor = Cursors.Default;
        }


        // 🔹 MÉTODO AUXILIAR PARA LLENAR EL DATAGRIDVIEW
        private void ActualizarGrid(List<DirectorioInfo> listaMostrar)
        {
            // Mapeamos la lista a un formato anónimo para que se vea limpio en las columnas del DataGridView
            var datosVisuales = listaMostrar.Select(d => new
            {
                Carpeta = d.NombreCarpeta,
                Cantidad = d.CantidadArchivos,
                Archivos = string.Join("; ", d.Archivos),
                Ruta = d.RutaCompleta
            }).ToList();

            dgvIndice.DataSource = null; // Limpiamos primero
            dgvIndice.DataSource = datosVisuales;
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona la carpeta raíz a indexar";

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    _rutaActualSeleccionada = fbd.SelectedPath;
                    lblRuta.Text = $"Ruta: {_rutaActualSeleccionada}";

                    ProcesarCarpeta();
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_rutaActualSeleccionada) || !Directory.Exists(_rutaActualSeleccionada))
            {
                MessageBox.Show("Primero selecciona una carpeta válida.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ProcesarCarpeta();
        }

        private void txtBuscar_TextChanged_1(object sender, EventArgs e)
        {
            string textoBusqueda = txtBuscar.Text.ToLower().Trim();

            if (string.IsNullOrEmpty(textoBusqueda))
            {
                // Si está vacío, mostramos todo
                ActualizarGrid(_indiceGlobal);
            }
            else
            {
                // Filtramos: Busca si el nombre de la carpeta coincide, O si algún archivo interno coincide
                var resultados = _indiceGlobal.Where(dir => !(!dir.NombreCarpeta.ToLower().Contains(textoBusqueda) &&
!                   dir.Archivos.Any(archivo => archivo.ToLower().Contains(textoBusqueda)))
                ).ToList();

                ActualizarGrid(resultados);
            }
        }
    }

    class DirectorioInfo
    {
        public string NombreCarpeta { get; internal set; }
        public int CantidadArchivos { get; internal set; }
        public List<string> Archivos { get; internal set; }
        public string RutaCompleta { get; internal set; }
    }
}