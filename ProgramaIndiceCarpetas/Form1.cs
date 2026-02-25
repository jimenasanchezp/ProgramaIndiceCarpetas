using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ProgramaIndiceCarpetas
{
    public partial class Form1 : Form
    {
        private string rutaRaizActual = "";
        private List<CarpetaInfo> indiceGlobal = new List<CarpetaInfo>();

        public Form1()
        {
            InitializeComponent();
        }

        // 🔹 1. Selección de carpeta
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Selecciona la carpeta raíz a indexar";
                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    rutaRaizActual = fbd.SelectedPath;
                    txtRuta.Text = rutaRaizActual;
                    ProcesarCarpeta();
                }
            }
        }

        // 🔹 5. Botón Actualizar
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rutaRaizActual) && Directory.Exists(rutaRaizActual))
            {
                ProcesarCarpeta();
                MessageBox.Show("Índice actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una carpeta válida primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 🔹 Flujo principal: Escanear, poblar árbol y generar CSV
        private void ProcesarCarpeta()
        {
            tvEstructura.Nodes.Clear();
            indiceGlobal.Clear();

            DirectoryInfo dirRaiz = new DirectoryInfo(rutaRaizActual);
            TreeNode nodoRaiz = new TreeNode(dirRaiz.Name);
            tvEstructura.Nodes.Add(nodoRaiz);

            Cursor.Current = Cursors.WaitCursor; // Cambiar el cursor mientras escanea
            EscanearDirectorio(dirRaiz, nodoRaiz);
            Cursor.Current = Cursors.Default;

            nodoRaiz.Expand();
            GenerarArchivoCSV();
        }

        // 🔹 2 y 3. Visualización e Indexación (Recursiva)
        private void EscanearDirectorio(DirectoryInfo dir, TreeNode nodoPadre)
        {
            try
            {
                FileInfo[] archivos = dir.GetFiles();
                CarpetaInfo info = new CarpetaInfo
                {
                    NombreCarpeta = dir.Name,
                    RutaCompleta = dir.FullName,
                    CantidadArchivos = archivos.Length,
                    Archivos = archivos.Select(a => a.Name).ToList()
                };

                indiceGlobal.Add(info);

                foreach (var archivo in archivos)
                {
                    nodoPadre.Nodes.Add(new TreeNode(archivo.Name) { ForeColor = System.Drawing.Color.Gray });
                }

                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    TreeNode subNodo = new TreeNode(subDir.Name);
                    nodoPadre.Nodes.Add(subNodo);
                    EscanearDirectorio(subDir, subNodo);
                }
            }
            catch (UnauthorizedAccessException)
            {
                // Ignorar carpetas del sistema a las que no se tiene acceso
            }
        }

        // 🔹 3. Generación del índice (Archivo CSV)
        private void GenerarArchivoCSV()
        {
            try
            {
                string rutaCsv = Path.Combine(rutaRaizActual, "IndiceCarpetas.csv");
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("Carpeta,RutaCompleta,CantidadArchivos,Archivos");

                foreach (var item in indiceGlobal)
                {
                    string archivosUnidos = string.Join("; ", item.Archivos);
                    sb.AppendLine($"\"{item.NombreCarpeta}\",\"{item.RutaCompleta}\",{item.CantidadArchivos},\"{archivosUnidos}\"");
                }

                File.WriteAllText(rutaCsv, sb.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 🔹 4. Buscador de archivos
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = txtBuscar.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(query)) return;

            dgvResultados.Rows.Clear();

            var resultados = indiceGlobal
                .Where(c => c.Archivos.Any(a => a.ToLower().Contains(query)))
                .ToList();

            foreach (var carpeta in resultados)
            {
                var archivosEncontrados = carpeta.Archivos.Where(a => a.ToLower().Contains(query));
                foreach (var archivo in archivosEncontrados)
                {
                    dgvResultados.Rows.Add(archivo, carpeta.NombreCarpeta, carpeta.RutaCompleta);
                }
            }

            if (dgvResultados.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron archivos con ese nombre.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    // 🔹 Estructura de Datos
    public class CarpetaInfo
    {
        public string NombreCarpeta { get; set; }
        public string RutaCompleta { get; set; }
        public int CantidadArchivos { get; set; }
        public List<string> Archivos { get; set; } = new List<string>();
    }
}