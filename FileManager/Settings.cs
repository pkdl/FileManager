using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace FileManager
{
    [Serializable]
    public class Settings
    {
        public Dictionary<String, object> SettingsList { get; private set; }

        public Dictionary<String, object> DefaultSettingsList { get; private set; }

        MainForm parent;

        private String login;
        private String password;

        private String key = "blblbl";
        private String iv = "sksfhskj";

        public Settings(MainForm parent)
        {
            this.parent = parent;
            SettingsList = new Dictionary<string, object>();

            DefaultSettingsList = new Dictionary<string, object>
            {
                ["StartDir"] = @"D:\",
                ["Color1"] = System.Drawing.Color.White,
                ["Color2"] = System.Drawing.Color.Gray
            };
            login = "Login";
            password = "qwerty";
        }

        public void Load()
        {
            DoDeserealization();
        }
        public void SetEntry(String name, object value)
        {
            SettingsList[name] = value;
        }

        public void DoSerializattion()
        {
            BinaryFormatter binformat = new BinaryFormatter();
            Stream stream = new FileStream(@"D:\test\settings.dat", FileMode.Create, FileAccess.Write, FileShare.None);
            binformat.Serialize(stream, parent.settings);
            stream.Close();
        }

        public void DoDeserealization()
        {

            FileStream fs = new FileStream(@"D:\test\settings.dat", FileMode.Open);
            BinaryFormatter bf = new BinaryFormatter();
            parent.settings = (Settings)bf.Deserialize(fs);
            fs.Close();
        }


        [OnSerializing]
        private void EncryptLoginPass(StreamingContext context)
        {
            var crypto = new Encryption(key, iv);
            login = crypto.Encrypt(login);
            password = crypto.Encrypt(password);
        }

        [OnDeserialized]
        private void DecryptLoginPass(StreamingContext context)
        {
            var crypto = new Encryption(key, iv);
            login = crypto.Decrypt(login);
            password = crypto.Decrypt(password);
        }

        
    }

}
