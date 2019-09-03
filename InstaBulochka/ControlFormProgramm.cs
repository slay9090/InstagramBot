using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstaBulochka
{
    class ControlFormProgramm 
    {

        Form1 _form;
        private Props _props;
        public ControlFormProgramm(Form1 form) {
            this._form = form;
            _props = new Props(_form);
        }


        public void reWriteXMLConfig(int compited) {
            _props.setXML(compited);
        }

        public void FirstStateProgramm()
        { //состояние всей морды без авторищации

            if (_form.IsHandleCreated == true) //INVOKE
            {
                _form.BeginInvoke(new MethodInvoker(delegate
                 {
                     _form.button1.Enabled = true; //вхъод
                 _form.textBox1.Enabled = true; //лог
                 _form.textBox2.Enabled = true; //пасс
                                                // _form.pictureBox1.Image = Properties.Resources.not_ok;

                 _form.radioButton1.Enabled = false; // действия лайкать
                 _form.radioButton6.Enabled = false; // действия подписыватся

                 _form.radioButton3.Enabled = false; //по тэгу
                 _form.radioButton4.Enabled = false; // по локации

                 _form.textBox3.Enabled = false; //Тэг
                 _form.label6.Enabled = false; // Тэг 

                 _form.textBox4.Enabled = false; // Локация
                 _form.label8.Enabled = false; // Локация
                 _form.label16.Enabled = false; // Локация

                 _form.button3.Enabled = false; //стоп
                 _form.button2.Enabled = false; //старт

                 _form.label9.Enabled = false; //задержка
                 _form.textBox5.Enabled = false; //задержка
                 _form.textBox6.Enabled = false; //коол-во
                 _form.label10.Enabled = false; //кол-во
                     _form.checkBox1.Enabled = false;
                     _form.textBox7.Enabled = false;
                     _form.checkBox2.Enabled = false;
                     _form.textBox8.Enabled = false;


                     _form.pictureBox1.Image = null;
                 }));
            }
            else {
                _form.button1.Enabled = true; //вхъод
                _form.textBox1.Enabled = true; //лог
                _form.textBox2.Enabled = true; //пасс
                                               // _form.pictureBox1.Image = Properties.Resources.not_ok;

                _form.radioButton1.Enabled = false; // действия лайкать
                _form.radioButton6.Enabled = false; // действия подписыватся

                _form.radioButton3.Enabled = false; //по тэгу
                _form.radioButton4.Enabled = false; // по локации

                _form.textBox3.Enabled = false; //Тэг
                _form.label6.Enabled = false; // Тэг 

                _form.textBox4.Enabled = false; // Локация
                _form.label8.Enabled = false; // Локация
                _form.label16.Enabled = false; // Локация

                _form.button3.Enabled = false; //стоп
                _form.button2.Enabled = false; //старт

                _form.label9.Enabled = false; //задержка
                _form.textBox5.Enabled = false; //задержка
                _form.textBox6.Enabled = false; //коол-во
                _form.label10.Enabled = false; //кол-во

               
                _form.pictureBox1.Image = null;
               
                _form.checkBox1.Enabled = false;
                _form.textBox7.Enabled = false;

                _form.checkBox2.Enabled = false;
                _form.textBox8.Enabled = false;


            }




        }
        public void NoAuthAccount(){ //состояние всей морды без авторищации

            _form.Invoke(new MethodInvoker(delegate
            {
                _form.button1.Enabled = true; //вхъод
            _form.textBox1.Enabled = true; //лог
            _form.textBox2.Enabled = true; //пасс
           
            _form.radioButton1.Enabled = false; // действия лайкать
            _form.radioButton6.Enabled = false; // действия подписыватся

            _form.radioButton3.Enabled = false; //по тэгу
            _form.radioButton4.Enabled = false; // по локации
            
            _form.textBox3.Enabled = false; //Тэг
            _form.label6.Enabled = false; // Тэг 

            _form.textBox4.Enabled = false; // Локация
            _form.label8.Enabled = false; // Локация
            _form.label16.Enabled = false; // Локация

            _form.button3.Enabled = false; //стоп
            _form.button2.Enabled = false; //старт
                   
            _form.label9.Enabled = false; //задержка
            _form.textBox5.Enabled = false; //задержка
            _form.textBox6.Enabled = false; //коол-во
            _form.label10.Enabled = false; //кол-во
                _form.checkBox1.Enabled = false;
                _form.textBox7.Enabled = false;

                _form.checkBox2.Enabled = false;
                _form.textBox8.Enabled = false;


                _form.pictureBox1.Image = Properties.Resources.not_ok;
            }));
        }

        public void YesAuthAccount() //состояние всей морды с авторищацией
        {
                _form.Invoke(new MethodInvoker(delegate
                {
                    _form.button1.Enabled = false; //вхъод
            _form.textBox1.Enabled = false; //лог
            _form.textBox2.Enabled = false; //пасс
                                           

            _form.radioButton1.Enabled = true; // действия лайкать
            _form.radioButton6.Enabled = true; // действия подписыватся

                    if (_form.radioButton3.Checked == true)
                    {
                        Only_tags();
                    }
                    else { Only_locations(); }

                   _form.radioButton3.Enabled = true;  //по тэгу
                   _form.radioButton4.Enabled = true; // по локации

                    //_form.textBox3.Enabled = true; //Тэг
                    //_form.label6.Enabled = true; // Тэг 

                    //_form.textBox4.Enabled = false; // Локация
                    //_form.label8.Enabled = false; // Локация
                    //_form.label16.Enabled = false; // Локация

                    _form.button3.Enabled = true; //стоп
            _form.button2.Enabled = true; //старт

            _form.label9.Enabled = true; //задержка
            _form.textBox5.Enabled = true; //задержка
            _form.textBox6.Enabled = true; //коол-во
            _form.label10.Enabled = true; //кол-во

                    _form.checkBox1.Enabled = true;
                    _form.checkBox2.Enabled = true;



                    if (_form.checkBox1.Checked == true) { _form.textBox7.Enabled = true; } else { _form.textBox7.Enabled = false; }

                  

                    if (_form.checkBox2.Checked == true) { _form.textBox8.Enabled = true; } else { _form.textBox8.Enabled = false; }


                    _form.pictureBox1.Image = Properties.Resources.ok;
                }));
        }

        public void Start() //состояние всей морды кнопка нажата кнопка старт
        {
            _form.Invoke(new MethodInvoker(delegate
            {
                _form.button1.Enabled = false; //вхъод
                _form.textBox1.Enabled = false; //лог
                _form.textBox2.Enabled = false; //пасс


                _form.radioButton1.Enabled = false; // действия лайкать
                _form.radioButton6.Enabled = false; // действия подписыватся

              

                _form.radioButton3.Enabled = false;  //по тэгу
                _form.radioButton4.Enabled = false; // по локации

                _form.textBox3.Enabled = false; //Тэг
                _form.label6.Enabled = false; // Тэг 

                _form.textBox4.Enabled = false; // Локация
                _form.label8.Enabled = false; // Локация
                _form.label16.Enabled = false; // Локация

                _form.button3.Enabled = true; //стоп
                _form.button2.Enabled = false; //старт

                _form.label9.Enabled = false; //задержка
                _form.textBox5.Enabled = false; //задержка
                _form.textBox6.Enabled = false; //коол-во
                _form.label10.Enabled = false; //кол-во
                _form.checkBox1.Enabled = false;
                _form.textBox7.Enabled = false;

                _form.checkBox2.Enabled = false;
                _form.textBox8.Enabled = false;


            }));
        }

    
        public void Stop() //состояние всей морды кнопка нажата кнопка стоп
        {
            _form.Invoke(new MethodInvoker(delegate
            {
                _form.button1.Enabled = false; //вхъод
                _form.textBox1.Enabled = false; //лог
                _form.textBox2.Enabled = false; //пасс


                _form.radioButton1.Enabled = true; // действия лайкать
                _form.radioButton6.Enabled = true; // действия подписыватся

                  _form.radioButton3.Enabled = true;  //по тэгу
                 _form.radioButton4.Enabled = true; // по локации

                if (_form.radioButton3.Checked == true)
                {
                    _form.textBox3.Enabled = true; //Тэг
                    _form.label6.Enabled = true; // Тэг 

                    _form.textBox4.Enabled = false; // Локация
                    _form.label8.Enabled = false; // Локация
                    _form.label16.Enabled = false; // Локация 
                }
                if (_form.radioButton4.Checked == true)
                {
                    _form.textBox3.Enabled = false; //Тэг
                    _form.label6.Enabled = false; // Тэг 

                    _form.textBox4.Enabled = true; // Локация
                    _form.label8.Enabled = true;  // Локация
                    _form.label16.Enabled = true;  // Локация 
                }

             

                _form.button3.Enabled = true; //стоп
                _form.button2.Enabled = true; //старт

                _form.label9.Enabled = true; //задержка
                _form.textBox5.Enabled = true; //задержка
                _form.textBox6.Enabled = true; //коол-во
                _form.label10.Enabled = true; //кол-во
                _form.checkBox1.Enabled = true;
                _form.textBox7.Enabled = true;

                _form.checkBox2.Enabled = true;
                _form.textBox8.Enabled = true;

            }));
        }
        public void Only_tags() //состояние когда по тэгам
        {
                    _form.Invoke(new MethodInvoker(delegate
                    {
                        _form.textBox4.Enabled = false;// Локация
            _form.label8.Enabled = false; // Локация
            _form.label16.Enabled = false; // Локация

            _form.textBox3.Enabled = true; //Тэг
            _form.label6.Enabled = true; // Тэг
                    }));
        }
        public void Only_locations() //состояние когда по локации
        {
                        _form.Invoke(new MethodInvoker(delegate
                        {
                            _form.textBox4.Enabled = true; // Локация
            _form.label8.Enabled = true; // Локация
            _form.label16.Enabled = true; // Локация

            _form.textBox3.Enabled = false; //Тэг
            _form.label6.Enabled = false; // Тэг 
                        }));
        }
        public void ProcessBarSetValue(int value) //проц бар запущен
        {
            _form.Invoke(new MethodInvoker(delegate
            {

                _form.progressBar1.Value = value;

            }));
        }

        public void SetTextStateLabel(String text) //строка состояния програмыы
        {
            _form.Invoke(new MethodInvoker(delegate
            {

                _form.label3.Text = text;
                _form.notifyIcon1.Text = "InstaBulochka\n"+text;

            }));
        }




        public class MsgLogBox 
        {
           
            public static void AddMsg(string text)
            {
                DateTime dt = DateTime.Now;
                Console.WriteLine(text);

                Form1.MyGlavForm.BeginInvoke(new MethodInvoker(delegate
                {
                      Form1.MyGlavForm.richTextBox1.AppendText(dt + " " + text + Environment.NewLine);
                    Form1.MyGlavForm.richTextBox1.Select(Form1.MyGlavForm.richTextBox1.Text.Length - 1, 0);
                  Form1.MyGlavForm.richTextBox1.ScrollToCaret();
                    Form1.MyGlavForm.richTextBox1.Focus();



                }));
                             
            }
        }

    }


}
