using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace ProJur.Cadastros.API.Configuration
{
	public static class SwaggerConfig
	{
		public static void AppSwaggerConfiguration(this IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Title = "ProJur - Usuario API",
					Description = "Esta API faz parte do desafio ProJur.",
					Contact = new OpenApiContact() { Name = "Phillipe", Email = "phillrog@hotmail.com" },
					License = new OpenApiLicense() { Name = "MIT", Url = new Uri("https://opensource.org/licenses/MIT") }
				});
				c.IncludeXmlComments(XmlCommentsFilePath);
			});
		}

		public static void UseSwaggerConfiguration(this IApplicationBuilder app)
		{
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("v1/swagger.json", "v1");
				c.DefaultModelsExpandDepth(-1);
				c.DocExpansion(DocExpansion.None);
			});
		}

		public static string XmlCommentsFilePath
		{
			get
			{
				var basePath = PlatformServices.Default.Application.ApplicationBasePath;
				var fileName = typeof(Startup).GetTypeInfo().Assembly.GetName().Name + ".xml";
				return Path.Combine(basePath, fileName);
			}
		}
	}
}
