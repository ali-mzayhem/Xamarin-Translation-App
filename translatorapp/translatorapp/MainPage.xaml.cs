using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace translatorapp
{
    public partial class MainPage : ContentPage
    {
        private static readonly string subscriptionKey = "b6e36e5b0f9e4a40874ad726ff297574";
        private static readonly string endpoint = "https://api.cognitive.microsofttranslator.com/";
        private static readonly string location = "eastasia";
        List<LanguageCode> languages = new List<LanguageCode>();
        List<string> categories = new List<string>();
        public MainPage()
        {
            InitializeComponent();

            fill();
            for (int i = 0; i < languages.Count; i++)
            {
                categories.Add(languages[i].getLanguage());
            }
            picker.ItemsSource = categories;
            picker2.ItemsSource = categories;

        }

        private async void Translate_Tapped(object sender, EventArgs e)
        {
            if(picker.SelectedIndex == -1) { picker.SelectedIndex = 0; }
            if (picker2.SelectedIndex == -1) { picker2.SelectedIndex = 0; }
            string l1 = languages[picker.SelectedIndex].getCode();
            string l2 = languages[picker2.SelectedIndex].getCode();
            ActivityIndicator indicator = new ActivityIndicator();
            indicator.IsVisible = true;
            indicator.IsRunning = true;
            stack1.Children.Add(indicator);
            TargetText.Text = await TranslateText(SourceText.Text,l1,l2);
            indicator.IsVisible = false;

        }
        static async Task<string> TranslateText(string textToTranslate,string l1,string l2)
        {
            
            string route = "/translate?api-version=3.0&from="+l1 +"&to="+l2;
            object[] body = new object[] { new { Text = textToTranslate } };
            var requestBody = JsonConvert.SerializeObject(body);
           using (var client = new HttpClient())
            using (var request = new HttpRequestMessage())
            {
                request.Method = HttpMethod.Post;
                request.RequestUri = new Uri(endpoint + route);
                request.Content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                request.Headers.Add("Ocp-Apim-Subscription-Key", subscriptionKey);
                request.Headers.Add("Ocp-Apim-Subscription-Region", location);
       HttpResponseMessage response = await client.SendAsync(request).ConfigureAwait(false);
                string responseBody = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<Dictionary<string, List<Dictionary<string, string>>>>>(responseBody);
                var translation = result[0]["translations"][0]["text"];
                return translation;
            }
           
        }
        public void fill()
        {
            LanguageCode l = new LanguageCode("English", "en");
            languages.Add(l);
            l = new LanguageCode("Arabic", "ar");
            languages.Add(l);
            l = new LanguageCode("Albanian", "sq");
            languages.Add(l);
            l = new LanguageCode("Armenian", "hy");
            languages.Add(l);
            l = new LanguageCode("Assamese", "as");
            languages.Add(l);
            l = new LanguageCode("Azerbaijani", "az");
            languages.Add(l);
            l = new LanguageCode("Bulgarian", "bg");
            languages.Add(l);
            l = new LanguageCode("Bangla", "bn");
            languages.Add(l);
            l = new LanguageCode("Bashkir", "ba");
            languages.Add(l);
            l = new LanguageCode("Basque", "eu");
            languages.Add(l);
            l = new LanguageCode("Bosnian", "bs");
            languages.Add(l);
            l = new LanguageCode("Czech", "cs");
            languages.Add(l);
            l = new LanguageCode("Chinese", "lzh");
            languages.Add(l);
            l = new LanguageCode("Croatian", "hr");
            languages.Add(l);
            l = new LanguageCode("Catalan", "ca");
            languages.Add(l);
            l = new LanguageCode("Dutch", "nl");
            languages.Add(l);
            l = new LanguageCode("Danish", "da");
            languages.Add(l);
            l = new LanguageCode("Dari", "prs");
            languages.Add(l);
            l = new LanguageCode("Estonian	", "et");
            languages.Add(l);
            l = new LanguageCode("Filipino	", "fil");
            languages.Add(l);
            l = new LanguageCode("Finnish	", "fi");
            languages.Add(l);
            l = new LanguageCode("French", "fr");
            languages.Add(l);
            l = new LanguageCode("Faroese", "fo");
            languages.Add(l);
            l = new LanguageCode("German", "de");
            languages.Add(l);
            l = new LanguageCode("Georgian	", "ka");
            languages.Add(l);
            l = new LanguageCode("Greek	", "el");
            languages.Add(l);
            l = new LanguageCode("Galician	", "gl");
            languages.Add(l);
            l = new LanguageCode("Gujarati	", "gu");
            languages.Add(l);
            l = new LanguageCode("Hindi", "hi");
            languages.Add(l);
            l = new LanguageCode("Hebrew", "he");
            languages.Add(l);
            l = new LanguageCode("Hungarian", "hu");
            languages.Add(l);
            l = new LanguageCode("Indonesian", "id");
            languages.Add(l);
            l = new LanguageCode("Italian", "it");
            languages.Add(l);
            l = new LanguageCode("Inuktitut", "iu");
            languages.Add(l);
            l = new LanguageCode("Irish", "ga");
            languages.Add(l);
            l = new LanguageCode("Japanese", "ja");
            languages.Add(l);
            l = new LanguageCode("Kazakh", "kk");
            languages.Add(l);
            l = new LanguageCode("Khmer", "km");
            languages.Add(l);
            l = new LanguageCode("Korean", "ko");
            languages.Add(l);
            l = new LanguageCode("Kurdish", "ku");
            languages.Add(l);
            l = new LanguageCode("Klingon", "tlh-Latn");
            languages.Add(l);
            l = new LanguageCode("Lao", "lo");
            languages.Add(l);
            l = new LanguageCode("Lativian", "lv");
            languages.Add(l);
            l = new LanguageCode("Lithuanian", "lt");
            languages.Add(l);
            l = new LanguageCode("Maltese", "mt");
            languages.Add(l);
            l = new LanguageCode("Macedonian", "mk");
            languages.Add(l);
            l = new LanguageCode("Malagasy", "mg");
            languages.Add(l);
            l = new LanguageCode("Maori", "mi");
            languages.Add(l);
            l = new LanguageCode("Marathi", "mr");
            languages.Add(l);
            l = new LanguageCode("Myanmar", "my");
            languages.Add(l);
            l = new LanguageCode("Norwegian", "nb");
            languages.Add(l);
            l = new LanguageCode("Nepali", "ne");
            languages.Add(l);
            l = new LanguageCode("Odia", "or");
            languages.Add(l);
            l = new LanguageCode("Persian", "fa");
            languages.Add(l);
            l = new LanguageCode("Portuguese", "pt-pt");
            languages.Add(l);
            l = new LanguageCode("Polish", "pl");
            languages.Add(l);
            l = new LanguageCode("Punjabi", "pa");
            languages.Add(l);
            l = new LanguageCode("Russian", "ru");
            languages.Add(l);
            l = new LanguageCode("Romanian", "ro");
            languages.Add(l);
            l = new LanguageCode("Swedish", "sv");
            languages.Add(l);
           l = new LanguageCode("Spanish", "es");
            languages.Add(l);
            l = new LanguageCode("Slovak", "sk");
            languages.Add(l);
            l = new LanguageCode("Tamil", "ta");
            languages.Add(l);
            l = new LanguageCode("Telugu", "te");
            languages.Add(l);
            l = new LanguageCode("Thai", "th");
            languages.Add(l);
            l = new LanguageCode("Tibetan", "bo");
            languages.Add(l);
            l = new LanguageCode("Turkish", "tr");
            languages.Add(l);
            l = new LanguageCode("Turkmen", "tk");
            languages.Add(l);
            l = new LanguageCode("Ukranian", "uk");
            languages.Add(l);
            l = new LanguageCode("Urdu", "ur");
            languages.Add(l);
            l = new LanguageCode("Uzbek", "uz");
            languages.Add(l);
            l = new LanguageCode("Vietnamese", "vi");
            languages.Add(l);
            l = new LanguageCode("Welsh", "cy");
            languages.Add(l);
            l = new LanguageCode("Zulu", "zu");
            languages.Add(l);

        }

    }
}


