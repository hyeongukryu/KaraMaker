using System;
using System.Collections.Generic;
using System.IO;
using System.Json;
using Autofac;

namespace KaraMakerTools
{
    internal class SheetProcessor
    {
        private IContainer Container { get; set; }

        private void BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<Config>().As<IConfig>().SingleInstance();
            builder.RegisterType<SheetFetcher>().As<ISheetFetcher>();

            Container = builder.Build();
        }

        public void Run()
        {
            BuildContainer();

            var config = Container.Resolve<IConfig>();
            Console.WriteLine(config.GoogleSheetsKey);
            var fetcher = Container.Resolve<ISheetFetcher>();

            var result = new List<KeyValuePair<string, JsonValue>>();

            foreach (var (name, key) in config.SheetNameAndKeyTuples)
            {
                Console.WriteLine(name + " 시도");
                var json = fetcher.GetSheetJson(name);
                result.Add(new KeyValuePair<string, JsonValue>(key, json));
                Console.WriteLine(json);
                Console.WriteLine(name + " 성공");
            }

            var jsonObject = new JsonObject
            {
                { "packs", new JsonObject(result) },
                { "version", "1.0.0"  }
            };
            var jsonString = jsonObject.ToString();
            var ciphertext = StringCipher.Encrypt(jsonString, config.CipherKey);
            File.WriteAllText("data.json", ciphertext);
            Console.WriteLine("완료");
        }
    }
}
