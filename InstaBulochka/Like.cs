using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace InstaBulochka
{
    class Like
    {
        
        private IWebDriver _driver;
                private ControlFormProgramm _controlFormProgramm;
        private Running _running;

        public Like(IWebDriver driver, ControlFormProgramm controlFormProgramm) {
            _driver = driver;
            _controlFormProgramm = controlFormProgramm;

            _running = new Running(_driver, _controlFormProgramm);
        }

        
       
        public void Tags(string tag, int time_wait, int limit, string filters_positive, string filters_negative, CancellationToken cancelToken) {


            _running.MarkRun(
                ConstantsApp.url_tags, 
                tag, 
                ConstantsApp.html_mark_open_first_post, 
                ConstantsApp.html_mark_button_like, 
                ConstantsApp.html_mark_button_next, 
                ConstantsApp.html_mark_get_check_like, 
                ConstantsApp.html_mark_name_attribut_grey_like, 
                ConstantsApp.html_mark_panel_textbox, 
                time_wait, 
                limit, 
                filters_positive,
                filters_negative,
                cancelToken);


        }

        public void Geolocation(string geonumber, int time_wait, int limit, string filters_positive, string filters_negative, CancellationToken cancelToken)
        {

            _running.MarkRun(
                 ConstantsApp.url_geolocation,
                 geonumber,
                 ConstantsApp.html_mark_open_first_post,
                 ConstantsApp.html_mark_button_like,
                 ConstantsApp.html_mark_button_next,
                 ConstantsApp.html_mark_get_check_like,
                 ConstantsApp.html_mark_name_attribut_grey_like,
                 ConstantsApp.html_mark_panel_textbox,
                 time_wait,
                 limit,
                filters_positive,
                filters_negative,
                 cancelToken);


        }

      






    }
}
