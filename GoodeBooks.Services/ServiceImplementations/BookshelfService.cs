using AutoMapper;
using GoodeBooks.Database;
using GoodeBooks.Models.Entities;
using GoodeBooks.Services.ServiceContracts.Bookshelves;
using GoodeBooks.Services.ViewModels.Bookshelves;
using GoodeBooks.Services.ViewModels.SaleInfos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public int Create(BookshelfCreateViewModel model, string userId)
        {
            try
            {
                var bookshelf = mapper.Map<Bookshelf>(model);
                var volumeNames = model.VolumeNames.Split(',').ToList();
                bookshelf.Volumes = context.Volumes.Where(x => volumeNames.Contains(x.VolumeInfo.Title)).ToList();
                bookshelf.Created = DateTime.Now;
                bookshelf.Updated = DateTime.Now;
                bookshelf.VolumeCount = bookshelf.Volumes.Count;

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

        public ICollection<BookshelfViewModel> GetAll()
        {
            try { return mapper.Map<List<BookshelfViewModel>>(context.Bookshelves); }
            catch (Exception ex) { throw new Exception("Not found!"); }
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
                    var volumeTitles = model.VolumeTitles.Split(',').ToList();
                    bookshelf.Volumes = context.Volumes.Where(x =>volumeTitles.Contains(x.VolumeInfo.Title)).ToList();
                    bookshelf.Title = model.Title;
                    bookshelf.Updated = DateTime.Now;
                    bookshelf.Title = model.Title;
                    bookshelf.VolumeCount = model.VolumeCount;

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
