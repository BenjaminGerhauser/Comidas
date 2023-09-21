using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comidas
{
    public partial class Form1 : Form
    {
        Personas oPersona;
        DataTable tper;
        Comidas oComida;
        DataTable tcom;
        MeGusta oMeGusta;
        DataTable tGusta;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            oPersona = new Personas();
            tper = oPersona.getData();

            oComida = new Comidas();
            tcom = oComida.getData();

            oMeGusta = new MeGusta();
            tGusta = oMeGusta.getData();

            cboPersona.DisplayMember = "nombre";
            cboPersona.ValueMember = "dni";
            cboPersona.DataSource = tper;
        }

        private void cboPersona_SelectedIndexChanged(object sender, EventArgs e)
        {
            grilla.Rows.Clear();
            foreach (DataRow fGus in tGusta.Rows)
            {
                if (fGus["dni"].ToString()== cboPersona.SelectedValue.ToString())
                {
                    DataRow fcom = tcom.Rows.Find(fGus["comida"]);
                    grilla.Rows.Add(fcom["comida"], fcom["nombre"]);
                }
            }
        }
    }
}
