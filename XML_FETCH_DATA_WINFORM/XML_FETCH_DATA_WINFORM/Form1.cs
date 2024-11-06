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

namespace XML_FETCH_DATA_WINFORM
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		

		//When user click on search button 
		private void button1_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(textBox1.Text) == true)
			{
				MessageBox.Show("Enter required filed..");
				textBox1.Focus();
			}
			else
			{
				// Clear the listbox first 
				listBox1.Items.Clear();

				// create xml document object
				XmlDocument doc = new XmlDocument();
				
				// Load the data of file which we want to load just fill the filename in bracket
				doc.Load("MyXMLFile.xml");

				// Now we have to use for loop for the child node first in the document
				foreach(XmlNode node in doc.DocumentElement)
				{
					// Now fetch the id of student i.e child node id 
					int id = Convert.ToInt32(node.Attributes[0].InnerText);
					// Compare the child node id and text box id
				
					if ( id == Convert.ToInt32(textBox1.Text))
					{
						// Now fetch the data of particular selected student id in xmlnode typoe variable
						foreach(XmlNode childnode in node.ChildNodes)
						{
							// Add the childnode detail to the listbox which is on ui
							listBox1.Items.Add(childnode.InnerText);
						}
					}

				}
			}
		}
	}
}
