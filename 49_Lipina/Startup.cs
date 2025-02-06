using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _49_Lipina
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� ��������, ����������� � �������"
                });
                c.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� ��������, ����������� � �������"
                });
                c.SwaggerDoc("v3", new OpenApiInfo
                {
                    Version = "v3",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� ��������, ����������� � �������"
                });
                c.SwaggerDoc("v4", new OpenApiInfo
                {
                    Version = "v4",
                    Title = "����������� ��� ������������� ��������",
                    Description = "������ ����������� ��� ������������� ��������, ����������� � �������"
                });
                var filePath = Path.Combine(System.AppContext.BaseDirectory, "pr49-RestApi_Lipina.xml");
                c.IncludeXmlComments(filePath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "����������� � ����������� ������������");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "������ ������");
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "������ ����");
                c.SwaggerEndpoint("/swagger/v4/swagger.json", "�������� ������ � ��������� �������");
            });
        }
    }
}
    