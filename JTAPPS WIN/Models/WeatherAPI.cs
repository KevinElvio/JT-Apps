using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace JTAPPS_WIN.Models
{
    internal class WeatherAPI
    {
        public bool ReadWeather(WeatherAPIContext weatherAPIContext, PictureBox iconcuaca, Label temperatur, Label serasa)
        {
            {
                bool isSucces = false;
                using (WebClient web = new WebClient())
                {
                    string url = string.Format("https://api.openweathermap.org/data/2.5/weather?q=Jember&appid=6dca9b25f0bf705eafbbf018e667fd3a");
                    var json = web.DownloadString(url);
                    WeatherAPIContext.root info = JsonConvert.DeserializeObject<WeatherAPIContext.root>(json);
                    double tempKelvin = info.main.temp;
                    double tempCelsius = tempKelvin - 273.15;
                    int temp = (int)Math.Round(tempCelsius);
                    iconcuaca.ImageLocation = "https://openweathermap.org/img/w/" + info.weather[0].icon + ".png";
                    temperatur.Text = temp.ToString("0.##" + "°C");
                    serasa.Text = temp.ToString("Terasa seperti 0.##");
                }
                return isSucces;
            }
        }
    }
}
