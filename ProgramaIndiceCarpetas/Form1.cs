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

        // 🔹 Configuración Visual Moderna (Íconos y Estilos)
        private void ConfigurarEstiloModerno()
        {
            // Crear íconos en memoria para no depender de archivos externos
            ImageList imageList = new ImageList { ColorDepth = ColorDepth.Depth32Bit, ImageSize = new Size(16, 16) };

            // Dibujar ícono de carpeta
            Bitmap bmpFolder = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpFolder))
            {
                g.FillRectangle(new SolidBrush(Color.FromArgb(255, 201, 34)), 1, 2, 14, 11); // Carpeta amarilla
                g.FillRectangle(new SolidBrush(Color.FromArgb(230, 175, 15)), 1, 2, 7, 3);   // Pestaña
            }

            // Dibujar ícono de archivo
            Bitmap bmpFile = new Bitmap(16, 16);
            using (Graphics g = Graphics.FromImage(bmpFile))
            {
                g.FillRectangle(Brushes.White, 3, 1, 10, 14);
                g.DrawRectangle(Pens.LightGray, 3, 1, 10, 14);
            }

            imageList.Images.Add("folder", bmpFolder);
            imageList.Images.Add("file", bmpFile);

            tvEstructura.ImageList = imageList;
            tvEstructura.ShowLines = false; // Quita las líneas punteadas estilo XP
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
            GenerarArchivoCSV();
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
                MessageBox.Show("Error al generar CSV: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }

    public class CarpetaInfo
    {
        public string NombreCarpeta { get; set; }
        public string RutaCompleta { get; set; }
        public int CantidadArchivos { get; set; }
        public List<string> Archivos { get; set; } = new List<string>();
    }
}