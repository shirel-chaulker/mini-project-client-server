using System;
using System.IO;
using ProductServer.Model;
using ProductServer.Entities;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace ProductSever.Azure1
{
    public static class Function1
    {
        [FunctionName("Products")]
        public static async Task<IActionResult> Run(
               [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", "delete", "put", Route = "Products/{action?}/{productID?}")] HttpRequest req, string action, string productID,
               ILogger log)
        {
            switch (action)
            {

                case "allProducts":

                    log.LogInformation("C# HTTP trigger function processed a request.");
                    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                    UserComment userComment = System.Text.Json.JsonSerializer.Deserialize<UserComment>(requestBody);
                    if (userComment.FirstName != null && userComment.LastName != null && userComment.Username != null && userComment.ContactUsInput != null && userComment.EmailAddress != null)
                    {
                        MainManager.INSTANCE.pustUsersComment(userComment);

                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");

                    break;

                case null:
                    log.LogInformation("C# HTTP trigger function processed a request.");
                    string requestBody1 = await new StreamReader(req.Body).ReadToEndAsync();
                    JsonConvert.DeserializeObject(requestBody1);

                    List<Product> productList = MainManager.INSTANCE.Init();
                    string responseMessage = System.Text.Json.JsonSerializer.Serialize(productList);

                    return new OkObjectResult(responseMessage);
                    break;



                case "deleteProduct":

                    log.LogInformation("C# HTTP trigger function processed a request.");

                    if (!(productID == null))
                    {

                        MainManager.INSTANCE.ProductsRemove(productID);

                        return new OkObjectResult("The operation was successful");
                    }

                    return new OkObjectResult("The operation failed");
                    break;


                case "UpdateProduct":

                    log.LogInformation("C# HTTP trigger function processed a request.");


                    string requestBody3 = await new StreamReader(req.Body).ReadToEndAsync();


                    ProductTemp product = System.Text.Json.JsonSerializer.Deserialize<ProductTemp>(requestBody3);


                    if (product.ProductID != 0 && product.UnitPrice != null && product.ProductName != null && product.UnitInStock != null)
                    {
                        MainManager.INSTANCE.ProductsUpdate(product);

                        return new OkObjectResult("The operation was successful");
                    }
                    return new OkObjectResult("The operation failed");
            }
            return null; ;
        }
    }
}
