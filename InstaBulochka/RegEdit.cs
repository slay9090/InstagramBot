using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InstaBulochka
{
    class RegEdit
    {
        public void StartTrialProgamm(string nameRegKey, int sumStart)
        {

            try
            {


                RegistryKey currentUserKey = Registry.CurrentUser;



                RegistryKey helloKeyRead = currentUserKey.OpenSubKey(nameRegKey); //BDriverKey

                if (helloKeyRead == null) //создаем параметр реестра если нет его
                {


                    RegistryKey helloKey = currentUserKey.CreateSubKey(nameRegKey);
                    helloKey.SetValue("value", sumStart);

                    helloKey.Close();
                 //   Osnova example = new Osnova();
                 //   example.Show();
                }

                else //если есть параметр реестра
                {
                    int kolichestvo_zapuskov;

                    string login = helloKeyRead.GetValue("value").ToString();
                    kolichestvo_zapuskov = Int32.Parse(login);
                    helloKeyRead.Close();
                    Console.WriteLine(login);
                    if (kolichestvo_zapuskov == 0) // если параметр равен 0
                    {                      
                        TrialEndWindow _trialendwindow = new TrialEndWindow();
                        _trialendwindow.Show();
                       
                    }
                    else //если есть параметр реестра минусуем 1 запуск
                    {
                        RegistryKey helloKey = currentUserKey.CreateSubKey(nameRegKey);
                        helloKey.SetValue("value", kolichestvo_zapuskov - 1);

                        helloKey.Close();

                        //Osnova example = new Osnova();
                        //example.Show();

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Корректная работа не возможна, запустите программу с правами Администратора", "Error UAC!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }

        }
    }
}
