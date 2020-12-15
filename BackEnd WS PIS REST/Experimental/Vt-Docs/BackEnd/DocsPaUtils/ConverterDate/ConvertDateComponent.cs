﻿using log4net;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DocsPaUtils.ConverterDate
{
    public class ConvertDateComponent: IConverterDate
    {
        private ILog logger = LogManager.GetLogger(typeof(ConvertDateComponent));
        #region CONSTANTS
        private string[] dateFormats = { "ddd MMM dd HH:mm:ss zzz yyyy", "dd/MM/yyyy HH:mm:ss", "dd/MM/yyyy HH.mm.ss"};
        private Dictionary<string, string> timeZones = null;
        private void initTimeZones()
        {
            timeZones = new Dictionary<string, string>();
            timeZones.Add("Etc/GMT+12", "-12:00");
            timeZones.Add("Etc/GMT+11", "-11:00");
            timeZones.Add("Pacific/Apia", "-11:00");
            timeZones.Add("Pacific/Midway", "-11:00");
            timeZones.Add("Pacific/Niue", "-11:00");
            timeZones.Add("Pacific/Pago_Pago", "-11:00");
            timeZones.Add("Pacific/Samoa ", "-11:00");
            timeZones.Add("US/Samoa", "-11:00");
            timeZones.Add("America/Adak", "-10:00");
            timeZones.Add("America/Atka ", "-10:00");
            timeZones.Add("US/Aleutian", "-10:00");
            timeZones.Add("Etc/GMT+1", "-10:00");
            timeZones.Add("HST", "-10:00");
            timeZones.Add("Pacific/Fakaofo", "-10:00");
            timeZones.Add("Pacific/Honolulu", "-10:00");
            timeZones.Add("US/Hawaii", "-10:00");
            timeZones.Add("Pacific/Johnston", "-10:00");
            timeZones.Add("Pacific/Rarotonga", "-10:00");
            timeZones.Add("Pacific/Tahiti", "-10:00");
            timeZones.Add("Pacific/Marquesas", "-0930");
            timeZones.Add("America/Anchorage", "-09:00");
            timeZones.Add("US/Alaska", "-09:00");
            timeZones.Add("America/Juneau", "-09:00");
            timeZones.Add("America/Nome", "-09:00");
            timeZones.Add("America/Yakutat", "-09:00");
            timeZones.Add("Etc/GMT+9", "-09:00");
            timeZones.Add("Pacific/Gambier", "-09:00");
            timeZones.Add("America/Dawson", "-08:00");
            timeZones.Add("America/Los_Angeles", "-08:00");
            timeZones.Add("US/Pacific ", "-08:00");
            timeZones.Add("US/Pacific-New", "-08:00");
            timeZones.Add("America/Santa_Isabel", "-08:00");
            timeZones.Add("America/Tijuana", "-08:00");
            timeZones.Add("America/Ensenada", "-08:00");
            timeZones.Add("Mexico/BajaNorte", "-08:00");
            timeZones.Add("America/Vancouver", "-08:00");
            timeZones.Add("Canada/Pacific", "-08:00");
            timeZones.Add("America/Whitehorse", "-08:00");
            timeZones.Add("Canada/Yukon", "-08:00");
            timeZones.Add("Etc/GMT+8", "-08:00");
            timeZones.Add("PST8PDT", "-08:00");
            timeZones.Add("Pacific/Pitcairn", "-08:00");
            timeZones.Add("America/Boise", "-07:00");
            timeZones.Add("America/Cambridge_Bay", "-07:00");
            timeZones.Add("America/Chihuahua", "-07:00");
            timeZones.Add("America/Dawson_Creek", "-07:00");
            timeZones.Add("America/Denver", "-07:00");
            timeZones.Add("America/Shiprock", "-07:00");
            timeZones.Add("Navajo", "-07:00");
            timeZones.Add("US/Mountain", "-07:00");
            timeZones.Add("America/Edmonton", "-07:00");
            timeZones.Add("Canada/Mountain", "-07:00");
            timeZones.Add("America/Hermosillo", "-07:00");
            timeZones.Add("America/Inuvik", "-07:00");
            timeZones.Add("America/Mazatlan", "-07:00");
            timeZones.Add("Mexico/BajaSur", "-07:00");
            timeZones.Add("America/Ojinaga", "-07:00");
            timeZones.Add("America/Phoenix", "-07:00");
            timeZones.Add("US/Arizona", "-07:00");
            timeZones.Add("America/Yellowknife", "-07:00");
            timeZones.Add("Etc/GMT+7", "-07:00");
            timeZones.Add("MST", "-07:00");
            timeZones.Add("MST7MDT", "-07:00");
            timeZones.Add("America/Bahia_Banderas", "-06:00");
            timeZones.Add("America/Belize", "-06:00");
            timeZones.Add("America/Cancun", "-06:00");
            timeZones.Add("America/ChicagoUS/Central", "-06:00");
            timeZones.Add("America/Costa_Rica", "-06:00");
            timeZones.Add("America/El_Salvador", "-06:00");
            timeZones.Add("America/Guatemala", "-06:00");
            timeZones.Add("America/Indiana/Knox", "-06:00");
            timeZones.Add("America/Knox_IN", "-06:00");
            timeZones.Add("US/Indiana-Starke", "-06:00");
            timeZones.Add("America/Indiana/Tell_City", "-06:00");
            timeZones.Add("America/Managua", "-06:00");
            timeZones.Add("America/Matamoros", "-06:00");
            timeZones.Add("America/Menominee", "-06:00");
            timeZones.Add("America/Merida", "-06:00");
            timeZones.Add("America/Mexico_City", "-06:00");
            timeZones.Add("Mexico/General", "-06:00");
            timeZones.Add("America/Monterrey", "-06:00");
            timeZones.Add("America/North_Dakota/Center", "-06:00");
            timeZones.Add("America/North_Dakota/New_Salem", "-06:00");
            timeZones.Add("America/Rainy_River", "-06:00");
            timeZones.Add("America/Rankin_Inlet", "-06:00");
            timeZones.Add("America/Regina", "-06:00");
            timeZones.Add("Canada/East-Saskatchewan", "-06:00");
            timeZones.Add("Canada/Saskatchewan", "-06:00");
            timeZones.Add("America/Swift_Current", "-06:00");
            timeZones.Add("America/Tegucigalpa", "-06:00");
            timeZones.Add("America/Winnipeg", "-06:00");
            timeZones.Add("Canada/Central", "-06:00");
            timeZones.Add("CST6CDT", "-06:00");
            timeZones.Add("Etc/GMT+6", "-06:00");
            timeZones.Add("Pacific/Easter", "-06:00");
            timeZones.Add("Chile/EasterIsland", "-06:00");
            timeZones.Add("Pacific/Galapagos", "-06:00");
            timeZones.Add("America/Atikokan", "-05:00");
            timeZones.Add("America/Coral_Harbour", "-05:00");
            timeZones.Add("America/Bogota", "-05:00");
            timeZones.Add("America/Cayman", "-05:00");
            timeZones.Add("America/Detroit", "-05:00");
            timeZones.Add("US/Michigan", "-05:00");
            timeZones.Add("America/Grand_Turk", "-05:00");
            timeZones.Add("America/Guayaquil", "-05:00");
            timeZones.Add("America/Havana", "-05:00");
            timeZones.Add("Cuba", "-05:00");
            timeZones.Add("America/Indiana/Indianapolis", "-05:00");
            timeZones.Add("America/Fort_Wayne", "-05:00");
            timeZones.Add("America/Indianapolis", "-05:00");
            timeZones.Add("US/East-Indiana", "-05:00");
            timeZones.Add("America/Indiana/Marengo", "-05:00");
            timeZones.Add("America/Indiana/Petersburg", "-05:00");
            timeZones.Add("America/Indiana/Vevay", "-05:00");
            timeZones.Add("America/Indiana/Vincennes", "-05:00");
            timeZones.Add("America/Indiana/Winamac", "-05:00");
            timeZones.Add("America/Iqaluit", "-05:00");
            timeZones.Add("America/JamaicaJamaica", "-05:00");
            timeZones.Add("America/Kentucky/Louisville", "-05:00");
            timeZones.Add("America/Louisville", "-05:00");
            timeZones.Add("America/Kentucky/Monticello", "-05:00");
            timeZones.Add("America/Lima", "-05:00");
            timeZones.Add("America/Montreal", "-05:00");
            timeZones.Add("America/Nassau", "-05:00");
            timeZones.Add("America/New_York", "-05:00");
            timeZones.Add("US/Eastern", "-05:00");
            timeZones.Add("America/Nipigon", "-05:00");
            timeZones.Add("America/Panama", "-05:00");
            timeZones.Add("America/Pangnirtung", "-05:00");
            timeZones.Add("America/Port-au-Prince", "-05:00");
            timeZones.Add("America/Resolute", "-05:00");
            timeZones.Add("America/Thunder_Bay", "-05:00");
            timeZones.Add("America/TorontoCanada/Eastern", "-05:00");
            timeZones.Add("EST", "-05:00");
            timeZones.Add("EST5EDT", "-05:00");
            timeZones.Add("Etc/GMT+5", "-05:00");
            timeZones.Add("America/Caracas", "-0430");
            timeZones.Add("America/Anguilla", "-04:00");
            timeZones.Add("America/Antigua", "-04:00");
            timeZones.Add("America/Argentina/San_Luis", "-03:00");
            timeZones.Add("America/Aruba", "-04:00");
            timeZones.Add("America/Asuncion", "-04:00");
            timeZones.Add("America/Barbados", "-04:00");
            timeZones.Add("America/Blanc-Sablon", "-04:00");
            timeZones.Add("America/Boa_Vista", "-04:00");
            timeZones.Add("America/Campo_Grande", "-04:00");
            timeZones.Add("America/Cuiaba", "-04:00");
            timeZones.Add("America/Curacao", "-04:00");
            timeZones.Add("America/Dominica", "-04:00");
            timeZones.Add("America/Eirunepe", "-04:00");
            timeZones.Add("America/Glace_Bay", "-04:00");
            timeZones.Add("America/Goose_Bay", "-04:00");
            timeZones.Add("America/Grenada", "-04:00");
            timeZones.Add("America/Guadeloupe", "-04:00");
            timeZones.Add("America/Marigot", "-04:00");
            timeZones.Add("America/St_Barthelemy", "-04:00");
            timeZones.Add("America/Guyana", "-04:00");
            timeZones.Add("America/Halifax", "-04:00");
            timeZones.Add("Canada/Atlantic", "-04:00");
            timeZones.Add("America/La_Paz", "-04:00");
            timeZones.Add("America/Manaus", "-04:00");
            timeZones.Add("Brazil/West", "-04:00");
            timeZones.Add("America/Martinique", "-04:00");
            timeZones.Add("America/Moncton", "-04:00");
            timeZones.Add("America/Montserrat", "-04:00");
            timeZones.Add("America/Port_of_Spain", "-04:00");
            timeZones.Add("America/Porto_Velho", "-04:00");
            timeZones.Add("America/Puerto_Rico", "-04:00");
            timeZones.Add("America/Rio_Branco", "-04:00");
            timeZones.Add("America/Porto_Acre", "-04:00");
            timeZones.Add("Brazil/Acre", "-04:00");
            timeZones.Add("America/Santiago", "-04:00");
            timeZones.Add("Chile/Continental", "-04:00");
            timeZones.Add("America/Santo_Domingo", "-04:00");
            timeZones.Add("America/St_Kitts", "-04:00");
            timeZones.Add("America/St_Lucia", "-04:00");
            timeZones.Add("America/St_Thomas", "-04:00");
            timeZones.Add("America/Virgin", "-04:00");
            timeZones.Add("America/St_Vincent", "-04:00");
            timeZones.Add("America/Thule", "-04:00");
            timeZones.Add("America/Tortola", "-04:00");
            timeZones.Add("Antarctica/Palmer", "-04:00");
            timeZones.Add("Atlantic/Bermuda", "-04:00");
            timeZones.Add("Atlantic/Stanley", "-04:00");
            timeZones.Add("Etc/GMT+4", "-04:00");
            timeZones.Add("America/St_Johns", "-0330");
            timeZones.Add("Canada/Newfoundland", "-0330");
            timeZones.Add("America/Araguaina", "-03:00");
            timeZones.Add("America/Argentina/Buenos_Aires", "-03:00");
            timeZones.Add("America/Buenos_Aires", "-03:00");
            timeZones.Add("America/Argentina/Catamarca", "-03:00");
            timeZones.Add("America/Argentina/ComodRivadavia", "-03:00");
            timeZones.Add("America/Catamarca", "-03:00");
            timeZones.Add("America/Argentina/Cordoba", "-03:00");
            timeZones.Add("America/Cordoba", "-03:00");
            timeZones.Add("America/Rosario", "-03:00");
            timeZones.Add("America/Argentina/Jujuy", "-03:00");
            timeZones.Add("America/Jujuy", "-03:00");
            timeZones.Add("America/Argentina/La_Rioja", "-03:00");
            timeZones.Add("America/Argentina/Mendoza", "-03:00");
            timeZones.Add("America/Mendoza", "-03:00");
            timeZones.Add("America/Argentina/Rio_Gallegos", "-03:00");
            timeZones.Add("America/Argentina/Salta", "-03:00");
            timeZones.Add("America/Argentina/San_Juan", "-03:00");
            timeZones.Add("America/Argentina/Tucuman", "-03:00");
            timeZones.Add("America/Argentina/Ushuaia", "-03:00");
            timeZones.Add("America/Bahia", "-03:00");
            timeZones.Add("America/Belem", "-03:00");
            timeZones.Add("America/Cayenne", "-03:00");
            timeZones.Add("America/Fortaleza", "-03:00");
            timeZones.Add("America/Godthab", "-03:00");
            timeZones.Add("America/Maceio", "-03:00");
            timeZones.Add("America/Miquelon", "-03:00");
            timeZones.Add("America/Montevideo", "-03:00");
            timeZones.Add("America/Paramaribo", "-03:00");
            timeZones.Add("America/Recife", "-03:00");
            timeZones.Add("America/Santarem", "-03:00");
            timeZones.Add("America/Sao_Paulo", "-03:00");
            timeZones.Add("Brazil/East", "-03:00");
            timeZones.Add("Antarctica/Rothera", "-03:00");
            timeZones.Add("Etc/GMT+3", "-03:00");
            timeZones.Add("America/Noronha", "-02:00");
            timeZones.Add("Brazil/DeNoronha", "-02:00");
            timeZones.Add("Atlantic/South_Georgia", "-02:00");
            timeZones.Add("Etc/GMT+2", "-02:00");
            timeZones.Add("America/Scoresbysund", "-01:00");
            timeZones.Add("Atlantic/Azores", "-01:00");
            timeZones.Add("Atlantic/Cape_Verde", "-01:00");
            timeZones.Add("Africa/Abidjan", "+00:00");
            timeZones.Add("Africa/Accra", "+00:00");
            timeZones.Add("Africa/Bamako", "+00:00");
            timeZones.Add("Africa/Timbuktu", "+00:00");
            timeZones.Add("Africa/Banjul", "+00:00");
            timeZones.Add("Africa/Bissau", "+00:00");
            timeZones.Add("Africa/Casablanca", "+00:00");
            timeZones.Add("Africa/Conakry", "+00:00");
            timeZones.Add("Africa/Dakar", "+00:00");
            timeZones.Add("Africa/El_Aaiun", "+00:00");
            timeZones.Add("Africa/Freetown", "+00:00");
            timeZones.Add("Africa/Lome", "+00:00");
            timeZones.Add("Africa/Monrovia", "+00:00");
            timeZones.Add("Africa/Nouakchott", "+00:00");
            timeZones.Add("Africa/Ouagadougou", "+00:00");
            timeZones.Add("Africa/Sao_Tome", "+00:00");
            timeZones.Add("America/Danmarkshavn", "+00:00");
            timeZones.Add("Atlantic/Canary", "+00:00");
            timeZones.Add("Atlantic/Faroe", "+00:00");
            timeZones.Add("Atlantic/Faeroe", "+00:00");
            timeZones.Add("Atlantic/Madeira", "+00:00");
            timeZones.Add("Atlantic/Reykjavik", "+00:00");
            timeZones.Add("Iceland", "+00:00");
            timeZones.Add("Atlantic/St_Helena", "+00:00");
            timeZones.Add("Etc/GMT", "+00:00");
            timeZones.Add("Etc/GMT+", "+00:00");
            timeZones.Add("Etc/GMT-", "+00:00");
            timeZones.Add("Etc/Greenwich", "+00:00");
            timeZones.Add("GMT", "+00:00");
            timeZones.Add("GMT+", "+00:00");
            timeZones.Add("GMT-", "+00:00");
            timeZones.Add("Greenwich", "+00:00");
            timeZones.Add("Etc/UCT", "+00:00");
            timeZones.Add("UCT", "+00:00");
            timeZones.Add("Etc/UTC", "+00:00");
            timeZones.Add("Etc/Universal", "+00:00");
            timeZones.Add("Etc/Zulu", "+00:00");
            timeZones.Add("Universal", "+00:00");
            timeZones.Add("Zulu", "+00:00");
            timeZones.Add("Europe/Dublin", "+00:00");
            timeZones.Add("Eire", "+00:00");
            timeZones.Add("Europe/Lisbon", "+00:00");
            timeZones.Add("Portugal", "+00:00");
            timeZones.Add("Europe/London", "+00:00");
            timeZones.Add("Europe/Belfast", "+00:00");
            timeZones.Add("Europe/Guernsey", "+00:00");
            timeZones.Add("Europe/Isle_of_Man", "+00:00");
            timeZones.Add("Europe/Jersey", "+00:00");
            timeZones.Add("GB", "+00:00");
            timeZones.Add("GB-Eire", "+00:00");
            timeZones.Add("UTC", "+00:00");
            timeZones.Add("WET", "+00:00");
            timeZones.Add("Africa/Algiers", "+01:00");
            timeZones.Add("Africa/Bangui", "+01:00");
            timeZones.Add("Africa/Brazzaville", "+01:00");
            timeZones.Add("Africa/Ceuta", "+01:00");
            timeZones.Add("Africa/Douala", "+01:00");
            timeZones.Add("Africa/Kinshasa", "+01:00");
            timeZones.Add("Africa/Lagos", "+01:00");
            timeZones.Add("Africa/Libreville", "+01:00");
            timeZones.Add("Africa/Luanda", "+01:00");
            timeZones.Add("Africa/Malabo", "+01:00");
            timeZones.Add("Africa/Ndjamena", "+01:00");
            timeZones.Add("Africa/Niamey", "+01:00");
            timeZones.Add("Africa/Porto-Novo", "+01:00");
            timeZones.Add("Africa/Tunis", "+01:00");
            timeZones.Add("Africa/Windhoek", "+01:00");
            timeZones.Add("CET", "+01:00");
            timeZones.Add("Etc/GMT-1", "+01:00");
            timeZones.Add("Europe/Amsterdam", "+01:00");
            timeZones.Add("Europe/Andorra", "+01:00");
            timeZones.Add("Europe/Belgrade", "+01:00");
            timeZones.Add("Europe/Ljubljana", "+01:00");
            timeZones.Add("Europe/Podgorica", "+01:00");
            timeZones.Add("Europe/Sarajevo", "+01:00");
            timeZones.Add("Europe/Skopje", "+01:00");
            timeZones.Add("Europe/Zagreb", "+01:00");
            timeZones.Add("Europe/Berlin", "+01:00");
            timeZones.Add("Europe/Brussels", "+01:00");
            timeZones.Add("Europe/Budapest", "+01:00");
            timeZones.Add("Europe/Copenhagen", "+01:00");
            timeZones.Add("Europe/Gibraltar", "+01:00");
            timeZones.Add("Europe/Luxembourg", "+01:00");
            timeZones.Add("Europe/Madrid", "+01:00");
            timeZones.Add("Europe/Malta", "+01:00");
            timeZones.Add("Europe/Monaco", "+01:00");
            timeZones.Add("Europe/Oslo", "+01:00");
            timeZones.Add("Arctic/Longyearbyen", "+01:00");
            timeZones.Add("Atlantic/Jan_Mayen", "+01:00");
            timeZones.Add("Europe/Paris", "+01:00");
            timeZones.Add("Europe/Prague", "+01:00");
            timeZones.Add("Europe/Bratislava", "+01:00");
            timeZones.Add("Europe/Rome", "+01:00");
            timeZones.Add("Europe/San_Marino", "+01:00");
            timeZones.Add("Europe/Vatican", "+01:00");
            timeZones.Add("Europe/Stockholm", "+01:00");
            timeZones.Add("Europe/Tirane", "+01:00");
            timeZones.Add("Europe/Vaduz", "+01:00");
            timeZones.Add("Europe/Vienna", "+01:00");
            timeZones.Add("Europe/Warsaw", "+01:00");
            timeZones.Add("Poland", "+01:00");
            timeZones.Add("Europe/Zurich", "+01:00");
            timeZones.Add("MET", "+01:00");
            timeZones.Add("Africa/Blantyre", "+02:00");
            timeZones.Add("Africa/Bujumbura", "+02:00");
            timeZones.Add("Africa/CairoEgypt", "+02:00");
            timeZones.Add("Africa/Gaborone", "+02:00");
            timeZones.Add("Africa/Harare", "+02:00");
            timeZones.Add("Africa/Johannesburg", "+02:00");
            timeZones.Add("Africa/Kigali", "+02:00");
            timeZones.Add("Africa/Lubumbashi", "+02:00");
            timeZones.Add("Africa/Lusaka", "+02:00");
            timeZones.Add("Africa/Maputo", "+02:00");
            timeZones.Add("Africa/Maseru", "+02:00");
            timeZones.Add("Africa/Mbabane", "+02:00");
            timeZones.Add("Africa/TripoliLibya", "+02:00");
            timeZones.Add("Asia/Amman", "+02:00");
            timeZones.Add("Asia/Beirut", "+02:00");
            timeZones.Add("Asia/Damascus", "+02:00");
            timeZones.Add("Asia/Gaza", "+02:00");
            timeZones.Add("Asia/Jerusalem", "+02:00");
            timeZones.Add("Asia/Tel_Aviv", "+02:00");
            timeZones.Add("Israel", "+02:00");
            timeZones.Add("Asia/Nicosia", "+02:00");
            timeZones.Add("Europe/Nicosia", "+02:00");
            timeZones.Add("EET", "+02:00");
            timeZones.Add("Etc/GMT-2", "+02:00");
            timeZones.Add("Europe/Athens", "+02:00");
            timeZones.Add("Europe/Bucharest", "+02:00");
            timeZones.Add("Europe/Chisinau", "+02:00");
            timeZones.Add("Europe/Tiraspol", "+02:00");
            timeZones.Add("Europe/Helsinki", "+02:00");
            timeZones.Add("Europe/Mariehamn", "+02:00");
            timeZones.Add("Europe/Istanbul", "+02:00");
            timeZones.Add("Asia/Istanbul", "+02:00");
            timeZones.Add("Turkey", "+02:00");
            timeZones.Add("Europe/Kaliningrad", "+02:00");
            timeZones.Add("Europe/Kiev", "+02:00");
            timeZones.Add("Europe/Minsk", "+02:00");
            timeZones.Add("Europe/Riga", "+02:00");
            timeZones.Add("Europe/Simferopol", "+02:00");
            timeZones.Add("Europe/Sofia", "+02:00");
            timeZones.Add("Europe/Tallinn", "+02:00");
            timeZones.Add("Europe/Uzhgorod", "+02:00");
            timeZones.Add("Europe/Vilnius", "+02:00");
            timeZones.Add("Europe/Zaporozhye", "+02:00");
            timeZones.Add("Africa/Addis_Ababa", "+03:00");
            timeZones.Add("Africa/Asmara", "+03:00");
            timeZones.Add("Africa/Asmera", "+03:00");
            timeZones.Add("Africa/Dar_es_Salaam", "+03:00");
            timeZones.Add("Africa/Djibouti", "+03:00");
            timeZones.Add("Africa/Kampala", "+03:00");
            timeZones.Add("Africa/Khartoum", "+03:00");
            timeZones.Add("Africa/Mogadishu", "+03:00");
            timeZones.Add("Africa/Nairobi", "+03:00");
            timeZones.Add("Antarctica/Syowa", "+03:00");
            timeZones.Add("Asia/Aden", "+03:00");
            timeZones.Add("Asia/Baghdad", "+03:00");
            timeZones.Add("Asia/Bahrain", "+03:00");
            timeZones.Add("Asia/Kuwait", "+03:00");
            timeZones.Add("Asia/Qatar", "+03:00");
            timeZones.Add("Asia/Riyadh", "+03:00");
            timeZones.Add("Etc/GMT-3", "+03:00");
            timeZones.Add("Europe/MoscowW-SU", "+03:00");
            timeZones.Add("Europe/Samara", "+03:00");
            timeZones.Add("Europe/Volgograd", "+03:00");
            timeZones.Add("Indian/Antananarivo", "+03:00");
            timeZones.Add("Indian/Comoro", "+03:00");
            timeZones.Add("Indian/Mayotte", "+03:00");
            timeZones.Add("Asia/TehranIran", "+0330");
            timeZones.Add("Asia/Baku", "+04:00");
            timeZones.Add("Asia/Dubai", "+04:00");
            timeZones.Add("Asia/Muscat", "+04:00");
            timeZones.Add("Asia/Tbilisi", "+04:00");
            timeZones.Add("Asia/Yerevan", "+04:00");
            timeZones.Add("Etc/GMT-4", "+04:00");
            timeZones.Add("Indian/Mahe", "+04:00");
            timeZones.Add("Indian/Mauritius", "+04:00");
            timeZones.Add("Indian/Reunion", "+04:00");
            timeZones.Add("Asia/Kabul", "+0430");
            timeZones.Add("Antarctica/Mawson", "+05:00");
            timeZones.Add("Asia/Aqtau", "+05:00");
            timeZones.Add("Asia/Aqtobe", "+05:00");
            timeZones.Add("Asia/Ashgabat", "+05:00");
            timeZones.Add("Asia/Ashkhabad", "+05:00");
            timeZones.Add("Asia/Dushanbe", "+05:00");
            timeZones.Add("Asia/Karachi", "+05:00");
            timeZones.Add("Asia/Oral", "+05:00");
            timeZones.Add("Asia/Samarkand", "+05:00");
            timeZones.Add("Asia/Tashkent", "+05:00");
            timeZones.Add("Asia/Yekaterinburg", "+05:00");
            timeZones.Add("Etc/GMT-5", "+05:00");
            timeZones.Add("Indian/Kerguelen", "+05:00");
            timeZones.Add("Indian/Maldives", "+05:00");
            timeZones.Add("Asia/Colombo", "+0530");
            timeZones.Add("Asia/Kolkata", "+0530");
            timeZones.Add("Asia/Calcutta", "+0530");
            timeZones.Add("Asia/Kathmandu", "+0545");
            timeZones.Add("Asia/Katmandu", "+0545");
            timeZones.Add("Antarctica/Vostok", "+06:00");
            timeZones.Add("Asia/Almaty", "+06:00");
            timeZones.Add("Asia/Bishkek", "+06:00");
            timeZones.Add("Asia/DhakaAsia/Dacca", "+06:00");
            timeZones.Add("Asia/Novokuznetsk", "+06:00");
            timeZones.Add("Asia/Novosibirsk", "+06:00");
            timeZones.Add("Asia/Omsk", "+06:00");
            timeZones.Add("Asia/Qyzylorda", "+06:00");
            timeZones.Add("Asia/Thimphu", "+06:00");
            timeZones.Add("Asia/Thimbu", "+06:00");
            timeZones.Add("Etc/GMT-6", "+06:00");
            timeZones.Add("Indian/Chagos", "+06:00");
            timeZones.Add("Asia/Rangoon", "+0630");
            timeZones.Add("Indian/Cocos", "+0630");
            timeZones.Add("Antarctica/Davis", "+07:00");
            timeZones.Add("Asia/Bangkok", "+07:00");
            timeZones.Add("Asia/Ho_Chi_Minh", "+07:00");
            timeZones.Add("Asia/Saigon", "+07:00");
            timeZones.Add("Asia/Hovd", "+07:00");
            timeZones.Add("Asia/Jakarta", "+07:00");
            timeZones.Add("Asia/Krasnoyarsk", "+07:00");
            timeZones.Add("Asia/Phnom_Penh", "+07:00");
            timeZones.Add("Asia/Pontianak", "+07:00");
            timeZones.Add("Asia/Vientiane", "+07:00");
            timeZones.Add("Etc/GMT-7", "+07:00");
            timeZones.Add("Indian/Christmas", "+07:00");
            timeZones.Add("Antarctica/Casey", "+08:00");
            timeZones.Add("Asia/Brunei", "+08:00");
            timeZones.Add("Asia/Choibalsan", "+08:00");
            timeZones.Add("Asia/Chongqing", "+08:00");
            timeZones.Add("Asia/Chungking", "+08:00");
            timeZones.Add("Asia/Harbin", "+08:00");
            timeZones.Add("Asia/Hong_Kong", "+08:00");
            timeZones.Add("Hongkong", "+08:00");
            timeZones.Add("Asia/Irkutsk", "+08:00");
            timeZones.Add("Asia/Kashgar", "+08:00");
            timeZones.Add("Asia/Kuala_Lumpur", "+08:00");
            timeZones.Add("Asia/Kuching", "+08:00");
            timeZones.Add("Asia/Macau", "+08:00");
            timeZones.Add("Asia/Macao", "+08:00");
            timeZones.Add("Asia/Makassar", "+08:00");
            timeZones.Add("Asia/Ujung_Pandang", "+08:00");
            timeZones.Add("Asia/Manila", "+08:00");
            timeZones.Add("Asia/Shanghai", "+08:00");
            timeZones.Add("PRC", "+08:00");
            timeZones.Add("Asia/Singapore", "+08:00");
            timeZones.Add("Singapore", "+08:00");
            timeZones.Add("Asia/TaipeiROC", "+08:00");
            timeZones.Add("Asia/Ulaanbaatar", "+08:00");
            timeZones.Add("Asia/Ulan_Bator", "+08:00");
            timeZones.Add("Asia/Urumqi", "+08:00");
            timeZones.Add("Australia/Perth", "+08:00");
            timeZones.Add("Australia/West", "+08:00");
            timeZones.Add("Etc/GMT-8", "+08:00");
            timeZones.Add("Australia/Eucla", "+0845");
            timeZones.Add("Asia/Dili", "+09:00");
            timeZones.Add("Asia/Jayapura", "+09:00");
            timeZones.Add("Asia/Pyongyang", "+09:00");
            timeZones.Add("Asia/SeoulROK", "+09:00");
            timeZones.Add("Asia/TokyoJapan", "+09:00");
            timeZones.Add("Asia/Yakutsk", "+09:00");
            timeZones.Add("Etc/GMT-9", "+09:00");
            timeZones.Add("Pacific/Palau", "+09:00");
            timeZones.Add("Australia/Adelaide", "+0930");
            timeZones.Add("Australia/South", "+0930");
            timeZones.Add("Australia/Yancowinna", "+0930");
            timeZones.Add("Australia/Broken_Hill", "+0930");
            timeZones.Add("Australia/North", "+0930");
            timeZones.Add("Australia/Darwin", "+0930");
            timeZones.Add("Antarctica/DumontDUrville", "+10:00");
            timeZones.Add("Asia/Sakhalin", "+10:00");
            timeZones.Add("Asia/Vladivostok", "+10:00");
            timeZones.Add("Australia/Brisbane", "+10:00");
            timeZones.Add("Australia/Queensland", "+10:00");
            timeZones.Add("Australia/Currie", "+10:00");
            timeZones.Add("Australia/Hobart", "+10:00");
            timeZones.Add("Australia/Tasmania", "+10:00");
            timeZones.Add("Australia/Lindeman", "+10:00");
            timeZones.Add("Australia/Victoria", "+10:00");
            timeZones.Add("Australia/Melbourne", "+10:00");
            timeZones.Add("Australia/Sydney", "+10:00");
            timeZones.Add("Australia/ACT", "+10:00");
            timeZones.Add("Australia/Canberra", "+10:00");
            timeZones.Add("Australia/NSW", "+10:00");
            timeZones.Add("Pacific/Chuuk", "+10:00");
            timeZones.Add("Pacific/Truk", "+10:00");
            timeZones.Add("Pacific/Yap", "+10:00");
            timeZones.Add("Pacific/Guam", "+10:00");
            timeZones.Add("Pacific/Port_Moresby", "+10:00");
            timeZones.Add("Pacific/Saipan", "+10:00");
            timeZones.Add("Australia/Lord_Howe", "+1030");
            timeZones.Add("Australia/LHI", "+1030");
            timeZones.Add("Antarctica/Macquarie", "+11:00");
            timeZones.Add("Asia/Anadyr", "+11:00");
            timeZones.Add("Asia/Kamchatka", "+11:00");
            timeZones.Add("Asia/Magadan", "+11:00");
            timeZones.Add("Etc/GMT-11", "+11:00");
            timeZones.Add("Pacific/Efate", "+11:00");
            timeZones.Add("Pacific/Guadalcanal", "+11:00");
            timeZones.Add("Pacific/Kosrae", "+11:00");
            timeZones.Add("Pacific/Noumea", "+11:00");
            timeZones.Add("Pacific/Pohnpei", "+11:00");
            timeZones.Add("Pacific/Ponape", "+11:00");
            timeZones.Add("Pacific/Norfolk", "+1130");
            timeZones.Add("Antarctica/McMurdo", "+12:00");
            timeZones.Add("Antarctica/South_Pole", "+12:00");
            timeZones.Add("Etc/GMT-12", "+12:00");
            timeZones.Add("Pacific/Auckland", "+12:00");
            timeZones.Add("NZ", "+12:00");
            timeZones.Add("Pacific/Fiji", "+12:00");
            timeZones.Add("Pacific/Funafuti", "+12:00");
            timeZones.Add("Pacific/Kwajalein", "+12:00");
            timeZones.Add("Kwajalein", "+12:00");
            timeZones.Add("Pacific/Majuro", "+12:00");
            timeZones.Add("Pacific/Nauru", "+12:00");
            timeZones.Add("Pacific/Tarawa", "+12:00");
            timeZones.Add("Pacific/Wake", "+12:00");
            timeZones.Add("Pacific/Wallis", "+12:00");
            timeZones.Add("Pacific/Chatham", "+1245");
            timeZones.Add("NZ-CHAT", "+1245");
            timeZones.Add("Etc/GMT-13", "+13:00");
            timeZones.Add("Pacific/Enderbury", "+13:00");
            timeZones.Add("Pacific/Tongatapu", "+13:00");
            timeZones.Add("Etc/GMT-14", "+14:00");
            timeZones.Add("Pacific/Kiritimati", "+14:00");
        }
        #endregion

        public ConvertDateComponent()
        {
            initTimeZones();
        }

        public DateTime getDateTime(string strDateTime)
        {
            DateTime dateTime;
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            logger.Debug("Data in ingresso: "+strDateTime);
            string[] arrayDate = strDateTime.Split(' ');
            string timeZone;
            string timeZoneValue = timeZones["CET"];

            if (arrayDate.Length > 4)
            {
                timeZone = arrayDate[4];
                if (timeZones.ContainsKey(timeZone))
                {
                    timeZoneValue = timeZones[timeZone];
                    this.logger.Error("Time zone trovato : " + timeZoneValue);
                }

                strDateTime = strDateTime.Replace(timeZone, timeZoneValue);
            }

            dateTime = DateTime.ParseExact(strDateTime, dateFormats, cultureInfo, DateTimeStyles.None);
            return dateTime;
        }
    }
}