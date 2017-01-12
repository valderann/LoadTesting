using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace LoadTesting
{
    public static class httpTestManager
    {
        public static List<httpTest> httpTests = new List<httpTest>();


        public static void Load()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "\\config.xml"))
            {
                XmlSerializer SerializerObj = new XmlSerializer(typeof(List<httpTest>));

                using (FileStream ReadFileStream = new FileStream(Directory.GetCurrentDirectory() + "\\config.xml", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    httpTests = (List<httpTest>)SerializerObj.Deserialize(ReadFileStream);

                    ReadFileStream.Close();
                }
            }
        }

        public static void Save()
        {
            XmlSerializer SerializerObj = new XmlSerializer(typeof(List<httpTest>));

            using (TextWriter WriteFileStream = new StreamWriter(Directory.GetCurrentDirectory() + "\\config.xml"))
            {
                SerializerObj.Serialize(WriteFileStream, httpTests);
                WriteFileStream.Close();
            }
        }
    }
}
