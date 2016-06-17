using System;
using System.Windows.Forms;

namespace ExtractDataModelFromXml
{
    public partial class Xml2Model : Form
    {
        private readonly IXml2ModelMapper _mapper = new Xml2ModelMapper();
        private readonly XmlDocumentStub _stub = new XmlDocumentStub();

        public Xml2Model()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var xml = _stub.Xml;
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                try
                {
                    xml.LoadXml(textBox1.Text);
                }
                catch 
                {
                    textBox2.Text = @"Could not parce XML";
                    return;
                }
            }

            var model = _mapper.Map(xml);

            textBox2.Text = model?.ToString() ?? "No model could be generated";
        }
    }
}
