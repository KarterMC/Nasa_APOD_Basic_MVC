using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NasaApodClient.Models
{
    public class PicOfTheDay
    {
        [JsonProperty("date")]
        [Display(Name = "Date")]
        public string Date { get; set; }

        [JsonProperty("explanation")]
        [Display(Name = "Explanation")]
        public string Explanation { get; set; }

        [JsonProperty("hdurl")]
        [Display(Name = "HD Picture URL")]
        public string HdPicUrl { get; set; }

        [JsonProperty("media_type")]
        [Display(Name = "Media Type")]
        public string MediaType { get; set; }

        [JsonProperty("title")]
        [Display(Name = "Picture Title")]
        public string PicTitle { get; set; }

        [JsonProperty("url")]
        [Display(Name = "Normal Picture URL")]
        public string NormalPicUrl { get; set; }
    }
}
