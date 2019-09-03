using InstaBulochka.Properties;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

// поиск инста локи https://www.toopics.com/search?c=location
// посты по локам https://www.instagram.com/explore/locations/383772834/
//посты по тегам https://www.instagram.com/explore/tags/Балаково
// 200 на 1 локу???

    //TODO

//

namespace InstaBulochka
{
    public partial class Form1 : Form
    {
        String programmVersion = ConstantsApp.app_version;
        String licencie_type = "unknown";
        string licencie_name_of;




        public static Form1 MyGlavForm;
        public static int stoped = 0;
        private Authenticator _authenticator;
        private ControlFormProgramm _сontrolFormProgramm;
        private Like _like;
        private Subscribe _subscribe;
        private SecurityKey _securityKey;
        private RegEdit _regEdit;
        private Props _props;
        private AutoRun _autoRun;




        IWebDriver web;
        CancellationTokenSource _tokenSource;

        public Form1()
        {

            ChromeOptions options = new ChromeOptions();

            options.AddArguments("window-size=1800x1080");
            options.AddArguments("--disable-gpu");
            options.AddArguments("--disable-extensions");
            options.AddArguments("--max_old_space_size=512");
            options.AddArguments("--start-maximized");
             options.AddArguments("--no-sandbox");
            options.AddArguments("--disable-dev-shm-usage");
         options.AddArguments("--headless");

            // var dir_chrome_browser = Directory.GetCurrentDirectory() + "\\Chrome\\Application1\\chrome.exe";
            // options.BinaryLocation = dir_chrome_browser;
            //options.AddArguments("start-maximized"); // open Browser in maximized mode
            //options.AddArguments("disable-infobars"); // disabling infobars
            //options.AddArguments("--disable-extensions"); // disabling extensions
            //options.AddArguments("--disable-gpu"); // applicable to windows os only
            //options.AddArguments("--disable-dev-shm-usage"); // overcome limited resource problems
            //options.AddArguments("--no-sandbox"); // Bypass OS security model

            // web = new ChromeDriver(@"D:/");
            var dir_chrome_driver = Directory.GetCurrentDirectory()+"\\lib";

            ChromeDriverService service = ChromeDriverService.CreateDefaultService(dir_chrome_driver);

            service.HideCommandPromptWindow = true;
            try  { web = new ChromeDriver(service,options); } catch (Exception e) {MessageBox.Show("Убедитесь в наличии браузера Google Chrome версии 72.0 и выше \nОшибка инициализации браузера, доступ запрещен или объект отстуствует. \n" + e.Message, "Error, Google Chrome!", MessageBoxButtons.OK, MessageBoxIcon.Error);  }
                                                 
            web.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);


            _authenticator = new Authenticator(web, new ControlFormProgramm(this));
            _like = new Like(web, new ControlFormProgramm(this));
            _subscribe = new Subscribe(web, new ControlFormProgramm(this));
            _сontrolFormProgramm = new ControlFormProgramm(this);
            _securityKey = new SecurityKey();
            _regEdit = new RegEdit();
            _props = new Props(this);
            _autoRun = new AutoRun();
            
            this.Icon = Resources.instagramico;
            MyGlavForm = this;

            InitializeComponent();


            progressBar1.Style = ProgressBarStyle.Continuous;
            progressBar1.Maximum = 100;
            progressBar1.Value = 0;
            

            _сontrolFormProgramm.FirstStateProgramm();
            label3.Text = "Войдите в свой инстаграмм профиль ..";

            this.MaximumSize = new System.Drawing.Size(690, 560);
            this.MinimumSize = new System.Drawing.Size(690, 560);





        }

        private void button1_Click(object sender, EventArgs e)
        {
            String login = textBox1.Text;
            String password = textBox2.Text;

            if (login == licencie_name_of || licencie_name_of == "trial")
            {
                Task.Factory.StartNew(() =>
                {  //new thread
                    _authenticator.Authenticate(login, password);
                });  //end thread
            }
            else { MessageBox.Show("Лицензия не соотвествует Вашему аккаунту" , "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }
                                          
        }



        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void лицензияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instabulochka (c) 2019\nMartynov A.", "О программе");
        }

        private void label16_Click(object sender, EventArgs e)
        {
            HelpLocation hl = new HelpLocation();
            hl.Show();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            HelpLocation hl = new HelpLocation();
            hl.Show();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e) //STOP
        {
            stoped = 1;
            label3.Text = "Останавливаем процесс..";
            _tokenSource.Cancel();
                       
          //string decryptedstring = _securityKey.Encrypt("andremart47", "442541Wq@");

          // Console.WriteLine(decryptedstring);
          
                                          

        }

        private void button2_Click_1(object sender, EventArgs e) //START
        {
            if (автозапускToolStripMenuItem.Checked == true)
            {                          
                _autoRun.appAutoRunOn();
            }
            else { _autoRun.appAutoRunOff(); }
                Start();
                       
        }

        public void Start() {
            _props.setXML(0); //save cfg
            _сontrolFormProgramm.ProcessBarSetValue(0);
            stoped = 0;
            ControlFormProgramm.MsgLogBox.AddMsg("Процесс запущен, ожидание потока..");
            String tag = textBox3.Text;
            String geonumber = textBox4.Text;
            int time_wait = Int32.Parse(textBox5.Text);
            int limit = Int32.Parse(textBox6.Text);
            _сontrolFormProgramm.Start();
            label3.Text = "000 / 00 (00 %)";
           String filters_positive = textBox7.Text.Trim().Replace(" ", "");
            if (filters_positive.Substring(filters_positive.Length - 1, 1) == ",") { filters_positive = filters_positive.Remove(filters_positive.Length - 1); } //обрезать если лишняя запятая в фтльтрах
            String filters_negative = textBox8.Text.Trim().Replace(" ", "");
            if (filters_negative.Substring(filters_negative.Length - 1, 1) == ",") { filters_negative = filters_negative.Remove(filters_negative.Length - 1); } //обрезать если лишняя запятая в фтльтрах
            _tokenSource = new CancellationTokenSource();

            CancellationToken cancelToken = _tokenSource.Token;

            try
            {

                //обратите внимание на передачу токена отмены, и экземпл. прогресса


                Task.Factory.StartNew(() => {  //new thread

                    if (radioButton1.Checked == true)
                    {
                        if (radioButton3.Checked == true)
                        {
                            _like.Tags(tag, time_wait, limit, filters_positive, filters_negative, cancelToken);
                        }
                        if (radioButton4.Checked == true)
                        {
                            _like.Geolocation(geonumber, time_wait, limit, filters_positive, filters_negative, cancelToken);
                        }
                    }
                    if (radioButton6.Checked == true)
                    {
                        if (radioButton3.Checked == true)
                        {
                            //подписка по тэгу
                            _subscribe.Tags(tag, time_wait, limit, filters_positive, filters_negative, cancelToken);
                        }
                        if (radioButton4.Checked == true)
                        {
                            _subscribe.Geolocation(geonumber, time_wait, limit, filters_positive, filters_negative, cancelToken);
                        }
                    }

                });


            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Задача отменена.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("В задаче произошла ошибка: " + ex, "Threads error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void richTextBox1_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            web.Quit();
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            web.Quit();
        }

        private void авторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vk.com/id140200183");
        }

        public void licencie(){
            licencie_name_of = _securityKey.Decrypt("442541Wq@");
            if (licencie_name_of == "trial") {
                licencie_type = "trial";
                _regEdit.StartTrialProgamm("BDriverKey",8);
            } else {
                licencie_type = "unlimited";
                if (licencie_name_of == "Error decrypter")
                {
                    web.Quit();
                    Environment.Exit(0);
                }
            }
            richTextBox1.Text = "Добро пожаловать! \nИнициализация компнентов выполнена. \nINSTABULOCHKA v." + programmVersion + "\nЛицензия для: " + licencie_name_of + " / Тип: " + licencie_type + "\n=======================\n";
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            _props.getXML();
             
            licencie();

            if (автозапускToolStripMenuItem.Checked == true)
            {

                //  _autoRun.AutoRunOn();
                
              
               Hide();
               notifyIcon1.Visible = true;
                String login = textBox1.Text;
                String password = textBox2.Text;

                if (login == licencie_name_of || licencie_name_of == "trial")
                {
                    Task.Factory.StartNew(() =>
                    {  //new thread
                        for (int i = 1; i <= ConstantsApp.timer_of_autostart; i++)
                        { //задержка минут перед автостартом
                            
                            if (автозапускToolStripMenuItem.Checked == true)
                            {
                                Thread.Sleep(1000);
                                _сontrolFormProgramm.SetTextStateLabel("До автостарта: " + (ConstantsApp.timer_of_autostart - i) + " сек. (меню для отмены)");
                                if (i == ConstantsApp.timer_of_autostart)
                                {
                                    _authenticator.Authenticate(login, password);
                                    if (Authenticator.accountIsLoggedIn == 1)
                                    {
                                        BeginInvoke(new MethodInvoker(delegate
                                        {
                                            Start();
                                        }));
                                    }
                                }
                            }
                            else { _сontrolFormProgramm.SetTextStateLabel("Автостарт отменен."); }
                        }
                         
                      
                    });  //end thread

                   
                }
                else { MessageBox.Show("Лицензия не соотвествует Вашему аккаунту", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
            else {  }

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void сохранитьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _props.setXML(0);
            if (автозапускToolStripMenuItem.Checked == true)
            {
                _autoRun.appAutoRunOn();
            }
            else { _autoRun.appAutoRunOff(); }
        }

        private void загрузитьНастройкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _props.getXML();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
                       this.MaximizeBox = false;
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
            
        }
            
        private void checkBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox1.Checked == true) { textBox7.Enabled = true; } else { textBox7.Enabled = false; }
        }

        private void radioButton3_MouseClick(object sender, MouseEventArgs e)
        {
            _сontrolFormProgramm.Only_tags();
        }

        private void radioButton4_MouseClick(object sender, MouseEventArgs e)
        {
            _сontrolFormProgramm.Only_locations();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
   
        }

        private void checkBox2_MouseClick(object sender, MouseEventArgs e)
        {
            if (checkBox2.Checked == true) { textBox8.Enabled = true; } else { textBox8.Enabled = false; }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
