﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.IO;
using Newtonsoft.Json;

namespace Euston_Leisure_Messaging
{
    /// <summary>
    /// Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        private Message message;
        private FormatMessage formatMessage;
        private static String[] isHashtag = new String[60];
        private static Dictionary<String, int> hashtags = new Dictionary<String, int>();

        public static string[] IsHashtag { get => isHashtag; set => isHashtag = value; }
        public static Dictionary<String,int> Hashtags { get => hashtags;}

        internal Test(FormatMessage f)
        {
            InitializeComponent();
            formatMessage = f;
            message = f.Message;

            //todo need to make a loop that will print all the abbreviations in this array
            textBlock.Text = GetAbriv(message.Body.text)[1];

            JSONHandler();
        }
        public void JSONHandler()
        {
            JObject text = new JObject(                
                new JProperty("ID", message.Type),
                //sender: new JProperty("sender", );
                //if (message.Type.Equals(Type.Email))
                // new JProperty("Subject, ")
                new JProperty("text", message.Body.text));

            File.WriteAllText(@"C:\Users\40203\text.json", text.ToString());
        }

        String[] GetAbriv(String[] text)
        {
            String[] strArray = new String[text.Length];
            Dictionary<String, String> dict = new Dictionary<string, string>();
            var strLines = File.ReadLines(@"C:\Users\40203\textwords.csv");
            int index = 0;
            var wordsInText = formatMessage.FormatBody(text, 1).Split(' ');

            foreach (var line in strLines)
            {
                dict.Add(line.Split(',')[0], line.Split(',')[1]);
            }

            foreach (var searchKey in wordsInText)
            {
                if (dict.ContainsKey(searchKey))
                {
                    var myKey = dict.FirstOrDefault(x => x.Key == searchKey);

                    Console.WriteLine(myKey.Value);
                    strArray[index] = myKey.Key + " <" + myKey.Value + "> ";
                }
                index++;
                continue;
            }

            return strArray;
        }

        string TextOut()
        {
            string text;
            if (message.Type.Equals(Type.Tweet))
            {
                
            }
            return "";
        }
    }
}
