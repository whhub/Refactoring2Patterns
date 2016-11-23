using System.IO;

namespace ObjectStructure
{
    internal class LayoutFactory
    {
        private static readonly LayoutFactory _instance = new LayoutFactory();

        private LayoutFactory()
        {
        }

        public static LayoutFactory Instance
        {
            get { return _instance; }
        }

        public Layout CreateLayout(int col, int row)
        {
            return new SimpleLayout(col, row);
        }

        public Layout CreateLayout(string xml)
        {
            return new XmlLayout(xml);
        }

        public Layout DefaultLayout()
        {
            return CreateLayout(ReadDefaultLayoutConfig());
        }

        private string ReadDefaultLayoutConfig()
        {
            var path =
                @"D:\UIH\appdata\filming\config\McsfMedViewerConfig\MedViewerLayouts\mcsf_med_viewer_layout_type_00_1x1.xml";
            var fileStream = new FileStream(path, FileMode.Open);
            var streamReader = new StreamReader(fileStream);
            var xml = streamReader.ReadToEnd();
            streamReader.Close();
            return xml;
        }
    }
}