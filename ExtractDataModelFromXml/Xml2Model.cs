using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ExtractDataModelFromXml
{
    public partial class Xml2Model : Form
    {
        private readonly IXml2ModelMapper _mapper = new Xml2ExpandoModelMapper();
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

            if (_mapper is Xml2DynamicModelMapper)
            {
                textBox2.Text = model?.ToString() ?? "No model could be generated";
            }

            if (_mapper is Xml2ExpandoModelMapper)
            {
                var values = model as IDictionary<string, object>;
                textBox2.Text = values?.Select(kv => $"{kv.Key} => {kv.Value}").Aggregate(string.Empty, (v1, v2) => $"{v1}\r\n{v2}");
            }
        }
    }
}
