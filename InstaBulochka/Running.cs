using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace InstaBulochka
{
     class Running
    {
        String positive_filter_view_in_msg_box ;
        String negative_filter_view_in_msg_box ;
        private IWebDriver _driver;
        private ControlFormProgramm _controlFormProgramm;
      
        public Running(IWebDriver driver, ControlFormProgramm controlFormProgramm)
        {
            _driver = driver;
            _controlFormProgramm = controlFormProgramm;
           
        }

        public void MarkRun(string url, string endUrl, string htmlOpenPost, string htmlClickButtonMark, string htmlNextPost, string htmlGetButtonMark, string nameAttributButtonMark, string htmlTextPanel,  int time_wait, int limit, string filters_positive, string filters_negative, CancellationToken cancelToken) {
            _driver.Navigate().GoToUrl(url + endUrl);
            _driver.FindElement(By.CssSelector(htmlOpenPost)).Click(); // открыть пост Самая первая запись в теге
            double dlimit = Convert.ToDouble(limit);



            for (int i = 1; i <= limit; i++)
            {

                if (Form1.stoped != 1)
                {
                    try
                    {

                        if (GetIsCheckedLike(htmlGetButtonMark, nameAttributButtonMark) == false && Filters_positive_word(filters_positive, htmlTextPanel) == true && Filters_negative_word(filters_negative, htmlTextPanel) == false)
                       
                        {
                            double di = Convert.ToDouble(i);



                            _driver.FindElement(By.CssSelector(htmlClickButtonMark)).Click(); //кнопка лайка в открытом посте
                            ControlFormProgramm.MsgLogBox.AddMsg(_driver.Url + " метка добавлена" + " (" + positive_filter_view_in_msg_box + ")");
                            _controlFormProgramm.ProcessBarSetValue(Convert.ToInt32(di / dlimit * 100));
                            _controlFormProgramm.SetTextStateLabel(limit + " / " + i + " (" + Convert.ToInt32(di / dlimit * 100) + " %)");
                            _driver.FindElement(By.CssSelector(htmlNextPost)).Click(); //следующий пост


                            cancelToken.WaitHandle.WaitOne(TimeSpan.FromSeconds(time_wait));
                            _controlFormProgramm.reWriteXMLConfig(i); //перезапписать конфиг
                         

                        }
                        else
                        {
                            cancelToken.WaitHandle.WaitOne(TimeSpan.FromSeconds(1));
                            ControlFormProgramm.MsgLogBox.AddMsg(_driver.Url + " пропускаем ("+ negative_filter_view_in_msg_box + ")");
                            _driver.FindElement(By.CssSelector(htmlNextPost)).Click(); //следующий пост


                            i = i - 1;
                            double di = Convert.ToDouble(i);
                            _controlFormProgramm.SetTextStateLabel(limit + " / " + i + " (" + Convert.ToInt32(di / dlimit * 100) + " %)");
                        }

                        if (i >= limit)
                        { //цикл выполнен
                            _controlFormProgramm.ProcessBarSetValue(100);
                            ControlFormProgramm.MsgLogBox.AddMsg("=======================");
                            ControlFormProgramm.MsgLogBox.AddMsg("      Завершено.");
                            ControlFormProgramm.MsgLogBox.AddMsg("=======================");
                            _controlFormProgramm.SetTextStateLabel("Завершено.");
                            _controlFormProgramm.Stop();
                        }
                    }
                    catch (Exception e)
                    {
                        ControlFormProgramm.MsgLogBox.AddMsg("Error: " + e.Message);
                        i = i - 1;
                        _driver.FindElement(By.CssSelector(htmlNextPost)).Click(); //следующий пост
                    }
                }                //принудительная остановка
                else
                {
                    i = limit;
                    _controlFormProgramm.ProcessBarSetValue(100);
                    ControlFormProgramm.MsgLogBox.AddMsg("=======================");
                    ControlFormProgramm.MsgLogBox.AddMsg("      Остановлено.");
                    ControlFormProgramm.MsgLogBox.AddMsg("=======================");
                    _controlFormProgramm.SetTextStateLabel("Остановлено.");
                    _controlFormProgramm.Stop();
                }

            }

        }

        public Boolean GetIsCheckedLike(string htmlGetButtonMark, string nameAttributButtonMark)
        {
            String getAttribut;
            Boolean ischeck;
            getAttribut = _driver.FindElement(By.CssSelector(htmlGetButtonMark)).GetAttribute("class");
            Console.WriteLine(getAttribut);
            if (getAttribut == nameAttributButtonMark)
            {
                ischeck = false;
            }
            else
            {
                ischeck = true;
                negative_filter_view_in_msg_box = "метка уже имеется";
            }

            return ischeck;

        }

        public Boolean Filters_positive_word(string _filter_words, string htmlTextPanel)
        {
            bool result;
            String bodyText = " ";
            if (Form1.MyGlavForm.checkBox1.Checked == true)
            {
                negative_filter_view_in_msg_box = "нет нужных слов";
                String filters = _filter_words;
                try
                {

                    IWebElement body = _driver.FindElement(By.CssSelector(htmlTextPanel));
                    bodyText = body.Text; //текст поста #react-root > section > main > div > div > article > div.eo2As > div.KlCQn.EtaWk > ul > li > div > div > div > span
                }
                catch (Exception) { positive_filter_view_in_msg_box = "null"; return result = true; }

                // Console.WriteLine(bodyText);

                string[] words = filters.Split(',');

                foreach (string word in words)
                {
                    result = Regex.IsMatch(bodyText, @"\b"+  word + @"\b", RegexOptions.IgnoreCase);
                    if (result == true)
                    {
                        positive_filter_view_in_msg_box = "нужное слово: "+word;
                        return result;


                    }

                }
                return result = false;
            }
            else { positive_filter_view_in_msg_box = "без фильтров"; return result = true; }

        }

        public Boolean Filters_negative_word(string _filter_words, string htmlTextPanel)
        {
            
            bool result;
            String bodyText = " ";
            if (Form1.MyGlavForm.checkBox2.Checked == true)
            {
                negative_filter_view_in_msg_box = "не нужных слов нет";
                String filters = _filter_words;
                try
                {

                    IWebElement body = _driver.FindElement(By.CssSelector(htmlTextPanel));
                    bodyText = body.Text; //текст поста #react-root > section > main > div > div > article > div.eo2As > div.KlCQn.EtaWk > ul > li > div > div > div > span
                }
                catch (Exception) { negative_filter_view_in_msg_box = "null"; return result = false; }

                // Console.WriteLine(bodyText);

                string[] words = filters.Split(',');

                foreach (string word in words)
                {
                    result = Regex.IsMatch(bodyText, @"\b" + word + @"\b", RegexOptions.IgnoreCase);
                    if (result == true)
                    {
                        negative_filter_view_in_msg_box = "не нужное слово: "+word;
                        return result;


                    }

                }
                return result = false;
            }
            else { negative_filter_view_in_msg_box = "без фильтров"; return result = false; }

        }

    }
}
