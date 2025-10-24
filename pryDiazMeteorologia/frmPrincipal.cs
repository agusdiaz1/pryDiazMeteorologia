using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryDiazMeteorologia
{
    public partial class frmPrincipal : Form
    {
        conexionBD conexion = new conexionBD();
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            ConfigurarListView();
            CargarTreeView();
        }

        private void ConfigurarListView()
        {
            lvTemperaturas.View = View.Details;
            lvTemperaturas.Columns.Add("Temp. Mínima", 120);
            lvTemperaturas.Columns.Add("Temp. Máxima", 120);
        }

        private void CargarTreeView()
        {
            tvUbicaciones.Nodes.Clear();
            TreeNode nodoProvincias = new TreeNode("PROVINCIAS");
            tvUbicaciones.Nodes.Add(nodoProvincias);

            List<Provincia> provincias = conexion.ObtenerProvincias();

            foreach (var prov in provincias)
            {
                TreeNode nodoProv = new TreeNode(prov.NombreProvincia);
                nodoProv.Tag = prov.IdProvincia;
                nodoProvincias.Nodes.Add(nodoProv);

                List<Localidad> localidades = conexion.ObtenerLocalidades(prov.IdProvincia);

                foreach (var loc in localidades)
                {
                    TreeNode nodoLoc = new TreeNode(loc.NombreLocalidad);
                    nodoLoc.Tag = loc.IdLocalidad;
                    nodoProv.Nodes.Add(nodoLoc);
                }
            }

            tvUbicaciones.ExpandAll();
        }


        private void tvUbicaciones_AfterSelect_1(object sender, TreeViewEventArgs e)
        {
            lvTemperaturas.Items.Clear();
            DateTime fecha = dtpFecha.Value;

            if (e.Node.Parent == null) return; // evita nodo raíz

            // Si el nodo seleccionado es una localidad
            if (e.Node.Parent.Parent != null)
            {
                int idLoc = Convert.ToInt32(e.Node.Tag);
                var temp = conexion.ObtenerTemperaturaLocalidad(idLoc, fecha);

                if (temp != null)
                {
                    ListViewItem item = new ListViewItem(temp.TempMin + "°C");
                    item.SubItems.Add(temp.TempMax + "°C");
                    lvTemperaturas.Items.Add(item);
                }
                else
                    lvTemperaturas.Items.Add(new ListViewItem("Sin datos para la fecha seleccionada"));

                stpSeleccion.Text = $"Seleccionado: {e.Node.Parent.Text} - {e.Node.Text}";
            }
            // Si el nodo seleccionado es una provincia
            else if (e.Node.Parent.Text == "PROVINCIAS")
            {
                int idProv = Convert.ToInt32(e.Node.Tag);
                var temps = conexion.ObtenerTemperaturasProvincia(idProv, fecha);

                if (temps.Count > 0)
                {
                    foreach (var t in temps)
                    {
                        ListViewItem item = new ListViewItem(t.TempMin + "°C");
                        item.SubItems.Add(t.TempMax + "°C");
                        lvTemperaturas.Items.Add(item);
                    }
                }
                else
                    lvTemperaturas.Items.Add(new ListViewItem("Sin datos para la fecha seleccionada"));

                stpSeleccion.Text = $"Seleccionado: {e.Node.Text}";
            }
        }
    }
}

