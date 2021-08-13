using Catalog.API.Entities;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.API.Data
{
    public class CatalogContextSeed
    {
        public static void SeedData(IMongoCollection<Product> productCollection)
        {
            bool existProduct = productCollection.Find(p => true).Any();

            if (!existProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product()
                {
                    ID = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Summery = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Stock=5,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    ID = "602d2149e773f2a3990b47f6",
                    Name = "Samsung 10",
                    Summery = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-2.png",
                    Price = 840.00M,
                    Stock=1,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    ID = "602d2149e773f2a3990b47f7",
                    Name = "Huawei Plus",
                    Summery = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-3.png",
                    Price = 650.00M,
                    Stock=2,
                    Category = "White Appliances"
                },
                new Product()
                {
                    ID = "602d2149e773f2a3990b47f8",
                    Name = "Xiaomi Mi 9",
                    Summery = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-4.png",
                    Price = 470.00M,
                    Stock=0,
                    Category = "White Appliances"
                },
                new Product()
                {
                    ID = "602d2149e773f2a3990b47f9",
                    Name = "HTC U11+ Plus",
                    Summery = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-5.png",
                    Price = 380.00M,
                    Stock=7,
                    Category = "Smart Phone"
                },
                new Product()
                {
                    ID = "602d2149e773f2a3990b47fa",
                    Name = "LG G7 ThinQ",
                    Summery = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-6.png",
                    Price = 240.00M,
                    Stock=5,
                    Category = "Home Kitchen"
                },
                new Product()
                {
                    ID = "61124adc2555ff504aed8fef",
                    Name = "Asus Laptop (Core i5 7th Gen/8 GB/1 TB/Windows 10/2 GB) - R558UQ-DM1286T",
                    Summery = "DISPLAY 15.6\" (39.62 cm) display, 1366 x 768 px STORAGE 1 TB HDD PROCESSOR Intel Core i5 (7th Gen) Processor RAM 8 GB DDR3 RAM",
                    Description = "Asus R558UQ-DM1286T Laptop (Core i5 7th Gen/8 GB/1 TB/Windows 10/2 GB) laptop has a 15.6 Inches (39.62 cm) display for your daily needs. This laptop is powered by Intel Core i5-7200U (7th Gen) processor, coupled with 8 GB of RAM and has 1 TB HDD storage at this price point.",
                    ImageFile = "product-7.png",
                    Price = 47500M,
                    Stock=8,
                    Category = "Laptop"
                },
                new Product()
                {
                    ID = "61124af82555ff504aed8ff0",
                    Name = "LENOVO Pro Yoga C940 14” 2 in 1 laptops",
                    Summery = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Premium 10th Gen Intel® Core™ processors Enjoy vibrant visuals on a 14\" UHD touchscreen display—perfect for everything from spreadsheets to movies Thin & light laptop allowing you to work & have fun from anywhere Redesigned rotating soundbar & 2 additional speakers provide crystal clear sound and reduce unwanted noise",                   
                    ImageFile = "product-8.png",
                    Price = 1399.99M,
                    Stock=1,
                    Category = "Laptop"
                },
                new Product()
                {
                    ID = "61124b0f2555ff504aed8ff1",
                    Name = "Dell Inspiron 15 3000",
                    Summery = "Dell Inspiron 15 3000 is a Windows 10 laptop with a 15.60-inch display that has a resolution of 1920x1080 pixels. It is powered by a Core i3 processor and it comes with 8GB of RAM. The Dell Inspiron 15 3000 packs 256GB of HDD storage.",
                    Description = "Dell Inspiron 15 3000 is a Windows 10 laptop with a 15.60-inch display that has a resolution of 1920x1080 pixels. It is powered by a Core i3 processor and it comes with 8GB of RAM. The Dell Inspiron 15 3000 packs 256GB of HDD storage. Graphics are powered by Intel Integrated HD Graphics 520. Connectivity options include Wi-Fi 802.11 ac, Bluetooth, Ethernet and it comes with 3 USB ports (1 x USB 2.0, 2 x USB 3.0), Mic In, RJ45 (LAN) ports. As of 10th August 2021, Dell Inspiron 15 3000 price in India starts at Rs. 30,602.",
                    ImageFile = "product-9.png",
                    Price = 153000M,
                    Stock=1,
                    Category = "Laptop"
                }
            };
        }
    }
}
