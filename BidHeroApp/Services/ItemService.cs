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
    public class ItemService : IItemService
    {
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;

        public ItemService(
            IMapper mapper,
            IWebHostEnvironment environment,
            ApplicationDbContext context)
        {
            _mapper = mapper;
            _environment = environment;
            _context = context;
        }

        public async Task<IList<ItemViewModel>> ListAsync()
        {
            try
            {
                var items = await _context.Items
                    .Include(x => x.Category)
                    .Where(x => !x.IsDeleted).ToListAsync();

                return _mapper.Map<List<ItemViewModel>>(items);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ItemViewModel> AddAsync(ItemInputModel model)
        {
            try
            {
                int categoryId = model.Category;

                var category = await _context.Categories.Where(x => x.Id == categoryId).FirstOrDefaultAsync();
                if (category == null)
                {
                    throw new NotFoundException($"Category ID {categoryId} not found!");
                }

                var itemObject = new Item()
                {
                    Name = model.Name,
                    IsActive = model.IsActive,
                    Code = model.Code,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    CategoryId = category.Id,
                    Category = category,
                    CreatedByUserId = model.GetUserId()
                };

                if (model.Image != null)
                {
                    long maxFileSize = 1024 * 15;
                    string fileExtension = Path.GetExtension(model.Image.Name);
                    string trustedFileNameForFileStorage = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                    string webPath = Path.Combine("uploads", "items", $"{trustedFileNameForFileStorage}{fileExtension}");
                    string path = Path.Combine(_environment.WebRootPath, webPath);

                    itemObject.Image = webPath;

                    await using FileStream fs = new(path, FileMode.Create);
                    await model.Image.OpenReadStream(maxFileSize).CopyToAsync(fs);
                }

                var item = await _context.Items.AddAsync(itemObject);
                await _context.SaveChangesAsync();

               return _mapper.Map<ItemViewModel>(item.Entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IList<ItemViewModel>> AddRangeAsync(ItemsInputModel model)
        {
            try
            {
                var list = new List<ItemViewModel>();

                if (model.Quantity > 0)
                {
                    string batchCode = DateTime.Now.ToString("yyyyMMddHHmmss");
                    int categoryId = model.Category;

                    var category = await _context.Categories.Where(x => x.Id == categoryId).FirstOrDefaultAsync();
                    if (category == null)
                    {
                        throw new NotFoundException($"Category ID {categoryId} not found!");
                    }

                    for (int i = 0; i < model.Quantity; i++)
                    {
                        string itemCode = $"{batchCode}{(i + 1).ToString("D3")}";

                        var itemObject = new Item()
                        {
                            Name = model.Name,
                            IsActive = model.IsActive,
                            Code = itemCode,
                            StartDate = model.StartDate,
                            EndDate = model.EndDate,
                            CategoryId = category.Id,
                            Category = category,
                            CreatedByUserId = model.GetUserId()
                        };

                        if (model.Image != null)
                        {
                            long maxFileSize = 1024 * 15;
                            string fileExtension = Path.GetExtension(model.Image.Name);
                            string trustedFileNameForFileStorage = Path.GetFileNameWithoutExtension(Path.GetRandomFileName());
                            string webPath = Path.Combine("uploads", "items", $"{trustedFileNameForFileStorage}{fileExtension}");
                            string path = Path.Combine(_environment.WebRootPath, webPath);

                            itemObject.Image = webPath;

                            await using FileStream fs = new(path, FileMode.Create);
                            await model.Image.OpenReadStream(maxFileSize).CopyToAsync(fs);
                        }

                        var item = await _context.Items.AddAsync(itemObject);
                        await _context.SaveChangesAsync();

                        var itemViewModel = _mapper.Map<ItemViewModel>(item.Entity);

                        list.Add(itemViewModel);
                    }
                }

                return list;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<ItemViewModel> UpdateAsync(ItemInputModel model)
        {
            try
            {
                int categoryId = model.Category;

                var item = await _context.Items
                    .Include(x => x.Category)
                    .Where(x => x.Id == model.Id && !x.IsDeleted)
                    .FirstOrDefaultAsync();

                if (item != null)
                {
                    if (item.CategoryId != categoryId)
                    {
                        var category = await _context.Categories.Where(x => x.Id == categoryId).FirstOrDefaultAsync();
                        if (category == null)
                        {
                            throw new NotFoundException($"Category ID {categoryId} not found!");
                        }

                        item.Category = category;
                        item.CategoryId = category.Id;
                    }

                    item.Name = model.Name;
                    item.Code = model.Code;
                    item.StartDate = model.StartDate;
                    item.EndDate = model.EndDate;
                    item.IsActive = model.IsActive;
                    item.UpdatedByUserId = model.GetUserId();
                    item.UpdatedDate = DateTimeOffset.UtcNow;
                    _context.Items.Update(item);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<ItemViewModel>(item);
                }

                throw new NotFoundException("Item not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ItemViewModel> DeleteAsync(DeleteInputModel model)
        {
            try
            {
                var item = await _context.Items
                    .Include(x => x.Category)
                    .Where(x => x.Id == model.Id && !x.IsDeleted)
                    .FirstOrDefaultAsync();

                if (item != null)
                {
                    item.IsDeleted = true;
                    item.DeletedByUserId = model.GetUserId();
                    item.DeletedDate = DateTimeOffset.UtcNow;
                    _context.Items.Update(item);
                    await _context.SaveChangesAsync();
                    return _mapper.Map<ItemViewModel>(item);
                }

                throw new NotFoundException("Item not found!");
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
