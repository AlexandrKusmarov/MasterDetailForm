using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MasterDetailForm
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Currencies : ContentPage
    {
        public Currencies()
        {
            InitializeComponent();
        }

        private void getUSD(object sender, EventArgs e)
        {
            ButtonUSD.Text = String.Format("1 - USD = {0} RUB", getValueByCharCode("USD"));
        }

        private void getEUR(object sender, EventArgs k)
        {
            ButtonEUR.Text = String.Format("1 - EUR = {0} RUB", getValueByCharCode("EUR"));
        }

        private void getBYN(object sender, EventArgs k)
        {
            ButtonBYN.Text = String.Format("1 - BYN = {0} RUB", getValueByCharCode("BYN"));
        }

        private void getTRY(object sender, EventArgs k)
        {
            ButtonTRY.Text = String.Format("1 - TRY = {0} RUB", getValueByCharCode("TRY"));
        }

        private void getCHF(object sender, EventArgs k)
        {
            ButtonCHF.Text = String.Format("1 - CHF = {0} RUB", getValueByCharCode("CHF"));
        }

        private void getAUD(object sender, EventArgs k)
        {
            ButtonAUD.Text = String.Format("1 - AUD = {0} RUB", getValueByCharCode("AUD"));
        }

        private String getValueByCharCode(String charcode)
        {
            String value = "";
            foreach (KeyValuePair<string, string> kvp in MainPage.currencies)
            {
                if (kvp.Key == charcode)
                {
                    value = kvp.Value.ToString();
                    break;
                }
            }
            return value;
        }

        public Dictionary<String, String> parseCurrency()
        {
            XmlTextReader reader = new XmlTextReader("http://www.cbr.ru/scripts/XML_daily.asp");
            string USDXml = "";
            string EuroXML = "";
            Dictionary<String, String> currencyValues = new Dictionary<string, string>();
            String pattern = "<Value>[0-9]+.?[0-9]+";

            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:

                        if (reader.Name == "Valute")
                        {
                            if (reader.HasAttributes)
                            {
                                while (reader.MoveToNextAttribute())
                                {
                                    if (reader.Name == "ID")
                                    {
                                        if (reader.Value == "R01235")
                                        {
                                            reader.MoveToElement();
                                            USDXml = reader.ReadOuterXml();
                                            Match match = Regex.Match(USDXml, pattern);
                                            currencyValues.Add("USD", match.Groups[0].ToString().Substring(7));
                                        }
                                    }

                                    if (reader.Name == "ID")
                                    {
                                        if (reader.Value == "R01239")
                                        {
                                            reader.MoveToElement();
                                            EuroXML = reader.ReadOuterXml();
                                            Match match = Regex.Match(EuroXML, pattern);
                                            currencyValues.Add("EUR", match.Groups[0].ToString().Substring(7));
                                        }
                                    }
                                    if (reader.Name == "ID")
                                    {
                                        if (reader.Value == "R01090B")
                                        {
                                            reader.MoveToElement();
                                            EuroXML = reader.ReadOuterXml();
                                            Match match = Regex.Match(EuroXML, pattern);
                                            currencyValues.Add("BYN", match.Groups[0].ToString().Substring(7));
                                        }
                                    }
                                    if (reader.Name == "ID")
                                    {
                                        if (reader.Value == "R01700J")
                                        {
                                            reader.MoveToElement();
                                            EuroXML = reader.ReadOuterXml();
                                            Match match = Regex.Match(EuroXML, pattern);
                                            currencyValues.Add("TRY", match.Groups[0].ToString().Substring(7));
                                        }
                                    }
                                    if (reader.Name == "ID")
                                    {
                                        if (reader.Value == "R01775")
                                        {
                                            reader.MoveToElement();
                                            EuroXML = reader.ReadOuterXml();
                                            Match match = Regex.Match(EuroXML, pattern);
                                            currencyValues.Add("CHF", match.Groups[0].ToString().Substring(7));
                                        }
                                    }
                                    if (reader.Name == "ID")
                                    {
                                        if (reader.Value == "R01010")
                                        {
                                            reader.MoveToElement();
                                            EuroXML = reader.ReadOuterXml();
                                            Match match = Regex.Match(EuroXML, pattern);
                                            currencyValues.Add("AUD", match.Groups[0].ToString().Substring(7));
                                        }
                                    }
                                }
                            }
                        }
                        break;
                }
            }
            return currencyValues;
        }

    }
}