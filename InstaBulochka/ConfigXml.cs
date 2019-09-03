using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace InstaBulochka
{
    public class ConfigXml
    {
        //  Console.WriteLine(Osnova.file_config);
       // public String XMLFileName = Directory.GetCurrentDirectory()+"//config.cfg"; //  Form1.file_config;
        //Чтобы добавить настройку в программу просто добавьте туда строку вида -
        //public ТИП ИМЯ_ПЕРЕМЕННОЙ = значение_переменной_по_умолчанию;

        public String TextValueBox1;
        public String TextValueBox2;
        public String TextValueBox3;
        public String TextValueBox4;
        public String TextValueBox5;
        public String TextValueBox6; //кол-во
      

        public Boolean BoolValueRadio1;
       public Boolean BoolValueRadio2;
       public Boolean BoolValueRadio3;
       public Boolean BoolValueRadio4;

        public Boolean CheckBox1Value;
        public Boolean CheckBox2Value;
        public String TextValueBox7;
        public String TextValueBox8;

        public Boolean BoolValueAutoStart;






    }

    class Props
    {
        Form1 _form;
        public ConfigXml Fields;

        public Props(Form1 form)
        {
            Fields = new ConfigXml();
            _form = form;
        }
        //Запись настроек в файл
        public void WriteXml()
        {
           
            XmlSerializer ser = new XmlSerializer(typeof(ConfigXml));

            TextWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + "//lib//config.cfg");
            ser.Serialize(writer, Fields);
            writer.Close();
        }
        //Чтение насроек из файла
        public void ReadXml()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "//lib//config.cfg"))
            {
                XmlSerializer ser = new XmlSerializer(typeof(ConfigXml));
                TextReader reader = new StreamReader(Directory.GetCurrentDirectory() + "//lib//config.cfg");
                Fields = ser.Deserialize(reader) as ConfigXml;
                reader.Close();
            }
            else
            {
                //можно написать вывод сообщения если файла не существует
            }
        }
        public void setXML(int complited_run) {
            
                      
            #region Settings action
           
            Fields.TextValueBox1 = _form.textBox1.Text; //login
            Fields.TextValueBox2 = _form.textBox2.Text; //pass
            Fields.TextValueBox3 = _form.textBox3.Text;
            Fields.TextValueBox4 = _form.textBox4.Text;
            Fields.TextValueBox5 = _form.textBox5.Text;
            
            int all = Convert.ToInt32(_form.textBox6.Text)-complited_run;


            Fields.TextValueBox6 = all.ToString();

            Fields.BoolValueRadio1 = _form.radioButton1.Checked;
           Fields.BoolValueRadio2 = _form.radioButton3.Checked;
           Fields.BoolValueRadio3 = _form.radioButton4.Checked;
            Fields.BoolValueRadio4 = _form.radioButton6.Checked;
            Fields.CheckBox1Value = _form.checkBox1.Checked;
            Fields.CheckBox2Value = _form.checkBox2.Checked;
            Fields.TextValueBox7 = _form.textBox7.Text;
            Fields.TextValueBox8 = _form.textBox8.Text;
            Fields.BoolValueAutoStart = _form.автозапускToolStripMenuItem.Checked;




            WriteXml();
                        
            #endregion
        }
        public void getXML() {
            #region Settings action
           
            ReadXml();


          

            _form.textBox1.Text = Fields.TextValueBox1;
            _form.textBox2.Text= Fields.TextValueBox2 ; //pass
            _form.textBox3.Text=Fields.TextValueBox3 ;
            _form.textBox4.Text=Fields.TextValueBox4 ;
            _form.textBox5.Text=Fields.TextValueBox5 ;
            _form.textBox6.Text=Fields.TextValueBox6 ;

            _form.radioButton1.Checked=Fields.BoolValueRadio1 ;
            _form.radioButton3.Checked=Fields.BoolValueRadio2 ;
           _form.radioButton4.Checked=Fields.BoolValueRadio3 ;
            _form.radioButton6.Checked=Fields.BoolValueRadio4 ;

             _form.checkBox1.Checked= Fields.CheckBox1Value;
            _form.checkBox2.Checked = Fields.CheckBox2Value;

            _form.textBox7.Text= Fields.TextValueBox7;
            _form.textBox8.Text = Fields.TextValueBox8;

            _form.автозапускToolStripMenuItem.Checked= Fields.BoolValueAutoStart;

            #endregion
        }
    }
}
