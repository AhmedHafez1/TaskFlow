using Microsoft.OpenApi.Models;

namespace TaskFlow.API.Extentions;

public static class OpenApiExtension
{
    public static IServiceCollection AddCustomizedOpenApi(this IServiceCollection services)
    {
        services.AddOpenApi(options =>
        {
            options.AddDocumentTransformer(
                (document, context, cancellationToken) =>
                {
                    document.Components ??= new();
                    document.Components.SecuritySchemes = new Dictionary<
                        string,
                        OpenApiSecurityScheme
                    >
                    {
                        ["Bearer"] = new OpenApiSecurityScheme
                        {
                            Description =
                                "JWT Authorization header using the Bearer scheme. Enter 'Bearer' [space] and then your token",
                            Name = "Authorization",
                            In = ParameterLocation.Header,
                            Type = SecuritySchemeType.Http,
                            Scheme = "bearer",
                            BearerFormat = "JWT",
                        },
                    };

                    document.SecurityRequirements = new List<OpenApiSecurityRequirement>
                    {
                        new OpenApiSecurityRequirement
                        {
                            {
                                new OpenApiSecurityScheme
                                {
                                    Reference = new OpenApiReference
                                    {
                                        Type = ReferenceType.SecurityScheme,
                                        Id = "Bearer",
                                    },
                                },
                                Array.Empty<string>()
                            },
                        },
                    };

                    return Task.CompletedTask;
                }
            );
        });

        return services;
    }
}
