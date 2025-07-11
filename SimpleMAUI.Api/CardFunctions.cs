using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SimpleMAUI.BLL.DTOs.In;
using SimpleMAUI.BLL.Helper;
using SimpleMAUI.BLL.Managers;

namespace SimpleMAUI.Api;

public class CardFunctions
{
    private readonly ILogger<CardFunctions> _logger;
    private readonly CardManager _cardManager;

    public CardFunctions(ILogger<CardFunctions> logger, SimpleMAUIDbContext context, IMapper mapper)
    {
        _logger = logger;
        _cardManager = new CardManager(context, mapper);
    }

    [Function("AddCard")]
    public async Task<IActionResult> RunAsync([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "cards")] HttpRequest req)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        CardInDto? card = JsonConvert.DeserializeObject<CardInDto>(requestBody);
        if (card == null)
        {
            return new BadRequestObjectResult("Invalid card data.");
        }
        await _cardManager.AddCardAsync(card);
        return new OkResult();
    }

    [Function("GetAllCards")]
    public async Task<IActionResult> GetAllCardsAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "cards")] HttpRequest req)
    {
        var cards = await _cardManager.GetAllCardsAsync();
        return new OkObjectResult(cards);
    }

    [Function("GetCardById")]
    public async Task<IActionResult> GetCardByIdAsync([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "cards/{id}")] HttpRequest req, Guid id)
    {
        var card = await _cardManager.GetCardByIdAsync(id);
        if (card == null)
        {
            return new NotFoundObjectResult($"Card with ID {id} not found.");
        }
        return new OkObjectResult(card);
    }

    [Function("UpdateCard")]
    public async Task<IActionResult> UpdateCardAsync([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "cards/{id}")] HttpRequest req, Guid id)
    {
        var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        CardInDto? card = JsonConvert.DeserializeObject<CardInDto>(requestBody);
        if (card == null)
        {
            return new BadRequestObjectResult("Invalid card data.");
        }
        try
        {
            await _cardManager.UpdateCardAsync(card, id);
            return new OkResult();
        }
        catch (KeyNotFoundException ex)
        {
            return new NotFoundObjectResult(ex.Message);
        }
    }

    [Function("DeleteCard")]
    public async Task<IActionResult> DeleteCardAsync([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "cards/{id}")] HttpRequest req, Guid id)
    {
        try
        {
            await _cardManager.DeleteCardAsync(id);
            return new OkResult();
        }
        catch (KeyNotFoundException ex)
        {
            return new NotFoundObjectResult(ex.Message);
        }
    }
}