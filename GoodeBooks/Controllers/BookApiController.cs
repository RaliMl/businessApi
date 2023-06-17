using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.Converter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using static GoodeBooks.Controllers.BookApiController;

namespace GoodeBooks.Controllers
{
    [ApiController]
    [Route("api/books")]
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
            //var apiKey = "AIzaSyBAvQuy5XzKNNoXefTJ-mv355w4uft9QVw";
            var apiKey = "AIzaSyBqS2mVmBj7KmfsWE_1w8qdEsSrGdHegbc";
            var max = 40;
            //var url = $"https://www.googleapis.com/books/v1/volumes?q=programming&maxResults={count}&key={apiKey}";
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
                        googleBook.VolumeInfo.PublishedDate = new DateTime();
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
                            PublishedDate = googleBook.VolumeInfo.PublishedDate,
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
                        // Map other properties as needed
                    };
                    if (context.Volumes.FirstOrDefault(x => x.VolumeInfo.Title == book.VolumeInfo.Title) != null)
                        continue;
                    //if (book.VolumeInfo.Subtitle == null)
                    //    book.VolumeInfo.Subtitle = "A book";
                    //if (book.VolumeInfo.Description == null)
                    //    book.VolumeInfo.Description = "A book";
                    //if (book.SearchInfo == null)
                    //{
                    //    book.SearchInfo.Id = Guid.NewGuid().ToString();
                    //    book.SearchInfo.TextSnippet = "No search info";
                    //}

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
        //public async Task<IActionResult> AddBookshelves()
        //{
        //    //var httpClient = _httpClient.CreateClient();
        //    var apiKey = "AIzaSyDTrkKLYH6SZ81n_1St-wj5Svyt_fMPxtg";
        //    var response = await _httpClient.GetAsync($"https://www.googleapis.com/books/v1/mylibrary/bookshelves?key={apiKey}");

        //    if (response.IsSuccessStatusCode)
        //    {
        //        var content = await response.Content.ReadAsStringAsync();
        //        var bookshelves = JsonSerializer.Deserialize<GoogleBookshelvesResponse>(content, new JsonSerializerOptions
        //        {
        //            PropertyNameCaseInsensitive = true
        //        });

        //        foreach (var item in bookshelves.Items)
        //        {
        //            var bookshelf = new Bookshelf
        //            {
        //                Id = item.Id,
        //                Kind = item.Kind,
        //                Title = item.Title,
        //                Updated = item.Updated,
        //                Created = item.Created,
        //                VolumeCount = item.VolumeCount
        //                // Set other properties as needed
        //            };

        //            var volumesResponse = await _httpClient.GetAsync($"https://www.googleapis.com/books/v1/mylibrary/bookshelves/{item.Id}/volumes");

        //            if (volumesResponse.IsSuccessStatusCode)
        //            {
        //                var volumesContent = await volumesResponse.Content.ReadAsStringAsync();
        //                var volumes = JsonSerializer.Deserialize<GoogleBooksResponse>(volumesContent);

        //                foreach (var googleBook in volumes.Items)
        //                {
        //                    if (googleBook.SearchInfo == null)
        //                    {
        //                        continue;
        //                    }
        //                    var book = new Volume
        //                    {
        //                        Kind = googleBook.Kind,
        //                        Etag = googleBook.Etag,
        //                        VolumeInfo = new VolumeInfo
        //                        {
        //                            Id = Guid.NewGuid().ToString(),
        //                            Title = googleBook.VolumeInfo.Title,
        //                            Subtitle = googleBook.VolumeInfo.Subtitle,
        //                            Authors = googleBook.VolumeInfo.Authors.Select(authorName => new Author { Name = authorName }).ToList(),
        //                            PublishedDate = googleBook.VolumeInfo.PublishedDate,
        //                            Description = googleBook.VolumeInfo.Description,
        //                            PageCount = googleBook.VolumeInfo.PageCount,
        //                            Language = googleBook.VolumeInfo.Language
        //                        },
        //                        SaleInfo = new SaleInfo
        //                        {
        //                            Country = googleBook.SaleInfo.Country,
        //                            IsEbook = googleBook.SaleInfo.IsEbook,
        //                            SaleAbility = googleBook.SaleInfo.SaleAbility,
        //                            Id = Guid.NewGuid().ToString()
        //                        },
        //                        SearchInfo = new SearchInfo { TextSnippet = googleBook.SearchInfo.TextSnippet, Id = Guid.NewGuid().ToString() }
        //                        // Map other properties as needed
        //                    };
        //                    if (book.VolumeInfo.Subtitle == null)
        //                        book.VolumeInfo.Subtitle = "A book";
        //                }
        //            }
        //        }
        //        await context.SaveChangesAsync();
        //        return Ok("Bookshelves added.");
        //    }

        //    return StatusCode((int)response.StatusCode);
        //}

        // Define the model classes based on the response structure of the Google Books API
        public class GoogleBooksResponse
        {
            public int TotalItems { get; set; }
            public List<GoogleBook> Items { get; set; }
        }

        public class GoogleBook
        {
            public string Kind { get; set; }
            public string Etag { get; set; }
            public virtual GoogleVolumeInfo VolumeInfo { get; set; }
            public virtual SaleInfo SaleInfo { get; set; }
            public virtual SearchInfo SearchInfo { get; set; }
        }

        public class GoogleVolumeInfo
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string Subtitle { get; set; }
            public virtual ICollection<string> Authors { get; set; }
            [JsonConverter(typeof(DateConverter))]
            public DateTime PublishedDate { get; set; }
            public string Description { get; set; }
            public int PageCount { get; set; }
            public string Language { get; set; }
            public GoogleImageLinks ImageLinks { get; set; }
        }

        public class GoogleImageLinks
        {
            public string SmallThumbnail { get; set; }
        }


        //public class GoogleBookshelvesResponse
        //{
        //    public List<GoogleBookshelf> Items { get; set; }
        //}

        //public class GoogleBookshelf
        //{
        //    public string Kind { get; set; }
        //    public long Id { get; set; }
        //    public string Title { get; set; }
        //    [JsonConverter(typeof(DateConverter))]
        //    public DateTime Updated { get; set; }
        //    [JsonConverter(typeof(DateConverter))]
        //    public DateTime Created { get; set; }
        //    public int VolumeCount { get; set; }
        //}
    }
}

