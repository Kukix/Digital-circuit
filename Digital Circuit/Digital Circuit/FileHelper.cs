using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;                    //because of FileStream
using System.Runtime.Serialization.Formatters.Binary; //because of BinaryFormatter
using System.Runtime.Serialization; //because of SerializationException
using System.Windows.Forms;

namespace Digital_Circuit
{
    class FileHelper
    {
        /// <summary>
        /// the object read from a specific file.
        /// </summary>
        private Manipluater mani;

        /// <summary>
        /// constructor of this class
        /// </summary>
        public FileHelper()
        {
            mani = new Manipluater();
        }

        /// <summary>
        /// the method that will read the manual from the file and return it as a list<string>.
        /// </summary>
        /// <returns>list<string></returns>
        public List<string> GettingManual()
        {
            FileStream fs = new FileStream("Manual.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            List<string> manual = new List<string>();
            string s = sr.ReadLine();
            while (s != null)
            {
                manual.Add(s);
                s = sr.ReadLine();
            }
            sr.Dispose();
            fs.Dispose();
            return manual;
        }

        /// <summary>
        /// a method that will save the project to a file as a binary format.
        /// user will give the filepath and the object that need to save as two paramaters.
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="m"></param>
        public void SaveToFile(string filepath,Manipluater m)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(filepath, FileMode.OpenOrCreate, FileAccess.Write);
            fs.SetLength(0);
            bf.Serialize(fs, m);
            fs.Dispose();
        }

        /// <summary>
        /// a method that will read a project and load it from a file.
        /// if the file selected is not a valid file, then return null.
        /// otherwise read the file and return the object with type of "Manipulator".
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>the object created above (Manipulator mani)</returns>
        public Manipluater LoadFromFile(string filepath)
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
                if (fs.Length == 0)
                    mani = null;
                else
                    mani = (Manipluater)bf.Deserialize(fs);
                fs.Dispose();
                return mani;
            }
            catch (Exception)
            {
                MessageBox.Show("Not a valid file!");
                return null;
            }
        }
    }
}
