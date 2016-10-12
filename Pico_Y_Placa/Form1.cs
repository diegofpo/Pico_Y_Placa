using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pico_Y_Placa
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!txtPlaca.Text.Equals("") && !cbHorario.Text.Equals(""))
                {
                    string placa, hora, fecha;
                    placa = txtPlaca.Text;
                    var regexItem = new Regex("^[a-zA-Z0-9]*$");
                    if (regexItem.IsMatch(placa))
                    {
                        var regexItem2 = new Regex("^[a-zA-Z]*$");
                        string letras = placa.Substring(0, 3);
                        if (regexItem2.IsMatch(placa.Substring(3, 1)))
                            MessageBox.Show("Placa no valida.");
                        else
                        {
                            if (letras.Length == 3)
                            {
                                var regexItem3 = new Regex("^[0-9]*$");
                                string numeros = placa.Substring(3, (placa.Length - 3));
                                if (numeros.Length == 4 && regexItem3.IsMatch(numeros))
                                {
                                    string dia = diaPicoyPlaca(int.Parse(numeros.Substring(3, 1)));
                                    fecha = (dtFecha.Value.ToString("dddd", new CultureInfo("es-ES"))).ToString();
                                    if ((nHora.Value == 7 || nHora.Value == 8) && cbHorario.Text.Equals("A.M.") && (dia.Equals(fecha)))
                                    {
                                        MessageBox.Show("Esta en pico y placa, recuerde que no puede circular.");
                                    }
                                    else if ((nHora.Value == 9 && nMinutos.Value < 30) && cbHorario.Text.Equals("A.M.") && (dia.Equals(fecha)))
                                    {
                                        MessageBox.Show("Esta en pico y placa, recuerde que no puede circular.");
                                    }
                                    else if ((nHora.Value == 4 || nHora.Value == 5 || nHora.Value == 6) && cbHorario.Text.Equals("P.M.") && (dia.Equals(fecha)))
                                    {
                                        MessageBox.Show("Esta en pico y placa, recuerde que no puede circular.");
                                    }
                                    else if ((nHora.Value == 7 && nMinutos.Value < 30) && cbHorario.Text.Equals("P.M.") && (dia.Equals(fecha)))
                                    {
                                        MessageBox.Show("Esta en pico y placa, recuerde que no puede circular.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("No esta en pico y placa, puede circular con normalidad.");
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("Si su placa tiene solo 3 numeros, añada el cero delante. Ejemplo: ABC0123");
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ingrese la placa sin espacion ni caracteres especiales. Ejemplo: ABC0000");
                    }
                }
                else
                {
                    MessageBox.Show("Datos incorrectos y/o campos vacios.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {}

        private string diaPicoyPlaca(int numFinal)
        {
            try
            {
                int op = 0;
                string aux="";

                if (numFinal % 2 == 0)
                    op = numFinal;
                else
                {
                    op = (numFinal + 1);
                    if (op == 10)
                        op = 0;
                }

                switch (op)
                {
                    case 0:
                        aux = "viernes";
                        break;
                    case 2:
                        aux = "lunes";
                        break;
                    case 4:
                        aux = "martes";
                        break;
                    case 6:
                        aux = "miércoles";
                        break;
                    case 8:
                        aux = "jueves";
                        break;
                }
                return aux;
            }
            catch(Exception ex)
            {
                return ex.ToString();
            }

        }

    }
}
