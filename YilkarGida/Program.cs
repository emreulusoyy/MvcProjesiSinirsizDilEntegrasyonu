using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YilkarGida
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<Context>();
                context.Database.Migrate();

                var languageService = serviceProvider.GetRequiredService<ILanguageService>();
                if (!languageService.TGetList().Any())
                {
                    var language = new Language()
                    {
                        LanguageID = 1,
                        Code = "TR",
                        Status = false
                    };
                    languageService.TInsert(language);

                    var categoryService = serviceProvider.GetRequiredService<ICategoryService>();
                    var categoryLanguageItemService = serviceProvider.GetRequiredService<ICategoryLanguageItemService>();
                    if (!categoryService.TGetList().Any())
                    {
                        var category1 = new Category
                        {
                            Status = false,
                        };
                        categoryService.TInsert(category1);
                        categoryLanguageItemService.TInsert(new CategoryLanguageItem()
                        {
                            LanguageID = language.LanguageID,
                            CategoryID = category1.CategoryID,
                            Name = "Meyve"
                        });


                        var category2 = new Category
                        {
                            Status = false,
                        };
                        categoryService.TInsert(category2);
                        categoryLanguageItemService.TInsert(new CategoryLanguageItem()
                        {
                            LanguageID = language.LanguageID,
                            CategoryID = category2.CategoryID,
                            Name = "Sebze"
                        });

                        var category3 = new Category
                        {
                            Status = false,
                        };
                        categoryService.TInsert(category3);
                        categoryLanguageItemService.TInsert(new CategoryLanguageItem()
                        {
                            LanguageID = language.LanguageID,
                            CategoryID = category3.CategoryID,
                            Name = "Narenciye"
                        });

                        var category4 = new Category
                        {
                            Status = false,
                        };
                        categoryService.TInsert(category4);
                        categoryLanguageItemService.TInsert(new CategoryLanguageItem()
                        {
                            LanguageID = language.LanguageID,
                            CategoryID = category4.CategoryID,
                            Name = "Sarküteri"
                        });

                        var category5 = new Category
                        {
                            Status = false,
                        };
                        categoryService.TInsert(category5);
                        categoryLanguageItemService.TInsert(new CategoryLanguageItem()
                        {
                            LanguageID = language.LanguageID,
                            CategoryID = category5.CategoryID,
                            Name = "Dondurulmuş Gıda"
                        });
                    }
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}