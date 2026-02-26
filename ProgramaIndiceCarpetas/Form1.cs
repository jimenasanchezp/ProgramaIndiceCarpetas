using System;
using System.Collections.Generic;
using System.Drawing;
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
            ConfigurarEstiloModerno();
        }

        private void ConfigurarEstiloModerno()
        {
            ImageList imageList = new ImageList { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(16, 16) };

            Bitmap bmpFolder = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpFolder))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 201, 34)), 1, 2, 14, 11);
                g.FillRectangle(new SolidBrush(Color.FromArgb(230, 175, 15)), 1, 2, 7, 3);
            }

            Bitmap bmpFile = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpFile))
            {
                g.FillRectangle(Brushes.White, 3, 1, 10, 14);
                g.DrawRectangle(Pens.LightGray, 3, 1, 10, 14);
            }

            imageList.Images.Add("folder", bmpFolder);
            imageList.Images.Add("file", bmpFile);

            tvEstructura.ImageList = imageList;
            tvEstructura.ShowLines = false;
        }

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

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(rutaRaizActual) && Directory.Exists(rutaRaizActual))
            {
                ProcesarCarpeta();
            }
            else
            {
                MessageBox.Show("Selecciona una carpeta válida primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // 🔹 NUEVO: Botón para guardar manualmente el CSV
        private void btnGuardarCSV_Click(object sender, EventArgs e)
        {
            if (indiceGlobal.Count == 0)
            {
                MessageBox.Show("No hay datos para guardar. Escanea una carpeta primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                // 1. AQUÍ DEFINIMOS LAS EXTENSIONES DISPONIBLES
                // El usuario verá un menú desplegable para elegir el formato deseado.
                sfd.Filter = "Archivo CSV (*.csv)|*.csv|Archivo de Texto (*.txt)|*.txt|Archivo JSON (*.json)|*.json|Documento PDF (*.pdf)|*.pdf";
                sfd.Title = "Guardar índice como...";
                sfd.FileName = "IndiceCarpetas";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // 2. AQUÍ SE UTILIZA LA CLASE ExportadorDatos
                        // Dependiendo de la extensión que el usuario eligió en el filtro, llamamos al método correspondiente.
                        switch (sfd.FilterIndex)
                        {
                            case 1: // Si eligió la primera opción (CSV)
                                ExportadorDatos.ExportarCSV(indiceGlobal, sfd.FileName);
                                break;
                            case 2: // Si eligió la segunda opción (TXT)
                                ExportadorDatos.ExportarTXT(indiceGlobal, sfd.FileName);
                                break;
                            case 3: // Si eligió la tercera opción (JSON)
                                ExportadorDatos.ExportarJSON(indiceGlobal, sfd.FileName);
                                break;
                            case 4: // Si eligió la cuarta opción (PDF)
                                ExportadorDatos.ExportarPDF(indiceGlobal, sfd.FileName);
                                break;
                        }

                        MessageBox.Show("Archivo exportado correctamente en el formato seleccionado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al exportar el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void ProcesarCarpeta()
        {
            tvEstructura.Nodes.Clear();
            indiceGlobal.Clear();

            DirectoryInfo dirRaiz = new DirectoryInfo(rutaRaizActual);
            TreeNode nodoRaiz = new TreeNode(dirRaiz.Name) { ImageKey = "folder", SelectedImageKey = "folder" };
            tvEstructura.Nodes.Add(nodoRaiz);

            Cursor.Current = Cursors.WaitCursor;
            EscanearDirectorio(dirRaiz, nodoRaiz);
            Cursor.Current = Cursors.Default;

            nodoRaiz.Expand();
        }

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
                    nodoPadre.Nodes.Add(new TreeNode(archivo.Name) { ImageKey = "file", SelectedImageKey = "file", ForeColor = Color.FromArgb(50, 50, 50) });
                }

                foreach (DirectoryInfo subDir in dir.GetDirectories())
                {
                    TreeNode subNodo = new TreeNode(subDir.Name) { ImageKey = "folder", SelectedImageKey = "folder" };
                    nodoPadre.Nodes.Add(subNodo);
                    EscanearDirectorio(subDir, subNodo);
                }
            }
            catch (UnauthorizedAccessException) { }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string query = txtBuscar.Text.Trim().ToLower();
            if (string.IsNullOrWhiteSpace(query)) return;

            dgvResultados.Rows.Clear();

            var resultados = indiceGlobal.Where(c => c.Archivos.Any(a => a.ToLower().Contains(query))).ToList();

            foreach (var carpeta in resultados)
            {
                foreach (var archivo in carpeta.Archivos.Where(a => a.ToLower().Contains(query)))
                {
                    dgvResultados.Rows.Add(archivo, carpeta.NombreCarpeta, carpeta.RutaCompleta);
                }
            }
        }

        private void btnExportarArchivo_Click(object sender, EventArgs e)
        {
            // 1. Verificar que haya un archivo seleccionado en la tabla
            if (dgvResultados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un archivo de la lista para exportarlo.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Obtener la ruta completa del archivo seleccionado
            string nombreArchivo = dgvResultados.SelectedRows[0].Cells["colArchivo"].Value.ToString();
            string rutaCarpeta = dgvResultados.SelectedRows[0].Cells["colRuta"].Value.ToString();
            string rutaCompletaOrigen = Path.Combine(rutaCarpeta, nombreArchivo);

            if (!File.Exists(rutaCompletaOrigen))
            {
                MessageBox.Show("El archivo original no se encuentra en el disco.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 3. Preguntar al usuario dónde y en qué formato quiere guardar EL ARCHIVO
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Title = "Exportar archivo seleccionado como...";
                sfd.FileName = Path.GetFileNameWithoutExtension(nombreArchivo) + "_exportado";
                sfd.Filter = "Documento PDF (*.pdf)|*.pdf|Archivo de Texto (*.txt)|*.txt|Archivo JSON (*.json)|*.json|Archivo CSV (*.csv)|*.csv";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        // 4. AQUI SE UTILIZA LA CLASE ESTÁTICA dependiendo de la extensión elegida
                        switch (sfd.FilterIndex)
                        {
                            case 1: // PDF
                                ConvertidorArchivos.ExportarAPdf(rutaCompletaOrigen, sfd.FileName);
                                break;
                            case 2: // TXT
                                ConvertidorArchivos.ExportarATxt(rutaCompletaOrigen, sfd.FileName);
                                break;
                            case 3: // JSON
                                ConvertidorArchivos.ExportarAJson(rutaCompletaOrigen, sfd.FileName);
                                break;
                            case 4: // CSV
                                ConvertidorArchivos.ExportarACsv(rutaCompletaOrigen, sfd.FileName);
                                break;
                        }

                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("El archivo se exportó correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        Cursor.Current = Cursors.Default;
                        MessageBox.Show("Error al convertir el archivo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }

    public class CarpetaInfo
    {
        public string NombreCarpeta { get; set; }
        public string RutaCompleta { get; set; }
        public int CantidadArchivos { get; set; }
        public List<string> Archivos { get; set; } = new List<string>();
    }
}