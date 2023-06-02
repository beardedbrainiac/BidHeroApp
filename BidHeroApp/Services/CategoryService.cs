using AutoMapper;
using BidHeroApp.Data;
using BidHeroApp.Exceptions;
using BidHeroApp.InputModels;
using BidHeroApp.Models;
using BidHeroApp.Services.Contracts;
using BidHeroApp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace BidHeroApp.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;

        public CategoryService(
            IMapper mapper,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<IList<CategoryViewModel>> ListAsync()
        {
            try
            {
                var categories = await _context.Categories.Where(x => !x.IsDeleted).ToListAsync();

                return _mapper.Map<List<CategoryViewModel>>(categories);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CategoryViewModel> AddAsync(CategoryInputModel model)
        {
            try
            {
                var categoryObject = new Category()
                {
                    Name = model.Name,
                    IsActive = model.IsActive,
                    CreatedByUserId = model.GetUserId()
                };

                var category = await _context.Categories.AddAsync(categoryObject);
                await _context.SaveChangesAsync();

               return _mapper.Map<CategoryViewModel>(category.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CategoryViewModel> UpdateAsync(CategoryInputModel model)
        {
            try
            {
                var category = await _context.Categories.Where(x => x.Id == model.Id && !x.IsDeleted).FirstOrDefaultAsync();
                
                if (category != null)
                {
                    category.Name = model.Name;
                    category.IsActive = model.IsActive;
                    category.UpdatedByUserId = model.GetUserId();
                    category.UpdatedDate = DateTimeOffset.UtcNow;
                    _context.Categories.Update(category);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<CategoryViewModel>(category);
                }

                throw new NotFoundException("Category not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<CategoryViewModel> DeleteAsync(DeleteInputModel model)
        {
            try
            {
                var category = await _context.Categories.Where(x => x.Id == model.Id && !x.IsDeleted).FirstOrDefaultAsync();

                if (category != null)
                {
                    category.IsDeleted = true;
                    category.DeletedByUserId = model.GetUserId();
                    category.DeletedDate = DateTimeOffset.UtcNow;
                    _context.Categories.Update(category);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<CategoryViewModel>(category);
                }

                throw new NotFoundException("Category not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
