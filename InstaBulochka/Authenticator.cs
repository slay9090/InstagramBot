using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaBulochka
{
    class Authenticator 
    {
        private IWebDriver _driver;
      
        private ControlFormProgramm _controlFormProgramm;
             
        public String smsValue;
        
        public static int accountIsLoggedIn; //использовать потом


        public Authenticator(IWebDriver driver, ControlFormProgramm controlFormProgramm)
                    {
            _driver = driver;
            _controlFormProgramm = controlFormProgramm;

        }

        

        public void  Authenticate(string login, string password) //Авторизация
        {
            _controlFormProgramm.FirstStateProgramm();
            _controlFormProgramm.ProcessBarSetValue(10);
            _controlFormProgramm.SetTextStateLabel("Идёт процесс авторизации ..");
            _driver.Navigate().GoToUrl("https://www.instagram.com/accounts/login/");
            _driver.FindElement(By.CssSelector("input[name='username']")).SendKeys(login);
            _driver.FindElement(By.CssSelector("input[name='password']")).SendKeys(password);
            _driver.FindElement(By.CssSelector("input[name='password']")).SendKeys(OpenQA.Selenium.Keys.Enter);
            _controlFormProgramm.ProcessBarSetValue(40);


            try //логин и пасс не подхзодят (без смс)
            {
                String err = _driver.FindElement(By.CssSelector("#slfErrorAlert")).Text;
               
                ControlFormProgramm.MsgLogBox.AddMsg(err);
                _controlFormProgramm.NoAuthAccount();
                _controlFormProgramm.ProcessBarSetValue(100);
                _controlFormProgramm.SetTextStateLabel("Ошибка.");

                Console.WriteLine(err);
                accountIsLoggedIn = 0;



            }
            catch (Exception) { //логин и пасс подходят

                ControlFormProgramm.MsgLogBox.AddMsg("Логин и пароль, прошли проверку");
                Console.WriteLine("log and pass is good");
                _controlFormProgramm.ProcessBarSetValue(70);

                if (IsSMSOnPagePresent("Подозрительная попытка входа") == true) //чек на СМС
                {
                    ControlFormProgramm.MsgLogBox.AddMsg("Необходима смс верификация");
                    PostSMS(); //post SMS


                }
                else
                {
                    ControlFormProgramm.MsgLogBox.AddMsg("Cмс верификация не требуется");
                    try
                    {
                        _controlFormProgramm.ProcessBarSetValue(90);
                       // _driver.FindElement(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div.mt3GC > button.aOOlW.HoLwm")).Click(); //отменяем опвещения
                        _controlFormProgramm.YesAuthAccount();
                        _controlFormProgramm.ProcessBarSetValue(100);
                        _controlFormProgramm.SetTextStateLabel("Процесс авторизации завершен.");
                        ControlFormProgramm.MsgLogBox.AddMsg("Внимание! Перед началом работы, внимательно ознакомтесь с ограничениями и лимитами инстаграма: http://instagrammar.ru/raskrutka/limity-i-ogranicheniya-instagram-podpiski-i-podpischiki-otpiski-i-lajki/");
                        ControlFormProgramm.MsgLogBox.AddMsg("Программа готова к работе..");
                       
                        accountIsLoggedIn = 1;
                       
                    }
                    catch (Exception) { }
                }



            }

            

        }
        public Boolean IsSMSOnPagePresent(String text) // проверка нужно ли смс
        {
           
            IWebElement body = _driver.FindElement(By.TagName("body"));
            String bodyText = body.Text;
            return bodyText.Contains(text);

        }
        public void PostSMS() { //отправка СМС

            _driver.FindElement(By.XPath("//span[@class='idhGk _1OSdk']")).Click();
            smsValue = PromtWindow.ShowDialog("Введите код безопасности из СМС", "СМС подтверждение");
            _driver.FindElement(By.CssSelector("input[name='security_code']")).SendKeys(smsValue); ////input[@id='security_code']
            _driver.FindElement(By.CssSelector("input[name='security_code']")).SendKeys(OpenQA.Selenium.Keys.Enter);
            try
            {
                String err = _driver.FindElement(By.XPath("//div[@id='form_error']")).Text; ////div[@id='form_error']
                ControlFormProgramm.MsgLogBox.AddMsg(err);
                accountIsLoggedIn = 1;
                _controlFormProgramm.NoAuthAccount();
                _controlFormProgramm.ProcessBarSetValue(100);
                _controlFormProgramm.SetTextStateLabel("Ошибка.");



            }
            catch (Exception) {
                ControlFormProgramm.MsgLogBox.AddMsg("Код безопасности принят");
                try
                {
                    _controlFormProgramm.ProcessBarSetValue(90);
                    // _driver.FindElement(By.CssSelector("body > div.RnEpo.Yx5HN > div > div > div.mt3GC > button.aOOlW.HoLwm")).Click(); //отменяем опвещения
                    accountIsLoggedIn = 0;
                    _controlFormProgramm.YesAuthAccount();
                    _controlFormProgramm.ProcessBarSetValue(100);
                    _controlFormProgramm.SetTextStateLabel("Процесс авторизации завершен.");
                    ControlFormProgramm.MsgLogBox.AddMsg("Внимание! Перед началом работы, внимательно ознакомтесь с ограничениями и лимитами инстаграма: http://instagrammar.ru/raskrutka/limity-i-ogranicheniya-instagram-podpiski-i-podpischiki-otpiski-i-lajki/");
                    ControlFormProgramm.MsgLogBox.AddMsg("Программа готова к работе..");
                }
                catch (Exception) { }
            }

        }



    }
}
