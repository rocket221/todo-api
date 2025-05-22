using Domain.Models;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using OneOf;
using OneOf.Types;
using Service.ModelExtensions;
using Service.Models;

namespace Service.Services
{
    public class SheetService : ISheetService
    {
        private readonly TodoContext _context;

        public SheetService(TodoContext context)
        {
            _context = context;
        }

        public OneOf<Sheet, NotFound> GetById(int sheetId)
        {
            var sheet =  _context.Sheets
                .Include(sheet => sheet.Items)
                .FirstOrDefault(sheet => sheet.Id == sheetId);

            if (sheet == null)
            {
                return new NotFound();
            }

            return sheet;
        }

        public List<Sheet> GetAllSheets()
        {
            var sheets = _context.Sheets.Include(x => x.Items).ToList();
            return sheets;
        }

        public OneOf<Sheet> Create(CreateSheetModel createSheetModel)
        {
            throw new NotImplementedException();
            //var sheet = _mapper.Map<Sheet>(createSheetModel);
            //sheet.SetIdsAndDates();

            //var entity = _context.Sheets.Add(sheet);
            //_context.SaveChanges();

            //return entity.Entity;
        }

        public OneOf<Sheet, NotFound> Update(int sheetId, UpdateSheetModel sheet)
        {
            var entity = _context.Sheets.FirstOrDefault(sheet => sheet.Id == sheetId);
            if (entity == null)
            {
                return new NotFound();
            }
            entity.Update(sheet);

            _context.SaveChanges();
            return entity;
        }

        //TODO validate this
        public OneOf<Success, NotFound> Delete(int sheetId)
        {
            var sheet = new Sheet { Id = sheetId };
            _context.Sheets.Attach(sheet);
            _context.Sheets.Remove(sheet);

            var changes = _context.SaveChanges();
            if (changes == 0)
                return new NotFound();
            return new Success();
        }
    }
}
