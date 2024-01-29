using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalIR.BusinessLayer.Abstract;
using SignalIR.DtoLayer.CategoryDto;
using SignalIRApi.EntityLayer.Entities;

namespace SignalIRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var value = _mapper.Map<List<ResultCategoryDto>>(_categoryService.TGetListAll());
            return Ok(value);
        }
        [HttpGet("CategoryCount")]
        public IActionResult CategoryCount()
        {
            return Ok(_categoryService.TCategoryCount());
        }
        [HttpGet("ActiveCategoryCount")]
        public IActionResult ActiveCategoryCount()
        {
            return Ok(_categoryService.TActiveCategoryCount());
        }
        [HttpGet("PasiveCategoryCount")]
        public IActionResult PasiveCategoryCount()
        {
            return Ok(_categoryService.TPasiveCategoryCount());
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _categoryService.TAdd(new Category
            {
                CategoryName = createCategoryDto.CategoryName,
                Status = true
            });
            return Ok("Kategori eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            _categoryService.TDelete(value);
            return Ok("Kategori silindi");
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value = _categoryService.TGetByID(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _categoryService.TUpdate(new Category()
            {
                CategoryName = updateCategoryDto.CategoryName,
                CategoryID= updateCategoryDto.CategoryID,   
                Status = updateCategoryDto.Status
            });
            return Ok("Kategori güncellendi");
        }
    }
}
