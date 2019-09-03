using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InstaBulochka
{
    public static class ConstantsApp
    {
        public const String app_version = "1.4b";
        public const int timer_of_autostart = 60;
        public const String app_author = "Martinov A.";
        public const String url_tags = "https://www.instagram.com/explore/tags/"; //
        public const String url_geolocation = "https://www.instagram.com/explore/locations/"; //
        public const String html_mark_open_first_post = "#react-root > section > main > article > div.EZdmt > div > div > div:nth-child(1) > div:nth-child(1)"; // открыть пост Самая первая запись в теге
        public const String html_mark_panel_textbox = "body > div._2dDPU.vCf6V > div.zZYga > div > article > div.eo2As > div.EtaWk"; // панель, где находится текст поста
        public const String html_mark_button_next = "body > div._2dDPU.vCf6V > div.EfHg9 > div > div > a.HBoOv.coreSpriteRightPaginationArrow"; // кнопка следующий пост (так же, можно использовать событие клавы)
        public const String html_mark_button_like = "body > div._2dDPU.vCf6V > div.zZYga > div > article > div.eo2As > section.ltpMr.Slqrh > span.fr66n > button"; //кнопка лайка в открытом посте
        public const String html_mark_get_check_like = "body > div._2dDPU.vCf6V > div.zZYga > div > article > div.eo2As > section.ltpMr.Slqrh > span.fr66n > button > span"; // проверка стоит ли лайк
        public const String html_mark_button_subscribe = "body > div._2dDPU.vCf6V > div.zZYga > div > article > header > div.o-MQd > div.PQo_0 > div.bY2yH > button"; // //кнопка подпис. в открытом посте
        public const String html_mark_get_check_subscribe = "body > div._2dDPU.vCf6V > div.zZYga > div > article > header > div.o-MQd > div.PQo_0 > div.bY2yH > button"; // проверка, подписаны ли
        public const String html_mark_name_attribut_grey_like = "glyphsSpriteHeart__outline__24__grey_9 u-__7"; // имя атрибута когда лайк не стоит (серое сердечко)
        public const String html_mark_name_attribut_active_sucbscribe = "oW_lN _0mzm- sqdOP yWX7d        "; // имя атрибута когда не подписаны

    }
}
