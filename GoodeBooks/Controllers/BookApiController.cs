using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Models.Entities.APIEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GoodeBooks.Controllers
{
    [ApiController]
    [Route("api/books")]
    [Authorize(Roles = "Admin")]
    public class BookApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly HttpClient _httpClient;
        private readonly BookstoreDbContext context;

        public BookApiController(IHttpClientFactory httpClientFactory, BookstoreDbContext context)
        {
            _httpClient = httpClientFactory.CreateClient();
            this.context = context;
        }

        [HttpGet("{count}")]
        public async Task<IActionResult> GetBooks(int count)
        {
            var apiKey = "AIzaSyBqS2mVmBj7KmfsWE_1w8qdEsSrGdHegbc";
            var max = 40;
            var url = $"https://www.googleapis.com/books/v1/volumes?q=classic&maxResults={max}&key={apiKey}";

            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var googleBooks = JsonSerializer.Deserialize<GoogleBooksResponse>(json, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                var books = new List<Volume>();

                foreach (var googleBook in googleBooks.Items)
                {
                    if (googleBook.VolumeInfo.Authors == null)
                        continue;
                    if(googleBook.SearchInfo == null)
                    {
                        googleBook.SearchInfo = new SearchInfo { TextSnippet = "No information" };
                    }
                    if (googleBook.VolumeInfo.Title == null)
                        googleBook.VolumeInfo.Title = "No title";
                    if (googleBook.VolumeInfo.Subtitle == null)
                        googleBook.VolumeInfo.Subtitle = "A book";
                    if (googleBook.VolumeInfo.PublishedDate == null)
                        googleBook.VolumeInfo.PublishedDate = "0001-01-01 00:00:00.0000000";
                    if (googleBook.VolumeInfo.Description == null)
                        googleBook.VolumeInfo.Description = "A book";
                    if (googleBook.VolumeInfo.PageCount == null)
                        googleBook.VolumeInfo.PageCount = 0;
                    if (googleBook.VolumeInfo.Language == null)
                        googleBook.VolumeInfo.Language = "Not specified";
                    if (googleBook.VolumeInfo.ImageLinks == null)
                        googleBook.VolumeInfo.ImageLinks = new GoogleImageLinks()
                        {
                            SmallThumbnail = "https://upload.wikimedia.org/wikipedia/commons/1/14/No_Image_Available.jpg?20200913095930"
                        };

                    var book = new Volume
                    {
                        Kind = googleBook.Kind,
                        Etag = googleBook.Etag,
                        VolumeInfo = new VolumeInfo
                        {
                            Id = Guid.NewGuid().ToString(),
                            Title = googleBook.VolumeInfo.Title,
                            Subtitle = googleBook.VolumeInfo.Subtitle,
                            Authors = googleBook.VolumeInfo.Authors.Select(authorName => new Author { Name = authorName }).ToList(),
                            PublishedDate = Convert.ToDateTime(googleBook.VolumeInfo.PublishedDate),
                            Description = googleBook.VolumeInfo.Description,
                            PageCount = googleBook.VolumeInfo.PageCount,
                            Language = googleBook.VolumeInfo.Language,
                            ImageUrl = googleBook.VolumeInfo.ImageLinks.SmallThumbnail
                        },
                        SaleInfo = new SaleInfo
                        {
                            Country = googleBook.SaleInfo.Country,
                            IsEbook = googleBook.SaleInfo.IsEbook,
                            SaleAbility = googleBook.SaleInfo.SaleAbility,
                            Id = Guid.NewGuid().ToString()
                        },
                        SearchInfo = new SearchInfo { TextSnippet = googleBook.SearchInfo.TextSnippet, Id = Guid.NewGuid().ToString() }
                    };
                    if (context.Volumes.FirstOrDefault(x => x.VolumeInfo.Title == book.VolumeInfo.Title) != null)
                        continue;
                   
                    context.Volumes.Add(book);
                }


                await context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return NotFound();
            }
        }       
       
    }
}

