using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace XmlForms1
{
    public partial class crear_leer_xml : Form
    {
        public crear_leer_xml()
        {
            InitializeComponent();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            XmlElement raiz = doc.CreateElement("Libros");
            doc.AppendChild(raiz);

            XmlElement libro = doc.CreateElement("libro");
            raiz.AppendChild(libro);

            XmlElement titulo = doc.CreateElement("titulo");
            titulo.AppendChild(doc.CreateTextNode("El Hobbit"));
            libro.AppendChild(titulo);

            XmlElement precio = doc.CreateElement("precio");
            precio.AppendChild(doc.CreateTextNode("10.0"));
            libro.AppendChild(precio);

            doc.Save("c:\\xml\\archivo.xml");
            MessageBox.Show("Archivo XML creado");

        }

        private void btnLeer_Click(object sender, EventArgs e)
        {
            string ultimaEtiqueta = "";

            XmlTextReader reader = new XmlTextReader("c:\\xml\\archivo.xml");

            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    // The node is an element.
                    richTextBox1.Text += (new String(' ', reader.Depth * 3) + "<" + reader.Name + ">");
                    ultimaEtiqueta = reader.Name;
                    continue;
                }

                if (reader.NodeType == XmlNodeType.Text)
                {
                    //Display the text in each element.
                    richTextBox1.Text += reader.ReadContentAsString() + "</" + ultimaEtiqueta + ">";
                }
                else
                    richTextBox1.Text += "\r";
                
            }
        }
    }
}
