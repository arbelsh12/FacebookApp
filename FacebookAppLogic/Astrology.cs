using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace FacebookAppLogic
{
    public class Astrology
    {
        private const string k_AstrologyJsonHoroscopeKeyPath = "$.description";
        private const string k_AstrologyJsonZodiacKeyPath = "$.compatibility";
        private const string k_RapidApiKeyHeader = "X-RapidAPI-Key";
        private const string k_RapidApiHostHeader = "X-RapidAPI-Host";
        private const string k_AstrologyApiKey = "9767aa43d4msh47ffc328d7f4776p1a40d0jsnedca44471bf6";
        private const string k_AstrologyApi = "sameer-kumar-aztro-v1.p.rapidapi.com";
        private readonly Zodiac r_Zodiac;
        
        private class Zodiac
        {
            public Zodiac()
            {

            }

            enum eMonth
            {
                Jan = 1,
                Feb,
                Mar,
                Apr,
                May,
                June,
                July,
                Aug,
                Sep,
                Oct,
                Nov,
                Dec,
            }

            public string FindZodiac(string i_UserBirthDate)
            {
                string[] birthDateArray = i_UserBirthDate.Split('/');
                int birthdayMonth = int.Parse(birthDateArray[0]);
                int birthdayDay = int.Parse(birthDateArray[1]);
                string zodiac = String.Empty;

                if (((birthdayMonth == (int)eMonth.Mar) && (birthdayDay >= 21 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.Apr) && (birthdayDay >= 01 || birthdayDay <= 20)))
                {
                    zodiac = "Aires";
                }
                else if (((birthdayMonth == (int)eMonth.Apr) && (birthdayDay >= 21 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.May) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Taurus";
                }
                else if (((birthdayMonth == (int)eMonth.May) && (birthdayDay >= 21 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.June) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Gemini";
                }
                else if (((birthdayMonth == (int)eMonth.June) && (birthdayDay >= 22 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.July) && (birthdayDay >= 01 || birthdayDay <= 22)))
                {
                    zodiac = "Cancer";
                }
                else if (((birthdayMonth == (int)eMonth.July) && (birthdayDay >= 23 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.Aug) && (birthdayDay >= 01 || birthdayDay <= 22)))
                {
                    zodiac = "Leo";
                }
                else if (((birthdayMonth == (int)eMonth.Aug) && (birthdayDay >= 23 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.Sep) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Virgo";
                }
                else if (((birthdayMonth == (int)eMonth.Sep) && (birthdayDay >= 22 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.Oct) && (birthdayDay >= 01 || birthdayDay <= 22)))
                {
                    zodiac = "Libra";
                }
                else if (((birthdayMonth == (int)eMonth.Oct) && (birthdayDay >= 23 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.Nov) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Scorpio";
                }
                else if (((birthdayMonth == (int)eMonth.Nov) && (birthdayDay >= 22 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.Dec) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Sagittarius";
                }
                else if (((birthdayMonth == (int)eMonth.Dec) && (birthdayDay >= 22 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.Jan) && (birthdayDay >= 01 || birthdayDay <= 20)))
                {
                    zodiac = "Capricorn";
                }
                else if (((birthdayMonth == (int)eMonth.Jan) && (birthdayDay >= 21 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.Feb) && (birthdayDay >= 01 || birthdayDay <= 19)))
                {
                    zodiac = "Aquarius";
                }
                else if (((birthdayMonth == (int)eMonth.Feb) && (birthdayDay >= 20 || birthdayDay <= 31)) || ((birthdayMonth == (int)eMonth.Mar) && (birthdayDay >= 01 || birthdayDay <= 20)))
                {
                    zodiac = "Pisces";
                }

                return zodiac;
            }
        }

        public Astrology()
        {
            r_Zodiac = new Zodiac();
        }

        //The Function return the user's daily compatibile astrology horoscope.
        public async Task<string> CreateHoroscopePost(string i_UserBirthDate)
        {
            string apiUri = await getUriByBirthday(i_UserBirthDate);
            JObject json = await getJsonFromApi(apiUri);
            string astrologyHoroscope = json.SelectToken(k_AstrologyJsonHoroscopeKeyPath)?.ToString();
            string userZodiac = json.SelectToken(k_AstrologyJsonZodiacKeyPath)?.ToString();
            string astrologyHoroscopePost = $"Hi! My zodiac is {userZodiac} and my horoscope today is {astrologyHoroscope}";

            return astrologyHoroscopePost;
        }

        private async Task<JObject> getJsonFromApi(string i_Uri)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(i_Uri),
                Headers =
                   {
                       { k_RapidApiKeyHeader, k_AstrologyApiKey},
                       { k_RapidApiHostHeader, k_AstrologyApi },
                   },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                JObject apiJson = JObject.Parse(body);

                return apiJson;
            }
        }

        private async Task<string> getUriByBirthday(string i_UserBirthDay)
        {
            string zodiac = r_Zodiac.FindZodiac(i_UserBirthDay);
            string apiUri = $"https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign={zodiac}&day=today";

            return apiUri;
        }

        public string GetZodiac(string i_UserBirthDate)
        {
            return r_Zodiac.FindZodiac(i_UserBirthDate);
        }
    }
}
