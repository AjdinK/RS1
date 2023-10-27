using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

public class AutorizacijaSwaggerHeader : IOperationFilter
{
    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    {
        operation.Parameters.Add(new OpenApiParameter{
            Name = "",
            In = ParameterLocation.Header,
            Description = "Upisati preuzeti token iz headersa"
        });
    }
}