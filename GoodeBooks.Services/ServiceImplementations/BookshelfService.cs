using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.Bookshelves;
using GoodeBooks.Services.ViewModels.Bookshelves;
using GoodeBooks.Services.ViewModels.Volumes;

namespace GoodeBooks.Services.ServiceImplementations
{
    public class BookshelfService : IBookshelfService
    {
        private readonly BookstoreDbContext context;

        private readonly IMapper mapper;
        public BookshelfService(BookstoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public ICollection<BookshelfViewModel> Search(string searchTerm)
        {
            var bookshelves = context.Bookshelves.Where(x => x.Title.Contains(searchTerm)).ToList();

            if (bookshelves != null)
            {
                var res = mapper.Map<List<BookshelfViewModel>>(bookshelves);

                for (int i = 0; i < res.Count; i++)
                {
                    res[i].VolumeTitles = string.Join(",", context.Volumes.Where(x => bookshelves[i].Volumes.Select(v => v.Id).Contains(x.Id))
                    .Select(s => s.VolumeInfo.Title));
                }
                return res;
            }
            return null;
        }
        public int Create(BookshelfCreateViewModel model, string userId)
        {
            try
            {
                var bookshelf = mapper.Map<Bookshelf>(model);

                if (model.VolumeNames != null)
                {
                    var volumeNames = model.VolumeNames.Split(',').ToList();
                    bookshelf.Volumes = context.Volumes.Where(x => volumeNames.Contains(x.VolumeInfo.Title)).ToList();
                    bookshelf.VolumeCount = bookshelf.Volumes.Count;
                }
                else
                {
                    bookshelf.Volumes = null;
                    bookshelf.VolumeCount = 0;
                }
                    bookshelf.Created = DateTime.Now;
                bookshelf.Updated = DateTime.Now;
                

                context.Bookshelves.Add(bookshelf);

                if (context.Roles.FirstOrDefault(x => x.Id == context.UserRoles.FirstOrDefault(x => x.UserId == userId).RoleId).Name
                    == "User")
                {
                    var user = context.Users.FirstOrDefault(x => x.Id == userId);
                    user.Bookshelves.Add(bookshelf);

                    context.Users.Update(user);
                }

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public int Delete(long id)
        {
            try
            {
                context.Bookshelves.Remove(context.Bookshelves.FirstOrDefault(e => e.Id == id));

                context.SaveChanges();

                return 1;
            }
            catch (Exception ex) { return -1; }
        }

        public ICollection<BookshelfViewModel> GetAll(string userId)
        {
            try 
            {
                var bookshelves = context.Users.FirstOrDefault(x => x.Id == userId).Bookshelves.ToList();
                var res = mapper.Map<List<BookshelfViewModel>>(bookshelves);

                for(int i = 0; i < res.Count; i++)
                {
                    res[i].VolumeTitles = string.Join(",", context.Volumes.Where(x => bookshelves[i].Volumes.Select(v => v.Id).Contains(x.Id))
                    .Select(s => s.VolumeInfo.Title));
                }
                return res;
            }
            catch (Exception ex) { throw new Exception("Not found!"); }
        }

        public ICollection<BookshelfViewModel> GetAll()
        {

            try
            {
                var bookshelves = context.Bookshelves.ToList();
                var res = mapper.Map<List<BookshelfViewModel>>(bookshelves);

                for (int i = 0; i < res.Count; i++)
                {
                    res[i].VolumeTitles = string.Join(",", context.Volumes.Where(x => bookshelves[i].Volumes.Select(v => v.Id).Contains(x.Id))
                    .Select(s => s.VolumeInfo.Title));
                }
                return res;
            }
            catch(Exception ex) { throw new Exception("Not found!"); }
        }

        public BookshelfViewModel GetById(long id)
        {
            try
            {
                var bookshelf = context.Bookshelves.FirstOrDefault(x => x.Id == id);


                var res = mapper.Map<BookshelfViewModel>(bookshelf);
                res.VolumeTitles = string.Join(",", context.Volumes.Where(x => bookshelf.Volumes.Select(v => v.Id).Contains(x.Id))
                    .Select(s => s.VolumeInfo.Title));

                return res;
            }
            catch (Exception ex) { throw new Exception("Not found!"); }
        }

        public int Update(BookshelfViewModel model)
        {
            try
            {
                var bookshelf = context.Bookshelves.FirstOrDefault(x => x.Id == model.Id);

                if (bookshelf != null)
                {

                    if (model.VolumeTitles != null)
                    {
                        List<string>? volumeTitles = model.VolumeTitles.Split(',').ToList();
                        bookshelf.Volumes.Add(context.Volumes.FirstOrDefault(x => volumeTitles.Contains(x.VolumeInfo.Title)));
                    }
                    else
                        bookshelf.Volumes = new List<Volume>();
                    bookshelf.Title = model.Title;
                    bookshelf.Updated = DateTime.Now;
                    bookshelf.Title = model.Title;
                    bookshelf.VolumeCount = bookshelf.Volumes.Count();

                    context.Bookshelves.Update(bookshelf);

                    context.SaveChanges();

                    return 1;
                }
                return -1;
            }
            catch (Exception ex) { return -1; }
        }
    }
}
