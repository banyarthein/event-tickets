using AutoMapper;
using GlobalEvents.Application.Features.Categories.Queries.GetCategoryList;
using GlobalEvents.Application.Interface.Infrastructure;
using GlobalEvents.Application.Interface.Persistence;
using GlobalEvents.Application.Model.Common;
using MediatR;

namespace GlobalEvents.Application.Features.Categories.Queries.GetCategoryExport
{
    public class GetCategoryExportQueryHandler : IRequestHandler<GetCategoryExportQuery, ExportFile>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepo _categoryRepo;
        private readonly ICSVExporter<CategoryListModel> _csvExporter;

        public GetCategoryExportQueryHandler(IMapper mapper, ICategoryRepo categoryRepo, ICSVExporter<CategoryListModel> csvExporter)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
            _csvExporter = csvExporter;
        }

        public async Task<ExportFile> Handle(GetCategoryExportQuery request, CancellationToken cancellationToken)
        {
            var allCategories = (await _categoryRepo.ListAllAsync()).OrderBy(c => c.Name);
            var categoryExport = _mapper.Map(allCategories, new List<CategoryListModel>());

            var fileData = _csvExporter.ExportToCSV(categoryExport);

            ExportFile exportFile = new ExportFile() { ContentType = "text/csv", Data = fileData, FileName = $"Category_List_{DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss")}.csv" };

            return exportFile;

        }
    }
}
