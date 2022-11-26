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
    public class AstrologyHoroscope
    {
        private readonly Zodiac r_Zodiac;

        private class Zodiac
        {
            public Zodiac()
            {

            }

            //TODO: check if the name of the enum is wrriten ok
            enum Month
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

            public string findZodiac(string i_userBirthDate)
            {
                string[] birthDateArray = i_userBirthDate.Split('/');
                int birthdayMonth = int.Parse(birthDateArray[0]);
                int birthdayDay = int.Parse(birthDateArray[1]);
                string zodiac = String.Empty;

                if (((birthdayMonth == (int)Month.Mar) && (birthdayDay >= 21 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.Apr) && (birthdayDay >= 01 || birthdayDay <= 20)))
                {
                    zodiac = "Aires";
                }
                else if (((birthdayMonth == (int)Month.Apr) && (birthdayDay >= 21 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.May) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Taurus";
                }
                else if (((birthdayMonth == (int)Month.Apr) && (birthdayDay >= 21 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.June) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Gemini";
                }
                else if (((birthdayMonth == (int)Month.June) && (birthdayDay >= 22 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.July) && (birthdayDay >= 01 || birthdayDay <= 22)))
                {
                    zodiac = "Cancer";
                }
                else if (((birthdayMonth == (int)Month.July) && (birthdayDay >= 23 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.Aug) && (birthdayDay >= 01 || birthdayDay <= 22)))
                {
                    zodiac = "Leo";
                }
                else if (((birthdayMonth == (int)Month.Aug) && (birthdayDay >= 23 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.Sep) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Virgo";
                }
                else if (((birthdayMonth == (int)Month.Sep) && (birthdayDay >= 22 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.Oct) && (birthdayDay >= 01 || birthdayDay <= 22)))
                {
                    zodiac = "Libra";
                }
                else if (((birthdayMonth == (int)Month.Oct) && (birthdayDay >= 23 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.Nov) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Scorpio";
                }
                else if (((birthdayMonth == (int)Month.Nov) && (birthdayDay >= 22 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.Dec) && (birthdayDay >= 01 || birthdayDay <= 21)))
                {
                    zodiac = "Sagittarius";
                }
                else if (((birthdayMonth == (int)Month.Dec) && (birthdayDay >= 22 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.Jan) && (birthdayDay >= 01 || birthdayDay <= 20)))
                {
                    zodiac = "Capricorn";
                }
                else if (((birthdayMonth == (int)Month.Jan) && (birthdayDay >= 21 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.Feb) && (birthdayDay >= 01 || birthdayDay <= 19)))
                {
                    zodiac = "Aquarius";
                }
                else if (((birthdayMonth == (int)Month.Feb) && (birthdayDay >= 20 || birthdayDay <= 31)) || ((birthdayMonth == (int)Month.Mar) && (birthdayDay >= 01 || birthdayDay <= 20)))
                {
                    zodiac = "Pisces";
                }

                return zodiac;
            }
        }

        public AstrologyHoroscope()
        {
            r_Zodiac = new Zodiac();
        }

        public async Task<string> CreatePost(string i_userBirthDate)
        {
            string apiUri = await GetUriByBirthday(i_userBirthDate);
            JObject json = await GetJsonFromApi(apiUri);
            var astrologyHoroscope = json.SelectToken("$.description");

            return astrologyHoroscope?.ToString();
        }

        private async Task<JObject> GetJsonFromApi(string i_uri)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri(i_uri),
                Headers =
                   {
                       { "X-RapidAPI-Key", "9767aa43d4msh47ffc328d7f4776p1a40d0jsnedca44471bf6" },
                       { "X-RapidAPI-Host", "sameer-kumar-aztro-v1.p.rapidapi.com" },
                   },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(body);

                return json;
            }
        }

        public async Task<string> GetUriByBirthday(string i_userBirthDate)
        {
            string zodiac = r_Zodiac.findZodiac(i_userBirthDate);
            string apiUri = $"https://sameer-kumar-aztro-v1.p.rapidapi.com/?sign={zodiac}&day=today";

            return apiUri;
        }
    }
}
