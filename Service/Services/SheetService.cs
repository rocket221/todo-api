using Domain.Models;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using Service.Factories;
using Service.ModelExtensions;
using Service.Models;

namespace Service.Services
{
    public class SheetService : ISheetService
    {
        private readonly TodoContext _context;
        private readonly ISheetFactory _sheetFactory;

        public SheetService(TodoContext context, ISheetFactory sheetFactory)
        {
            _context = context;
            _sheetFactory = sheetFactory;
        }

        public OneOf<Sheet, NotFound> GetById(int sheetId, int userId)
        {
            var sheet =  _context.Sheets
                .Include(s => s.Items)
                .FirstOrDefault(s => s.Id == sheetId && s.UserId == userId);

            if (sheet == null)
            {
                return new NotFound();
            }

            return sheet;
        }

        public List<Sheet> GetAllSheets(int userId)
        {
            var sheets = _context.Sheets.Include(x => x.Items).Where(s => s.UserId == userId).ToList();
            return sheets;
        }

        public OneOf<Sheet> Create(int userId, CreateSheetModel createSheetModel)
        {
            var item = _sheetFactory.Create(createSheetModel, userId);

            var entity = _context.Sheets.Add(item);
            _context.SaveChanges();

            return entity.Entity;
        }

        public OneOf<Sheet, NotFound> Update(int sheetId, int userId, UpdateSheetModel sheet)
        {
            var entity = _context.Sheets.FirstOrDefault(s => s.Id == sheetId && s.UserId == userId);
            if (entity == null)
            {
                return new NotFound();
            }
            entity.Update(sheet);

            _context.SaveChanges();
            return entity;
        }

        public OneOf<Success, NotFound> Delete(int sheetId, int userId)
        {
            var sheet = _context.Sheets.FirstOrDefault(s => s.Id == sheetId && s.UserId == userId);
            if (sheet == null)
            {
                return new NotFound();
            }

            _context.Sheets.Remove(sheet);
            _context.SaveChanges();
            return new Success();
        }
    }
}
